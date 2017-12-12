using System;
using System.ComponentModel;

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
        [DefaultValue(true)]
        public bool ShowIndents { get; set; } = true;

        public MenuBuilder Item(string name, Action action) {
            var item = new MenuItemBuilder(name, action);
            Items.Add(item);
            return this;
        }

        public MenuBuilder Indents(bool value) {
            ShowIndents = value;
            return this;
        }

        // TODO: Test it!
        public void Show() {
            ConsoleKey key;
            do {
                Console.Clear();
                if(!string.IsNullOrWhiteSpace(DisplayNameProvider.MenuTitle)) {
                    Console.WriteLine();
                    ShowIndentIfNeeded();
                    Console.WriteLine($"{DisplayNameProvider.MenuTitle}");
                }
                Console.WriteLine();
                foreach(var item in Items) {
                    ShowIndentIfNeeded();
                    Console.WriteLine($"{(DisplayNameProvider).GetDisplayName(item.Key)}. {item.Name}");
                }
                Console.WriteLine();
                ShowIndentIfNeeded();
                Console.WriteLine($"{DisplayNameProvider.GetDisplayName(ConsoleKey.D0)}. {DisplayNameProvider.ExitDisplayName}");
                Console.WriteLine();
                Console.WriteLine();
                ShowIndentIfNeeded();
                key = Console.ReadKey(true).Key;
                var action = Items[key]?.Action;
                if(action != null) {
                    Console.Clear();
                    action();
                }
            } while(key != ConsoleKey.D0);
        }

        void ShowIndentIfNeeded() {
            if(ShowIndents) {
                Console.Write("\t");
            }
        }
    }
}