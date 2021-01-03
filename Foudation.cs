using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSGeo.GDAL;
using static RSImageProgressing.Foudation;

namespace RSImageProgressing
{
    class Foudation
    {
        public static int buckets = 4096;
        public static Foudation fd = new Foudation();
        public enum SaveType
        {
            Img = 0,
            Bmp = 1,
            Tiff = 2,
            JPG = 3,
            PNG = 4,
            GIF = 5,
            NITF = 6
        }
        public Bitmap GetImage(Dataset ds, Rectangle showRect, int bandCount, int[] bandList)
        {
            int imgWidth = ds.RasterXSize;
            int imgHeight = ds.RasterYSize;
            //影像宽高比 
            float ImgRatio = imgWidth / (float)imgHeight;

            //获取显示控件大小  
            int BoxWidth = showRect.Width;
            int BoxHeight = showRect.Height;
            //显示控件宽高比
            float BoxRatio = imgWidth / (float)imgHeight;

            //计算实际显示区域大小，防止影像畸变显示  
            int BufferWidth, BufferHeight;
            if (BoxRatio >= ImgRatio)
            {
                BufferHeight = BoxHeight;
                BufferWidth = (int)(BoxHeight * ImgRatio);
            }
            else
            {
                BufferWidth = BoxWidth;
                BufferHeight = (int)(BoxWidth / ImgRatio);
            }

            //构建位图  
            Bitmap bitmap = new Bitmap(BufferWidth, BufferHeight,
                                     System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int[] r = new int[BufferWidth * BufferHeight];
            Band band1 = ds.GetRasterBand(bandList[0]);
            band1.ReadRaster(0, 0, imgWidth, imgHeight, r, BufferWidth, BufferHeight, 0, 0);  //读取图像到内存  

            //为了显示好看，进行最大最小值拉伸显示  
            double[] maxandmin1 = { 0, 0 };
            band1.ComputeRasterMinMax(maxandmin1, 0);

            int[] g = new int[BufferWidth * BufferHeight];
            Band band2 = ds.GetRasterBand(bandList[1]);
            band2.ReadRaster(0, 0, imgWidth, imgHeight, g, BufferWidth, BufferHeight, 0, 0);

            double[] maxandmin2 = { 0, 0 };
            band2.ComputeRasterMinMax(maxandmin2, 0);

            int[] b = new int[BufferWidth * BufferHeight];
            Band band3 = ds.GetRasterBand(bandList[2]);
            band3.ReadRaster(0, 0, imgWidth, imgHeight, b, BufferWidth, BufferHeight, 0, 0);

            double[] maxandmin3 = { 0, 0 };
            band3.ComputeRasterMinMax(maxandmin3, 0);

            int i, j;
            for (i = 0; i < BufferWidth; i++)
            {
                for (j = 0; j < BufferHeight; j++)
                {
                    int rVal = Convert.ToInt32(r[i + j * BufferWidth]);
                    rVal = (int)((rVal - maxandmin1[0]) / (maxandmin1[1] - maxandmin1[0]) * 255);

                    int gVal = Convert.ToInt32(g[i + j * BufferWidth]);
                    gVal = (int)((gVal - maxandmin2[0]) / (maxandmin2[1] - maxandmin2[0]) * 255);

                    int bVal = Convert.ToInt32(b[i + j * BufferWidth]);
                    bVal = (int)((bVal - maxandmin3[0]) / (maxandmin3[1] - maxandmin3[0]) * 255);

                    Color newColor = Color.FromArgb(rVal, gVal, bVal);
                    bitmap.SetPixel(i, j, newColor);
                }
            }
            return bitmap;

        }
        public Bitmap GetImage(Dataset ds, Rectangle showRect, Band band)
        {
            int imgWidth = ds.RasterXSize;
            int imgHeight = ds.RasterYSize;
            //影像宽高比 
            float ImgRatio = imgWidth / (float)imgHeight;

            //获取显示控件大小  
            int BoxWidth = showRect.Width;
            int BoxHeight = showRect.Height;
            //显示控件宽高比
            float BoxRatio = imgWidth / (float)imgHeight;

            //计算实际显示区域大小，防止影像畸变显示  
            int BufferWidth, BufferHeight;
            if (BoxRatio >= ImgRatio)
            {
                BufferHeight = BoxHeight;
                BufferWidth = (int)(BoxHeight * ImgRatio);
            }
            else
            {
                BufferWidth = BoxWidth;
                BufferHeight = (int)(BoxWidth / ImgRatio);
            }

            //构建位图  
            Bitmap bitmap = new Bitmap(BufferWidth, BufferHeight,
                                     System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int[] r = new int[BufferWidth * BufferHeight];
            band.ReadRaster(0, 0, imgWidth, imgHeight, r, BufferWidth, BufferHeight, 0, 0);  //读取图像到内存  

            //为了显示好看，进行最大最小值拉伸显示  
            double[] maxandmin1 = { 0, 0 };
            band.ComputeRasterMinMax(maxandmin1, 0);
            int i, j;
            for (i = 0; i < BufferWidth; i++)
            {
                for (j = 0; j < BufferHeight; j++)
                {
                    int rVal = Convert.ToInt32(r[i + j * BufferWidth]);
                    rVal = (int)((rVal - maxandmin1[0]) / (maxandmin1[1] - maxandmin1[0]) * 255);
                    Color newColor = Color.FromArgb(rVal, rVal, rVal);
                    bitmap.SetPixel(i, j, newColor);
                }
            }
            return bitmap;

        }

        public int[] GetHistograph(int[] arr)
        {
            int[] histo = new int[4096];
            for (int i = 0; i < arr.Length; i++)
            {
                histo[arr[i]]++;
            }
            return histo;
        }
        public int[] HistoMatch(int[] pan, int[] res)
        {
            int[] _pan = GetHistograph(pan);
            int[] _res = GetHistograph(res);

            double[] pan_dn = new double[4096];
            double[] res_dn = new double[4096];
            for (int i = 0; i < 4096; i++)
            {
                pan_dn[i] = ((_pan[i] * 1.0) / pan.Length);
                res_dn[i] = ((_res[i] * 1.0) / res.Length);
            }
            for (int i = 1; i < 4096; i++)
            {
                pan_dn[i] = pan_dn[i] + pan_dn[i - 1];
                res_dn[i] = res_dn[i] + res_dn[i - 1];
            }
            double diffAR = 0.0, diffBR = 0.0;
            byte kR = 0;
            byte[] mapPixelR = new byte[4096];
            for (int i = 0; i < 4096; i++)
            {
                diffBR = 1;
                for (int j = kR; j < 4096; j++)
                {
                    diffAR = Math.Abs(pan_dn[i] - res_dn[j]);
                    if (diffAR - diffBR < 1.0E-08)
                    {
                        diffBR = diffAR;
                        kR = (byte)j;
                    }
                    else
                    {
                        kR = (byte)Math.Abs(j - 1);
                        break;
                    }
                }
                if (kR == buckets - 1)
                {
                    for (int l = i; l < 4096; l++)
                    {
                        mapPixelR[l] = kR;
                    }
                    break;
                }
                mapPixelR[i] = kR;
            }

            int[] fin = new int[res.Length];

            for (int i = 0; i < res.Length; i++)
            {
                fin[i] = mapPixelR[pan[i]];
            }
            return fin;
        }
        public SaveType GetSaveType(string filePath)
        {
            SaveType type = SaveType.Img;
            string exName = System.IO.Path.GetExtension(filePath).ToLower();
            if (exName.Equals(".jpg") || exName.Equals(".jpeg"))
            {
                type = SaveType.JPG;
            }
            if (exName.Equals(".bmp"))
            {
                type = SaveType.Bmp;
            }
            if (exName.Equals(".gif"))
            {
                type = SaveType.GIF;
            }
            if (exName.Equals(".png"))
            {
                type = SaveType.PNG;
            }
            if (exName.Equals(".img"))
            {
                type = SaveType.Img;
            }
            if (exName.Equals(".tif") || exName.Equals(".tiff"))
            {
                type = SaveType.Tiff;
            }
            return type;
        }

        /// <summary>
        /// 判断颜色是否超过24位
        /// </summary>
        /// <param name="r">红色波段</param>
        /// <param name="g">绿色波段</param>
        /// <param name="b">蓝色波段</param>
        /// <returns></returns>
        public bool IsTypeWrong(int[] r, int[] g, int[] b)
        {
            if (GetMaxMin(r)[0] > 255) return true;
            if (GetMaxMin(g)[0] > 255) return true;
            if (GetMaxMin(b)[0] > 255) return true;
            return false;
        }

        /// <summary>
        /// 归一化为24位颜色
        /// </summary>
        /// <param name="arr"></param>
        public void Normalize(int[] arr)
        {
            int max = GetMaxMin(arr)[0];
            int min = GetMaxMin(arr)[1];

            for (int i = 0; i < arr.Length; i++)
            {
                {
                    arr[i] = (int)((arr[i] * 1.0 - min) / (max - min) * 255.0);
                }
            }
        }

        /// <summary>
        /// 找出数组中的最大值与最小值
        /// </summary>
        /// <param name="arr">输入数组</param>
        /// <returns>[0]为最大值，[1]为最小值</returns>
        public int[] GetMaxMin(int[] arr)
        {
            int max = 0, min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0) continue;
                if (max < arr[i]) max = arr[i];
                if (min > arr[i]) min = arr[i];
            }
            return new int[] { max, min };
        }


        public void SaveF(Dataset src, string filePath, List<int[]> band, int xSize, int ySize)
        {
            SaveType saveType = fd.GetSaveType(filePath);
            Driver driver = null;
            bool ifCreate = true;

            switch (saveType)
            {
                case SaveType.Img:
                    ifCreate = true;
                    driver = Gdal.GetDriverByName("HFA");
                    break;
                case SaveType.Tiff:
                    ifCreate = true;
                    driver = Gdal.GetDriverByName("GTiff");
                    break;
                case SaveType.Bmp:
                    ifCreate = true;
                    driver = Gdal.GetDriverByName("BMP");
                    break;
                case SaveType.PNG:
                    ifCreate = true;
                    driver = Gdal.GetDriverByName("PNG");
                    break;
                case SaveType.JPG:
                    ifCreate = false;
                    break;
                case SaveType.GIF:
                    ifCreate = false;
                    break;
                default: break;
            }

            if (ifCreate == true)
            {
                Dataset output = null;
                if (band.Count > src.RasterCount)
                {
                    output = driver.Create(filePath, xSize, ySize, band.Count, src.GetRasterBand(1).DataType, null);
                    double[] trans = new double[6];
                    src.GetGeoTransform(trans);
                    output.SetGeoTransform(trans);
                    output.SetProjection(src.GetProjection());
                }
                else
                {
                    output = driver.CreateCopy(filePath, src, 0, null, null, null);
                }
                for (int i = 1; i <= band.Count; i++)
                {
                    output.GetRasterBand(i).WriteRaster(0, 0, xSize, ySize, band[i - 1], xSize, ySize, 0, 0);
                }
                output.Dispose();
                driver.Dispose();
                driver = null;
            }
            else
            {
                // 图像RGB值
                int[] red = new int[xSize * ySize];
                int[] green = new int[xSize * ySize];
                int[] blue = new int[xSize * ySize];

                // 波段数目不同，表现形式不同
                if (band.Count == 1)
                {
                    red = band[0];
                    green = band[0];
                    blue = band[0];
                }
                else if (band.Count == 2)
                {
                    red = band[0];
                    green = band[0];
                    blue = band[1];
                }
                else
                {
                    red = band[0];
                    green = band[1];
                    blue = band[2];
                }

                Bitmap bitmap = new Bitmap(xSize, ySize);
                Color color = new Color();

                if (fd.IsTypeWrong(red, green, blue))
                {
                    fd.Normalize(red);
                    fd.Normalize(green);
                    fd.Normalize(blue);
                }

                for (int i = 0; i < xSize; i++)
                {
                    for (int j = 0; j < ySize; j++)
                    {

                        int ind = i + j * xSize;
                        try
                        {
                            color = Color.FromArgb(red[ind], green[ind], blue[ind]);
                        }
                        catch
                        {
                            color = Color.FromArgb(0, 0, 0);
                        }
                        bitmap.SetPixel(i, j, color);
                    }
                }

                switch (saveType)
                {
                    case SaveType.JPG:
                        bitmap.Save(filePath, ImageFormat.Jpeg);
                        break;
                    case SaveType.GIF:
                        bitmap.Save(filePath, ImageFormat.Gif);
                        break;
                    default: break;
                }
            }
        }

        public double[] GeoTransform(double B, double L)
        {
            double[] XY = new double[2];
            //先转为弧度制
            B = B * Math.PI / 180;
            L = L * Math.PI / 180;
            double cos2_B = Math.Cos(B) * Math.Cos(B);
            double L0 = 33.0 * Math.PI / 180; //中央子午线经度

            //克拉索夫斯基椭球
            double l = L - L0;
            double N = 6399698.902 - (21562.267 - (108.973 - 0.612 * cos2_B) * cos2_B) * cos2_B;
            double a0 = 32140.404 - (135.3302 - (0.7092 - 0.004 * cos2_B) * cos2_B) * cos2_B;
            double a4 = (0.25 + 0.00252 * cos2_B) * cos2_B - 0.04166;
            double a6 = (0.166 * cos2_B - 0.084) * cos2_B;
            double a3 = (0.3333333 + 0.001123 * cos2_B) * cos2_B - 0.1666667;
            double a5 = 0.0083 - (0.1667 - (0.1968 + 0.004 * cos2_B) * cos2_B) * cos2_B;

            XY[0] = 6367558.4969 * B - (a0 - (0.5 + (a4 + a6 * l * l) * l * l) * l * N)
                * Math.Sin(B) * Math.Cos(B);
            XY[1] = (1 + (a3 + a5 * l * l) * l * l) * l * N * Math.Cos(B);

            return XY;

        }

    }
}

