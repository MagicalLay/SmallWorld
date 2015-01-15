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
            Assert.IsInstanceOfType(u1, typeof(UnitDwarf));
            int x = u1.Space.axis;
            int y = u1.Space.ordinate;
            Boolean b = c.game.getSpace(x, y).isNeighbour(c.game.getSpace(x + 1, y));
            Assert.AreEqual(true, b);
            //Boolean b = u1.move(x+1, y, c.game);
            //Assert.AreEqual(true, b);
        }
    }
}
