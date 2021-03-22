using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GnssView
{
    public partial class FormContent : Form
    {
        public FormContent()
        {
            InitializeComponent();
        }

        public void history()
        {
            string filePath = Application.StartupPath + "\\history.txt";
            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.GetEncoding("gb2312")))
            {
                while (sr.Peek() >= 0)
                {
                    textBoxContent.Text += sr.ReadLine() + "\r\n";
                }
            }
            textBoxContent.SelectionStart = textBoxContent.SelectionLength;
        }
    }
}
