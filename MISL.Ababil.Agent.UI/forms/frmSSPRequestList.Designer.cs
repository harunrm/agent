namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmSSPRequestList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSSPRequestList));
            this.lblAgentSearchCriteria = new System.Windows.Forms.Label();
            this.lblTransactionStatus = new System.Windows.Forms.Label();
            this.cmbSspProductTypes = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchFieldContent = new System.Windows.Forms.TextBox();
            this.lblContains = new System.Windows.Forms.Label();
            this.cmbAgentField = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstSearchCriteria = new System.Windows.Forms.ListBox();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnViewAgent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAgentSearchCriteria
            // 
            this.lblAgentSearchCriteria.AutoSize = true;
            this.lblAgentSearchCriteria.Location = new System.Drawing.Point(33, 29);
            this.lblAgentSearchCriteria.Name = "lblAgentSearchCriteria";
            this.lblAgentSearchCriteria.Size = new System.Drawing.Size(131, 13);
            this.lblAgentSearchCriteria.TabIndex = 0;
            this.lblAgentSearchCriteria.Text = "Application Search Criteria";
            // 
            // lblTransactionStatus
            // 
            this.lblTransactionStatus.AutoSize = true;
            this.lblTransactionStatus.Location = new System.Drawing.Point(72, 107);
            this.lblTransactionStatus.Name = "lblTransactionStatus";
            this.lblTransactionStatus.Size = new System.Drawing.Size(92, 13);
            this.lblTransactionStatus.TabIndex = 4;
            this.lblTransactionStatus.Text = "Ssp Product Type";
            this.lblTransactionStatus.Visible = false;
            // 
            // cmbSspProductTypes
            // 
            this.cmbSspProductTypes.FormattingEnabled = true;
            this.cmbSspProductTypes.Location = new System.Drawing.Point(170, 104);
            this.cmbSspProductTypes.Name = "cmbSspProductTypes";
            this.cmbSspProductTypes.Size = new System.Drawing.Size(243, 21);
            this.cmbSspProductTypes.TabIndex = 5;
            this.cmbSspProductTypes.Visible = false;
            this.cmbSspProductTypes.SelectedIndexChanged += new System.EventHandler(this.cmbSspProductTypes_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(434, 105);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 20);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchFieldContent
            // 
            this.txtSearchFieldContent.Location = new System.Drawing.Point(170, 67);
            this.txtSearchFieldContent.Name = "txtSearchFieldContent";
            this.txtSearchFieldContent.Size = new System.Drawing.Size(243, 20);
            this.txtSearchFieldContent.TabIndex = 3;
            this.txtSearchFieldContent.TextChanged += new System.EventHandler(this.txtSearchFieldContent_TextChanged);
            // 
            // lblContains
            // 
            this.lblContains.AutoSize = true;
            this.lblContains.Location = new System.Drawing.Point(120, 67);
            this.lblContains.Name = "lblContains";
            this.lblContains.Size = new System.Drawing.Size(47, 13);
            this.lblContains.TabIndex = 2;
            this.lblContains.Text = "contains";
            // 
            // cmbAgentField
            // 
            this.cmbAgentField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgentField.FormattingEnabled = true;
            this.cmbAgentField.Location = new System.Drawing.Point(170, 26);
            this.cmbAgentField.Name = "cmbAgentField";
            this.cmbAgentField.Size = new System.Drawing.Size(243, 21);
            this.cmbAgentField.TabIndex = 1;
            this.cmbAgentField.SelectedIndexChanged += new System.EventHandler(this.cmbAgentField_SelectedIndexChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(434, 66);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(59, 20);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(434, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 21);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstSearchCriteria
            // 
            this.lstSearchCriteria.FormattingEnabled = true;
            this.lstSearchCriteria.Location = new System.Drawing.Point(512, 29);
            this.lstSearchCriteria.Name = "lstSearchCriteria";
            this.lstSearchCriteria.Size = new System.Drawing.Size(412, 212);
            this.lstSearchCriteria.TabIndex = 9;
            this.lstSearchCriteria.SelectedIndexChanged += new System.EventHandler(this.lstSearchCriteria_SelectedIndexChanged);
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToDeleteRows = false;
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Location = new System.Drawing.Point(23, 265);
            this.dgResults.MultiSelect = false;
            this.dgResults.Name = "dgResults";
            this.dgResults.Size = new System.Drawing.Size(901, 170);
            this.dgResults.TabIndex = 10;
            this.dgResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResults_CellContentClick);
            this.dgResults.SelectionChanged += new System.EventHandler(this.dgResults_SelectionChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(848, 451);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnViewAgent
            // 
            this.btnViewAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAgent.Location = new System.Drawing.Point(738, 451);
            this.btnViewAgent.Name = "btnViewAgent";
            this.btnViewAgent.Size = new System.Drawing.Size(104, 33);
            this.btnViewAgent.TabIndex = 11;
            this.btnViewAgent.Text = "View";
            this.btnViewAgent.UseVisualStyleBackColor = true;
            this.btnViewAgent.Click += new System.EventHandler(this.btnViewAgent_Click);
            // 
            // frmSSPRequestList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 496);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewAgent);
            this.Controls.Add(this.dgResults);
            this.Controls.Add(this.lblAgentSearchCriteria);
            this.Controls.Add(this.lblTransactionStatus);
            this.Controls.Add(this.cmbSspProductTypes);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchFieldContent);
            this.Controls.Add(this.lblContains);
            this.Controls.Add(this.cmbAgentField);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstSearchCriteria);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSSPRequestList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSP Request List";
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAgentSearchCriteria;
        private System.Windows.Forms.Label lblTransactionStatus;
        private System.Windows.Forms.ComboBox cmbSspProductTypes;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchFieldContent;
        private System.Windows.Forms.Label lblContains;
        private System.Windows.Forms.ComboBox cmbAgentField;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstSearchCriteria;
        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnViewAgent;
    }
}