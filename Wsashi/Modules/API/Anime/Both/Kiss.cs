﻿using System.Threading.Tasks;
using Discord.Commands;
using System.Net;
using Newtonsoft.Json;
using Discord;
using Weeb.net;
using Weeb.net.Data;
using Wsashi.Preconditions;
using Wsashi.Core.Modules;

namespace Wsashi.Modules.API.Anime
{
    public class Kiss : WsashiModule
    {
        [Command("kiss")]
        [Summary("Kiss someone! :3")]
        [Remarks("w!kiss <user you want to kiss (if left empty you will kiss yourself)> Ex: w!kiss @Phytal")]
        [Cooldown(10)]
        public async Task GetRandomNeko(IGuildUser user = null)
        {
            int rand = Global.Rng.Next(1, 3);
            if (rand == 1)
            {
                string json = "";
                using (WebClient client = new WebClient())
                {
                    json = client.DownloadString("https://nekos.life/api/v2/img/kiss");
                }

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string nekolink = dataObject.url.ToString();

                if (user == null)
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(37, 152, 255);
                    embed.WithTitle("Kiss!");
                    embed.WithDescription(
                        $"{Context.User.Mention} you can't really kiss yourself... Don't worry how about a kiss from me?... \n **(Include a user with your command! Example: w!kiss <person you want to kiss>)**");
                    embed.WithImageUrl(nekolink);
                    embed.WithFooter($"Powered by nekos.life");

                    await Context.Channel.SendMessageAsync("", embed: embed.Build());
                }
                else
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(37, 152, 255);
                    embed.WithImageUrl(nekolink);
                    embed.WithTitle("Kiss!");
                    embed.WithDescription($":heart:  |  {Context.User.Username} kissed {user.Mention}!");
                    embed.WithFooter($"Powered by nekos.life");

                    await Context.Channel.SendMessageAsync("", embed: embed.Build());
                }
            }

            if (rand == 2)
            {
                string[] tags = new[] { "" };
                weebDotSh.Helpers.WebRequest webReq = new weebDotSh.Helpers.WebRequest();
                RandomData result = await webReq.GetTypesAsync("kiss", tags, FileType.Gif, NsfwSearch.False, false);
                string url = result.Url;
                string id = result.Id;
                if (user == null)
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(37, 152, 255);
                    embed.WithTitle("Kiss!");
                    embed.WithDescription(
                        $"{Context.User.Mention} kissed themselves, welcome to quantum mechanics class everybody. \n **(Include a user with your command! Example: w!kiss <kiss you want to hug>)**");
                    embed.WithImageUrl(url);
                    embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                    await Context.Channel.SendMessageAsync("", embed: embed.Build());
                }
                else
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(37, 152, 255);
                    embed.WithImageUrl(url);
                    embed.WithTitle("Kiss!");
                    embed.WithDescription($"{Context.User.Username} kissed {user.Mention}!");
                    embed.WithFooter($"Powered by weeb.sh | ID: {id}");

                    await Context.Channel.SendMessageAsync("", embed: embed.Build());
                }
            }
        }
    }
}
