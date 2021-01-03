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
    public partial class Histogram : Form
    {
        Dataset _ds;
        int[] _panHistogram = new int[256];//存储直方图的数组
        int _max;

        public Histogram(string filepath)
        {
            InitializeComponent();
            _ds = Gdal.Open(filepath, Access.GA_ReadOnly);
            int length = _ds.RasterCount;
            int[] countPixel = new int[256];
            for (int i = 0; i < length; i++)
            {
                int x = i + 1;
                bandSelect.Items.Add("band" + x);
            }
            bandSelect.SelectedIndex = 0;
        }
        private void bandSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //发生改变后进行重绘
            this.Invalidate();
            Band band = _ds.GetRasterBand(bandSelect.SelectedIndex + 1);
            double dfmin; double dfmax; double pdfMean; double pdfStdDev;
            band.GetStatistics(1, 1, out dfmin, out dfmax, out pdfMean, out pdfStdDev);

            int nBuckets = 256;//表示直方图统计的份数
            int include_out_of_range = 0;//如果这个参数设置为TRUE，那么图像中的像元值小于最小值的像元值将被统计到直方图数组中的第一个里面去，
                                         //图像中的像元值大于最大值的像元会被统计到直方图数组中的最后一个里面去。
                                         //如果设置为FALSE，那么图像中的像元值小于最小值的像元不进行统计，
                                         //像元值超过最大值的像元值也不进行统计。
            int approx_ok = 1;
            Gdal.GDALProgressFuncDelegate callback = null;
            string callback_data = null;
            band.GetHistogram(-0.5, 255.5, nBuckets, _panHistogram, include_out_of_range, approx_ok, callback, callback_data);
            this.richTextBox1.Text = "Band:" + (bandSelect.SelectedIndex + 1).ToString() + "\n" +
                                     "Mean：" + pdfMean.ToString() + "\n" +
                                     "StdDev：" + pdfStdDev.ToString() + "\n" +
                                     "Min:" + dfmin.ToString() + "\n" +
                                    "Max:" + dfmax.ToString();
        }
        /// <summary>
        /// 画出y轴方向的线
        /// </summary>
        /// <param name="pen">画笔</param>
        /// <param name="g">Graphics</param>
        public void GetHistogram(Pen pen, Graphics g)
        {
            _max = _panHistogram.Max();
            g.DrawString(_max.ToString(), new Font("New Timer", 8), Brushes.Black, new PointF(18, 34));

            //绘制直方图
            double temp = 0;

            for (int i = 0; i < 256; i++)
            {
                //纵坐标长度
                temp = 200 * _panHistogram[i] / _max;
                g.DrawLine(pen, 50 + i, 270, 50 + i, 270 - (int)temp);
            }
            pen.Dispose();
            //g.Dispose();
        }
        private void Histogram_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //创建一个宽度为1的黑色钢笔
            Pen curPen = new Pen(Brushes.Black, 1);

            //绘制坐标轴
            g.DrawLine(curPen, 50, 270, 360, 270);//在点(50,270)与(360,270)间画条线，x轴
            g.DrawLine(curPen, 50, 270, 50, 60);//y轴

            //绘制并标识坐标刻度
            g.DrawLine(curPen, 100, 270, 100, 272);//同上，画长度为2的线
            g.DrawLine(curPen, 150, 270, 150, 272);
            g.DrawLine(curPen, 200, 270, 200, 272);
            g.DrawLine(curPen, 250, 270, 250, 272);
            g.DrawLine(curPen, 300, 270, 300, 272);
            g.DrawLine(curPen, 350, 270, 350, 272);

            //在x轴上为刻度标出刻度值
            g.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(46, 272));
            g.DrawString("50", new Font("New Timer", 8), Brushes.Black, new PointF(92, 272));
            g.DrawString("100", new Font("New Timer", 8), Brushes.Black, new PointF(139, 272));
            g.DrawString("150", new Font("New Timer", 8), Brushes.Black, new PointF(189, 272));
            g.DrawString("200", new Font("New Timer", 8), Brushes.Black, new PointF(239, 272));
            g.DrawString("250", new Font("New Timer", 8), Brushes.Black, new PointF(289, 272));
            g.DrawString("300", new Font("New Timer", 8), Brushes.Black, new PointF(339, 272));
            g.DrawString(">", new Font("New Timer", 8), Brushes.Black, new PointF(356, 263));

            this.GetHistogram(curPen, g);
        }
    }
}
