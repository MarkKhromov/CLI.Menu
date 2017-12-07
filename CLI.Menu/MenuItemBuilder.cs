using System;
using System.Linq.Expressions;

namespace CLI.Menu {
    public class MenuItemBuilder {
        #region Inner classes
        public class MenuItemInfo {
            internal MenuItemInfo() { }

            public string Name { get; set; }
            public Action Action { get; set; }
        }
        #endregion

        public MenuItemBuilder(MenuBuilder menuBuilder) {
            this.menuBuilder = menuBuilder;
            Info = new MenuItemInfo();
            Key = null;
        }

        readonly MenuBuilder menuBuilder;
        internal ConsoleKey? Key;
        public MenuItemInfo Info { get; }

        public MenuItemBuilder Set<T>(Expression<Func<MenuItemInfo, T>> accessor, T value) {
            Info.GetType().GetProperty(((MemberExpression)accessor.Body).Member.Name).SetValue(Info, value);
            return this;
        }

        public MenuBuilder EndItem() {
            return menuBuilder;
        }
    }
}