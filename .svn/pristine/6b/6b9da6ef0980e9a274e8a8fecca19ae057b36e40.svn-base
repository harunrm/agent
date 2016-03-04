using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.menu;
using MISL.Ababil.Agent.Services;

namespace MISL.Ababil.Agent.UI.forms.security
{
    public partial class MenuManagement : Form
    {

        private MenuService menuService;
        
        public MenuManagement()
        {
            InitializeComponent();
            this.menuService = new MenuService();
            this.menuGroupsComboBox.ValueMember = "id";
            this.menuGroupsComboBox.DisplayMember = "description";

            menuItemListBox.ValueMember = "id";
            menuItemListBox.DisplayMember = "name";

            LoadMenuGroups();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditMenuGroupDialog groupDialog = new EditMenuGroupDialog();
            if (groupDialog.ShowDialog() == DialogResult.OK)
            {
                menuGroupsComboBox.Items.Add(groupDialog.MenuGroup);
                menuGroupsComboBox.SelectedItem = groupDialog.MenuGroup;
            }

            groupDialog.Dispose();
        }

        private void LoadMenuGroups(){
            List<MislbdMenuGroup> menuGroups = menuService.GetMenuGroups();
            foreach (MislbdMenuGroup group in menuGroups)
            {
                menuGroupsComboBox.Items.Add(group);
            }
        }

        private void LoadMenus(long groupId)
        {

            menuTreeView.Nodes.Clear();
            
            try
            {
                List<MislbdMenu> menus = menuService.GetMenuForGroup(groupId);
                if (menus != null && menus.Count != 0)
                {
                    foreach(MislbdMenu menu in menus){
                        MenuTreeNode node = new MenuTreeNode(menu);
                        menuTreeView.Nodes.Add(node);
                    }
                }
            }
            catch (Exception e)
            {
                Message.showError(e.Message);
            }
        }

        private void DeleteMenuGroup()
        {
            try
            {
                MislbdMenuGroup group = (MislbdMenuGroup)menuGroupsComboBox.SelectedItem;
                if (group != null)
                {
                    menuService.DeleteMenuGroup(group.id);
                }

                menuGroupsComboBox.Items.RemoveAt(menuGroupsComboBox.SelectedIndex);
                menuGroupsComboBox.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                Message.showError(e.Message);
            }
        }

        private void MenuManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void menuGroupsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            menuItemListBox.Items.Clear();
            MislbdMenuGroup group = (MislbdMenuGroup) menuGroupsComboBox.SelectedItem;

            if (group != null)
            {
                this.LoadMenus(group.id);
            }
        }

        private void menuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            menuItemListBox.Items.Clear();
            TreeNode node = menuTreeView.SelectedNode;
            if (node is MenuTreeNode)
            {
                if (((MenuTreeNode)node).Menu.menuItems != null)
                foreach (MislbdMenu menu in ((MenuTreeNode)node).Menu.menuItems)
                {
                    if (menu.menuType == MislbdMenuType.MenuItem)
                    {
                        menuItemListBox.Items.Add(menu);
                    }
                }
            }
        }

        private void editGroupButton_Click(object sender, EventArgs e)
        {
            EditMenuGroupDialog groupDialog = new EditMenuGroupDialog();
            groupDialog.MenuGroup = (MislbdMenuGroup) menuGroupsComboBox.SelectedItem;

            if (groupDialog.MenuGroup != null && groupDialog.ShowDialog() == DialogResult.OK)
            {
                menuGroupsComboBox.Items[menuGroupsComboBox.SelectedIndex] = groupDialog.MenuGroup;
            }

            groupDialog.Dispose();
        }

        private void deleteGroupButton_Click(object sender, EventArgs e)
        {
            DeleteMenuGroup();
        }

        private void menuTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = menuTreeView.GetNodeAt(e.X, e.Y);
            if (node == null)
            {
                menuTreeView.SelectedNode = null;
                menuItemListBox.Items.Clear();
            }
        }

        private void newMenuButton_Click(object sender, EventArgs e)
        {

            TreeNode node = menuTreeView.SelectedNode;
            MislbdMenuGroup menuGroup = (MislbdMenuGroup) menuGroupsComboBox.SelectedItem;

            if (menuGroup != null)
            {
                CreateNewMenu(node, menuGroup);
            }
        }

        private void CreateNewMenu( TreeNode node, MislbdMenuGroup menuGroup)
        {
            EditMenuDialog menuDialog = new EditMenuDialog();
            if (menuDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    MislbdMenu menu = new MislbdMenu();
                    menu.id = 0;
                    menu.menuType = MislbdMenuType.Menu;
                    menu.name = menuDialog.MenuName;

                    MenuTreeNode menuNode = new MenuTreeNode(menu);
                    
                    if (node == null)
                    {
                        menuService.AddMenuToGroup(menu, menuGroup);
                        menuTreeView.Nodes.Add(menuNode);
                    }
                    else
                    {
                        menuService.AddMenuToMenu(menu, ((MenuTreeNode)node).Menu );
                        node.Nodes.Add(menuNode);
                    }
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
            }

            menuDialog.Dispose();
        }

        private void newMenuItemButton_Click(object sender, EventArgs e)
        {
            
            EditMenuItemDialog editMenuItemDialog = new EditMenuItemDialog();

            try
            {


                TreeNode node = menuTreeView.SelectedNode;
                if (node != null && editMenuItemDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    MenuTreeNode menuNode = ((MenuTreeNode)node);
                    MislbdMenu menu = editMenuItemDialog.MenuItem;

                    menuService.AddMenuToMenu(menu, menuNode.Menu);
                   
                    if (menuNode.Menu.menuItems == null)
                    {
                        menuNode.Menu.menuItems = new List<MislbdMenu>();
                    }

                    menuNode.Menu.menuItems.Add(menu);
                    menuItemListBox.Items.Add(menu);
                }

            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }

            editMenuItemDialog.Dispose();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    class MenuTreeNode : TreeNode
    {
        public MislbdMenu Menu
        {
            get;
            set;
        }

        public MenuTreeNode(MislbdMenu menu) : this(menu, menu.menuItems)
        {
        }

        public MenuTreeNode(MislbdMenu menu, List<MislbdMenu> childMenus) : base(menu.name)
        {
            this.Menu = menu;
            if(childMenus != null && childMenus.Count != 0)
            foreach(MislbdMenu cm in childMenus){
                if (cm.menuType == MislbdMenuType.Menu)
                {
                    Nodes.Add(new MenuTreeNode(cm, cm.menuItems));
                }
            }
        }
    }
}
