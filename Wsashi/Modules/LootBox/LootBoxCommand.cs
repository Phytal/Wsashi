﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Linq;
using System.Threading.Tasks;
using Wsashi.Core.Modules;
using Wsashi.Features.GlobalAccounts;
using Wsashi.Preconditions;

namespace Wsashi.Modules.LootBox
{
    public class LootBoxCommand : WsashiModule
    {
        [Command("openLootBox")]
        [Alias("olb")]
        [Summary("Opens one of the loot boxes you have")]
        [Remarks("Usage: w!openLootBox <rarity (common/uncommon/rare/epic/legendary) Ex: w!openLootBox common")]
        public async Task OpenLootBoxCommand([Remainder] string arg)
        {
            var config = GlobalUserAccounts.GetUserAccount(Context.User);

            if (arg == "common")
            {
                if (config.LootBoxCommon > 0)
                {
                    config.LootBoxCommon -= 1;
                    await OpenLootBox.OpenCommonBox(Context.User, (ITextChannel)Context.Channel);
                }
                else
                {
                    await Context.Channel.SendMessageAsync($":octagonal_sign:  |  **{Context.User.Username}**, you don't have any Common Loot Boxes!");
                    return;
                }
            }
            if (arg == "uncommon")
            {
                if (config.LootBoxCommon > 0)
                {
                    config.LootBoxUncommon -= 1;
                    await OpenLootBox.OpenUncommonBox(Context.User, (ITextChannel)Context.Channel);
                }
                else
                {
                    await Context.Channel.SendMessageAsync($":octagonal_sign:  |  **{Context.User.Username}**, you don't have any Uncommon Loot Boxes!");
                    return;
                }
            }
            if (arg == "rare")
            {
                if (config.LootBoxRare > 0)
                {
                    config.LootBoxRare -= 1;
                    await OpenLootBox.OpenRareBox(Context.User, (ITextChannel)Context.Channel);
                }
                else
                {
                    await Context.Channel.SendMessageAsync($":octagonal_sign:  |  **{Context.User.Username}**, you don't have any Rare Loot Boxes!");
                    return;
                }
            }
            if (arg == "epic")
            {
                if (config.LootBoxEpic > 0)
                {
                    config.LootBoxEpic -= 1;
                    await OpenLootBox.OpenEpicBox(Context.User, (ITextChannel)Context.Channel);
                }
                else
                {
                    await Context.Channel.SendMessageAsync($":octagonal_sign:  |  **{Context.User.Username}**, you don't have any Epic Loot Boxes!");
                    return;
                }
            }
            if (arg == "legendary")
            {
                if (config.LootBoxLegendary > 0)
                {
                    config.LootBoxLegendary -= 1;
                    await OpenLootBox.OpenLegendaryBox(Context.User, (ITextChannel)Context.Channel);
                }
                else
                {
                    await Context.Channel.SendMessageAsync($":octagonal_sign:  |  **{Context.User.Username}**, you don't have any Legendary Loot Boxes!");
                    return;
                }
            }
            return;
        }

        [Command("lootBoxInventory"), Alias("lbi")]
        [Summary("View your loot box inventory")]
        [Remarks("Usage: w!inventory")]
        public async Task LootBoxInventory()
        {
            var account = GlobalUserAccounts.GetUserAccount(Context.User);
            var embed = new EmbedBuilder();
            embed.WithTitle($"{Context.User.Username}'s Loot Box Inventory");

            embed.AddField("Common Loot Boxes", $"**x{account.LootBoxCommon}**");
            embed.AddField("Uncommon Loot Boxes", $"**x{account.LootBoxUncommon}**");
            embed.AddField("Rare loot Boxes", $"**x{account.LootBoxRare}**");
            embed.AddField("Epic Loot Boxes", $"**x{account.LootBoxEpic}**");
            embed.AddField("Legendary Loot Boxes", $"**x{account.LootBoxLegendary}**");
            embed.WithFooter("You can get Loot Boxes from increasing your Wsashi Level (not server level) and winning duels!");

            await Context.Channel.SendMessageAsync("", embed: embed.Build());
        }

        [Command("addLootBox"), Alias("alb")]
        [Summary("Adds some loot boxes to a person")]
        [Remarks("Usage: w!alb <user>")]
        [RequireOwner]
        public async Task AddLootBox([Remainder] string arg = "")
        {
            SocketUser target = null;
            var mentionedUser = Context.Message.MentionedUsers.FirstOrDefault();
            target = mentionedUser ?? Context.User;

            var account = GlobalUserAccounts.GetUserAccount(target);
            account.LootBoxCommon += 1;
            account.LootBoxUncommon += 1;
            account.LootBoxRare += 1;
            account.LootBoxEpic += 1;
            account.LootBoxLegendary += 1;
            GlobalUserAccounts.SaveAccounts();

            await Context.Channel.SendMessageAsync($"Successfully added one of every loot box to {target}");
        }

        [Command("giftLootbox")]
        [Alias("giftlb", "grantlb", "glb")]
        [Summary("Gifts a lootbox to a selected user from your arsenal of lootboxes Ex: w!giftlb epic @user")]
        [Remarks("w!giftlb <rarity> <user you want to gift to> Ex: w!giftlb rare @Phytal")]
        [Cooldown(10)]
        public async Task Gift(string Rarity, IGuildUser userB)
        {
            var giveaccount = GlobalUserAccounts.GetUserAccount(Context.User);

            Rarity = Rarity.ToUpper();
            uint numOfLootboxes = 0;
            if (Rarity == "COMMON") numOfLootboxes = giveaccount.LootBoxCommon;
            if (Rarity == "UNCOMMON") numOfLootboxes = giveaccount.LootBoxUncommon;
            if (Rarity == "RARE") numOfLootboxes = giveaccount.LootBoxRare;
            if (Rarity == "EPIC") numOfLootboxes = giveaccount.LootBoxEpic;
            if (Rarity == "LEGENDARY") numOfLootboxes = giveaccount.LootBoxLegendary;

            if (numOfLootboxes < 1)
            {
                await ReplyAsync(":angry:  | Stop trying to gift lootboxes you don't have!");
            }
            else
            {
                if (userB == null)
                {
                    var embed = new EmbedBuilder();
                    embed.WithColor(37, 152, 255);
                    embed.WithTitle(":hand_splayed:  | Please say who you want to gift lootboxes to. Ex: w!gift <rarity of lootbox> @user");
                    await Context.Channel.SendMessageAsync("", embed: embed.Build());
                }
                else
                {
                    SocketUser target = null;
                    var mentionedUser = Context.Message.MentionedUsers.FirstOrDefault();
                    target = mentionedUser ?? Context.User;

                    var receiver = GlobalUserAccounts.GetUserAccount((SocketUser)userB);

                    if (Rarity == "COMMON") { giveaccount.LootBoxCommon--; receiver.LootBoxCommon++; }
                    if (Rarity == "UNCOMMON") { giveaccount.LootBoxUncommon--; receiver.LootBoxUncommon++; }
                    if (Rarity == "RARE") { giveaccount.LootBoxRare--; receiver.LootBoxRare++; }
                    if (Rarity == "EPIC") { giveaccount.LootBoxEpic--; receiver.LootBoxEpic++; }
                    if (Rarity == "LEGENDARY") { giveaccount.LootBoxLegendary--; receiver.LootBoxLegendary++; }

                    GlobalUserAccounts.SaveAccounts();

                    await Context.Channel.SendMessageAsync($":gift:  | {Context.User.Mention} has gifted {userB.Mention} a **{Rarity}** Lootbox! How generous.");
                }
            }
        }
    }
}
