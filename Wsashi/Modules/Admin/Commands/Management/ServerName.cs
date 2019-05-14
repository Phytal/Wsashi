﻿using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using Wsashi.Core.Modules;
using Wsashi.Features.GlobalAccounts;
using Wsashi.Preconditions;

namespace Wsashi.Modules.Management.Commands
{
    public class ServerName : WsashiModule
    {

        [Command("ServerName")]
        [Summary("Changes the name of the server")]
        [Remarks("w!servername <new name of the server> Ex: w!servername roblox is best")]
        [Cooldown(5)]
        public async Task ModifyServerName([Remainder]string name)
        {
            var guser = Context.User as SocketGuildUser;
            if (guser.GuildPermissions.Administrator)
            {
                await Context.Guild.ModifyAsync(x => x.Name = name);
                var embed = new EmbedBuilder();
                embed.WithDescription($"Set this server's name to **{name}**!");
                embed.WithColor(37, 152, 255);

                await ReplyAsync("", embed: embed.Build());
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.Title = $":x:  | You Need the Administrator Permission to do that {Context.User.Username}";
                await ReplyAndDeleteAsync("", embed: embed.Build(), timeout: TimeSpan.FromSeconds(5));
            }
        }

    }
}
