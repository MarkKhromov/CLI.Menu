using System;

namespace CLI.Menu {
    public class MenuItemBuilder {
        public MenuItemBuilder(string name, Action action) {
            Name = name;
            Action = action;
            Key = null;
        }

        public string Name { get; set; }
        public Action Action { get; set; }
        internal ConsoleKey? Key { get; set; }
    }
}