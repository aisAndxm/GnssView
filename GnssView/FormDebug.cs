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

        //Initialize TextBox1.
        internal System.Windows.Forms.TextBox TextBox1;

        private void InitializeTextBox()
        {
            this.TextBox1 = new TextBox
            {
                Location = new System.Drawing.Point(32, 24),
                Name = "TextBox1",
                Size = new System.Drawing.Size(136, 20),
                TabIndex = 1,
                Text = "Type and hit enter here..."
            };

            //Keep the selection highlighted, even after textbox loses focus.

            //TextBox1.HideSelection = false;
            this.Controls.Add(TextBox1);
        }


        private void FormDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void FormDebug_Load(object sender, EventArgs e)
        {
            InitializeTextBox();
        }

        private void splitContainer2D_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
