namespace MISL.Ababil.Agent.Module.Security.UI.FingerprintUI
{
    partial class frmFingerprintChangeRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFingerprintChangeRequest));
            this.btnClear = new System.Windows.Forms.Button();
            this.gbxAuthentication = new System.Windows.Forms.GroupBox();
            this.lblRequiredFingerPrint = new System.Windows.Forms.Label();
            this.fingerPrintGrid = new System.Windows.Forms.DataGridView();
            this.gbxAccountInfo = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConsumerAccount = new System.Windows.Forms.TextBox();
            this.photo = new System.Windows.Forms.GroupBox();
            this.pic_conusmer = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.lblConsumerTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.bio = new AxBIOPLUGINACTXLib.AxBioPlugInActX();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            this.gbxAuthentication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fingerPrintGrid)).BeginInit();
            this.gbxAccountInfo.SuspendLayout();
            this.photo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_conusmer)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(356, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(82, 29);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // gbxAuthentication
            // 
            this.gbxAuthentication.Controls.Add(this.lblRequiredFingerPrint);
            this.gbxAuthentication.Controls.Add(this.fingerPrintGrid);
            this.gbxAuthentication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAuthentication.Location = new System.Drawing.Point(12, 218);
            this.gbxAuthentication.Name = "gbxAuthentication";
            this.gbxAuthentication.Size = new System.Drawing.Size(666, 263);
            this.gbxAuthentication.TabIndex = 10;
            this.gbxAuthentication.TabStop = false;
            this.gbxAuthentication.Tag = "12, 313";
            this.gbxAuthentication.Text = "New Capture Information";
            // 
            // lblRequiredFingerPrint
            // 
            this.lblRequiredFingerPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRequiredFingerPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequiredFingerPrint.Location = new System.Drawing.Point(276, 10);
            this.lblRequiredFingerPrint.Name = "lblRequiredFingerPrint";
            this.lblRequiredFingerPrint.Size = new System.Drawing.Size(379, 15);
            this.lblRequiredFingerPrint.TabIndex = 0;
            this.lblRequiredFingerPrint.Text = "msg";
            this.lblRequiredFingerPrint.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fingerPrintGrid
            // 
            this.fingerPrintGrid.AllowUserToAddRows = false;
            this.fingerPrintGrid.AllowUserToDeleteRows = false;
            this.fingerPrintGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fingerPrintGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fingerPrintGrid.Location = new System.Drawing.Point(12, 29);
            this.fingerPrintGrid.Name = "fingerPrintGrid";
            this.fingerPrintGrid.RowHeadersVisible = false;
            this.fingerPrintGrid.Size = new System.Drawing.Size(643, 222);
            this.fingerPrintGrid.TabIndex = 4;
            this.fingerPrintGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fingerPrintGrid_CellContentClick);
            // 
            // gbxAccountInfo
            // 
            this.gbxAccountInfo.Controls.Add(this.label4);
            this.gbxAccountInfo.Controls.Add(this.txtConsumerAccount);
            this.gbxAccountInfo.Controls.Add(this.photo);
            this.gbxAccountInfo.Controls.Add(this.label3);
            this.gbxAccountInfo.Controls.Add(this.label1);
            this.gbxAccountInfo.Controls.Add(this.lblMobileNo);
            this.gbxAccountInfo.Controls.Add(this.lblConsumerTitle);
            this.gbxAccountInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAccountInfo.Location = new System.Drawing.Point(12, 35);
            this.gbxAccountInfo.Name = "gbxAccountInfo";
            this.gbxAccountInfo.Size = new System.Drawing.Size(666, 177);
            this.gbxAccountInfo.TabIndex = 8;
            this.gbxAccountInfo.TabStop = false;
            this.gbxAccountInfo.Text = "Account Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 120);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mobile No :";
            // 
            // txtConsumerAccount
            // 
            this.txtConsumerAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumerAccount.Location = new System.Drawing.Point(168, 35);
            this.txtConsumerAccount.MaxLength = 13;
            this.txtConsumerAccount.Name = "txtConsumerAccount";
            this.txtConsumerAccount.Size = new System.Drawing.Size(342, 38);
            this.txtConsumerAccount.TabIndex = 1;
            this.txtConsumerAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumerAccount_KeyPress);
            this.txtConsumerAccount.Leave += new System.EventHandler(this.txtConsumerAccount_Leave);
            // 
            // photo
            // 
            this.photo.Controls.Add(this.pic_conusmer);
            this.photo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photo.Location = new System.Drawing.Point(523, 14);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(131, 153);
            this.photo.TabIndex = 9;
            this.photo.TabStop = false;
            this.photo.Text = "Photo";
            // 
            // pic_conusmer
            // 
            this.pic_conusmer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_conusmer.Location = new System.Drawing.Point(11, 21);
            this.pic_conusmer.Name = "pic_conusmer";
            this.pic_conusmer.Size = new System.Drawing.Size(109, 121);
            this.pic_conusmer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_conusmer.TabIndex = 5;
            this.pic_conusmer.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Account Title :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account No. :";
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobileNo.Location = new System.Drawing.Point(168, 120);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMobileNo.Size = new System.Drawing.Size(90, 18);
            this.lblMobileNo.TabIndex = 5;
            this.lblMobileNo.Text = "lbvMobileNo";
            // 
            // lblConsumerTitle
            // 
            this.lblConsumerTitle.AutoSize = true;
            this.lblConsumerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumerTitle.Location = new System.Drawing.Point(168, 84);
            this.lblConsumerTitle.Name = "lblConsumerTitle";
            this.lblConsumerTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblConsumerTitle.Size = new System.Drawing.Size(123, 18);
            this.lblConsumerTitle.TabIndex = 3;
            this.lblConsumerTitle.Text = "lbvConsumerTitle";
            this.lblConsumerTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(444, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 29);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(250, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 29);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnClear);
            this.flowLayoutPanel1.Controls.Add(this.btnApply);
            this.flowLayoutPanel1.Controls.Add(this.btnReject);
            this.flowLayoutPanel1.Controls.Add(this.btnApprove);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(147, 491);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(529, 36);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // btnApprove
            // 
            this.btnApprove.Enabled = false;
            this.btnApprove.Location = new System.Drawing.Point(38, 3);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 29);
            this.btnApprove.TabIndex = 14;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Visible = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Enabled = false;
            this.btnReject.Location = new System.Drawing.Point(144, 3);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(100, 29);
            this.btnReject.TabIndex = 15;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Visible = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // bio
            // 
            this.bio.Enabled = true;
            this.bio.Location = new System.Drawing.Point(27, 494);
            this.bio.Name = "bio";
            this.bio.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("bio.OcxState")));
            this.bio.Size = new System.Drawing.Size(100, 50);
            this.bio.TabIndex = 5;
            this.bio.Visible = false;
            this.bio.OnCapture += new System.EventHandler(this.bio_OnCapture_AgreeAndSubmit);
            // 
            // customTitlebar1
            // 
            this.customTitlebar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTitlebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.customTitlebar1.Location = new System.Drawing.Point(0, 0);
            this.customTitlebar1.MinimumSize = new System.Drawing.Size(0, 26);
            this.customTitlebar1.Name = "customTitlebar1";
            this.customTitlebar1.OwnerForm = this;
            this.customTitlebar1.ShowTitle = true;
            this.customTitlebar1.Size = new System.Drawing.Size(691, 26);
            this.customTitlebar1.TabIndex = 14;
            // 
            // frmFingerprintChangeRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 547);
            this.Controls.Add(this.bio);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.gbxAuthentication);
            this.Controls.Add(this.gbxAccountInfo);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.Name = "frmFingerprintChangeRequest";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Fingerprint Request";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChequeRequisition_FormClosing);
            this.Load += new System.EventHandler(this.frmChequeRequisition_Load);
            this.gbxAuthentication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fingerPrintGrid)).EndInit();
            this.gbxAccountInfo.ResumeLayout(false);
            this.gbxAccountInfo.PerformLayout();
            this.photo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_conusmer)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbxAuthentication;
        private System.Windows.Forms.Label lblRequiredFingerPrint;
        private System.Windows.Forms.DataGridView fingerPrintGrid;
        private System.Windows.Forms.GroupBox gbxAccountInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConsumerAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.Label lblConsumerTitle;
        private System.Windows.Forms.GroupBox photo;
        private System.Windows.Forms.PictureBox pic_conusmer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private Agent.UI.forms.CustomControls.CustomTitlebar customTitlebar1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnApprove;
        private AxBIOPLUGINACTXLib.AxBioPlugInActX bio;
        private System.Windows.Forms.Button btnReject;
    }
}