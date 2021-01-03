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
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 变量
        double[] GeoTransform1 = new double[6];
        double[] GeoTransform2 = new double[6];
        List<double[,]> List1;
        List<double[,]> List2;
        int NOP = 0;
        resFoudation res = new resFoudation();
        #endregion

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开待配准影像
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Filter = "所有文件|*.*";
            op1.Title = "打开待配准影像";
            string op1name = op1.FileName;
            if (op1.ShowDialog() == DialogResult.OK)
            {
                //初始化设置
                OSGeo.GDAL.Gdal.AllRegister(); // 初始化gdal库
                OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");    //设置为UTF-8编码

                //打开影像
                Dataset ds1 = OSGeo.GDAL.Gdal.Open(op1.FileName, OSGeo.GDAL.Access.GA_ReadOnly);
                ds1.GetGeoTransform(GeoTransform1);
                Rectangle pictureRect = new Rectangle();
                pictureRect.X = 0;
                pictureRect.Y = 0;
                pictureRect.Width = this.pictureBox1.Width;
                pictureRect.Height = this.pictureBox1.Height;

                int[] disband = new int[3] { 1, 2, 3 };
                Band band=ds1.GetRasterBand(1);
                Foudation fd = new Foudation();
                Bitmap bitmap1 = fd.GetImage(ds1, pictureRect,band ) ;   //遥感影像构建位图
                pictureBox1.Image = bitmap1;
            }
            #endregion

            #region 打开标准影像
            OpenFileDialog op2 = new OpenFileDialog();
            op2.Filter = "所有文件|*.*";
            op2.Title = "打开标准影像";
            string op2name = op2.FileName;
            if (op2.ShowDialog() == DialogResult.OK)
            {
                //初始化设置
                OSGeo.GDAL.Gdal.AllRegister(); // 初始化gdal库
                OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");    //设置为UTF-8编码

                //打开影像
                Dataset ds2 = OSGeo.GDAL.Gdal.Open(op2.FileName, OSGeo.GDAL.Access.GA_ReadOnly);
                ds2.GetGeoTransform(GeoTransform2);
                Rectangle pictureRect = new Rectangle();
                pictureRect.X = 0;
                pictureRect.Y = 0;
                pictureRect.Width = this.pictureBox2.Width;
                pictureRect.Height = this.pictureBox2.Height;

                int[] disband = new int[3] { 1, 2, 3 };
                Foudation fd = new Foudation();
                Bitmap bitmap2 = fd.GetImage(ds2, pictureRect, 3, disband); ;   //遥感影像构建位图
                pictureBox2.Image = bitmap2;
            }
            #endregion
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (NOP > 4 || NOP == 0)
            {
                return;
            }
            double[,] XY = new double[1, 2];
            XY[0, 0] = GeoTransform1[0] + (e.Location.X / 1.0) * GeoTransform1[1] + (e.Location.Y / 1.0) * GeoTransform1[2];
            XY[0, 1] = GeoTransform1[3] + (e.Location.X / 1.0) * GeoTransform1[4] + (e.Location.Y / 1.0) * GeoTransform1[5];
            List1.Add(XY);
            if (List1.Count == List2.Count)
            {
                NOP++;
            }
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red, 1);
            g.DrawLine(pen, e.Location.X - 3, e.Location.Y, e.Location.X + 3, e.Location.Y);
            g.DrawLine(pen, e.Location.X, e.Location.Y - 3, e.Location.X, e.Location.Y + 3);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (NOP > 4 || NOP == 0)
            {
                return;
            }
            double[,] XY = new double[1, 2];
            XY[0, 0] = GeoTransform2[0] + (e.Location.X / 1.0) * GeoTransform2[1] + (e.Location.Y / 1.0) * GeoTransform2[2];
            XY[0, 1] = GeoTransform2[3] + (e.Location.X / 1.0) * GeoTransform2[4] + (e.Location.Y / 1.0) * GeoTransform2[5];
            List2.Add(XY);
            if (List2.Count == List1.Count)
            {
                NOP++;
            }
            if (NOP > 4)
            {
                MessageBox.Show("已经超过四个了，请计算系数！");
            }
            Graphics g = pictureBox2.CreateGraphics();
            Pen pen = new Pen(Color.Red, 1);
            g.DrawLine(pen, e.Location.X - 3, e.Location.Y, e.Location.X + 3, e.Location.Y);
            g.DrawLine(pen, e.Location.X, e.Location.Y - 3, e.Location.X, e.Location.Y + 3);
        }
        private void 同名点采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List1 = new List<double[,]>();
            List2 = new List<double[,]>();
            NOP = 1;
        }
        private void 系数计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            res.Coefficient(List1, List2);
            MessageBox.Show("计算成功！", "Result");
        }
        private void 进行配准ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            res.ImageRegistration((Bitmap)pictureBox1.Image);
        }


    }
}
