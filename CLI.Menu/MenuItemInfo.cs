using System;

namespace CLI.Menu {
    public class MenuItemInfo {
        public MenuItemInfo(string name, Action action) {
            Name = name;
            Action = action;
            Key = null;
        }

        public string Name { get; }
        public Action Action { get; }
        public ConsoleKey? Key { get; internal set; }
    }
}