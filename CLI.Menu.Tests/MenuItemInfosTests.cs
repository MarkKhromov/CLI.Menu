using System;
using NUnit.Framework;

namespace CLI.Menu.Tests {
    [TestFixture]
    public class MenuItemInfosTests {
        [Test]
        public void AddTest() {
            var menuItemInfos = new MenuItemInfos();
            Assert.IsTrue(menuItemInfos.Add(new MenuItemInfo(null, null)));
            Assert.IsTrue(menuItemInfos.Add(new MenuItemInfo(null, null)));
            Assert.IsTrue(menuItemInfos.Add(new MenuItemInfo(null, null)));
            Assert.IsTrue(menuItemInfos.Add(new MenuItemInfo(null, null)));
            Assert.IsTrue(menuItemInfos.Add(new MenuItemInfo(null, null)));
            Assert.IsTrue(menuItemInfos.Add(new MenuItemInfo(null, null)));
            Assert.IsTrue(menuItemInfos.Add(new MenuItemInfo(null, null)));
            Assert.IsTrue(menuItemInfos.Add(new MenuItemInfo(null, null)));
            Assert.IsTrue(menuItemInfos.Add(new MenuItemInfo(null, null)));
            Assert.IsFalse(menuItemInfos.Add(new MenuItemInfo(null, null)));
        }

        [Test]
        public void AccessByConsoleKeyTest() {
            var menuItemInfos = new MenuItemInfos();
            var menuItem1 = new MenuItemInfo(null, null);
            var menuItem2 = new MenuItemInfo(null, null);
            Assert.AreNotEqual(menuItem1, menuItem2);
            Assert.IsTrue(menuItemInfos.Add(menuItem1));
            Assert.IsTrue(menuItemInfos.Add(menuItem2));
            Assert.AreEqual(menuItem1, menuItemInfos[ConsoleKey.D1]);
            Assert.AreEqual(menuItem2, menuItemInfos[ConsoleKey.D2]);
            Assert.AreEqual(null, menuItemInfos[ConsoleKey.D3]);
        }
    }
}