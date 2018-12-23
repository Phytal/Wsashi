﻿using System.Threading.Tasks;
using Newtonsoft.Json;
using Discord.Commands;
using Discord;
using System.Net;
using Wsashi.Preconditions;
using Wsashi.Core.Modules;

namespace Wsashi.Modules.API
{
    public class Person : WsashiModule
    {
        [Command("person")]
        [Summary("Gets a random person with random credentials")]
        [Remarks("Ex: w!person")]
        [Cooldown(10)]
        public async Task GetRandomPerson()
        {
            string json = "";
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString("https://randomuser.me/api/?nat=US");
            }

            var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

            string firstName = dataObject.results[0].name.first.ToString();
            string lastName = dataObject.results[0].name.last.ToString();
            string gender = dataObject.results[0].gender.ToString();
            string avatarURL = dataObject.results[0].picture.large.ToString();

            var embed = new EmbedBuilder();
            embed.WithThumbnailUrl(avatarURL);
            embed.WithColor(37, 152, 255);
            embed.WithTitle("Generated Person");
            embed.AddField("Gender", gender, true);
            embed.AddField("First Name", firstName, true);
            embed.AddField("Last Name", lastName, true);

            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }
    }
}
