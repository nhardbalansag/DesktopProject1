namespace building_management_system
{
    partial class UserControl1
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
            this.buttonSearchPersonnel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSearchPersonnel
            // 
            this.buttonSearchPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchPersonnel.AutoEllipsis = true;
            this.buttonSearchPersonnel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonSearchPersonnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchPersonnel.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchPersonnel.ForeColor = System.Drawing.Color.White;
            this.buttonSearchPersonnel.Image = global::building_management_system.Properties.Resources.ic_note_add_white_24dp;
            this.buttonSearchPersonnel.Location = new System.Drawing.Point(242, 164);
            this.buttonSearchPersonnel.Name = "buttonSearchPersonnel";
            this.buttonSearchPersonnel.Size = new System.Drawing.Size(145, 41);
            this.buttonSearchPersonnel.TabIndex = 108;
            this.buttonSearchPersonnel.Text = "Add Record";
            this.buttonSearchPersonnel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonSearchPersonnel.UseVisualStyleBackColor = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSearchPersonnel);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(672, 611);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearchPersonnel;
    }
}
