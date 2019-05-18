﻿using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using Weeb.net;
using Weeb.net.Data;
using Wsashi.Core.Modules;
using Wsashi.Preconditions;

namespace Wsashi.Modules.API.Anime.weebDotSh
{
    public class ThumbsUp : WsashiModule
    {
        [Command("thumbsUp")]
        [Summary("Displays an image of an anime thumbs-up gif")]
        [Remarks("Usage: w!thumbsUp <user you want to thumbs-up at (or can be left empty)> Ex: w!thumbsUp @Phytal")]
        [Cooldown(5)]
        public async Task ThumbsUpUser(IGuildUser user = null)
        {
            string[] tags = new[] { "" };
            Helpers.WebRequest webReq = new Helpers.WebRequest();
            RandomData result = await webReq.GetTypesAsync("thumbsup", tags, FileType.Gif, NsfwSearch.False, false);
            string url = result.Url;
            string id = result.Id;
            if (user == null)
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithTitle("Yoku yatta!");
                embed.WithDescription(
                    $"{Context.User.Mention} gave themselves a thumbs up, high self-esteem is good you know. \n**(Include a user with your command! Example: w!thumbsUp <person you want to give a thumbs-up>)**");
                embed.WithImageUrl(url);
                embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                await Context.Channel.SendMessageAsync("", embed: embed.Build());
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithImageUrl(url);
                embed.WithTitle("Yoku yatta!");
                embed.WithDescription($"{Context.User.Username} gave {user.Mention} a thumbs up!");
                embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                await Context.Channel.SendMessageAsync("", embed: embed.Build());
            }
        }
    }
}
