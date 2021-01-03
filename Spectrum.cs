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
    public partial class Spectrum : Form
    {
        public Spectrum()
        {
            InitializeComponent();
        }
        public Spectrum(string filepath,int X,int Y,PictureBox pictureBox)
        {
            InitializeComponent();
            filepath1.Text = filepath;
            Gdal.AllRegister();
            Dataset ds = Gdal.Open(filepath, Access.GA_ReadOnly);
            imgX.Text  = X.ToString();
            imgY.Text = Y.ToString();
            int[] r, g, b;
            int xSize = ds.RasterXSize;
            int ySize = ds.RasterYSize;

            double[] tran = new double[6];
            ds.GetGeoTransform(tran);
            float pre_x = X * 1.0f /pictureBox.Width * xSize;
            float pre_y = Y * 1.0f / pictureBox.Height * ySize;

            // 坐标转换
            double x = tran[0] + pre_x * tran[1] + pre_y * tran[2];
            double y = tran[3] + pre_x * tran[4] + pre_y * tran[5];
            trueX.Text = x.ToString();
            trueY.Text = y.ToString();
            if (ds.RasterCount == 1)
            {
                r = new int[xSize * ySize];
                ds.GetRasterBand(1).ReadRaster(0, 0, xSize, ySize, r, xSize, ySize, 0, 0);
                G.Visible = false;
                B.Visible = false;
                R.Text = "R：" + r[(int)(pre_x + pre_y * xSize)].ToString();
            }
            else if (ds.RasterCount == 2)
            {
                r = new int[xSize * ySize];
                g = new int[xSize * ySize];
                ds.GetRasterBand(1).ReadRaster(0, 0, xSize, ySize, r, xSize, ySize, 0, 0);
                ds.GetRasterBand(2).ReadRaster(0, 0, xSize, ySize, g, xSize, ySize, 0, 0);
                G.Visible = true;
                B.Visible = false;
                R.Text = "R：" + r[(int)(pre_x + pre_y * xSize)].ToString();
                G.Text = "G：" + g[(int)(pre_x + pre_y * xSize)].ToString();
            }
            else
            {
                r = new int[xSize * ySize];
                g = new int[xSize * ySize];
                b = new int[xSize * ySize];
                ds.GetRasterBand(1).ReadRaster(0, 0, xSize, ySize, r, xSize, ySize, 0, 0);
                ds.GetRasterBand(2).ReadRaster(0, 0, xSize, ySize, g, xSize, ySize, 0, 0);
                ds.GetRasterBand(3).ReadRaster(0, 0, xSize, ySize, b, xSize, ySize, 0, 0);
                G.Visible = true;
                B.Visible = true;
                R.Text = "R：" + r[(int)(pre_x + pre_y * xSize)].ToString();
                G.Text = "G：" + g[(int)(pre_x + pre_y * xSize)].ToString();
                B.Text = "B：" + b[(int)(pre_x + pre_y * xSize)].ToString();
            }
        }
    }
}
