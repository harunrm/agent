namespace MISL.Ababil.Agent.UI.forms.Dashboard
{
    partial class frmDashboardDetail
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
            this.ucOutletDetail1 = new MISL.Ababil.Agent.UI.forms.Dashboard.Pages.ucOutletDetail();
            this.SuspendLayout();
            // 
            // ucOutletDetail1
            // 
            this.ucOutletDetail1.BackColor = System.Drawing.Color.White;
            this.ucOutletDetail1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucOutletDetail1.Location = new System.Drawing.Point(0, 0);
            this.ucOutletDetail1.Name = "ucOutletDetail1";
            this.ucOutletDetail1.Size = new System.Drawing.Size(936, 389);
            this.ucOutletDetail1.TabIndex = 0;
            // 
            // frmDashboardDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(936, 428);
            this.Controls.Add(this.ucOutletDetail1);
            this.Name = "frmDashboardDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDashboardDetail";
            this.ResumeLayout(false);

        }

        #endregion

        private Pages.ucOutletDetail ucOutletDetail1;
    }
}