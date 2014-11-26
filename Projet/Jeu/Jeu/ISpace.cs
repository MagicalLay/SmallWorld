using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    interface ISpace
    {
        Space getDesert();
        Space getMountain();
        Space getForest();
        Space getField();
    }
}
