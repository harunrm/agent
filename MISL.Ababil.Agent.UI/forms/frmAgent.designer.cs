namespace MISL.Ababil.Agent.UI.forms
{
    partial class frmAgent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgent));
            this.tabSubAgent = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblAgent_BusinessLocation = new System.Windows.Forms.Label();
            this.lblAgent_BusinessName = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gvAccountInfo = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.gvUsers = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnNewSubAgent = new System.Windows.Forms.Button();
            this.gvSubAgent = new System.Windows.Forms.DataGridView();
            this.cmbAgentName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabSubAgent.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountInfo)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubAgent)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSubAgent
            // 
            this.tabSubAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSubAgent.Controls.Add(this.tabPage1);
            this.tabSubAgent.Controls.Add(this.tabPage2);
            this.tabSubAgent.Controls.Add(this.tabPage3);
            this.tabSubAgent.Controls.Add(this.tabPage4);
            this.tabSubAgent.Location = new System.Drawing.Point(12, 46);
            this.tabSubAgent.Name = "tabSubAgent";
            this.tabSubAgent.SelectedIndex = 0;
            this.tabSubAgent.Size = new System.Drawing.Size(670, 231);
            this.tabSubAgent.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblMobile);
            this.tabPage1.Controls.Add(this.lblAgent_BusinessLocation);
            this.tabPage1.Controls.Add(this.lblAgent_BusinessName);
            this.tabPage1.Controls.Add(this.lblCustomerId);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(662, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(157, 75);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(0, 13);
            this.lblMobile.TabIndex = 4;
            // 
            // lblAgent_BusinessLocation
            // 
            this.lblAgent_BusinessLocation.Location = new System.Drawing.Point(157, 100);
            this.lblAgent_BusinessLocation.Name = "lblAgent_BusinessLocation";
            this.lblAgent_BusinessLocation.Size = new System.Drawing.Size(499, 98);
            this.lblAgent_BusinessLocation.TabIndex = 3;
            // 
            // lblAgent_BusinessName
            // 
            this.lblAgent_BusinessName.AutoSize = true;
            this.lblAgent_BusinessName.Location = new System.Drawing.Point(157, 49);
            this.lblAgent_BusinessName.Name = "lblAgent_BusinessName";
            this.lblAgent_BusinessName.Size = new System.Drawing.Size(0, 13);
            this.lblAgent_BusinessName.TabIndex = 2;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(157, 23);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(0, 13);
            this.lblCustomerId.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(87, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mobile No. :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Agent/Business Location :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Agent/Business Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer ID :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gvAccountInfo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(662, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Account List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gvAccountInfo
            // 
            this.gvAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvAccountInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccountInfo.Location = new System.Drawing.Point(2, 4);
            this.gvAccountInfo.Name = "gvAccountInfo";
            this.gvAccountInfo.Size = new System.Drawing.Size(656, 198);
            this.gvAccountInfo.TabIndex = 25;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnNewUser);
            this.tabPage3.Controls.Add(this.gvUsers);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(662, 205);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Users";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewUser.Location = new System.Drawing.Point(583, 5);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(75, 23);
            this.btnNewUser.TabIndex = 0;
            this.btnNewUser.Text = "New User";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // gvUsers
            // 
            this.gvUsers.AllowUserToOrderColumns = true;
            this.gvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsers.Location = new System.Drawing.Point(2, 33);
            this.gvUsers.Name = "gvUsers";
            this.gvUsers.Size = new System.Drawing.Size(656, 169);
            this.gvUsers.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnNewSubAgent);
            this.tabPage4.Controls.Add(this.gvSubAgent);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(662, 205);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Sub Agent";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnNewSubAgent
            // 
            this.btnNewSubAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewSubAgent.Location = new System.Drawing.Point(569, 5);
            this.btnNewSubAgent.Name = "btnNewSubAgent";
            this.btnNewSubAgent.Size = new System.Drawing.Size(89, 23);
            this.btnNewSubAgent.TabIndex = 0;
            this.btnNewSubAgent.Text = "New Sub agent";
            this.btnNewSubAgent.UseVisualStyleBackColor = true;
            this.btnNewSubAgent.Click += new System.EventHandler(this.button2_Click);
            // 
            // gvSubAgent
            // 
            this.gvSubAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvSubAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSubAgent.Location = new System.Drawing.Point(2, 33);
            this.gvSubAgent.Name = "gvSubAgent";
            this.gvSubAgent.Size = new System.Drawing.Size(656, 169);
            this.gvSubAgent.TabIndex = 1;
            this.gvSubAgent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSubAgent_CellContentClick);
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.Location = new System.Drawing.Point(97, 12);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.Size = new System.Drawing.Size(227, 21);
            this.cmbAgentName.TabIndex = 23;
            this.cmbAgentName.SelectedIndexChanged += new System.EventHandler(this.cmbAgentName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Agent Name :";
            // 
            // frmAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 288);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAgentName);
            this.Controls.Add(this.tabSubAgent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAgent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agent Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAgent_FormClosing);
            this.Load += new System.EventHandler(this.frmAgent_Load);
            this.tabSubAgent.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvAccountInfo)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSubAgent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabSubAgent;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.DataGridView gvUsers;
        private System.Windows.Forms.Button btnNewSubAgent;
        private System.Windows.Forms.DataGridView gvSubAgent;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblAgent_BusinessLocation;
        private System.Windows.Forms.Label lblAgent_BusinessName;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.DataGridView gvAccountInfo;
        private System.Windows.Forms.ComboBox cmbAgentName;
        private System.Windows.Forms.Label label2;
    }
}