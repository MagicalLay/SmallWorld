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
        // test de la version simple des combats
        public void TestSimpleFight()
        {
            CreateBuilder c = new CreateBuilder(MapSize.Small, Species.Dwarf, Species.Elf);
            Unit u1 = c.game.getPeople(0).units[0];
            Unit u2 = c.game.getPeople(1).units[0];
            u1.SimpleFight(u2.axis, u2.ordinate, c.game);
            Object o1 = u1.isDead();
            Object o2 = u2.isDead();
            Assert.IsInstanceOfType(o1, typeof(Boolean));
            Assert.IsInstanceOfType(o2, typeof(Boolean));
            Assert.AreNotEqual(o1, o2);
        }
        [TestMethod]
        // test de la version plus complexe des combats
        public void TestFight()
        {
            CreateBuilder c = new CreateBuilder(MapSize.Small, Species.Dwarf, Species.Elf);
            Unit u1 = c.game.getPeople(0).units[0];
            Unit u2 = c.game.getPeople(1).units[0];
            u1.fight(u2.axis, u2.ordinate, c.game);
            Object o1 = u1.hp;
            Object o2 = u2.hp;
            Assert.IsInstanceOfType(o1, typeof(int));
            Assert.IsInstanceOfType(o2, typeof(int));
        }
    }
}
