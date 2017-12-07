using System;
using System.Threading;

namespace CLI.Menu.Demo {
    class Program {
        static void Main(string[] args) {
            Menu.Show(new MenuInfo {
                ItemInfos = {
                    new MenuItemInfo(@"Show ""Test 1"" text and sleep 3 seconds", () => {
                        Console.WriteLine("Test 1");
                        Thread.Sleep(3000);
                    }),
                    new MenuItemInfo("Show sub-menu", () => {
                        Menu.Show(new MenuInfo {
                            ItemInfos = {
                                new MenuItemInfo(@"Show ""Test 2"" text and sleep 5 seconds", () => {
                                    Console.WriteLine("Test 2");
                                    Thread.Sleep(5000);
                                })
                            },
                            ExitName = "Back",
                            Name = "Sub-menu 1:"
                        });
                    }),
                    new MenuItemInfo(@"Show ""Test 3"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 3");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 4"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 4");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 5"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 5");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 6"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 6");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 7"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 7");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 8"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 8");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 9"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 9");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 10"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 10");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 11"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 11");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 12"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 12");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 13"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 13");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 14"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 14");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 15"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 15");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 16"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 16");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 17"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 17");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 18"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 18");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 19"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 19");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 20"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 20");
                        Thread.Sleep(1000);
                    }),
                    new MenuItemInfo(@"Show ""Test 21"" text and sleep 1 seconds", () => {
                        Console.WriteLine("Test 21");
                        Thread.Sleep(1000);
                    })
                },
                ExitName = "Exit",
                Name = "Menu:"
            });
        }
    }
}