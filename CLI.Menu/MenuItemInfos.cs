using System.Collections;
using System.Collections.Generic;

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
            string IDisplayNameProvider.GetDisplayName(int key) => parentDisplayNameProvider.GetDisplayName(key);
        }
        #endregion

        internal MenuItemInfos(MenuBuilder menuBuilder) {
            this.menuBuilder = menuBuilder;
            items = new Dictionary<int, MenuItemBuilder>();
        }

        public MenuItemBuilder this[int key] {
            get {
                MenuItemBuilder item = null;
                items.TryGetValue(key, out item);
                return item;
            }
        }

        public int Count { get { return items.Count; } }

        readonly MenuBuilder menuBuilder;
        readonly Dictionary<int, MenuItemBuilder> items;
        int currentItemNumber = 1;

        public void Add(MenuItemBuilder itemInfo) {
            itemInfo.Key = currentItemNumber;
            items.Add(currentItemNumber, itemInfo);
            currentItemNumber++;
        }

        IEnumerator<MenuItemBuilder> IEnumerable<MenuItemBuilder>.GetEnumerator() {
            return items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return items.GetEnumerator();
        }
    }
}