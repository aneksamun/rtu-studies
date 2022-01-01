namespace NougthAndCroses.UI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.firstFieldPicBox = new System.Windows.Forms.PictureBox();
            pictures[0, 0] = firstFieldPicBox;
            this.secondFieldPicBox = new System.Windows.Forms.PictureBox();
            pictures[0, 1] = secondFieldPicBox;
            this.thirdFieldPicBox = new System.Windows.Forms.PictureBox();
            pictures[0, 2] = thirdFieldPicBox;
            this.fourthFieldPicBox = new System.Windows.Forms.PictureBox();
            pictures[1, 0] = fourthFieldPicBox;
            this.fithFieldPicBox = new System.Windows.Forms.PictureBox();
            pictures[1, 1] = fithFieldPicBox;
            this.sixthFieldPicBox = new System.Windows.Forms.PictureBox();
            pictures[1, 2] = sixthFieldPicBox;
            this.seventhFieldPicBox = new System.Windows.Forms.PictureBox();
            pictures[2, 0] = seventhFieldPicBox;
            this.eightFieldPicBox = new System.Windows.Forms.PictureBox();
            pictures[2, 1] = eightFieldPicBox;
            this.ninthFieldPicBox = new System.Windows.Forms.PictureBox();
            pictures[2, 2] = ninthFieldPicBox;
            this.graphicalOverlay = new NougthAndCroses.UI.GraphicalOverlay(this.components);
            this.menuStrip.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondFieldPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdFieldPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourthFieldPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstFieldPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fithFieldPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eightFieldPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seventhFieldPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ninthFieldPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sixthFieldPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(321, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.fileToolStripMenuItem.Text = "&Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newGameToolStripMenuItem.Image")));
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem});
            this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("colorToolStripMenuItem.Image")));
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.lblStatus);
            this.groupBox.Location = new System.Drawing.Point(33, 279);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(253, 47);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(3, 11);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(247, 28);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "lblStatus";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondFieldPicBox
            // 
            this.secondFieldPicBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.secondFieldPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondFieldPicBox.Location = new System.Drawing.Point(124, 61);
            this.secondFieldPicBox.Name = "secondFieldPicBox";
            this.secondFieldPicBox.Size = new System.Drawing.Size(60, 60);
            this.secondFieldPicBox.TabIndex = 11;
            this.secondFieldPicBox.TabStop = false;
            // 
            // thirdFieldPicBox
            // 
            this.thirdFieldPicBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.thirdFieldPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thirdFieldPicBox.Location = new System.Drawing.Point(190, 61);
            this.thirdFieldPicBox.Name = "thirdFieldPicBox";
            this.thirdFieldPicBox.Size = new System.Drawing.Size(60, 60);
            this.thirdFieldPicBox.TabIndex = 12;
            this.thirdFieldPicBox.TabStop = false;
            // 
            // fourthFieldPicBox
            // 
            this.fourthFieldPicBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fourthFieldPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fourthFieldPicBox.Location = new System.Drawing.Point(58, 127);
            this.fourthFieldPicBox.Name = "fourthFieldPicBox";
            this.fourthFieldPicBox.Size = new System.Drawing.Size(60, 60);
            this.fourthFieldPicBox.TabIndex = 13;
            this.fourthFieldPicBox.TabStop = false;
            // 
            // firstFieldPicBox
            // 
            this.firstFieldPicBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.firstFieldPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstFieldPicBox.Location = new System.Drawing.Point(58, 61);
            this.firstFieldPicBox.Name = "firstFieldPicBox";
            this.firstFieldPicBox.Size = new System.Drawing.Size(60, 60);
            this.firstFieldPicBox.TabIndex = 14;
            this.firstFieldPicBox.TabStop = false;
            // 
            // fithFieldPicBox
            // 
            this.fithFieldPicBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fithFieldPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fithFieldPicBox.Location = new System.Drawing.Point(124, 127);
            this.fithFieldPicBox.Name = "fithFieldPicBox";
            this.fithFieldPicBox.Size = new System.Drawing.Size(60, 60);
            this.fithFieldPicBox.TabIndex = 15;
            this.fithFieldPicBox.TabStop = false;
            // 
            // eightFieldPicBox
            // 
            this.eightFieldPicBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.eightFieldPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eightFieldPicBox.Location = new System.Drawing.Point(124, 193);
            this.eightFieldPicBox.Name = "eightFieldPicBox";
            this.eightFieldPicBox.Size = new System.Drawing.Size(60, 60);
            this.eightFieldPicBox.TabIndex = 16;
            this.eightFieldPicBox.TabStop = false;
            // 
            // seventhFieldPicBox
            // 
            this.seventhFieldPicBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.seventhFieldPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seventhFieldPicBox.Location = new System.Drawing.Point(58, 193);
            this.seventhFieldPicBox.Name = "seventhFieldPicBox";
            this.seventhFieldPicBox.Size = new System.Drawing.Size(60, 60);
            this.seventhFieldPicBox.TabIndex = 17;
            this.seventhFieldPicBox.TabStop = false;
            // 
            // ninthFieldPicBox
            // 
            this.ninthFieldPicBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ninthFieldPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ninthFieldPicBox.Location = new System.Drawing.Point(190, 193);
            this.ninthFieldPicBox.Name = "ninthFieldPicBox";
            this.ninthFieldPicBox.Size = new System.Drawing.Size(61, 60);
            this.ninthFieldPicBox.TabIndex = 18;
            this.ninthFieldPicBox.TabStop = false;
            // 
            // sixthFieldPicBox
            // 
            this.sixthFieldPicBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sixthFieldPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sixthFieldPicBox.Location = new System.Drawing.Point(190, 127);
            this.sixthFieldPicBox.Name = "sixthFieldPicBox";
            this.sixthFieldPicBox.Size = new System.Drawing.Size(61, 60);
            this.sixthFieldPicBox.TabIndex = 19;
            this.sixthFieldPicBox.TabStop = false;
            // 
            // graphicalOverlay
            // 
            this.graphicalOverlay.Paint += new System.EventHandler<System.Windows.Forms.PaintEventArgs>(this.graphicalOverlay_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(321, 350);
            this.Controls.Add(this.sixthFieldPicBox);
            this.Controls.Add(this.ninthFieldPicBox);
            this.Controls.Add(this.seventhFieldPicBox);
            this.Controls.Add(this.eightFieldPicBox);
            this.Controls.Add(this.fithFieldPicBox);
            this.Controls.Add(this.firstFieldPicBox);
            this.Controls.Add(this.fourthFieldPicBox);
            this.Controls.Add(this.thirdFieldPicBox);
            this.Controls.Add(this.secondFieldPicBox);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "Tic-Tac-Toe";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondFieldPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdFieldPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fourthFieldPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstFieldPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fithFieldPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eightFieldPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seventhFieldPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ninthFieldPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sixthFieldPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox secondFieldPicBox;
        private System.Windows.Forms.PictureBox thirdFieldPicBox;
        private System.Windows.Forms.PictureBox fourthFieldPicBox;
        private System.Windows.Forms.PictureBox firstFieldPicBox;
        private System.Windows.Forms.PictureBox fithFieldPicBox;
        private System.Windows.Forms.PictureBox eightFieldPicBox;
        private System.Windows.Forms.PictureBox seventhFieldPicBox;
        private System.Windows.Forms.PictureBox ninthFieldPicBox;
        private System.Windows.Forms.PictureBox sixthFieldPicBox;
        private GraphicalOverlay graphicalOverlay;
    }
}

