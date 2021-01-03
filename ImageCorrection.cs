using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImageProgressing
{
    public partial class ImageCorrection : Form
    {
        public ImageCorrection()
        {
            double B = 105.1846987, L = 30.6211769, H = 824.501;
            double phi = -4, w = -1, k = 358.5;
            double width = 36, height = 24, f = 24, size = 0.1;
            InitializeComponent();
            b1.Text = B.ToString();
            l1.Text = L.ToString();
            h1.Text = H.ToString();
            phi1.Text = phi.ToString();
            w1.Text = w.ToString();
            k1.Text = k.ToString();
            height1.Text = height.ToString();
            width1.Text = width.ToString();
            f1.Text = f.ToString();
            size1.Text = size.ToString();
        }

        double[] canS = new double[11];

        public double[] returnCan()
        {
            return canS;
        }

        private void run_Click(object sender, EventArgs e)
        {
            canS[0] = 0;
            if (canS != null)
            {
                canS[0] = 1;
                canS[1] = Convert.ToDouble(b1.Text);
                canS[2] = Convert.ToDouble(l1.Text);
                canS[3] = Convert.ToDouble(h1.Text);
                canS[4] = Convert.ToDouble(phi1.Text);
                canS[5] = Convert.ToDouble(w1.Text);
                canS[6] = Convert.ToDouble(k1.Text);
                canS[7] = Convert.ToDouble(height1.Text);
                canS[8] = Convert.ToDouble(width1.Text);
                canS[9] = Convert.ToDouble(f1.Text);
                canS[10] = Convert.ToDouble(size1.Text);
                returnCan();
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入完整参数！");
                this.Close();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
