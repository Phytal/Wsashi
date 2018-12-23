﻿using System;
using Discord.WebSocket;
using Wsashi.Features.Economy;
using Wsashi.Features.Trivia;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Discord;

namespace Wsashi
{
    internal static class Global
    {
        internal static DiscordShardedClient Client { get; set; }
        internal static Random Rng { get; set; } = new Random();
        internal static Dictionary<ulong, string> MessagesIdToTrack { get; set; }
        internal static List<TriviaGame> TriviaGames { get; set; } = new List<TriviaGame>();

        internal static Slot slot = new Slot();

        public static string ReplacePlacehoderStrings(this string messageString, IGuildUser user = null)
        {
            var result = messageString;
            if (user != null)
            {
                result = ReplaceGuildUserPlaceholderStrings(result, user);
            }

            if (Client != null)
            {
                result = ReplaceClientPlaceholderStrings(result);
            }

            return result;
        }

        private static string ReplaceGuildUserPlaceholderStrings(string messageString, IGuildUser user)
        {
            return messageString.Replace("<username>", user.Nickname ?? user.Username)
                .Replace("<usermention>", user.Mention)
                .Replace("<guildname>", user.Guild.Name);
        }

        private static string ReplaceClientPlaceholderStrings(string messageString)
        {
            return messageString.Replace("<botmention>", Client.CurrentUser.Mention)
                .Replace("<botdiscriminator>", Client.CurrentUser.Discriminator)
                .Replace("<botname>", Client.CurrentUser.Username);
        }

        public static async Task<string> SendWebRequest(string requestUrl)
        {
            using (var client = new HttpClient(new HttpClientHandler()))
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Wsashi");
                using (var response = await client.GetAsync(requestUrl))
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        return response.StatusCode.ToString();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
