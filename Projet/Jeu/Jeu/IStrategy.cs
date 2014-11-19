using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public interface IMapStrategy
    {

        Map Instantiate();
    }

    public interface IStrategy
    {
        Map instantiate();
    }
}
