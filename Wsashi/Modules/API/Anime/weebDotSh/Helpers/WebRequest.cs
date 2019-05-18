﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weeb.net;
using Weeb.net.Data;

namespace Wsashi.Modules.API.Anime.weebDotSh.Helpers
{
    public class WebRequest
    {
        WeebClient weebClient = new WeebClient("Wsashi", Config.bot.Version);

        public async Task<RandomData> GetTypesAsync(string type, IEnumerable<string> tags, FileType fileType,
            NsfwSearch nsfw, bool hidden)
        {
            await weebClient.Authenticate(Config.bot.wolkeToken, Weeb.net.TokenType.Wolke);
            var result =
                await weebClient.GetRandomAsync(type, tags, fileType, hidden,
                    nsfw); //hidden and nsfw are always defaulted to false

            if (result == null)
            {
                return null;
            }

            return result;


        }
    }
}
