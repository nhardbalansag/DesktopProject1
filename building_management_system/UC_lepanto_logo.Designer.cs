namespace building_management_system
{
    partial class UC_lepanto_logo
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
            this.label_logo_text = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // label_logo_text
            // 
            this.label_logo_text.AutoSize = true;
            this.label_logo_text.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_logo_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(218)))), ((int)(((byte)(241)))));
            this.label_logo_text.Location = new System.Drawing.Point(118, 19);
            this.label_logo_text.Name = "label_logo_text";
            this.label_logo_text.Size = new System.Drawing.Size(152, 92);
            this.label_logo_text.TabIndex = 3;
            this.label_logo_text.Text = "BA \r\nLepanto \r\nCondominium \r\nCorporation";
            // 
            // logo
            // 
            this.logo.Image = global::building_management_system.Properties.Resources.logo_1inch;
            this.logo.Location = new System.Drawing.Point(16, 19);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(96, 92);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 2;
            this.logo.TabStop = false;
            // 
            // UC_lepanto_logo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(38)))), ((int)(((byte)(66)))));
            this.Controls.Add(this.label_logo_text);
            this.Controls.Add(this.logo);
            this.Name = "UC_lepanto_logo";
            this.Size = new System.Drawing.Size(387, 131);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_logo_text;
        private System.Windows.Forms.PictureBox logo;
    }
}
