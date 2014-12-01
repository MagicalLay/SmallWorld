using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    interface IPeople
    {
        People[] makePeoples(Jeu.Species race1, Jeu.Species race2, Map m);
    }
}
