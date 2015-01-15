using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jeu;

namespace UnitTests
/// <summary>
/// Tests sur les déplacements des unités 
/// </summary>
{
    [TestClass]
    public class UnitTestMoves
    {
        [TestMethod]
        // Test de la fonction opponent(Game g) de la classe Unit
        public void TestOpponent()
        {
            CreateBuilder c = new CreateBuilder(MapSize.Small, Species.Dwarf, Species.Elf);
            Unit u1 = c.game.getPeople(0).units[0];
            int o1 = u1.opponent(c.game);
            Assert.AreEqual(1, o1);
            Unit u2 = c.game.getPeople(1).units[0];
            int o2 = u2.opponent(c.game);
            Assert.AreEqual(0, o2);
        }

        [TestMethod]
        // Test de la fonction possibleMove() de la classe Unit
        public void TestPossibleMove()
        {
            CreateBuilder c = new CreateBuilder(MapSize.Small, Species.Dwarf, Species.Elf);
            Unit u1 = c.game.getPeople(0).units[0];
            Boolean b = u1.possibleMove(u1.axis + 1, u1.ordinate + 1, c.game);
            Assert.AreEqual(true, b);
        }
    }
}
