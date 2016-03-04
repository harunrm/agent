using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.menu;

namespace MISL.Ababil.Agent.Communication
{
    public class MenuCom
    {
        public List<MislbdMenu> GetUserMenu()
        {
            GatewayClient<List<MislbdMenu>> menuRequest = new GatewayClient<List<MislbdMenu>>();
            List<MislbdMenu> menus = menuRequest.Get(SessionInfo.rootServiceUrl + "resources/security/menu");
            return menus;
        }

        public void SaveMenuAction(MislbdMenuAction action)
        {
            GatewayClient<long> menuActionRequest = new GatewayClient<long>();
            action.id = menuActionRequest.PostJson(SessionInfo.rootServiceUrl + "resources/security/menu/action", action);
        }

        public List<MislbdMenuAction> GetMenuActions()
        {
            GatewayClient<List<MislbdMenuAction>> menuActionRequest = new GatewayClient<List<MislbdMenuAction>>();
            List<MislbdMenuAction> menuActions = menuActionRequest.Get(SessionInfo.rootServiceUrl + "resources/security/menu/action");
            return menuActions;
        }

        public void DeleteMenuAction(long menuActionId)
        {
            GatewayClient<MislbdMenuAction> menuActionRequest = new GatewayClient<MislbdMenuAction>();
            menuActionRequest.Delete(SessionInfo.rootServiceUrl + "resources/security/menu/action/" + menuActionId);
        }

        public void SaveMenuGroup(MislbdMenuGroup milsbdMenuGroup)
        {
            GatewayClient<long> menuGroupRequest = new GatewayClient<long>();
            milsbdMenuGroup.id = menuGroupRequest.PostJson(SessionInfo.rootServiceUrl + "resources/security/menu/group", milsbdMenuGroup);
        }

        public List<MislbdMenuGroup> GetMenuGroups()
        {
            GatewayClient<List<MislbdMenuGroup>> menuGroupRequest = new GatewayClient<List<MislbdMenuGroup>>();
            List<MislbdMenuGroup> groups = menuGroupRequest.Get(SessionInfo.rootServiceUrl + "resources/security/menu/group");
            return groups;
        }

        public List<MislbdMenu> GetMenuForGroup(long groupId)
        {
            GatewayClient<List<MislbdMenu>> menuRequest = new GatewayClient<List<MislbdMenu>>();
            List<MislbdMenu> menus = menuRequest.Get(SessionInfo.rootServiceUrl + "resources/security/menu/"+groupId+"/gid");
            return menus;
        }

        public void DeleteMenuGroup(long groupId)
        {
            GatewayClient<MislbdMenuGroup> menuActionRequest = new GatewayClient<MislbdMenuGroup>();
            menuActionRequest.Delete(SessionInfo.rootServiceUrl + "resources/security/menu/group/" + groupId);
        }

        public void SaveMenu(MislbdMenu menu, MislbdMenuGroup menuGroup)
        {
            GatewayClient<MislbdMenu> menuRequest = new GatewayClient<MislbdMenu>();
            MislbdMenu smenu = menuRequest.PostJson(SessionInfo.rootServiceUrl + "resources/security/menu/" + menuGroup.id + "/GID", menu);
            menu.menuIndex = smenu.menuIndex;
            menu.id = smenu.id;
        }

        public void SaveMenu(MislbdMenu menu, MislbdMenu parentMenu)
        {
            GatewayClient<MislbdMenu> menuRequest = new GatewayClient<MislbdMenu>();
            MislbdMenu smenu = menuRequest.PostJson(SessionInfo.rootServiceUrl + "resources/security/menu/" + parentMenu.id + "/MID", menu);
            menu.menuIndex = smenu.menuIndex;
            menu.id = smenu.id;
        }

    }
}
