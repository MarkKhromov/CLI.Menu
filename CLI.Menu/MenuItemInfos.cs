using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CLI.Menu {
    public class MenuItemInfos : IEnumerable<MenuItemInfo> {
        public MenuItemInfos() {
            items = new Collection<MenuItemInfo>();
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

        public MenuItemInfo this[ConsoleKey key] => items.SingleOrDefault(x => x.Key == key);

        readonly Collection<MenuItemInfo> items;
        readonly Queue<ConsoleKey> available;
        MenuInfo nextMenuInfo;

        public bool Add(MenuItemInfo itemInfo) {
            try {
                if(items.Count == 9 && nextMenuInfo == null) {
                    nextMenuInfo = new MenuInfo {
                        ExitName = "Back",
                        KeyDisplayNameProvider = DefaultKeyDisplayNameProvider.Instance,
                        Name = "Menu:"
                    };
                    var nextItemInfo = new MenuItemInfo("Next", () => {
                        new Menu(nextMenuInfo).Show();
                    });
                    var lastItemInfo = this[ConsoleKey.D9];
                    items.Remove(lastItemInfo);
                    available.Enqueue(ConsoleKey.D9);
                    items.Add(nextItemInfo);
                    nextItemInfo.Key = available.Dequeue();
                    nextMenuInfo.ItemInfos.Add(lastItemInfo);
                    nextMenuInfo.ItemInfos.Add(itemInfo);
                    return true;
                }
                if(nextMenuInfo != null) {
                    nextMenuInfo.ItemInfos.Add(itemInfo);
                    return true;
                }
                items.Add(itemInfo);
                itemInfo.Key = available.Dequeue();
                return true;
            } catch { return false; }
        }

        IEnumerator<MenuItemInfo> IEnumerable<MenuItemInfo>.GetEnumerator() {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return items.GetEnumerator();
        }
    }
}