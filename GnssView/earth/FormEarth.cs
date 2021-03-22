using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GnssView
{
    public partial class FormEarth : Form
    {
        public FormEarth(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;
        }

        FormHome homeTmp;

        private void FormEarth_Load(object sender, EventArgs e)
        {
            //html文件Copy到程序根目录
            this.webBrowserBaidu.Navigate(AppDomain.CurrentDomain.BaseDirectory + "earth/BaiDuEarth.html", false);
        }
    }
}
