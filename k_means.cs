using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSGeo.GDAL;
using OpenCvSharp;

namespace RSImageProgressing
{
    public partial class k_means : Form
    {
        static Bitmap bitmap1;
        public k_means(Bitmap bitmap)
        {
            InitializeComponent();
            bitmap1 = bitmap;

        }
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            #region 变量
            double threshold = 0.01 * double.Parse(textBox2.Text);//变化阈值
            int maxLter = int.Parse(maxIter.Text);//最大迭代次数
            int classN = int.Parse(classNum.Text);//类别数
            #endregion
            if (classN > 8)
            {
                MessageBox.Show("请输入小于8的数", "Error");
                return;
            }
            Mat source = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap1);//bitmap转mat;
            int width = source.Cols;
            int height = source.Rows;
            int dims = source.Channels();
            Scalar s10 = new Scalar(10);
            int simpleCount = width * height;//数据数量
            int clusterCount = classN;       //聚类个数
            Mat point = new Mat(simpleCount, dims, MatType.CV_32F, s10);//一维数据对象
            Mat labels = new Mat();
            Mat centers = new Mat(clusterCount, 1, point.Type());
            ////二维图像转换为一维数据集
            int index = 0;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    index = row * width + col;
                    Vec3b rgb = source.At<Vec3b>(row, col);
                    point.At<float>(index, 0) = (int)(rgb[0]);
                    point.At<float>(index, 1) = (int)(rgb[1]);
                    point.At<float>(index, 2) = (int)(rgb[2]);
                }
            }


            // 运行K-Means数据分类
            //TermCriteria模板类，迭代算法的终止条件,该类变量需要3个参数.
            //CvTermCriteria cvCheckTermCriteria(CvTermCriteria criteria,
            //                                      double default_eps,
            //                                   int default_max_iters);
            //第一个参数：迭代终止条件类型。
            //CV_TERMCRIT_ITER：达到最大迭代次数终止。
            //CV_TERMCRIT_EPS：迭代到阈值终止。
            //CV_TERMCRIT_ITER+CV_TERMCRIT_EPS：两者都作为迭代终止条件。
            //以上的宏对应的c++的版本分别为TermCriteria::COUNT、TermCriteria::EPS，这里的COUNT也可以写成MAX_ITER。
            //c#对应的是CriteriaType.Count,CriteriaType.Eps,CriteriaType.MaxIter)
            //第二个参数：迭代的最大次数。
            //第三个参数：阈值。

            TermCriteria criteria = new TermCriteria(CriteriaType.MaxIter, maxLter, threshold);
            Cv2.Kmeans(point, clusterCount, labels, criteria, 3, KMeansFlags.PpCenters, centers);
            //显示图像分割结果
            Mat result = Mat.Zeros(source.Size(), MatType.CV_8UC3);
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    index = row * width + col;
                    int label = labels.At<int>(index, 0);
                    if (label == 0)
                    {
                        Vec3b vec = new Vec3b(0, 0, 0);
                        result.Set<Vec3b>(col, row, vec);

                    }
                    else if (label == 1)
                    {
                        Vec3b vec = new Vec3b(255, 0, 0);
                        result.Set<Vec3b>(col, row, vec);
                    }
                    else if (label == 2)
                    {
                        Vec3b vec = new Vec3b(0, 255, 0);
                        result.Set<Vec3b>(col, row, vec);
                    }
                    else if (label == 3)
                    {
                        Vec3b vec = new Vec3b(0, 0, 255);
                        result.Set<Vec3b>(col, row, vec);
                    }
                    else if (label == 4)
                    {
                        Vec3b vec = new Vec3b(255, 255, 0);
                        result.Set<Vec3b>(col, row, vec);
                    }
                    else if (label == 5)
                    {
                        Vec3b vec = new Vec3b(255, 0, 255);
                        result.Set<Vec3b>(col, row, vec);
                    }
                    else if (label == 6)
                    {
                        Vec3b vec = new Vec3b(0, 255, 255);
                        result.Set<Vec3b>(col, row, vec);
                    }
                    else if (label == 7)
                    {
                        Vec3b vec = new Vec3b(255, 255, 255);
                        result.Set<Vec3b>(col, row, vec);
                    }
                }
            }
            if (textBox3.Text != "" && textBox3.Text != null)
            {
                Cv2.ImWrite(textBox3.Text, result);
                Cv2.ImShow("Result", result);
                Cv2.WaitKey(0);
            }
            else
            {
                Cv2.ImShow("Result", result);
                Cv2.WaitKey(0);
                MessageBox.Show("未保存");
            }

            //Bitmap newbitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(source); // mat 转 bitmap;
            //pictureBox001.Image = newbitmap;


        }

        private void saveFile_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "保存为";
            saveDlg.Filter =
                "BMP文件 (*.bmp) | *.bmp|" +
                "Gif文件 (*.gif) | *.gif|" +
                "JPEG文件 (*.jpg) | *.jpg|" +
                "PNG文件 (*.png) | *.png";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDlg.FileName;
                textBox3.Text = fileName;
            }
        }







        ///错误的方法，流的问题上有错误！！！！！！///
        //public static Bitmap KMeansCluster(Bitmap srcBitmap, int k)
        //{
        //    if (srcBitmap != null)
        //    {
        //        int w = srcBitmap.Width;
        //        int h = srcBitmap.Height;
        //        MemoryStream ms = new MemoryStream();
        //        byte[] imagedata = null;
        //        srcBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
        //        imagedata = ms.GetBuffer();
        //        //Bitmap dstImage = new Bitmap(w, h);
        //        byte[] temp = imagedata;
        //        byte[] tempMask = (byte[])temp.Clone();
        //        //WriteableBitmap dstImage = new WriteableBitmap(w, h);
        //        //byte[] temp = src.PixelBuffer.ToArray();
        //        //byte[] tempMask = (byte[])temp.Clone();
        //        int b = 0, g = 0, r = 0;
        //        //定义灰度图像信息存储变量
        //        byte[] imageData = new byte[w * h];
        //        //定义聚类均值存储变量(存储每一个聚类的均值)
        //        double[] meanCluster = new double[k];
        //        //定义聚类标记变量(标记当前像素属于哪一类)
        //        int[] markCluster = new int[w * h];
        //        //定义聚类像素和存储变量(存储每一类像素值之和)
        //        double[] sumCluster = new double[k];
        //        //定义聚类像素统计变量(存储每一类像素的数目)
        //        int[] countCluster = new int[k];
        //        //定义聚类RGB分量存储变量(存储每一类的RGB三分量大小)
        //        int[] sumR = new int[k];
        //        int[] sumG = new int[k];
        //        int[] sumB = new int[k];
        //        //临时变量
        //        int sum = 0;
        //        //循环控制变量
        //        bool s = true;
        //        double[] mJduge = new double[k];
        //        double tempV = 0;
        //        int cou = 0;
        //        //获取灰度图像信息 
        //        for (int j = 0; j < h; j++)
        //        {
        //            for (int i = 0; i < w; i++)
        //            {
        //                b = tempMask[i * 4 + j * w * 4];
        //                g = tempMask[i * 4 + 1 + j * w * 4];
        //                r = tempMask[i * 4 + 2 + j * w * 4];
        //                imageData[i + j * w] = (byte)(b * 0.114 + g * 0.587 + r * 0.299);
        //            }
        //        }
        //        while (s)
        //        {
        //            sum = 0;
        //            //初始化聚类均值
        //            for (int i = 0; i < k; i++)
        //            {
        //                meanCluster[i] = i * 255.0 / (k - 1);
        //            }
        //            //计算聚类归属
        //            for (int i = 0; i < imageData.Length; i++)
        //            {
        //                tempV = Math.Abs((double)imageData[i] - meanCluster[0]);
        //                cou = 0;
        //                for (int j = 1; j < k; j++)
        //                {
        //                    double t = Math.Abs((double)imageData[i] - meanCluster[j]);
        //                    if (tempV > t)
        //                    {
        //                        tempV = t;
        //                        cou = j;
        //                    }
        //                }
        //                countCluster[cou]++;
        //                sumCluster[cou] += (double)imageData[i];
        //                markCluster[i] = cou;
        //            }
        //            //更新聚类均值
        //            for (int i = 0; i < k; i++)
        //            {
        //                meanCluster[i] = sumCluster[i] / (double)countCluster[i];
        //                sum += (int)(meanCluster[i] - mJduge[i]);
        //                mJduge[i] = meanCluster[i];
        //            }
        //            if (sum == 0)
        //            {
        //                s = false;
        //            }
        //        }
        //        //计算聚类RGB分量
        //        for (int j = 0; j < h; j++)
        //        {
        //            for (int i = 0; i < w; i++)
        //            {
        //                sumB[markCluster[i + j * w]] += tempMask[i * 4 + j * w * 4];
        //                sumG[markCluster[i + j * w]] += tempMask[i * 4 + 1 + j * w * 4];
        //                sumR[markCluster[i + j * w]] += tempMask[i * 4 + 2 + j * w * 4];
        //            }
        //        }
        //        for (int j = 0; j < h; j++)
        //        { 
        //            for (int i = 0; i < w; i++)
        //            {
        //                temp[i * 4 + j * 4 * w] = (byte)(sumB[markCluster[i + j * w]] / countCluster[markCluster[i + j * w]]);
        //                temp[i * 4 + 1 + j * 4 * w] = (byte)(sumG[markCluster[i + j * w]] / countCluster[markCluster[i + j * w]]);
        //                temp[i * 4 + 2 + j * 4 * w] = (byte)(sumR[markCluster[i + j * w]] / countCluster[markCluster[i + j * w]]);
        //            }
        //        }
        //        MemoryStream ms2 = new MemoryStream();
        //        srcBitmap.Save(ms2, System.Drawing.Imaging.ImageFormat.Tiff);
        //        //Stream sTemp = dstImage.PixelBuffer.AsStream();
        //        ms2.Seek(0, SeekOrigin.Begin);
        //        ms2.Write(temp, 0, w * 4 * h);
        //        return dstImage;

        //    }
        //}
    }
}
