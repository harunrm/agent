namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmMiniStatement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMiniStatement));
            this.btnShowStatement = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.miniStatementGrid = new System.Windows.Forms.DataGridView();
            this.lblCustomerTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pic_consumer = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fingerPrintGrid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtConsumerAccount = new MetroFramework.Controls.MetroTextBox();
            this.lblConsumerTitle = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bio = new AxBIOPLUGINACTXLib.AxBioPlugInActX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblRequiredFingerPrint = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.customTitlebar1 = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomTitlebar();
            ((System.ComponentModel.ISupportInitialize)(this.miniStatementGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_consumer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerPrintGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bio)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowStatement
            // 
            this.btnShowStatement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnShowStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowStatement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowStatement.ForeColor = System.Drawing.Color.White;
            this.btnShowStatement.Location = new System.Drawing.Point(526, 302);
            this.btnShowStatement.Name = "btnShowStatement";
            this.btnShowStatement.Size = new System.Drawing.Size(138, 28);
            this.btnShowStatement.TabIndex = 3;
            this.btnShowStatement.Text = "Show Statement";
            this.btnShowStatement.UseVisualStyleBackColor = false;
            this.btnShowStatement.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account :";
            // 
            // miniStatementGrid
            // 
            this.miniStatementGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.miniStatementGrid.Location = new System.Drawing.Point(24, 357);
            this.miniStatementGrid.Name = "miniStatementGrid";
            this.miniStatementGrid.ReadOnly = true;
            this.miniStatementGrid.Size = new System.Drawing.Size(807, 197);
            this.miniStatementGrid.TabIndex = 7;
            // 
            // lblCustomerTitle
            // 
            this.lblCustomerTitle.AutoSize = true;
            this.lblCustomerTitle.Location = new System.Drawing.Point(146, 72);
            this.lblCustomerTitle.Name = "lblCustomerTitle";
            this.lblCustomerTitle.Size = new System.Drawing.Size(0, 13);
            this.lblCustomerTitle.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Consumer Title :";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(670, 302);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 28);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(751, 302);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pic_consumer
            // 
            this.pic_consumer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_consumer.Location = new System.Drawing.Point(136, 128);
            this.pic_consumer.Name = "pic_consumer";
            this.pic_consumer.Size = new System.Drawing.Size(153, 180);
            this.pic_consumer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_consumer.TabIndex = 6;
            this.pic_consumer.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 227);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Statement";
            // 
            // fingerPrintGrid
            // 
            this.fingerPrintGrid.AllowUserToDeleteRows = false;
            this.fingerPrintGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fingerPrintGrid.Location = new System.Drawing.Point(378, 82);
            this.fingerPrintGrid.Name = "fingerPrintGrid";
            this.fingerPrintGrid.ReadOnly = true;
            this.fingerPrintGrid.Size = new System.Drawing.Size(447, 201);
            this.fingerPrintGrid.TabIndex = 5;
            this.fingerPrintGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fingerPrintGrid_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(368, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 229);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FingerPrint Information";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtConsumerAccount);
            this.groupBox3.Controls.Add(this.lblConsumerTitle);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Location = new System.Drawing.Point(13, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 289);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consumer Information";
            // 
            // txtConsumerAccount
            // 
            this.txtConsumerAccount.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtConsumerAccount.Lines = new string[0];
            this.txtConsumerAccount.Location = new System.Drawing.Point(112, 16);
            this.txtConsumerAccount.MaxLength = 13;
            this.txtConsumerAccount.Name = "txtConsumerAccount";
            this.txtConsumerAccount.PasswordChar = '\0';
            this.txtConsumerAccount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConsumerAccount.SelectedText = "";
            this.txtConsumerAccount.Size = new System.Drawing.Size(207, 35);
            this.txtConsumerAccount.TabIndex = 0;
            this.txtConsumerAccount.UseSelectable = true;
            this.txtConsumerAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumerAccount_KeyPress);
            this.txtConsumerAccount.MouseLeave += new System.EventHandler(this.txtConsumerAccount_MouseLeave);
            // 
            // lblConsumerTitle
            // 
            this.lblConsumerTitle.AutoSize = true;
            this.lblConsumerTitle.Location = new System.Drawing.Point(110, 54);
            this.lblConsumerTitle.Name = "lblConsumerTitle";
            this.lblConsumerTitle.Size = new System.Drawing.Size(35, 13);
            this.lblConsumerTitle.TabIndex = 1;
            this.lblConsumerTitle.Text = "label2";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bio);
            this.groupBox5.Location = new System.Drawing.Point(112, 75);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(173, 206);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Photo";
            // 
            // bio
            // 
            this.bio.Enabled = true;
            this.bio.Location = new System.Drawing.Point(43, 152);
            this.bio.Name = "bio";
            this.bio.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("bio.OcxState")));
            this.bio.Size = new System.Drawing.Size(31, 27);
            this.bio.TabIndex = 0;
            this.bio.OnCapture += new System.EventHandler(this.bio_OnCapture);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblRequiredFingerPrint);
            this.groupBox4.Location = new System.Drawing.Point(359, 36);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(484, 260);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Account Information";
            // 
            // lblRequiredFingerPrint
            // 
            this.lblRequiredFingerPrint.AutoSize = true;
            this.lblRequiredFingerPrint.Location = new System.Drawing.Point(217, 13);
            this.lblRequiredFingerPrint.Name = "lblRequiredFingerPrint";
            this.lblRequiredFingerPrint.Size = new System.Drawing.Size(35, 13);
            this.lblRequiredFingerPrint.TabIndex = 0;
            this.lblRequiredFingerPrint.Text = "label2";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(414, 302);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(104, 30);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // customTitlebar1
            // 
            this.customTitlebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.customTitlebar1.Location = new System.Drawing.Point(-1, -1);
            this.customTitlebar1.MinimumSize = new System.Drawing.Size(0, 26);
            this.customTitlebar1.Name = "customTitlebar1";
            this.customTitlebar1.OwnerForm = this;
            this.customTitlebar1.ShowTitle = true;
            this.customTitlebar1.Size = new System.Drawing.Size(859, 26);
            this.customTitlebar1.TabIndex = 11;
            // 
            // frmMiniStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 573);
            this.Controls.Add(this.customTitlebar1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.fingerPrintGrid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pic_consumer);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblCustomerTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.miniStatementGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowStatement);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMiniStatement";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "Mini Statement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMiniStatement_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.miniStatementGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_consumer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerPrintGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bio)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowStatement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView miniStatementGrid;
        private System.Windows.Forms.Label lblCustomerTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pic_consumer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView fingerPrintGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private AxBIOPLUGINACTXLib.AxBioPlugInActX bio;
        private System.Windows.Forms.Label lblRequiredFingerPrint;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblConsumerTitle;
        private System.Windows.Forms.Button btnPrint;
        private MetroFramework.Controls.MetroTextBox txtConsumerAccount;
        private CustomControls.CustomTitlebar customTitlebar1;
    }
}