namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmSSPRequestSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSSPRequestSearch));
            this.lblDepositAccountNumber = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblDepositAccountTitle = new System.Windows.Forms.Label();
            this.lblSSPAccountType = new System.Windows.Forms.Label();
            this.lblSSPAccountStatus = new System.Windows.Forms.Label();
            this.lblReferenceNo = new System.Windows.Forms.Label();
            this.dgvSearchResult = new System.Windows.Forms.DataGridView();
            this.lblReferenceNumber = new System.Windows.Forms.Label();
            this.lblReferenceNoDisplay = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtReferenceNumber = new MetroFramework.Controls.MetroTextBox();
            this.txtDepositAccountNumber = new MetroFramework.Controls.MetroTextBox();
            this.txtDepositAccountTitle = new MetroFramework.Controls.MetroTextBox();
            this.cmbSSPAccountStatus = new MetroFramework.Controls.MetroComboBox();
            this.cmbSSPAccountType = new MetroFramework.Controls.MetroComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDepositAccountNumber
            // 
            this.lblDepositAccountNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDepositAccountNumber.AutoSize = true;
            this.lblDepositAccountNumber.Location = new System.Drawing.Point(12, 82);
            this.lblDepositAccountNumber.Name = "lblDepositAccountNumber";
            this.lblDepositAccountNumber.Size = new System.Drawing.Size(132, 13);
            this.lblDepositAccountNumber.TabIndex = 4;
            this.lblDepositAccountNumber.Text = "Deposit Account Number :";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(13, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(138, 29);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(13, 62);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(138, 29);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblDepositAccountTitle
            // 
            this.lblDepositAccountTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDepositAccountTitle.AutoSize = true;
            this.lblDepositAccountTitle.Location = new System.Drawing.Point(29, 54);
            this.lblDepositAccountTitle.Name = "lblDepositAccountTitle";
            this.lblDepositAccountTitle.Size = new System.Drawing.Size(115, 13);
            this.lblDepositAccountTitle.TabIndex = 2;
            this.lblDepositAccountTitle.Text = "Deposit Account Title :";
            // 
            // lblSSPAccountType
            // 
            this.lblSSPAccountType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSSPAccountType.AutoSize = true;
            this.lblSSPAccountType.Location = new System.Drawing.Point(43, 25);
            this.lblSSPAccountType.Name = "lblSSPAccountType";
            this.lblSSPAccountType.Size = new System.Drawing.Size(101, 13);
            this.lblSSPAccountType.TabIndex = 0;
            this.lblSSPAccountType.Text = "SSP Product Type :";
            // 
            // lblSSPAccountStatus
            // 
            this.lblSSPAccountStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSSPAccountStatus.AutoSize = true;
            this.lblSSPAccountStatus.Location = new System.Drawing.Point(459, 25);
            this.lblSSPAccountStatus.Name = "lblSSPAccountStatus";
            this.lblSSPAccountStatus.Size = new System.Drawing.Size(110, 13);
            this.lblSSPAccountStatus.TabIndex = 6;
            this.lblSSPAccountStatus.Text = "SSP Account Status :";
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Location = new System.Drawing.Point(9, 515);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(79, 13);
            this.lblReferenceNo.TabIndex = 3;
            this.lblReferenceNo.Text = "Record Count :";
            // 
            // dgvSearchResult
            // 
            this.dgvSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearchResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResult.Location = new System.Drawing.Point(12, 154);
            this.dgvSearchResult.Name = "dgvSearchResult";
            this.dgvSearchResult.Size = new System.Drawing.Size(1056, 354);
            this.dgvSearchResult.TabIndex = 2;
            this.dgvSearchResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResult_CellContentClick);
            // 
            // lblReferenceNumber
            // 
            this.lblReferenceNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblReferenceNumber.AutoSize = true;
            this.lblReferenceNumber.Location = new System.Drawing.Point(466, 54);
            this.lblReferenceNumber.Name = "lblReferenceNumber";
            this.lblReferenceNumber.Size = new System.Drawing.Size(103, 13);
            this.lblReferenceNumber.TabIndex = 8;
            this.lblReferenceNumber.Text = "Reference Number :";
            // 
            // lblReferenceNoDisplay
            // 
            this.lblReferenceNoDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReferenceNoDisplay.AutoSize = true;
            this.lblReferenceNoDisplay.Location = new System.Drawing.Point(88, 515);
            this.lblReferenceNoDisplay.Name = "lblReferenceNoDisplay";
            this.lblReferenceNoDisplay.Size = new System.Drawing.Size(13, 13);
            this.lblReferenceNoDisplay.TabIndex = 4;
            this.lblReferenceNoDisplay.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtReferenceNumber);
            this.groupBox1.Controls.Add(this.txtDepositAccountNumber);
            this.groupBox1.Controls.Add(this.txtDepositAccountTitle);
            this.groupBox1.Controls.Add(this.cmbSSPAccountStatus);
            this.groupBox1.Controls.Add(this.cmbSSPAccountType);
            this.groupBox1.Controls.Add(this.lblSSPAccountType);
            this.groupBox1.Controls.Add(this.lblDepositAccountNumber);
            this.groupBox1.Controls.Add(this.lblDepositAccountTitle);
            this.groupBox1.Controls.Add(this.lblReferenceNumber);
            this.groupBox1.Controls.Add(this.lblSSPAccountStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(882, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Searching Criteria";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtReferenceNumber.Lines = new string[0];
            this.txtReferenceNumber.Location = new System.Drawing.Point(575, 49);
            this.txtReferenceNumber.MaxLength = 32767;
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.PasswordChar = '\0';
            this.txtReferenceNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReferenceNumber.SelectedText = "";
            this.txtReferenceNumber.Size = new System.Drawing.Size(295, 23);
            this.txtReferenceNumber.TabIndex = 9;
            this.txtReferenceNumber.UseSelectable = true;
            // 
            // txtDepositAccountNumber
            // 
            this.txtDepositAccountNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDepositAccountNumber.Lines = new string[0];
            this.txtDepositAccountNumber.Location = new System.Drawing.Point(150, 78);
            this.txtDepositAccountNumber.MaxLength = 32767;
            this.txtDepositAccountNumber.Name = "txtDepositAccountNumber";
            this.txtDepositAccountNumber.PasswordChar = '\0';
            this.txtDepositAccountNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDepositAccountNumber.SelectedText = "";
            this.txtDepositAccountNumber.Size = new System.Drawing.Size(295, 23);
            this.txtDepositAccountNumber.TabIndex = 5;
            this.txtDepositAccountNumber.UseSelectable = true;
            // 
            // txtDepositAccountTitle
            // 
            this.txtDepositAccountTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDepositAccountTitle.Lines = new string[0];
            this.txtDepositAccountTitle.Location = new System.Drawing.Point(150, 49);
            this.txtDepositAccountTitle.MaxLength = 32767;
            this.txtDepositAccountTitle.Name = "txtDepositAccountTitle";
            this.txtDepositAccountTitle.PasswordChar = '\0';
            this.txtDepositAccountTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDepositAccountTitle.SelectedText = "";
            this.txtDepositAccountTitle.Size = new System.Drawing.Size(295, 23);
            this.txtDepositAccountTitle.TabIndex = 3;
            this.txtDepositAccountTitle.UseSelectable = true;
            // 
            // cmbSSPAccountStatus
            // 
            this.cmbSSPAccountStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbSSPAccountStatus.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbSSPAccountStatus.FormattingEnabled = true;
            this.cmbSSPAccountStatus.ItemHeight = 19;
            this.cmbSSPAccountStatus.Location = new System.Drawing.Point(575, 18);
            this.cmbSSPAccountStatus.Name = "cmbSSPAccountStatus";
            this.cmbSSPAccountStatus.Size = new System.Drawing.Size(295, 25);
            this.cmbSSPAccountStatus.TabIndex = 7;
            this.cmbSSPAccountStatus.UseSelectable = true;
            // 
            // cmbSSPAccountType
            // 
            this.cmbSSPAccountType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbSSPAccountType.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbSSPAccountType.FormattingEnabled = true;
            this.cmbSSPAccountType.ItemHeight = 19;
            this.cmbSSPAccountType.Location = new System.Drawing.Point(150, 18);
            this.cmbSSPAccountType.Name = "cmbSSPAccountType";
            this.cmbSSPAccountType.Size = new System.Drawing.Size(295, 25);
            this.cmbSSPAccountType.TabIndex = 1;
            this.cmbSSPAccountType.UseSelectable = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Location = new System.Drawing.Point(904, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 110);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
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
            this.customTitlebar1.Size = new System.Drawing.Size(1081, 26);
            this.customTitlebar1.TabIndex = 5;
            this.customTitlebar1.Click += new System.EventHandler(this.customTitlebar1_Click);
            this.customTitlebar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customTitlebar1_MouseDown);
            // 
            // frmSSPRequestSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 551);
            this.ControlBox = false;
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvSearchResult);
            this.Controls.Add(this.lblReferenceNoDisplay);
            this.Controls.Add(this.lblReferenceNo);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1094, 504);
            this.Name = "frmSSPRequestSearch";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Submitted SSP Request";
            this.Load += new System.EventHandler(this.frmSSPRequestSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDepositAccountNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblDepositAccountTitle;
        private System.Windows.Forms.Label lblSSPAccountType;
        private System.Windows.Forms.Label lblSSPAccountStatus;
        private System.Windows.Forms.Label lblReferenceNo;
        private System.Windows.Forms.DataGridView dgvSearchResult;
        private System.Windows.Forms.Label lblReferenceNumber;
        private System.Windows.Forms.Label lblReferenceNoDisplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private CustomControls.CustomTitlebar customTitlebar1;
        private MetroFramework.Controls.MetroComboBox cmbSSPAccountType;
        private MetroFramework.Controls.MetroTextBox txtDepositAccountTitle;
        private MetroFramework.Controls.MetroTextBox txtDepositAccountNumber;
        private MetroFramework.Controls.MetroComboBox cmbSSPAccountStatus;
        private MetroFramework.Controls.MetroTextBox txtReferenceNumber;
    }
}