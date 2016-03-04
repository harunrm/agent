namespace MISL.Ababil.Agent.Report
{
    partial class frmBillPaymentReport
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
            this.cmbSubAgnetName = new MetroFramework.Controls.MetroComboBox();
            this.cmbServiceProvider = new MetroFramework.Controls.MetroComboBox();
            this.cmbAgentName = new MetroFramework.Controls.MetroComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblSubAgent = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBillNumber = new MetroFramework.Controls.MetroTextBox();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            this.dtpToDatae = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.dtpFromDate = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.SuspendLayout();
            // 
            // cmbSubAgnetName
            // 
            this.cmbSubAgnetName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbSubAgnetName.FormattingEnabled = true;
            this.cmbSubAgnetName.ItemHeight = 19;
            this.cmbSubAgnetName.Location = new System.Drawing.Point(536, 114);
            this.cmbSubAgnetName.Name = "cmbSubAgnetName";
            this.cmbSubAgnetName.Size = new System.Drawing.Size(226, 25);
            this.cmbSubAgnetName.TabIndex = 19;
            this.cmbSubAgnetName.UseSelectable = true;
            // 
            // cmbServiceProvider
            // 
            this.cmbServiceProvider.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbServiceProvider.FormattingEnabled = true;
            this.cmbServiceProvider.ItemHeight = 19;
            this.cmbServiceProvider.Location = new System.Drawing.Point(192, 145);
            this.cmbServiceProvider.Name = "cmbServiceProvider";
            this.cmbServiceProvider.Size = new System.Drawing.Size(240, 25);
            this.cmbServiceProvider.TabIndex = 21;
            this.cmbServiceProvider.UseSelectable = true;
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.ItemHeight = 19;
            this.cmbAgentName.Location = new System.Drawing.Point(192, 112);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.Size = new System.Drawing.Size(240, 25);
            this.cmbAgentName.TabIndex = 17;
            this.cmbAgentName.UseSelectable = true;
            this.cmbAgentName.SelectedIndexChanged += new System.EventHandler(this.cmbAgentName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(338, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Bill Payment Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(500, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "To :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "From :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(686, 214);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 29;
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
            this.btnViewReport.Location = new System.Drawing.Point(547, 214);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(127, 28);
            this.btnViewReport.TabIndex = 28;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblProduct.Location = new System.Drawing.Point(66, 148);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(120, 17);
            this.lblProduct.TabIndex = 20;
            this.lblProduct.Text = "Service Provider :";
            // 
            // lblSubAgent
            // 
            this.lblSubAgent.AutoSize = true;
            this.lblSubAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblSubAgent.Location = new System.Drawing.Point(450, 117);
            this.lblSubAgent.Name = "lblSubAgent";
            this.lblSubAgent.Size = new System.Drawing.Size(83, 17);
            this.lblSubAgent.TabIndex = 18;
            this.lblSubAgent.Text = "Sub-Agent :";
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblAgent.Location = new System.Drawing.Point(134, 116);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(53, 17);
            this.lblAgent.TabIndex = 16;
            this.lblAgent.Text = "Agent :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(445, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Bill Number :";
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Lines = new string[0];
            this.txtBillNumber.Location = new System.Drawing.Point(536, 147);
            this.txtBillNumber.MaxLength = 32767;
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.PasswordChar = '\0';
            this.txtBillNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBillNumber.SelectedText = "";
            this.txtBillNumber.Size = new System.Drawing.Size(226, 25);
            this.txtBillNumber.TabIndex = 0;
            this.txtBillNumber.UseSelectable = true;
            // 
            // customTitlebar1
            // 
            this.customTitlebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.customTitlebar1.Location = new System.Drawing.Point(-1, -1);
            this.customTitlebar1.MinimumSize = new System.Drawing.Size(0, 26);
            this.customTitlebar1.Name = "customTitlebar1";
            this.customTitlebar1.OwnerForm = this;
            this.customTitlebar1.ShowTitle = true;
            this.customTitlebar1.Size = new System.Drawing.Size(856, 26);
            this.customTitlebar1.TabIndex = 31;
            // 
            // dtpToDatae
            // 
            this.dtpToDatae.Date = "22/09/2015";
            this.dtpToDatae.Location = new System.Drawing.Point(536, 179);
            this.dtpToDatae.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpToDatae.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpToDatae.Name = "dtpToDatae";
            this.dtpToDatae.Size = new System.Drawing.Size(226, 25);
            this.dtpToDatae.TabIndex = 27;
            this.dtpToDatae.Value = new System.DateTime(2015, 9, 22, 14, 6, 29, 674);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Date = "22/09/2015";
            this.dtpFromDate.Location = new System.Drawing.Point(192, 180);
            this.dtpFromDate.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpFromDate.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(240, 25);
            this.dtpFromDate.TabIndex = 25;
            this.dtpFromDate.Value = new System.DateTime(2015, 9, 22, 14, 5, 36, 349);
            // 
            // frmBillPaymentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 275);
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.txtBillNumber);
            this.Controls.Add(this.dtpToDatae);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cmbSubAgnetName);
            this.Controls.Add(this.cmbServiceProvider);
            this.Controls.Add(this.cmbAgentName);
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
            this.Name = "frmBillPaymentReport";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Bill Payment Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBillPaymentReport_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.forms.CustomControls.CustomDateTimePicker dtpToDatae;
        private UI.forms.CustomControls.CustomDateTimePicker dtpFromDate;
        private MetroFramework.Controls.MetroComboBox cmbSubAgnetName;
        private MetroFramework.Controls.MetroComboBox cmbServiceProvider;
        private MetroFramework.Controls.MetroComboBox cmbAgentName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblSubAgent;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroTextBox txtBillNumber;
        private UI.forms.CustomControls.CustomTitlebar customTitlebar1;
    }
}