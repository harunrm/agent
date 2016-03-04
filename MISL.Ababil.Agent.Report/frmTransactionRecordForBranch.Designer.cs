namespace MISL.Ababil.Agent.Report
{
    partial class frmTransactionRecordForBranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactionRecordForBranch));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.mtbDateFrom = new System.Windows.Forms.MaskedTextBox();
            this.mtbDateTo = new System.Windows.Forms.MaskedTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbSubAgnetName = new System.Windows.Forms.ComboBox();
            this.cmbAgentName = new System.Windows.Forms.ComboBox();
            this.lblSubAgent = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date Range :";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "";
            this.dtpDateFrom.Location = new System.Drawing.Point(270, 115);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(20, 20);
            this.dtpDateFrom.TabIndex = 10;
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "To";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(619, 112);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(20, 20);
            this.dtpDateTo.TabIndex = 12;
            this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpDateTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "User Name :";
            this.label3.Visible = false;
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(317, 166);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(125, 23);
            this.btnShowReport.TabIndex = 14;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(90, 85);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 13);
            this.lblUserName.TabIndex = 15;
            // 
            // cmbUser
            // 
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(90, 85);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(200, 21);
            this.cmbUser.TabIndex = 16;
            this.cmbUser.Visible = false;
            // 
            // mtbDateFrom
            // 
            this.mtbDateFrom.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbDateFrom.Location = new System.Drawing.Point(90, 115);
            this.mtbDateFrom.Mask = "00-00-0000";
            this.mtbDateFrom.Name = "mtbDateFrom";
            this.mtbDateFrom.Size = new System.Drawing.Size(181, 20);
            this.mtbDateFrom.TabIndex = 17;
            this.mtbDateFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbDateFrom_KeyUp);
            // 
            // mtbDateTo
            // 
            this.mtbDateTo.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbDateTo.Location = new System.Drawing.Point(412, 112);
            this.mtbDateTo.Mask = "00-00-0000";
            this.mtbDateTo.Name = "mtbDateTo";
            this.mtbDateTo.Size = new System.Drawing.Size(208, 20);
            this.mtbDateTo.TabIndex = 18;
            this.mtbDateTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbDateTo_KeyUp);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(448, 166);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 23);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbSubAgnetName
            // 
            this.cmbSubAgnetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubAgnetName.FormattingEnabled = true;
            this.cmbSubAgnetName.Location = new System.Drawing.Point(412, 37);
            this.cmbSubAgnetName.Name = "cmbSubAgnetName";
            this.cmbSubAgnetName.Size = new System.Drawing.Size(231, 21);
            this.cmbSubAgnetName.TabIndex = 22;
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.Location = new System.Drawing.Point(86, 37);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.Size = new System.Drawing.Size(204, 21);
            this.cmbAgentName.TabIndex = 23;
            this.cmbAgentName.SelectedIndexChanged += new System.EventHandler(this.cmbAgentName_SelectedIndexChanged);
            // 
            // lblSubAgent
            // 
            this.lblSubAgent.AutoSize = true;
            this.lblSubAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblSubAgent.Location = new System.Drawing.Point(326, 38);
            this.lblSubAgent.Name = "lblSubAgent";
            this.lblSubAgent.Size = new System.Drawing.Size(83, 17);
            this.lblSubAgent.TabIndex = 21;
            this.lblSubAgent.Text = "Sub-Agent :";
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblAgent.Location = new System.Drawing.Point(20, 37);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(53, 17);
            this.lblAgent.TabIndex = 20;
            this.lblAgent.Text = "Agent :";
            // 
            // frmTransactionRecordForBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 258);
            this.Controls.Add(this.cmbSubAgnetName);
            this.Controls.Add(this.cmbAgentName);
            this.Controls.Add(this.lblSubAgent);
            this.Controls.Add(this.lblAgent);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.mtbDateTo);
            this.Controls.Add(this.mtbDateFrom);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTransactionRecordForBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Record";
            this.Load += new System.EventHandler(this.frmTransactionRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.MaskedTextBox mtbDateFrom;
        private System.Windows.Forms.MaskedTextBox mtbDateTo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbSubAgnetName;
        private System.Windows.Forms.ComboBox cmbAgentName;
        private System.Windows.Forms.Label lblSubAgent;
        private System.Windows.Forms.Label lblAgent;
    }
}