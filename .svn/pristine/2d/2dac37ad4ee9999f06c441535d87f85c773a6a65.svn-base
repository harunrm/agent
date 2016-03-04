using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using  MISL.Ababil.Agent.Infrastructure.Models.menu;
using MISL.Ababil.Agent.Services;

namespace MISL.Ababil.Agent.UI.forms.security
{
    public partial class EditMenuGroupDialog : Form
    {

        private MenuService menuService;
        private MislbdMenuGroup menuGroup;
        private string backupValue;
        
        public EditMenuGroupDialog()
        {
            InitializeComponent();

            this.menuService = new MenuService();
        }

        private void EditMenuGroupDialog_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {


            backupValue = null;
            string value = menuGroupDescriptionTextBox.Text;

            if (menuGroupDescriptionTextBox.Text.Trim() == String.Empty)
            {
                Message.showWarning("Please enter menu group name.");
                return;
            }

            if (this.MenuGroup == null)
            {
                this.MenuGroup = new MislbdMenuGroup();
                this.MenuGroup.id = 0;
            }
            else
            {
                backupValue = this.MenuGroup.description;
            }

            this.MenuGroup.description = value;



            SaveMenuGroup();

        }

        private void EditMenuGroupDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        public void SaveMenuGroup()
        {
            try
            {
                menuService.SaveMenuGroup(this.MenuGroup);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception e)
            {
                menuGroupDescriptionTextBox.Text = this.menuGroup.description;
                
                if(backupValue != null)
                this.menuGroup.description = backupValue;
                Message.showError(e.Message);
            }
        }

        public MislbdMenuGroup MenuGroup
        {
            get {return menuGroup;}
            set {
                this.menuGroup = value;
                this.menuGroupDescriptionTextBox.Text = value.description;
            }
        }
    }
}
