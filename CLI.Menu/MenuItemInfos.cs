using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CLI.Menu {
    public class MenuItemInfos : IEnumerable<MenuItemBuilder> {
        #region Inner classes
        class InnerMenuKeyDisplayNameProvider : IKeyDisplayNameProvider {
            public InnerMenuKeyDisplayNameProvider(IKeyDisplayNameProvider parentKeyDisplayNameProvider) {
                this.parentKeyDisplayNameProvider = parentKeyDisplayNameProvider;
            }

            readonly IKeyDisplayNameProvider parentKeyDisplayNameProvider;

            string IKeyDisplayNameProvider.MenuTitle => parentKeyDisplayNameProvider.MenuTitle;
            string IKeyDisplayNameProvider.NextButtonText => parentKeyDisplayNameProvider.NextButtonText;
            string IKeyDisplayNameProvider.BackButtonText => parentKeyDisplayNameProvider.BackButtonText;
            string IKeyDisplayNameProvider.ExitButtonText => parentKeyDisplayNameProvider.BackButtonText;
            string IKeyDisplayNameProvider.GetDisplayName(ConsoleKey? key) => parentKeyDisplayNameProvider.GetDisplayName(key);
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
                nextMenuBuilder = MenuBuilder.Create(new InnerMenuKeyDisplayNameProvider(menuBuilder.Info.KeyDisplayNameProvider));
                    //.Set(x => x.Name, menuBuilder.Info.Name)
                    //.Set(x => x.NextName, menuBuilder.Info.NextName)
                    //.Set(x => x.BackName, menuBuilder.Info.BackName)
                    //.Set(x => x.ExitName, menuBuilder.Info.BackName)
                    //.Set(x => x.KeyDisplayNameProvider, DefaultKeyDisplayNameProvider.Instance)
                var nextItemInfo = new MenuItemBuilder(menuBuilder.Info.KeyDisplayNameProvider.NextButtonText, nextMenuBuilder.Show);
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