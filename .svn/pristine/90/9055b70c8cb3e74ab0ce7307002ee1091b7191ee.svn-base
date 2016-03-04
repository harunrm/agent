using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.menu;
using MISL.Ababil.Agent.Communication;

namespace MISL.Ababil.Agent.Services
{
    public class MenuService
    {
        private Form masterForm;
        private MenuCom menuCom;

        public MenuService()
        {
            this.menuCom = new MenuCom();
        }


        public void InitializeMenu(Form masterForm)
        {
            this.masterForm = masterForm;
            this.masterForm.Controls.Add(GetUserMenu());
        }

        private MenuStrip GetUserMenu()
        {
            List<MislbdMenu> menus = menuCom.GetUserMenu(); //createDummyMenuList(); //null; /// load from session data;
            MenuStrip menuStrip = new MenuStrip();
            foreach (MislbdMenu menu in menus)
            {
                ToolStripItem menuItem = (ToolStripItem)CreateStripMenuItem(menu);
                menuStrip.Items.Add(menuItem);
                if (menu.menuType == MislbdMenuType.Menu && menu.menuItems != null && menu.menuItems.Any())
                {
                    CreateSubmenu((ToolStripMenuItem)menuItem, menu);
                }
            }
            return menuStrip;
        }

        private void CreateSubmenu(ToolStripMenuItem menuStrip, MislbdMenu menu)
        {
            foreach (MislbdMenu menuItem in menu.menuItems)
            {
                ToolStripItem stripMenuItem = CreateStripMenuItem(menuItem);
                menuStrip.DropDownItems.Add(stripMenuItem);
                if (menuItem.menuType == MislbdMenuType.Menu && menuItem.menuItems != null && menuItem.menuItems.Any())
                {
                    CreateSubmenu((ToolStripMenuItem)stripMenuItem, menuItem);
                }
            }
        }

        private ToolStripItem CreateStripMenuItem(MislbdMenu menu)
        {
            if (menu.menuType == MislbdMenuType.MenuItem)
            {
                ToolStripActionMenuItem item = new ToolStripActionMenuItem(menu.menuAction.action, menu.name, new EventHandler(OnMenuItemClick));
                return item;
            }
            else if ((menu.menuType == MislbdMenuType.Menu))
            {
                return new ToolStripMenuItem(menu.name);
            }
            else
            {
                return new ToolStripSeparator();
            }
        }

        private void OnMenuItemClick(object sender, EventArgs e)
        {
            if (sender is ToolStripActionMenuItem)
            {

                var executingPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().CodeBase) + "\\MISL.Ababil.Agent.UI.dll";

                Assembly frmAssembly = Assembly.LoadFrom(new Uri(executingPath).LocalPath);
                ToolStripActionMenuItem item = (ToolStripActionMenuItem)sender;

                foreach (Type type in frmAssembly.GetTypes())
                {
                    if (type.BaseType == typeof(Form))
                    {
                        if (type.FullName == item.Action)
                        {
                            Form frmShow = (Form)frmAssembly.CreateInstance(type.ToString());
                            frmShow.WindowState = FormWindowState.Normal;
                            frmShow.MdiParent = masterForm;
                            frmShow.Show();//Dialog(masterForm);
                            return;
                        }
                    }
                }

                MessageBox.Show(masterForm, "No action defined for menu", "Menu Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<MislbdMenu> createDummyMenuList()
        {

            MislbdMenuAction menuAction = new MislbdMenuAction();
            menuAction.action = "MISL.Ababil.Agent.UI.forms.security.MenuItemManagement";
            
            MislbdMenu menuItem = new MislbdMenu();
            menuItem.menuType = MislbdMenuType.MenuItem;
            menuItem.name = "Open";
            menuItem.menuAction = menuAction;


            MislbdMenu menu = new MislbdMenu();
            menu.menuType = MislbdMenuType.Menu;
            menu.name = "File";
            menu.menuItems = new List<MislbdMenu>();
            menu.menuItems.Add(menuItem);

            List<MislbdMenu> menus = new List<MislbdMenu>();
            menus.Add(menu);

            return menus;
        }

        public void SaveMenuAction(MislbdMenuAction action)
        {
            menuCom.SaveMenuAction(action);
        }

        public List<MislbdMenuAction> GetMenuActions()
        {
            return menuCom.GetMenuActions();
        }

        public void DeleteMenuAction(long menuActionId)
        {
            menuCom.DeleteMenuAction(menuActionId);
        }

        public void SaveMenuGroup(MislbdMenuGroup milsbdMenuGroup)
        {
            menuCom.SaveMenuGroup(milsbdMenuGroup);
        }

        public List<MislbdMenuGroup> GetMenuGroups()
        {
            return menuCom.GetMenuGroups();
        }

        public List<MislbdMenu> GetMenuForGroup(long groupId)
        {
            return menuCom.GetMenuForGroup(groupId);
        }

        public void DeleteMenuGroup(long groupId)
        {
            menuCom.DeleteMenuGroup(groupId);
        }

        public void AddMenuToGroup(MislbdMenu menu, MislbdMenuGroup menuGroup)
        {
            menuCom.SaveMenu(menu, menuGroup);
        }

        public void AddMenuToMenu(MislbdMenu menu, MislbdMenu parentMenu)
        {
            menuCom.SaveMenu(menu, parentMenu);
        }
    }

    class ToolStripActionMenuItem : ToolStripMenuItem
    {

        private String _action;

        public ToolStripActionMenuItem(string action, string menuName, EventHandler eventHandler)
            : base(menuName, null, eventHandler)
        {
            this._action = action;
        }

        public String Action
        {
            get { return _action; }
            set { _action = value; }
        }
    }
}
