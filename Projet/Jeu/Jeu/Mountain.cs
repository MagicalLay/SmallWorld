﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class Mountain : Space
    {
        public Mountain() { }
        public Type getType()
        {
            return Type.Mountain;
        }
    }
}
