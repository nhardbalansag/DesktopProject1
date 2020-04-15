namespace building_management_system
{
    partial class UC_FloorCategory
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFloorType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFloorTypeAdd = new System.Windows.Forms.Button();
            this.panelAddEditBuldingInfo = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonFloorTypeDelete = new System.Windows.Forms.Button();
            this.panelViews = new System.Windows.Forms.Panel();
            this.dataGridFloorTypes = new System.Windows.Forms.DataGridView();
            this.labelWarning = new System.Windows.Forms.Label();
            this.label_description = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.uC_lepnatoLogoDARKfont1 = new building_management_system.UC_lepnatoLogoDARKfont();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelAddEditBuldingInfo.SuspendLayout();
            this.panelViews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFloorTypes)).BeginInit();
            this.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(737, 37);
            this.label1.TabIndex = 49;
            this.label1.Text = "Floor Type Category";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxFloorType
            // 
            this.textBoxFloorType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFloorType.BackColor = System.Drawing.Color.White;
            this.textBoxFloorType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFloorType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxFloorType.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFloorType.Location = new System.Drawing.Point(24, 36);
            this.textBoxFloorType.Name = "textBoxFloorType";
            this.textBoxFloorType.Size = new System.Drawing.Size(560, 33);
            this.textBoxFloorType.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 24);
            this.label3.TabIndex = 35;
            this.label3.Text = "Type Of Floor";
            // 
            // buttonFloorTypeAdd
            // 
            this.buttonFloorTypeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFloorTypeAdd.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonFloorTypeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFloorTypeAdd.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFloorTypeAdd.ForeColor = System.Drawing.Color.White;
            this.buttonFloorTypeAdd.Location = new System.Drawing.Point(603, 32);
            this.buttonFloorTypeAdd.Name = "buttonFloorTypeAdd";
            this.buttonFloorTypeAdd.Size = new System.Drawing.Size(111, 36);
            this.buttonFloorTypeAdd.TabIndex = 44;
            this.buttonFloorTypeAdd.Text = "Save";
            this.buttonFloorTypeAdd.UseVisualStyleBackColor = false;
            this.buttonFloorTypeAdd.Click += new System.EventHandler(this.buttonFloorTypeAdd_Click);
            // 
            // panelAddEditBuldingInfo
            // 
            this.panelAddEditBuldingInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAddEditBuldingInfo.BackColor = System.Drawing.Color.White;
            this.panelAddEditBuldingInfo.Controls.Add(this.buttonBack);
            this.panelAddEditBuldingInfo.Controls.Add(this.buttonFloorTypeAdd);
            this.panelAddEditBuldingInfo.Controls.Add(this.label3);
            this.panelAddEditBuldingInfo.Controls.Add(this.textBoxFloorType);
            this.panelAddEditBuldingInfo.Location = new System.Drawing.Point(39, 324);
            this.panelAddEditBuldingInfo.Name = "panelAddEditBuldingInfo";
            this.panelAddEditBuldingInfo.Size = new System.Drawing.Size(737, 130);
            this.panelAddEditBuldingInfo.TabIndex = 51;
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Image = global::building_management_system.Properties.Resources.ic_close_white_24dp;
            this.buttonBack.Location = new System.Drawing.Point(603, 78);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(111, 36);
            this.buttonBack.TabIndex = 46;
            this.buttonBack.Text = "Cancel";
            this.buttonBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonFloorTypeDelete
            // 
            this.buttonFloorTypeDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFloorTypeDelete.BackColor = System.Drawing.Color.Brown;
            this.buttonFloorTypeDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFloorTypeDelete.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFloorTypeDelete.ForeColor = System.Drawing.Color.White;
            this.buttonFloorTypeDelete.Location = new System.Drawing.Point(642, 705);
            this.buttonFloorTypeDelete.Name = "buttonFloorTypeDelete";
            this.buttonFloorTypeDelete.Size = new System.Drawing.Size(111, 36);
            this.buttonFloorTypeDelete.TabIndex = 51;
            this.buttonFloorTypeDelete.Text = "Delete";
            this.buttonFloorTypeDelete.UseVisualStyleBackColor = false;
            this.buttonFloorTypeDelete.Click += new System.EventHandler(this.buttonFloorTypeDelete_Click);
            // 
            // panelViews
            // 
            this.panelViews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelViews.AutoScroll = true;
            this.panelViews.BackColor = System.Drawing.Color.White;
            this.panelViews.Controls.Add(this.dataGridFloorTypes);
            this.panelViews.Location = new System.Drawing.Point(63, 460);
            this.panelViews.Name = "panelViews";
            this.panelViews.Size = new System.Drawing.Size(560, 281);
            this.panelViews.TabIndex = 52;
            // 
            // dataGridFloorTypes
            // 
            this.dataGridFloorTypes.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridFloorTypes.AllowUserToAddRows = false;
            this.dataGridFloorTypes.AllowUserToDeleteRows = false;
            this.dataGridFloorTypes.AllowUserToResizeColumns = false;
            this.dataGridFloorTypes.AllowUserToResizeRows = false;
            this.dataGridFloorTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridFloorTypes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridFloorTypes.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridFloorTypes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFloorTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridFloorTypes.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridFloorTypes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridFloorTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridFloorTypes.Location = new System.Drawing.Point(0, 0);
            this.dataGridFloorTypes.Name = "dataGridFloorTypes";
            this.dataGridFloorTypes.ReadOnly = true;
            this.dataGridFloorTypes.Size = new System.Drawing.Size(560, 281);
            this.dataGridFloorTypes.TabIndex = 49;
            this.dataGridFloorTypes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFloorTypes_CellContentClick);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(41, 255);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(92, 24);
            this.labelWarning.TabIndex = 52;
            this.labelWarning.Text = "warning";
            this.labelWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_description
            // 
            this.label_description.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(38)))), ((int)(((byte)(66)))));
            this.label_description.Location = new System.Drawing.Point(55, 786);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(431, 45);
            this.label_description.TabIndex = 53;
            this.label_description.Text = " Cliked the table row you wish to delete\r\n or Edit";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.YellowGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(642, 663);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 36);
            this.button1.TabIndex = 54;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uC_lepnatoLogoDARKfont1
            // 
            this.uC_lepnatoLogoDARKfont1.Location = new System.Drawing.Point(39, 68);
            this.uC_lepnatoLogoDARKfont1.Name = "uC_lepnatoLogoDARKfont1";
            this.uC_lepnatoLogoDARKfont1.Size = new System.Drawing.Size(387, 119);
            this.uC_lepnatoLogoDARKfont1.TabIndex = 50;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.BackgroundImage = global::building_management_system.Properties.Resources.Untitled_1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Location = new System.Drawing.Point(0, 902);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(835, 47);
            this.panel3.TabIndex = 96;
            // 
            // UC_FloorCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.panelViews);
            this.Controls.Add(this.buttonFloorTypeDelete);
            this.Controls.Add(this.panelAddEditBuldingInfo);
            this.Controls.Add(this.uC_lepnatoLogoDARKfont1);
            this.Controls.Add(this.label1);
            this.Name = "UC_FloorCategory";
            this.Size = new System.Drawing.Size(835, 949);
            this.panelAddEditBuldingInfo.ResumeLayout(false);
            this.panelAddEditBuldingInfo.PerformLayout();
            this.panelViews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFloorTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UC_lepnatoLogoDARKfont uC_lepnatoLogoDARKfont1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFloorType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonFloorTypeAdd;
        private System.Windows.Forms.Panel panelAddEditBuldingInfo;
        private System.Windows.Forms.Button buttonFloorTypeDelete;
        private System.Windows.Forms.Panel panelViews;
        private System.Windows.Forms.DataGridView dataGridFloorTypes;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panel3;
    }
}
