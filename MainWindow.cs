using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OSGeo.GDAL;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace RSImageProgressing
{
    public partial class MainWindow : Form
    {
        bool _panelOp = true;//文件列表是否处于打开状态,默认是打开状态
        bool _panel2Op = false;//图片信息是否处于打开状态
        bool _pictureChoose = false;//图片是否被选中
        string _filePath;
        int _fileIndex = 0;
        Bitmap _bitmap;
        Dataset ds;
        bool isSelected;
        int isDan=0;
        Point mouseDownPoint;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            fileList.Checked = false;

            #region 每隔1s加载时间
            timer1.Interval = 1000;
            timeNow.Text = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            timer1.Start();
            #endregion


        }
        //加载时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeNow.Text = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        //打开文件
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //允许打开的文件格式
            ofd.Filter =
                "Erdas Imagine (*.img)|*.img|" +
                "GeoTiff (*.tif *.tiff)|*.tif;*.tiff|" +
                "HDF (*.hdf *.h5 *he5)|*.hdf;*.h5;*he5|" +
                "位图文件 (*.bmp)|*.bmp|" +
                "Graphics Interchange Format (*.gif)|*.gif|" +
                "JPEG (*.jpg *.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphics (*.png)|*.png|" +
                "所有文件|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //将文件添加到Treeview中
                _filePath = ofd.FileName;
                AddPicture(_filePath);
                //fileTree.Nodes[0].Nodes.Add(ofd.FileName);
                //MessageBox.Show("文件成功打开！");
                //每添加一个图片,索引加一个
                _fileIndex++;
            }
        }
        //显示列表
        private void listView_Click(object sender, EventArgs e)
        {
            //判断是否处于选中状态
            if (!_panelOp)
            {
                panel1.Visible = false;
                _panelOp = true;
                fileList.Checked = false;
            }
            else
            {
                panel1.Visible = true;
                _panelOp = false;
                fileList.Checked = true;
            }
        }
        //退出程序
        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出？", "提示", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// 添加图片及波段到Tree View控件里面去
        /// </summary>
        /// <param name="filePath">图片的绝对路径</param>
        private void AddPicture(string filePath)
        {
            string filename = Path.GetFileNameWithoutExtension(filePath);
            fileTree.Nodes[0].Nodes.Add(filename);
            fileTree.Nodes[0].Nodes[_fileIndex].Tag = filePath;
            Gdal.AllRegister();
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
            ds = Gdal.Open(filePath, Access.GA_ReadOnly);
            int bandCount = ds.RasterCount;
            for (int i = 0; i < bandCount; i++)
            {
                fileTree.Nodes[0].Nodes[_fileIndex].Nodes.Add("Band" + (i + 1).ToString());
            }
        }
        private void fileTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                int x = e.X;
                int y = e.Y;
                TreeNode CurrentNode = fileTree.GetNodeAt(ClickPoint);
                //判断你点的是不是一个节点
                if (CurrentNode is TreeNode)
                {
                    fileTree.SelectedNode = CurrentNode;
                    //判断是否是中间的那个节点，一级节点和三级节点不行
                    if (CurrentNode.Parent != null && CurrentNode.LastNode != null)
                    {
                        CurrentNode.ContextMenuStrip = this.contextMenuStrip1;
                        contextMenuStrip1.Show(MousePosition);
                    }
                }
                else
                {
                    MessageBox.Show("请正确选择节点");
                    return;
                }
            }
        }
        //显示图片
        private void ShowImage_Click(object sender, EventArgs e)
        {
            TreeNode imageNode = fileTree.SelectedNode;
            string filePath = imageNode.Tag.ToString();
            Gdal.AllRegister();
            ds = Gdal.Open(filePath, Access.GA_ReadOnly);
            //获取波段数
            int bandCount = ds.RasterCount;


            Rectangle pictureRect = new Rectangle();
            pictureRect.X = 0;
            pictureRect.Y = 0;
            pictureRect.Width = 600;
            pictureRect.Height = 450;
            Foudation fd = new Foudation();
            if (bandCount == 3)
            {
                BandSelection selection = new BandSelection();
                selection.ShowDialog();
                int[] bandList = new int[3];
                bandList[0] = selection.Band1;
                bandList[1] = selection.Band2;
                bandList[2] = selection.Band3;
                _bitmap = fd.GetImage(ds, pictureRect, bandCount, bandList);
            }
            else
            {
                Band band = ds.GetRasterBand(1);
                // _bitmap = null;
                _bitmap = fd.GetImage(ds, pictureRect, band);
            }
            pictureBox1.Image = _bitmap;
            _pictureChoose = true;
        }
        //显示直方图
        private void ShowHistigram_Click(object sender, EventArgs e)
        {
            _filePath = fileTree.SelectedNode.Tag.ToString();
            Histogram his = new Histogram(_filePath);
            his.ShowDialog();
        }
        //显示图片信息
        private void ShowImageMessage_Click(object sender, EventArgs e)
        {
            if (!_panel2Op)
            {
                panel2.Visible = true;
                _panel2Op = true;
                if (_filePath == null)
                {
                    MessageBox.Show("请选择一个图片！");
                    return;
                }
                _filePath = fileTree.SelectedNode.Tag.ToString();
                imgMessge.Text = _filePath;
            }
            else
            {
                panel2.Visible = false;
                _panel2Op = false;
            }
        }
        //获取点的坐标
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.Location;
            if (_pictureChoose == true)
            {

                //ds.GetGeoTransform(tran);
                //pre_x = e.X * 1.0f / pictureBox1.Width * ds.RasterXSize;
                //pre_y = e.Y * 1.0f / pictureBox1.Height * ds.RasterYSize;
                //// 坐标转换
                //double x = tran[0] + pre_x * tran[1] + pre_y * tran[2];
                //double y = tran[3] + pre_x * tran[4] + pre_y * tran[5];
                double[] getxy = new double[2];
                int pointx = e.X;
                int pointy = e.Y;
                getxy =GetTrueX(ds,pointx,pointy);
                double x = getxy[0];
                double y = getxy[1];
                //状态栏显示
                coordanite.Text = "坐标：" + x.ToString() + "," + y.ToString();
            }
        }
        //放大
        private void ZoomOut_Click(object sender, EventArgs e)
        {
            if (_bitmap != null)
            {
                try
                {
                    Image img = _bitmap;
                    int nwidth = (int)(pictureBox1.Width * 1.5);
                    int nheight = (int)(pictureBox1.Height * 1.5);
                    System.Drawing.Image sbmpthum = img.GetThumbnailImage(nwidth, nheight, () => { return false; }, IntPtr.Zero);
                    pictureBox1.Image = sbmpthum;
                }
                catch (Exception)
                {
                    MessageBox.Show("不能再放大了！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("没选择图片");
                return;
            }
        }
        //缩小
        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if (_bitmap != null)
            {
                try
                {
                    Image img = _bitmap;
                    int nwidth = (int)(pictureBox1.Width * 0.5);
                    int nheight = (int)(pictureBox1.Height * 0.5);
                    System.Drawing.Image sbmpthum = img.GetThumbnailImage(nwidth, nheight, () => { return false; }, IntPtr.Zero);
                    pictureBox1.Image = sbmpthum;
                }
                catch (Exception)
                {
                    MessageBox.Show("不能再缩小了！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("没选择图片");
                return;
            }
        }
        private void kmeans算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if ((Bitmap)pictureBox1.Image != null)
            {
                k_means k = new k_means((Bitmap)pictureBox1.Image);
                k.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有图像");
                //this.Close();
            }
            
            
        }

        private void 直方图均衡化ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Bitmap bitmap = pictureBox1.Image as Bitmap;
            if (bitmap != null)
            {
                Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = bitmap.Width * bitmap.Height * 3;
                byte[] grayValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);
                byte temp;
                int[] countPixel = new int[256];
                int[] tempArray = new int[256];
                byte[] pixelMap = new byte[256];
                for (int i = 0; i < bytes; i++)
                {
                    temp = grayValues[i];
                    countPixel[temp]++;
                }
                for (int i = 0; i < 256; i++)
                {
                    if (i != 0)
                    {
                        tempArray[i] = tempArray[i - 1] + countPixel[i];
                    }
                    else
                    {
                        tempArray[0] = countPixel[0];
                    }

                    pixelMap[i] = (byte)(255.0 * tempArray[i] / bytes + 0.5);
                }
                for (int i = 0; i < bytes; i++)
                {
                    temp = grayValues[i];
                    grayValues[i] = pixelMap[temp];
                }
                System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                bitmap.UnlockBits(bmpData);
                pictureBox1.Image = null;
                pictureBox1.Image = bitmap;
            }
            else
            {
                MessageBox.Show("失败");
                return;
            }
        }

        private void 线性拉伸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = pictureBox1.Image as Bitmap;
            if (bitmap != null)
            {

                Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = bitmap.Width * bitmap.Height * 3;
                byte[] grayValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

                byte a = 255, b = 0;
                double p;

                for (int i = 0; i < bytes; i++)
                {
                    if (a > grayValues[i])
                    {
                        a = grayValues[i];
                    }
                    if (b < grayValues[i])
                    {
                        b = grayValues[i];
                    }
                }
                p = 255.0 / (b - a);

                for (int i = 0; i < bytes; i++)
                {
                    grayValues[i] = (byte)(p * (grayValues[i] - a) + 0.5);
                }

                System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                bitmap.UnlockBits(bmpData);
                pictureBox1.Image = null;
                pictureBox1.Image = bitmap;
            }
            else
            {
                MessageBox.Show("失败");
                return;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap curBitmap = pictureBox1.Image as Bitmap;
            if (curBitmap == null)
            {
                return;
            }
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "保存为";
            saveDlg.OverwritePrompt = true;
            saveDlg.Filter =
                "BMP文件 (*.bmp) | *.bmp|" +
                "Gif文件 (*.gif) | *.gif|" +
                "JPEG文件 (*.jpg) | *.jpg|" +
                "Tiff文件（*.tif）|*.tif|" +
                "PNG文件 (*.png) | *.png";
            saveDlg.ShowHelp = true;
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDlg.FileName;
                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                switch (strFilExtn)
                {
                    case "bmp":
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }

        }

        private void 显示光谱特征ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MouseEventArgs m;            
            _filePath = fileTree.SelectedNode.Tag.ToString();
            ds=Gdal.Open(_filePath, Access.GA_ReadOnly);
            Point formPoint = pictureBox1.PointToClient(Control.MousePosition);//this.PointToClient(Control.MousePosition);
            int _imgX = formPoint.X;
            int _imgY = formPoint.Y;
            Spectrum spectrum = new Spectrum(_filePath,_imgX,_imgY,pictureBox1);
            spectrum.Show();
        }

        private void 阈值分割ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Bitmap curBitmap = (Bitmap)pictureBox1.Image;
            //Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
            //System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
            //IntPtr ptr = bmpData.Scan0;
            //int bytes = bmpData.Height * bmpData.Stride;
            //byte[] grayValues = new byte[bytes];
            //System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

            //byte T = 0, S = 0;
            //byte[] neighb = new byte[bytes];
            //byte temp = 0;
            //byte maxGray = 0;
            //byte minGray = 255;
            //int[] countPixel = new int[256];
            //for (int i = 0; i < grayValues.Length; i++)
            //{
            //    temp = grayValues[i];
            //    countPixel[temp]++;
            //    if (temp > maxGray)
            //    {
            //        maxGray = temp;
            //    }
            //    if (temp < minGray)
            //    {
            //        minGray = temp;
            //    }
            //}
            //double mu1, mu2;
            //int numerator;
            //double sigma;
            //double tempMax = 0;
            //double w1 = 0, w2 = 0;
            //double sum = 0;
            //numerator = 0;
            //for (int i = minGray; i <= maxGray; i++)
            //{
            //    sum += i * countPixel[i];
            //}
            //for (int i = minGray; i < maxGray; i++)
            //{
            //    w1 += countPixel[i];
            //    numerator += i * countPixel[i];
            //    mu1 = numerator / w1;
            //    w2 = grayValues.Length - w1;
            //    mu2 = (sum - numerator) / w2;
            //    sigma = w1 * w2 * (mu1 - mu2) * (mu1 - mu2);

            //    if (sigma > tempMax)
            //    {
            //        tempMax = sigma;
            //        T = Convert.ToByte(i);
            //    }
            //}
            //for (int i = 0; i < bytes; i++)
            //{
            //    if (grayValues[i] < T)
            //        grayValues[i] = 0;
            //    else
            //        grayValues[i] = 255;

            //}

            //System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
            //curBitmap.UnlockBits(bmpData);
            //pictureBox1.Image = curBitmap;
            ///*************************///
            if (pictureBox1.Image != null)
            {
                Bitmap bitmap = (Bitmap)pictureBox1.Image;
                int imgWidth = pictureBox1.Width;
                int imgHeight = pictureBox1.Height;
                int AllLength = imgWidth * imgHeight;
                int[] CountPixel = new int[256];
                for (int x = 0; x < imgWidth; x++)
                {
                    for (int y = 0; y < imgHeight; y++)
                    {
                        Color curcolor = bitmap.GetPixel(x, y);
                        CountPixel[curcolor.R]++;
                    }
                }

                //求取中值
                byte T = 0;
                int mid = AllLength / 2;
                int sum = 0;
                for (byte i = 0; i <= 255; i++)
                {
                    if (sum > mid)
                    {
                        T = i;
                        break;
                    }
                    else
                    {
                        sum += CountPixel[i];
                    }
                }

                byte oldT = 0;
                int u1, u2;
                int numerator, denominator;
                //进行迭代
                do
                {
                    oldT = T;
                    numerator = 0; denominator = 0;
                    for (int i = 0; i < T; i++)
                    {
                        numerator += i * CountPixel[i];
                        denominator += CountPixel[i];
                    }
                    u1 = numerator / denominator;

                    numerator = 0; denominator = 0;
                    for (int i = T; i < 256; i++)
                    {
                        numerator += i * CountPixel[i];
                        denominator += CountPixel[i];
                    }
                    u2 = numerator / denominator;

                    T = Convert.ToByte((u1 + u2) / 2);
                }
                while (oldT != T);

                for (int x = 0; x < imgWidth; x++)
                {
                    for (int y = 0; y < imgHeight; y++)
                    {
                        Color curcolor = bitmap.GetPixel(x, y);
                        int r;

                        if (curcolor.R < T)
                            r = 0;
                        else
                            r = 255;

                        Color newcolor = Color.FromArgb(r, r, r);
                        bitmap.SetPixel(x, y, newcolor);
                    }
                }
                pictureBox1.Image = bitmap;
            }
            else
                MessageBox.Show("没有图片！");
        }
        
        //OSTU（最大类间方差）法（来自网络）
        private void oSTUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Otsu ot = new Otsu();
                Bitmap bitmap = (Bitmap)pictureBox1.Image;
                ot.Convert2GrayScaleFast(bitmap);
                int otsuThreshold = ot.getOtsuThreshold((Bitmap)bitmap);
                ot.threshold(bitmap, otsuThreshold);
                MessageBox.Show(otsuThreshold.ToString(), "阈值");
                pictureBox1.Image = bitmap;
            }
            else
                MessageBox.Show("没有图片！");
        }

        /// <summary>
        /// 求地理坐标
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="pointx">地理坐标x</param>
        /// <param name="pointy">地理坐标x</param>
        /// <returns></returns>
        public double[] GetTrueX(Dataset ds,int pointx,int pointy)
        {
            double[] tran = new double[6];
            ds.GetGeoTransform(tran);
            float pre_x = pointx * 1.0f / pictureBox1.Width * ds.RasterXSize;
            float pre_y = pointy * 1.0f / pictureBox1.Height * ds.RasterYSize;
            // 坐标转换
            double[] point = new double[2];
            point[0] = tran[0] + pre_x * tran[1] + pre_y * tran[2];
            point[1] = tran[3] + pre_x * tran[4] + pre_y * tran[5];
            return point;
        }

        private void iHS变换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IHS变换 ihs = new IHS变换();
            ihs.Show();
        }

        private void brovey变换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brovey变换 brovey = new Brovey变换();
            brovey.Show();
        }

        private void 监督分类ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MinS mins = new MinS();
            mins.ShowDialog();
        }

        private void 无人机影像粗校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image!=null)
            {
                //ds = Gdal.Open(_filePath, Access.GA_ReadOnly);
                Bitmap bitmap = (Bitmap)pictureBox1.Image;
                double pi = Math.PI;
                double[] can = new double[11];
                double w = ds.RasterXSize;
                double h = ds.RasterYSize;
                ImageCorrection iC = new ImageCorrection();
                iC.ShowDialog();
                can = iC.returnCan();

                if (can[0] == 0)
                {
                    return;
                }

                //校正参数
                double B = can[1], L = can[2], Zs = can[3], fai = can[4] / 180 * pi, w0 = can[5] / 180 * pi;
                double k = can[6] / 180 * pi, Iw = can[7] * 0.001, Ih = can[8] * 0.001, f = can[9] * 0.001, u = can[10];
                double Xs = 0, Ys = 0;
                Foudation fd = new Foudation();
                double[] xy =fd.GeoTransform(B, L);
                Xs = xy[0];
                Ys = xy[1];

                //旋转矩阵参数
                double a1 = Math.Cos(fai) * Math.Cos(k) - Math.Sin(fai) * Math.Sin(w0) * Math.Sin(k);
                double a2 = -Math.Cos(fai) * Math.Sin(k) - Math.Sin(fai) * Math.Sin(w0) * Math.Cos(k);
                double a3 = -Math.Sin(fai) * Math.Cos(w0);
                double b1 = Math.Cos(w0) * Math.Sin(k);
                double b2 = Math.Cos(w0) * Math.Cos(k);
                double b3 = -Math.Sin(w0);
                double c1 = Math.Sin(fai) * Math.Cos(k) + Math.Cos(fai) * Math.Sin(w0) * Math.Sin(k);
                double c2 = -Math.Sin(fai) * Math.Sin(k) + Math.Cos(fai) * Math.Sin(w0) * Math.Cos(k);
                double c3 = Math.Cos(fai) * Math.Cos(k);

                //角点图像坐标
                double[,] Ixy = new double[5, 3];
                Ixy[1, 1] = 0; Ixy[1, 2] = 0;
                Ixy[2, 1] = Iw; Ixy[2, 2] = Ih;
                Ixy[3, 1] = 0; Ixy[3, 2] = Ih;
                Ixy[4, 1] = Iw; Ixy[4, 2] = 0;

                //图像像元大小
                double pixelSize_x = Iw / w;
                double pixelSize_y = Ih / h;

                //角点地面坐标
                double[,] XY = new double[5, 3];

                double Zp = 750;//平均高程待定
                for (int i = 1; i < 5; i++)
                {
                    XY[i, 1] = Xs + (Zp - Zs) * (a1 * Ixy[i, 1] + a2 * Ixy[i, 2] - a3 * f)
                        / (c1 * Ixy[i, 1] + c2 * Ixy[i, 2] - c3 * f);
                    XY[i, 2] = Ys + (Zp - Zs) * (b1 * Ixy[i, 1] + b2 * Ixy[i, 2] - b3 * f)
                        / (c1 * Ixy[i, 1] + c2 * Ixy[i, 2] - c3 * f);
                }

                //输出影像最小范围
                double Xmin = (XY[1, 1] < XY[3, 1] ? XY[1, 1] : XY[3, 1]);
                double Xmax = (XY[2, 1] > XY[4, 1] ? XY[2, 1] : XY[4, 1]);
                double Ymin = (XY[3, 2] < XY[4, 2] ? XY[3, 2] : XY[4, 2]);
                double Ymax = (XY[1, 2] > XY[2, 2] ? XY[1, 2] : XY[2, 2]);
                int outwid = (int)((Xmax - Xmin) / u) + 10;
                int outhei = (int)((Ymax - Ymin) / u) + 10;

                //构建位图
                double Xp, Yp;
                double x, y;
                Driver dryMemory = Gdal.GetDriverByName("MEM");
                Dataset dsMemory = dryMemory.Create("", outwid, outhei, ds.RasterCount, DataType.GDT_CInt32, null);
                //dsMemory.SetProjection(ds.GetGCPProjection());
                double[] GeoTrans = new double[6];
                GeoTrans[0] = Xmin; GeoTrans[3] = Ymin;
                GeoTrans[1] = u; GeoTrans[5] = -u;
                GeoTrans[2] = 0; GeoTrans[4] = 0;
                dsMemory.SetGeoTransform(GeoTrans);
                dsMemory.SetProjection(" PROGCS[''G-K'']");

                for (int i = 0; i < outhei; i++)
                {
                    int[][] R = new int[ds.RasterCount][];
                    for (int bandindex = 0; bandindex < ds.RasterCount; bandindex++)
                    {
                        R[bandindex] = new int[outwid];
                    }

                    for (int j = 0; j < outwid; j++)
                    {
                        //地面坐标
                        Xp = j * u + Xmin;
                        Yp = (i) * u + Ymin;
                        //解像点坐标
                        x = -f * (a1 * (Xp - Xs) + b1 * (Yp - Ys) + c1 * (Zp - Zs)) / (a3 * (Xp - Xs) + b3 * (Yp - Ys) + c3 * (Zp - Zs));
                        y = -f * (a2 * (Xp - Xs) + b2 * (Yp - Ys) + c2 * (Zp - Zs)) / (a3 * (Xp - Xs) + b3 * (Yp - Ys) + c3 * (Zp - Zs));
                        //对应原来图像的行列号
                        int i0 = (int)(x / pixelSize_x);
                        int j0 = (int)(y / pixelSize_y);
                        if (i0 >= 0 && i0 < ds.RasterXSize && j0 >= 0 && j0 < ds.RasterYSize)
                        {
                            for (int bandindex = 0; bandindex < ds.RasterCount; bandindex++)
                            {
                                int[] r_read = new int[1];
                                Band band = ds.GetRasterBand(bandindex + 1);
                                band.ReadRaster(i0, j0, 1, 1, r_read, 1, 1, 0, 0);
                                R[bandindex][j] = r_read[0];
                            }
                        }
                        else
                        {
                            for (int bandindex = 0; bandindex < ds.RasterCount; bandindex++)
                            {
                                R[bandindex][j] = 0;
                            }
                        }
                    }
                    for (int bandindex = 0; bandindex < ds.RasterCount; bandindex++)
                    {
                        Band memBand1 = dsMemory.GetRasterBand(bandindex + 1);
                        memBand1.WriteRaster(0, i, R[bandindex].Length, 1, R[bandindex], R[bandindex].Length, 1, 0, 0);
                    }
                }
                Driver drvJPG = Gdal.GetDriverByName("GTiff");

                string dstFileName = @"E:\Correction.Tif"; ;
                //Dataset dstDs = drvJPG.Create(dstFileName, srcWidth, srcHeight, bandCount, DataType.GDT_Byte, null);
                drvJPG.CreateCopy(dstFileName, dsMemory, 1, null, null, null);
                ds = dsMemory;
                Rectangle pictureRect = new Rectangle();
                pictureRect.X = 0;
                pictureRect.Y = 0;
                pictureRect.Width = this.pictureBox1.Width;
                pictureRect.Height = this.pictureBox1.Height;
                int[] disband = new int[3] { 1, 2, 3 };
                Bitmap bitmap2 = fd.GetImage(this.ds, pictureRect,3, disband);   //遥感影像构建位图  
                pictureBox1.Image = bitmap2;
                MessageBox.Show("计算完成！");
            }
            else
            {
                MessageBox.Show("没有图像！","Error!");
            }
        }

        private void 配准ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registration rs = new registration();
            rs.ShowDialog();
        }

        private void 打开ＥＮＶＩToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Process.Start(@"E:\Study\Envi5.31\IDL85\bin\bin.x86_64\idlrt.exe");
            //MessageBox.Show("打开ENVI");
            System.Diagnostics.Process.Start(@"C:\Users\AYLuo\Desktop\学习软件\ENVI 5.3 (64-bit)");
        }

        private void 监督分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\AYLuo\Desktop\Finally.exe.lnk"); 
        }
    }
}
