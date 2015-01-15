using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jeu;

namespace UnitTests
/// <summary>
/// Tests sur les combats
/// </summary>
{
    [TestClass]
    public class UnitTestFight
    {
        [TestMethod]
        public void TestSimpleFight()
        {
            CreateBuilder c = new CreateBuilder(MapSize.Small, Species.Dwarf, Species.Elf);
            Unit u1 = c.game.getPeople(0).units[0];
            Unit u2 = c.game.getPeople(1).units[0];
            Boolean b = u1.SimpleFight(u2.axis, u2.ordinate, c.game);
            Assert.AreEqual(true, b);
        }
    }
}
