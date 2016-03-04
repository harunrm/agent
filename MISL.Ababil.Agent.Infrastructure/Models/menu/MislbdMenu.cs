using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.menu
{
    public class MislbdMenu
    {
        private long _id;
        private String _name;
		private MislbdMenuAction _menuAction;
        private List<MislbdMenu> _menuItems;
        private MislbdMenuType _menuType;
        private long _index;

        public long id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String name
        {
            get { return _name; }
            set { _name = value; }
        }

		public MislbdMenuAction menuAction
        {
			get { return _menuAction; }
			set { _menuAction = value; }
        }

        public List<MislbdMenu> menuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; }
        }

        public MislbdMenuType menuType
        {
            get { return _menuType; }
            set { _menuType = value; }
        }

        public long menuIndex
        {
            get { return _index; }
            set { _index = value; }
        }
    }
}
