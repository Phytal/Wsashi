﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsashi.Entities
{
    public class GlobalGuildAccount : IGlobalAccount
    {
        public ulong Id { get; set; }

        public ulong AnnouncementChannelId { get; set; }

        public List<string> Prefixes { get; set; } = new List<string>();

        public List<string> WelcomeMessages { get; set; } = new List<string> { };

        public List<string> LeaveMessages { get; set; } = new List<string>();

        public bool Filter { get; set; }

        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();
        /* Add more values to store */
    }
}