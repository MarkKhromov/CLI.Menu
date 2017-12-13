using System;
using NUnit.Framework;

namespace CLI.Menu.Tests {
    [TestFixture]
    public class DisplayNameProviderTests {
        [Test]
        public void DefaultProviderTest() {
            IDisplayNameProvider defaultProvider = DefaultDisplayNameProvider.Instance;
            Assert.AreEqual("0", defaultProvider.GetDisplayName(0));
            Assert.AreEqual("1", defaultProvider.GetDisplayName(1));
            Assert.AreEqual("2", defaultProvider.GetDisplayName(2));
            Assert.AreEqual("3", defaultProvider.GetDisplayName(3));
            Assert.AreEqual("4", defaultProvider.GetDisplayName(4));
            Assert.AreEqual("5", defaultProvider.GetDisplayName(5));
            Assert.AreEqual("6", defaultProvider.GetDisplayName(6));
            Assert.AreEqual("7", defaultProvider.GetDisplayName(7));
            Assert.AreEqual("8", defaultProvider.GetDisplayName(8));
            Assert.AreEqual("9", defaultProvider.GetDisplayName(9));
            Assert.AreEqual("10", defaultProvider.GetDisplayName(10));
            Assert.AreEqual("-1", defaultProvider.GetDisplayName(-1));
        }

        [Test]
        public void CustomProviderTest() {
            IDisplayNameProvider defaultProvider = new CustomKeyDisplayNameProvider();
            Assert.AreEqual("Test text 1", defaultProvider.GetDisplayName(1));
            Assert.AreEqual("Test text 2", defaultProvider.GetDisplayName(2));
            Assert.AreEqual("Test text 2", defaultProvider.GetDisplayName(-1));
        }

        class CustomKeyDisplayNameProvider : IDisplayNameProvider {
            string IDisplayNameProvider.MenuTitle => throw new NotImplementedException();
            string IDisplayNameProvider.NextDisplayName => throw new NotImplementedException();
            string IDisplayNameProvider.BackDisplayName => throw new NotImplementedException();
            string IDisplayNameProvider.ExitDisplayName => throw new NotImplementedException();
            string IDisplayNameProvider.GetDisplayName(int key) {
                switch(key) {
                    case 1:
                        return "Test text 1";
                    default:
                        return "Test text 2";
                }
            }
        }
    }
}