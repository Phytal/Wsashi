﻿using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wsashi.Core.Modules;

namespace Wsashi.Modules
{
    public class Dming : WsashiModule
    {
        [Command("dm")]
        [Summary("DMs a specified user.")]
        public async Task Dm(IGuildUser user, [Remainder] string dm)
        {
            var rep = user.Id;

            var application = await Context.Client.GetApplicationInfoAsync();
            var message = await user.GetOrCreateDMChannelAsync();

            var embed = new EmbedBuilder()
            {
                Color = new Color(37, 152, 255)
            };

            embed.WithTitle($":mailbox_with_mail:  | You have recieved a DM from {Context.User.Username}!");
            embed.Description = $"{dm}";
            embed.WithFooter(new EmbedFooterBuilder().WithText($"Guild: {Context.Guild.Name}"));
            await message.SendMessageAsync("", false, embed);
            embed.Description = $":e_mail: | You have sent a message to {user.Username}, they will read the message soon.";

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
