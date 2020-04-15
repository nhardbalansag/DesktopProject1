namespace building_management_system
{
    partial class UC_graph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_WaterElectric = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_water = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.chart_Electric = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label24 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewGraphContentWater = new System.Windows.Forms.DataGridView();
            this.dataGridViewGraphContentElectricity = new System.Windows.Forms.DataGridView();
            this.uC_lepnatoLogoDARKfont1 = new building_management_system.UC_lepnatoLogoDARKfont();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_WaterElectric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_water)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Electric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphContentWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphContentElectricity)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_WaterElectric
            // 
            this.chart_WaterElectric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart_WaterElectric.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_WaterElectric.Legends.Add(legend1);
            this.chart_WaterElectric.Location = new System.Drawing.Point(39, 429);
            this.chart_WaterElectric.Name = "chart_WaterElectric";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Water";
            series1.YValuesPerPoint = 4;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Electricity";
            this.chart_WaterElectric.Series.Add(series1);
            this.chart_WaterElectric.Series.Add(series2);
            this.chart_WaterElectric.Size = new System.Drawing.Size(1060, 394);
            this.chart_WaterElectric.TabIndex = 65;
            this.chart_WaterElectric.Text = "chart2";
            // 
            // chart_water
            // 
            this.chart_water.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart_water.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            this.chart_water.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart_water.BorderSkin.BorderWidth = 10;
            chartArea2.Name = "ChartArea1";
            this.chart_water.ChartAreas.Add(chartArea2);
            this.chart_water.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart_water.Legends.Add(legend2);
            this.chart_water.Location = new System.Drawing.Point(0, 65);
            this.chart_water.Name = "chart_water";
            this.chart_water.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series3.Label = "water";
            series3.Legend = "Legend1";
            series3.Name = "water";
            this.chart_water.Series.Add(series3);
            this.chart_water.Size = new System.Drawing.Size(1085, 353);
            this.chart_water.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 36);
            this.label2.TabIndex = 67;
            this.label2.Text = "Consumption Summary";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Gray;
            this.panel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel5.Location = new System.Drawing.Point(39, 334);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1060, 10);
            this.panel5.TabIndex = 94;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.LightGray;
            this.panel6.Controls.Add(this.chart_water);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(39, 935);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1085, 418);
            this.panel6.TabIndex = 96;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DimGray;
            this.panel7.Controls.Add(this.label17);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.label14);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1085, 65);
            this.panel7.TabIndex = 67;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(851, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 32);
            this.label17.TabIndex = 5;
            this.label17.Text = "Water";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(946, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 18);
            this.label16.TabIndex = 4;
            this.label16.Text = "Weekly Reports";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(7, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(199, 18);
            this.label15.TabIndex = 3;
            this.label15.Text = "Water Reading Consumption";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(179, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 18);
            this.label14.TabIndex = 2;
            this.label14.Text = "01/01/2019";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(118, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 18);
            this.label13.TabIndex = 1;
            this.label13.Text = "To";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(7, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "01/01/2019";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DimGray;
            this.panel8.Controls.Add(this.label18);
            this.panel8.Controls.Add(this.label19);
            this.panel8.Controls.Add(this.label20);
            this.panel8.Controls.Add(this.label21);
            this.panel8.Controls.Add(this.label22);
            this.panel8.Controls.Add(this.label23);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1085, 65);
            this.panel8.TabIndex = 97;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(851, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 32);
            this.label18.TabIndex = 5;
            this.label18.Text = "Electric";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(962, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(114, 18);
            this.label19.TabIndex = 4;
            this.label19.Text = "Weekly Reports";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(7, 37);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(199, 18);
            this.label20.TabIndex = 3;
            this.label20.Text = "Water Reading Consumption";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(179, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 18);
            this.label21.TabIndex = 2;
            this.label21.Text = "01/01/2019";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(118, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 18);
            this.label22.TabIndex = 1;
            this.label22.Text = "To";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(7, 10);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 18);
            this.label23.TabIndex = 0;
            this.label23.Text = "01/01/2019";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.LightGray;
            this.panel9.Controls.Add(this.chart_Electric);
            this.panel9.Controls.Add(this.panel8);
            this.panel9.Location = new System.Drawing.Point(39, 1405);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1085, 418);
            this.panel9.TabIndex = 98;
            // 
            // chart_Electric
            // 
            this.chart_Electric.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart_Electric.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            this.chart_Electric.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart_Electric.BorderSkin.BorderWidth = 10;
            chartArea3.Name = "ChartArea1";
            this.chart_Electric.ChartAreas.Add(chartArea3);
            this.chart_Electric.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart_Electric.Legends.Add(legend3);
            this.chart_Electric.Location = new System.Drawing.Point(0, 65);
            this.chart_Electric.Name = "chart_Electric";
            this.chart_Electric.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Orange;
            series4.Label = "Electricity";
            series4.Legend = "Legend1";
            series4.Name = "electric";
            this.chart_Electric.Series.Add(series4);
            this.chart_Electric.Size = new System.Drawing.Size(1085, 353);
            this.chart_Electric.TabIndex = 66;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(290, 385);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(230, 30);
            this.label24.TabIndex = 99;
            this.label24.Text = "Water && Electricity";
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.Gray;
            this.panel10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel10.Location = new System.Drawing.Point(39, 868);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1060, 10);
            this.panel10.TabIndex = 103;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(53, 829);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 36);
            this.label11.TabIndex = 104;
            this.label11.Text = "Reports";
            // 
            // dataGridViewGraphContentWater
            // 
            this.dataGridViewGraphContentWater.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGraphContentWater.Location = new System.Drawing.Point(472, 77);
            this.dataGridViewGraphContentWater.Name = "dataGridViewGraphContentWater";
            this.dataGridViewGraphContentWater.Size = new System.Drawing.Size(209, 64);
            this.dataGridViewGraphContentWater.TabIndex = 117;
            // 
            // dataGridViewGraphContentElectricity
            // 
            this.dataGridViewGraphContentElectricity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGraphContentElectricity.Location = new System.Drawing.Point(749, 77);
            this.dataGridViewGraphContentElectricity.Name = "dataGridViewGraphContentElectricity";
            this.dataGridViewGraphContentElectricity.Size = new System.Drawing.Size(209, 64);
            this.dataGridViewGraphContentElectricity.TabIndex = 118;
            this.dataGridViewGraphContentElectricity.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // uC_lepnatoLogoDARKfont1
            // 
            this.uC_lepnatoLogoDARKfont1.Location = new System.Drawing.Point(39, 68);
            this.uC_lepnatoLogoDARKfont1.Name = "uC_lepnatoLogoDARKfont1";
            this.uC_lepnatoLogoDARKfont1.Size = new System.Drawing.Size(387, 119);
            this.uC_lepnatoLogoDARKfont1.TabIndex = 63;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Gray;
            this.panel11.BackgroundImage = global::building_management_system.Properties.Resources.Untitled_1;
            this.panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel11.Location = new System.Drawing.Point(0, 2062);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1158, 47);
            this.panel11.TabIndex = 116;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.YellowGreen;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1060, 37);
            this.label1.TabIndex = 62;
            this.label1.Text = "Consumption Monitoring Graph";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridViewGraphContentElectricity);
            this.Controls.Add(this.dataGridViewGraphContentWater);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chart_WaterElectric);
            this.Controls.Add(this.uC_lepnatoLogoDARKfont1);
            this.Controls.Add(this.label1);
            this.Name = "UC_graph";
            this.Size = new System.Drawing.Size(1158, 2109);
            this.Load += new System.EventHandler(this.UC_graph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_WaterElectric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_water)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Electric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphContentWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGraphContentElectricity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC_lepnatoLogoDARKfont uC_lepnatoLogoDARKfont1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_WaterElectric;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_water;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Electric;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.DataGridView dataGridViewGraphContentWater;
        private System.Windows.Forms.DataGridView dataGridViewGraphContentElectricity;
    }
}
