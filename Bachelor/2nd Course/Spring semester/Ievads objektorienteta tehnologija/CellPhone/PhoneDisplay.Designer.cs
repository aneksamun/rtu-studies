namespace CellPhone
{
    partial class PhoneDisplay
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
			this.pbWallpaper = new System.Windows.Forms.PictureBox();
			this.lbSelectRight = new System.Windows.Forms.Label();
			this.lbSelectLeft = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.tbEntryBox = new System.Windows.Forms.TextBox();
			this.listMenu = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.pbWallpaper)).BeginInit();
			this.pbWallpaper.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbWallpaper
			// 
			this.pbWallpaper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pbWallpaper.Controls.Add(this.lbSelectRight);
			this.pbWallpaper.Controls.Add(this.lbSelectLeft);
			this.pbWallpaper.Controls.Add(this.lbTitle);
			this.pbWallpaper.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbWallpaper.Image = global::CellPhone.Properties.Resources.Wallpaper;
			this.pbWallpaper.Location = new System.Drawing.Point(0, 0);
			this.pbWallpaper.MaximumSize = new System.Drawing.Size(176, 220);
			this.pbWallpaper.MinimumSize = new System.Drawing.Size(126, 157);
			this.pbWallpaper.Name = "pbWallpaper";
			this.pbWallpaper.Size = new System.Drawing.Size(126, 157);
			this.pbWallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbWallpaper.TabIndex = 0;
			this.pbWallpaper.TabStop = false;
			// 
			// lbSelectRight
			// 
			this.lbSelectRight.BackColor = System.Drawing.Color.Transparent;
			this.lbSelectRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbSelectRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lbSelectRight.Location = new System.Drawing.Point(64, 129);
			this.lbSelectRight.Name = "lbSelectRight";
			this.lbSelectRight.Size = new System.Drawing.Size(60, 25);
			this.lbSelectRight.TabIndex = 3;
			this.lbSelectRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbSelectRight.Visible = false;
			// 
			// lbSelectLeft
			// 
			this.lbSelectLeft.BackColor = System.Drawing.Color.Transparent;
			this.lbSelectLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbSelectLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lbSelectLeft.Location = new System.Drawing.Point(2, 129);
			this.lbSelectLeft.Name = "lbSelectLeft";
			this.lbSelectLeft.Size = new System.Drawing.Size(60, 25);
			this.lbSelectLeft.TabIndex = 2;
			this.lbSelectLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbSelectLeft.Visible = false;
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbTitle.ForeColor = System.Drawing.Color.Silver;
			this.lbTitle.Location = new System.Drawing.Point(3, 9);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(120, 111);
			this.lbTitle.TabIndex = 1;
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbEntryBox
			// 
			this.tbEntryBox.BackColor = System.Drawing.Color.Black;
			this.tbEntryBox.Enabled = false;
			this.tbEntryBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbEntryBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.tbEntryBox.Location = new System.Drawing.Point(3, 29);
			this.tbEntryBox.Multiline = true;
			this.tbEntryBox.Name = "tbEntryBox";
			this.tbEntryBox.ReadOnly = true;
			this.tbEntryBox.Size = new System.Drawing.Size(120, 92);
			this.tbEntryBox.TabIndex = 4;
			this.tbEntryBox.TabStop = false;
			this.tbEntryBox.Visible = false;
			// 
			// listMenu
			// 
			this.listMenu.BackColor = System.Drawing.Color.Black;
			this.listMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.listMenu.FormattingEnabled = true;
			this.listMenu.Location = new System.Drawing.Point(3, 29);
			this.listMenu.Name = "listMenu";
			this.listMenu.Size = new System.Drawing.Size(120, 95);
			this.listMenu.TabIndex = 5;
			this.listMenu.Visible = false;
			// 
			// PhoneDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.listMenu);
			this.Controls.Add(this.tbEntryBox);
			this.Controls.Add(this.pbWallpaper);
			this.Name = "PhoneDisplay";
			this.Size = new System.Drawing.Size(126, 157);
			((System.ComponentModel.ISupportInitialize)(this.pbWallpaper)).EndInit();
			this.pbWallpaper.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.PictureBox pbWallpaper;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbSelectLeft;
		private System.Windows.Forms.Label lbSelectRight;
		private System.Windows.Forms.TextBox tbEntryBox;
		private System.Windows.Forms.ListBox listMenu;

	}
}
