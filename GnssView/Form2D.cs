using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DevExpress.XtraEditors;

namespace GnssView
{
    public partial class Form2D : Form
    {
        public Form2D(FormHome home)
        {
            InitializeComponent();
            homeTmp = home;
        }

        private FormHome homeTmp;
        readonly float emSize = 10f;
        PointF axisMargin = new PointF(30f, 20f);
        PointF axisO = new PointF(100f, 100f);
        float radius = 200f;
        float radiusM = 10f;
        readonly float R1 = 6378004f;//%地球极半径
        readonly float R2 = 6356755f;//%地球赤道半径
        SizeF axisArea = new SizeF(100f,100f);

        double r0Lat = 3957.26395668;
        double r0Lon = 11622.59042752;


        public void DrawAddPoint(Graphics g)
        {
            float pointRadius = 2f;
            int dataCount;

            if (homeTmp.bRefreshFlag)
                dataCount = homeTmp.posInfos.Count;/*实时数据使用当前最新数量*/
            else
                dataCount = homeTmp.nmeaLoadSecond;/*加载数据使用当前位置*/

            if ((dataCount < 1) || (dataCount > homeTmp.posInfos.Count)) return;

            try
            {
                if (radioBtnCurrent.Checked)
                {
                    r0Lat = (Int32)(homeTmp.posInfos[dataCount - 1].lat / 100) + ((homeTmp.posInfos[dataCount - 1].lat % 100) / 60f);
                    r0Lon = (Int32)(homeTmp.posInfos[dataCount - 1].lon / 100) + ((homeTmp.posInfos[dataCount - 1].lon % 100) / 60f);
                }
                else if (radioBtnFirst.Checked)
                {
                    r0Lat = (Int32)(homeTmp.posInfos[0].lat / 100) + ((homeTmp.posInfos[0].lat % 100) / 60f);
                    r0Lon = (Int32)(homeTmp.posInfos[0].lon / 100) + ((homeTmp.posInfos[0].lon % 100) / 60f);
                }

                for (int i = 0; i < dataCount; i++)
                {
                    double lat1 = (Int32)(homeTmp.posInfos[i].lat / 100) + ((homeTmp.posInfos[i].lat % 100) / 60f);
                    double lon1 = (Int32)(homeTmp.posInfos[i].lon / 100) + ((homeTmp.posInfos[i].lon % 100) / 60f);

                    float x = (float)((lon1 - r0Lon) * 2.0 * Math.PI * R1 * Math.Cos(r0Lat * Math.PI / 180.0) / 360.0);
                    float y = (float)((lat1 - r0Lat) * (2.0 * Math.PI * R2 + 4.0 * (R1 - R2)) / 360.0);//R1=6378004;%地球极半径. R2=6356755;%地球赤道半径
                    //float shuiping = (float)Math.Sqrt(x * x + y * y);

                    float addx = axisO.X + x / radiusM * radius;/*坐标*/
                    float addy = axisO.Y + y / radiusM * radius;
                    if ((addx < axisMargin.X) || (addx > (axisO.X + axisArea.Width / 2)) || (addy > (axisO.Y + axisArea.Height / 2)) || (addy < axisMargin.Y)) continue;

                    if (i == dataCount - 1)
                        g.FillEllipse(Brushes.Blue, new RectangleF(addx - pointRadius, addy - pointRadius, pointRadius * 2, pointRadius * 2));
                    else
                        g.FillEllipse(Brushes.Green, new RectangleF(addx - pointRadius, addy - pointRadius, pointRadius * 2, pointRadius * 2));
                }
            }
            catch { }
        }

        //double  lon0,lat0;
        //double  lon1,lat1;
        //wei=(lat1-lat0)*(2*pi*R2+4*(R1-R2))/360;//R1=6378004;%地球极半径. R2=6356755;%地球赤道半径
        //jing=(lon1-lon0)*2*pi*R1*cos(lat0*pi/180)/360; 
        //shuiping=sqrt(wei^2+jing^2); double  lon0,lat0;

        public void DrawAxis(Graphics g, SplitGroupPanel panel)
        {
            axisArea.Width = panel.Size.Width - 2 * axisMargin.X;
            axisArea.Height = panel.Size.Height - 2 * axisMargin.Y;

            axisO.X = panel.Size.Width / 2f;
            axisO.Y = panel.Size.Height / 2f;

            radius = (axisArea.Width > axisArea.Height) ? (axisArea.Height / 4f) : (axisArea.Width / 4f);

            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6, true);
            Pen pen = new Pen(Color.DimGray, 0.5f)
            {
                CustomEndCap = lineCap
            };
            g.DrawLine(pen, new PointF(axisMargin.X, axisO.Y), new PointF(axisMargin.X + axisArea.Width, axisO.Y));
            g.DrawLine(pen, new PointF(axisO.X, axisMargin.Y + axisArea.Height), new PointF(axisO.X, axisMargin.Y));

            //pen.DashStyle = DashStyle.Custom;
            //pen.DashPattern = new float[] { 1f, 3f };
            pen.DashStyle = DashStyle.Solid;
            pen.Color = Color.LightGray;
            pen.Width = 0.1f;
            g.DrawEllipse(pen, new RectangleF(axisO.X - radius, axisO.Y - radius, radius * 2, radius * 2));

            g.DrawString("N", new Font("宋体", emSize), new SolidBrush(Color.Black), axisO.X + 5, axisMargin.Y + 5);
            //g.DrawString("O", new Font("宋体", emSize), new SolidBrush(Color.Black), axisO.X, axisO.Y);
            g.DrawString(radiusM.ToString("f1") + "m", new Font("宋体", emSize), new SolidBrush(Color.Black), axisO.X + radius + 5, axisO.Y);
            g.DrawString("E", new Font("宋体", emSize), new SolidBrush(Color.Black), axisArea.Width + axisMargin.X, axisO.Y);

            DrawAddPoint(g);
        }

        private void splitContainerControl2D_Panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawAxis(e.Graphics, splitContainerControl2D.Panel1);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (radiusM <= 1f) radiusM -= e.Delta / 120f / 10f;
                else if (radiusM > 1f) radiusM -= e.Delta / 120f;
                if (radiusM < 0.1) radiusM = 0.1f;
            }
            else if (e.Delta < 0)
            {
                if (radiusM < 1f) radiusM -= e.Delta / 120f / 10f;
                else if (radiusM >= 1f) radiusM -= e.Delta / 120f;
                if (radiusM < 0.1) radiusM = 0.1f;
            }
            refresh2D();
        }

        public void refresh2D()
        {
            splitContainerControl2D.Panel1.Refresh();
        }

        public void clear2D()
        {
            homeTmp.posInfos.Clear();
            splitContainerControl2D.Panel1.Refresh();
        }

        private void Form2D_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void radioBtnTrue_CheckedChanged(object sender, EventArgs e)
        {
            labelLat.Visible = true;
            textBoxLat.Visible = true;
            labelLon.Visible = true;
            textBoxLon.Visible = true;
            btnApply.Visible = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxLat.Text, out double dTmpA) && double.TryParse(textBoxLon.Text, out double dTmpB))
            {
                r0Lat = (Int32)(dTmpA / 100) + ((dTmpA % 100) / 60f);
                r0Lon = (Int32)(dTmpB / 100) + ((dTmpB % 100) / 60f);
            }
        }

        //private const double WGS_E1_SQRT = 0.00669437999014;		// first  numerical eccentricity
        //private const double WGS_MAJOR = 6378137.0;			//a - WGS-84 earth's semi major axis
        //void llaToEcef(double lat, double lon, double alt, ref double e, ref double n, ref double u)
        //{
        //    double N = 0.0;
        //    double sinLat, cosLat, sinLon = 0.0, cosLon = 0.0;
        //    double x, y, z;

        //    sinLat = Math.Sin(lat);
        //    cosLat = Math.Cos(lat);
        //    sinLon = Math.Sin(lon);
        //    cosLon = Math.Cos(lon);

        //    N = WGS_MAJOR / Math.Sqrt(1.0 - WGS_E1_SQRT * sinLat * sinLat);

        //    x = (N + alt) * cosLat * Math.Cos(lon);
        //    y = (N + alt) * cosLat * Math.Sin(lon);
        //    z = (N * (1.0 - WGS_E1_SQRT) + alt) * sinLat;

        //    /*enu坐标等于转化矩阵乘以xyz*/
        //    e = (-sinLon) * x + cosLon * y;
        //    n = (-sinLat) * cosLon * x - sinLat * sinLon * y + cosLat * z;
        //    u = cosLat * cosLon * x + sinLon * cosLat * y + sinLat * z;

        //}

        //private const double EARTH_RADIUS = 6378137;
        //private static double Rad(double d)
        //{
        //    return (double)d * Math.PI / 180d;
        //}
        //public static double getDistance(double lat1, double lng1, double lat2, double lng2)
        //{
        //    double radLat1 = Rad(lat1);
        //    double radLng1 = Rad(lng1);
        //    double radLat2 = Rad(lat2);
        //    double radLng2 = Rad(lng2);
        //    double a = radLat1 - radLat2;
        //    double b = radLng1 - radLng2;
        //    double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
        //    return result;
        //}

    }
}