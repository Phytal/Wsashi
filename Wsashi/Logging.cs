﻿using System.Threading.Tasks;
using System;
using Discord.WebSocket;
using Discord;
using Discord.Commands;
using Wsashi.Features.GlobalAccounts;

namespace Wsashi
{
    public static class Logging
    {
        public static async Task HandleBans(SocketUser user, SocketGuild server)
        {
            var config = GlobalGuildAccounts.GetGuildAccount(server.Id);
            var loggingChannel = server.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .AddField("User", $"{user.Username}#{user.Discriminator}")
                .WithTitle("User Banned")
                .AddField("Time", DateTime.UtcNow + " UTC")
                .WithThumbnailUrl("https://pbs.twimg.com/media/C9kEEmbXUAEX3r6.png")
                .WithAuthor(user)
                .WithColor(37, 152, 255);

            await loggingChannel.SendMessageAsync("", embed: embed.Build());
        }

        public static async Task HandleChannelCreate(SocketChannel chnl)
        {
            var config = GlobalGuildAccounts.GetGuildAccount((chnl as SocketTextChannel).Guild.Id);
            var loggingChannel = (chnl as SocketTextChannel).Guild.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .AddField("Channel Name", (chnl as SocketGuildChannel).Name)
                .WithTitle("Channel Created")
                .AddField("Time", DateTime.UtcNow + " UTC")
                .WithThumbnailUrl("https://vignette.wikia.nocookie.net/uncyclopedia/images/b/b2/Plus_sign.png/revision/latest?cb=20101129042826")
                .WithAuthor((chnl as SocketGuildChannel).Guild.Owner)
                .WithColor(37, 152, 255);

            await loggingChannel.SendMessageAsync("", embed: embed.Build());
        }

        public static async Task HandleChannelDelete(SocketChannel chnl)
        {
            var config = GlobalGuildAccounts.GetGuildAccount((chnl as SocketTextChannel).Guild.Id);
            var loggingChannel = (chnl as SocketTextChannel).Guild.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .AddField("Channel Name", (chnl as SocketGuildChannel).Name)
                .WithTitle("Channel Deleted")
                .AddField("Time", DateTime.UtcNow + " UTC")
                .WithThumbnailUrl("https://openclipart.org/image/2400px/svg_to_png/91861/Remove-349235435.png")
                .WithAuthor((chnl as SocketGuildChannel).Guild.Owner)
                .WithColor(37, 152, 255);

            await loggingChannel.SendMessageAsync("", embed: embed.Build());
        }

        public static async Task HandleServerUpdate(SocketGuild server, SocketGuild guild)
        {
            var config = GlobalGuildAccounts.GetGuildAccount(server.Id);
            var loggingChannel = guild.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .AddField("Name", guild.Name)
                .AddField("Region", guild.VoiceRegionId)
                .AddField("Owner", $"{guild.Owner.Username}#{guild.Owner.Discriminator}")
                .WithTitle("Server Updated")
                .AddField("Time", DateTime.UtcNow + " UTC")
                .WithThumbnailUrl("https://i.imgur.com/fqwyqT1.png")
                .WithAuthor(guild.Owner)
                .WithColor(37, 152, 255);

            await loggingChannel.SendMessageAsync("", embed: embed.Build());
        }

        public static async Task HandleMessageDelete(Cacheable<IMessage, ulong> message, ISocketMessageChannel channel)
        {
            var msg = message.Value as SocketUserMessage;
            var context = new SocketCommandContext(Program._client, msg);
            var config = GlobalGuildAccounts.GetGuildAccount(context.Guild.Id);
            var loggingChannel = context.Guild.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .AddField("Author", context.Message.Author)
                .WithTitle("Message Deleted")
                .AddField("Message Content", message.Value.Content)
                .AddField("Time", DateTime.UtcNow + " UTC")
                .WithThumbnailUrl("https://lh3.googleusercontent.com/G2jzG8a6-GAA4yhxx3XMJfPXsm6_pluyeEWKr9I5swUGF62d2xo_Qg3Kdnu00HAmDQ=s180")
                .WithAuthor(context.Guild.Owner)
                .WithColor(37, 152, 255);

            await loggingChannel.SendMessageAsync("", embed: embed.Build());
        }

        public static async Task HandleMessageUpdate(Cacheable<IMessage, ulong> message, SocketMessage s, ISocketMessageChannel channel)
        {
            var msg = s as SocketUserMessage;
            var context = new SocketCommandContext(Program._client, msg);
            var config = GlobalGuildAccounts.GetGuildAccount(context.Guild.Id);
            var loggingChannel = context.Guild.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .AddField("Author", message.Value.Author)
                .WithTitle("Message Edited")
                .AddField("Before", message.Value.Content)
                .AddField("After", s.Content)
                .AddField("Time", DateTime.UtcNow + " UTC")
                .WithThumbnailUrl("https://i.imgur.com/fqwyqT1.png")
                .WithAuthor(context.Guild.Owner)
                .WithColor(37, 152, 255);

            await loggingChannel.SendMessageAsync("", embed: embed.Build());
        }

        public static async Task HandleRoleCreation(SocketRole role)
        {
            var config = GlobalGuildAccounts.GetGuildAccount(role.Guild.Id);
            var loggingChannel = role.Guild.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .AddField("Name", role.Name)
                .AddField("ID", role.Id)
                .WithTitle("Role Created")
                .AddField("Colour", role.Color.RawValue.ToString())
                .AddField("Mentionable", role.IsMentionable)
                .AddField("Displayed Separately", role.IsHoisted)
                .AddField("Time", DateTime.UtcNow + " UTC")
                .WithThumbnailUrl("https://vignette.wikia.nocookie.net/uncyclopedia/images/b/b2/Plus_sign.png/revision/latest?cb=20101129042826")
                .WithAuthor(role.Guild.Owner)
                .WithColor(37, 152, 255);

            await loggingChannel.SendMessageAsync("", embed: embed.Build());
        }

        public static async Task HandleRoleUpdate(SocketRole roleBefore, SocketRole roleAfter)
        {
            var config = GlobalGuildAccounts.GetGuildAccount(roleAfter.Guild.Id);
            var loggingChannel = roleAfter.Guild.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .WithDescription(
                "**Name**\n" +
                $"  **Before**: {roleBefore.Name}\n" +
                $"  **After**: {roleAfter.Name}\n" +
                "**Colour**\n" +
                $"  **Before**: ({roleBefore.Color.R}, {roleBefore.Color.G}, {roleBefore.Color.B})\n" +
                $"  **After**: ({roleAfter.Color.R}, {roleAfter.Color.G}, {roleAfter.Color.B})\n" +
                "**Mentionable**\n" +
                $"  **Before**: {roleBefore.IsMentionable}\n" +
                $"  **After**: {roleAfter.IsMentionable}\n" +
                "**Displayed Separately**\n" +
                $"  **Before**: {roleBefore.IsHoisted}\n" +
                $"  **After**: {roleAfter.IsHoisted}\n" +
                $"**Time**: {DateTime.UtcNow} UTC")
                .WithAuthor(roleAfter.Guild.Owner)
                .WithThumbnailUrl("https://content.mycutegraphics.com/graphics/pencil/sharp-pencil.png")
                .WithColor(37, 152, 255);

            await loggingChannel.SendMessageAsync("", embed: embed.Build());
        }

        public static async Task HandleRoleDelete(SocketRole role)
        {
            var config = GlobalGuildAccounts.GetGuildAccount(role.Guild.Id);
            var loggingChannel = role.Guild.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .AddField("Name", role.Name)
                .AddField("ID", role.Id)
                .WithTitle("Role Deleted")
                .AddField("Time", DateTime.UtcNow + " UTC")
                .WithThumbnailUrl("https://lh3.googleusercontent.com/G2jzG8a6-GAA4yhxx3XMJfPXsm6_pluyeEWKr9I5swUGF62d2xo_Qg3Kdnu00HAmDQ=s180")
                .WithAuthor(role.Guild.Owner)
                .WithColor(37, 152, 255);

            await loggingChannel.SendMessageAsync("", embed: embed.Build());
        }

        public static async Task HandleUserUpdate(SocketUser userBefore, SocketUser userAfter)
        {
            var uB = userBefore as SocketGuildUser;
            var uA = userAfter as SocketGuildUser;
            var config = GlobalGuildAccounts.GetGuildAccount(uB.Guild.Id);
            var loggingChannel = uB.Guild.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .WithDescription(
                $"**Name**\n" +
                $"  **Before**: {uB.Username}\n" +
                $"  **After**: {uA.Username}\n" +
                $"**Nickname**\n" +
                $"  **Before**: {uB.Nickname})\n" +
                $"  **After**: {uA.Nickname}\n" +
                $"**Profile Pic**\n" +
                $"  **Before**: {uB.GetAvatarUrl()}\n" +
                $"  **After**: {uA.GetAvatarUrl()}\n" +
                $"**Discriminator**\n" +
                $"  **Before**: {uB.Discriminator}\n" +
                $"  **After**: {uA.Discriminator}\n" +
                $"**Time**: {DateTime.UtcNow} UTC")
                .WithAuthor(uA.Guild.Owner)
                .WithThumbnailUrl("https://content.mycutegraphics.com/graphics/pencil/sharp-pencil.png")
                .WithColor(37, 152, 255);

            await loggingChannel.SendMessageAsync("", embed: embed.Build());
        }
    }
}