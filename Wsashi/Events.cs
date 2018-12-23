﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wsashi.Core.LevelingSystem;
using Wsashi.Features.GlobalAccounts;

namespace Wsashi
{
    public class Events
    {
        private static readonly DiscordShardedClient _client = Program._client;

        public async Task _Autorole(SocketGuildUser user)
        {
            _ = Autorole(user);
        }
        public async Task Autorole(SocketGuildUser user)
        {
            var config = GlobalGuildAccounts.GetGuildAccount(user.Guild.Id);
            if (config.Autorole != null || config.Autorole != "")
            {
                var targetRole = user.Guild.Roles.FirstOrDefault(r => r.Name == config.Autorole);
                await user.AddRoleAsync(targetRole);
            }
        }

        public async Task GuildUtils(SocketGuild s)
        {
            var info = System.IO.Directory.CreateDirectory(Path.Combine(Constants.ResourceFolder, Constants.ServerUserAccountsFolder));
            ulong In = s.Id;
            string Out = Convert.ToString(In);
            if (!Directory.Exists(Out))
                Directory.CreateDirectory(Path.Combine(Constants.ServerUserAccountsFolder, Out));

            var config = GlobalGuildAccounts.GetGuildAccount(s.Id);

            var dmChannel = await s.Owner.GetOrCreateDMChannelAsync();
            var embed = new EmbedBuilder();
            embed.WithTitle($"Thanks for adding me to your server, {s.Owner.Username}!");
            embed.WithDescription("For quick information, use the `w!help` command! \nNeed quick help? Visit the our server and ask away https://discord.gg/NuUdx4h!");
            embed.WithThumbnailUrl(s.IconUrl);
            embed.WithFooter("Found an issue in a command? Report it in the server linked above!");
            embed.WithColor(37, 152, 255);

            config.GuildOwnerId = s.Owner.Id;

            await dmChannel.SendMessageAsync("", embed: embed.Build());
            GlobalGuildAccounts.SaveAccounts();

            var client = Program._client;
            var guilds = client.Guilds.Count;
            await client.SetGameAsync($"w!help | in {guilds} servers!", $"https://twitch.tv/{Config.bot.TwitchStreamer}", ActivityType.Streaming);
        }

        public static async Task FilterUnflip(SocketMessage s)
        {
            _ = FilterChecks(s);
            _ = Unflip(s);
            //_ = HandleMessageRewards(s);
        }

        public static async Task FilterChecks(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            var context = new ShardedCommandContext(_client, msg);
            var config = GlobalGuildAccounts.GetGuildAccount(context.Guild.Id);
            if (context.User.IsBot) return;
            if (msg == null) return;
            if (msg.Author.Id == config.GuildOwnerId) return;

            try
            {
                if (config.Antilink == true)
                {
                    if ((msg.Content.Contains("https://discord.gg") || msg.Content.Contains("https://discord.io")) && !config.AntilinkIgnoredChannels.Contains(context.Channel.Id))
                    {
                        await msg.DeleteAsync();
                        var embed = new EmbedBuilder();
                        embed.WithColor(37, 152, 255);
                        embed.WithDescription($":warning:  | {context.User.Mention}, Don't post your filthy links here! (No links)");
                        var mssg = await context.Channel.SendMessageAsync("", embed: embed.Build());
                        await Task.Delay(5000);
                        await mssg.DeleteAsync();
                    }
                }
            }
            catch (NullReferenceException)
            {
                return;
            }

            string[] reactionTexts = new string[]
{
        "This is a Christian Minecraft Server!",
        "Watch your language buddy!",
        "I think you touched the stove on accident!",
        "You're starting to bug me..",
        "You're under-arrest by the Good Boy Cops",
        "Woah man, too far"
};
            Random rand = new Random();
            List<string> bannedWords = new List<string>
                {
                     "fuck", "fuk", "bitch", "pussy", "nigg","asshole", "c0ck", "cock", "dick", "cunt", "cnut", "d1ck", "blowjob", "b1tch"
                };
            try
            {
                if (config.Filter == true)
                {
                    if (bannedWords.Any(msg.Content.ToLower().Contains) 
                        || config.CustomFilter.Any(msg.Content.ToLower().Contains) && !config.NoFilterChannels.Contains(context.Channel.Id))
                    {
                        int randomIndex = rand.Next(reactionTexts.Length);
                        string text = reactionTexts[randomIndex];
                        await msg.DeleteAsync();
                        var embed = new EmbedBuilder();
                        embed.WithDescription($":warning:  |  {text} (Inappropiate language)");
                        embed.WithColor(37, 152, 255);
                        //await context.Channel.SendMessageAsync("", embed: embed.Build());
                        var mssg = await context.Channel.SendMessageAsync("", embed: embed.Build());
                        await Task.Delay(4000);
                        await mssg.DeleteAsync();
                    }
                }
            }
            catch (NullReferenceException)
            {
                return;
            }

            if (config.MassPingChecks == true)
            {
                if (msg.Content.Contains("@everyone") || msg.Content.Contains("@here"))
                {
                    await msg.DeleteAsync();
                    var msgg = await context.Channel.SendMessageAsync($":warning:  | {msg.Author.Mention}, try not to mass ping.");
                    await Task.Delay(4000);
                    await msgg.DeleteAsync();
                }
            }
        }

        public static async Task Unflip(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            var context = new ShardedCommandContext(_client, msg);
            var config = GlobalGuildAccounts.GetGuildAccount(context.Guild.Id);
            if (context.User.IsBot) return;
            if (msg == null) return;

            if (config.Unflip)
            {
                if (msg.Content.Contains("(╯°□°）╯︵ ┻━┻"))
                {
                    await context.Channel.SendMessageAsync("┬─┬ ノ( ゜-゜ノ)");
                }
            }
        }

        public static async Task HandleMessageRewards(SocketMessage s)
        {
            var msg = s as SocketUserMessage;

            if (msg == null) return;
            if (msg.Channel == msg.Author.GetOrCreateDMChannelAsync()) return;
            if (msg.Author.IsBot) return;

            var userAcc = GlobalUserAccounts.GetUserAccount(msg.Author.Id);
            DateTime now = DateTime.UtcNow;

            // Check if message is long enough and if the coolown of the reward is up - if not return
            if (now < userAcc.LastMessage.AddSeconds(Constants.MessageRewardCooldown) || msg.Content.Length < Constants.MessageRewardMinLenght)
            {
                return; // This Message is not eligible for a reward
            }

            // Generate a randomized reward in the configured boundries
            userAcc.Money += (ulong)Global.Rng.Next(Constants.MessagRewardMinMax.Item1, Constants.MessagRewardMinMax.Item2 + 1);
            userAcc.LastMessage = now;

            GlobalUserAccounts.SaveAccounts();
        }
    }
}
