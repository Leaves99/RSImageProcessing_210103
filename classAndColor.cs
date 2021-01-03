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
    public partial class classAndColor : Form
    {
        public classAndColor()
        {
            InitializeComponent();
        }

        static string colorS;
        static string cname;
        static string[] n1;
        public string[] caco
        {
            get { return n1; }
            set { n1 = value; }
        }
        private void addColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            Color classC;
            classC = color.Color;
            colorS = classC.ToArgb().ToString();
        }

        private void oK_Click(object sender, EventArgs e)
        {
            if (className.Text != ""&&className.Text!=null)
            {
                cname = className.Text;
                string[] s=AddColorandname(cname,colorS);
                n1 = s;
            }
            this.Close();
        }
        public string[] AddColorandname(string name1,string color1)
        {
            string[] n = new string[2];
            n[0] = name1;
            n[1] = color1;
            return n;
        }
    }
}
