using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSGeo.GDAL;

namespace RSImageProgressing
{
    public partial class Brovey变换 : Form
    {
        static Dataset ds1;
        static Dataset ds2;
        static string file1;
        static string file2;
        Image img1;
        Image img2;
        Bitmap newBitmap;

        public Brovey变换()
        {
            InitializeComponent();
        }

        private void openMsi1_Click(object sender, EventArgs e)
        {
            Gdal.AllRegister();
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
                file1 = ofd.FileName;
                ds1 = Gdal.Open(file1, Access.GA_ReadOnly);
                if (ds1.RasterCount < 3)
                {
                    MessageBox.Show("不是多波段影像！\n请重新选择", "Error");
                    file1 = null;
                }
            }
            Rectangle pictureRect = new Rectangle();
            pictureRect.X = 0;
            pictureRect.Y = 0;
            pictureRect.Width = 600;
            pictureRect.Height = 450;
            Foudation fd = new Foudation();
            int[] bandList = new int[3];
            bandList[0] = 3;
            bandList[1] = 2;
            bandList[2] = 1;
            img1 =fd.GetImage(ds1, pictureRect, 3, bandList);
        }

        private void openPan1_Click(object sender, EventArgs e)
        {
            Gdal.AllRegister();
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
                file2 = ofd.FileName;
                ds2 = Gdal.Open(file2, Access.GA_ReadOnly);
            }
            Rectangle pictureRect = new Rectangle();
            pictureRect.X = 0;
            pictureRect.Y = 0;
            pictureRect.Width = 600;
            pictureRect.Height = 450;
            Foudation fd = new Foudation();
            Band band = ds2.GetRasterBand(1);
            img2 = fd.GetImage(ds2, pictureRect, band);
        }


        private static List<int[]> GetDNs(Dataset ds, int xSize, int ySize)
        {
            List<int[]> dns = new List<int[]>();
            for (int i = 1; i <= ds.RasterCount; i++)
            {
                int[] temp = new int[xSize * ySize];
                double[] mm = { 0, 0 };
                ds.GetRasterBand(i).ComputeRasterMinMax(mm, 0);
                ds.GetRasterBand(i).ReadRaster(0, 0, ds.RasterXSize, ds.RasterYSize, temp, xSize, ySize, 0, 0);
                for (int j = 0; j < xSize * ySize; j++)
                {
                    temp[j] = (int)(((temp[j] - mm[0]) / (mm[1] - mm[0])) * 255);
                }
                dns.Add(temp);
            }
            return dns;
        }
        private void calculate_Click(object sender, EventArgs e)
        {

            Image temp;
            temp = img1;
            img1 = img2;
            img2 = temp;

            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {
                newBitmap = new Bitmap(img1.Width, img1.Height);
                Bitmap map1 = (Bitmap)img1;
                Bitmap map2 = (Bitmap)img2;
                int r, g, b, rgb, r1, r2, g2, b2;

                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        Color pixel1 = map1.GetPixel(i, j);
                        Color pixel2 = map2.GetPixel(i, j);

                        r1 = pixel1.R;
                        r2 = pixel2.R;
                        g2 = pixel2.G;
                        b2 = pixel2.B;
                        rgb = r2 + g2 + b2;

                        r = (int)(r2 * 1.0 / rgb * r1);
                        g = (int)(g2 * 1.0 / rgb * r1);
                        b = (int)(b2 * 1.0 / rgb * r1);

                        newBitmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                pictureBox1.Image = newBitmap;

            }
            else MessageBox.Show("图像大小不一致无法完成融合！");


            //Gdal.AllRegister();
            //ds1 = Gdal.Open(file1, Access.GA_ReadOnly);
            //ds2 = Gdal.Open(file2, Access.GA_ReadOnly);


            //// 全色影像单波段数据
            //int xSize = ds2.RasterXSize;
            //int ySize = ds2.RasterYSize;
            //int[] res_r = GetDNs(ds2, xSize, ySize)[0];

            //// 多光谱影像多波段数据
            //int panXSize = ds1.RasterXSize;
            //int panYSize = ds1.RasterYSize;
            //List<int[]> pans = GetDNs(ds1, xSize, ySize);




            //// 融合影像多波段数据
            //List<int[]> afts = new List<int[]>();
            //pans.ForEach(i => afts.Add(new int[xSize * ySize]));

            //// 影像融合过程
            //for (int i = 0; i < xSize; i++)
            //{
            //    for (int j = 0; j < ySize; j++)
            //    {
            //        int k = i + j * xSize;
            //        int all = 0;
            //        for (int m = 0; m < afts.Count; m++)
            //        {
            //            all += pans[m][k];
            //        }
            //        all /= afts.Count;
            //        try
            //        {
            //            for (int m = 0; m < afts.Count; m++)
            //            {
            //                afts[m][k] = (res_r[k] * pans[m][k]) / all;
            //            }
            //        }
            //        catch (DivideByZeroException)
            //        {
            //            for (int m = 0; m < afts.Count; m++)
            //            {
            //                afts[m][k] = 0;
            //            }
            //        }
            //    }
        }
        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "保存为";
            saveDlg.Filter =
                "BMP文件 (*.bmp) | *.bmp|" +
                "Gif文件 (*.gif) | *.gif|" +
                "JPEG文件 (*.jpg) | *.jpg|" +
                "PNG文件 (*.png) | *.png"+
                "Tif文件 (*.tif,*tiff) | *.tiff|" ;
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDlg.FileName; 
                using (MemoryStream mem = new MemoryStream())
                {
                    //这句很重要，不然不能正确保存图片或出错（关键就这一句）
                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    //保存到磁盘文件
                    if (saveDlg.Filter == "*bmp")
                    { 
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp); 
                    }
                    else if(saveDlg.Filter == "*gif")
                    {
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                    }
                    else if (saveDlg.Filter == "*jpg")
                    {
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else if (saveDlg.Filter == "*png")
                    {
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                    }
                    bmp.Dispose();
                    MessageBox.Show("保存成功！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        //平均梯度
        private void button1_Click(object sender, EventArgs e)
        {
            double Gr, Gg, Gb;
            int delt_xr, delt_yr, delt_xg, delt_yg, delt_xb, delt_yb;

            double map_r, map_g, map_b;
            map_r = map_g = map_b = 0;

            for (int i = 0; i < newBitmap.Width - 1; i++)
            {
                for (int j = 0; j < newBitmap.Height - 1; j++)
                {
                    Color pixel = newBitmap.GetPixel(i, j);
                    Color pixel_x = newBitmap.GetPixel(i + 1, j);
                    Color pixel_y = newBitmap.GetPixel(i, j + 1);

                    delt_xr = (pixel_x.R - pixel.R) * (pixel_x.R - pixel.R);
                    delt_yr = (pixel_y.R - pixel.R) * (pixel_y.R - pixel.R);

                    delt_xg = (pixel_x.G - pixel.G) * (pixel_x.G - pixel.G);
                    delt_yg = (pixel_y.G - pixel.G) * (pixel_y.G - pixel.G);

                    delt_xb = (pixel_x.B - pixel.B) * (pixel_x.B - pixel.B);
                    delt_yb = (pixel_y.B - pixel.B) * (pixel_y.B - pixel.B);

                    map_r += Math.Sqrt(delt_xr + delt_yr);
                    map_g += Math.Sqrt(delt_xg + delt_yg);
                    map_b += Math.Sqrt(delt_xb + delt_yb);

                }

            }

            Gr = map_r / ((newBitmap.Width - 1) * (newBitmap.Height - 1));
            Gg = map_g / ((newBitmap.Width - 1) * (newBitmap.Height - 1));
            Gb = map_b / ((newBitmap.Width - 1) * (newBitmap.Height - 1));

            MessageBox.Show("融合图三通道平均梯度" + "\r\n" + "Gr:" + Gr.ToString() + "   " + "Gg:" + Gg.ToString() + "   " + "Gb:" + Gb.ToString());
        }
        //偏差指数评价
        private void button2_Click(object sender, EventArgs e)
        {
            double Br, Bg, Bb;//三通道偏差指数

            double r, g, b;
            r = g = b = 0;
            Bitmap map2 = (Bitmap)img2;

            for (int i = 0; i < newBitmap.Width; i++)
            {
                for (int j = 0; j < newBitmap.Height; j++)
                {
                    Color pixel1 = newBitmap.GetPixel(i, j);
                    Color piexl2 = map2.GetPixel(i, j);

                    r += Math.Abs(pixel1.R - piexl2.R) * 1.0 / piexl2.R;
                    g += Math.Abs(pixel1.G - piexl2.G) * 1.0 / piexl2.G;
                    b += Math.Abs(pixel1.B - piexl2.B) * 1.0 / piexl2.B;

                }
            }

            Br = r / (newBitmap.Width * newBitmap.Height);
            Bg = g / (newBitmap.Width * newBitmap.Height);
            Bb = b / (newBitmap.Width * newBitmap.Height);

            MessageBox.Show("融合图三通道偏差指数" + "\r\n" + "Br:" + Br.ToString() + "   " + "Bg:" + Bg.ToString() + "   " + "Bb:" + Bb.ToString());
        }
    }




}