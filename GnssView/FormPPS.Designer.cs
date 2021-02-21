namespace GnssView
{
    partial class FormPPS
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPPS));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartAdjust = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRecv = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRecv)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.chartAdjust);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chartRecv);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(810, 405);
            this.splitContainerControl1.SplitterPosition = 127;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // chartAdjust
            // 
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartAdjust.ChartAreas.Add(chartArea1);
            this.chartAdjust.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartAdjust.Legends.Add(legend1);
            this.chartAdjust.Location = new System.Drawing.Point(0, 0);
            this.chartAdjust.Name = "chartAdjust";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartAdjust.Series.Add(series1);
            this.chartAdjust.Size = new System.Drawing.Size(806, 269);
            this.chartAdjust.TabIndex = 1;
            this.chartAdjust.Text = "chart1";
            title1.DockedToChartArea = "ChartArea1";
            title1.Name = "Title1";
            title1.Text = "秒脉冲误差(采样钟)";
            this.chartAdjust.Titles.Add(title1);
            // 
            // chartRecv
            // 
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.chartRecv.ChartAreas.Add(chartArea2);
            this.chartRecv.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartRecv.Legends.Add(legend2);
            this.chartRecv.Location = new System.Drawing.Point(0, 0);
            this.chartRecv.Name = "chartRecv";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartRecv.Series.Add(series2);
            this.chartRecv.Size = new System.Drawing.Size(806, 127);
            this.chartRecv.TabIndex = 2;
            this.chartRecv.Text = "chart1";
            title2.DockedToChartArea = "ChartArea1";
            title2.Name = "Title1";
            title2.Text = "钟差(ns)";
            this.chartRecv.Titles.Add(title2);
            // 
            // FormPPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 405);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPPS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "秒脉冲";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPPS_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRecv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAdjust;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRecv;

    }
}