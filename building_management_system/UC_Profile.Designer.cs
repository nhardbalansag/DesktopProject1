namespace building_management_system
{
    partial class UC_Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Profile));
            this.panel_steady_slide_form_3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label_logo_text = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel_steady_slide_form_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_steady_slide_form_3
            // 
            this.panel_steady_slide_form_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(218)))), ((int)(((byte)(241)))));
            this.panel_steady_slide_form_3.Controls.Add(this.button1);
            this.panel_steady_slide_form_3.Controls.Add(this.label_logo_text);
            this.panel_steady_slide_form_3.Controls.Add(this.pictureBox2);
            this.panel_steady_slide_form_3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_steady_slide_form_3.Location = new System.Drawing.Point(0, 0);
            this.panel_steady_slide_form_3.Name = "panel_steady_slide_form_3";
            this.panel_steady_slide_form_3.Size = new System.Drawing.Size(224, 542);
            this.panel_steady_slide_form_3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(38)))), ((int)(((byte)(66)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "Profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_logo_text
            // 
            this.label_logo_text.Font = new System.Drawing.Font("Cooper Std Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_logo_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(38)))), ((int)(((byte)(66)))));
            this.label_logo_text.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_logo_text.Location = new System.Drawing.Point(72, 12);
            this.label_logo_text.Name = "label_logo_text";
            this.label_logo_text.Size = new System.Drawing.Size(127, 41);
            this.label_logo_text.TabIndex = 4;
            this.label_logo_text.Text = "Dashboard";
            this.label_logo_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(38)))), ((int)(((byte)(66)))));
            this.pictureBox2.Image = global::building_management_system.Properties.Resources.logo_1inch;
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(27, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // UC_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_steady_slide_form_3);
            this.Name = "UC_Profile";
            this.Size = new System.Drawing.Size(224, 542);
            this.panel_steady_slide_form_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_steady_slide_form_3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_logo_text;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
