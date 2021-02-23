
namespace GnssView
{
    partial class FormEarth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEarth));
            this.webBrowserBaidu = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserBaidu
            // 
            this.webBrowserBaidu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserBaidu.Location = new System.Drawing.Point(0, 0);
            this.webBrowserBaidu.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserBaidu.Name = "webBrowserBaidu";
            this.webBrowserBaidu.Size = new System.Drawing.Size(800, 450);
            this.webBrowserBaidu.TabIndex = 0;
            this.webBrowserBaidu.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // FormEarth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webBrowserBaidu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEarth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormEarth";
            this.Load += new System.EventHandler(this.FormEarth_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserBaidu;
    }
}