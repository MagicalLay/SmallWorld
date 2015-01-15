using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeu;

namespace Jeu
{
    public class UnitElf : Unit
    {
        public UnitElf()
        {
            favoriteSpace = Space.Type.Forest;
        }
        public override Type getType()
        {
            return Type.Elf;
        }
    }
}
