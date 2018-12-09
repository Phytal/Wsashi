﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Wsashi.Core.Modules;
using Wsashi.Features.GlobalAccounts;
using Wsashi.Preconditions;

namespace Wsashi.Modules.API.Overwatch
{
    public class SetAccount : WsashiModule
    {
        [Command("owaccount")]
        [Summary("Set your Overwatch username, platform and region")]
        [Remarks("w!owaccount <username> <platform> <region> Ex: w!owaccount Username#1234 pc us")]
        [Cooldown(10)]
        public async Task OwAccount(string user, string platform, string region)
        {
            user = user.Replace('#', '-');
            var config = GlobalUserAccounts.GetUserAccount(Context.User);

            var embed = new EmbedBuilder();
            embed.WithColor(37, 152, 255);
            embed.WithTitle("Overwatch Credentials");
            embed.AddField("Username", user);
            embed.AddField("Platform", platform);
            embed.AddField("Region", region);
            embed.WithDescription($"Successfully set your default Battle.net credentials.");

            config.OverwatchID = user;
            config.OverwatchPlatform = platform;
            config.OverwatchRegion = region;
            GlobalUserAccounts.SaveAccounts();


            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }

        [Command("owaccount")]
        [Summary("View your Overwatch information")]
        [Remarks("w!owaccountinfo")]
        [Cooldown(10)]
        public async Task GetOwAccount()
        {
            var config = GlobalUserAccounts.GetUserAccount(Context.User);
            if (config.OverwatchPlatform == null && config.OverwatchRegion == null && config.OverwatchID == null)
            {
                await Context.Channel.SendMessageAsync("**Make sure you set your account information first!**\n w!owaccount <username> <platform> <region> Ex: w!owaccount Username#1234 pc us ");
                return;
            }
            var embed = new EmbedBuilder();
            embed.WithColor(37, 152, 255);
            embed.WithTitle("Here are your Overwatch credentials");
            embed.AddField("Username", config.OverwatchID);
            embed.AddField("Region", config.OverwatchRegion);
            embed.AddField("Platform", config.OverwatchPlatform);

            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }
    }
}
