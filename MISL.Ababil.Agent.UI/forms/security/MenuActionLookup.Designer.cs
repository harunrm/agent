namespace MISL.Ababil.Agent.UI.forms.security
{
    partial class MenuActionLookup
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectActionButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.actionSearchButton = new System.Windows.Forms.Button();
            this.actionSearchTextBox = new System.Windows.Forms.TextBox();
            this.actionGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.actionGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 349);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu Actions";
            // 
            // selectActionButton
            // 
            this.selectActionButton.Location = new System.Drawing.Point(267, 447);
            this.selectActionButton.Name = "selectActionButton";
            this.selectActionButton.Size = new System.Drawing.Size(75, 23);
            this.selectActionButton.TabIndex = 1;
            this.selectActionButton.Text = "Select";
            this.selectActionButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(348, 447);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.actionSearchButton);
            this.groupBox2.Controls.Add(this.actionSearchTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 53);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // actionSearchButton
            // 
            this.actionSearchButton.Location = new System.Drawing.Point(336, 16);
            this.actionSearchButton.Name = "actionSearchButton";
            this.actionSearchButton.Size = new System.Drawing.Size(69, 23);
            this.actionSearchButton.TabIndex = 1;
            this.actionSearchButton.Text = "Find";
            this.actionSearchButton.UseVisualStyleBackColor = true;
            // 
            // actionSearchTextBox
            // 
            this.actionSearchTextBox.Location = new System.Drawing.Point(6, 19);
            this.actionSearchTextBox.Name = "actionSearchTextBox";
            this.actionSearchTextBox.Size = new System.Drawing.Size(324, 20);
            this.actionSearchTextBox.TabIndex = 0;
            // 
            // actionGridView
            // 
            this.actionGridView.AllowUserToAddRows = false;
            this.actionGridView.AllowUserToDeleteRows = false;
            this.actionGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.actionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actionGridView.Location = new System.Drawing.Point(6, 19);
            this.actionGridView.Name = "actionGridView";
            this.actionGridView.ReadOnly = true;
            this.actionGridView.Size = new System.Drawing.Size(399, 324);
            this.actionGridView.TabIndex = 0;
            // 
            // MenuActionLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 485);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.selectActionButton);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuActionLookup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menu Action Lookup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selectActionButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button actionSearchButton;
        private System.Windows.Forms.TextBox actionSearchTextBox;
        private System.Windows.Forms.DataGridView actionGridView;
    }
}