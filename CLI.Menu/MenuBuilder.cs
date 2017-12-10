using System;
using System.Linq.Expressions;

namespace CLI.Menu {
    public class MenuBuilder {
        #region Inner classes
        public class MenuInfo {
            internal MenuInfo() { }

            IKeyDisplayNameProvider keyDisplayNameProvider;
            public IKeyDisplayNameProvider KeyDisplayNameProvider {
                get => keyDisplayNameProvider;
                set => keyDisplayNameProvider = value ?? DefaultKeyDisplayNameProvider.Instance;
            }
        }
        #endregion

        public static MenuBuilder Create(IKeyDisplayNameProvider keyDisplayNameProvider = null) {
            return new MenuBuilder(keyDisplayNameProvider);
        }

        public MenuBuilder(IKeyDisplayNameProvider keyDisplayNameProvider = null) {
            Info = new MenuInfo { KeyDisplayNameProvider = keyDisplayNameProvider };
            Items = new MenuItemInfos(this);
        }

        public MenuInfo Info { get; }
        public MenuItemInfos Items { get; }

        public MenuBuilder Set<T>(Expression<Func<MenuInfo, T>> accessor, T value) {
            Info.GetType().GetProperty(((MemberExpression)accessor.Body).Member.Name).SetValue(Info, value);
            return this;
        }

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
                if(!string.IsNullOrWhiteSpace(Info.KeyDisplayNameProvider.MenuTitle)) {
                    Console.WriteLine();
                    Console.WriteLine($"\t{Info.KeyDisplayNameProvider.MenuTitle}");
                }
                Console.WriteLine();
                foreach(var item in Items) {
                    Console.WriteLine($"\t{(Info.KeyDisplayNameProvider).GetDisplayName(item.Info.Key)}. {item.Info.Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"\t0. {Info.KeyDisplayNameProvider.ExitButtonText}");
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