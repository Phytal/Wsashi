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
    public class NekoBoobs : WsashiModule
    { 
    [Command("boobs")]
    [Alias("tits")]
    [Summary("Displays hentai boobs")]
        [Remarks("Ex: w!boobs")]
        [Cooldown(5)]
        public async Task GetRandomNeko()
        {
            var channel = Context.Channel as ITextChannel;
            if (channel.IsNsfw)
            {
                string json = "";
                using (WebClient client = new WebClient())
                {
                    json = client.DownloadString("https://nekos.life/api/v2/img/boobs");
                }

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string nekolink = dataObject.url.ToString();

                var embed = new EmbedBuilder();
                embed.WithTitle("Randomly generated hentai boobs just for you <3!");
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
