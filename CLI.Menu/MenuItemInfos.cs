using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CLI.Menu {
    public class MenuItemInfos : IEnumerable<MenuItemBuilder> {
        #region Inner classes
        class InnerMenuDisplayNameProvider : IDisplayNameProvider {
            public InnerMenuDisplayNameProvider(IDisplayNameProvider parentDisplayNameProvider) {
                this.parentDisplayNameProvider = parentDisplayNameProvider;
            }

            readonly IDisplayNameProvider parentDisplayNameProvider;

            string IDisplayNameProvider.MenuTitle => parentDisplayNameProvider.MenuTitle;
            string IDisplayNameProvider.NextDisplayName => parentDisplayNameProvider.NextDisplayName;
            string IDisplayNameProvider.BackDisplayName => parentDisplayNameProvider.BackDisplayName;
            string IDisplayNameProvider.ExitDisplayName => parentDisplayNameProvider.BackDisplayName;
            string IDisplayNameProvider.GetDisplayName(ConsoleKey? key) => parentDisplayNameProvider.GetDisplayName(key);
        }
        #endregion

        internal MenuItemInfos(MenuBuilder menuBuilder) {
            this.menuBuilder = menuBuilder;
            items = new Collection<MenuItemBuilder>();
            available = new Queue<ConsoleKey>(new[] {
                ConsoleKey.D1,
                ConsoleKey.D2,
                ConsoleKey.D3,
                ConsoleKey.D4,
                ConsoleKey.D5,
                ConsoleKey.D6,
                ConsoleKey.D7,
                ConsoleKey.D8,
                ConsoleKey.D9
            });
        }

        public MenuItemBuilder this[ConsoleKey key] => items.SingleOrDefault(x => x.Info.Key == key);

        readonly MenuBuilder menuBuilder;
        readonly Collection<MenuItemBuilder> items;
        readonly Queue<ConsoleKey> available;
        MenuBuilder nextMenuBuilder;

        public void Add(MenuItemBuilder itemInfo) {
            if(items.Count == 9 && nextMenuBuilder == null) {
                var parentInfo = menuBuilder.Info;
                nextMenuBuilder = MenuBuilder.Create(new InnerMenuDisplayNameProvider(menuBuilder.Info.DisplayNameProvider));
                var nextItemInfo = new MenuItemBuilder(menuBuilder.Info.DisplayNameProvider.NextDisplayName, nextMenuBuilder.Show);
                var lastItemInfo = this[ConsoleKey.D9];
                items.Remove(lastItemInfo);
                available.Enqueue(ConsoleKey.D9);
                items.Add(nextItemInfo);
                nextItemInfo.Info.Key = available.Dequeue();
                nextMenuBuilder.Items.Add(lastItemInfo);
                nextMenuBuilder.Items.Add(itemInfo);
                return;
            }
            if(nextMenuBuilder != null) {
                nextMenuBuilder.Items.Add(itemInfo);
                return;
            }
            items.Add(itemInfo);
            itemInfo.Info.Key = available.Dequeue();
        }

        IEnumerator<MenuItemBuilder> IEnumerable<MenuItemBuilder>.GetEnumerator() {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return items.GetEnumerator();
        }
    }
}