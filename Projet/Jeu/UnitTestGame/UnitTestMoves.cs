using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jeu;

namespace UnitTests
/// <summary>
/// Tests sur les déplacements des unités Nain
/// </summary>
{
    [TestClass]
    public class UnitTestMoves
    {
        [TestMethod]
        public void TestOneMove()
        {
            UnitDwarf ud = new UnitDwarf();

            StrategySmall sts = new StrategySmall();
            Map m1 = sts.instantiate();
            Object o1 = ud.movePoints;
            ud.move(1, 2);
            Object o2 = ud.movePoints + 1;
            Assert.IsInstanceOfType(o1, typeof(int));
            Assert.IsInstanceOfType(o2, typeof(int));
            Assert.AreEqual(o1, o2);
        }
    }
}
