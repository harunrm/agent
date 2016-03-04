namespace MISL.Ababil.Agent.Report
{
    partial class frmCashRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashRegister));
            this.lblSubAgent = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            this.cmbAgentName = new MetroFramework.Controls.MetroComboBox();
            this.cmbSubAgnetName = new MetroFramework.Controls.MetroComboBox();
            this.cmbUser = new MetroFramework.Controls.MetroComboBox();
            this.dtpDateFrom = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.dtpDateTo = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.SuspendLayout();
            // 
            // lblSubAgent
            // 
            this.lblSubAgent.AutoSize = true;
            this.lblSubAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubAgent.Location = new System.Drawing.Point(342, 123);
            this.lblSubAgent.Name = "lblSubAgent";
            this.lblSubAgent.Size = new System.Drawing.Size(77, 16);
            this.lblSubAgent.TabIndex = 2;
            this.lblSubAgent.Text = "Sub-Agent :";
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgent.Location = new System.Drawing.Point(63, 122);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(49, 16);
            this.lblAgent.TabIndex = 0;
            this.lblAgent.Text = "Agent :";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(571, 207);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 31);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(120, 115);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 13);
            this.lblUserName.TabIndex = 14;
            // 
            // btnShowReport
            // 
            this.btnShowReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowReport.ForeColor = System.Drawing.Color.White;
            this.btnShowReport.Location = new System.Drawing.Point(436, 207);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(127, 31);
            this.btnShowReport.TabIndex = 8;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = false;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "User Name :";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(390, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "To :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "From Date  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(230, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Agent Cash Register";
            // 
            // customTitlebar1
            // 
            this.customTitlebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.customTitlebar1.Location = new System.Drawing.Point(-1, 0);
            this.customTitlebar1.MinimumSize = new System.Drawing.Size(0, 26);
            this.customTitlebar1.Name = "customTitlebar1";
            this.customTitlebar1.OwnerForm = this;
            this.customTitlebar1.ShowTitle = true;
            this.customTitlebar1.Size = new System.Drawing.Size(723, 26);
            this.customTitlebar1.TabIndex = 12;
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.ItemHeight = 19;
            this.cmbAgentName.Location = new System.Drawing.Point(116, 120);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.Size = new System.Drawing.Size(204, 25);
            this.cmbAgentName.TabIndex = 1;
            this.cmbAgentName.UseSelectable = true;
            this.cmbAgentName.SelectedIndexChanged += new System.EventHandler(this.cmbAgentName_SelectedIndexChanged);
            // 
            // cmbSubAgnetName
            // 
            this.cmbSubAgnetName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbSubAgnetName.FormattingEnabled = true;
            this.cmbSubAgnetName.ItemHeight = 19;
            this.cmbSubAgnetName.Location = new System.Drawing.Point(422, 123);
            this.cmbSubAgnetName.Name = "cmbSubAgnetName";
            this.cmbSubAgnetName.Size = new System.Drawing.Size(231, 25);
            this.cmbSubAgnetName.TabIndex = 3;
            this.cmbSubAgnetName.UseSelectable = true;
            // 
            // cmbUser
            // 
            this.cmbUser.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.ItemHeight = 19;
            this.cmbUser.Location = new System.Drawing.Point(116, 197);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(204, 25);
            this.cmbUser.TabIndex = 11;
            this.cmbUser.UseSelectable = true;
            this.cmbUser.Visible = false;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Date = "22/09/2015";
            this.dtpDateFrom.Location = new System.Drawing.Point(116, 157);
            this.dtpDateFrom.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpDateFrom.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(204, 25);
            this.dtpDateFrom.TabIndex = 5;
            this.dtpDateFrom.Value = new System.DateTime(2015, 9, 22, 13, 35, 25, 868);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Date = "22/09/2015";
            this.dtpDateTo.Location = new System.Drawing.Point(422, 162);
            this.dtpDateTo.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpDateTo.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(231, 25);
            this.dtpDateTo.TabIndex = 7;
            this.dtpDateTo.Value = new System.DateTime(2015, 9, 22, 13, 51, 14, 484);
            // 
            // frmCashRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 274);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.cmbSubAgnetName);
            this.Controls.Add(this.cmbAgentName);
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSubAgent);
            this.Controls.Add(this.lblAgent);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCashRegister";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Cash Register";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCashRegister_FormClosing);
            this.Load += new System.EventHandler(this.frmCashRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSubAgent;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private UI.forms.CustomControls.CustomTitlebar customTitlebar1;
        private MetroFramework.Controls.MetroComboBox cmbUser;
        private MetroFramework.Controls.MetroComboBox cmbSubAgnetName;
        private MetroFramework.Controls.MetroComboBox cmbAgentName;
        private UI.forms.CustomControls.CustomDateTimePicker dtpDateFrom;
        private UI.forms.CustomControls.CustomDateTimePicker dtpDateTo;
    }
}