using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSGeo.GDAL;

namespace RSImageProgressing
{
    public partial class IHS变换 : Form
    {
        static Dataset ds1;
        static Dataset ds2;
        static string file1;
        static string file2;
        static string filepath;
        static bool isSave=false;
        Image img1;
        Image img2;
        public IHS变换()
        {
            InitializeComponent();
        }
        public static void IHS(Dataset msi, Dataset pan, string filePath)
        {

            // 全色影像单波段数据
            int xSize = pan.RasterXSize;
            int ySize = pan.RasterYSize;
            int[] pan_r = GetDNs(pan, xSize, ySize)[0];

            // 多光谱影像多波段数据
            List<int[]> msi_all = GetDNs(msi, xSize, ySize);
            int[] msi_r = msi_all[0];
            int[] msi_g = msi_all[1];
            int[] msi_b = msi_all[2];

            // RGB空间变换到IHS空间
            List<double[]> ihs = RecRGBToIHS(new List<int[]>() { msi_r, msi_g, msi_b });

            Foudation fd = new Foudation();
            // 对全色影像和IHS空间中的亮度分量I进行直方图匹配
            int[] matched = fd.HistoMatch(pan_r, ToInt(ihs[0]));

            // 用全色影像I代替IHS空间的亮度分量
            ihs[0] = ToDouble(matched);

            // 将IHS逆变换到RGB空间
            List<int[]> band = RecIHSToRGB(ihs);
            if(isSave==true)
            { 
                fd.SaveF(pan, filePath, band, xSize, ySize); 
            }
        }

        /// <summary>
        /// 获取灰度值
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        /// <returns></returns>
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
        private static List<double[]> RecRGBToIHS(List<int[]> rgb)
        {
            int cou = rgb[0].Count();
            double[] i = new double[cou];
            double[] h = new double[cou];
            double[] s = new double[cou];

            for (int j = 0; j < cou; j++)
            {
                double r = rgb[0][j] * 1.0;
                double g = rgb[1][j] * 1.0;
                double b = rgb[2][j] * 1.0;
                double _i = r + g + b;

                i[j] = _i / 3.0;

                double min = Math.Min(Math.Min(r, g), b) * 1.0;
                if (r == g && g == b)
                {
                    h[j] = 0;
                    s[j] = 0;
                }
                else
                {
                    if (min == b)
                    {
                        h[j] = (g - b) / (_i - 3.0 * b);
                        s[j] = (_i - 3.0 * b) / _i;
                    }
                    else if (min == r)
                    {
                        h[j] = (b - r) / (_i - 3.0 * r) + 1;
                        s[j] = (_i - 3.0 * r) / _i;
                    }
                    else
                    {
                        h[j] = (r - g) / (_i - 3.0 * g) + 2;
                        s[j] = (_i - 3.0 * g) / _i;
                    }
                }
            }


            return new List<double[]>() { i, h, s };
        }
        private static List<int[]> RecIHSToRGB(List<double[]> ihs)
        {
            int cou = ihs[0].Count();
            int[] r = new int[cou];
            int[] g = new int[cou];
            int[] b = new int[cou];

            for (int j = 0; j < cou; j++)
            {
                double i = ihs[0][j] * 1.0;
                double h = ihs[1][j] * 1.0;
                double s = ihs[2][j] * 1.0;

                if (h >= 2.0 && h < 3.0)
                {
                    r[j] = (int)(i * (1.0 - 7 * s - 3 * s * h));
                    g[j] = (int)(i * (1.0 - s));
                    b[j] = (int)(i * (1.0 + 8 * s - 2 * s * h));
                }
                else if (h >= 1.0 && h < 2.0)
                {
                    r[j] = (int)(i * (1.0 - s));
                    g[j] = (int)(i * (1.0 + 5 * s - 3 * s * h));
                    b[j] = (int)(i * (1.0 - 4 * s + 3 * s * h));
                }
                else
                {
                    r[j] = (int)(i * (1.0 + 2 * s - 3 * s * h));
                    g[j] = (int)(i * (1.0 - 1 * s + 3 * s * h));
                    b[j] = (int)(i * (1.0 - s));
                }

                if (r[j] > 255) r[j] = 255;
                if (g[j] > 255) g[j] = 255;
                if (b[j] > 255) b[j] = 255;
                if (r[j] < 0) r[j] = 0;
                if (g[j] < 0) g[j] = 0;
                if (b[j] < 0) b[j] = 0;
            }

            return new List<int[]>() { r, g, b };
        }
        private static int[] ToInt(double[] arr)
        {
            int[] fin = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                fin[i] = (int)arr[i];
            }
            return fin;
        }
        private static double[] ToDouble(int[] arr)
        {
            double[] fin = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                fin[i] = arr[i];
            }
            return fin;
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
        }
        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = 
             "Erdas Imagine (*.img)|*.img|" +
            "GeoTiff (*.tif *.tiff)|*.tif;*.tiff|" +
            "NITF (*.ntf *.nsf)|*.ntf;*.nsf|" +
            "位图文件 (*.bmp)|*.bmp|" +
            "Graphics Interchange Format (*.gif)|*.gif|" +
            "JPEG (*.jpg *.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphics (*.png)|*.png";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                filepath = saveDlg.FileName;
                isSave = true;
            }
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            IHS(ds1, ds2, filepath);
        }
    }
}
