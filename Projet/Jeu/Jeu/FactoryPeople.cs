﻿using System;
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

        public People[] makePeoples(Species race1, Species race2, Map m)
        {
            if (race1 == race2) Console.WriteLine("Race1 must be different from race2 !");

            People[] p = new People[2];
            int nbUnits;

            do
            {
                if (m.Size == 6)
                {
                    nbUnits = 4;
                }
                else if (m.Size == 10)
                {
                    nbUnits = 6;
                }
                else
                {
                    nbUnits = 8;
                }
            } while (m.Size == 4 || m.Size == 10 || m.Size == 14);

            switch (race1)
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
                    break;
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
                    break;
            }

            Random rnd = new Random();

            int nbcases = m.Size * m.Size;
            int placement = rnd.Next(nbcases);
            p[1].placeUnits(placement);

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
