﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wsashi.Core.Modules;

namespace Wsashi.Helpers
{
    public class ConvertBool : WsashiModule
    {
        public static bool CheckStringToBoolean(string boolean)
        {
            if (boolean == "on" || boolean == "off") return true;
            else return false;
        }

        public static Tuple<bool, bool> ConvertStringToBoolean(string boolean) // <is it a bool, true / false>
        {
            bool result = CheckStringToBoolean(boolean);
            if (result == true)
            {
                if (boolean == "on") return new Tuple<bool, bool>(true, true);
                if (boolean == "off") return new Tuple<bool, bool>(true, false);
            }
            else
            {
                return new Tuple<bool, bool>(false, false);
            }
            return new Tuple<bool, bool>(false, false);
        }
    }
}
