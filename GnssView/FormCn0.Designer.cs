namespace GnssView
{
    partial class FormCn0
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCn0));
            this.panelControlCn0 = new DevExpress.XtraEditors.PanelControl();
            this.chartCn0 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStripCn0 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.galToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlCn0)).BeginInit();
            this.panelControlCn0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCn0)).BeginInit();
            this.contextMenuStripCn0.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControlCn0
            // 
            this.panelControlCn0.Controls.Add(this.chartCn0);
            this.panelControlCn0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlCn0.Location = new System.Drawing.Point(0, 0);
            this.panelControlCn0.Name = "panelControlCn0";
            this.panelControlCn0.Size = new System.Drawing.Size(863, 538);
            this.panelControlCn0.TabIndex = 0;
            // 
            // chartCn0
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 8F);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Interval = 10D;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Consolas", 8F);
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Maximum = 60D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.BorderColor = System.Drawing.Color.DimGray;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 90F;
            chartArea1.InnerPlotPosition.Width = 94F;
            chartArea1.InnerPlotPosition.X = 4F;
            chartArea1.InnerPlotPosition.Y = 4F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chartCn0.ChartAreas.Add(chartArea1);
            this.chartCn0.ContextMenuStrip = this.contextMenuStripCn0;
            this.chartCn0.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartCn0.Legends.Add(legend1);
            this.chartCn0.Location = new System.Drawing.Point(2, 2);
            this.chartCn0.Name = "chartCn0";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Blue;
            series1.CustomProperties = "PointWidth=0.95, LabelStyle=Bottom";
            series1.Font = new System.Drawing.Font("Consolas", 8F);
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.DimGray;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            dataPoint1.IsEmpty = true;
            series1.Points.Add(dataPoint1);
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartCn0.Series.Add(series1);
            this.chartCn0.Size = new System.Drawing.Size(859, 534);
            this.chartCn0.TabIndex = 7;
            this.chartCn0.Text = "chart1";
            this.chartCn0.Paint += new System.Windows.Forms.PaintEventHandler(this.chartCn0_Paint);
            // 
            // contextMenuStripCn0
            // 
            this.contextMenuStripCn0.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gpsToolStripMenuItem,
            this.bdsToolStripMenuItem,
            this.gloToolStripMenuItem,
            this.galToolStripMenuItem,
            this.allToolStripMenuItem});
            this.contextMenuStripCn0.Name = "contextMenuStripView";
            this.contextMenuStripCn0.Size = new System.Drawing.Size(181, 136);
            this.contextMenuStripCn0.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripCn0_ItemClicked);
            // 
            // gpsToolStripMenuItem
            // 
            this.gpsToolStripMenuItem.Checked = true;
            this.gpsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gpsToolStripMenuItem.Name = "gpsToolStripMenuItem";
            this.gpsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gpsToolStripMenuItem.Text = "GPS";
            // 
            // bdsToolStripMenuItem
            // 
            this.bdsToolStripMenuItem.Checked = true;
            this.bdsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bdsToolStripMenuItem.Name = "bdsToolStripMenuItem";
            this.bdsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bdsToolStripMenuItem.Text = "BDS";
            // 
            // gloToolStripMenuItem
            // 
            this.gloToolStripMenuItem.Checked = true;
            this.gloToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gloToolStripMenuItem.Name = "gloToolStripMenuItem";
            this.gloToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gloToolStripMenuItem.Text = "GLO";
            // 
            // galToolStripMenuItem
            // 
            this.galToolStripMenuItem.Checked = true;
            this.galToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.galToolStripMenuItem.Name = "galToolStripMenuItem";
            this.galToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.galToolStripMenuItem.Text = "GAL";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Checked = true;
            this.allToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.allToolStripMenuItem.Text = "ALL";
            // 
            // FormCn0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 538);
            this.Controls.Add(this.panelControlCn0);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCn0";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "信号强度";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCn0_FormClosing);
            this.Resize += new System.EventHandler(this.FormCn0_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlCn0)).EndInit();
            this.panelControlCn0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCn0)).EndInit();
            this.contextMenuStripCn0.ResumeLayout(false);
            this.ResumeLayout(false);

        }




        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlCn0;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCn0;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCn0;
        private System.Windows.Forms.ToolStripMenuItem gpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bdsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem galToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
    }
}