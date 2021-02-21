using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GnssView
{
    public partial class FormAcc : Form
    {
        public FormAcc(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;

            homeTmp.navGgaMsg.ggaCount = 0;/*清除*/

            textBoxLat.Text = "3957.2638";
            textBoxLon.Text = "11622.5904";
            textBoxAlt.Text = "61.8759";

            axisLat = new DrawingCurve();
        }

        public DrawingCurve axisLat;
        private List<float> fltsKeys = new List<float>();//键
        private List<float> fltsValues = new List<float>();//值
        private bool bPicShowing = false;
        public FormHome homeTmp;

        private void pictureBoxXy_Paint(object sender, PaintEventArgs e)
        {
            bPicShowing = true;
            e.Graphics.DrawImage(axisLat.DrawImage(this.pictureBoxXy.Size, fltsKeys, fltsValues), new Point(0, 0));
            bPicShowing = false;

        }

        private void pictureBoxXy_Resize(object sender, EventArgs e)
        {
            this.pictureBoxXy.Refresh();
        }

        public void refreshAxis(int Keys, double Values)
        {
            fltsKeys.Add(Keys);
            fltsValues.Add((float)Values);

            this.pictureBoxXy.Refresh();
        }

        public void clearGnss()
        {
            while (bPicShowing) ;//执行之后再清除buf

            fltsKeys.Clear();
            fltsValues.Clear();

            this.pictureBoxXy.Refresh();
        }

        private void FormGnss_FormClosing(object sender, FormClosingEventArgs e)
        {
            while (bPicShowing) ;

            this.Dispose();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            double N;
            double sinLat, cosLat, sinLon, cosLon;
            double latFloor, lonFloor;

            if (double.TryParse(textBoxLat.Text, out double lat) && double.TryParse(textBoxLon.Text, out double lon) && double.TryParse(textBoxAlt.Text, out double alt))
            {

                lat /= 100.0;
                lon /= 100.0;

                latFloor = Math.Floor(lat);
                lonFloor = Math.Floor(lon);

                lat = latFloor + ((lat - latFloor) * 100.0 / 60.0);
                lon = lonFloor + ((lon - lonFloor) * 100.0 / 60.0);

                lat = lat * 3.1415926535898 / 180.0;
                lon = lon * 3.1415926535898 / 180.0;

                sinLat = Math.Sin(lat);
                cosLat = Math.Cos(lat);
                sinLon = Math.Sin(lon);
                cosLon = Math.Cos(lon);

                N = 6378137.0 / Math.Sqrt(1.0 - 0.00669437999014 * sinLat * sinLat);

                homeTmp.formCn0.trueValue[0] = (N + alt) * cosLat * cosLon;
                homeTmp.formCn0.trueValue[1] = (N + alt) * cosLat * sinLon;
                homeTmp.formCn0.trueValue[2] = (N * (1.0 - 0.00669437999014) + alt) * sinLat;

                clearGnss();
            }
        }
    }
}
