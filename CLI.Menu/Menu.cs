using System;

namespace CLI.Menu {
    public static class Menu {
        // TODO: Test it!
        public static void Show(MenuInfo info) {
            ConsoleKey key;
            do {
                Console.Clear();
                if(!string.IsNullOrWhiteSpace(info.Name)) {
                    Console.WriteLine();
                    Console.WriteLine($"\t{info.Name}");
                }
                Console.WriteLine();
                foreach(var item in info.ItemInfos) {
                    Console.WriteLine($"\t{(info.KeyDisplayNameProvider ?? DefaultKeyDisplayNameProvider.Instance).GetDisplayName(item.Key)}. {item.Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"\t0. {info.ExitName}");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\t");
                key = Console.ReadKey(true).Key;
                var action = info.ItemInfos[key]?.Action;
                if(action != null) {
                    Console.Clear();
                    action();
                }
            } while(key != ConsoleKey.D0);
        }
    }
}