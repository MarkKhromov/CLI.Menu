namespace CLI.Menu {
    public class MenuInfo {
        public MenuInfo() {
            ItemInfos = new MenuItemInfos();
        }

        public MenuItemInfos ItemInfos { get; }
        public string Name { get; set; }
        public string ExitName { get; set; }
        public IKeyDisplayNameProvider KeyDisplayNameProvider { get; set; }
    }
}