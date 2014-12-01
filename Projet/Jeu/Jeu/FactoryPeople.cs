using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public enum Species { Elf, Dwarf, Orc };
    public class FactoryPeople : IPeople
    {
        private UnitElf elf;
        private UnitDwarf dwarf;
        private UnitOrc orc;

        private static FactoryPeople instance_FactPeople;

        public People[] makePeoples(Species race, Species race2, Map map)
        {
            if (race == race2) Console.WriteLine("race1 must be different from race2 !");

            People[] p = new People[2];
            int nbUnits;
            switch (map.Size)
            {
                case 6:
                    nbUnits = 4;
                    break;
                case 10:
                    nbUnits = 6;
                    break;
                case 14:
                    nbUnits = 8;
                    break;
                default:
                    Console.WriteLine("taille de carte incorrecte");
                    throw new System.NotImplementedException();
            }

            switch (race)
            {
                case Species.Elf:
                    p[0] = new Elf(nbUnits);
                    break;
                case Species.Dwarf:
                    p[0] = new Dwarf(nbUnits);
                    break;
                case Species.Orc:
                    p[0] = new Orc(nbUnits);
                    break;
                default:
                    Console.WriteLine("Unknown race !");
                    throw new System.NotImplementedException();
            }

            switch (race2)
            {
                case Species.Elf:
                    p[1] = new Elf(nbUnits);
                    break;
                case Species.Dwarf:
                    p[1] = new Dwarf(nbUnits);
                    break;
                case Species.Orc:
                    p[1] = new Orc(nbUnits);
                    break;
                default:
                    Console.WriteLine("Unknown race !");
                    throw new System.NotImplementedException();
            }

            Random rnd = new Random();

            int nbcases = map.Size * map.Size;
            int placement = rnd.Next(nbcases);
            p[1].placerUnits(placement);

            int p1 = rnd.Next(nbcases);
            int p2 = rnd.Next(nbcases);
            int p3 = rnd.Next(nbcases);

            int d1 = placement - p1;
            int d2 = placement - p2;
            int d3 = placement - p3;



            return p;

        }
    }
}
