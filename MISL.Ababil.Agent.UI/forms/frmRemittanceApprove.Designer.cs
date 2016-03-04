namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmRemittanceApprove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemittanceApprove));
            this.txtAgentName = new System.Windows.Forms.TextBox();
            this.lblAgentName = new System.Windows.Forms.Label();
            this.lblExchangeHouseName = new System.Windows.Forms.Label();
            this.lblOutletName = new System.Windows.Forms.Label();
            this.txtOutletName = new System.Windows.Forms.TextBox();
            this.lblACNo = new System.Windows.Forms.Label();
            this.txtACNo = new System.Windows.Forms.TextBox();
            this.lblExpectedAmount = new System.Windows.Forms.Label();
            this.txtExpectedAmount = new System.Windows.Forms.TextBox();
            this.lblCorrectionAmount = new System.Windows.Forms.Label();
            this.txtCorrectionAmount = new System.Windows.Forms.TextBox();
            this.btnRequestDetails = new System.Windows.Forms.Button();
            this.gbxCorrection = new System.Windows.Forms.GroupBox();
            this.rdobtnNeedCorrection = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.rdobtnReject = new System.Windows.Forms.RadioButton();
            this.rdobtnApproveSave = new System.Windows.Forms.RadioButton();
            this.btnSendToSecondApprover = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbxRequest = new System.Windows.Forms.GroupBox();
            this.lblExpectedAmountInWords = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCorrectedAmountInWords = new System.Windows.Forms.Label();
            this.lblCorrectedAmountInWords2 = new System.Windows.Forms.Label();
            this.txtRefranceNumber = new System.Windows.Forms.TextBox();
            this.txtExchangeHouseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblApprover = new System.Windows.Forms.Label();
            this.btnDocuments = new System.Windows.Forms.Button();
            this.gbxCorrection.SuspendLayout();
            this.gbxRequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAgentName
            // 
            this.txtAgentName.Location = new System.Drawing.Point(141, 45);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.ReadOnly = true;
            this.txtAgentName.Size = new System.Drawing.Size(226, 20);
            this.txtAgentName.TabIndex = 3;
            // 
            // lblAgentName
            // 
            this.lblAgentName.AutoSize = true;
            this.lblAgentName.Location = new System.Drawing.Point(64, 48);
            this.lblAgentName.Name = "lblAgentName";
            this.lblAgentName.Size = new System.Drawing.Size(72, 13);
            this.lblAgentName.TabIndex = 2;
            this.lblAgentName.Text = "Agent Name :";
            // 
            // lblExchangeHouseName
            // 
            this.lblExchangeHouseName.AutoSize = true;
            this.lblExchangeHouseName.Location = new System.Drawing.Point(10, 74);
            this.lblExchangeHouseName.Name = "lblExchangeHouseName";
            this.lblExchangeHouseName.Size = new System.Drawing.Size(126, 13);
            this.lblExchangeHouseName.TabIndex = 4;
            this.lblExchangeHouseName.Text = "Exchange House Name :";
            // 
            // lblOutletName
            // 
            this.lblOutletName.AutoSize = true;
            this.lblOutletName.Location = new System.Drawing.Point(415, 48);
            this.lblOutletName.Name = "lblOutletName";
            this.lblOutletName.Size = new System.Drawing.Size(72, 13);
            this.lblOutletName.TabIndex = 8;
            this.lblOutletName.Text = "Outlet Name :";
            // 
            // txtOutletName
            // 
            this.txtOutletName.Location = new System.Drawing.Point(493, 45);
            this.txtOutletName.Name = "txtOutletName";
            this.txtOutletName.ReadOnly = true;
            this.txtOutletName.Size = new System.Drawing.Size(226, 20);
            this.txtOutletName.TabIndex = 9;
            // 
            // lblACNo
            // 
            this.lblACNo.AutoSize = true;
            this.lblACNo.Location = new System.Drawing.Point(438, 75);
            this.lblACNo.Name = "lblACNo";
            this.lblACNo.Size = new System.Drawing.Size(49, 13);
            this.lblACNo.TabIndex = 10;
            this.lblACNo.Text = "A/C No :";
            // 
            // txtACNo
            // 
            this.txtACNo.Location = new System.Drawing.Point(493, 72);
            this.txtACNo.Name = "txtACNo";
            this.txtACNo.ReadOnly = true;
            this.txtACNo.Size = new System.Drawing.Size(226, 20);
            this.txtACNo.TabIndex = 11;
            // 
            // lblExpectedAmount
            // 
            this.lblExpectedAmount.AutoSize = true;
            this.lblExpectedAmount.Location = new System.Drawing.Point(39, 101);
            this.lblExpectedAmount.Name = "lblExpectedAmount";
            this.lblExpectedAmount.Size = new System.Drawing.Size(97, 13);
            this.lblExpectedAmount.TabIndex = 6;
            this.lblExpectedAmount.Text = "Expected Amount :";
            // 
            // txtExpectedAmount
            // 
            this.txtExpectedAmount.Location = new System.Drawing.Point(141, 98);
            this.txtExpectedAmount.Name = "txtExpectedAmount";
            this.txtExpectedAmount.ReadOnly = true;
            this.txtExpectedAmount.Size = new System.Drawing.Size(226, 20);
            this.txtExpectedAmount.TabIndex = 7;
            this.txtExpectedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCorrectionAmount
            // 
            this.lblCorrectionAmount.AutoSize = true;
            this.lblCorrectionAmount.Location = new System.Drawing.Point(387, 101);
            this.lblCorrectionAmount.Name = "lblCorrectionAmount";
            this.lblCorrectionAmount.Size = new System.Drawing.Size(100, 13);
            this.lblCorrectionAmount.TabIndex = 12;
            this.lblCorrectionAmount.Text = "Correction Amount :";
            // 
            // txtCorrectionAmount
            // 
            this.txtCorrectionAmount.Location = new System.Drawing.Point(493, 98);
            this.txtCorrectionAmount.Name = "txtCorrectionAmount";
            this.txtCorrectionAmount.Size = new System.Drawing.Size(226, 20);
            this.txtCorrectionAmount.TabIndex = 13;
            this.txtCorrectionAmount.Text = "0";
            this.txtCorrectionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCorrectionAmount.TextChanged += new System.EventHandler(this.txtCorrectionAmount_TextChanged);
            this.txtCorrectionAmount.Leave += new System.EventHandler(this.txtCorrectionAmount_Leave);
            // 
            // btnRequestDetails
            // 
            this.btnRequestDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestDetails.Location = new System.Drawing.Point(589, 185);
            this.btnRequestDetails.Name = "btnRequestDetails";
            this.btnRequestDetails.Size = new System.Drawing.Size(130, 23);
            this.btnRequestDetails.TabIndex = 14;
            this.btnRequestDetails.Text = "Request &Details";
            this.btnRequestDetails.UseVisualStyleBackColor = true;
            this.btnRequestDetails.Click += new System.EventHandler(this.btnRequestDetails_Click);
            // 
            // gbxCorrection
            // 
            this.gbxCorrection.Controls.Add(this.rdobtnNeedCorrection);
            this.gbxCorrection.Controls.Add(this.label7);
            this.gbxCorrection.Controls.Add(this.txtComments);
            this.gbxCorrection.Controls.Add(this.rdobtnReject);
            this.gbxCorrection.Controls.Add(this.rdobtnApproveSave);
            this.gbxCorrection.Location = new System.Drawing.Point(14, 279);
            this.gbxCorrection.Name = "gbxCorrection";
            this.gbxCorrection.Size = new System.Drawing.Size(732, 126);
            this.gbxCorrection.TabIndex = 2;
            this.gbxCorrection.TabStop = false;
            this.gbxCorrection.Text = "Correction";
            // 
            // rdobtnNeedCorrection
            // 
            this.rdobtnNeedCorrection.AutoSize = true;
            this.rdobtnNeedCorrection.Location = new System.Drawing.Point(27, 23);
            this.rdobtnNeedCorrection.Name = "rdobtnNeedCorrection";
            this.rdobtnNeedCorrection.Size = new System.Drawing.Size(102, 17);
            this.rdobtnNeedCorrection.TabIndex = 0;
            this.rdobtnNeedCorrection.TabStop = true;
            this.rdobtnNeedCorrection.Text = "&Need Correction";
            this.rdobtnNeedCorrection.UseVisualStyleBackColor = true;
            this.rdobtnNeedCorrection.CheckedChanged += new System.EventHandler(this.rdobtnNeedCorrection_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Correction Notes :";
            // 
            // txtComments
            // 
            this.txtComments.Enabled = false;
            this.txtComments.Location = new System.Drawing.Point(141, 46);
            this.txtComments.MaxLength = 200;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(578, 20);
            this.txtComments.TabIndex = 2;
            // 
            // rdobtnReject
            // 
            this.rdobtnReject.AutoSize = true;
            this.rdobtnReject.Location = new System.Drawing.Point(27, 76);
            this.rdobtnReject.Name = "rdobtnReject";
            this.rdobtnReject.Size = new System.Drawing.Size(56, 17);
            this.rdobtnReject.TabIndex = 3;
            this.rdobtnReject.TabStop = true;
            this.rdobtnReject.Text = "&Reject";
            this.rdobtnReject.UseVisualStyleBackColor = true;
            // 
            // rdobtnApproveSave
            // 
            this.rdobtnApproveSave.AutoSize = true;
            this.rdobtnApproveSave.Checked = true;
            this.rdobtnApproveSave.Location = new System.Drawing.Point(27, 99);
            this.rdobtnApproveSave.Name = "rdobtnApproveSave";
            this.rdobtnApproveSave.Size = new System.Drawing.Size(95, 17);
            this.rdobtnApproveSave.TabIndex = 4;
            this.rdobtnApproveSave.TabStop = true;
            this.rdobtnApproveSave.Text = "&Approve/Save";
            this.rdobtnApproveSave.UseVisualStyleBackColor = true;
            // 
            // btnSendToSecondApprover
            // 
            this.btnSendToSecondApprover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendToSecondApprover.Location = new System.Drawing.Point(565, 415);
            this.btnSendToSecondApprover.Name = "btnSendToSecondApprover";
            this.btnSendToSecondApprover.Size = new System.Drawing.Size(100, 26);
            this.btnSendToSecondApprover.TabIndex = 3;
            this.btnSendToSecondApprover.Text = "Process";
            this.btnSendToSecondApprover.UseVisualStyleBackColor = true;
            this.btnSendToSecondApprover.Click += new System.EventHandler(this.btnSendToSecondApprover_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(671, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbxRequest
            // 
            this.gbxRequest.Controls.Add(this.lblExpectedAmountInWords);
            this.gbxRequest.Controls.Add(this.btnRequestDetails);
            this.gbxRequest.Controls.Add(this.label11);
            this.gbxRequest.Controls.Add(this.txtACNo);
            this.gbxRequest.Controls.Add(this.lblCorrectedAmountInWords);
            this.gbxRequest.Controls.Add(this.lblCorrectedAmountInWords2);
            this.gbxRequest.Controls.Add(this.txtOutletName);
            this.gbxRequest.Controls.Add(this.lblACNo);
            this.gbxRequest.Controls.Add(this.txtCorrectionAmount);
            this.gbxRequest.Controls.Add(this.txtRefranceNumber);
            this.gbxRequest.Controls.Add(this.txtExpectedAmount);
            this.gbxRequest.Controls.Add(this.txtExchangeHouseName);
            this.gbxRequest.Controls.Add(this.txtAgentName);
            this.gbxRequest.Controls.Add(this.lblCorrectionAmount);
            this.gbxRequest.Controls.Add(this.label1);
            this.gbxRequest.Controls.Add(this.lblOutletName);
            this.gbxRequest.Controls.Add(this.lblExpectedAmount);
            this.gbxRequest.Controls.Add(this.lblAgentName);
            this.gbxRequest.Controls.Add(this.lblExchangeHouseName);
            this.gbxRequest.Location = new System.Drawing.Point(14, 51);
            this.gbxRequest.Name = "gbxRequest";
            this.gbxRequest.Size = new System.Drawing.Size(732, 221);
            this.gbxRequest.TabIndex = 1;
            this.gbxRequest.TabStop = false;
            this.gbxRequest.Text = "Request";
            // 
            // lblExpectedAmountInWords
            // 
            this.lblExpectedAmountInWords.Location = new System.Drawing.Point(141, 124);
            this.lblExpectedAmountInWords.Name = "lblExpectedAmountInWords";
            this.lblExpectedAmountInWords.Size = new System.Drawing.Size(226, 54);
            this.lblExpectedAmountInWords.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(38, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 53);
            this.label11.TabIndex = 11;
            this.label11.Text = "Expected Amount In Words :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCorrectedAmountInWords
            // 
            this.lblCorrectedAmountInWords.Location = new System.Drawing.Point(493, 124);
            this.lblCorrectedAmountInWords.Name = "lblCorrectedAmountInWords";
            this.lblCorrectedAmountInWords.Size = new System.Drawing.Size(226, 54);
            this.lblCorrectedAmountInWords.TabIndex = 12;
            // 
            // lblCorrectedAmountInWords2
            // 
            this.lblCorrectedAmountInWords2.Location = new System.Drawing.Point(390, 125);
            this.lblCorrectedAmountInWords2.Name = "lblCorrectedAmountInWords2";
            this.lblCorrectedAmountInWords2.Size = new System.Drawing.Size(98, 53);
            this.lblCorrectedAmountInWords2.TabIndex = 13;
            this.lblCorrectedAmountInWords2.Text = "Corrected Amount In Words :";
            this.lblCorrectedAmountInWords2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRefranceNumber
            // 
            this.txtRefranceNumber.Location = new System.Drawing.Point(141, 19);
            this.txtRefranceNumber.Name = "txtRefranceNumber";
            this.txtRefranceNumber.ReadOnly = true;
            this.txtRefranceNumber.Size = new System.Drawing.Size(226, 20);
            this.txtRefranceNumber.TabIndex = 1;
            // 
            // txtExchangeHouseName
            // 
            this.txtExchangeHouseName.Location = new System.Drawing.Point(141, 71);
            this.txtExchangeHouseName.Name = "txtExchangeHouseName";
            this.txtExchangeHouseName.ReadOnly = true;
            this.txtExchangeHouseName.Size = new System.Drawing.Size(226, 20);
            this.txtExchangeHouseName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reference Number :";
            // 
            // lblApprover
            // 
            this.lblApprover.AutoSize = true;
            this.lblApprover.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApprover.Location = new System.Drawing.Point(15, 16);
            this.lblApprover.Name = "lblApprover";
            this.lblApprover.Size = new System.Drawing.Size(38, 20);
            this.lblApprover.TabIndex = 0;
            this.lblApprover.Text = "Title";
            // 
            // btnDocuments
            // 
            this.btnDocuments.Enabled = false;
            this.btnDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocuments.Location = new System.Drawing.Point(14, 415);
            this.btnDocuments.Name = "btnDocuments";
            this.btnDocuments.Size = new System.Drawing.Size(95, 26);
            this.btnDocuments.TabIndex = 5;
            this.btnDocuments.Text = "Documents";
            this.btnDocuments.UseVisualStyleBackColor = true;
            this.btnDocuments.Click += new System.EventHandler(this.btnDocuments_Click);
            // 
            // frmRemittanceApprove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 453);
            this.Controls.Add(this.btnDocuments);
            this.Controls.Add(this.lblApprover);
            this.Controls.Add(this.gbxRequest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSendToSecondApprover);
            this.Controls.Add(this.gbxCorrection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRemittanceApprove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remittance Request";
            this.Load += new System.EventHandler(this.frmRemittanceFirstApproval_Load);
            this.gbxCorrection.ResumeLayout(false);
            this.gbxCorrection.PerformLayout();
            this.gbxRequest.ResumeLayout(false);
            this.gbxRequest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAgentName;
        private System.Windows.Forms.Label lblAgentName;
        private System.Windows.Forms.Label lblExchangeHouseName;
        private System.Windows.Forms.Label lblOutletName;
        private System.Windows.Forms.TextBox txtOutletName;
        private System.Windows.Forms.Label lblACNo;
        private System.Windows.Forms.TextBox txtACNo;
        private System.Windows.Forms.Label lblExpectedAmount;
        private System.Windows.Forms.TextBox txtExpectedAmount;
        private System.Windows.Forms.Label lblCorrectionAmount;
        private System.Windows.Forms.TextBox txtCorrectionAmount;
        private System.Windows.Forms.Button btnRequestDetails;
        private System.Windows.Forms.GroupBox gbxCorrection;
        private System.Windows.Forms.RadioButton rdobtnApproveSave;
        private System.Windows.Forms.RadioButton rdobtnReject;
        private System.Windows.Forms.RadioButton rdobtnNeedCorrection;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSendToSecondApprover;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbxRequest;
        private System.Windows.Forms.TextBox txtExchangeHouseName;
        private System.Windows.Forms.TextBox txtRefranceNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblApprover;
        private System.Windows.Forms.Button btnDocuments;
        private System.Windows.Forms.Label lblExpectedAmountInWords;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCorrectedAmountInWords;
        private System.Windows.Forms.Label lblCorrectedAmountInWords2;
    }
}