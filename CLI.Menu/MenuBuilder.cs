using System;

namespace CLI.Menu {
    public class MenuBuilder {
        public static MenuBuilder Create(IDisplayNameProvider displayNameProvider = null) {
            return new MenuBuilder(displayNameProvider);
        }

        public MenuBuilder(IDisplayNameProvider displayNameProvider = null) {
            DisplayNameProvider = displayNameProvider;
            Items = new MenuItemInfos(this);
        }

        IDisplayNameProvider displayNameProvider;
        public IDisplayNameProvider DisplayNameProvider {
            get => displayNameProvider;
            set => displayNameProvider = value ?? DefaultDisplayNameProvider.Instance;
        }
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
                if(!string.IsNullOrWhiteSpace(DisplayNameProvider.MenuTitle)) {
                    Console.WriteLine();
                    Console.WriteLine($"\t{DisplayNameProvider.MenuTitle}");
                }
                Console.WriteLine();
                foreach(var item in Items) {
                    Console.WriteLine($"\t{(DisplayNameProvider).GetDisplayName(item.Key)}. {item.Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"\t{DisplayNameProvider.GetDisplayName(ConsoleKey.D0)}. {DisplayNameProvider.ExitDisplayName}");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\t");
                key = Console.ReadKey(true).Key;
                var action = Items[key]?.Action;
                if(action != null) {
                    Console.Clear();
                    action();
                }
            } while(key != ConsoleKey.D0);
        }
    }
}