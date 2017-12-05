namespace CLI.Menu {
    public struct MenuInfo {
        public string Name { get; set; }
        public string ExitName { get; set; }
        public MenuItemInfos ItemInfos { get; set; }
        public IKeyDisplayNameProvider KeyDisplayNameProvider { get; set; }
    }
}