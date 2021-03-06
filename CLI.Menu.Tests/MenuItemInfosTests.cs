﻿using System.Linq;
using NUnit.Framework;

namespace CLI.Menu.Tests {
    [TestFixture]
    public class MenuItemInfosTests {
        [Test]
        public void AddTest() {
            var menuBuilder = new MenuBuilder();
            var menuItemInfos = menuBuilder.Items;
            Assert.AreEqual(0, menuItemInfos.Count());
            menuItemInfos.Add(new MenuItemBuilder(null, null));
            Assert.AreEqual(1, menuItemInfos.Count());
            menuItemInfos.Add(new MenuItemBuilder(null, null));
            Assert.AreEqual(2, menuItemInfos.Count());
            menuItemInfos.Add(new MenuItemBuilder(null, null));
            Assert.AreEqual(3, menuItemInfos.Count());
            menuItemInfos.Add(new MenuItemBuilder(null, null));
            Assert.AreEqual(4, menuItemInfos.Count());
            menuItemInfos.Add(new MenuItemBuilder(null, null));
            Assert.AreEqual(5, menuItemInfos.Count());
            menuItemInfos.Add(new MenuItemBuilder(null, null));
            Assert.AreEqual(6, menuItemInfos.Count());
            menuItemInfos.Add(new MenuItemBuilder(null, null));
            Assert.AreEqual(7, menuItemInfos.Count());
            menuItemInfos.Add(new MenuItemBuilder(null, null));
            Assert.AreEqual(8, menuItemInfos.Count());
            menuItemInfos.Add(new MenuItemBuilder(null, null));
            Assert.AreEqual(9, menuItemInfos.Count());
            menuItemInfos.Add(new MenuItemBuilder(null, null));
            Assert.AreEqual(10, menuItemInfos.Count());
        }

        [Test]
        public void AccessByConsoleKeyTest() {
            var menuBuilder = new MenuBuilder();
            var menuItemInfos = menuBuilder.Items;
            var menuItem1 = new MenuItemBuilder(null, null);
            var menuItem2 = new MenuItemBuilder(null, null);
            Assert.AreNotEqual(menuItem1, menuItem2);
            Assert.AreEqual(0, menuItemInfos.Count());
            menuItemInfos.Add(menuItem1);
            Assert.AreEqual(1, menuItemInfos.Count());
            menuItemInfos.Add(menuItem2);
            Assert.AreEqual(2, menuItemInfos.Count());
            Assert.AreEqual(menuItem1, menuItemInfos[1]);
            Assert.AreEqual(menuItem2, menuItemInfos[2]);
            Assert.AreEqual(null, menuItemInfos[3]);
        }
    }
}