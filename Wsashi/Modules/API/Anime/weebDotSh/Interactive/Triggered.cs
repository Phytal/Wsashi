﻿using Discord;
using Discord.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weeb.net;
using Weeb.net.Data;
using Wsashi.Core.Modules;
using Wsashi.Preconditions;

namespace Wsashi.Modules.API.Anime.weebDotSh
{
    public class Triggered : WsashiModule
    {
        [Command("triggered")]
        [Summary("Displays an image of an anime triggered gif")]
        [Remarks("Usage: w!triggered <user you want to be triggered at (or can be left empty)> Ex: w!triggered @Phytal")]
        [Cooldown(5)]
        public async Task TriggeredUser(IGuildUser user = null)
        {
            string[] tags = new[] { "" };
            Helpers.WebRequest webReq = new Helpers.WebRequest();
            RandomData result = await webReq.GetTypesAsync("triggered", tags, FileType.Gif, NsfwSearch.False, false);
            string url = result.Url;
            string id = result.Id;
            if (user == null)
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithTitle("Triggered!");
                embed.WithDescription(
                    $"{Context.User.Mention} is triggered at themselves! What happened? May I be of assistance? \n**(Include a user with your command! Example: w!triggered <person you want to be triggered at>)**");
                embed.WithImageUrl(url);
                embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                await Context.Channel.SendMessageAsync("", embed: embed.Build());
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithImageUrl(url);
                embed.WithTitle("Triggered!");
                embed.WithDescription($"{Context.User.Username} is triggered {user.Mention}!");
                embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                await Context.Channel.SendMessageAsync("", embed: embed.Build());
            }
        }
    }
}
