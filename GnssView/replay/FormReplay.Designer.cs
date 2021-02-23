
namespace GnssView.replay
{
    partial class FormReplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReplay));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnStatusCtrl = new System.Windows.Forms.Button();
            this.textBoxSkipUtc = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSkip);
            this.panel1.Controls.Add(this.btnStatusCtrl);
            this.panel1.Controls.Add(this.textBoxSkipUtc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 261);
            this.panel1.TabIndex = 0;
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.White;
            this.btnSkip.Location = new System.Drawing.Point(201, 101);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 2;
            this.btnSkip.Text = "跳转";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnStatusCtrl
            // 
            this.btnStatusCtrl.Image = global::GnssView.Properties.Resources.开始;
            this.btnStatusCtrl.Location = new System.Drawing.Point(95, 27);
            this.btnStatusCtrl.Name = "btnStatusCtrl";
            this.btnStatusCtrl.Size = new System.Drawing.Size(54, 54);
            this.btnStatusCtrl.TabIndex = 1;
            this.btnStatusCtrl.UseVisualStyleBackColor = false;
            this.btnStatusCtrl.Click += new System.EventHandler(this.btnStatusCtrl_Click);
            // 
            // textBoxSkipUtc
            // 
            this.textBoxSkipUtc.Location = new System.Drawing.Point(95, 101);
            this.textBoxSkipUtc.Name = "textBoxSkipUtc";
            this.textBoxSkipUtc.Size = new System.Drawing.Size(100, 21);
            this.textBoxSkipUtc.TabIndex = 0;
            this.textBoxSkipUtc.Text = "UTC(HHMMSS)";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormReplay
            // 
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReplay";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnStatusCtrl;
        private System.Windows.Forms.TextBox textBoxSkipUtc;
        private System.Windows.Forms.Timer timer1;
    }
}