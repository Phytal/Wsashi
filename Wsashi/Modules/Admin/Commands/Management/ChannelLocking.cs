﻿using Discord;
using Discord.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using Wsashi.Core.Modules;
using Wsashi.Features.GlobalAccounts;
using Wsashi.Preconditions;
using Wsashi.Helpers;

namespace Wsashi.Modules.Management.Commands
{
    public class ChannelLocking : WsashiModule
    {
        [Command("lockchannel"), Alias("lc")]
        [Summary("Locks the current channel (users will be unable to send messages, only admins)")]
        [Remarks("w!lc")]
        [Cooldown(5)]
        public async Task LockChannel()
        {
            var guser = Context.User as SocketGuildUser;
            if (guser.GuildPermissions.ManageChannels)
            {
                var chnl = Context.Channel as ITextChannel;
                var role = Context.Guild.Roles.FirstOrDefault(r => r.Name == "@everyone");
                var perms = new OverwritePermissions(
                    sendMessages: PermValue.Deny
                    );
                await chnl.AddPermissionOverwriteAsync(role, perms);

                var embed = MiscHelpers.CreateEmbed(Context, "Channel Locked", $":lock: Locked {Context.Channel.Name}.");
                await MiscHelpers.SendMessage(Context, embed);
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.Title = $":x:  | You Need the Manage Channels Permission to do that {Context.User.Username}";
                await ReplyAndDeleteAsync("", embed: embed.Build(), timeout: TimeSpan.FromSeconds(5));
            }
        }

        [Command("unlockchannel"), Alias("ulc")]
        [Summary("Unlocks the current channel (users can send messages again)")]
        [Remarks("w!ulc")]
        [Cooldown(5)]
        public async Task UnlockChannel()
        {
            var guser = Context.User as SocketGuildUser;
            if (guser.GuildPermissions.ManageChannels)
            {
                var chnl = Context.Channel as ITextChannel;
                var role = Context.Guild.Roles.FirstOrDefault(r => r.Name == "@everyone");
                var perms = new OverwritePermissions(
                    sendMessages: PermValue.Allow
                    );
                await chnl.AddPermissionOverwriteAsync(role, perms);

                var embed = MiscHelpers.CreateEmbed(Context, "Channel Unlocked", $":unlock: Unlocked {Context.Channel.Name}.").WithColor(37, 152, 255);
                await MiscHelpers.SendMessage(Context, embed);
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithColor(37, 152, 255);
                embed.Title = $":x:  | You Need the Manage Channels Permission to do that {Context.User.Username}";
                await ReplyAndDeleteAsync("", embed: embed.Build(), timeout: TimeSpan.FromSeconds(5));
            }
        }
    }
}
