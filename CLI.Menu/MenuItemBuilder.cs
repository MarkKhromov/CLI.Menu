using System;

namespace CLI.Menu {
    public class MenuItemBuilder {
        #region Inner classes
        public class MenuItemInfo {
            internal MenuItemInfo() {
                Key = null;
            }

            public string Name { get; set; }
            public Action Action { get; set; }
            internal ConsoleKey? Key { get; set; }
        }
        #endregion

        public MenuItemBuilder(string name, Action action) {
            Info = new MenuItemInfo {
                Name = name,
                Action = action
            };
        }

        public MenuItemInfo Info { get; }
    }
}