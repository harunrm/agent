namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmCashInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashInformation));
            this.lblPreviousDayBalance = new System.Windows.Forms.Label();
            this.dgvCashInformation = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotalReceived = new System.Windows.Forms.TextBox();
            this.txtTotalPayment = new System.Windows.Forms.TextBox();
            this.lblCashInHand = new System.Windows.Forms.Label();
            this.txtCashInHand = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblOutlet = new System.Windows.Forms.Label();
            this.txtPreviousDayBalance = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashInformation)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPreviousDayBalance
            // 
            this.lblPreviousDayBalance.AutoSize = true;
            this.lblPreviousDayBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviousDayBalance.Location = new System.Drawing.Point(13, 63);
            this.lblPreviousDayBalance.Name = "lblPreviousDayBalance";
            this.lblPreviousDayBalance.Size = new System.Drawing.Size(170, 16);
            this.lblPreviousDayBalance.TabIndex = 0;
            this.lblPreviousDayBalance.Text = "Previous Day Balance :";
            // 
            // dgvCashInformation
            // 
            this.dgvCashInformation.AllowUserToAddRows = false;
            this.dgvCashInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCashInformation.BackgroundColor = System.Drawing.Color.White;
            this.dgvCashInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashInformation.Location = new System.Drawing.Point(16, 95);
            this.dgvCashInformation.Name = "dgvCashInformation";
            this.dgvCashInformation.Size = new System.Drawing.Size(840, 298);
            this.dgvCashInformation.TabIndex = 2;
            this.dgvCashInformation.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvCashInformation_ColumnWidthChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(70, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(52, 16);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total :";
            // 
            // txtTotalReceived
            // 
            this.txtTotalReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReceived.Location = new System.Drawing.Point(121, 6);
            this.txtTotalReceived.Name = "txtTotalReceived";
            this.txtTotalReceived.ReadOnly = true;
            this.txtTotalReceived.Size = new System.Drawing.Size(143, 22);
            this.txtTotalReceived.TabIndex = 1;
            this.txtTotalReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPayment
            // 
            this.txtTotalPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPayment.Location = new System.Drawing.Point(270, 6);
            this.txtTotalPayment.Name = "txtTotalPayment";
            this.txtTotalPayment.ReadOnly = true;
            this.txtTotalPayment.Size = new System.Drawing.Size(143, 22);
            this.txtTotalPayment.TabIndex = 1;
            this.txtTotalPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCashInHand
            // 
            this.lblCashInHand.AutoSize = true;
            this.lblCashInHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashInHand.Location = new System.Drawing.Point(14, 36);
            this.lblCashInHand.Name = "lblCashInHand";
            this.lblCashInHand.Size = new System.Drawing.Size(108, 16);
            this.lblCashInHand.TabIndex = 0;
            this.lblCashInHand.Text = "Cash In Hand :";
            // 
            // txtCashInHand
            // 
            this.txtCashInHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashInHand.Location = new System.Drawing.Point(121, 32);
            this.txtCashInHand.Name = "txtCashInHand";
            this.txtCashInHand.ReadOnly = true;
            this.txtCashInHand.Size = new System.Drawing.Size(143, 22);
            this.txtCashInHand.TabIndex = 1;
            this.txtCashInHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(766, 462);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(574, 462);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(670, 462);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblOutlet
            // 
            this.lblOutlet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutlet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutlet.Location = new System.Drawing.Point(16, 19);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(840, 24);
            this.lblOutlet.TabIndex = 6;
            this.lblOutlet.Text = "OutletName";
            this.lblOutlet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPreviousDayBalance
            // 
            this.txtPreviousDayBalance.AutoSize = true;
            this.txtPreviousDayBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreviousDayBalance.Location = new System.Drawing.Point(189, 63);
            this.txtPreviousDayBalance.Name = "txtPreviousDayBalance";
            this.txtPreviousDayBalance.Size = new System.Drawing.Size(16, 16);
            this.txtPreviousDayBalance.TabIndex = 0;
            this.txtPreviousDayBalance.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtTotalPayment);
            this.panel1.Controls.Add(this.txtCashInHand);
            this.panel1.Controls.Add(this.lblCashInHand);
            this.panel1.Controls.Add(this.txtTotalReceived);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Location = new System.Drawing.Point(16, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 58);
            this.panel1.TabIndex = 7;
            // 
            // frmCashInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 504);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblOutlet);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvCashInformation);
            this.Controls.Add(this.txtPreviousDayBalance);
            this.Controls.Add(this.lblPreviousDayBalance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCashInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Information";
            this.Load += new System.EventHandler(this.frmCashInformation_Load);
            this.ResizeEnd += new System.EventHandler(this.frmCashInformation_ResizeEnd);
            this.Resize += new System.EventHandler(this.frmCashInformation_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashInformation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPreviousDayBalance;
        private System.Windows.Forms.DataGridView dgvCashInformation;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotalReceived;
        private System.Windows.Forms.TextBox txtTotalPayment;
        private System.Windows.Forms.Label lblCashInHand;
        private System.Windows.Forms.TextBox txtCashInHand;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblOutlet;
        private System.Windows.Forms.Label txtPreviousDayBalance;
        private System.Windows.Forms.Panel panel1;
    }
}