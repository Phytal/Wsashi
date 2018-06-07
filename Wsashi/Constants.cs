﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsashi
{
    public static class Constants
    {
        internal static readonly string ResourceFolder = "resources";
        internal static readonly string UserAccountsFolder = "users";
        internal static readonly string WasagotchiAccountsFolder = "wasagotchis";
        internal static readonly string ServerAccountsFolder = "servers";
        internal static readonly string InvisibleString = "\u200b";
        public const ulong DailyMoneyGain = 100;
        public const int MessageRewardCooldown = 30;
        public const int MessageRewardMinLenght = 20;
        public static readonly Tuple<int, int> MessagRewardMinMax = Tuple.Create(1, 5);
    }
}