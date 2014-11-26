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

        public People makePeople(Species race)
        {
            switch (race)
            {
                case Species.Elf:
                    //return new Elf();
                case Species.Dwarf:
                    //return new Dwarf();
                case Species.Orc:
                    //return new Orc();
                default:
                    Console.WriteLine("Unknown race !");
                    return null;
            }
        }
    }
}
