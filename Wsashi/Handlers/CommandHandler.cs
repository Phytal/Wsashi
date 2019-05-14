﻿using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Wsashi.Core.LevelingSystem;
using Wsashi.Modules.Games;
using Wsashi.Features.GlobalAccounts;
using Discord;
using System.Collections.Generic;
using Wsashi.Handlers;
using Wsashi.Features.Trivia;
using System.Collections.Concurrent;
using Wsashi.Modules;
using Weeb.net;

namespace Wsashi
{
    public class CommandHandler
    {
        private DiscordShardedClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        //readonly ConcurrentDictionary<CooldownInfo, DateTime> _cooldowns = new ConcurrentDictionary<CooldownInfo, DateTime>();

        public CommandHandler(IServiceProvider services, CommandService commands,
    DiscordShardedClient client)
        {
            _commands = commands;
            _services = services;
            _client = client;

        }
        WeebClient weebClient = new WeebClient("Wsashi", Config.bot.Version);

        public async Task InitializeAsync()
        {
            _commands = new CommandService();
            var cmdConfig = new CommandServiceConfig
            {
                DefaultRunMode = RunMode.Async
            };
            await _commands.AddModulesAsync(
                Assembly.GetEntryAssembly(),
                _services);
            Global.Client = _client;
            //Will print current weeb.sh API version and Weeb.net wrapper version
            await weebClient.Authenticate(Config.bot.wolkeToken, Weeb.net.TokenType.Wolke);
        }

        public async Task HandleCommandAsync(SocketMessage s)
        {
            _ = Events.FilterUnflip(s);
            _ = Modules.Management.SlowMode.HandleSlowMode(s);

            if (!(s is SocketUserMessage msg)) return;
            if (msg.Channel is SocketDMChannel) return;

            var context = new ShardedCommandContext(_client, msg);
            if (context.User.IsBot) return;

            /*var key = new CooldownInfo(context.User.Id);
            // Check if message with the same hash code is already in dictionary 
            if (_cooldowns.TryGetValue(key, out DateTime endsAt))
            {
                // Calculate the difference between current time and the time cooldown should end
                var difference = endsAt.Subtract(DateTime.UtcNow);
                var timeSpanString = string.Format("{0:%s} seconds", difference);
                // Display message if command is on cooldown
                if (difference.Ticks > 0)
                {
                    await context.Channel.SendMessageAsync($"You can use a command in {timeSpanString}");
                    return;
                }
                // Update cooldown time
                var time = DateTime.UtcNow.Add(TimeSpan.FromSeconds(2));
                _cooldowns.TryUpdate(key, time, endsAt);
            }
            else
            {
                _cooldowns.TryAdd(key, DateTime.UtcNow.Add(TimeSpan.FromSeconds(2)));
            }*/


            var config = GlobalGuildAccounts.GetGuildAccount(context.Guild.Id);
            var prefix = config.CommandPrefix ?? Config.bot.cmdPrefix;

            var argPos = 0;
            if (msg.HasStringPrefix(prefix, ref argPos) && (context.Guild == null || context.Guild.Id != 264445053596991498 || context.Guild.Id != 396440418507816960) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos) && (context.Guild == null || context.Guild.Id != 264445053596991498 || context.Guild.Id != 396440418507816960))
            {
                foreach (var command in config.CustomCommands)
                    if (msg.HasStringPrefix($"{config.CommandPrefix}{command.Key}", ref argPos))
                    {
                        await context.Channel.SendMessageAsync(command.Value);
                    }

                var cmdSearchResult = _commands.Search(context, argPos);
                if (cmdSearchResult.Commands.Count == 0) await context.Channel.SendMessageAsync($"{context.User.Mention}, that is not a valid command");

                var executionTask = _commands.ExecuteAsync(context, argPos, _services);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                executionTask.ContinueWith(task =>
                {
                    if (task.Result.IsSuccess || task.Result.Error == CommandError.UnknownCommand) return;
                    const string errTemplate = "{0}, Error: {1}.";
                    var errMessage = string.Format(errTemplate, context.User.Mention, task.Result.ErrorReason);
                    var embed = new EmbedBuilder()
                    .WithColor(37, 152, 255)
                    .WithTitle("Error!")
                    .WithDescription(errMessage)
                    .WithFooter("Did you use the command correctly? If so, please report this to our discord server https://discord.gg/NuUdx4h");
                    context.Channel.SendMessageAsync("", embed: embed.Build());
                });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }

            // Leveling up
            if (config.Leveling)
            {
                await Leveling.Level((SocketGuildUser)context.User, (SocketTextChannel)context.Channel);
                await Leveling.WsashiLevel((SocketGuildUser)context.User, (SocketTextChannel)context.Channel);
                await Leveling.MessageRewards((SocketGuildUser)context.User, (SocketTextChannel)context.Channel, s);
            }
        }

        /*public struct CooldownInfo
        {
            public ulong UserId { get; }

            public CooldownInfo(ulong userId)
            {
                UserId = userId;
            }

        }*/
        public async Task ReactionWasAdded(Cacheable<IUserMessage, ulong> message, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (Timeouts.HasCommandTimeout(reaction.UserId, "REACTION", 1)) return;
            await G2048ReactionInput.HandleReaction(message, reaction);
        }

        public async Task _UserJoined(SocketGuildUser user)
        {
            _ = UserJoined(user);
        }
        private async Task UserJoined(SocketGuildUser user)
        {
            var guildAcc = GlobalGuildAccounts.GetGuildAccount(user.Guild.Id);
            if (guildAcc.WelcomeChannel == 0) return;
            if (!(_client.GetChannel(guildAcc.WelcomeChannel) is SocketTextChannel channel)) return;
            var possibleMessages = guildAcc.WelcomeMessages;
            var messageString = possibleMessages[Global.Rng.Next(possibleMessages.Count)];
            messageString = messageString.ReplacePlacehoderStrings(user);
            if (string.IsNullOrEmpty(messageString)) return;
            await channel.SendMessageAsync(messageString);
        }

        public async Task _UserLeft(SocketGuildUser user)
        {
            _ = UserLeft(user);
        }

        private async Task UserLeft(SocketGuildUser user)
        {
            var guildAcc = GlobalGuildAccounts.GetGuildAccount(user.Guild.Id);
            if (guildAcc.LeaveChannel == 0) return;
            if (!(_client.GetChannel(guildAcc.LeaveChannel) is SocketTextChannel channel)) return;
            var possibleMessages = guildAcc.LeaveMessages;
            var messageString = possibleMessages[Global.Rng.Next(possibleMessages.Count)];
            messageString = messageString.ReplacePlacehoderStrings(user);
            if (string.IsNullOrEmpty(messageString)) return;
            await channel.SendMessageAsync(messageString);
        }

        public async Task OnReactionAdded(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (!reaction.User.Value.IsBot)
            {
                var msgList = Global.MessagesIdToTrack ?? new Dictionary<ulong, string>();
                if (msgList.ContainsKey(reaction.MessageId))
                {
                    if (reaction.Emote.Name == "➕")
                    {
                        var item = msgList.FirstOrDefault(k => k.Key == reaction.MessageId);
                        var embed = BlogHandler.SubscribeToBlog(reaction.User.Value.Id, item.Value);
                    }
                }
                // Checks if the rection is associated with a running game and if it is 
                // from the same user who ran the command - if so it handles it
                await TriviaGames.HandleReactionAdded(cache, reaction);
            }
        }

        public async Task OnReactionAddedDuelRequest(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (!reaction.User.Value.IsBot)
            {
                var context = new ShardedCommandContext(Global.Client, (SocketUserMessage)reaction.Message);
                if (!PendingDuelProvider.UserIsPlaying(reaction.UserId)) return;
                var emote = Emote.Parse("<:no:453716729525174273>");
                var user = (SocketGuildUser)reaction.User;
                var req = PendingDuelProvider.RequestUser(reaction.UserId);
                var requester = Global.Client.GetUser(req);
                if (reaction.Emote.Name == emote.Name)
                {
                    var game = PendingDuelProvider.games.FirstOrDefault(g => g.PlayerId == reaction.UserId);
                    PendingDuelProvider.games.Remove(game);
                    await context.Message.DeleteAsync();
                    await channel.SendMessageAsync($"**{user.Username}** has declined **{requester.Username}**'s duel request!");
                }
                if (reaction.Emote.Name == "✅")
                {
                    var game = PendingDuelProvider.games.FirstOrDefault(g => g.PlayerId == reaction.UserId);
                    PendingDuelProvider.games.Remove(game);
                    await context.Message.DeleteAsync();
                    await channel.SendMessageAsync($"**{user.Username}** has accepted **{requester.Username}**'s duel request!");
                    await Duel.StartDuel(channel, user, requester);
                }
                else
                {
                    return;
                }
            }
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message ?? msg.Exception.ToString());
        }
        
        private async Task AttemptLogin()
        {
            try
            {
                await _client.LoginAsync(Discord.TokenType.Bot, Config.bot.token);
            }
            catch
            {
                Console.WriteLine("The BOT Token is most likely incorrect.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
