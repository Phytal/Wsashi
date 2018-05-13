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

namespace Wsashi.Modules.API.Nekos.life.Anime
{
    public class Tickle : ModuleBase<SocketCommandContext>
    {
        [Command("Tickle", RunMode = RunMode.Async)]
        [Summary("Tickle someone! :3")]
        public async Task GetRandomTickle(IGuildUser user = null)
        {

            string json = "";
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString("https://nekos.life/api/v2/img/tickle");
            }

            var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

            string nekolink = dataObject.url.ToString();

            if (user == null)
            {
                var embedd = new EmbedBuilder();
                embedd.WithColor(37, 152, 255);
                embedd.WithTitle("Tickle!");
                embedd.WithDescription($"{Context.User.Mention} tickled themselves... I'll stay out of this for now... \n **(Include a user with your command! Example: w!tickle <person you want to tickle>)**");
                embedd.WithImageUrl(nekolink);

                await Context.Channel.SendMessageAsync("", false, embedd);
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithImageUrl(nekolink);
                embed.WithTitle("Tickle!");
                embed.WithDescription($"{Context.User.Username} tickled {user.Mention}!");

                await Context.Channel.SendMessageAsync("", embed: embed);
            }
        }
    }
}