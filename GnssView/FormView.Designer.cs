namespace GnssView
{
    partial class FormView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel3 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel4 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel5 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel6 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel7 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel8 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel9 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel10 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel11 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel12 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormView));
            this.contextMenuStripView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.galToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerControlView = new DevExpress.XtraEditors.SplitContainerControl();
            this.dataGridViewGga = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStripView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlView)).BeginInit();
            this.splitContainerControlView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartView)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripView
            // 
            this.contextMenuStripView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gpsToolStripMenuItem,
            this.bdsToolStripMenuItem,
            this.gloToolStripMenuItem,
            this.galToolStripMenuItem,
            this.allToolStripMenuItem});
            this.contextMenuStripView.Name = "contextMenuStripView";
            this.contextMenuStripView.Size = new System.Drawing.Size(102, 114);
            this.contextMenuStripView.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripView_ItemClicked);
            // 
            // gpsToolStripMenuItem
            // 
            this.gpsToolStripMenuItem.Checked = true;
            this.gpsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gpsToolStripMenuItem.Name = "gpsToolStripMenuItem";
            this.gpsToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.gpsToolStripMenuItem.Text = "GPS";
            // 
            // bdsToolStripMenuItem
            // 
            this.bdsToolStripMenuItem.Checked = true;
            this.bdsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bdsToolStripMenuItem.Name = "bdsToolStripMenuItem";
            this.bdsToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.bdsToolStripMenuItem.Text = "BDS";
            // 
            // gloToolStripMenuItem
            // 
            this.gloToolStripMenuItem.Checked = true;
            this.gloToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gloToolStripMenuItem.Name = "gloToolStripMenuItem";
            this.gloToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.gloToolStripMenuItem.Text = "GLO";
            // 
            // galToolStripMenuItem
            // 
            this.galToolStripMenuItem.Checked = true;
            this.galToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.galToolStripMenuItem.Name = "galToolStripMenuItem";
            this.galToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.galToolStripMenuItem.Text = "GAL";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Checked = true;
            this.allToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.allToolStripMenuItem.Text = "ALL";
            // 
            // splitContainerControlView
            // 
            this.splitContainerControlView.Appearance.BackColor = System.Drawing.Color.Black;
            this.splitContainerControlView.Appearance.Options.UseBackColor = true;
            this.splitContainerControlView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControlView.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlView.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlView.Name = "splitContainerControlView";
            this.splitContainerControlView.Panel1.Controls.Add(this.dataGridViewGga);
            this.splitContainerControlView.Panel1.Text = "Panel1";
            this.splitContainerControlView.Panel2.Controls.Add(this.chartView);
            this.splitContainerControlView.Panel2.Text = "Panel2";
            this.splitContainerControlView.Size = new System.Drawing.Size(881, 531);
            this.splitContainerControlView.SplitterPosition = 244;
            this.splitContainerControlView.TabIndex = 1;
            this.splitContainerControlView.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerControlView_Paint);
            // 
            // dataGridViewGga
            // 
            this.dataGridViewGga.AllowUserToAddRows = false;
            this.dataGridViewGga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGga.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridViewGga.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewGga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGga.ColumnHeadersVisible = false;
            this.dataGridViewGga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridViewGga.GridColor = System.Drawing.Color.Black;
            this.dataGridViewGga.Location = new System.Drawing.Point(21, 86);
            this.dataGridViewGga.Name = "dataGridViewGga";
            this.dataGridViewGga.RowHeadersVisible = false;
            this.dataGridViewGga.RowTemplate.Height = 23;
            this.dataGridViewGga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewGga.Size = new System.Drawing.Size(203, 355);
            this.dataGridViewGga.TabIndex = 2;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.FillWeight = 70F;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // chartView
            // 
            this.chartView.BackColor = System.Drawing.Color.Black;
            customLabel1.Text = "0";
            customLabel2.Text = "45";
            customLabel3.Text = "90";
            customLabel4.Text = "135";
            customLabel5.Text = "180";
            customLabel6.Text = "225";
            customLabel7.Text = "270";
            customLabel8.Text = "315";
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.CustomLabels.Add(customLabel2);
            chartArea1.AxisX.CustomLabels.Add(customLabel3);
            chartArea1.AxisX.CustomLabels.Add(customLabel4);
            chartArea1.AxisX.CustomLabels.Add(customLabel5);
            chartArea1.AxisX.CustomLabels.Add(customLabel6);
            chartArea1.AxisX.CustomLabels.Add(customLabel7);
            chartArea1.AxisX.CustomLabels.Add(customLabel8);
            chartArea1.AxisX.CustomLabels.Add(customLabel9);
            chartArea1.AxisX.Interval = 45D;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 8F);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.Maximum = 360D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            customLabel10.FromPosition = 30D;
            customLabel10.Text = "30";
            customLabel10.ToPosition = 32D;
            customLabel11.FromPosition = 60D;
            customLabel11.Text = "60";
            customLabel11.ToPosition = 62D;
            customLabel12.FromPosition = 90D;
            customLabel12.Text = "90";
            customLabel12.ToPosition = 92D;
            chartArea1.AxisY.CustomLabels.Add(customLabel10);
            chartArea1.AxisY.CustomLabels.Add(customLabel11);
            chartArea1.AxisY.CustomLabels.Add(customLabel12);
            chartArea1.AxisY.Interval = 30D;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.IsReversed = true;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Consolas", 8F);
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.Maximum = 90D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderColor = System.Drawing.Color.Empty;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            this.chartView.ChartAreas.Add(chartArea1);
            this.chartView.ContextMenuStrip = this.contextMenuStripView;
            this.chartView.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Black;
            legend1.BorderColor = System.Drawing.SystemColors.Desktop;
            legend1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Font = new System.Drawing.Font("Consolas", 8F);
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsDockedInsideChartArea = false;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartView.Legends.Add(legend1);
            this.chartView.Location = new System.Drawing.Point(0, 0);
            this.chartView.Name = "chartView";
            this.chartView.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series1.CustomProperties = "PolarDrawingStyle=Marker, LabelStyle=Center";
            series1.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.LabelBorderWidth = 15;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Blue;
            series1.MarkerSize = 20;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "GPS";
            series1.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.White;
            series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
            series1.SmartLabelStyle.Enabled = false;
            series1.SmartLabelStyle.MaxMovingDistance = 20D;
            series1.ToolTip = "卫星号：#LABEL";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series2.CustomProperties = "PolarDrawingStyle=Marker, LabelStyle=Center";
            series2.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.LabelBorderWidth = 15;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.MarkerColor = System.Drawing.Color.Red;
            series2.MarkerSize = 20;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "BDS";
            series2.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.White;
            series2.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
            series2.SmartLabelStyle.Enabled = false;
            series2.ToolTip = "卫星号：#LABEL";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series3.CustomProperties = "PolarDrawingStyle=Marker, LabelStyle=Center";
            series3.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series3.LabelBorderWidth = 15;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.MarkerColor = System.Drawing.Color.Green;
            series3.MarkerSize = 20;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "GLO";
            series3.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.White;
            series3.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
            series3.SmartLabelStyle.Enabled = false;
            series3.ToolTip = "卫星号：#LABEL";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series4.CustomProperties = "PolarDrawingStyle=Marker, LabelStyle=Center";
            series4.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series4.LabelBorderWidth = 15;
            series4.Legend = "Legend1";
            series4.MarkerColor = System.Drawing.Color.Yellow;
            series4.MarkerSize = 20;
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series4.Name = "GAL";
            series4.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.White;
            series4.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
            series4.SmartLabelStyle.Enabled = false;
            series4.ToolTip = "卫星号：#LABEL";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series5.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series5.CustomProperties = "PolarDrawingStyle=Marker, LabelStyle=Center";
            series5.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.IsVisibleInLegend = false;
            series5.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series5.LabelBorderWidth = 15;
            series5.Legend = "Legend1";
            series5.MarkerColor = System.Drawing.Color.LightGray;
            series5.MarkerSize = 20;
            series5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series5.Name = "IDEL";
            dataPoint1.IsEmpty = true;
            dataPoint1.ToolTip = "";
            series5.Points.Add(dataPoint1);
            series5.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.White;
            series5.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
            series5.SmartLabelStyle.Enabled = false;
            series5.ToolTip = "卫星号：#LABEL";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartView.Series.Add(series1);
            this.chartView.Series.Add(series2);
            this.chartView.Series.Add(series3);
            this.chartView.Series.Add(series4);
            this.chartView.Series.Add(series5);
            this.chartView.Size = new System.Drawing.Size(623, 527);
            this.chartView.TabIndex = 2;
            this.chartView.Text = "View";
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 531);
            this.Controls.Add(this.splitContainerControlView);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "视野";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormView_FormClosing);
            this.Load += new System.EventHandler(this.FormView_Load);
            this.contextMenuStripView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlView)).EndInit();
            this.splitContainerControlView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripView;
        private System.Windows.Forms.ToolStripMenuItem gpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bdsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem galToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlView;
        private System.Windows.Forms.DataGridView dataGridViewGga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartView;
    }
}