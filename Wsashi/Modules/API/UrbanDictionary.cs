﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Discord.Commands;
using Discord;
using System.Net;
using Wsashi.Preconditions;

namespace Wsashi.Modules.API
{
    public class UrbanDictionary : ModuleBase
    {
        [Command("define", RunMode = RunMode.Async)]
        [Summary("Use Urban Dictionary to define a given word")]
        [Alias("dictionary", "urban", "definition")]
        [Remarks("w!define <word you want to define> Ex: w!define Weeb")]
        [Cooldown(10)]
        public async Task Define([Remainder] string link)
        {
            string json = "";
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString("http://api.urbandictionary.com/v0/define?term=" + link);
            }

            var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

            string author = dataObject.list[0].author.ToString();
            string definition = dataObject.list[0].definition.ToString();
            string example = dataObject.list[0].example.ToString();
            string permalink = dataObject.list[0].permalink.ToString();
            string up = dataObject.list[0].thumbs_up.ToString();
            string down = dataObject.list[0].thumbs_down.ToString();

            var embed = new EmbedBuilder();
            embed.WithColor(37, 152, 255);
            embed.WithTitle(link);
            embed.WithDescription($"By *{author}*");
            embed.AddInlineField("Definition", definition);
            embed.AddInlineField("Example", example + "\n" +
                "\n:thumbsup:" + up + " :thumbsdown:" + down);
            embed.WithFooter("Provided by the Urban Dictionary API");
            embed.WithUrl(permalink);

            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }
    }
}
