﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Desert : Space
    {
        public Desert() { }
        public override Type getType()
        {
            return Type.Desert;
        }
    }
}
