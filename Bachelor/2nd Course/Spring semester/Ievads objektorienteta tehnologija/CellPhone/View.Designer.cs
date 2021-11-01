namespace CellPhone
{
    partial class View
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
			this.display = new PhoneDisplay();
			this.keyboard = new CellPhone.PhoneKeyboard();
			this.SuspendLayout();
			// 
			// display
			// 
			this.display.AutoScroll = true;
			this.display.BackColor = System.Drawing.Color.Black;
			this.display.Location = new System.Drawing.Point(30, 37);
			this.display.Name = "display";
			this.display.SelectedMenuIndex = -1;
			this.display.Size = new System.Drawing.Size(126, 157);
			this.display.TabIndex = 0;
			// 
			// keyboard
			// 
			this.keyboard.BackColor = System.Drawing.Color.Black;
			this.keyboard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("keyboard.BackgroundImage")));
			this.keyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.keyboard.Location = new System.Drawing.Point(8, 199);
			this.keyboard.Name = "keyboard";
			this.keyboard.Size = new System.Drawing.Size(169, 169);
			this.keyboard.TabIndex = 1;
			// 
			// View
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::CellPhone.Properties.Resources.w810;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(187, 397);
			this.Controls.Add(this.keyboard);
			this.Controls.Add(this.display);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "View";
			this.Text = "View";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.View_Paint);
			this.ResumeLayout(false);

        }

        #endregion

		private PhoneDisplay display;
		private PhoneKeyboard keyboard;

	}
}