using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jeu;

namespace UnitTestGame
{
    [TestClass]
    public class UnitTestMap
    {

        [TestMethod]
        public void TestMapSize()
        {
            Map m1 = new Map(1);
            Object o1 = m1.size;
            Assert.IsInstanceOfType(o1, typeof(int));
            Assert.AreEqual(o1, 6);

            Map m2 = new Map(2);
            Object o2 = m2.size;
            Assert.IsInstanceOfType(o2, typeof(int));
            Assert.AreEqual(o2, 10);

            Map m3 = new Map(3);
            Object o3 = m3.size;
            Assert.IsInstanceOfType(o3, typeof(int));
            Assert.AreEqual(o3, 14);
        }
        
    }
}
