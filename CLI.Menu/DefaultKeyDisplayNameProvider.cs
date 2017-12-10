using System;

namespace CLI.Menu {
    public class DefaultDisplayNameProvider : IDisplayNameProvider {
        public static DefaultDisplayNameProvider Instance = new DefaultDisplayNameProvider();

        protected DefaultDisplayNameProvider() { }

        public virtual string MenuTitle => "Menu:";

        public virtual string NextDisplayName => "Next";

        public virtual string BackDisplayName => "Back";

        public virtual string ExitDisplayName => "Exit";

        public virtual string GetDisplayName(ConsoleKey? key) {
            switch(key) {
                case ConsoleKey.D0:
                    return "0";
                case ConsoleKey.D1:
                    return "1";
                case ConsoleKey.D2:
                    return "2";
                case ConsoleKey.D3:
                    return "3";
                case ConsoleKey.D4:
                    return "4";
                case ConsoleKey.D5:
                    return "5";
                case ConsoleKey.D6:
                    return "6";
                case ConsoleKey.D7:
                    return "7";
                case ConsoleKey.D8:
                    return "8";
                case ConsoleKey.D9:
                    return "9";
                default:
                    return "Undefined";
            }
        }
    }
}