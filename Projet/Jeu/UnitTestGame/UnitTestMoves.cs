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
            CreateBuilder c = new CreateBuilder(MapSize.Small, Species.Dwarf, Species.Elf);
            Unit u1 = c.game.getPeople(0).units[0];

            Boolean b = u1.isNeighbour(1, 0, c.game.Map);
            Assert.AreEqual(true, b);
        }
    }
}
