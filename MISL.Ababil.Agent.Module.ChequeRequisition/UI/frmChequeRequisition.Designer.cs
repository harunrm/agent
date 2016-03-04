namespace MISL.Ababil.Agent.Module.ChequeRequisition.UI
{
    partial class frmChequeRequisition
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
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.lblReferenceNumber = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.cmbUrgencyType = new System.Windows.Forms.ComboBox();
            this.lblUrgencyType = new System.Windows.Forms.Label();
            this.cmbDeliveryMedium = new System.Windows.Forms.ComboBox();
            this.lblDeliveryMedium = new System.Windows.Forms.Label();
            this.cmbDeliveryFrom = new System.Windows.Forms.ComboBox();
            this.lblDeliveryFrom = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCorrection = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnComment = new System.Windows.Forms.Button();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            this.btnPrepare = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReady = new System.Windows.Forms.Button();
            this.txtSerialFrom = new System.Windows.Forms.TextBox();
            this.txtSerialTo = new System.Windows.Forms.TextBox();
            this.lblSerialNumberFrom = new System.Windows.Forms.Label();
            this.lblSerialNumberTo = new System.Windows.Forms.Label();
            this.txtNumberOfLeaf = new System.Windows.Forms.TextBox();
            this.lblLeafNumber = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.Location = new System.Drawing.Point(196, 79);
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.ReadOnly = true;
            this.txtReferenceNumber.Size = new System.Drawing.Size(141, 20);
            this.txtReferenceNumber.TabIndex = 9;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(196, 112);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.ReadOnly = true;
            this.txtAccountNo.Size = new System.Drawing.Size(141, 20);
            this.txtAccountNo.TabIndex = 10;
            // 
            // lblReferenceNumber
            // 
            this.lblReferenceNumber.AutoSize = true;
            this.lblReferenceNumber.Location = new System.Drawing.Point(87, 82);
            this.lblReferenceNumber.Name = "lblReferenceNumber";
            this.lblReferenceNumber.Size = new System.Drawing.Size(103, 13);
            this.lblReferenceNumber.TabIndex = 7;
            this.lblReferenceNumber.Text = "Reference Number :";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(117, 115);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(73, 13);
            this.lblAccountNo.TabIndex = 8;
            this.lblAccountNo.Text = "Account No. :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(157, 149);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 13);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Title :";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(196, 146);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(315, 20);
            this.txtTitle.TabIndex = 10;
            // 
            // cmbUrgencyType
            // 
            this.cmbUrgencyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrgencyType.FormattingEnabled = true;
            this.cmbUrgencyType.Location = new System.Drawing.Point(196, 220);
            this.cmbUrgencyType.Name = "cmbUrgencyType";
            this.cmbUrgencyType.Size = new System.Drawing.Size(141, 21);
            this.cmbUrgencyType.TabIndex = 5;
            // 
            // lblUrgencyType
            // 
            this.lblUrgencyType.AutoSize = true;
            this.lblUrgencyType.Location = new System.Drawing.Point(110, 223);
            this.lblUrgencyType.Name = "lblUrgencyType";
            this.lblUrgencyType.Size = new System.Drawing.Size(80, 13);
            this.lblUrgencyType.TabIndex = 6;
            this.lblUrgencyType.Text = "Urgency Type :";
            // 
            // cmbDeliveryMedium
            // 
            this.cmbDeliveryMedium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryMedium.FormattingEnabled = true;
            this.cmbDeliveryMedium.Location = new System.Drawing.Point(196, 255);
            this.cmbDeliveryMedium.Name = "cmbDeliveryMedium";
            this.cmbDeliveryMedium.Size = new System.Drawing.Size(141, 21);
            this.cmbDeliveryMedium.TabIndex = 5;
            // 
            // lblDeliveryMedium
            // 
            this.lblDeliveryMedium.AutoSize = true;
            this.lblDeliveryMedium.Location = new System.Drawing.Point(99, 258);
            this.lblDeliveryMedium.Name = "lblDeliveryMedium";
            this.lblDeliveryMedium.Size = new System.Drawing.Size(91, 13);
            this.lblDeliveryMedium.TabIndex = 6;
            this.lblDeliveryMedium.Text = "Delivery Medium :";
            // 
            // cmbDeliveryFrom
            // 
            this.cmbDeliveryFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryFrom.FormattingEnabled = true;
            this.cmbDeliveryFrom.Location = new System.Drawing.Point(196, 290);
            this.cmbDeliveryFrom.Name = "cmbDeliveryFrom";
            this.cmbDeliveryFrom.Size = new System.Drawing.Size(315, 21);
            this.cmbDeliveryFrom.TabIndex = 5;
            // 
            // lblDeliveryFrom
            // 
            this.lblDeliveryFrom.AutoSize = true;
            this.lblDeliveryFrom.Location = new System.Drawing.Point(113, 293);
            this.lblDeliveryFrom.Name = "lblDeliveryFrom";
            this.lblDeliveryFrom.Size = new System.Drawing.Size(77, 13);
            this.lblDeliveryFrom.TabIndex = 6;
            this.lblDeliveryFrom.Text = "Delivery From :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(458, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 28);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCorrection
            // 
            this.btnCorrection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnCorrection.FlatAppearance.BorderSize = 0;
            this.btnCorrection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorrection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnCorrection.ForeColor = System.Drawing.Color.White;
            this.btnCorrection.Location = new System.Drawing.Point(370, 3);
            this.btnCorrection.Name = "btnCorrection";
            this.btnCorrection.Size = new System.Drawing.Size(82, 28);
            this.btnCorrection.TabIndex = 12;
            this.btnCorrection.Text = "C&orrection";
            this.btnCorrection.UseVisualStyleBackColor = false;
            this.btnCorrection.Visible = false;
            this.btnCorrection.Click += new System.EventHandler(this.btnCorrection_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(282, 3);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(82, 28);
            this.btnReject.TabIndex = 12;
            this.btnReject.Text = "&Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Visible = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(194, 3);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(82, 28);
            this.btnApprove.TabIndex = 12;
            this.btnApprove.Text = "&Accept";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Visible = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnComment
            // 
            this.btnComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnComment.FlatAppearance.BorderSize = 0;
            this.btnComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnComment.ForeColor = System.Drawing.Color.White;
            this.btnComment.Location = new System.Drawing.Point(23, 403);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(112, 28);
            this.btnComment.TabIndex = 12;
            this.btnComment.Text = "Co&mment (0)";
            this.btnComment.UseVisualStyleBackColor = false;
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
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
            this.customTitlebar1.Size = new System.Drawing.Size(707, 26);
            this.customTitlebar1.TabIndex = 11;
            // 
            // btnPrepare
            // 
            this.btnPrepare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnPrepare.FlatAppearance.BorderSize = 0;
            this.btnPrepare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrepare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPrepare.ForeColor = System.Drawing.Color.White;
            this.btnPrepare.Location = new System.Drawing.Point(106, 3);
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.Size = new System.Drawing.Size(82, 28);
            this.btnPrepare.TabIndex = 13;
            this.btnPrepare.Text = "&Prepare";
            this.btnPrepare.UseVisualStyleBackColor = false;
            this.btnPrepare.Visible = false;
            this.btnPrepare.Click += new System.EventHandler(this.btnPrepare_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnCorrection);
            this.flowLayoutPanel1.Controls.Add(this.btnReject);
            this.flowLayoutPanel1.Controls.Add(this.btnApprove);
            this.flowLayoutPanel1.Controls.Add(this.btnPrepare);
            this.flowLayoutPanel1.Controls.Add(this.btnReady);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(141, 401);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(543, 36);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // btnReady
            // 
            this.btnReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnReady.FlatAppearance.BorderSize = 0;
            this.btnReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnReady.ForeColor = System.Drawing.Color.White;
            this.btnReady.Location = new System.Drawing.Point(18, 3);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(82, 28);
            this.btnReady.TabIndex = 14;
            this.btnReady.Text = "&Receive";
            this.btnReady.UseVisualStyleBackColor = false;
            this.btnReady.Visible = false;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // txtSerialFrom
            // 
            this.txtSerialFrom.Location = new System.Drawing.Point(196, 325);
            this.txtSerialFrom.Name = "txtSerialFrom";
            this.txtSerialFrom.Size = new System.Drawing.Size(141, 20);
            this.txtSerialFrom.TabIndex = 17;
            this.txtSerialFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSerialFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericText_KeyPress);
            this.txtSerialFrom.Leave += new System.EventHandler(this.ChequeSerialNo_OnLeave);
            // 
            // txtSerialTo
            // 
            this.txtSerialTo.Location = new System.Drawing.Point(196, 358);
            this.txtSerialTo.Name = "txtSerialTo";
            this.txtSerialTo.Size = new System.Drawing.Size(141, 20);
            this.txtSerialTo.TabIndex = 18;
            this.txtSerialTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSerialTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericText_KeyPress);
            this.txtSerialTo.Leave += new System.EventHandler(this.ChequeSerialNo_OnLeave);
            // 
            // lblSerialNumberFrom
            // 
            this.lblSerialNumberFrom.AutoSize = true;
            this.lblSerialNumberFrom.Location = new System.Drawing.Point(105, 328);
            this.lblSerialNumberFrom.Name = "lblSerialNumberFrom";
            this.lblSerialNumberFrom.Size = new System.Drawing.Size(85, 13);
            this.lblSerialNumberFrom.TabIndex = 15;
            this.lblSerialNumberFrom.Text = "From Serial No. :";
            // 
            // lblSerialNumberTo
            // 
            this.lblSerialNumberTo.AutoSize = true;
            this.lblSerialNumberTo.Location = new System.Drawing.Point(115, 361);
            this.lblSerialNumberTo.Name = "lblSerialNumberTo";
            this.lblSerialNumberTo.Size = new System.Drawing.Size(75, 13);
            this.lblSerialNumberTo.TabIndex = 16;
            this.lblSerialNumberTo.Text = "To Serial No. :";
            // 
            // txtNumberOfLeaf
            // 
            this.txtNumberOfLeaf.Location = new System.Drawing.Point(196, 183);
            this.txtNumberOfLeaf.Name = "txtNumberOfLeaf";
            this.txtNumberOfLeaf.ReadOnly = true;
            this.txtNumberOfLeaf.Size = new System.Drawing.Size(141, 20);
            this.txtNumberOfLeaf.TabIndex = 20;
            this.txtNumberOfLeaf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLeafNumber
            // 
            this.lblLeafNumber.AutoSize = true;
            this.lblLeafNumber.Location = new System.Drawing.Point(124, 186);
            this.lblLeafNumber.Name = "lblLeafNumber";
            this.lblLeafNumber.Size = new System.Drawing.Size(66, 13);
            this.lblLeafNumber.TabIndex = 19;
            this.lblLeafNumber.Text = "No. of Leaf :";
            // 
            // frmChequeRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 455);
            this.Controls.Add(this.txtNumberOfLeaf);
            this.Controls.Add(this.lblLeafNumber);
            this.Controls.Add(this.txtSerialFrom);
            this.Controls.Add(this.txtSerialTo);
            this.Controls.Add(this.lblSerialNumberFrom);
            this.Controls.Add(this.lblSerialNumberTo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnComment);
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.txtReferenceNumber);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.lblDeliveryFrom);
            this.Controls.Add(this.lblDeliveryMedium);
            this.Controls.Add(this.lblUrgencyType);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblReferenceNumber);
            this.Controls.Add(this.lblAccountNo);
            this.Controls.Add(this.cmbDeliveryFrom);
            this.Controls.Add(this.cmbDeliveryMedium);
            this.Controls.Add(this.cmbUrgencyType);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChequeRequisition";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Cheque Requisition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChequeRequisition_FormClosing);
            this.Load += new System.EventHandler(this.frmChequeRequisition_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label lblReferenceNumber;
        private System.Windows.Forms.Label lblAccountNo;
        private Agent.UI.forms.CustomControls.CustomTitlebar customTitlebar1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUrgencyType;
        private System.Windows.Forms.ComboBox cmbUrgencyType;
        private System.Windows.Forms.Label lblDeliveryMedium;
        private System.Windows.Forms.ComboBox cmbDeliveryMedium;
        private System.Windows.Forms.Label lblDeliveryFrom;
        private System.Windows.Forms.ComboBox cmbDeliveryFrom;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnCorrection;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnComment;
        private System.Windows.Forms.Button btnPrepare;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtSerialFrom;
        private System.Windows.Forms.TextBox txtSerialTo;
        private System.Windows.Forms.Label lblSerialNumberFrom;
        private System.Windows.Forms.Label lblSerialNumberTo;
        private System.Windows.Forms.TextBox txtNumberOfLeaf;
        private System.Windows.Forms.Label lblLeafNumber;
        private System.Windows.Forms.Button btnReady;
    }
}