namespace MISL.Ababil.Agent.Report
{
    partial class frmAgentCashInformationReport
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
            this.cmbAgentName = new MetroFramework.Controls.MetroComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.dtpDate = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            this.SuspendLayout();
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.ItemHeight = 19;
            this.cmbAgentName.Location = new System.Drawing.Point(201, 91);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.Size = new System.Drawing.Size(239, 25);
            this.cmbAgentName.TabIndex = 13;
            this.cmbAgentName.UseSelectable = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(364, 172);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ForeColor = System.Drawing.Color.White;
            this.btnViewReport.Location = new System.Drawing.Point(225, 172);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(127, 33);
            this.btnViewReport.TabIndex = 20;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblFromDate.Location = new System.Drawing.Point(147, 132);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(46, 17);
            this.lblFromDate.TabIndex = 16;
            this.lblFromDate.Text = "Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(181, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Agent Cash Information Report";
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblAgent.Location = new System.Drawing.Point(101, 92);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(94, 17);
            this.lblAgent.TabIndex = 12;
            this.lblAgent.Text = "Agent Name :";
            // 
            // dtpDate
            // 
            this.dtpDate.Date = "22/09/2015";
            this.dtpDate.Location = new System.Drawing.Point(201, 128);
            this.dtpDate.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpDate.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(239, 25);
            this.dtpDate.TabIndex = 17;
            this.dtpDate.Value = new System.DateTime(2015, 9, 22, 12, 50, 47, 945);
            // 
            // customTitlebar1
            // 
            this.customTitlebar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTitlebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.customTitlebar1.Location = new System.Drawing.Point(-3, 0);
            this.customTitlebar1.MinimumSize = new System.Drawing.Size(0, 26);
            this.customTitlebar1.Name = "customTitlebar1";
            this.customTitlebar1.OwnerForm = this;
            this.customTitlebar1.ShowTitle = true;
            this.customTitlebar1.Size = new System.Drawing.Size(605, 26);
            this.customTitlebar1.TabIndex = 0;
            // 
            // frmAgentCashInformationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 238);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbAgentName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAgent);
            this.Controls.Add(this.customTitlebar1);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.Name = "frmAgentCashInformationReport";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Agent Cash Information Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.forms.CustomControls.CustomTitlebar customTitlebar1;
        private UI.forms.CustomControls.CustomDateTimePicker dtpDate;
        private MetroFramework.Controls.MetroComboBox cmbAgentName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAgent;
    }
}