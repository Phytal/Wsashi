﻿using System.Net;
using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Wsashi.Preconditions;
using Wsashi.Core.Modules;
using System;

namespace Wsashi.Modules.API.Nekos.life.NSFW_Hentai
{
    public class HentaiAnal : WsashiModule
    {
        [Command("anal")]
        [Summary("Displays hentai anal")]
        [Remarks("Ex: w!anal")]
        [Cooldown(5)]
        public async Task GetRandomNekoAnal()
        {
            var channel = Context.Channel as ITextChannel;
            if (channel.IsNsfw)
            {
                string json = "";
                using (WebClient client = new WebClient())
                {
                    json = client.DownloadString("https://nekos.life/api/v2/img/anal");
                }

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string nekolink = dataObject.url.ToString();

                var embed = new EmbedBuilder();
                embed.WithTitle("Randomly generated anal hentai just for you <3!");
                embed.WithImageUrl(nekolink);
                await Context.Channel.SendMessageAsync("", embed: embed.Build());
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.Title = $":x:  | You need to use this command in a NSFW channel, {Context.User.Username}!";
                await ReplyAndDeleteAsync("", embed: embed.Build(), timeout: TimeSpan.FromSeconds(5));
            }
        }
    }
}
