namespace building_management_system
{
    partial class UC_noContent
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonShowAddInfo = new System.Windows.Forms.Button();
            this.uC_lepnatoLogoDARKfont1 = new building_management_system.UC_lepnatoLogoDARKfont();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::building_management_system.Properties.Resources.ic_error_outline_black_48dp;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(259, 57);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.label2.Size = new System.Drawing.Size(206, 48);
            this.label2.TabIndex = 8;
            this.label2.Text = "No Content.        ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonShowAddInfo
            // 
            this.buttonShowAddInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonShowAddInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowAddInfo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowAddInfo.ForeColor = System.Drawing.Color.White;
            this.buttonShowAddInfo.Location = new System.Drawing.Point(264, 145);
            this.buttonShowAddInfo.Name = "buttonShowAddInfo";
            this.buttonShowAddInfo.Size = new System.Drawing.Size(171, 36);
            this.buttonShowAddInfo.TabIndex = 45;
            this.buttonShowAddInfo.Text = "Add Information";
            this.buttonShowAddInfo.UseVisualStyleBackColor = false;
            // 
            // uC_lepnatoLogoDARKfont1
            // 
            this.uC_lepnatoLogoDARKfont1.Location = new System.Drawing.Point(39, 68);
            this.uC_lepnatoLogoDARKfont1.Name = "uC_lepnatoLogoDARKfont1";
            this.uC_lepnatoLogoDARKfont1.Size = new System.Drawing.Size(387, 119);
            this.uC_lepnatoLogoDARKfont1.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.YellowGreen;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(724, 37);
            this.label1.TabIndex = 46;
            this.label1.Text = "Building Information";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonShowAddInfo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(58, 359);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 251);
            this.panel1.TabIndex = 48;
            // 
            // UC_noContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uC_lepnatoLogoDARKfont1);
            this.Controls.Add(this.label1);
            this.Name = "UC_noContent";
            this.Size = new System.Drawing.Size(835, 809);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonShowAddInfo;
        private UC_lepnatoLogoDARKfont uC_lepnatoLogoDARKfont1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
