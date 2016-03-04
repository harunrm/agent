namespace MISL.Ababil.Agent.UI.Forms
{
    partial class frmAccountStatement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountStatement));
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.gpbAccountStatementInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.mtbTo = new System.Windows.Forms.MaskedTextBox();
            this.mtbFrom = new System.Windows.Forms.MaskedTextBox();
            this.lbltName = new System.Windows.Forms.Label();
            this.gpbAccountStatementInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.Location = new System.Drawing.Point(13, 30);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(96, 13);
            this.lblAccountNumber.TabIndex = 0;
            this.lblAccountNumber.Text = "Account Number. :";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(113, 27);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(147, 20);
            this.txtAccountNo.TabIndex = 1;
            this.txtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountNo_KeyPress);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(73, 75);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(36, 13);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From :";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(263, 75);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(26, 13);
            this.lblToDate.TabIndex = 7;
            this.lblToDate.Text = "To :";
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(316, 118);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(123, 23);
            this.btnShowReport.TabIndex = 12;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(292, 25);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(147, 23);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // gpbAccountStatementInfo
            // 
            this.gpbAccountStatementInfo.Controls.Add(this.label1);
            this.gpbAccountStatementInfo.Controls.Add(this.label2);
            this.gpbAccountStatementInfo.Controls.Add(this.dateTimePicker1);
            this.gpbAccountStatementInfo.Controls.Add(this.dateTimePicker2);
            this.gpbAccountStatementInfo.Controls.Add(this.mtbTo);
            this.gpbAccountStatementInfo.Controls.Add(this.mtbFrom);
            this.gpbAccountStatementInfo.Controls.Add(this.lbltName);
            this.gpbAccountStatementInfo.Controls.Add(this.btnShow);
            this.gpbAccountStatementInfo.Controls.Add(this.btnShowReport);
            this.gpbAccountStatementInfo.Controls.Add(this.lblToDate);
            this.gpbAccountStatementInfo.Controls.Add(this.lblFromDate);
            this.gpbAccountStatementInfo.Controls.Add(this.txtAccountNo);
            this.gpbAccountStatementInfo.Controls.Add(this.lblAccountNumber);
            this.gpbAccountStatementInfo.Location = new System.Drawing.Point(11, 12);
            this.gpbAccountStatementInfo.Name = "gpbAccountStatementInfo";
            this.gpbAccountStatementInfo.Size = new System.Drawing.Size(452, 152);
            this.gpbAccountStatementInfo.TabIndex = 0;
            this.gpbAccountStatementInfo.TabStop = false;
            this.gpbAccountStatementInfo.Text = "Account Statement Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(293, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "dd-MM-yyyy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(114, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "dd-MM-yyyy";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(240, 72);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(20, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(419, 72);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(20, 20);
            this.dateTimePicker2.TabIndex = 9;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // mtbTo
            // 
            this.mtbTo.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbTo.Location = new System.Drawing.Point(292, 72);
            this.mtbTo.Mask = "00-00-0000";
            this.mtbTo.Name = "mtbTo";
            this.mtbTo.Size = new System.Drawing.Size(128, 20);
            this.mtbTo.TabIndex = 8;
            this.mtbTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbTo_KeyUp);
            // 
            // mtbFrom
            // 
            this.mtbFrom.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbFrom.Location = new System.Drawing.Point(113, 72);
            this.mtbFrom.Mask = "00-00-0000";
            this.mtbFrom.Name = "mtbFrom";
            this.mtbFrom.Size = new System.Drawing.Size(128, 20);
            this.mtbFrom.TabIndex = 5;
            this.mtbFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbFrom_KeyUp);
            // 
            // lbltName
            // 
            this.lbltName.AutoSize = true;
            this.lbltName.Location = new System.Drawing.Point(68, 52);
            this.lbltName.Name = "lbltName";
            this.lbltName.Size = new System.Drawing.Size(41, 13);
            this.lbltName.TabIndex = 3;
            this.lbltName.Text = "Name :";
            // 
            // frmAccountStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 174);
            this.Controls.Add(this.gpbAccountStatementInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccountStatement";
            this.Text = "Account Statement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountStatement_FormClosing);
            this.Load += new System.EventHandler(this.frmAccountStatement_Load);
            this.gpbAccountStatementInfo.ResumeLayout(false);
            this.gpbAccountStatementInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.GroupBox gpbAccountStatementInfo;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lbltName;
        private System.Windows.Forms.MaskedTextBox mtbTo;
        private System.Windows.Forms.MaskedTextBox mtbFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}