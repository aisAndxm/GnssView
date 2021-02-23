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
            try
            {
                if (!int.TryParse(textBoxSkipUtc.Text, out int value)) return;
                for (int i = 0; i < homeTmp.loadDataUtc.Count(); i++)
                {
                    if (homeTmp.loadDataUtc[i] == value)
                    {
                        homeTmp.trackValueCtrl = i;
                        break;
                    }
                }
            }
            catch
            { }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
