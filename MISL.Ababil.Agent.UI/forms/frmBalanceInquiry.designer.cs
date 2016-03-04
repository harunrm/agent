namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmBalanceInquiry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBalanceInquiry));
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowBalance = new System.Windows.Forms.Button();
            this.lblConsumerTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.bio = new AxBIOPLUGINACTXLib.AxBioPlugInActX();
            this.pic_conusmer = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtConsumerAccount = new MetroFramework.Controls.MetroTextBox();
            this.lblInWords = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btshowAccountInfo = new System.Windows.Forms.Button();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            ((System.ComponentModel.ISupportInitialize)(this.bio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_conusmer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account :";
            // 
            // btnShowBalance
            // 
            this.btnShowBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnShowBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowBalance.ForeColor = System.Drawing.Color.White;
            this.btnShowBalance.Location = new System.Drawing.Point(476, 289);
            this.btnShowBalance.Name = "btnShowBalance";
            this.btnShowBalance.Size = new System.Drawing.Size(80, 29);
            this.btnShowBalance.TabIndex = 10;
            this.btnShowBalance.Text = "Clear";
            this.btnShowBalance.UseVisualStyleBackColor = false;
            this.btnShowBalance.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblConsumerTitle
            // 
            this.lblConsumerTitle.AutoSize = true;
            this.lblConsumerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumerTitle.Location = new System.Drawing.Point(153, 84);
            this.lblConsumerTitle.Name = "lblConsumerTitle";
            this.lblConsumerTitle.Size = new System.Drawing.Size(28, 16);
            this.lblConsumerTitle.TabIndex = 2;
            this.lblConsumerTitle.Text = "title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Consumer Title :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(573, 289);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 29);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bio
            // 
            this.bio.Enabled = true;
            this.bio.Location = new System.Drawing.Point(33, 208);
            this.bio.Name = "bio";
            this.bio.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("bio.OcxState")));
            this.bio.Size = new System.Drawing.Size(29, 12);
            this.bio.TabIndex = 0;
            this.bio.Visible = false;
            this.bio.OnCapture += new System.EventHandler(this.bio_OnCapture);
            // 
            // pic_conusmer
            // 
            this.pic_conusmer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_conusmer.Location = new System.Drawing.Point(20, 20);
            this.pic_conusmer.Name = "pic_conusmer";
            this.pic_conusmer.Size = new System.Drawing.Size(172, 207);
            this.pic_conusmer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_conusmer.TabIndex = 8;
            this.pic_conusmer.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bio);
            this.groupBox1.Controls.Add(this.pic_conusmer);
            this.groupBox1.Location = new System.Drawing.Point(456, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 244);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Photo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtConsumerAccount);
            this.groupBox2.Controls.Add(this.lblInWords);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btshowAccountInfo);
            this.groupBox2.Controls.Add(this.lblConsumerTitle);
            this.groupBox2.Controls.Add(this.lblMobileNo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblBalance);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(17, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 275);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consumer Information";
            // 
            // txtConsumerAccount
            // 
            this.txtConsumerAccount.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtConsumerAccount.Lines = new string[0];
            this.txtConsumerAccount.Location = new System.Drawing.Point(157, 30);
            this.txtConsumerAccount.MaxLength = 13;
            this.txtConsumerAccount.Name = "txtConsumerAccount";
            this.txtConsumerAccount.PasswordChar = '\0';
            this.txtConsumerAccount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConsumerAccount.SelectedText = "";
            this.txtConsumerAccount.Size = new System.Drawing.Size(223, 38);
            this.txtConsumerAccount.TabIndex = 0;
            this.txtConsumerAccount.UseSelectable = true;
            this.txtConsumerAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumerAccount_KeyPress);
            this.txtConsumerAccount.Leave += new System.EventHandler(this.txtConsumerAccount_Leave);
            // 
            // lblInWords
            // 
            this.lblInWords.Location = new System.Drawing.Point(154, 202);
            this.lblInWords.Name = "lblInWords";
            this.lblInWords.Size = new System.Drawing.Size(250, 61);
            this.lblInWords.TabIndex = 8;
            this.lblInWords.Text = "inWords";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "In Words :";
            // 
            // btshowAccountInfo
            // 
            this.btshowAccountInfo.Location = new System.Drawing.Point(379, 29);
            this.btshowAccountInfo.Name = "btshowAccountInfo";
            this.btshowAccountInfo.Size = new System.Drawing.Size(25, 40);
            this.btshowAccountInfo.TabIndex = 1;
            this.btshowAccountInfo.Text = "...";
            this.btshowAccountInfo.UseVisualStyleBackColor = true;
            this.btshowAccountInfo.Click += new System.EventHandler(this.btshowAccountInfo_Click);
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobileNo.Location = new System.Drawing.Point(154, 113);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(49, 16);
            this.lblMobileNo.TabIndex = 4;
            this.lblMobileNo.Text = "mobile";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Account Balance :";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(154, 174);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(64, 16);
            this.lblBalance.TabIndex = 6;
            this.lblBalance.Text = "balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mobile No :";
            // 
            // customTitlebar1
            // 
            this.customTitlebar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTitlebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.customTitlebar1.Location = new System.Drawing.Point(-2, 0);
            this.customTitlebar1.MinimumSize = new System.Drawing.Size(0, 26);
            this.customTitlebar1.Name = "customTitlebar1";
            this.customTitlebar1.OwnerForm = this;
            this.customTitlebar1.ShowTitle = true;
            this.customTitlebar1.Size = new System.Drawing.Size(691, 26);
            this.customTitlebar1.TabIndex = 12;
            // 
            // frmBalanceInquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 339);
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.btnShowBalance);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBalanceInquiry";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Balance Inquiry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBalanceInquiry_FormClosing);            
            ((System.ComponentModel.ISupportInitialize)(this.bio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_conusmer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowBalance;
        private System.Windows.Forms.Label lblConsumerTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private AxBIOPLUGINACTXLib.AxBioPlugInActX bio;
        private System.Windows.Forms.PictureBox pic_conusmer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.Button btshowAccountInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInWords;
        private MetroFramework.Controls.MetroTextBox txtConsumerAccount;
        private CustomControls.CustomTitlebar customTitlebar1;
    }
}