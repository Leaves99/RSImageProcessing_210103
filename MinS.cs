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
    public partial class MinS : Form
    {
        public MinS()
        {
            InitializeComponent();
        }

        #region 变量
        Point Image_Mouse_X_Y;//鼠标处在影像中的行列号
        double Geo_X, Geo_Y;//鼠标处在影像中的地理坐标
        Point mouse_inBox_X_Y;//鼠标在控件坐标
        public Color penColor = Color.Red;
        Pen pen = new Pen(Color.Red, 3);
        Point Jstar, Jend;
        Point start; //画框的起始点
        bool blnDraw;//在MouseMove事件中判断是否绘制矩形框
        int[] rgb = { 3, 2, 1 };
        int[,] K_cen;
        Color[] K_color;
        int DWidth, DHeight;
        int DSize;
        string filename_out;
        int k = -1;
        int K_t = 0;
        #endregion

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 执行分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename_out == null)
                return;
            int[,] center_color = new int[K_t, 3];
            //minS0(Rd.FileName, filename_out, rgb, K_color);
            MessageBox.Show("成功！");
            this.pictureBox1.Image = Image.FromFile(filename_out);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.tif|*.tif|*.img|*.img|*.png|*.png|*.bmp|*.bmp|*.gif|*.gif";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            filename_out = sfd.FileName;
        }

        

        private void MinS_Load(object sender, EventArgs e)
        {
            //pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);//滚轮事件
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "遥感影像|*.tif;*.img;*tiff;|常规图片|*.jpg;*.png;*.bmp";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            string Filename = ofd.FileName;
        }

        private void add_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();

            colorDialog1.AllowFullOpen = true;
            colorDialog1.AnyColor = true;
            colorDialog1.FullOpen = true;
            DialogResult dlg = colorDialog1.ShowDialog();
            if (dlg != DialogResult.OK)
                return;

            string name = textBox1.Text;
            Color cl = colorDialog1.Color;
            k = K_t;
            K_t = K_t + 1;

            penColor = cl;

            if (K_color == null)
            {
                K_color = new Color[K_t];
                K_color[0] = cl;
            }
            else
            {
                int len = K_color.Length;
                Color[] kcolor = new Color[len + 1];
                for (int i = 0; i < len; i++)
                {
                    kcolor[i] = K_color[i];
                }
                kcolor[len] = cl;
                K_color = kcolor;
            }

            if (K_cen == null)
            {
                K_t = 1;
                k = 0;
                K_cen = new int[K_t, DSize + 1];
            }
            else
            {
                int len = K_cen.GetLength(0);

                int[,] kcen = new int[K_t, DSize + 1];
                for (int i = 0; i < K_t - 1; i++)
                {
                    int p = K_cen[i, 0];
                    for (int j = 0; j < p + 1; j++)
                        kcen[i, j] = K_cen[i, j];
                }
                K_cen = kcen;
            }

            comboBox1.Items.Add(name + "  " + K_t.ToString());
            comboBox1.SelectedIndex = k;
            ListViewItem list1 = new ListViewItem();
            list1.Text = K_t.ToString();//
            list1.SubItems.Add(name);//
            list1.SubItems.Add(K_cen[k, 0].ToString());//
            list1.SubItems.Add(cl.R.ToString() + "  " + cl.G.ToString() + "  " + cl.B.ToString());//颜色
            listView1.Items.Add(list1);
        }

        public void minS0(string filename_in, string filename_out, int[] rgb, Color[] K_colors)
        {
            Dataset Ds_in = Gdal.Open(filename_in, Access.GA_ReadOnly);
            int width = Ds_in.RasterXSize;
            int height = Ds_in.RasterYSize;
            int size = width * height;

            double[] R = new double[size];
            double[] G = new double[size];
            double[] B = new double[size];
            Ds_in.GetRasterBand(rgb[0]).ReadRaster(0, 0, width, height, R, width, height, 0, 0);
            Ds_in.GetRasterBand(rgb[1]).ReadRaster(0, 0, width, height, G, width, height, 0, 0);
            Ds_in.GetRasterBand(rgb[2]).ReadRaster(0, 0, width, height, B, width, height, 0, 0);

            int k = K_cen.GetLength(0);
            double[,] center = new double[k, 3];
            for (int i = 0; i < k; i++)
            {
                double rsum = 0, gsum = 0, bsum = 0;
                int t = K_cen[i, 0];
                for (int j = 1; j <= t; j++)
                {
                    int h = K_cen[i, j];
                    rsum = rsum + R[h];
                    gsum = gsum + G[h];
                    bsum = bsum + B[h];
                }
                rsum = rsum / t;
                gsum = gsum / t;
                bsum = bsum / t;
                center[i, 0] = rsum;
                center[i, 1] = gsum;
                center[i, 2] = bsum;
            }

            int len = center.GetLength(0);
            int[] result_q = new int[size];
            for (int i = 0; i < size; i++)
            {
                int p = 0;
                double dis, min;
                dis = (R[i] - center[0, 0]) * (R[i] - center[0, 0]) + (G[i] - center[0, 1]) * (G[i] - center[0, 1]) + (B[i] - center[0, 2]) * (B[i] - center[0, 2]);
                min = dis;

                for (int j = 1; j < len; j++)
                {
                    dis = (R[i] - center[j, 0]) * (R[i] - center[j, 0]) + (G[i] - center[j, 1]) * (G[i] - center[j, 1]) + (B[i] - center[j, 2]) * (B[i] - center[j, 2]);
                    if (dis < min)
                    {
                        min = dis;
                        p = j;
                    }
                }
                result_q[i] = p;
            }


            //输出
            string ext=".bmp"; //= Path.GetExtension(filename_out);
            string Gtype = null;
            if (ext == ".bmp") Gtype = "BMP";
            //else if (ext == ".jpg") Gtype = "JPEG";
            else if (ext == ".img") Gtype = "HFA";
            else if (ext == ".png") Gtype = "PNG";
            else if (ext == ".tif") Gtype = "GTiff";
            else if (ext == ".gif") Gtype = "GIF";
            else return;
            Driver driver = Gdal.GetDriverByName(Gtype);//在GDAL中创建影像,先需要明确待创建影像的格式,并获取到该影像格式的驱动
            Dataset DataOut = driver.Create(filename_out, width, height, 1, DataType.GDT_Byte, null);//设置影像属性
            double[] geotransform = new double[6];
            Ds_in.GetGeoTransform(geotransform);
            DataOut.SetGeoTransform(geotransform); //影像转换参数
            DataOut.SetProjection(Ds_in.GetProjection()); //投影

            DataOut.GetRasterBand(1).WriteRaster(0, 0, width, height, result_q, width, height, 0, 0);
            DataOut.GetRasterBand(1).FlushCache();
            DataOut.FlushCache();


            ColorTable coltable = new ColorTable(PaletteInterp.GPI_RGB);
            ColorEntry colentry = new ColorEntry();

            for (int i = 0; i < len; i++)
            {
                colentry = new ColorEntry();
                colentry.c1 = K_colors[i].R;
                colentry.c2 = K_colors[i].G;
                colentry.c3 = K_colors[i].B;
                colentry.c4 = 0;
                coltable.SetColorEntry(i, colentry);
            }
            int rt = DataOut.GetRasterBand(1).SetColorTable(coltable);
            DataOut.FlushCache();
            DataOut.Dispose();
        }
    }
}
