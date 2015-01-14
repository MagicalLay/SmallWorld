using Jeu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTestMap
    {
        [TestMethod]
        public void TestMapSize()
        {
            StrategySmall sts = new StrategySmall();
            StrategyMedium stm = new StrategyMedium();
            StrategyLarge stl = new StrategyLarge();

            Map m1 = sts.instantiate();
            Object o1 = m1.Size;
            Assert.IsInstanceOfType(o1, typeof(int));
            Assert.AreEqual(o1, 6);

            Map m2 = stm.instantiate();
            Object o2 = m2.Size;
            Assert.IsInstanceOfType(o2, typeof(int));
            Assert.AreEqual(o2, 10);

            Map m3 = stl.instantiate();
            Object o3 = m3.Size;
            Assert.IsInstanceOfType(o3, typeof(int));
            Assert.AreEqual(o3, 14);
        }
    }
}
