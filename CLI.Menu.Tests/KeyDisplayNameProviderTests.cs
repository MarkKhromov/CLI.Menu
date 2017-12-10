using System;
using NUnit.Framework;

namespace CLI.Menu.Tests {
    [TestFixture]
    public class KeyDisplayNameProviderTests {
        [Test]
        public void DefaultProviderTest() {
            IKeyDisplayNameProvider defaultProvider = DefaultKeyDisplayNameProvider.Instance;
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
            IKeyDisplayNameProvider defaultProvider = new CustomKeyDisplayNameProvider();
            Assert.AreEqual("Test text 1", defaultProvider.GetDisplayName(ConsoleKey.A));
            Assert.AreEqual("Test text 2", defaultProvider.GetDisplayName(null));
            Assert.AreEqual("Test text 2", defaultProvider.GetDisplayName(ConsoleKey.B));
        }

        class CustomKeyDisplayNameProvider : IKeyDisplayNameProvider {
            string IKeyDisplayNameProvider.MenuTitle => throw new NotImplementedException();
            string IKeyDisplayNameProvider.NextButtonText => throw new NotImplementedException();
            string IKeyDisplayNameProvider.BackButtonText => throw new NotImplementedException();
            string IKeyDisplayNameProvider.ExitButtonText => throw new NotImplementedException();
            string IKeyDisplayNameProvider.GetDisplayName(ConsoleKey? key) {
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