namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.time = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblAgent = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_version = new System.Windows.Forms.Label();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            this.bio = new AxBIOPLUGINACTXLib.AxBioPlugInActX();
            this.lblTestEdition = new System.Windows.Forms.Label();
            this.lblNotForProductionUse = new System.Windows.Forms.Label();
            this.panelTest = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bio)).BeginInit();
            this.panelTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(286, 474);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(217, 474);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(61, 28);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(115, 430);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(240, 24);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(116, 368);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(239, 24);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MISL.Ababil.Agent.UI.Properties.Resources.login_back_04;
            this.pictureBox1.Location = new System.Drawing.Point(-22, 179);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 425);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // time
            // 
            this.time.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Location = new System.Drawing.Point(521, 405);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(743, 108);
            this.time.TabIndex = 13;
            this.time.Text = "label1";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.time.Click += new System.EventHandler(this.time_Click);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(494, 507);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblDate.Size = new System.Drawing.Size(743, 31);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "label1";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblAgent
            // 
            this.lblAgent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgent.Location = new System.Drawing.Point(494, 330);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblAgent.Size = new System.Drawing.Size(743, 55);
            this.lblAgent.TabIndex = 15;
            this.lblAgent.Text = "Agent Banking";
            this.lblAgent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBankName
            // 
            this.lblBankName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.Location = new System.Drawing.Point(508, 280);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblBankName.Size = new System.Drawing.Size(743, 55);
            this.lblBankName.TabIndex = 17;
            this.lblBankName.Text = "Al-Arafah Islami Bank Ltd.";
            this.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(954, -19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 30);
            this.label2.TabIndex = 18;
            this.label2.Text = "Version: 0.00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Visible = false;
            // 
            // lbl_version
            // 
            this.lbl_version.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_version.AutoSize = true;
            this.lbl_version.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_version.Location = new System.Drawing.Point(1182, 385);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(59, 20);
            this.lbl_version.TabIndex = 20;
            this.lbl_version.Text = "version";
            // 
            // customTitlebar1
            // 
            this.customTitlebar1.BackColor = System.Drawing.Color.Transparent;
            this.customTitlebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.customTitlebar1.Location = new System.Drawing.Point(0, 0);
            this.customTitlebar1.MinimumSize = new System.Drawing.Size(0, 26);
            this.customTitlebar1.Name = "customTitlebar1";
            this.customTitlebar1.OwnerForm = this;
            this.customTitlebar1.ShowTitle = false;
            this.customTitlebar1.Size = new System.Drawing.Size(1252, 26);
            this.customTitlebar1.TabIndex = 21;
            // 
            // bio
            // 
            this.bio.Enabled = true;
            this.bio.Location = new System.Drawing.Point(332, 434);
            this.bio.Name = "bio";
            this.bio.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("bio.OcxState")));
            this.bio.Size = new System.Drawing.Size(27, 20);
            this.bio.TabIndex = 16;
            this.bio.OnCapture += new System.EventHandler(this.bio_OnCapture);
            // 
            // lblTestEdition
            // 
            this.lblTestEdition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTestEdition.BackColor = System.Drawing.Color.Transparent;
            this.lblTestEdition.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestEdition.ForeColor = System.Drawing.Color.White;
            this.lblTestEdition.Location = new System.Drawing.Point(11, 10);
            this.lblTestEdition.Name = "lblTestEdition";
            this.lblTestEdition.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblTestEdition.Size = new System.Drawing.Size(261, 32);
            this.lblTestEdition.TabIndex = 15;
            this.lblTestEdition.Text = "TESTING EDITION";
            this.lblTestEdition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNotForProductionUse
            // 
            this.lblNotForProductionUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotForProductionUse.BackColor = System.Drawing.Color.Transparent;
            this.lblNotForProductionUse.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotForProductionUse.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNotForProductionUse.Location = new System.Drawing.Point(11, 38);
            this.lblNotForProductionUse.Name = "lblNotForProductionUse";
            this.lblNotForProductionUse.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblNotForProductionUse.Size = new System.Drawing.Size(261, 32);
            this.lblNotForProductionUse.TabIndex = 15;
            this.lblNotForProductionUse.Text = "NOT FOR PRODUCTION USE";
            this.lblNotForProductionUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTest
            // 
            this.panelTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelTest.Controls.Add(this.lblNotForProductionUse);
            this.panelTest.Controls.Add(this.lblTestEdition);
            this.panelTest.Location = new System.Drawing.Point(965, 39);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(288, 75);
            this.panelTest.TabIndex = 22;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MISL.Ababil.Agent.UI.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1252, 586);
            this.Controls.Add(this.panelTest);
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBankName);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.time);
            this.Controls.Add(this.lblAgent);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Text = "Ababil Agent Banking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLogin_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bio)).EndInit();
            this.panelTest.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblAgent;
        private AxBIOPLUGINACTXLib.AxBioPlugInActX bio;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_version;
        private CustomControls.CustomTitlebar customTitlebar1;
        private System.Windows.Forms.Label lblNotForProductionUse;
        private System.Windows.Forms.Label lblTestEdition;
        private System.Windows.Forms.Panel panelTest;
    }
}