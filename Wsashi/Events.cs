﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wsashi.Core.LevelingSystem;
using Wsashi.Features.GlobalAccounts;

namespace Wsashi
{
    internal class Events
    {
        private static DiscordSocketClient _client = Program._client;

        public static async Task Autorole(SocketGuildUser user)
        {
            var config = GlobalGuildAccounts.GetGuildAccount(user.Guild.Id);
            if (config.Autorole != null || config.Autorole != "")
            {
                var targetRole = user.Guild.Roles.FirstOrDefault(r => r.Name == config.Autorole);
                await user.AddRoleAsync(targetRole);
            }
        }


        public static async Task Goodbye(SocketGuildUser user)
        {
            var config = GlobalGuildAccounts.GetGuildAccount(user.Guild.Id);

            if (config.WelcomeChannel != 0)
            {
                var a = config.LeavingMessage.Replace("{UserMention}", user.Mention);
                a = a.Replace("{ServerName}", user.Guild.Name);
                a = a.Replace("{UserName}", user.Username);
                a = a.Replace("{OwnerMention}", user.Guild.Owner.Mention);
                a = a.Replace("{UserTag}", user.DiscriminatorValue.ToString());

                var channel = user.Guild.GetTextChannel(config.WelcomeChannel);
                var embed = new EmbedBuilder();
                embed.WithDescription(a);
                embed.WithColor(37, 152, 255);
                embed.WithFooter($"Guild Owner: {user.Guild.Owner.Username}#{user.Guild.Owner.Discriminator}");
                embed.WithThumbnailUrl(user.Guild.IconUrl);
                await channel.SendMessageAsync("", false, embed);

            }
        }

        public static async Task Welcome(SocketGuildUser user)
        {
            var config = GlobalGuildAccounts.GetGuildAccount(user.Guild.Id);

            if (config.WelcomeChannel != 0)
            {
                var a = config.WelcomeMessage.Replace("{UserMention}", user.Mention);
                a = a.Replace("{ServerName}", user.Guild.Name);
                a = a.Replace("{UserName}", user.Username);
                a = a.Replace("{OwnerMention}", user.Guild.Owner.Mention);
                a = a.Replace("{UserTag}", user.DiscriminatorValue.ToString());

                var channel = user.Guild.GetTextChannel(config.WelcomeChannel);
                var embed = new EmbedBuilder();
                embed.WithDescription(a);
                embed.WithColor(37, 152, 255);
                embed.WithThumbnailUrl(user.Guild.IconUrl);
                await channel.SendMessageAsync("", false, embed);
            }

            if (user.Guild.Id == 419612620090245140)
            {
                await user.ModifyAsync(x =>
                {
                    x.Nickname = $"{user.Username}.cs";
                });
            }
        }

        public static async Task GuildUtils(SocketGuild s)
        {
            var dmChannel = await s.Owner.GetOrCreateDMChannelAsync();
            var embed = new EmbedBuilder();
            embed.WithTitle($"Thanks for adding me to your server, {s.Owner.Username}!");
            embed.WithDescription("For quick information, use the `w!help` command! \nNeed quick help? Visit the our server and ask away https://discord.gg/NuUdx4h!");
            embed.WithThumbnailUrl(s.IconUrl);
            embed.WithFooter("Still need help? Visit the Wsashi Bot server linked above.");
            embed.WithColor(37, 152, 255);

            await dmChannel.SendMessageAsync("", false, embed);
            GlobalGuildAccounts.SaveAccounts();

        }

        public static async Task FilterChecks(SocketMessage s)
        {

            var msg = s as SocketUserMessage;
            var context = new SocketCommandContext(_client, msg);
            if (context.User.IsBot) return;
            if (msg == null) return;

            var config = GlobalGuildAccounts.GetGuildAccount(context.Guild.Id);

            try
            {
                if (config.Antilink == false) return;

                else
                {
                    if (msg.Content.Contains("http") || msg.Content.Contains("www.") || msg.Content.Contains(".io") && !config.AntilinkIgnoredChannels.Contains(context.Channel.Id))
                    {
                        await msg.DeleteAsync();
                        var embed = new EmbedBuilder();
                        embed.WithDescription($":warning:  | {context.User.Mention}, Don't post your filthy links here! (No links)");
                        var mssg = await context.Channel.SendMessageAsync("", false, embed);
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
        "You're starting to bug me.."
};
            Random rand = new Random();
            List<string> bannedWords = new List<string>
                {
                     "fuck", "bitch", "gay", "shit", "pussy", "penis", "vagina", "nigger", "nigga", "suck", "eat my balls", "make me wet", "nude", "naked"," ass","asshole", "-ass", "cock", "dick", "cunt", "arse", "damn", "hell", "kill urslef", "kys", "slut", "hoe", "whore","retard", "gay", "autis", "screw you", "kill"
                };
            try
            {
                if (msg.Author.IsBot) return;
                if (config.Filter == false) return;
                else
                {
                    if (bannedWords.Any(msg.Content.ToLower().Contains))
                    {
                        int randomIndex = rand.Next(reactionTexts.Length);
                        string text = reactionTexts[randomIndex];
                        await msg.DeleteAsync();
                        var use = await msg.Channel.SendMessageAsync(":warning:  | " + text + " (Inappropiate language)");
                        await Task.Delay(5000);
                        await use.DeleteAsync();
                    }
                }
            }
            catch (NullReferenceException)
            {

                return;
            }

            if (config.MassPingChecks)
            {
                if (msg.Content.Contains("@everyone") || msg.Content.Contains("@here"))
                {
                    if (msg.Author != context.Guild.Owner)
                    {
                        await msg.DeleteAsync();
                        var msgg = await context.Channel.SendMessageAsync($":warning:  | {msg.Author.Mention}, try not to mass ping.");
                        Thread.Sleep(4000);
                        await msgg.DeleteAsync();
                    }
                }
            }
        }
    }
}
