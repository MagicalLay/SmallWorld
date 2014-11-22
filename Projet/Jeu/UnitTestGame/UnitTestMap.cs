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
            Map m1 = new Map(MapSize.Small);
            Object o1 = m1.Size;
            Assert.IsInstanceOfType(o1, typeof(int));
            Assert.AreEqual(o1, 6);

            Map m2 = new Map(MapSize.Medium);
            Object o2 = m2.Size;
            Assert.IsInstanceOfType(o2, typeof(int));
            Assert.AreEqual(o2, 10);

            Map m3 = new Map(MapSize.Large);
            Object o3 = m3.Size;
            Assert.IsInstanceOfType(o3, typeof(int));
            Assert.AreEqual(o3, 14);
        }
        
    }
}
