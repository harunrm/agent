namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmRemittanceAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemittanceAdmin));
            this.dgvRemittance = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSenderName = new System.Windows.Forms.Label();
            this.lblPINCode = new System.Windows.Forms.Label();
            this.lblRecipientNationalID = new System.Windows.Forms.Label();
            this.lblRecipientName = new System.Windows.Forms.Label();
            this.lblNameofExchangeHouse = new System.Windows.Forms.Label();
            this.txtRecipientName = new System.Windows.Forms.TextBox();
            this.txtRecipientNationalID = new System.Windows.Forms.TextBox();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.txtPINCode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbNameofExchangeHouse = new System.Windows.Forms.ComboBox();
            this.lblReferanceNumber = new System.Windows.Forms.Label();
            this.txtReferanceNumber = new System.Windows.Forms.TextBox();
            this.lblRemittanceStatus = new System.Windows.Forms.Label();
            this.cmbRemittanceStatus = new System.Windows.Forms.ComboBox();
            this.lblMndField5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemsFound = new System.Windows.Forms.Label();
            this.autoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemittance)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRemittance
            // 
            this.dgvRemittance.AllowUserToAddRows = false;
            this.dgvRemittance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRemittance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRemittance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemittance.Location = new System.Drawing.Point(12, 199);
            this.dgvRemittance.MultiSelect = false;
            this.dgvRemittance.Name = "dgvRemittance";
            this.dgvRemittance.Size = new System.Drawing.Size(913, 271);
            this.dgvRemittance.TabIndex = 16;
            this.dgvRemittance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemittance_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(830, 478);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 28);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSenderName
            // 
            this.lblSenderName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSenderName.AutoSize = true;
            this.lblSenderName.Location = new System.Drawing.Point(240, 92);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(80, 17);
            this.lblSenderName.TabIndex = 6;
            this.lblSenderName.Text = "Sender Name :";
            this.lblSenderName.UseCompatibleTextRendering = true;
            // 
            // lblPINCode
            // 
            this.lblPINCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPINCode.AutoSize = true;
            this.lblPINCode.Location = new System.Drawing.Point(261, 118);
            this.lblPINCode.Name = "lblPINCode";
            this.lblPINCode.Size = new System.Drawing.Size(59, 17);
            this.lblPINCode.TabIndex = 8;
            this.lblPINCode.Text = "PIN Code :";
            this.lblPINCode.UseCompatibleTextRendering = true;
            // 
            // lblRecipientNationalID
            // 
            this.lblRecipientNationalID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRecipientNationalID.AutoSize = true;
            this.lblRecipientNationalID.Location = new System.Drawing.Point(201, 66);
            this.lblRecipientNationalID.Name = "lblRecipientNationalID";
            this.lblRecipientNationalID.Size = new System.Drawing.Size(117, 17);
            this.lblRecipientNationalID.TabIndex = 4;
            this.lblRecipientNationalID.Text = "Recipient National ID :";
            this.lblRecipientNationalID.UseCompatibleTextRendering = true;
            // 
            // lblRecipientName
            // 
            this.lblRecipientName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRecipientName.AutoSize = true;
            this.lblRecipientName.Location = new System.Drawing.Point(227, 40);
            this.lblRecipientName.Name = "lblRecipientName";
            this.lblRecipientName.Size = new System.Drawing.Size(91, 17);
            this.lblRecipientName.TabIndex = 2;
            this.lblRecipientName.Text = "Recipient Name :";
            this.lblRecipientName.UseCompatibleTextRendering = true;
            // 
            // lblNameofExchangeHouse
            // 
            this.lblNameofExchangeHouse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNameofExchangeHouse.AutoSize = true;
            this.lblNameofExchangeHouse.Location = new System.Drawing.Point(178, 14);
            this.lblNameofExchangeHouse.Name = "lblNameofExchangeHouse";
            this.lblNameofExchangeHouse.Size = new System.Drawing.Size(142, 17);
            this.lblNameofExchangeHouse.TabIndex = 0;
            this.lblNameofExchangeHouse.Text = "Name of Exchange House :";
            this.lblNameofExchangeHouse.UseCompatibleTextRendering = true;
            // 
            // txtRecipientName
            // 
            this.txtRecipientName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtRecipientName.Location = new System.Drawing.Point(325, 37);
            this.txtRecipientName.Name = "txtRecipientName";
            this.txtRecipientName.Size = new System.Drawing.Size(301, 20);
            this.txtRecipientName.TabIndex = 3;
            // 
            // txtRecipientNationalID
            // 
            this.txtRecipientNationalID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtRecipientNationalID.Location = new System.Drawing.Point(324, 63);
            this.txtRecipientNationalID.Name = "txtRecipientNationalID";
            this.txtRecipientNationalID.Size = new System.Drawing.Size(301, 20);
            this.txtRecipientNationalID.TabIndex = 5;
            // 
            // txtSenderName
            // 
            this.txtSenderName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSenderName.Location = new System.Drawing.Point(324, 89);
            this.txtSenderName.Name = "txtSenderName";
            this.txtSenderName.Size = new System.Drawing.Size(301, 20);
            this.txtSenderName.TabIndex = 7;
            // 
            // txtPINCode
            // 
            this.txtPINCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPINCode.Location = new System.Drawing.Point(324, 115);
            this.txtPINCode.Name = "txtPINCode";
            this.txtPINCode.Size = new System.Drawing.Size(301, 20);
            this.txtPINCode.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(648, 166);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(735, 166);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "R&eset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbNameofExchangeHouse
            // 
            this.cmbNameofExchangeHouse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbNameofExchangeHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNameofExchangeHouse.FormattingEnabled = true;
            this.cmbNameofExchangeHouse.Location = new System.Drawing.Point(324, 10);
            this.cmbNameofExchangeHouse.Name = "cmbNameofExchangeHouse";
            this.cmbNameofExchangeHouse.Size = new System.Drawing.Size(301, 21);
            this.cmbNameofExchangeHouse.TabIndex = 1;
            // 
            // lblReferanceNumber
            // 
            this.lblReferanceNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblReferanceNumber.AutoSize = true;
            this.lblReferanceNumber.Location = new System.Drawing.Point(214, 144);
            this.lblReferanceNumber.Name = "lblReferanceNumber";
            this.lblReferanceNumber.Size = new System.Drawing.Size(106, 17);
            this.lblReferanceNumber.TabIndex = 10;
            this.lblReferanceNumber.Text = "Reference Number :";
            this.lblReferanceNumber.UseCompatibleTextRendering = true;
            // 
            // txtReferanceNumber
            // 
            this.txtReferanceNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtReferanceNumber.Location = new System.Drawing.Point(324, 141);
            this.txtReferanceNumber.Name = "txtReferanceNumber";
            this.txtReferanceNumber.Size = new System.Drawing.Size(301, 20);
            this.txtReferanceNumber.TabIndex = 11;
            // 
            // lblRemittanceStatus
            // 
            this.lblRemittanceStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRemittanceStatus.AutoSize = true;
            this.lblRemittanceStatus.Location = new System.Drawing.Point(217, 171);
            this.lblRemittanceStatus.Name = "lblRemittanceStatus";
            this.lblRemittanceStatus.Size = new System.Drawing.Size(103, 17);
            this.lblRemittanceStatus.TabIndex = 12;
            this.lblRemittanceStatus.Text = "Remittance Status :";
            this.lblRemittanceStatus.UseCompatibleTextRendering = true;
            // 
            // cmbRemittanceStatus
            // 
            this.cmbRemittanceStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbRemittanceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemittanceStatus.FormattingEnabled = true;
            this.cmbRemittanceStatus.Location = new System.Drawing.Point(324, 167);
            this.cmbRemittanceStatus.Name = "cmbRemittanceStatus";
            this.cmbRemittanceStatus.Size = new System.Drawing.Size(301, 21);
            this.cmbRemittanceStatus.TabIndex = 13;
            // 
            // lblMndField5
            // 
            this.lblMndField5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMndField5.AutoSize = true;
            this.lblMndField5.ForeColor = System.Drawing.Color.Red;
            this.lblMndField5.Location = new System.Drawing.Point(631, 14);
            this.lblMndField5.Name = "lblMndField5";
            this.lblMndField5.Size = new System.Drawing.Size(11, 13);
            this.lblMndField5.TabIndex = 18;
            this.lblMndField5.Text = "*";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(631, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "*";
            // 
            // lblItemsFound
            // 
            this.lblItemsFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItemsFound.AutoSize = true;
            this.lblItemsFound.Location = new System.Drawing.Point(9, 483);
            this.lblItemsFound.Name = "lblItemsFound";
            this.lblItemsFound.Size = new System.Drawing.Size(83, 13);
            this.lblItemsFound.TabIndex = 19;
            this.lblItemsFound.Text = "Item(s) Found: 0";
            // 
            // autoRefreshTimer
            // 
            this.autoRefreshTimer.Interval = 120000;
            this.autoRefreshTimer.Tick += new System.EventHandler(this.autoRefreshTimer_Tick);
            // 
            // frmRemittanceAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 515);
            this.Controls.Add(this.lblItemsFound);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMndField5);
            this.Controls.Add(this.cmbRemittanceStatus);
            this.Controls.Add(this.cmbNameofExchangeHouse);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtReferanceNumber);
            this.Controls.Add(this.txtPINCode);
            this.Controls.Add(this.txtSenderName);
            this.Controls.Add(this.txtRecipientNationalID);
            this.Controls.Add(this.txtRecipientName);
            this.Controls.Add(this.lblReferanceNumber);
            this.Controls.Add(this.lblSenderName);
            this.Controls.Add(this.lblPINCode);
            this.Controls.Add(this.lblRecipientNationalID);
            this.Controls.Add(this.lblRemittanceStatus);
            this.Controls.Add(this.lblRecipientName);
            this.Controls.Add(this.lblNameofExchangeHouse);
            this.Controls.Add(this.dgvRemittance);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRemittanceAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remittance Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRemittanceAdmin_FormClosing);
            this.Load += new System.EventHandler(this.frmRemittanceAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemittance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRemittance;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.Label lblPINCode;
        private System.Windows.Forms.Label lblRecipientNationalID;
        private System.Windows.Forms.Label lblRecipientName;
        private System.Windows.Forms.Label lblNameofExchangeHouse;
        private System.Windows.Forms.TextBox txtRecipientName;
        private System.Windows.Forms.TextBox txtRecipientNationalID;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.TextBox txtPINCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmbNameofExchangeHouse;
        private System.Windows.Forms.Label lblReferanceNumber;
        private System.Windows.Forms.TextBox txtReferanceNumber;
        private System.Windows.Forms.Label lblRemittanceStatus;
        private System.Windows.Forms.ComboBox cmbRemittanceStatus;
        private System.Windows.Forms.Label lblMndField5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblItemsFound;
        private System.Windows.Forms.Timer autoRefreshTimer;
    }
}