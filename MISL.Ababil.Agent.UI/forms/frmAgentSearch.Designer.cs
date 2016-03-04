namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmAgentSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgentSearch));
            this.lstSearchCriteria = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cmbAgentField = new System.Windows.Forms.ComboBox();
            this.lblContains = new System.Windows.Forms.Label();
            this.txtSearchFieldContent = new System.Windows.Forms.TextBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblBetween = new System.Windows.Forms.Label();
            this.lblAnd = new System.Windows.Forms.Label();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnViewAgent = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbTransactionStatus = new System.Windows.Forms.ComboBox();
            this.cmbApprovalStatus = new System.Windows.Forms.ComboBox();
            this.lblTransactionStatus = new System.Windows.Forms.Label();
            this.lblApprovalStatus = new System.Windows.Forms.Label();
            this.lblAgentSearchCriteria = new System.Windows.Forms.Label();
            this.mtbFrom = new System.Windows.Forms.MaskedTextBox();
            this.mtbTo = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.SuspendLayout();
            // 
            // lstSearchCriteria
            // 
            this.lstSearchCriteria.FormattingEnabled = true;
            this.lstSearchCriteria.Location = new System.Drawing.Point(488, 25);
            this.lstSearchCriteria.Name = "lstSearchCriteria";
            this.lstSearchCriteria.Size = new System.Drawing.Size(412, 212);
            this.lstSearchCriteria.TabIndex = 12;
            this.lstSearchCriteria.SelectedIndexChanged += new System.EventHandler(this.lstSearchCriteria_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(410, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 21);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(410, 62);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(59, 20);
            this.btnRemove.TabIndex = 19;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // cmbAgentField
            // 
            this.cmbAgentField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgentField.FormattingEnabled = true;
            this.cmbAgentField.Location = new System.Drawing.Point(146, 22);
            this.cmbAgentField.Name = "cmbAgentField";
            this.cmbAgentField.Size = new System.Drawing.Size(243, 21);
            this.cmbAgentField.TabIndex = 1;
            this.cmbAgentField.SelectedIndexChanged += new System.EventHandler(this.cmbAgentField_SelectedIndexChanged);
            // 
            // lblContains
            // 
            this.lblContains.AutoSize = true;
            this.lblContains.Location = new System.Drawing.Point(96, 63);
            this.lblContains.Name = "lblContains";
            this.lblContains.Size = new System.Drawing.Size(47, 13);
            this.lblContains.TabIndex = 13;
            this.lblContains.Text = "contains";
            // 
            // txtSearchFieldContent
            // 
            this.txtSearchFieldContent.Location = new System.Drawing.Point(146, 63);
            this.txtSearchFieldContent.Name = "txtSearchFieldContent";
            this.txtSearchFieldContent.Size = new System.Drawing.Size(243, 20);
            this.txtSearchFieldContent.TabIndex = 14;
            this.txtSearchFieldContent.TextChanged += new System.EventHandler(this.txtSearchFieldContent_TextChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(296, 100);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(20, 20);
            this.dtpFrom.TabIndex = 4;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(296, 139);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(20, 20);
            this.dtpTo.TabIndex = 8;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // lblBetween
            // 
            this.lblBetween.AutoSize = true;
            this.lblBetween.Location = new System.Drawing.Point(96, 100);
            this.lblBetween.Name = "lblBetween";
            this.lblBetween.Size = new System.Drawing.Size(48, 13);
            this.lblBetween.TabIndex = 2;
            this.lblBetween.Text = "between";
            // 
            // lblAnd
            // 
            this.lblAnd.AutoSize = true;
            this.lblAnd.Location = new System.Drawing.Point(115, 139);
            this.lblAnd.Name = "lblAnd";
            this.lblAnd.Size = new System.Drawing.Size(25, 13);
            this.lblAnd.TabIndex = 6;
            this.lblAnd.Text = "and";
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToDeleteRows = false;
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Location = new System.Drawing.Point(12, 267);
            this.dgResults.MultiSelect = false;
            this.dgResults.Name = "dgResults";
            this.dgResults.Size = new System.Drawing.Size(901, 170);
            this.dgResults.TabIndex = 20;
            this.dgResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResults_CellContentClick);
            this.dgResults.SelectionChanged += new System.EventHandler(this.dgResults_SelectionChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(410, 101);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 20);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnViewAgent
            // 
            this.btnViewAgent.Location = new System.Drawing.Point(757, 456);
            this.btnViewAgent.Name = "btnViewAgent";
            this.btnViewAgent.Size = new System.Drawing.Size(75, 23);
            this.btnViewAgent.TabIndex = 21;
            this.btnViewAgent.Text = "View";
            this.btnViewAgent.UseVisualStyleBackColor = true;
            this.btnViewAgent.Click += new System.EventHandler(this.btnViewAgent_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(838, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbTransactionStatus
            // 
            this.cmbTransactionStatus.FormattingEnabled = true;
            this.cmbTransactionStatus.Location = new System.Drawing.Point(146, 177);
            this.cmbTransactionStatus.Name = "cmbTransactionStatus";
            this.cmbTransactionStatus.Size = new System.Drawing.Size(243, 21);
            this.cmbTransactionStatus.TabIndex = 16;
            this.cmbTransactionStatus.SelectedIndexChanged += new System.EventHandler(this.cmbTransactionStatus_SelectedIndexChanged);
            // 
            // cmbApprovalStatus
            // 
            this.cmbApprovalStatus.FormattingEnabled = true;
            this.cmbApprovalStatus.Location = new System.Drawing.Point(146, 217);
            this.cmbApprovalStatus.Name = "cmbApprovalStatus";
            this.cmbApprovalStatus.Size = new System.Drawing.Size(243, 21);
            this.cmbApprovalStatus.TabIndex = 18;
            this.cmbApprovalStatus.SelectedIndexChanged += new System.EventHandler(this.cmbApprovalStatus_SelectedIndexChanged);
            // 
            // lblTransactionStatus
            // 
            this.lblTransactionStatus.AutoSize = true;
            this.lblTransactionStatus.Location = new System.Drawing.Point(48, 179);
            this.lblTransactionStatus.Name = "lblTransactionStatus";
            this.lblTransactionStatus.Size = new System.Drawing.Size(96, 13);
            this.lblTransactionStatus.TabIndex = 15;
            this.lblTransactionStatus.Text = "Transaction Status";
            // 
            // lblApprovalStatus
            // 
            this.lblApprovalStatus.AutoSize = true;
            this.lblApprovalStatus.Location = new System.Drawing.Point(58, 217);
            this.lblApprovalStatus.Name = "lblApprovalStatus";
            this.lblApprovalStatus.Size = new System.Drawing.Size(82, 13);
            this.lblApprovalStatus.TabIndex = 17;
            this.lblApprovalStatus.Text = "Approval Status";
            // 
            // lblAgentSearchCriteria
            // 
            this.lblAgentSearchCriteria.AutoSize = true;
            this.lblAgentSearchCriteria.Location = new System.Drawing.Point(33, 25);
            this.lblAgentSearchCriteria.Name = "lblAgentSearchCriteria";
            this.lblAgentSearchCriteria.Size = new System.Drawing.Size(107, 13);
            this.lblAgentSearchCriteria.TabIndex = 0;
            this.lblAgentSearchCriteria.Text = "Agent Search Criteria";
            // 
            // mtbFrom
            // 
            this.mtbFrom.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbFrom.Location = new System.Drawing.Point(146, 100);
            this.mtbFrom.Mask = "00-00-0000";
            this.mtbFrom.Name = "mtbFrom";
            this.mtbFrom.Size = new System.Drawing.Size(151, 20);
            this.mtbFrom.TabIndex = 3;
            this.mtbFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbFrom_KeyUp);
            // 
            // mtbTo
            // 
            this.mtbTo.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbTo.Location = new System.Drawing.Point(146, 139);
            this.mtbTo.Mask = "00-00-0000";
            this.mtbTo.Name = "mtbTo";
            this.mtbTo.Size = new System.Drawing.Size(151, 20);
            this.mtbTo.TabIndex = 7;
            this.mtbTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbTo_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(322, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "dd-MM-yyyy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(322, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "dd-MM-yyyy";
            // 
            // frmAgentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 497);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.mtbTo);
            this.Controls.Add(this.mtbFrom);
            this.Controls.Add(this.lblAgentSearchCriteria);
            this.Controls.Add(this.lblApprovalStatus);
            this.Controls.Add(this.lblTransactionStatus);
            this.Controls.Add(this.cmbApprovalStatus);
            this.Controls.Add(this.cmbTransactionStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewAgent);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgResults);
            this.Controls.Add(this.lblAnd);
            this.Controls.Add(this.lblBetween);
            this.Controls.Add(this.txtSearchFieldContent);
            this.Controls.Add(this.lblContains);
            this.Controls.Add(this.cmbAgentField);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstSearchCriteria);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAgentSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agent Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAgentSearch_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSearchCriteria;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cmbAgentField;
        private System.Windows.Forms.Label lblContains;
        private System.Windows.Forms.TextBox txtSearchFieldContent;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblBetween;
        private System.Windows.Forms.Label lblAnd;
        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnViewAgent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbTransactionStatus;
        private System.Windows.Forms.ComboBox cmbApprovalStatus;
        private System.Windows.Forms.Label lblTransactionStatus;
        private System.Windows.Forms.Label lblApprovalStatus;
        private System.Windows.Forms.Label lblAgentSearchCriteria;
        private System.Windows.Forms.MaskedTextBox mtbFrom;
        private System.Windows.Forms.MaskedTextBox mtbTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}