namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmOutletCashInfoAll
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
            this.cmbAgentName = new MetroFramework.Controls.MetroComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblSubAgent = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.dtpFromDate = new MISL.Ababil.Agent.UI.forms.CustomControls.CustomDateTimePicker();
            this.SuspendLayout();
            // 
            // cmbSubAgnetName
            // 
            this.cmbSubAgnetName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbSubAgnetName.FormattingEnabled = true;
            this.cmbSubAgnetName.ItemHeight = 19;
            this.cmbSubAgnetName.Location = new System.Drawing.Point(221, 157);
            this.cmbSubAgnetName.Name = "cmbSubAgnetName";
            this.cmbSubAgnetName.Size = new System.Drawing.Size(235, 25);
            this.cmbSubAgnetName.TabIndex = 19;
            this.cmbSubAgnetName.UseSelectable = true;
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.ItemHeight = 19;
            this.cmbAgentName.Location = new System.Drawing.Point(221, 121);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.Size = new System.Drawing.Size(235, 25);
            this.cmbAgentName.TabIndex = 17;
            this.cmbAgentName.UseSelectable = true;
            this.cmbAgentName.SelectedIndexChanged += new System.EventHandler(this.cmbAgentName_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(471, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 31);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(170)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Location = new System.Drawing.Point(350, 287);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(110, 31);
            this.btnShow.TabIndex = 22;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblFromDate.Location = new System.Drawing.Point(170, 196);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(46, 17);
            this.lblFromDate.TabIndex = 20;
            this.lblFromDate.Text = "Date :";
            // 
            // lblSubAgent
            // 
            this.lblSubAgent.AutoSize = true;
            this.lblSubAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblSubAgent.Location = new System.Drawing.Point(162, 161);
            this.lblSubAgent.Name = "lblSubAgent";
            this.lblSubAgent.Size = new System.Drawing.Size(54, 17);
            this.lblSubAgent.TabIndex = 18;
            this.lblSubAgent.Text = "Outlet :";
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblAgent.Location = new System.Drawing.Point(163, 125);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(53, 17);
            this.lblAgent.TabIndex = 16;
            this.lblAgent.Text = "Agent :";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Date = "17/09/2015";
            this.dtpFromDate.Location = new System.Drawing.Point(221, 193);
            this.dtpFromDate.MaximumSize = new System.Drawing.Size(400, 25);
            this.dtpFromDate.MinimumSize = new System.Drawing.Size(60, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(235, 25);
            this.dtpFromDate.TabIndex = 21;
            this.dtpFromDate.Value = new System.DateTime(2015, 9, 17, 14, 24, 55, 74);
            // 
            // frmOutletCashInfoAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 341);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cmbSubAgnetName);
            this.Controls.Add(this.cmbAgentName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.lblSubAgent);
            this.Controls.Add(this.lblAgent);
            this.Name = "frmOutletCashInfoAll";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Outlet Cash Information";
            this.Load += new System.EventHandler(this.frmOutletCashInfoAll_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.CustomDateTimePicker dtpFromDate;
        private MetroFramework.Controls.MetroComboBox cmbSubAgnetName;
        private MetroFramework.Controls.MetroComboBox cmbAgentName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblSubAgent;
        private System.Windows.Forms.Label lblAgent;
    }
}