﻿using System;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using Weeb.net;
using Weeb.net.Data;
using Wsashi.Core.Modules;
using Wsashi.Preconditions;

namespace Wsashi.Modules.API.Anime.weebDotSh
{
    public class Any : WsashiModule
    {
        [Command("anyweeb")]
        [Summary("Displays an image of a sfw anime gif/image, provided with the type")]
        [Remarks("Usage: w!anyweeb <type> Ex: w!anyweeb lick")]
        [Cooldown(5)]
        public async Task AnyUser([Remainder] string type)
        {
            try
            {
                string[] tags = new[] {""};
                Helpers.WebRequest webReq = new Helpers.WebRequest();
                RandomData result = await webReq.GetTypesAsync(type, tags, FileType.Any, NsfwSearch.False, false);
                string url = result.Url;
                string id = result.Id;

                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithTitle("QWERTY!");
                embed.WithDescription($"Looks like {Context.User.Username} is interested in some {type} owo");
                embed.WithImageUrl(url);
                embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                await Context.Channel.SendMessageAsync("", embed: embed.Build());
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync(
                    "Did you enter a valid type? \nView all types with the `w!weebtypes` command" +
                    "\nOtherwise did you use the command correctly?\nUsage: w!anyweeb <type> Ex: w!anyweeb lick");
            }
        }
    }
}
