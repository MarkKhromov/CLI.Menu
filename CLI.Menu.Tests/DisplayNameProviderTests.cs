using System;
using NUnit.Framework;

namespace CLI.Menu.Tests {
    [TestFixture]
    public class DisplayNameProviderTests {
        [Test]
        public void DefaultProviderTest() {
            IDisplayNameProvider defaultProvider = DefaultDisplayNameProvider.Instance;
            Assert.AreEqual("0", defaultProvider.GetDisplayName(ConsoleKey.D0));
            Assert.AreEqual("1", defaultProvider.GetDisplayName(ConsoleKey.D1));
            Assert.AreEqual("2", defaultProvider.GetDisplayName(ConsoleKey.D2));
            Assert.AreEqual("3", defaultProvider.GetDisplayName(ConsoleKey.D3));
            Assert.AreEqual("4", defaultProvider.GetDisplayName(ConsoleKey.D4));
            Assert.AreEqual("5", defaultProvider.GetDisplayName(ConsoleKey.D5));
            Assert.AreEqual("6", defaultProvider.GetDisplayName(ConsoleKey.D6));
            Assert.AreEqual("7", defaultProvider.GetDisplayName(ConsoleKey.D7));
            Assert.AreEqual("8", defaultProvider.GetDisplayName(ConsoleKey.D8));
            Assert.AreEqual("9", defaultProvider.GetDisplayName(ConsoleKey.D9));
            Assert.AreEqual("Undefined", defaultProvider.GetDisplayName(null));
            Assert.AreEqual("Undefined", defaultProvider.GetDisplayName(ConsoleKey.A));
        }

        [Test]
        public void CustomProviderTest() {
            IDisplayNameProvider defaultProvider = new CustomKeyDisplayNameProvider();
            Assert.AreEqual("Test text 1", defaultProvider.GetDisplayName(ConsoleKey.A));
            Assert.AreEqual("Test text 2", defaultProvider.GetDisplayName(null));
            Assert.AreEqual("Test text 2", defaultProvider.GetDisplayName(ConsoleKey.B));
        }

        class CustomKeyDisplayNameProvider : IDisplayNameProvider {
            string IDisplayNameProvider.MenuTitle => throw new NotImplementedException();
            string IDisplayNameProvider.NextDisplayName => throw new NotImplementedException();
            string IDisplayNameProvider.BackDisplayName => throw new NotImplementedException();
            string IDisplayNameProvider.ExitDisplayName => throw new NotImplementedException();
            string IDisplayNameProvider.GetDisplayName(ConsoleKey? key) {
                switch(key) {
                    case ConsoleKey.A:
                        return "Test text 1";
                    default:
                        return "Test text 2";
                }
            }
        }
    }
}