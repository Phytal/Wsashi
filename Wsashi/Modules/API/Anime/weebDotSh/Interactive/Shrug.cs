﻿using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using Weeb.net;
using Weeb.net.Data;
using Wsashi.Core.Modules;
using Wsashi.Preconditions;

namespace Wsashi.Modules.API.Anime.weebDotSh
{
    public class Shrug : WsashiModule
    {
        [Command("shrug")]
        [Summary("Displays an image of an anime shrug gif")]
        [Remarks("Usage: w!shrug <user you want to shrug at (or can be left empty)> Ex: w!shrug @Phytal")]
        [Cooldown(5)]
        public async Task ShrugUser(IGuildUser user = null)
        {
            string[] tags = new[] {""};
            Helpers.WebRequest webReq = new Helpers.WebRequest();
            RandomData result = await webReq.GetTypesAsync("shrug", tags, FileType.Gif, NsfwSearch.False, false);
            string url = result.Url;
            string id = result.Id;
            if (user == null)
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithTitle("Shrug!");
                embed.WithDescription(
                    $"{Context.User.Mention} shrugged at themselves... I wonder what {Context.User.Username} is thinking about.. \n**(Include a user with your command! Example: w!shrug <person you want to shrug>)**");
                embed.WithImageUrl(url);
                embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                await Context.Channel.SendMessageAsync("", embed: embed.Build());
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithImageUrl(url);
                embed.WithTitle("Shrug!");
                embed.WithDescription($"{Context.User.Username} shrugged at {user.Mention}!");
                embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                await Context.Channel.SendMessageAsync("", embed: embed.Build());
            }
        }
    }
}
