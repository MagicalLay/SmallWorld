using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Jeu
{
    public enum Species { Elf, Dwarf, Orc };
    public class FactoryPeople : IPeople
    {
        private static FactoryPeople instance_FactPeople;

        private Elf elves;
        private Dwarf dwarves;
        private Orc orcs;

        public FactoryPeople()
        {
            /*int nb = Jeu.People.nbUnits;
            elves = new Elf(nb);
            dwarves = new Dwarf(nb);
            orcs = new Orc(nb);*/
        }
        public static FactoryPeople Instance_FactPeople
        {
            get
            {
                if (instance_FactPeople == null)
                {
                    instance_FactPeople = new FactoryPeople();
                }
                return instance_FactPeople;
            }
        }

        public unsafe People[] makePeoples(Species race1, Species race2, Map m)
        {
            if (race1 == race2) Console.WriteLine("Race1 must be different from race2 !");

            People[] p = new People[2];
            int nbUnits;

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
            return p;
        }
    }
}
