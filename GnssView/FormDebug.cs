using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace GnssView
{
    public partial class FormDebug : Form
    {
        public FormDebug(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;
        }

        private FormHome homeTmp;

        private void FormDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void FormDebug_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer2D_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
