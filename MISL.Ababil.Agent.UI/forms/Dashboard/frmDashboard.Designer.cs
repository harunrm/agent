namespace MISL.Ababil.Agent.UI.forms.Dashboard
{
    partial class frmDashboard
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
            this.ucDashboardIncome1 = new MISL.Ababil.Agent.UI.forms.Dashboard.Pages.ucDashboardIncome();
            this.SuspendLayout();
            // 
            // ucDashboardIncome1
            // 
            this.ucDashboardIncome1.BackColor = System.Drawing.Color.White;
            this.ucDashboardIncome1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucDashboardIncome1.Location = new System.Drawing.Point(0, 0);
            this.ucDashboardIncome1.Name = "ucDashboardIncome1";
            this.ucDashboardIncome1.Size = new System.Drawing.Size(1339, 1096);
            this.ucDashboardIncome1.TabIndex = 0;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1356, 499);
            this.Controls.Add(this.ucDashboardIncome1);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Pages.ucDashboardIncome ucDashboardIncome1;
    }
}