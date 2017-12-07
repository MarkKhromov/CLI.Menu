using System;
using System.Linq.Expressions;

namespace CLI.Menu {
    public class MenuBuilder {
        #region Inner classes
        public class MenuInfo {
            internal MenuInfo() { }

            public string Name { get; set; }
            public string NextName { get; set; }
            public string BackName { get; set; }
            public string ExitName { get; set; }
            public IKeyDisplayNameProvider KeyDisplayNameProvider { get; set; }
        }
        #endregion

        public static MenuBuilder Create() {
            return new MenuBuilder();
        }

        public MenuBuilder() {
            Info = new MenuInfo();
            Items = new MenuItemInfos(this);
        }

        public MenuInfo Info { get; }
        public MenuItemInfos Items { get; }

        public MenuBuilder Set<T>(Expression<Func<MenuInfo, T>> accessor, T value) {
            Info.GetType().GetProperty(((MemberExpression)accessor.Body).Member.Name).SetValue(Info, value);
            return this;
        }

        public MenuItemBuilder Item() {
            var item = new MenuItemBuilder(this);
            Items.Add(item);
            return item;
        }

        // TODO: Test it!
        public void Show() {
            ConsoleKey key;
            do {
                Console.Clear();
                if(!string.IsNullOrWhiteSpace(Info.Name)) {
                    Console.WriteLine();
                    Console.WriteLine($"\t{Info.Name}");
                }
                Console.WriteLine();
                foreach(var item in Items) {
                    Console.WriteLine($"\t{(Info.KeyDisplayNameProvider ?? DefaultKeyDisplayNameProvider.Instance).GetDisplayName(item.Key)}. {item.Info.Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"\t0. {Info.ExitName}");
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