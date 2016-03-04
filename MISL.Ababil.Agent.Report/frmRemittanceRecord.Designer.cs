namespace MISL.Ababil.Agent.Report
{
    partial class frmRemittanceRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemittanceRecord));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblSubAgent = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAgentName = new MetroFramework.Controls.MetroComboBox();
            this.cmbCompanyName = new MetroFramework.Controls.MetroComboBox();
            this.cmbSubAgnetName = new MetroFramework.Controls.MetroComboBox();
            this.cmbStatus = new MetroFramework.Controls.MetroComboBox();
            this.dtpToDatae = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.dtpFromDate = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(643, 202);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 13;
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
            this.btnViewReport.Location = new System.Drawing.Point(504, 202);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(127, 28);
            this.btnViewReport.TabIndex = 12;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblProduct.Location = new System.Drawing.Point(32, 136);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(121, 17);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Exchange house :";
            this.lblProduct.Click += new System.EventHandler(this.lblProduct_Click);
            // 
            // lblSubAgent
            // 
            this.lblSubAgent.AutoSize = true;
            this.lblSubAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblSubAgent.Location = new System.Drawing.Point(403, 105);
            this.lblSubAgent.Name = "lblSubAgent";
            this.lblSubAgent.Size = new System.Drawing.Size(83, 17);
            this.lblSubAgent.TabIndex = 2;
            this.lblSubAgent.Text = "Sub-Agent :";
            this.lblSubAgent.Click += new System.EventHandler(this.lblSubAgent_Click);
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblAgent.Location = new System.Drawing.Point(100, 104);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(53, 17);
            this.lblAgent.TabIndex = 0;
            this.lblAgent.Text = "Agent :";
            this.lblAgent.Click += new System.EventHandler(this.lblAgent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "From :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(453, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "To :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(430, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(300, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Remittance Report";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.ItemHeight = 19;
            this.cmbAgentName.Location = new System.Drawing.Point(158, 100);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.Size = new System.Drawing.Size(240, 25);
            this.cmbAgentName.TabIndex = 1;
            this.cmbAgentName.UseSelectable = true;
            this.cmbAgentName.SelectedIndexChanged += new System.EventHandler(this.cmbAgentName_SelectedIndexChanged);
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.ItemHeight = 19;
            this.cmbCompanyName.Location = new System.Drawing.Point(158, 133);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.Size = new System.Drawing.Size(240, 25);
            this.cmbCompanyName.TabIndex = 5;
            this.cmbCompanyName.UseSelectable = true;
            this.cmbCompanyName.SelectedIndexChanged += new System.EventHandler(this.cmbCompanyName_SelectedIndexChanged);
            // 
            // cmbSubAgnetName
            // 
            this.cmbSubAgnetName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbSubAgnetName.FormattingEnabled = true;
            this.cmbSubAgnetName.ItemHeight = 19;
            this.cmbSubAgnetName.Location = new System.Drawing.Point(492, 102);
            this.cmbSubAgnetName.Name = "cmbSubAgnetName";
            this.cmbSubAgnetName.Size = new System.Drawing.Size(226, 25);
            this.cmbSubAgnetName.TabIndex = 3;
            this.cmbSubAgnetName.UseSelectable = true;
            this.cmbSubAgnetName.SelectedIndexChanged += new System.EventHandler(this.cmbSubAgnetName_SelectedIndexChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.ItemHeight = 19;
            this.cmbStatus.Location = new System.Drawing.Point(492, 134);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(226, 25);
            this.cmbStatus.TabIndex = 7;
            this.cmbStatus.UseSelectable = true;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // dtpToDatae
            // 
            this.dtpToDatae.Date = "22/09/2015";
            this.dtpToDatae.Location = new System.Drawing.Point(492, 167);
            this.dtpToDatae.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpToDatae.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpToDatae.Name = "dtpToDatae";
            this.dtpToDatae.Size = new System.Drawing.Size(226, 25);
            this.dtpToDatae.TabIndex = 11;
            this.dtpToDatae.Value = new System.DateTime(2015, 9, 22, 14, 6, 29, 674);
            this.dtpToDatae.Load += new System.EventHandler(this.dtpToDatae_Load);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Date = "22/09/2015";
            this.dtpFromDate.Location = new System.Drawing.Point(158, 168);
            this.dtpFromDate.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpFromDate.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(240, 25);
            this.dtpFromDate.TabIndex = 9;
            this.dtpFromDate.Value = new System.DateTime(2015, 9, 22, 14, 5, 36, 349);
            this.dtpFromDate.Load += new System.EventHandler(this.dtpFromDate_Load);
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
            this.customTitlebar1.Size = new System.Drawing.Size(785, 26);
            this.customTitlebar1.TabIndex = 14;
            // 
            // frmRemittanceRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 252);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.dtpToDatae);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cmbSubAgnetName);
            this.Controls.Add(this.cmbCompanyName);
            this.Controls.Add(this.cmbAgentName);
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblSubAgent);
            this.Controls.Add(this.lblAgent);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRemittanceRecord";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Remittance Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRemittanceRecord_FormClosing);
            this.Load += new System.EventHandler(this.frmRemittanceRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblSubAgent;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private UI.forms.CustomControls.CustomTitlebar customTitlebar1;
        private MetroFramework.Controls.MetroComboBox cmbAgentName;
        private MetroFramework.Controls.MetroComboBox cmbCompanyName;
        private MetroFramework.Controls.MetroComboBox cmbSubAgnetName;
        private UI.forms.CustomControls.CustomDateTimePicker dtpToDatae;
        private UI.forms.CustomControls.CustomDateTimePicker dtpFromDate;
        private MetroFramework.Controls.MetroComboBox cmbStatus;

    }
}