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

namespace Wsashi.Modules.API
{
    public class Feed : ModuleBase<SocketCommandContext>
    {
        [Command("feed", RunMode = RunMode.Async)]
        [Summary("Feed someone!")]
        public async Task GetRandomNekoHug(IGuildUser user = null)
        {

            string json = "";
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString("https://nekos.life/api/v2/img/feed");
            }

            var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

            string nekolink = dataObject.url.ToString();

            if (user == null)
            {
                var embedd = new EmbedBuilder();
                embedd.WithColor(37, 152, 255);
                embedd.WithTitle("Munch!");
                embedd.WithDescription($"{Context.User.Mention} fed themselves... Let's hope they don't get fat... \n **(Include a user with your command! Example: w!feed <person you want to feed>)**");
                embedd.WithImageUrl(nekolink);

                await Context.Channel.SendMessageAsync("", false, embedd);
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithImageUrl(nekolink);
                embed.WithTitle("Munch!");
                embed.WithDescription($"{Context.User.Username} fed {user.Mention}!");

                await Context.Channel.SendMessageAsync("", embed: embed);
            }
        }
    }
}