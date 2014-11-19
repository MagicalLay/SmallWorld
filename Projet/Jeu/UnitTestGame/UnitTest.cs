using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGame
{
    [TestClass]
    public class UnitTest
    {
        public void TestMap(Map m)
        {
            Object o = m.getTaille();
            Assert.IsInstanceOfType(o, int);
        }
        [TestMethod]
        

    }
}
