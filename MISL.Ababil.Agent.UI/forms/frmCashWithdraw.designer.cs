using System.ComponentModel;
using System.Drawing.Design;
namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmCashWithdraw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashWithdraw));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.txtConsumerAccount = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pic_conusmer = new System.Windows.Forms.PictureBox();
            this.fingerPrintGrid = new System.Windows.Forms.DataGridView();
            this.photo = new System.Windows.Forms.GroupBox();
            this.bio = new AxBIOPLUGINACTXLib.AxBioPlugInActX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtrTotal = new System.Windows.Forms.TextBox();
            this.txtrCharge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBalanceValue = new System.Windows.Forms.Label();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.lblInWords = new System.Windows.Forms.Label();
            this.lblConsumerTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRequiredFingerPrint = new System.Windows.Forms.Label();
            this.btClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_conusmer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerPrintGrid)).BeginInit();
            this.photo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bio)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Amount :";
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWithdraw.Location = new System.Drawing.Point(443, 511);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(75, 23);
            this.btnWithdraw.TabIndex = 5;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // txtConsumerAccount
            // 
            this.txtConsumerAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumerAccount.Location = new System.Drawing.Point(134, 23);
            this.txtConsumerAccount.MaxLength = 13;
            this.txtConsumerAccount.Name = "txtConsumerAccount";
            this.txtConsumerAccount.Size = new System.Drawing.Size(296, 38);
            this.txtConsumerAccount.TabIndex = 1;
            this.txtConsumerAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumerAccount_KeyPress);
            this.txtConsumerAccount.Leave += new System.EventHandler(this.txtConsumerAccount_Leave);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(134, 150);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(296, 31);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(603, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pic_conusmer
            // 
            this.pic_conusmer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_conusmer.Location = new System.Drawing.Point(11, 23);
            this.pic_conusmer.Name = "pic_conusmer";
            this.pic_conusmer.Size = new System.Drawing.Size(189, 211);
            this.pic_conusmer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_conusmer.TabIndex = 5;
            this.pic_conusmer.TabStop = false;
            // 
            // fingerPrintGrid
            // 
            this.fingerPrintGrid.AllowUserToDeleteRows = false;
            this.fingerPrintGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fingerPrintGrid.Location = new System.Drawing.Point(12, 35);
            this.fingerPrintGrid.Name = "fingerPrintGrid";
            this.fingerPrintGrid.ReadOnly = true;
            this.fingerPrintGrid.Size = new System.Drawing.Size(643, 109);
            this.fingerPrintGrid.TabIndex = 4;
            this.fingerPrintGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fingerPrintGrid_CellContentClick);
            // 
            // photo
            // 
            this.photo.Controls.Add(this.bio);
            this.photo.Controls.Add(this.pic_conusmer);
            this.photo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photo.Location = new System.Drawing.Point(466, 7);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(211, 334);
            this.photo.TabIndex = 2;
            this.photo.TabStop = false;
            this.photo.Text = "Photo";
            // 
            // bio
            // 
            this.bio.Enabled = true;
            this.bio.Location = new System.Drawing.Point(79, 179);
            this.bio.Name = "bio";
            this.bio.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("bio.OcxState")));
            this.bio.Size = new System.Drawing.Size(17, 17);
            this.bio.TabIndex = 0;
            this.bio.Visible = false;
            this.bio.OnCapture += new System.EventHandler(this.bio_OnCapture);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtrTotal);
            this.groupBox1.Controls.Add(this.txtrCharge);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.lblBalance);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtConsumerAccount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblBalanceValue);
            this.groupBox1.Controls.Add(this.lblMobileNo);
            this.groupBox1.Controls.Add(this.lblInWords);
            this.groupBox1.Controls.Add(this.lblConsumerTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 334);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction Information";
            // 
            // txtrTotal
            // 
            this.txtrTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrTotal.Location = new System.Drawing.Point(134, 223);
            this.txtrTotal.MaxLength = 10;
            this.txtrTotal.Name = "txtrTotal";
            this.txtrTotal.ReadOnly = true;
            this.txtrTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtrTotal.Size = new System.Drawing.Size(296, 35);
            this.txtrTotal.TabIndex = 11;
            this.txtrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtrTotal.TextChanged += new System.EventHandler(this.txtrTotal_TextChanged);
            // 
            // txtrCharge
            // 
            this.txtrCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrCharge.Location = new System.Drawing.Point(134, 187);
            this.txtrCharge.MaxLength = 10;
            this.txtrCharge.Name = "txtrCharge";
            this.txtrCharge.ReadOnly = true;
            this.txtrCharge.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtrCharge.Size = new System.Drawing.Size(296, 29);
            this.txtrCharge.TabIndex = 9;
            this.txtrCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtrCharge.TextChanged += new System.EventHandler(this.txtrCharge_TextChanged);
            this.txtrCharge.Leave += new System.EventHandler(this.txtrCharge_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Charge :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total :";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(48, 120);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBalance.Size = new System.Drawing.Size(78, 18);
            this.lblBalance.TabIndex = 4;
            this.lblBalance.Text = "Balance :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 95);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mobile No :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(59, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "In Words :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Consumer Title :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBalanceValue
            // 
            this.lblBalanceValue.AutoSize = true;
            this.lblBalanceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceValue.Location = new System.Drawing.Point(134, 120);
            this.lblBalanceValue.Name = "lblBalanceValue";
            this.lblBalanceValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBalanceValue.Size = new System.Drawing.Size(126, 18);
            this.lblBalanceValue.TabIndex = 5;
            this.lblBalanceValue.Text = "lblBalanceValue";
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobileNo.Location = new System.Drawing.Point(134, 95);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMobileNo.Size = new System.Drawing.Size(85, 16);
            this.lblMobileNo.TabIndex = 5;
            this.lblMobileNo.Text = "lbvMobileNo";
            // 
            // lblInWords
            // 
            this.lblInWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInWords.Location = new System.Drawing.Point(134, 270);
            this.lblInWords.Name = "lblInWords";
            this.lblInWords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInWords.Size = new System.Drawing.Size(296, 50);
            this.lblInWords.TabIndex = 3;
            this.lblInWords.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblConsumerTitle
            // 
            this.lblConsumerTitle.AutoSize = true;
            this.lblConsumerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumerTitle.Location = new System.Drawing.Point(134, 70);
            this.lblConsumerTitle.Name = "lblConsumerTitle";
            this.lblConsumerTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblConsumerTitle.Size = new System.Drawing.Size(113, 16);
            this.lblConsumerTitle.TabIndex = 3;
            this.lblConsumerTitle.Text = "lbvConsumerTitle";
            this.lblConsumerTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRequiredFingerPrint);
            this.groupBox2.Controls.Add(this.fingerPrintGrid);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 347);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(666, 156);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Finger Print Information";
            // 
            // lblRequiredFingerPrint
            // 
            this.lblRequiredFingerPrint.AutoSize = true;
            this.lblRequiredFingerPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequiredFingerPrint.Location = new System.Drawing.Point(378, 16);
            this.lblRequiredFingerPrint.Name = "lblRequiredFingerPrint";
            this.lblRequiredFingerPrint.Size = new System.Drawing.Size(41, 15);
            this.lblRequiredFingerPrint.TabIndex = 0;
            this.lblRequiredFingerPrint.Text = "label5";
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.Location = new System.Drawing.Point(523, 511);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 6;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // frmCashWithdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 545);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.photo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCashWithdraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Withdraw";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCashWithdraw_FormClosing);
            this.Load += new System.EventHandler(this.frmCashWithdraw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_conusmer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerPrintGrid)).EndInit();
            this.photo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bio)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.TextBox txtConsumerAccount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnClose;
        private AxBIOPLUGINACTXLib.AxBioPlugInActX bio;
        private System.Windows.Forms.PictureBox pic_conusmer;
        private System.Windows.Forms.DataGridView fingerPrintGrid;
        private System.Windows.Forms.GroupBox photo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblConsumerTitle;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRequiredFingerPrint;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.TextBox txtrTotal;
        private System.Windows.Forms.TextBox txtrCharge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblInWords;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblBalanceValue;
    }
}