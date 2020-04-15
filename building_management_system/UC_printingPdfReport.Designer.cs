namespace building_management_system
{
    partial class UC_printingPdfReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chart_pdf_water = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pdfPanelTittleBar = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelAddressWaterpdf = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelTittlePdfwater = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGeneratePdfWater = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelViewPdfReading = new System.Windows.Forms.Panel();
            this.dataGridPdrfReading = new System.Windows.Forms.DataGridView();
            this.comboBoxSearchUtility = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonSearchReading = new System.Windows.Forms.Button();
            this.labelWarning = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_pdf_water)).BeginInit();
            this.pdfPanelTittleBar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelViewPdfReading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPdrfReading)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_pdf_water
            // 
            this.chart_pdf_water.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_pdf_water.BorderlineWidth = 2;
            this.chart_pdf_water.BorderSkin.BackColor = System.Drawing.Color.Black;
            this.chart_pdf_water.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart_pdf_water.BorderSkin.BorderWidth = 2;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart_pdf_water.ChartAreas.Add(chartArea1);
            this.chart_pdf_water.Location = new System.Drawing.Point(458, 306);
            this.chart_pdf_water.Name = "chart_pdf_water";
            this.chart_pdf_water.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.DodgerBlue;
            series1.EmptyPointStyle.Label = "water";
            series1.EmptyPointStyle.LabelBorderWidth = 5;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series1.LabelBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.Name = "water";
            this.chart_pdf_water.Series.Add(series1);
            this.chart_pdf_water.Size = new System.Drawing.Size(692, 686);
            this.chart_pdf_water.TabIndex = 87;
            this.chart_pdf_water.Text = "chart1";
            // 
            // pdfPanelTittleBar
            // 
            this.pdfPanelTittleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfPanelTittleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdfPanelTittleBar.Controls.Add(this.panel4);
            this.pdfPanelTittleBar.Controls.Add(this.panel3);
            this.pdfPanelTittleBar.Controls.Add(this.panel2);
            this.pdfPanelTittleBar.Location = new System.Drawing.Point(61, 242);
            this.pdfPanelTittleBar.Name = "pdfPanelTittleBar";
            this.pdfPanelTittleBar.Size = new System.Drawing.Size(1089, 54);
            this.pdfPanelTittleBar.TabIndex = 89;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelAddressWaterpdf);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(824, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(263, 52);
            this.panel4.TabIndex = 91;
            // 
            // labelAddressWaterpdf
            // 
            this.labelAddressWaterpdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddressWaterpdf.Location = new System.Drawing.Point(-19, -1);
            this.labelAddressWaterpdf.Multiline = true;
            this.labelAddressWaterpdf.Name = "labelAddressWaterpdf";
            this.labelAddressWaterpdf.Size = new System.Drawing.Size(283, 54);
            this.labelAddressWaterpdf.TabIndex = 0;
            this.labelAddressWaterpdf.Text = "BA LEPANTO CONDOMINIUM CORPORATION\r\n8747 PASEO DEROXAS MAKATI CITY";
            this.labelAddressWaterpdf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.labelTittlePdfwater);
            this.panel3.Location = new System.Drawing.Point(166, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(755, 52);
            this.panel3.TabIndex = 91;
            // 
            // labelTittlePdfwater
            // 
            this.labelTittlePdfwater.BackColor = System.Drawing.Color.White;
            this.labelTittlePdfwater.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelTittlePdfwater.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTittlePdfwater.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTittlePdfwater.Location = new System.Drawing.Point(0, 0);
            this.labelTittlePdfwater.Name = "labelTittlePdfwater";
            this.labelTittlePdfwater.Size = new System.Drawing.Size(755, 40);
            this.labelTittlePdfwater.TabIndex = 82;
            this.labelTittlePdfwater.Text = "WATER CONSUMPTION";
            this.labelTittlePdfwater.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 54);
            this.panel2.TabIndex = 90;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::building_management_system.Properties.Resources.ic_add_a_photo_black_36dp1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 85;
            this.pictureBox1.TabStop = false;
            // 
            // btnGeneratePdfWater
            // 
            this.btnGeneratePdfWater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneratePdfWater.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGeneratePdfWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePdfWater.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePdfWater.ForeColor = System.Drawing.Color.White;
            this.btnGeneratePdfWater.Image = global::building_management_system.Properties.Resources.ic_print_black_36dp;
            this.btnGeneratePdfWater.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneratePdfWater.Location = new System.Drawing.Point(996, 188);
            this.btnGeneratePdfWater.Name = "btnGeneratePdfWater";
            this.btnGeneratePdfWater.Size = new System.Drawing.Size(154, 48);
            this.btnGeneratePdfWater.TabIndex = 88;
            this.btnGeneratePdfWater.Text = "Generate Pdf";
            this.btnGeneratePdfWater.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneratePdfWater.UseVisualStyleBackColor = false;
            this.btnGeneratePdfWater.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BackgroundImage = global::building_management_system.Properties.Resources.Untitled_1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(0, 1129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 47);
            this.panel1.TabIndex = 96;
            // 
            // panelViewPdfReading
            // 
            this.panelViewPdfReading.Controls.Add(this.dataGridPdrfReading);
            this.panelViewPdfReading.Location = new System.Drawing.Point(61, 306);
            this.panelViewPdfReading.Name = "panelViewPdfReading";
            this.panelViewPdfReading.Size = new System.Drawing.Size(383, 686);
            this.panelViewPdfReading.TabIndex = 111;
            // 
            // dataGridPdrfReading
            // 
            this.dataGridPdrfReading.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridPdrfReading.AllowUserToAddRows = false;
            this.dataGridPdrfReading.AllowUserToDeleteRows = false;
            this.dataGridPdrfReading.AllowUserToResizeColumns = false;
            this.dataGridPdrfReading.AllowUserToResizeRows = false;
            this.dataGridPdrfReading.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPdrfReading.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridPdrfReading.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridPdrfReading.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPdrfReading.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridPdrfReading.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridPdrfReading.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridPdrfReading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPdrfReading.Location = new System.Drawing.Point(0, 0);
            this.dataGridPdrfReading.Name = "dataGridPdrfReading";
            this.dataGridPdrfReading.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridPdrfReading.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridPdrfReading.RowTemplate.Height = 80;
            this.dataGridPdrfReading.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridPdrfReading.Size = new System.Drawing.Size(383, 686);
            this.dataGridPdrfReading.TabIndex = 50;
            // 
            // comboBoxSearchUtility
            // 
            this.comboBoxSearchUtility.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSearchUtility.FormattingEnabled = true;
            this.comboBoxSearchUtility.Location = new System.Drawing.Point(184, 133);
            this.comboBoxSearchUtility.Name = "comboBoxSearchUtility";
            this.comboBoxSearchUtility.Size = new System.Drawing.Size(260, 32);
            this.comboBoxSearchUtility.TabIndex = 117;
            this.comboBoxSearchUtility.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchUtility_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(56, 140);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 25);
            this.label19.TabIndex = 118;
            this.label19.Text = "Utility Type";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // buttonSearchReading
            // 
            this.buttonSearchReading.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonSearchReading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchReading.Font = new System.Drawing.Font("Arial Narrow", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchReading.ForeColor = System.Drawing.Color.White;
            this.buttonSearchReading.Image = global::building_management_system.Properties.Resources.ic_cached_white_24dp;
            this.buttonSearchReading.Location = new System.Drawing.Point(341, 188);
            this.buttonSearchReading.Name = "buttonSearchReading";
            this.buttonSearchReading.Size = new System.Drawing.Size(103, 36);
            this.buttonSearchReading.TabIndex = 119;
            this.buttonSearchReading.Text = "Refresh";
            this.buttonSearchReading.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSearchReading.UseVisualStyleBackColor = false;
            this.buttonSearchReading.Click += new System.EventHandler(this.buttonSearchReading_Click);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(463, 133);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(92, 24);
            this.labelWarning.TabIndex = 125;
            this.labelWarning.Text = "warning";
            this.labelWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UC_printingPdfReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.buttonSearchReading);
            this.Controls.Add(this.comboBoxSearchUtility);
            this.Controls.Add(this.panelViewPdfReading);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pdfPanelTittleBar);
            this.Controls.Add(this.btnGeneratePdfWater);
            this.Controls.Add(this.chart_pdf_water);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UC_printingPdfReport";
            this.Size = new System.Drawing.Size(1216, 1176);
            ((System.ComponentModel.ISupportInitialize)(this.chart_pdf_water)).EndInit();
            this.pdfPanelTittleBar.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelViewPdfReading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPdrfReading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_pdf_water;
        private System.Windows.Forms.Button btnGeneratePdfWater;
        private System.Windows.Forms.Panel pdfPanelTittleBar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox labelTittlePdfwater;
        private System.Windows.Forms.TextBox labelAddressWaterpdf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelViewPdfReading;
        private System.Windows.Forms.DataGridView dataGridPdrfReading;
        private System.Windows.Forms.ComboBox comboBoxSearchUtility;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonSearchReading;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Timer timer1;
    }
}
