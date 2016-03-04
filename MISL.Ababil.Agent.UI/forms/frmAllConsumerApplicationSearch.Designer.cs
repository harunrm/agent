namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmAllConsumerApplicationSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllConsumerApplicationSearch));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblItemsFound = new System.Windows.Forms.Label();
            this.dvAllApplicationSearch = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbToDate = new System.Windows.Forms.MaskedTextBox();
            this.mtbFromDate = new System.Windows.Forms.MaskedTextBox();
            this.lblApplicationStatus = new System.Windows.Forms.Label();
            this.dateTimeFromDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimeToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbApplicationStatus = new System.Windows.Forms.ComboBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.txtNationalId = new System.Windows.Forms.TextBox();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.timerAutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvAllApplicationSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblItemsFound);
            this.groupBox2.Controls.Add(this.dvAllApplicationSearch);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(14, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(909, 446);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lblItemsFound
            // 
            this.lblItemsFound.AutoSize = true;
            this.lblItemsFound.Location = new System.Drawing.Point(9, 422);
            this.lblItemsFound.Name = "lblItemsFound";
            this.lblItemsFound.Size = new System.Drawing.Size(83, 13);
            this.lblItemsFound.TabIndex = 2;
            this.lblItemsFound.Text = "Item(s) Found: 0";
            // 
            // dvAllApplicationSearch
            // 
            this.dvAllApplicationSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvAllApplicationSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvAllApplicationSearch.Location = new System.Drawing.Point(12, 108);
            this.dvAllApplicationSearch.Name = "dvAllApplicationSearch";
            this.dvAllApplicationSearch.Size = new System.Drawing.Size(885, 311);
            this.dvAllApplicationSearch.TabIndex = 1;
            this.dvAllApplicationSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvAllApplicationSearch_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mtbToDate);
            this.groupBox1.Controls.Add(this.mtbFromDate);
            this.groupBox1.Controls.Add(this.lblApplicationStatus);
            this.groupBox1.Controls.Add(this.dateTimeFromDate);
            this.groupBox1.Controls.Add(this.dateTimeToDate);
            this.groupBox1.Controls.Add(this.cmbApplicationStatus);
            this.groupBox1.Controls.Add(this.lblToDate);
            this.groupBox1.Controls.Add(this.txtNationalId);
            this.groupBox1.Controls.Add(this.txtReferenceNo);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(487, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "dd-MM-yyyy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(339, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "dd-MM-yyyy";
            // 
            // mtbToDate
            // 
            this.mtbToDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbToDate.Location = new System.Drawing.Point(485, 40);
            this.mtbToDate.Mask = "00-00-0000";
            this.mtbToDate.Name = "mtbToDate";
            this.mtbToDate.Size = new System.Drawing.Size(124, 20);
            this.mtbToDate.TabIndex = 9;
            this.mtbToDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbToDate_KeyUp);
            // 
            // mtbFromDate
            // 
            this.mtbFromDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbFromDate.Location = new System.Drawing.Point(336, 40);
            this.mtbFromDate.Mask = "00-00-0000";
            this.mtbFromDate.Name = "mtbFromDate";
            this.mtbFromDate.Size = new System.Drawing.Size(124, 20);
            this.mtbFromDate.TabIndex = 7;
            this.mtbFromDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbFromDate_KeyUp);
            // 
            // lblApplicationStatus
            // 
            this.lblApplicationStatus.AutoSize = true;
            this.lblApplicationStatus.Location = new System.Drawing.Point(660, 22);
            this.lblApplicationStatus.Name = "lblApplicationStatus";
            this.lblApplicationStatus.Size = new System.Drawing.Size(92, 13);
            this.lblApplicationStatus.TabIndex = 4;
            this.lblApplicationStatus.Text = "Application Status";
            // 
            // dateTimeFromDate
            // 
            this.dateTimeFromDate.Location = new System.Drawing.Point(459, 40);
            this.dateTimeFromDate.Name = "dateTimeFromDate";
            this.dateTimeFromDate.Size = new System.Drawing.Size(20, 20);
            this.dateTimeFromDate.TabIndex = 8;
            this.dateTimeFromDate.ValueChanged += new System.EventHandler(this.dateTimeFromDate_ValueChanged);
            // 
            // dateTimeToDate
            // 
            this.dateTimeToDate.Location = new System.Drawing.Point(608, 40);
            this.dateTimeToDate.Name = "dateTimeToDate";
            this.dateTimeToDate.Size = new System.Drawing.Size(20, 20);
            this.dateTimeToDate.TabIndex = 10;
            this.dateTimeToDate.ValueChanged += new System.EventHandler(this.dateTimeToDate_ValueChanged);
            // 
            // cmbApplicationStatus
            // 
            this.cmbApplicationStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplicationStatus.FormattingEnabled = true;
            this.cmbApplicationStatus.Location = new System.Drawing.Point(634, 40);
            this.cmbApplicationStatus.Name = "cmbApplicationStatus";
            this.cmbApplicationStatus.Size = new System.Drawing.Size(160, 21);
            this.cmbApplicationStatus.TabIndex = 11;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(517, 22);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(46, 13);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "To Date";
            // 
            // txtNationalId
            // 
            this.txtNationalId.Location = new System.Drawing.Point(165, 40);
            this.txtNationalId.Name = "txtNationalId";
            this.txtNationalId.Size = new System.Drawing.Size(165, 20);
            this.txtNationalId.TabIndex = 6;
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Location = new System.Drawing.Point(6, 40);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(153, 20);
            this.txtReferenceNo.TabIndex = 5;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(372, 22);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(56, 13);
            this.lblFromDate.TabIndex = 2;
            this.lblFromDate.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "National ID  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reference No. :";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(799, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 30);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(767, 460);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 33);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(848, 460);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timerAutoRefresh
            // 
            this.timerAutoRefresh.Enabled = true;
            this.timerAutoRefresh.Interval = 300000;
            this.timerAutoRefresh.Tick += new System.EventHandler(this.timerAutoRefresh_Tick);
            // 
            // frmAllConsumerApplicationSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 512);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAllConsumerApplicationSearch";
            this.Text = "All Consumer Application Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAllConsumerApplicationSearch_FormClosing);
            this.Load += new System.EventHandler(this.frmAllConsumerApplicationSearch_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvAllApplicationSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dvAllApplicationSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.TextBox txtNationalId;
        private System.Windows.Forms.TextBox txtReferenceNo;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimeFromDate;
        private System.Windows.Forms.DateTimePicker dateTimeToDate;
        private System.Windows.Forms.ComboBox cmbApplicationStatus;
        private System.Windows.Forms.Label lblApplicationStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblItemsFound;
        private System.Windows.Forms.MaskedTextBox mtbToDate;
        private System.Windows.Forms.MaskedTextBox mtbFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerAutoRefresh;
    }
}