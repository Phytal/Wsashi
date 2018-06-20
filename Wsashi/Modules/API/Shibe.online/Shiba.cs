﻿using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Wsashi.Preconditions;

namespace Watchdog.Modules.API
{
    public class Shiba : ModuleBase<SocketCommandContext>
    {
        [Command("shiba")]
        [Alias("shibe")]
        [Summary("Sends an image of a Shiba Inu :3")]
        [Remarks("Ex: w!shiba")]
        [Cooldown(10)]
        public async Task GetRandomShiba()
        {
            string json = "";
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString("http://shibe.online/api/shibes?count=1&urls=true&httpsUrls=false");
            }

            var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

            string link = dataObject[0].ToString();

            var embed = new EmbedBuilder();
            embed.WithTitle(":dog: | Here's a Shiba!");
            embed.WithImageUrl(link);
            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }
    }
}
