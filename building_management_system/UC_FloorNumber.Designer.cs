namespace building_management_system
{
    partial class UC_FloorNumber
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelAddEditBuldingInfo = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelViews = new System.Windows.Forms.Panel();
            this.dataGridFloorNumber = new System.Windows.Forms.DataGridView();
            this.buttonSaveInfo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFloorNumber = new System.Windows.Forms.TextBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uC_lepnatoLogoDARKfont1 = new building_management_system.UC_lepnatoLogoDARKfont();
            this.panelAddEditBuldingInfo.SuspendLayout();
            this.panelViews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFloorNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAddEditBuldingInfo
            // 
            this.panelAddEditBuldingInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAddEditBuldingInfo.AutoScroll = true;
            this.panelAddEditBuldingInfo.BackColor = System.Drawing.Color.White;
            this.panelAddEditBuldingInfo.Controls.Add(this.button1);
            this.panelAddEditBuldingInfo.Controls.Add(this.panelViews);
            this.panelAddEditBuldingInfo.Controls.Add(this.buttonSaveInfo);
            this.panelAddEditBuldingInfo.Controls.Add(this.label3);
            this.panelAddEditBuldingInfo.Controls.Add(this.textBoxFloorNumber);
            this.panelAddEditBuldingInfo.Location = new System.Drawing.Point(39, 304);
            this.panelAddEditBuldingInfo.Name = "panelAddEditBuldingInfo";
            this.panelAddEditBuldingInfo.Size = new System.Drawing.Size(754, 504);
            this.panelAddEditBuldingInfo.TabIndex = 48;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(417, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 36);
            this.button1.TabIndex = 50;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelViews
            // 
            this.panelViews.AutoScroll = true;
            this.panelViews.BackColor = System.Drawing.Color.White;
            this.panelViews.Controls.Add(this.dataGridFloorNumber);
            this.panelViews.Location = new System.Drawing.Point(6, 104);
            this.panelViews.Name = "panelViews";
            this.panelViews.Size = new System.Drawing.Size(396, 397);
            this.panelViews.TabIndex = 51;
            // 
            // dataGridFloorNumber
            // 
            this.dataGridFloorNumber.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridFloorNumber.AllowUserToAddRows = false;
            this.dataGridFloorNumber.AllowUserToDeleteRows = false;
            this.dataGridFloorNumber.AllowUserToResizeColumns = false;
            this.dataGridFloorNumber.AllowUserToResizeRows = false;
            this.dataGridFloorNumber.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridFloorNumber.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridFloorNumber.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridFloorNumber.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFloorNumber.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridFloorNumber.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridFloorNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridFloorNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridFloorNumber.Location = new System.Drawing.Point(0, 0);
            this.dataGridFloorNumber.Name = "dataGridFloorNumber";
            this.dataGridFloorNumber.Size = new System.Drawing.Size(396, 397);
            this.dataGridFloorNumber.TabIndex = 49;
            this.dataGridFloorNumber.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFloorNumber_CellContentClick);
            // 
            // buttonSaveInfo
            // 
            this.buttonSaveInfo.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonSaveInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveInfo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveInfo.ForeColor = System.Drawing.Color.White;
            this.buttonSaveInfo.Location = new System.Drawing.Point(417, 16);
            this.buttonSaveInfo.Name = "buttonSaveInfo";
            this.buttonSaveInfo.Size = new System.Drawing.Size(111, 33);
            this.buttonSaveInfo.TabIndex = 44;
            this.buttonSaveInfo.Text = "Add";
            this.buttonSaveInfo.UseVisualStyleBackColor = false;
            this.buttonSaveInfo.Click += new System.EventHandler(this.buttonSaveInfo_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 24);
            this.label3.TabIndex = 35;
            this.label3.Text = "Floor Number";
            // 
            // textBoxFloorNumber
            // 
            this.textBoxFloorNumber.BackColor = System.Drawing.Color.White;
            this.textBoxFloorNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFloorNumber.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFloorNumber.Location = new System.Drawing.Point(6, 16);
            this.textBoxFloorNumber.Name = "textBoxFloorNumber";
            this.textBoxFloorNumber.Size = new System.Drawing.Size(396, 33);
            this.textBoxFloorNumber.TabIndex = 34;
            this.textBoxFloorNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(41, 262);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(92, 24);
            this.labelWarning.TabIndex = 51;
            this.labelWarning.Text = "warning";
            this.labelWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label1.Size = new System.Drawing.Size(754, 37);
            this.label1.TabIndex = 46;
            this.label1.Text = "Floor Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.BackgroundImage = global::building_management_system.Properties.Resources.Untitled_1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Location = new System.Drawing.Point(0, 868);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(835, 47);
            this.panel3.TabIndex = 95;
            // 
            // uC_lepnatoLogoDARKfont1
            // 
            this.uC_lepnatoLogoDARKfont1.Location = new System.Drawing.Point(39, 68);
            this.uC_lepnatoLogoDARKfont1.Name = "uC_lepnatoLogoDARKfont1";
            this.uC_lepnatoLogoDARKfont1.Size = new System.Drawing.Size(387, 119);
            this.uC_lepnatoLogoDARKfont1.TabIndex = 47;
            // 
            // UC_FloorNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.panelAddEditBuldingInfo);
            this.Controls.Add(this.uC_lepnatoLogoDARKfont1);
            this.Controls.Add(this.label1);
            this.Name = "UC_FloorNumber";
            this.Size = new System.Drawing.Size(835, 915);
            this.Load += new System.EventHandler(this.UC_FloorNumber_Load);
            this.panelAddEditBuldingInfo.ResumeLayout(false);
            this.panelAddEditBuldingInfo.PerformLayout();
            this.panelViews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFloorNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAddEditBuldingInfo;
        private System.Windows.Forms.Button buttonSaveInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFloorNumber;
        private UC_lepnatoLogoDARKfont uC_lepnatoLogoDARKfont1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridFloorNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelViews;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Panel panel3;
    }
}
