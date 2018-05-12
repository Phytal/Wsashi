﻿using System.Net;
using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace Wsashi.Modules.API.Nekos.life.NSFW_Neko
{
    public class NSFW_Neko_Gif : ModuleBase<SocketCommandContext>
    {
        [Command("nekonsfwgif", RunMode = RunMode.Async)]
        [Summary("Displays a nsfw neko gif")]
        public async Task GetRandomNekoLewd()
        {
            var channel = Context.Channel as IGuildChannel;
            if (channel.IsNsfw)
            {
                string json = "";
                using (WebClient client = new WebClient())
                {
                    json = client.DownloadString("https://nekos.life/api/v2/img/nsfw_neko_gif");
                }

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string nekolink = dataObject.url.ToString();

                await Context.Channel.SendMessageAsync(nekolink);
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.Title = $":x:  | You need to use this command in a NSFW channel, {Context.User.Username}!";
                var use = await Context.Channel.SendMessageAsync("", false, embed);
                await Task.Delay(5000);
                await use.DeleteAsync();
            }
        }
    }
}
