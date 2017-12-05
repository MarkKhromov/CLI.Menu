using System;
using System.Threading;

namespace CLI.Menu.Demo {
    class Program {
        static void Main(string[] args) {
            var info = new MenuInfo {
                ItemInfos = new MenuItemInfos {
                    new MenuItemInfo(@"Show ""Test 1"" text and sleep 3 seconds", () => {
                        Console.WriteLine("Test 1");
                        Thread.Sleep(3000);
                    }),
                    new MenuItemInfo("Show sub-menu", () => {
                        new Menu(new MenuInfo {
                            ItemInfos = new MenuItemInfos {
                                new MenuItemInfo(@"Show ""Test 2"" text and sleep 5 seconds", () => {
                                    Console.WriteLine("Test 2");
                                    Thread.Sleep(5000);
                                })
                            },
                            ExitName = "Back",
                            Name = "Sub-menu 1:"
                        }).Show();
                    })
                },
                ExitName = "Exit",
                Name = "Menu:"
            };
            new Menu(info).Show();
        }
    }
}