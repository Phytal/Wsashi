﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wsashi.Modules.Fun.Dueling
{
    public class Criticals
    {
        public static bool GetCritical()
        {
            int hit = Global.Rng.Next(1, 10);
            if (hit == 2) return true;
            else return false;
        }
    }
}
