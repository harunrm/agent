﻿namespace MISL.Ababil.Agent.Report
{
    partial class frmTrMonitoringRport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrMonitoringRport));
            this.lblAgent = new System.Windows.Forms.Label();
            this.lblSubAgent = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblTodate = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAgentName = new MetroFramework.Controls.MetroComboBox();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            this.cmbSubAgnetName = new MetroFramework.Controls.MetroComboBox();
            this.dtpFromDate = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.dtpToDate = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.SuspendLayout();
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblAgent.Location = new System.Drawing.Point(39, 107);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(53, 17);
            this.lblAgent.TabIndex = 0;
            this.lblAgent.Text = "Agent :";
            // 
            // lblSubAgent
            // 
            this.lblSubAgent.AutoSize = true;
            this.lblSubAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblSubAgent.Location = new System.Drawing.Point(335, 107);
            this.lblSubAgent.Name = "lblSubAgent";
            this.lblSubAgent.Size = new System.Drawing.Size(83, 17);
            this.lblSubAgent.TabIndex = 2;
            this.lblSubAgent.Text = "Sub-Agent :";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblFromDate.Location = new System.Drawing.Point(43, 147);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(48, 17);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From :";
            // 
            // lblTodate
            // 
            this.lblTodate.AutoSize = true;
            this.lblTodate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblTodate.Location = new System.Drawing.Point(385, 141);
            this.lblTodate.Name = "lblTodate";
            this.lblTodate.Size = new System.Drawing.Size(33, 17);
            this.lblTodate.TabIndex = 6;
            this.lblTodate.Text = "To :";
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ForeColor = System.Drawing.Color.White;
            this.btnViewReport.Location = new System.Drawing.Point(431, 183);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(127, 28);
            this.btnViewReport.TabIndex = 8;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(570, 183);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Transaction Monitoring Report";
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.ItemHeight = 19;
            this.cmbAgentName.Location = new System.Drawing.Point(95, 105);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.Size = new System.Drawing.Size(239, 25);
            this.cmbAgentName.TabIndex = 1;
            this.cmbAgentName.UseSelectable = true;
            this.cmbAgentName.SelectedIndexChanged += new System.EventHandler(this.cmbAgentName_SelectedIndexChanged);
            // 
            // customTitlebar1
            // 
            this.customTitlebar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTitlebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.customTitlebar1.Location = new System.Drawing.Point(-1, 0);
            this.customTitlebar1.MinimumSize = new System.Drawing.Size(0, 26);
            this.customTitlebar1.Name = "customTitlebar1";
            this.customTitlebar1.OwnerForm = this;
            this.customTitlebar1.ShowTitle = true;
            this.customTitlebar1.Size = new System.Drawing.Size(697, 26);
            this.customTitlebar1.TabIndex = 10;
            // 
            // cmbSubAgnetName
            // 
            this.cmbSubAgnetName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbSubAgnetName.FormattingEnabled = true;
            this.cmbSubAgnetName.ItemHeight = 19;
            this.cmbSubAgnetName.Location = new System.Drawing.Point(421, 105);
            this.cmbSubAgnetName.Name = "cmbSubAgnetName";
            this.cmbSubAgnetName.Size = new System.Drawing.Size(229, 25);
            this.cmbSubAgnetName.TabIndex = 3;
            this.cmbSubAgnetName.UseSelectable = true;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Date = "22/09/2015";
            this.dtpFromDate.Location = new System.Drawing.Point(95, 146);
            this.dtpFromDate.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpFromDate.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(239, 25);
            this.dtpFromDate.TabIndex = 5;
            this.dtpFromDate.Value = new System.DateTime(2015, 9, 22, 14, 52, 5, 693);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Date = "22/09/2015";
            this.dtpToDate.Location = new System.Drawing.Point(421, 138);
            this.dtpToDate.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpToDate.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(229, 25);
            this.dtpToDate.TabIndex = 7;
            this.dtpToDate.Value = new System.DateTime(2015, 9, 22, 14, 52, 53, 838);
            // 
            // frmTrMonitoringRport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 239);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cmbSubAgnetName);
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.cmbAgentName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.lblTodate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.lblSubAgent);
            this.Controls.Add(this.lblAgent);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrMonitoringRport";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Transaction Monitoring Report";
            this.Load += new System.EventHandler(this.frmTrMonitoringRport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.Label lblSubAgent;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblTodate;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox cmbAgentName;
        private UI.forms.CustomControls.CustomTitlebar customTitlebar1;
        private MetroFramework.Controls.MetroComboBox cmbSubAgnetName;
        private UI.forms.CustomControls.CustomDateTimePicker dtpToDate;
        private UI.forms.CustomControls.CustomDateTimePicker dtpFromDate;
    }
}