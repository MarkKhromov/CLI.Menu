using System;

namespace CLI.Menu {
    public class MenuBuilder {
        #region Inner classes
        public class MenuInfo {
            internal MenuInfo() { }

            IDisplayNameProvider displayNameProvider;
            public IDisplayNameProvider DisplayNameProvider {
                get => displayNameProvider;
                set => displayNameProvider = value ?? DefaultDisplayNameProvider.Instance;
            }
        }
        #endregion

        public static MenuBuilder Create(IDisplayNameProvider displayNameProvider = null) {
            return new MenuBuilder(displayNameProvider);
        }

        public MenuBuilder(IDisplayNameProvider displayNameProvider = null) {
            Info = new MenuInfo { DisplayNameProvider = displayNameProvider };
            Items = new MenuItemInfos(this);
        }

        public MenuInfo Info { get; }
        public MenuItemInfos Items { get; }

        public MenuBuilder Item(string name, Action action) {
            var item = new MenuItemBuilder(name, action);
            Items.Add(item);
            return this;
        }

        // TODO: Test it!
        public void Show() {
            ConsoleKey key;
            do {
                Console.Clear();
                if(!string.IsNullOrWhiteSpace(Info.DisplayNameProvider.MenuTitle)) {
                    Console.WriteLine();
                    Console.WriteLine($"\t{Info.DisplayNameProvider.MenuTitle}");
                }
                Console.WriteLine();
                foreach(var item in Items) {
                    Console.WriteLine($"\t{(Info.DisplayNameProvider).GetDisplayName(item.Info.Key)}. {item.Info.Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"\t0. {Info.DisplayNameProvider.ExitDisplayName}");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\t");
                key = Console.ReadKey(true).Key;
                var action = Items[key]?.Info.Action;
                if(action != null) {
                    Console.Clear();
                    action();
                }
            } while(key != ConsoleKey.D0);
        }
    }
}