﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsashi.Core.Modules;
using Wsashi.Preconditions;

namespace Wsashi.Modules.ServerManagement
{
    public class Reports_Channel : WsashiModule
    {
        [Command("reports")]
        [Summary("If the reports channel isn't automatically created, you can use this command to manually create it")]
        [Remarks("Ex: w!reports")]
        [Cooldown(10)]
        [RequireBotPermission(GuildPermission.ManageChannels)]
        public async Task Text()
        {
            var guser = Context.User as SocketGuildUser;
            if (guser.GuildPermissions.ManageMessages)
            {
                var role = Context.Guild.Roles.FirstOrDefault(r => r.Name == "@everyone");
                var perms = new OverwritePermissions(
                    sendMessages: PermValue.Deny,
                    addReactions: PermValue.Deny,
                    viewChannel: PermValue.Allow
                    );
                var channel = await Context.Guild.CreateTextChannelAsync("Reports");
                await channel.AddPermissionOverwriteAsync(role, perms);
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.Title = $":x:  | You Need the Administrator Permission to do that {Context.User.Username}";
                var use = await Context.Channel.SendMessageAsync("", embed: embed.Build());
                await Task.Delay(5000);
                await use.DeleteAsync();
            }
        }

        [Command("Report")]
        [Summary("Reports @Username")]
        [Remarks("w!report <user> <reason> Ex: w!report @Phytal abusing")]
        [Cooldown(10)]
        public async Task ReportAsync(SocketGuildUser user, [Remainder] string reason)
        {
            if ((user == null)
                || (string.IsNullOrWhiteSpace(reason)))
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.WithTitle(":hand_splayed:  | You must mention a user and provide a reason. Ex: w!report @Username <reason>");
                var use = await Context.Channel.SendMessageAsync("", embed: embed.Build());
                await Task.Delay(5000);
                await use.DeleteAsync();
            }
            else
            {
                var chnl = Context.Guild.TextChannels.FirstOrDefault(r => r.Name == "reports");
                if (chnl == null)
                {
                    var role = Context.Guild.Roles.FirstOrDefault(r => r.Name == "@everyone");
                    var perms = new OverwritePermissions(
                        sendMessages: PermValue.Deny,
                        addReactions: PermValue.Deny,
                        viewChannel: PermValue.Allow
                        );
                    var channell = await Context.Guild.CreateTextChannelAsync("reports");
                    await channell.AddPermissionOverwriteAsync(role, perms);
                }
                var channel = chnl as SocketTextChannel;
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.Title = $"{Context.User}'s report of {user.Username}";
                embed.Description = $"**Username: **{user.Username}\n**Reported by: **{Context.User.Mention}\n**Reason: **{reason}";
                await channel.SendMessageAsync("", embed: embed.Build());
                await ReplyAsync(":white_check_mark:  | *Your report has been furthered to staff.* ***(ABUSE OF THIS COMMAND IS PUNISHABLE)***");
            }
        }

        public async Task GetReportChannel(IGuild guild)
        {
            var channelName = "Reports";

            var TextChannel = Context.Guild.TextChannels.FirstOrDefault(r => r.Name == channelName);

            if (TextChannel == null)
            {
                var role = Context.Guild.Roles.FirstOrDefault(r => r.Name == "@everyone");
                var perms = new OverwritePermissions(
                    sendMessages: PermValue.Deny,
                    addReactions: PermValue.Deny,
                    viewChannel: PermValue.Allow
                    );
                var channel = await Context.Guild.CreateTextChannelAsync("Reports");
                await channel.AddPermissionOverwriteAsync(role, perms);
            }
            return;
        }
    }   
}
