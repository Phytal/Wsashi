﻿using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsashi.Features.GlobalAccounts;

namespace Wsashi.Handlers
{
    public class MessageRewardHandler
    {
        public async Task HandleMessageRewards(SocketMessage s)
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