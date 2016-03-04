using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.UI.forms.security;
using MISL.Ababil.Agent.Infrastructure.Models.menu;
using MISL.Ababil.Agent.Services;

namespace MISL.Ababil.Agent.UI.forms.security
{
    public partial class EditMenuItemDialog : Form
    {

        MenuService menuService;
        MislbdMenu menuItem;
        
        public EditMenuItemDialog()
        {
            InitializeComponent();

            this.menuService = new MenuService();
            this.actionComboBox.DisplayMember = "name";
            this.actionComboBox.ValueMember = "id";
            this.actionComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.actionComboBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();


            List<MislbdMenuAction> actions =  menuService.GetMenuActions();

            foreach (MislbdMenuAction action in actions)
            {
                this.actionComboBox.AutoCompleteCustomSource.Add(action.name);
                this.actionComboBox.Items.Add(action);
            }
            
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            SelectMenuAction();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SelectMenuAction();
            }
        }

        public void SelectMenuAction()
        {
            MenuActionLookup actionLookup = new MenuActionLookup();
            if (actionLookup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        public MislbdMenu MenuItem
        {
            get { return menuItem; }
            set
            {
                this.menuItem = value;
                this.menuItemNameTextBox.Text = value.name;
                this.actionComboBox.SelectedItem = value.menuAction;
            }
        }

        private void EditMenuItemDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            MislbdMenuAction action = (MislbdMenuAction) actionComboBox.SelectedItem;
            string name = menuItemNameTextBox.Text;

            if (this.MenuItem == null)
            {
                this.MenuItem = new MislbdMenu();
                this.MenuItem.id = 0;
                this.MenuItem.name = name;
                this.MenuItem.menuType = MislbdMenuType.MenuItem;
                this.MenuItem.menuAction = action;
            }
            else
            {
                this.MenuItem.name = name;
                this.MenuItem.menuAction = action;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
