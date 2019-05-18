﻿using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using Weeb.net;
using Weeb.net.Data;
using Wsashi.Core.Modules;
using Wsashi.Preconditions;

namespace Wsashi.Modules.API.Anime.weebDotSh
{
    public class Stare : WsashiModule
    {
        [Command("stare")]
        [Summary("Displays an image of an anime stare gif")]
        [Remarks("Usage: w!stare <user you want to bite (or can be left empty)> Ex: w!stare @Phytal")]
        [Cooldown(5)]
        public async Task StareUser(IGuildUser user = null)
        {
            string[] tags = new[] { "" };
            Helpers.WebRequest webReq = new Helpers.WebRequest();
            RandomData result = await webReq.GetTypesAsync("stare", tags, FileType.Gif, NsfwSearch.False, false);
            string url = result.Url;
            string id = result.Id;
            if (user == null)
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithTitle("Chiiiiii...");
                embed.WithDescription(
                    $"{Context.User.Mention} is staring at themselves! You know, you can't win a staring contest against a mirror.. \n**(Include a user with your command! Example: w!stare <person you want to stare at>)**");
                embed.WithImageUrl(url);
                embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                await Context.Channel.SendMessageAsync("", embed: embed.Build());
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithImageUrl(url);
                embed.WithTitle("Chiiiiii...");
                embed.WithDescription($"{Context.User.Username} is staring at {user.Mention}!");
                embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                await Context.Channel.SendMessageAsync("", embed: embed.Build());
            }
        }
    }
}
