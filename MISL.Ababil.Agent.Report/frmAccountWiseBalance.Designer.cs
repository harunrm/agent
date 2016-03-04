namespace MISL.Ababil.Agent.Report
{
    partial class frmAccountWiseBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountWiseBalance));
            this.lblSubAgent = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.rBtnDeposit = new System.Windows.Forms.RadioButton();
            this.rBtnInvestment = new System.Windows.Forms.RadioButton();
            this.rBtnITDMTD = new System.Windows.Forms.RadioButton();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            this.cmbAgentName = new MetroFramework.Controls.MetroComboBox();
            this.cmbSubAgnetName = new MetroFramework.Controls.MetroComboBox();
            this.cmbProduct = new MetroFramework.Controls.MetroComboBox();
            this.dtpToDate = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.rBtnMTD = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblSubAgent
            // 
            this.lblSubAgent.AutoSize = true;
            this.lblSubAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblSubAgent.Location = new System.Drawing.Point(369, 103);
            this.lblSubAgent.Name = "lblSubAgent";
            this.lblSubAgent.Size = new System.Drawing.Size(83, 17);
            this.lblSubAgent.TabIndex = 2;
            this.lblSubAgent.Text = "Sub-Agent :";
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblAgent.Location = new System.Drawing.Point(71, 103);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(53, 17);
            this.lblAgent.TabIndex = 0;
            this.lblAgent.Text = "Agent :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(600, 238);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 31);
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
            this.btnViewReport.Location = new System.Drawing.Point(461, 238);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(127, 31);
            this.btnViewReport.TabIndex = 12;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblProduct.Location = new System.Drawing.Point(58, 183);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(65, 17);
            this.lblProduct.TabIndex = 8;
            this.lblProduct.Text = "Product :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(77, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(631, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Account Balance As on Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblProductType.Location = new System.Drawing.Point(25, 141);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(101, 17);
            this.lblProductType.TabIndex = 4;
            this.lblProductType.Text = "Product Type :";
            // 
            // rBtnDeposit
            // 
            this.rBtnDeposit.AutoSize = true;
            this.rBtnDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.rBtnDeposit.Location = new System.Drawing.Point(140, 139);
            this.rBtnDeposit.Name = "rBtnDeposit";
            this.rBtnDeposit.Size = new System.Drawing.Size(74, 21);
            this.rBtnDeposit.TabIndex = 5;
            this.rBtnDeposit.Text = "Deposit";
            this.rBtnDeposit.UseVisualStyleBackColor = true;
            this.rBtnDeposit.CheckedChanged += new System.EventHandler(this.rBtnDeposit_CheckedChanged);
            // 
            // rBtnInvestment
            // 
            this.rBtnInvestment.AutoSize = true;
            this.rBtnInvestment.Enabled = false;
            this.rBtnInvestment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.rBtnInvestment.Location = new System.Drawing.Point(226, 139);
            this.rBtnInvestment.Name = "rBtnInvestment";
            this.rBtnInvestment.Size = new System.Drawing.Size(94, 21);
            this.rBtnInvestment.TabIndex = 6;
            this.rBtnInvestment.Text = "Investment";
            this.rBtnInvestment.UseVisualStyleBackColor = true;
            // 
            // rBtnITDMTD
            // 
            this.rBtnITDMTD.AutoSize = true;
            this.rBtnITDMTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.rBtnITDMTD.Location = new System.Drawing.Point(332, 139);
            this.rBtnITDMTD.Name = "rBtnITDMTD";
            this.rBtnITDMTD.Size = new System.Drawing.Size(48, 21);
            this.rBtnITDMTD.TabIndex = 7;
            this.rBtnITDMTD.Text = "ITD";
            this.rBtnITDMTD.UseVisualStyleBackColor = true;
            this.rBtnITDMTD.CheckedChanged += new System.EventHandler(this.rBtnITDMTD_CheckedChanged);
            // 
            // customTitlebar1
            // 
            this.customTitlebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.customTitlebar1.Location = new System.Drawing.Point(-1, 0);
            this.customTitlebar1.MinimumSize = new System.Drawing.Size(0, 26);
            this.customTitlebar1.Name = "customTitlebar1";
            this.customTitlebar1.OwnerForm = this;
            this.customTitlebar1.ShowTitle = true;
            this.customTitlebar1.Size = new System.Drawing.Size(727, 26);
            this.customTitlebar1.TabIndex = 14;
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.ItemHeight = 19;
            this.cmbAgentName.Location = new System.Drawing.Point(127, 100);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.Size = new System.Drawing.Size(236, 25);
            this.cmbAgentName.TabIndex = 1;
            this.cmbAgentName.UseSelectable = true;
            this.cmbAgentName.SelectedIndexChanged += new System.EventHandler(this.cmbAgentName_SelectedIndexChanged);
            // 
            // cmbSubAgnetName
            // 
            this.cmbSubAgnetName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbSubAgnetName.FormattingEnabled = true;
            this.cmbSubAgnetName.ItemHeight = 19;
            this.cmbSubAgnetName.Location = new System.Drawing.Point(455, 102);
            this.cmbSubAgnetName.Name = "cmbSubAgnetName";
            this.cmbSubAgnetName.Size = new System.Drawing.Size(229, 25);
            this.cmbSubAgnetName.TabIndex = 3;
            this.cmbSubAgnetName.UseSelectable = true;
            // 
            // cmbProduct
            // 
            this.cmbProduct.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.ItemHeight = 19;
            this.cmbProduct.Location = new System.Drawing.Point(127, 180);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(557, 25);
            this.cmbProduct.TabIndex = 9;
            this.cmbProduct.UseSelectable = true;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Date = "21/09/2015";
            this.dtpToDate.Location = new System.Drawing.Point(127, 218);
            this.dtpToDate.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpToDate.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(236, 25);
            this.dtpToDate.TabIndex = 11;
            this.dtpToDate.Value = new System.DateTime(2015, 9, 21, 16, 28, 40, 16);
            // 
            // rBtnMTD
            // 
            this.rBtnMTD.AutoSize = true;
            this.rBtnMTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.rBtnMTD.Location = new System.Drawing.Point(390, 139);
            this.rBtnMTD.Name = "rBtnMTD";
            this.rBtnMTD.Size = new System.Drawing.Size(56, 21);
            this.rBtnMTD.TabIndex = 16;
            this.rBtnMTD.Text = "MTD";
            this.rBtnMTD.UseVisualStyleBackColor = true;
            this.rBtnMTD.CheckedChanged += new System.EventHandler(this.rBtnMTD_CheckedChanged);
            // 
            // frmAccountWiseBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 300);
            this.Controls.Add(this.rBtnMTD);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.cmbSubAgnetName);
            this.Controls.Add(this.cmbAgentName);
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.rBtnITDMTD);
            this.Controls.Add(this.rBtnInvestment);
            this.Controls.Add(this.rBtnDeposit);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblSubAgent);
            this.Controls.Add(this.lblAgent);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAccountWiseBalance";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.ShowInTaskbar = false;
            this.Text = "Account Wise Balance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountWiseBalance_FormClosing);
            this.Load += new System.EventHandler(this.frmAccountWiseBalance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSubAgent;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.RadioButton rBtnDeposit;
        private System.Windows.Forms.RadioButton rBtnInvestment;
        private System.Windows.Forms.RadioButton rBtnITDMTD;
        private UI.forms.CustomControls.CustomTitlebar customTitlebar1;
        private MetroFramework.Controls.MetroComboBox cmbProduct;
        private MetroFramework.Controls.MetroComboBox cmbSubAgnetName;
        private MetroFramework.Controls.MetroComboBox cmbAgentName;
        private UI.forms.CustomControls.CustomDateTimePicker dtpToDate;
        private System.Windows.Forms.RadioButton rBtnMTD;
    }
}