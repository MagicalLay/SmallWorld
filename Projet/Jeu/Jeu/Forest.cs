using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Forest : Space
    {
        public Forest() { }

        public Type getType()
        {
            return Type.Forest;
        }
    }
}
