using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GnssView.replay
{
    public partial class FormReplay : Form
    {
        public FormReplay(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;
        }

        FormHome homeTmp;

        bool status = false;
        private void btnStatusCtrl_Click(object sender, EventArgs e)
        {
            btnStatusCtrl.Image = status ? Properties.Resources.开始 : Properties.Resources.暂停;
            status = !status;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            int value = homeTmp.trackValueCtrl;
            try
            {
                homeTmp.trackValueCtrl = value + 100;
            }
            catch
            { }
            
        }
    }
}
