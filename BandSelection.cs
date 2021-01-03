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
    public partial class BandSelection : Form
    {
        public BandSelection()
        {
            InitializeComponent(); 
            band1Com.SelectedIndex = 2;//设置显示的item索引
            band2Com.SelectedIndex = 1;
            band3Com.SelectedIndex = 0;
        }
        //public static int[] bandList=new int[3];
        private int _band1;
        private int _band2;
        private int _band3;

        public int Band1
        {
            get { return _band1; }
            set { _band1 = value; } 
        }
        public int Band2
        {
            get { return _band2; }
            set { _band2 = value; }
        }
        public int Band3
        {
            get { return _band3; }
            set { _band3 = value; }
        }

        private void three21Button_Click(object sender, EventArgs e)
        {
            this.Band1 = 3;
            this.Band2 = 2;
            this.Band3 = 1;
            this.Dispose(); 
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            this.Band1 = int.Parse(band1Com.SelectedItem.ToString());
            this.Band2 = int.Parse(band2Com.SelectedItem.ToString());
            this.Band3 = int.Parse(band3Com.SelectedItem.ToString());
            this.Dispose();
        }
    }
}
