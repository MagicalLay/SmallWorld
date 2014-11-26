using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    interface IPeople
    {
        People makePeople(Jeu.Species race);
    }
}
