namespace MISL.Ababil.Agent.UI.forms.security
{
    partial class MenuManagement
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
            this.menuTreeView = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuItemListBox = new System.Windows.Forms.ListBox();
            this.newMenuButton = new System.Windows.Forms.Button();
            this.newMenuItemButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.editMenuItemButton = new System.Windows.Forms.Button();
            this.editMenuButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuGroupsComboBox = new System.Windows.Forms.ComboBox();
            this.newGroupButton = new System.Windows.Forms.Button();
            this.editGroupButton = new System.Windows.Forms.Button();
            this.deleteGroupButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuTreeView);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 457);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menus";
            // 
            // menuTreeView
            // 
            this.menuTreeView.Location = new System.Drawing.Point(0, 19);
            this.menuTreeView.Name = "menuTreeView";
            this.menuTreeView.Size = new System.Drawing.Size(315, 432);
            this.menuTreeView.TabIndex = 1;
            this.menuTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.menuTreeView_AfterSelect);
            this.menuTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuTreeView_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.menuItemListBox);
            this.groupBox2.Location = new System.Drawing.Point(339, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 457);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Menu Items";
            // 
            // menuItemListBox
            // 
            this.menuItemListBox.FormattingEnabled = true;
            this.menuItemListBox.Location = new System.Drawing.Point(6, 19);
            this.menuItemListBox.Name = "menuItemListBox";
            this.menuItemListBox.Size = new System.Drawing.Size(281, 433);
            this.menuItemListBox.TabIndex = 0;
            // 
            // newMenuButton
            // 
            this.newMenuButton.Location = new System.Drawing.Point(638, 58);
            this.newMenuButton.Name = "newMenuButton";
            this.newMenuButton.Size = new System.Drawing.Size(118, 23);
            this.newMenuButton.TabIndex = 3;
            this.newMenuButton.Text = "New Menu";
            this.newMenuButton.UseVisualStyleBackColor = true;
            this.newMenuButton.Click += new System.EventHandler(this.newMenuButton_Click);
            // 
            // newMenuItemButton
            // 
            this.newMenuItemButton.Location = new System.Drawing.Point(638, 130);
            this.newMenuItemButton.Name = "newMenuItemButton";
            this.newMenuItemButton.Size = new System.Drawing.Size(118, 23);
            this.newMenuItemButton.TabIndex = 4;
            this.newMenuItemButton.Text = "New Menu Item";
            this.newMenuItemButton.UseVisualStyleBackColor = true;
            this.newMenuItemButton.Click += new System.EventHandler(this.newMenuItemButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(638, 203);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(118, 23);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // moveUpButton
            // 
            this.moveUpButton.Location = new System.Drawing.Point(638, 246);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(118, 23);
            this.moveUpButton.TabIndex = 7;
            this.moveUpButton.Text = "Move Up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            // 
            // moveDownButton
            // 
            this.moveDownButton.Location = new System.Drawing.Point(638, 275);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(118, 23);
            this.moveDownButton.TabIndex = 8;
            this.moveDownButton.Text = "Move Down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            // 
            // editMenuItemButton
            // 
            this.editMenuItemButton.Location = new System.Drawing.Point(638, 159);
            this.editMenuItemButton.Name = "editMenuItemButton";
            this.editMenuItemButton.Size = new System.Drawing.Size(118, 23);
            this.editMenuItemButton.TabIndex = 10;
            this.editMenuItemButton.Text = "Edit Menu Item";
            this.editMenuItemButton.UseVisualStyleBackColor = true;
            // 
            // editMenuButton
            // 
            this.editMenuButton.Location = new System.Drawing.Point(638, 87);
            this.editMenuButton.Name = "editMenuButton";
            this.editMenuButton.Size = new System.Drawing.Size(118, 23);
            this.editMenuButton.TabIndex = 11;
            this.editMenuButton.Text = "Edit Menu";
            this.editMenuButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(638, 467);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(118, 23);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Menu Group:";
            // 
            // menuGroupsComboBox
            // 
            this.menuGroupsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuGroupsComboBox.FormattingEnabled = true;
            this.menuGroupsComboBox.Location = new System.Drawing.Point(92, 12);
            this.menuGroupsComboBox.Name = "menuGroupsComboBox";
            this.menuGroupsComboBox.Size = new System.Drawing.Size(235, 21);
            this.menuGroupsComboBox.TabIndex = 12;
            this.menuGroupsComboBox.SelectedIndexChanged += new System.EventHandler(this.menuGroupsComboBox_SelectedIndexChanged);
            // 
            // newGroupButton
            // 
            this.newGroupButton.Location = new System.Drawing.Point(521, 10);
            this.newGroupButton.Name = "newGroupButton";
            this.newGroupButton.Size = new System.Drawing.Size(82, 23);
            this.newGroupButton.TabIndex = 14;
            this.newGroupButton.Text = "New Group";
            this.newGroupButton.UseVisualStyleBackColor = true;
            this.newGroupButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // editGroupButton
            // 
            this.editGroupButton.Location = new System.Drawing.Point(345, 10);
            this.editGroupButton.Name = "editGroupButton";
            this.editGroupButton.Size = new System.Drawing.Size(82, 23);
            this.editGroupButton.TabIndex = 15;
            this.editGroupButton.Text = "Edit Group";
            this.editGroupButton.UseVisualStyleBackColor = true;
            this.editGroupButton.Click += new System.EventHandler(this.editGroupButton_Click);
            // 
            // deleteGroupButton
            // 
            this.deleteGroupButton.Location = new System.Drawing.Point(433, 10);
            this.deleteGroupButton.Name = "deleteGroupButton";
            this.deleteGroupButton.Size = new System.Drawing.Size(82, 23);
            this.deleteGroupButton.TabIndex = 16;
            this.deleteGroupButton.Text = "Delete Group";
            this.deleteGroupButton.UseVisualStyleBackColor = true;
            this.deleteGroupButton.Click += new System.EventHandler(this.deleteGroupButton_Click);
            // 
            // MenuManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 508);
            this.Controls.Add(this.deleteGroupButton);
            this.Controls.Add(this.editGroupButton);
            this.Controls.Add(this.newGroupButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuGroupsComboBox);
            this.Controls.Add(this.editMenuButton);
            this.Controls.Add(this.editMenuItemButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.newMenuItemButton);
            this.Controls.Add(this.newMenuButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menu Setup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuManagement_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView menuTreeView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button newMenuButton;
        private System.Windows.Forms.Button newMenuItemButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button editMenuItemButton;
        private System.Windows.Forms.Button editMenuButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox menuGroupsComboBox;
        private System.Windows.Forms.Button newGroupButton;
        private System.Windows.Forms.Button editGroupButton;
        private System.Windows.Forms.Button deleteGroupButton;
        private System.Windows.Forms.ListBox menuItemListBox;
    }
}