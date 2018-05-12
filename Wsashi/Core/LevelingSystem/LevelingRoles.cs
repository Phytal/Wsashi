﻿using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsashi.Features.GlobalAccounts;

namespace Wsashi.Core.LevelingSystem
{
    internal static class LevelingRoles
    {
        internal static async void UserSentMessage(SocketGuildUser user)
        {

            var userAccount = GlobalUserAccounts.GetUserAccount(user);
            uint oldLevel = userAccount.LevelNumber;
            userAccount.XP += 13;
            GlobalUserAccounts.SaveAccounts();

            if (oldLevel != 10)
            {
                var mplus = user.Guild.Roles.Where(input => input.Name.ToUpper() == "MEMBER+").FirstOrDefault() as SocketRole;
                var m = user.Guild.Roles.Where(input => input.Name.ToUpper() == "MEMBER").FirstOrDefault() as SocketRole;
                await user.AddRoleAsync(mplus);
                await user.RemoveRoleAsync(m);
            }
        }

        internal static async void UserSentMessagem(SocketGuildUser user)
        {

            var userAccount = GlobalUserAccounts.GetUserAccount(user);
            uint oldLevel = userAccount.LevelNumber;
            userAccount.XP += 13;
            GlobalUserAccounts.SaveAccounts();

            if (oldLevel != 30)
            {
                var mplus = user.Guild.Roles.Where(input => input.Name.ToUpper() == "MEMBER++").FirstOrDefault() as SocketRole;
                var m = user.Guild.Roles.Where(input => input.Name.ToUpper() == "MEMBER+").FirstOrDefault() as SocketRole;
                await user.AddRoleAsync(mplus);
                await user.RemoveRoleAsync(m);
            }
        }
    }
}
