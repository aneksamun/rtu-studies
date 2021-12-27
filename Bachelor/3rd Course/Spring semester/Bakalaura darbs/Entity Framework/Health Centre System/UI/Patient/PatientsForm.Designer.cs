namespace HealthSystem.UI.Patient {
    partial class PatientsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientsForm));
            this.dividerLabel1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.patientGroupBox = new System.Windows.Forms.GroupBox();
            this.reTypedPsswdLB = new System.Windows.Forms.Label();
            this.psswdLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.psswdTextBox = new System.Windows.Forms.TextBox();
            this.retypedPsswdTxtBox = new System.Windows.Forms.TextBox();
            this.dividerLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.telephoneLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.telephoneTxtBox = new System.Windows.Forms.TextBox();
            this.personCodeTxtBox = new System.Windows.Forms.TextBox();
            this.personCodeLabel = new System.Windows.Forms.Label();
            this.lastnameTextBox = new System.Windows.Forms.TextBox();
            this.firstnameTextBox = new System.Windows.Forms.TextBox();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.firstnameLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.bloodGroupLabel = new System.Windows.Forms.Label();
            this.bloodGroupNUD = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.patientGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloodGroupNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // dividerLabel1
            // 
            this.dividerLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dividerLabel1.Location = new System.Drawing.Point(23, 477);
            this.dividerLabel1.Name = "dividerLabel1";
            this.dividerLabel1.Size = new System.Drawing.Size(416, 2);
            this.dividerLabel1.TabIndex = 52;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(269, 503);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 27);
            this.closeButton.TabIndex = 53;
            this.closeButton.Text = "Aizvērt";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(355, 503);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(96, 27);
            this.saveButton.TabIndex = 54;
            this.saveButton.Text = "Saglabāt datus";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // patientGroupBox
            // 
            this.patientGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.patientGroupBox.Controls.Add(this.reTypedPsswdLB);
            this.patientGroupBox.Controls.Add(this.psswdLabel);
            this.patientGroupBox.Controls.Add(this.descriptionLabel);
            this.patientGroupBox.Controls.Add(this.psswdTextBox);
            this.patientGroupBox.Controls.Add(this.retypedPsswdTxtBox);
            this.patientGroupBox.Controls.Add(this.dividerLabel);
            this.patientGroupBox.Controls.Add(this.usernameLabel);
            this.patientGroupBox.Controls.Add(this.usernameTextBox);
            this.patientGroupBox.Controls.Add(this.addressLabel);
            this.patientGroupBox.Controls.Add(this.telephoneLabel);
            this.patientGroupBox.Controls.Add(this.addressTextBox);
            this.patientGroupBox.Controls.Add(this.telephoneTxtBox);
            this.patientGroupBox.Controls.Add(this.personCodeTxtBox);
            this.patientGroupBox.Controls.Add(this.personCodeLabel);
            this.patientGroupBox.Controls.Add(this.lastnameTextBox);
            this.patientGroupBox.Controls.Add(this.firstnameTextBox);
            this.patientGroupBox.Controls.Add(this.lastnameLabel);
            this.patientGroupBox.Controls.Add(this.firstnameLabel);
            this.patientGroupBox.Controls.Add(this.browseButton);
            this.patientGroupBox.Controls.Add(this.pictureBox);
            this.patientGroupBox.Controls.Add(this.bloodGroupLabel);
            this.patientGroupBox.Controls.Add(this.bloodGroupNUD);
            this.patientGroupBox.Location = new System.Drawing.Point(12, 11);
            this.patientGroupBox.Name = "patientGroupBox";
            this.patientGroupBox.Size = new System.Drawing.Size(438, 457);
            this.patientGroupBox.TabIndex = 56;
            this.patientGroupBox.TabStop = false;
            this.patientGroupBox.Text = "Dati par pacientu";
            // 
            // reTypedPsswdLB
            // 
            this.reTypedPsswdLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reTypedPsswdLB.AutoSize = true;
            this.reTypedPsswdLB.Location = new System.Drawing.Point(32, 366);
            this.reTypedPsswdLB.Name = "reTypedPsswdLB";
            this.reTypedPsswdLB.Size = new System.Drawing.Size(81, 13);
            this.reTypedPsswdLB.TabIndex = 107;
            this.reTypedPsswdLB.Text = "Parole atkārtoti:";
            // 
            // psswdLabel
            // 
            this.psswdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.psswdLabel.AutoSize = true;
            this.psswdLabel.Location = new System.Drawing.Point(73, 341);
            this.psswdLabel.Name = "psswdLabel";
            this.psswdLabel.Size = new System.Drawing.Size(40, 13);
            this.psswdLabel.TabIndex = 109;
            this.psswdLabel.Text = "Parole:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.Location = new System.Drawing.Point(317, 117);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(109, 18);
            this.descriptionLabel.TabIndex = 118;
            this.descriptionLabel.Text = "Pacienta profils";
            // 
            // psswdTextBox
            // 
            this.psswdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.psswdTextBox.Location = new System.Drawing.Point(119, 337);
            this.psswdTextBox.MaxLength = 50;
            this.psswdTextBox.Name = "psswdTextBox";
            this.psswdTextBox.PasswordChar = '*';
            this.psswdTextBox.Size = new System.Drawing.Size(245, 20);
            this.psswdTextBox.TabIndex = 108;
            // 
            // retypedPsswdTxtBox
            // 
            this.retypedPsswdTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.retypedPsswdTxtBox.Location = new System.Drawing.Point(119, 363);
            this.retypedPsswdTxtBox.MaxLength = 50;
            this.retypedPsswdTxtBox.Name = "retypedPsswdTxtBox";
            this.retypedPsswdTxtBox.PasswordChar = '*';
            this.retypedPsswdTxtBox.Size = new System.Drawing.Size(244, 20);
            this.retypedPsswdTxtBox.TabIndex = 106;
            // 
            // dividerLabel
            // 
            this.dividerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dividerLabel.Location = new System.Drawing.Point(11, 145);
            this.dividerLabel.Name = "dividerLabel";
            this.dividerLabel.Size = new System.Drawing.Size(416, 2);
            this.dividerLabel.TabIndex = 117;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(43, 314);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(70, 13);
            this.usernameLabel.TabIndex = 116;
            this.usernameLabel.Text = "Lietotājvārds:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameTextBox.Location = new System.Drawing.Point(119, 311);
            this.usernameTextBox.MaxLength = 50;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(245, 20);
            this.usernameTextBox.TabIndex = 115;
            // 
            // addressLabel
            // 
            this.addressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(70, 287);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(43, 13);
            this.addressLabel.TabIndex = 114;
            this.addressLabel.Text = "Adrese:";
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.Location = new System.Drawing.Point(85, 260);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(28, 13);
            this.telephoneLabel.TabIndex = 113;
            this.telephoneLabel.Text = "Tel.:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addressTextBox.Location = new System.Drawing.Point(119, 283);
            this.addressTextBox.MaxLength = 32;
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(244, 22);
            this.addressTextBox.TabIndex = 112;
            // 
            // telephoneTxtBox
            // 
            this.telephoneTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.telephoneTxtBox.Location = new System.Drawing.Point(119, 255);
            this.telephoneTxtBox.MaxLength = 8;
            this.telephoneTxtBox.Multiline = true;
            this.telephoneTxtBox.Name = "telephoneTxtBox";
            this.telephoneTxtBox.Size = new System.Drawing.Size(245, 22);
            this.telephoneTxtBox.TabIndex = 111;
            // 
            // personCodeTxtBox
            // 
            this.personCodeTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.personCodeTxtBox.Location = new System.Drawing.Point(119, 227);
            this.personCodeTxtBox.MaxLength = 12;
            this.personCodeTxtBox.Multiline = true;
            this.personCodeTxtBox.Name = "personCodeTxtBox";
            this.personCodeTxtBox.Size = new System.Drawing.Size(245, 22);
            this.personCodeTxtBox.TabIndex = 110;
            this.toolTip.SetToolTip(this.personCodeTxtBox, "Ievades formāts 000000-00000");
            // 
            // personCodeLabel
            // 
            this.personCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.personCodeLabel.AutoSize = true;
            this.personCodeLabel.Location = new System.Drawing.Point(55, 232);
            this.personCodeLabel.Name = "personCodeLabel";
            this.personCodeLabel.Size = new System.Drawing.Size(58, 13);
            this.personCodeLabel.TabIndex = 105;
            this.personCodeLabel.Text = "Person. k.:";
            // 
            // lastnameTextBox
            // 
            this.lastnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lastnameTextBox.Location = new System.Drawing.Point(119, 199);
            this.lastnameTextBox.MaxLength = 25;
            this.lastnameTextBox.Multiline = true;
            this.lastnameTextBox.Name = "lastnameTextBox";
            this.lastnameTextBox.Size = new System.Drawing.Size(245, 22);
            this.lastnameTextBox.TabIndex = 104;
            // 
            // firstnameTextBox
            // 
            this.firstnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.firstnameTextBox.Location = new System.Drawing.Point(119, 171);
            this.firstnameTextBox.MaxLength = 25;
            this.firstnameTextBox.Multiline = true;
            this.firstnameTextBox.Name = "firstnameTextBox";
            this.firstnameTextBox.Size = new System.Drawing.Size(245, 22);
            this.firstnameTextBox.TabIndex = 103;
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.Location = new System.Drawing.Point(64, 204);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(49, 13);
            this.lastnameLabel.TabIndex = 102;
            this.lastnameLabel.Text = "Uzvārds:";
            // 
            // firstnameLabel
            // 
            this.firstnameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstnameLabel.AutoSize = true;
            this.firstnameLabel.Location = new System.Drawing.Point(76, 175);
            this.firstnameLabel.Name = "firstnameLabel";
            this.firstnameLabel.Size = new System.Drawing.Size(37, 13);
            this.firstnameLabel.TabIndex = 101;
            this.firstnameLabel.Text = "Vārds:";
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browseButton.Location = new System.Drawing.Point(11, 115);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(90, 23);
            this.browseButton.TabIndex = 100;
            this.browseButton.Text = "Sameklēt";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(11, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(90, 90);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 99;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // bloodGroupLabel
            // 
            this.bloodGroupLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bloodGroupLabel.AutoSize = true;
            this.bloodGroupLabel.Location = new System.Drawing.Point(48, 393);
            this.bloodGroupLabel.Name = "bloodGroupLabel";
            this.bloodGroupLabel.Size = new System.Drawing.Size(65, 13);
            this.bloodGroupLabel.TabIndex = 98;
            this.bloodGroupLabel.Text = "Asins grupa:";
            // 
            // bloodGroupNUD
            // 
            this.bloodGroupNUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bloodGroupNUD.Location = new System.Drawing.Point(119, 390);
            this.bloodGroupNUD.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.bloodGroupNUD.Name = "bloodGroupNUD";
            this.bloodGroupNUD.Size = new System.Drawing.Size(244, 20);
            this.bloodGroupNUD.TabIndex = 97;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipTitle = "Personas koda ievade";
            // 
            // PatientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 542);
            this.Controls.Add(this.patientGroupBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.dividerLabel1);
            this.Name = "PatientsForm";
            this.Text = "Pacients";
            this.Load += new System.EventHandler(this.PatientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.patientGroupBox.ResumeLayout(false);
            this.patientGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloodGroupNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label dividerLabel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox patientGroupBox;
        private System.Windows.Forms.Label reTypedPsswdLB;
        private System.Windows.Forms.Label psswdLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox psswdTextBox;
        private System.Windows.Forms.TextBox retypedPsswdTxtBox;
        private System.Windows.Forms.Label dividerLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label telephoneLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox telephoneTxtBox;
        private System.Windows.Forms.TextBox personCodeTxtBox;
        private System.Windows.Forms.Label personCodeLabel;
        private System.Windows.Forms.TextBox lastnameTextBox;
        private System.Windows.Forms.TextBox firstnameTextBox;
        private System.Windows.Forms.Label lastnameLabel;
        private System.Windows.Forms.Label firstnameLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label bloodGroupLabel;
        private System.Windows.Forms.NumericUpDown bloodGroupNUD;
        private System.Windows.Forms.ToolTip toolTip;

    }
}