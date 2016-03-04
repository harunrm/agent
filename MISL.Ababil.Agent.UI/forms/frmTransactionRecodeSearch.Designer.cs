namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmTransactionRecodeSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactionRecodeSearch));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblItemsFound = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dvAllTransactinRecordSearch = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtbTransactionDate = new System.Windows.Forms.MaskedTextBox();
            this.lblApplicationStatus = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.cmbAgentServices = new System.Windows.Forms.ComboBox();
            this.txtVoucherNumber = new System.Windows.Forms.TextBox();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.lblVoucherNumber = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvAllTransactinRecordSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblItemsFound);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.dvAllTransactinRecordSearch);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(877, 465);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lblItemsFound
            // 
            this.lblItemsFound.AutoSize = true;
            this.lblItemsFound.Location = new System.Drawing.Point(9, 427);
            this.lblItemsFound.Name = "lblItemsFound";
            this.lblItemsFound.Size = new System.Drawing.Size(83, 13);
            this.lblItemsFound.TabIndex = 2;
            this.lblItemsFound.Text = "Item(s) Found: 0";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(778, 427);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(675, 427);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 30);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dvAllTransactinRecordSearch
            // 
            this.dvAllTransactinRecordSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvAllTransactinRecordSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvAllTransactinRecordSearch.Location = new System.Drawing.Point(11, 113);
            this.dvAllTransactinRecordSearch.Name = "dvAllTransactinRecordSearch";
            this.dvAllTransactinRecordSearch.Size = new System.Drawing.Size(851, 306);
            this.dvAllTransactinRecordSearch.TabIndex = 1;
            this.dvAllTransactinRecordSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvAllTransactinRecordSearch_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtbTransactionDate);
            this.groupBox1.Controls.Add(this.lblApplicationStatus);
            this.groupBox1.Controls.Add(this.dtpTransactionDate);
            this.groupBox1.Controls.Add(this.cmbAgentServices);
            this.groupBox1.Controls.Add(this.txtVoucherNumber);
            this.groupBox1.Controls.Add(this.lblTransactionDate);
            this.groupBox1.Controls.Add(this.lblVoucherNumber);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox1.Location = new System.Drawing.Point(11, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(851, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Information";
            // 
            // mtbTransactionDate
            // 
            this.mtbTransactionDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbTransactionDate.Location = new System.Drawing.Point(241, 44);
            this.mtbTransactionDate.Mask = "00-00-0000";
            this.mtbTransactionDate.Name = "mtbTransactionDate";
            this.mtbTransactionDate.Size = new System.Drawing.Size(228, 23);
            this.mtbTransactionDate.TabIndex = 4;
            this.mtbTransactionDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbTransactionDate_KeyUp);
            // 
            // lblApplicationStatus
            // 
            this.lblApplicationStatus.AutoSize = true;
            this.lblApplicationStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblApplicationStatus.Location = new System.Drawing.Point(558, 20);
            this.lblApplicationStatus.Name = "lblApplicationStatus";
            this.lblApplicationStatus.Size = new System.Drawing.Size(103, 17);
            this.lblApplicationStatus.TabIndex = 2;
            this.lblApplicationStatus.Text = "Agent Services";
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Location = new System.Drawing.Point(465, 44);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(23, 23);
            this.dtpTransactionDate.TabIndex = 5;
            this.dtpTransactionDate.ValueChanged += new System.EventHandler(this.dtpTransactionDate_ValueChanged);
            // 
            // cmbAgentServices
            // 
            this.cmbAgentServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgentServices.FormattingEnabled = true;
            this.cmbAgentServices.Location = new System.Drawing.Point(494, 43);
            this.cmbAgentServices.Name = "cmbAgentServices";
            this.cmbAgentServices.Size = new System.Drawing.Size(243, 25);
            this.cmbAgentServices.TabIndex = 6;
            // 
            // txtVoucherNumber
            // 
            this.txtVoucherNumber.Location = new System.Drawing.Point(15, 44);
            this.txtVoucherNumber.Name = "txtVoucherNumber";
            this.txtVoucherNumber.Size = new System.Drawing.Size(220, 23);
            this.txtVoucherNumber.TabIndex = 3;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblTransactionDate.Location = new System.Drawing.Point(324, 20);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(117, 17);
            this.lblTransactionDate.TabIndex = 1;
            this.lblTransactionDate.Text = "Transaction Date";
            // 
            // lblVoucherNumber
            // 
            this.lblVoucherNumber.AutoSize = true;
            this.lblVoucherNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblVoucherNumber.Location = new System.Drawing.Point(88, 20);
            this.lblVoucherNumber.Name = "lblVoucherNumber";
            this.lblVoucherNumber.Size = new System.Drawing.Size(115, 17);
            this.lblVoucherNumber.TabIndex = 0;
            this.lblVoucherNumber.Text = "Voucher Number";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(743, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 30);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmTransactionRecodeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 506);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTransactionRecodeSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Record Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTransactionRecodeSearch_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvAllTransactinRecordSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dvAllTransactinRecordSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblApplicationStatus;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.ComboBox cmbAgentServices;
        private System.Windows.Forms.TextBox txtVoucherNumber;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.Label lblVoucherNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.MaskedTextBox mtbTransactionDate;
        private System.Windows.Forms.Label lblItemsFound;
    }
}