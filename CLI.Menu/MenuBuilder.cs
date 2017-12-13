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

        int startItemNumber = 1;
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
        public void Show(DisplayMode displayMode) {
            var key = -1;
            var nextNeeded = false;
            do {
                Console.Clear();
                if(!string.IsNullOrWhiteSpace(DisplayNameProvider.MenuTitle)) {
                    Console.WriteLine();
                    ShowIndentIfNeeded();
                    Console.WriteLine($"{DisplayNameProvider.MenuTitle}");
                }
                Console.WriteLine();
                switch(displayMode) {
                    case DisplayMode.Linear:
                        foreach(var item in Items) {
                            ShowIndentIfNeeded();
                            Console.WriteLine($"{(DisplayNameProvider).GetDisplayName(item.Key)}. {item.Name}");
                        }
                        break;
                    case DisplayMode.Separate:
                        nextNeeded = Items.Count > 9;
                        if(nextNeeded) {
                            var count = Math.Min(Items.Count - startItemNumber + 1, 8);
                            for(var i = 0; i < count; i++) {
                                var item = Items[startItemNumber + i];
                                ShowIndentIfNeeded();
                                Console.WriteLine($"{(DisplayNameProvider).GetDisplayName(i + 1)}. {item.Name}");
                            }
                            if(startItemNumber + count - 1 != Items.Count) {
                                ShowIndentIfNeeded();
                                Console.WriteLine($"{(DisplayNameProvider).GetDisplayName(9)}. {DisplayNameProvider.NextDisplayName}");
                            }
                        } else {
                            foreach(var item in Items) {
                                ShowIndentIfNeeded();
                                Console.WriteLine($"{(DisplayNameProvider).GetDisplayName(item.Key)}. {item.Name}");
                            }
                        }
                        break;
                    default:
                        throw new NotSupportedException();
                }
                Console.WriteLine();
                ShowIndentIfNeeded();
                var exitDisplayName = startItemNumber == 1 ? DisplayNameProvider.ExitDisplayName : DisplayNameProvider.BackDisplayName;
                Console.WriteLine($"{DisplayNameProvider.GetDisplayName(0)}. {exitDisplayName}");
                Console.WriteLine();
                Console.WriteLine();
                ShowIndentIfNeeded();
                if(!int.TryParse(Console.ReadLine(), out key)) {
                    continue;
                }
                if(nextNeeded) {
                    if(key > 9) {
                        continue;
                    }
                    if(key == 9) {
                        startItemNumber += 8;
                        Show(displayMode);
                        continue;
                    }
                }
                if(key == 0 && startItemNumber != 1) {
                    startItemNumber -= 8;
                } else {
                    var action = Items[key + startItemNumber - 1]?.Action;
                    if(action != null) {
                        Console.Clear();
                        action();
                    }
                }
            } while(key != 0);
        }

        void ShowIndentIfNeeded() {
            if(ShowIndents) {
                Console.Write("\t");
            }
        }
    }
}