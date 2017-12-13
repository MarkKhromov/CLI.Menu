namespace CLI.Menu {
    public class DefaultDisplayNameProvider : IDisplayNameProvider {
        public static DefaultDisplayNameProvider Instance = new DefaultDisplayNameProvider();

        protected DefaultDisplayNameProvider() { }

        public virtual string MenuTitle => "Menu:";

        public virtual string NextDisplayName => "Next";

        public virtual string BackDisplayName => "Back";

        public virtual string ExitDisplayName => "Exit";

        public virtual string GetDisplayName(int key) {
            return key.ToString();
        }
    }
}