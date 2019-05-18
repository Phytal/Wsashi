﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Discord;
using Weeb.net;
using Weeb.net.Data;
using Wsashi.Preconditions;
using Wsashi.Core.Modules;

namespace Wsashi.Modules.API.Anime
{
    public class Cuddle : WsashiModule
    {
        [Command("cuddle")]
        [Summary("Displays an random cuddle picture!")]
        [Remarks("w!cuddle <user you want to cuddle (if left empty you will cuddle yourself)> Ex: w!cuddle @Phytal")]
        [Cooldown(10)]
        public async Task GetRandomNekoCuddle(IGuildUser user = null)
        {
            int rand = Global.Rng.Next(1, 3);
            if (rand == 1)
            {
                string json = "";
                using (WebClient client = new WebClient())
                {
                    json = client.DownloadString("https://nekos.life/api/v2/img/cuddle");
                }

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string nekolink = dataObject.url.ToString();

                if (user == null)
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(37, 152, 255);
                    embed.WithTitle("Cuddle!");
                    embed.WithDescription(
                        $"{Context.User.Mention} cuddled with themselves... Maybe you can cuddle with a friend? \n **(Include a user with your command! Example: w!cuddle <person you want to cuddle with>)**");
                    embed.WithImageUrl(nekolink);
                    embed.WithFooter($"Powered by nekos.life");

                    await Context.Channel.SendMessageAsync("", embed: embed.Build());
                }
                else
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(37, 152, 255);
                    embed.WithImageUrl(nekolink);
                    embed.WithTitle("Cuddle!");
                    embed.WithDescription($"{Context.User.Username} cuddled with {user.Mention}!");
                    embed.WithFooter($"Powered by nekos.life");

                    await Context.Channel.SendMessageAsync("", embed: embed.Build());
                }
            }

            if (rand == 2)
            {
                string[] tags = new[] { "" };
                weebDotSh.Helpers.WebRequest webReq = new weebDotSh.Helpers.WebRequest();
                RandomData result = await webReq.GetTypesAsync("cuddle", tags, FileType.Gif, NsfwSearch.False, false);
                string url = result.Url;
                string id = result.Id;
                if (user == null)
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(37, 152, 255);
                    embed.WithTitle("Cuddle!");
                    embed.WithDescription(
                        $"{Context.User.Mention} cuddled themselves, that's some intense self-love right there.. \n **(Include a user with your command! Example: w!cuddle <person you want to cuddle>)**");
                    embed.WithImageUrl(url);
                    embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                    await Context.Channel.SendMessageAsync("", embed: embed.Build());
                }
                else
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(37, 152, 255);
                    embed.WithImageUrl(url);
                    embed.WithTitle("Cuddle!");
                    embed.WithDescription($"{Context.User.Username} cuddled {user.Mention}!");
                    embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                    await Context.Channel.SendMessageAsync("", embed: embed.Build());
                }
            }
        }
    }
}
