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
    public class CatEmoticon : ModuleBase<SocketCommandContext>
    {
        [Command("catemoticon", RunMode = RunMode.Async)]
        [Summary("Displays an random cat emoticon :3")]
        [Alias("cate")]
        public async Task GetRandomNeko()
        {
            string json = "";
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString("https://nekos.life/api/v2/cat");
            }

            var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

            string nekolink = dataObject.cat.ToString();

            await Context.Channel.SendMessageAsync(nekolink);
        }
    }
}