﻿using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wsashi.Core.Modules;
using Wsashi.Features.GlobalAccounts;
using Wsashi.Preconditions;

namespace Wsashi.Modules.API.Overwatch
{
    public class HeroStats : InteractiveBase
    {
        [Command("owherostats")]
        [Summary("Get a Overwatch user's statistics for a specific hero on both Quickplay and Competitive.")]
        [Alias("owhs")]
        [Remarks("w!owherostats <hero> <Your Battle.net username and id> <platform (pc/xbl/psn)> <region (us/eu etc.)> Ex: w!owherostats dVa Phytal-1427 pc us")]
        [Cooldown(10)]
        public async Task GetOwHeroStats(string hero, string username, string platform, string region)
        {
            try
            {
                string originalhero = hero;
                var config = GlobalUserAccounts.GetUserAccount(Context.User);
                hero = hero.ToLower();
                hero = GetHero(hero);

                var json = await Global.SendWebRequest($"https://ow-api.com/v1/stats/{platform}/{region}/{username}/heroes/{hero}");

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string endorsementIcon = dataObject.endorsementIcon.ToString();
                string playerIcon = dataObject.icon.ToString();
                string srIcon = dataObject.ratingIcon.ToString();
                //compstats
                //avg
                string CompAllDamageAvg = dataObject.competitiveStats.careerStats[hero].average.allDamageDoneAvgPer10Min.ToString();
                string CompBarrierDamageAvg = dataObject.competitiveStats.careerStats[hero].average.barrierDamageDoneAvgPer10Min.ToString();
                string CompCriticalsAvg = dataObject.competitiveStats.careerStats[hero].average.criticalHitsAvgPer10Min.ToString();
                string CompDeathAvg = dataObject.competitiveStats.careerStats[hero].average.deathsAvgPer10Min.ToString();
                string CompElimAvg = dataObject.competitiveStats.careerStats[hero].average.eliminationsAvgPer10Min.ToString();
                string CompElimPerLife = dataObject.competitiveStats.careerStats[hero].average.eliminationsPerLife.ToString();
                string CompFinalBlowAvg = dataObject.competitiveStats.careerStats[hero].average.finalBlowsAvgPer10Min.ToString();
                string CompHeroDamageAvg = dataObject.competitiveStats.careerStats[hero].average.heroDamageDoneAvgPer10Min.ToString();
                string CompMeleeAvg = dataObject.competitiveStats.careerStats[hero].average.meleeFinalBlowsAvgPer10Min.ToString();
                string CompObjKillsAvg = dataObject.competitiveStats.careerStats[hero].average.objectiveKillsAvgPer10Min.ToString();
                string CompObjTimeAvg = dataObject.competitiveStats.careerStats[hero].average.objectiveTimeAvgPer10Min.ToString();
                string CompSoloKillAvg = dataObject.competitiveStats.careerStats[hero].average.soloKillsAvgPer10Min.ToString();
                string CompOnFireAvg = dataObject.competitiveStats.careerStats[hero].average.timeSpentOnFireAvgPer10Min.ToString();
                //best
                string CompAllDamageInGame = dataObject.competitiveStats.careerStats[hero].best.allDamageDoneMostInGame.ToString();
                string CompAllDamageInLife = dataObject.competitiveStats.careerStats[hero].best.allDamageDoneMostInLife.ToString();
                string CompBarrierDamageInGame = dataObject.competitiveStats.careerStats[hero].best.barrierDamageDoneMostInGame.ToString();
                string CompCritMostInGame = dataObject.competitiveStats.careerStats[hero].best.criticalHitsMostInGame.ToString();
                string CompCritMostInLife = dataObject.competitiveStats.careerStats[hero].best.criticalHitsMostInLife.ToString();
                string CompElimMostInLife = dataObject.competitiveStats.careerStats[hero].best.eliminationsMostInLife.ToString();
                string CompElimMostInGame = dataObject.competitiveStats.careerStats[hero].best.eliminationsMostInGame.ToString();
                string CompFinalBlowMostInGame = dataObject.competitiveStats.careerStats[hero].best.finalBlowsMostInGame.ToString();
                string CompHeroDmgMostInGame = dataObject.competitiveStats.careerStats[hero].best.heroDamageDoneMostInGame.ToString();
                string CompHeroDmgMostInLife = dataObject.competitiveStats.careerStats[hero].best.heroDamageDoneMostInLife.ToString();
                string CompKillStreakBest = dataObject.competitiveStats.careerStats[hero].best.killsStreakBest.ToString();
                string CompMeleeFinalBlowMostInGame = dataObject.competitiveStats.careerStats[hero].best.meleeFinalBlowsMostInGame.ToString();
                string CompMultikillBest = dataObject.competitiveStats.careerStats[hero].best.multikillsBest.ToString();
                string CompObjKillMostInGame = dataObject.competitiveStats.careerStats[hero].best.objectiveKillsMostInGame.ToString();
                string CompObjTimeMostInGame = dataObject.competitiveStats.careerStats[hero].best.objectiveTimeMostInGame.ToString();
                string CompSoloKillsMostInGame = dataObject.competitiveStats.careerStats[hero].best.soloKillsMostInGame.ToString();
                string CompOnFireMostInGame = dataObject.competitiveStats.careerStats[hero].best.timeSpentOnFireMostInGame.ToString();
                string CompWeaponAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].best.weaponAccuracyBestInGame.ToString();
                //combat
                string CompBarrierDmgDone = dataObject.competitiveStats.careerStats[hero].combat.barrierDamageDone.ToString();
                string CompCriticalHits = dataObject.competitiveStats.careerStats[hero].combat.criticalHits.ToString();
                string CompCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].combat.criticalHitsAccuracy.ToString();
                string CompDamageDone = dataObject.competitiveStats.careerStats[hero].combat.damageDone.ToString();
                string CompDeaths = dataObject.competitiveStats.careerStats[hero].combat.deaths.ToString();
                string CompElims = dataObject.competitiveStats.careerStats[hero].combat.eliminations.ToString();
 
                string CompFinalBlows = dataObject.competitiveStats.careerStats[hero].combat.finalBlows.ToString();
                string CompHeroDmg = dataObject.competitiveStats.careerStats[hero].combat.heroDamageDone.ToString();
                string CompMeleeFinalBlows = dataObject.competitiveStats.careerStats[hero].combat.meleeFinalBlows.ToString();
                string CompMultikills = dataObject.competitiveStats.careerStats[hero].combat.multikills.ToString();
                string CompObjKills = dataObject.competitiveStats.careerStats[hero].combat.objectiveKills.ToString();
                string CompObjTime = dataObject.competitiveStats.careerStats[hero].combat.objectiveTime.ToString();
                string CompMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].combat.quickMeleeAccuracy.ToString();
                string CompSoloKills = dataObject.competitiveStats.careerStats[hero].combat.soloKills.ToString();
                string CompOnFire = dataObject.competitiveStats.careerStats[hero].combat.timeSpentOnFire.ToString();
                string CompWeaponAccuracy = dataObject.competitiveStats.careerStats[hero].combat.weaponAccuracy.ToString();
                //misc stuff
                string CompGamesPlayed = dataObject.competitiveStats.careerStats[hero].game.gamesPlayed.ToString();
                string CompGamesWon = dataObject.competitiveStats.careerStats[hero].game.gamesWon.ToString();
                string CompGamesTied = dataObject.competitiveStats.careerStats[hero].game.gamesTied.ToString();
                string CompGamesLost = dataObject.competitiveStats.careerStats[hero].game.gamesLost.ToString();
                string CompTimePlayed = dataObject.competitiveStats.careerStats[hero].game.timePlayed.ToString();
                string CompWinPercentage = dataObject.competitiveStats.careerStats[hero].game.winPercentage.ToString();
                string CompCards = dataObject.competitiveStats.careerStats[hero].matchAwards.cards.ToString();
                string CompMedals = dataObject.competitiveStats.careerStats[hero].matchAwards.medals.ToString();
                string CompMedalsBronze = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsBronze.ToString();
                string CompMedalsGold = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsGold.ToString();
                string CompMedalsSilver = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsSilver.ToString();
                string CompElimsPerLife = dataObject.competitiveStats.topHeroes[hero].eliminationsPerLife.ToString();

                //quickplay stats
                string QpAllDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.allDamageDoneAvgPer10Min.ToString();
                string QpBarrierDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.barrierDamageDoneAvgPer10Min.ToString();
                string QpCriticalsAvg = dataObject.quickPlayStats.careerStats[hero].average.criticalHitsAvgPer10Min.ToString();
                string QpDeathAvg = dataObject.quickPlayStats.careerStats[hero].average.deathsAvgPer10Min.ToString();
                string QpElimAvg = dataObject.quickPlayStats.careerStats[hero].average.eliminationsAvgPer10Min.ToString();
                string QpElimPerLife = dataObject.quickPlayStats.careerStats[hero].average.eliminationsPerLife.ToString();
                string QpFinalBlowAvg = dataObject.quickPlayStats.careerStats[hero].average.finalBlowsAvgPer10Min.ToString();
                string QpHeroDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.heroDamageDoneAvgPer10Min.ToString();
                string QpMeleeAvg = dataObject.quickPlayStats.careerStats[hero].average.meleeFinalBlowsAvgPer10Min.ToString();
                string QpObjKillsAvg = dataObject.quickPlayStats.careerStats[hero].average.objectiveKillsAvgPer10Min.ToString();
                string QpObjTimeAvg = dataObject.quickPlayStats.careerStats[hero].average.objectiveTimeAvgPer10Min.ToString();
                string QpSoloKillAvg = dataObject.quickPlayStats.careerStats[hero].average.soloKillsAvgPer10Min.ToString();
                string QpOnFireAvg = dataObject.quickPlayStats.careerStats[hero].average.timeSpentOnFireAvgPer10Min.ToString();
                //best
                string QpAllDamageInGame = dataObject.quickPlayStats.careerStats[hero].best.allDamageDoneMostInGame.ToString();
                string QpAllDamageInLife = dataObject.quickPlayStats.careerStats[hero].best.allDamageDoneMostInLife.ToString();
                string QpBarrierDamageInGame = dataObject.quickPlayStats.careerStats[hero].best.barrierDamageDoneMostInGame.ToString();
                string QpCritMostInGame = dataObject.quickPlayStats.careerStats[hero].best.criticalHitsMostInGame.ToString();
                string QpCritMostInLife = dataObject.quickPlayStats.careerStats[hero].best.criticalHitsMostInLife.ToString();
                string QpElimMostInLife = dataObject.quickPlayStats.careerStats[hero].best.eliminationsMostInLife.ToString();
                string QpElimMostInGame = dataObject.quickPlayStats.careerStats[hero].best.eliminationsMostInGame.ToString();
                string QpFinalBlowMostInGame = dataObject.quickPlayStats.careerStats[hero].best.finalBlowsMostInGame.ToString();
                string QpHeroDmgMostInGame = dataObject.quickPlayStats.careerStats[hero].best.heroDamageDoneMostInGame.ToString();
                string QpHeroDmgMostInLife = dataObject.quickPlayStats.careerStats[hero].best.heroDamageDoneMostInLife.ToString();
                string QpKillStreakBest = dataObject.quickPlayStats.careerStats[hero].best.killsStreakBest.ToString();
                string QpMeleeFinalBlowMostInGame = dataObject.quickPlayStats.careerStats[hero].best.meleeFinalBlowsMostInGame.ToString();
                string QpMultikillBest = dataObject.quickPlayStats.careerStats[hero].best.multikillsBest.ToString();
                string QpObjKillMostInGame = dataObject.quickPlayStats.careerStats[hero].best.objectiveKillsMostInGame.ToString();
                string QpObjTimeMostInGame = dataObject.quickPlayStats.careerStats[hero].best.objectiveTimeMostInGame.ToString();
                string QpSoloKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].best.soloKillsMostInGame.ToString();
                string QpOnFireMostInGame = dataObject.quickPlayStats.careerStats[hero].best.timeSpentOnFireMostInGame.ToString();
                string QpWeaponAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].best.weaponAccuracyBestInGame.ToString();
                //combat
                string QpBarrierDmgDone = dataObject.quickPlayStats.careerStats[hero].combat.barrierDamageDone.ToString();
                string QpCriticalHits = dataObject.quickPlayStats.careerStats[hero].combat.criticalHits.ToString();
                string QpCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.criticalHitsAccuracy.ToString();
                string QpDamageDone = dataObject.quickPlayStats.careerStats[hero].combat.damageDone.ToString();
                string QpDeaths = dataObject.quickPlayStats.careerStats[hero].combat.deaths.ToString();
                string QpElims = dataObject.quickPlayStats.careerStats[hero].combat.eliminations.ToString();

                string QpFinalBlows = dataObject.quickPlayStats.careerStats[hero].combat.finalBlows.ToString();
                string QpHeroDmg = dataObject.quickPlayStats.careerStats[hero].combat.heroDamageDone.ToString();
                string QpMeleeFinalBlows = dataObject.quickPlayStats.careerStats[hero].combat.meleeFinalBlows.ToString();
                string QpMultikills = dataObject.quickPlayStats.careerStats[hero].combat.multikills.ToString();
                string QpObjKills = dataObject.quickPlayStats.careerStats[hero].combat.objectiveKills.ToString();
                string QpObjTime = dataObject.quickPlayStats.careerStats[hero].combat.objectiveTime.ToString();
                string QpMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.quickMeleeAccuracy.ToString();
                string QpSoloKills = dataObject.quickPlayStats.careerStats[hero].combat.soloKills.ToString();
                string QpOnFire = dataObject.quickPlayStats.careerStats[hero].combat.timeSpentOnFire.ToString();
                string QpWeaponAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.weaponAccuracy.ToString();
                //misc stuff
                string QpGamesWon = dataObject.quickPlayStats.careerStats[hero].game.gamesWon.ToString();
                string QpTimePlayed = dataObject.quickPlayStats.careerStats[hero].game.timePlayed.ToString();
                string QpCards = dataObject.quickPlayStats.careerStats[hero].matchAwards.cards.ToString();
                string QpMedals = dataObject.quickPlayStats.careerStats[hero].matchAwards.medals.ToString();
                string QpMedalsBronze = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsBronze.ToString();
                string QpMedalsGold = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsGold.ToString();
                string QpMedalsSilver = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsSilver.ToString();
                string QpElimsPerLife = dataObject.quickPlayStats.topHeroes[hero].eliminationsPerLife.ToString();

                string compAvg = $"All Damage Done per 10 Minutes: **{CompAllDamageAvg}**\nBarrier Damage Done per 10 Minutes: **{CompBarrierDamageAvg}**\nHero Damage Done per 10 Minutes: **{CompHeroDamageAvg}**\nCritical Hits per 10 Minutes: **{CompCriticalsAvg}**\nDeaths per 10 Minutes: **{CompDeathAvg}**\nEliminations per 10 Minutes: **{CompElimAvg}**\nEliminations per Life: **{CompElimPerLife}**\nFinal Blows per 10 Minutes: **{CompFinalBlowAvg}**\nMelee Final Blows per 10 Minutes: **{CompMeleeAvg}**\nObjective Time per 10 Minutes: **{CompObjTimeAvg}**\nObjective Kills per 10 Minutes: **{CompObjKillsAvg}**\nSolo Kills per 10 Minutes: **{CompSoloKillAvg}**\nTime on Fire per 10 Minutes: **{CompOnFireAvg}**";
                string compBest = $"All Damage in Game: **{CompAllDamageInGame}**\nAll Damage in Life: **{CompAllDamageInLife}**\nBarrier Damage in Game: **{CompBarrierDamageInGame}**\nCriticals in Game: **{CompCritMostInGame}**\nCriticals in Life: **{CompCritMostInLife}**\nEliminations in Game: **{CompElimMostInGame}**\nEliminations in Life: **{CompElimMostInLife}**\nFinal Blows in Game: **{CompFinalBlowMostInGame}**\nHero Damage in Game: **{CompHeroDmgMostInGame}**\nHero Damage in Life: **{CompHeroDmgMostInLife}**\nKill Streak: **{CompKillStreakBest}**\nMelee Final Blows in Game: **{CompMeleeFinalBlowMostInGame}**\nMultikill: **{CompMultikillBest}**\nObjective Kills in Game: **{CompObjKillMostInGame}**\nObjective Time in Game: **{CompObjTimeMostInGame}**\nSolo Kills in Game: **{CompSoloKillsMostInGame}**\nOn Fire Time in Game: **{CompOnFireMostInGame}**\nWeapon Accuracy in Game: **{CompWeaponAccuracyBestInGame}**";
                string compTotal = $"Barrier Damage Done: **{CompBarrierDmgDone}**\nCritical Hits: **{CompCriticalHits}**\nObjective Time in Game: **{CompObjTimeMostInGame}**\nCritical Hit Accuracy: **{CompCriticalHitsAccuracy}**\nDamage Done: **{CompDamageDone}**\nDeaths: **{CompDeaths}**\nEliminations: **{CompElims}**\nFinal Blows: **{CompFinalBlows}**\nHero Damage: **{CompHeroDmg}**\nMelee Final Blows: **{CompMeleeFinalBlows}**\nMultikills: **{CompMultikills}**\nObjective Kills: **{CompObjKills}**\nObjective Time: **{CompObjTime}**\nMelee Accuracy: **{CompMeleeAccuracy}**\nSolo Kills: **{CompSoloKills}**\nOn Fire Time: **{CompOnFire}**\nWeapon Accuracy: **{CompWeaponAccuracy}**";
                string compMisc = $"Games Played: **{CompGamesPlayed}**\nGames Won: **{CompGamesWon}**\nGames Tied: **{CompGamesTied}**\nGames Lost: **{CompGamesLost}**\nTime Played: **{CompTimePlayed}**\nWin Percentage: **{CompWinPercentage}**\nCards: **{CompCards}**\nTotal Medals: **{CompMedals}**\nGold Medals: **{CompMedalsGold}**\nSilver Medals: **{CompMedalsSilver}**\nBronze Medals: **{CompMedalsBronze}**\nEliminations per Life: **{CompElimsPerLife}**\n";
                string qpAvg = $"All Damage Done per 10 Minutes: **{QpAllDamageAvg}**\nBarrier Damage Done per 10 Minutes: **{QpBarrierDamageAvg}**\nHero Damage Done per 10 Minutes: **{QpHeroDamageAvg}**\nCritical Hits per 10 Minutes: **{QpCriticalsAvg}**\nDeaths per 10 Minutes: **{QpDeathAvg}**\nEliminations per 10 Minutes: **{QpElimAvg}**\nEliminations per Life: **{QpElimPerLife}**\nFinal Blows per 10 Minutes: **{QpFinalBlowAvg}**\nMelee Final Blows per 10 Minutes: **{QpMeleeAvg}**\nObjective Time per 10 Minutes: **{QpObjTimeAvg}**\nObjective Kills per 10 Minutes: **{QpObjKillsAvg}**\nSolo Kills per 10 Minutes: **{QpSoloKillAvg}**\nTime on Fire per 10 Minutes: **{QpOnFireAvg}**";
                string qpBest = $"All Damage in Game: **{QpAllDamageInGame}**\nAll Damage in Life: **{QpAllDamageInLife}**\nBarrier Damage in Game: **{QpBarrierDamageInGame}**\nCriticals in Game: **{QpCritMostInGame}**\nCriticals in Life: **{QpCritMostInLife}**\nEliminations in Game: **{QpElimMostInGame}**\nEliminations in Life: **{QpElimMostInLife}**\nFinal Blows in Game: **{QpFinalBlowMostInGame}**\nHero Damage in Game: **{QpHeroDmgMostInGame}**\nHero Damage in Life: **{QpHeroDmgMostInLife}**\nKill Streak: **{QpKillStreakBest}**\nMelee Final Blows in Game: **{QpMeleeFinalBlowMostInGame}**\nMultikill: **{QpMultikillBest}**\nObjective Kills in Game: **{QpObjKillMostInGame}**\nObjective Time in Game: **{QpObjTimeMostInGame}**\nSolo Kills in Game: **{QpSoloKillsMostInGame}**\nOn Fire Time in Game: **{QpOnFireMostInGame}**\nWeapon Accuracy in Game: **{QpWeaponAccuracyBestInGame}**";
                string qpTotal = $"Barrier Damage Done: **{QpBarrierDmgDone}**\nCritical Hits: **{QpCriticalHits}**\nObjective Time in Game: **{QpObjTimeMostInGame}**\nCritical Hit Accuracy: **{QpCriticalHitsAccuracy}**\nDamage Done: **{QpDamageDone}**\nDeaths: **{QpDeaths}**\nEliminations: **{QpElims}**\nFinal Blows: **{QpFinalBlows}**\nHero Damage: **{QpHeroDmg}**\nMelee Final Blows: **{QpMeleeFinalBlows}**\nMultikills: **{QpMultikills}**\nObjective Kills: **{QpObjKills}**\nObjective Time: **{QpObjTime}**\nMelee Accuracy: **{QpMeleeAccuracy}**\nSolo Kills: **{QpSoloKills}**\nOn Fire Time: **{QpOnFire}**\nWeapon Accuracy: **{QpWeaponAccuracy}**";
                string qpMisc = $"Games Won: **{QpGamesWon}**\nTime Played: **{QpTimePlayed}**\nCards: **{QpCards}**\nTotal Medals: **{QpMedals}**\nGold Medals: **{QpMedalsGold}**\nSilver Medals: **{QpMedalsSilver}**\nBronze Medals: **{QpMedalsBronze}**\nEliminations per Life: **{QpElimsPerLife}**\n";
        
                if (hero == "ana")
                {
                    string QpBioticKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticGrenadeKills.ToString();
                    string QpEnemiesSlept = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSlept.ToString();
                    string QpEnemiesSleptPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSleptAvgPer10Min.ToString();
                    string QpEnemiesSleptMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSleptMostInGame.ToString();
                    string QpNanoAssists = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssists.ToString();
                    string QpNanoAssistsPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssistsAvgPer10Min.ToString();
                    string QpMostNanoAssistsIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssistsMostInGame.ToString();
                    string QpNanosApplied = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsApplied.ToString();
                    string QpNanosAppliedPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsAppliedAvgPer10Min.ToString();
                    string QpNanoAppliedMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsAppliedMostInGame.ToString();
                    string QpScopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpScopedAccuracyBestIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpSecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpSelfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpSelfHealingPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpSelfHealingMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpUnscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.unscopedAccuracy.ToString();
                    string QpUnscopedAccuracyBestIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.unscopedAccuracyBestInGame.ToString();

                    string CompBioticKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticGrenadeKills.ToString();
                    string CompEnemiesSlept = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSlept.ToString();
                    string CompEnemiesSleptPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSleptAvgPer10Min.ToString();
                    string CompEnemiesSleptMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSleptMostInGame.ToString();
                    string CompNanoAssists = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssists.ToString();
                    string CompNanoAssistsPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssistsAvgPer10Min.ToString();
                    string CompMostNanoAssistsIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssistsMostInGame.ToString();
                    string CompNanosApplied = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsApplied.ToString();
                    string CompNanosAppliedPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsAppliedAvgPer10Min.ToString();
                    string CompNanoAppliedMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsAppliedMostInGame.ToString();
                    string CompScopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompScopedAccuracyBestIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompSecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompSelfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompSelfHealingPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompSelfHealingMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompUnscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.unscopedAccuracy.ToString();
                    string CompUnscopedAccuracyBestIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.unscopedAccuracyBestInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Biotic Grenade Kills: **{QpBioticKills}**\nEnemies Slept: **{QpEnemiesSlept}**\nAverage Enemies Slept per 10 Minutes: **{QpEnemiesSleptPer10Min}**\nMost Enemies Slept In Game: **{QpEnemiesSleptPer10Min}**\nNano Boost Assists: **{QpNanoAssists}**\nNano Boost Assists Per 10 Minutes: **{QpNanosAppliedPer10Min}**\nMost Nano Boost Assists In Game: **{QpMostNanoAssistsIG}**\nNano Boosts Applied: **{QpNanosApplied}**\nNano Boosts Applied Per 10 Minutes: **{QpNanosAppliedPer10Min}**\nNano Boosts Applied Most In Game: **{QpNanoAppliedMostIG}**\nScoped Accuracy: **{QpScopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpScopedAccuracyBestIG}**\nSecondary Fire Accuracy: **{QpSecondaryFireAccuracy}**\nSelf Healing: **{QpSelfHealing}**\nSelf Healing Per 10 Minutes: **{QpSelfHealingPer10Min}**\nMost Self Healing In Game: **{QpSelfHealingMostIG}**\nUnscoped Accuracy: **{QpUnscopedAccuracy}**\nBest Unscoped Accuracy In Game: **{QpScopedAccuracyBestIG}**";
                    string compHeroSpecific = $"Biotic Grenade Kills: **{CompBioticKills}**\nEnemies Slept: **{CompEnemiesSlept}**\nAverage Enemies Slept per 10 Minutes: **{CompEnemiesSleptPer10Min}**\nMost Enemies Slept In Game: **{CompEnemiesSleptPer10Min}**\nNano Boost Assists: **{CompNanoAssists}**\nNano Boost Assists Per 10 Minutes: **{CompNanosAppliedPer10Min}**\nMost Nano Boost Assists In Game: **{CompMostNanoAssistsIG}**\nNano Boosts Applied: **{CompNanosApplied}**\nNano Boosts Applied Per 10 Minutes: **{CompNanosAppliedPer10Min}**\nNano Boosts Applied Most In Game: **{CompNanoAppliedMostIG}**\nScoped Accuracy: **{CompScopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompScopedAccuracyBestIG}**\nSecondary Fire Accuracy: **{CompSecondaryFireAccuracy}**\nSelf Healing: **{CompSelfHealing}**\nSelf Healing Per 10 Minutes: **{CompSelfHealingPer10Min}**\nMost Self Healing In Game: **{CompSelfHealingMostIG}**\nUnscoped Accuracy: **{CompUnscopedAccuracy}**\nBest Unscoped Accuracy In Game: **{CompScopedAccuracyBestIG}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "ashe")
                {
                    string CompbobKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKills.ToString();
                    string CompbobKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKillsAvgPer10Min.ToString();
                    string CompbobKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKillsMostInGame.ToString();
                    string CompcoachGunKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKills.ToString();
                    string CompcoachGunKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKillsAvgPer10Min.ToString();
                    string CompcoachGunKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKillsMostInGame.ToString();
                    string CompdynamiteKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKills.ToString();
                    string CompdynamiteKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKillsAvgPer10Min.ToString();
                    string CompdynamiteKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKillsMostInGame.ToString();
                    string CompscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompscopedAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompscopedCriticalHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string CompscopedCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string CompscopedCriticalHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string CompscopedCriticalHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string QpbobKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKills.ToString();
                    string QpbobKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKillsAvgPer10Min.ToString();
                    string QpbobKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKillsMostInGame.ToString();
                    string QpcoachGunKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKills.ToString();
                    string QpcoachGunKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKillsAvgPer10Min.ToString();
                    string QpcoachGunKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKillsMostInGame.ToString();
                    string QpdynamiteKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKills.ToString();
                    string QpdynamiteKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKillsAvgPer10Min.ToString();
                    string QpdynamiteKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKillsMostInGame.ToString();
                    string QpscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpscopedAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpscopedCriticalHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string QpscopedCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string QpscopedCriticalHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string QpscopedCriticalHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"BOB Kills: **{QpbobKills}**\nAverage BOB Kills Per 10 Minutes: **{QpbobKillsAvgPer10Min}**\nMost BOB Kills In Game: **{QpbobKillsMostInGame}**\nCoach Gun Kills: **{QpcoachGunKills}**\nAverage Coach Gun Kills Per 10 Minutes: **{QpcoachGunKillsAvgPer10Min}**\nMost Coach Gun Kills In Game: **{QpcoachGunKillsMostInGame}**\nDynamite Kills: **{QpdynamiteKills}**\nAverage Dynamite Kills Per 10 Minutes: **{QpdynamiteKillsAvgPer10Min}**\nMost Dynamite Kills In Game Kills: **{QpdynamiteKillsMostInGame}**\nScoped Accuracy: **{QpscopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpscopedAccuracyBestInGame}**\nScoped Creitical Hits: **{QpscopedCriticalHits}**\nScoped Critical Hits Accuracy: **{QpscopedCriticalHitsAccuracy}**\nAverage Scoped Critical Hits Per 10 Minutes: **{QpscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{QpscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"BOB Kills: **{CompbobKills}**\nAverage BOB Kills Per 10 Minutes: **{CompbobKillsAvgPer10Min}**\nMost BOB Kills In Game: **{CompbobKillsMostInGame}**\nCoach Gun Kills: **{CompcoachGunKills}**\nAverage Coach Gun Kills Per 10 Minutes: **{CompcoachGunKillsAvgPer10Min}**\nMost Coach Gun Kills In Game: **{CompcoachGunKillsMostInGame}**\nDynamite Kills: **{CompdynamiteKills}**\nAverage Dynamite Kills Per 10 Minutes: **{CompdynamiteKillsAvgPer10Min}**\nMost Dynamite Kills In Game Kills: **{CompdynamiteKillsMostInGame}**\nScoped Accuracy: **{CompscopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompscopedAccuracyBestInGame}**\nScoped Creitical Hits: **{CompscopedCriticalHits}**\nScoped Critical Hits Accuracy: **{CompscopedCriticalHitsAccuracy}**\nAverage Scoped Critical Hits Per 10 Minutes: **{CompscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{CompscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "bastion")
                {
                    string QpreconKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKills.ToString();
                    string QpreconKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKillsAvgPer10Min.ToString();
                    string QpreconKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].selfHealingAvgPer10Min.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpsentryKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKills.ToString();
                    string QpsentryKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKillsAvgPer10Min.ToString();
                    string QpsentryKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKillsMostInGame.ToString();
                    string QptankKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKills.ToString();
                    string QptankKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKillsAvgPer10Min.ToString();
                    string QptankKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKillsMostInGame.ToString();

                    string CompreconKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKills.ToString();
                    string CompreconKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKillsAvgPer10Min.ToString();
                    string CompreconKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].selfHealingAvgPer10Min.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompsentryKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKills.ToString();
                    string CompsentryKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKillsAvgPer10Min.ToString();
                    string CompsentryKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKillsMostInGame.ToString();
                    string ComptankKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKills.ToString();
                    string ComptankKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKillsAvgPer10Min.ToString();
                    string ComptankKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKillsMostInGame.ToString();


                    string qpHeroSpecific = $"Recon Kills: **{QpreconKills}**\nAverage Recon Kills Per 10 Minutes: **{QpreconKillsAvgPer10Min}**\nMost Recon Kills In Game: **{QpreconKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nSentry Kills: **{QpsentryKills}**\nAverage Sentry Kills Per 10 Minutes: **{QpsentryKillsAvgPer10Min}**\nMost Sentry Kills In Game: **{QpsentryKillsMostInGame}**\nTank Kills: **{QptankKills}**\nAverage Tank Kills Per 10 Minutes: **{QpreconKills}**\nMost Tank Kills In Game: **{QptankKillsMostInGame}**";
                    string compHeroSpecific = $"Recon Kills: **{CompreconKills}**\nAverage Recon Kills Per 10 Minutes: **{CompreconKillsAvgPer10Min}**\nMost Recon Kills In Game: **{CompreconKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nSentry Kills: **{CompsentryKills}**\nAverage Sentry Kills Per 10 Minutes: **{CompsentryKillsAvgPer10Min}**\nMost Sentry Kills In Game: **{CompsentryKillsMostInGame}**\nTank Kills: **{ComptankKills}**\nAverage Tank Kills Per 10 Minutes: **{CompreconKills}**\nMost Tank Kills In Game: **{ComptankKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "brigitte")
                {
                    string QparmorProvided = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvided.ToString();
                    string QparmorProvidedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvidedAvgPer10Min.ToString();
                    string QparmorProvidedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvidedMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpinspireUptimePercentage = dataObject.quickPlayStats.careerStats[hero].heroSpecific.inspireUptimePercentage.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();

                    string ComparmorProvided = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvided.ToString();
                    string ComparmorProvidedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvidedAvgPer10Min.ToString();
                    string ComparmorProvidedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvidedMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompinspireUptimePercentage = dataObject.competitiveStats.careerStats[hero].heroSpecific.inspireUptimePercentage.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Armor Provided: **{QparmorProvided}**\nAverage Armor Provided Per 10 Minutes: **{QparmorProvidedAvgPer10Min}**\nMost Armor Provided In Game: **{QparmorProvidedMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nInspire Uptime Percentage: **{QpinspireUptimePercentage}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\n";
                    string compHeroSpecific = $"Armor Provided: **{ComparmorProvided}**\nAverage Armor Provided Per 10 Minutes: **{ComparmorProvidedAvgPer10Min}**\nMost Armor Provided In Game: **{ComparmorProvidedMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nInspire Uptime Percentage: **{CompinspireUptimePercentage}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "dVa")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpmechDeaths = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechDeaths.ToString();
                    string QpmechsCalled = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalled.ToString();
                    string QpmechsCalledAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalledAvgPer10Min.ToString();
                    string QpmechsCalledMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalledMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfDestructKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKills.ToString();
                    string QpselfDestructKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKillsAvgPer10Min.ToString();
                    string QpselfDestructKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKillsMostInGame.ToString();

                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompmechDeaths = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechDeaths.ToString();
                    string CompmechsCalled = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalled.ToString();
                    string CompmechsCalledAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalledAvgPer10Min.ToString();
                    string CompmechsCalledMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalledMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfDestructKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKills.ToString();
                    string CompselfDestructKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKillsAvgPer10Min.ToString();
                    string CompselfDestructKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKillsMostInGame.ToString();

                    string qpHeroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nMech Deaths: **{QpmechDeaths}**\nMechs Called: **{QpmechsCalled}**\nAverage Mechs Called Per 10 Minutes: **{QpmechsCalledAvgPer10Min}**\nMost Mechs Called In Game: **{QpmechsCalledMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Destruct Kills: **{QpselfDestructKills}**\nAverage Self Destruct Kills Per 10 Minutes: **{QpselfDestructKillsAvgPer10Min}**\nMost Self Destruct Kills In Game: **{QpselfDestructKillsMostInGame}**";
                    string compHeroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nMech Deaths: **{CompmechDeaths}**\nMechs Called: **{CompmechsCalled}**\nAverage Mechs Called Per 10 Minutes: **{CompmechsCalledAvgPer10Min}**\nMost Mechs Called In Game: **{CompmechsCalledMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Destruct Kills: **{CompselfDestructKills}**\nAverage Self Destruct Kills Per 10 Minutes: **{CompselfDestructKillsAvgPer10Min}**\nMost Self Destruct Kills In Game: **{CompselfDestructKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "doomfist")
                {
                    string QpabilityDamageDone = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.barrierDamageDone.ToString();
                    string QpabilityDamageDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.abilityDamageDoneAvgPer10Min.ToString();
                    string QpabilityDamageDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.abilityDamageDoneMostInGame.ToString();
                    string QpmeteorStrikeKills = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKills.ToString();
                    string QpmeteorStrikeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsAvgPer10Min.ToString();
                    string QpmeteorStrikeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.secondaryFireAccuracy.ToString();
                    string QpshieldsCreated = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreated.ToString();
                    string QpshieldsCreatedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreatedAvgPer10Min.ToString();
                    string QpshieldsCreatedMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreatedMostInGame.ToString();

                    string CompabilityDamageDone = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.barrierDamageDone.ToString();
                    string CompabilityDamageDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.abilityDamageDoneAvgPer10Min.ToString();
                    string CompabilityDamageDoneMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.abilityDamageDoneMostInGame.ToString();
                    string CompmeteorStrikeKills = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKills.ToString();
                    string CompmeteorStrikeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsAvgPer10Min.ToString();
                    string CompmeteorStrikeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.secondaryFireAccuracy.ToString();
                    string CompshieldsCreated = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreated.ToString();
                    string CompshieldsCreatedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreatedAvgPer10Min.ToString();
                    string CompshieldsCreatedMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreatedMostInGame.ToString();

                    string qpHeroSpecific = $"Ability Damage Done: **{QpabilityDamageDone}**\nAverage Ability Damage Done Per 10 Minutes: **{QpabilityDamageDoneAvgPer10Min}**\nMost Ability Damage Done In Game: **{QpabilityDamageDoneMostInGame}**\nMeteor Strike Kills: **{QpmeteorStrikeKills}**\nAverage Meteor Strike Kills Per 10 Minutes: **{QpmeteorStrikeKillsAvgPer10Min}**\nMost Meteor Strike Kills In Game: **{QpmeteorStrikeKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nShields Created: **{QpshieldsCreated}**\nAverage Shields Created Per 10 Minutes: **{QpshieldsCreatedAvgPer10Min}**\nMost Shields Created In Game: **{QpshieldsCreatedMostInGame}**";
                    string compHeroSpecific = $"Ability Damage Done: **{CompabilityDamageDone}**\nAverage Ability Damage Done Per 10 Minutes: **{CompabilityDamageDoneAvgPer10Min}**\nMost Ability Damage Done In Game: **{CompabilityDamageDoneMostInGame}**\nMeteor Strike Kills: **{CompmeteorStrikeKills}**\nAverage Meteor Strike Kills Per 10 Minutes: **{CompmeteorStrikeKillsAvgPer10Min}**\nMost Meteor Strike Kills In Game: **{CompmeteorStrikeKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nShields Created: **{CompshieldsCreated}**\nAverage Shields Created Per 10 Minutes: **{CompshieldsCreatedAvgPer10Min}**\nMost Shields Created In Game: **{CompshieldsCreatedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "genji")
                {
                    string QpdamageReflected = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflected.ToString();
                    string QpdamageReflectedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflectedAvgPer10Min.ToString();
                    string QpdamageReflectedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflectedMostInGame.ToString();
                    string QpdeflectionKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deflectionKills.ToString();
                    string QpdragonbladesKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKills.ToString();
                    string QpdragonbladesKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKillsAvgPer10Min.ToString();
                    string QpdragonbladesKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompdamageReflected = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflected.ToString();
                    string CompdamageReflectedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflectedAvgPer10Min.ToString();
                    string CompdamageReflectedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflectedMostInGame.ToString();
                    string CompdeflectionKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deflectionKills.ToString();
                    string CompdragonbladesKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKills.ToString();
                    string CompdragonbladesKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKillsAvgPer10Min.ToString();
                    string CompdragonbladesKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"Damage Deflected: **{QpdamageReflected}**\nAverage Damage Deflected Per 10 Minutes: **{QpdamageReflectedMostInGame}**\nMost Damage Deflected In Game: **{QpdamageReflectedMostInGame}**\nDeflection Kills: **{QpdeflectionKills}**\nDragonblade Kills: **{QpdragonbladesKills}**\nAverage Dragonblade Kills Per 10 Minutes: **{QpdragonbladesKillsAvgPer10Min}**\nMost Dragonblade Kills In Game: **{QpdragonbladesKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific =  $"Damage Deflected: **{CompdamageReflected}**\nAverage Damage Deflected Per 10 Minutes: **{CompdamageReflectedMostInGame}**\nMost Damage Deflected In Game: **{CompdamageReflectedMostInGame}**\nDeflection Kills: **{CompdeflectionKills}**\nDragonblade Kills: **{CompdragonbladesKills}**\nAverage Dragonblade Kills Per 10 Minutes: **{CompdragonbladesKillsAvgPer10Min}**\nMost Dragonblade Kills In Game: **{CompdragonbladesKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "hanzo")
                {
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompstormArrowKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKills.ToString();
                    string CompstormArrowKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKillsAvgPer10Min.ToString();
                    string CompstormArrowKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKillsMostInGame.ToString();

                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpstormArrowKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKills.ToString();
                    string QpstormArrowKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKillsAvgPer10Min.ToString();
                    string QpstormArrowKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKillsMostInGame.ToString();

                    string qpHeroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nStorm Arrow Kills: **{QpstormArrowKills}**\nAverage Storm Arrow Kills Per 10 Minutes: **{QpstormArrowKillsAvgPer10Min}**\nMost Storm Arrow Kills In Game: **{QpstormArrowKillsMostInGame}**";
                    string compHeroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nStorm Arrow Kills: **{CompstormArrowKills}**\nAverage Storm Arrow Kills Per 10 Minutes: **{CompstormArrowKillsAvgPer10Min}**\nMost Storm Arrow Kills In Game: **{CompstormArrowKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "junkrat")
                {
                    string CompconcussionMineKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKills.ToString();
                    string CompconcussionMineKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKillsAvgPer10Min.ToString();
                    string CompconcussionMineKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKillsMostInGame.ToString();
                    string CompenemiesTrapped = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrapped.ToString();
                    string CompenemiesTrappedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrappedAvgPer10Min.ToString();
                    string CompenemiesTrappedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrappedMostInGame.ToString();
                    string CompripTireKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKills.ToString();
                    string CompripTireKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKillsAvgPer10Min.ToString();
                    string CompripTireKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string QpconcussionMineKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKills.ToString();
                    string QpconcussionMineKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKillsAvgPer10Min.ToString();
                    string QpconcussionMineKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKillsMostInGame.ToString();
                    string QpenemiesTrapped = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrapped.ToString();
                    string QpenemiesTrappedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrappedAvgPer10Min.ToString();
                    string QpenemiesTrappedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrappedMostInGame.ToString();
                    string QpripTireKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKills.ToString();
                    string QpripTireKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKillsAvgPer10Min.ToString();
                    string QpripTireKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Concussion Mine Kills: **{QpconcussionMineKills}**\nAverage Concussion Mine Kills Per 10 Minutes: **{QpconcussionMineKillsAvgPer10Min}**\nMost Concussion Mine Kills in Game: **{QpconcussionMineKillsMostInGame}**\nEnemies Trapped: **{QpenemiesTrapped}**\nAverage Enemies Trapped Per 10 Minutes: **{QpenemiesTrappedAvgPer10Min}**\nMost Enemies Trapped In Game: **{QpenemiesTrappedMostInGame}**\nRip Tire Kills: **{QpripTireKills}**\nAverage Rip Tire Kills Per 10 Minutes: **{QpripTireKillsAvgPer10Min}**\nMost Rip Tire Kills In Game: **{QpripTireKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Concussion Mine Kills: **{CompconcussionMineKills}**\nAverage Concussion Mine Kills Per 10 Minutes: **{CompconcussionMineKillsAvgPer10Min}**\nMost Concussion Mine Kills in Game: **{CompconcussionMineKillsMostInGame}**\nEnemies Trapped: **{CompenemiesTrapped}**\nAverage Enemies Trapped Per 10 Minutes: **{CompenemiesTrappedAvgPer10Min}**\nMost Enemies Trapped In Game: **{CompenemiesTrappedMostInGame}**\nRip Tire Kills: **{CompripTireKills}**\nAverage Rip Tire Kills Per 10 Minutes: **{CompripTireKillsAvgPer10Min}**\nMost Rip Tire Kills In Game: **{CompripTireKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "lucio")
                {
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompsoundBarriersProvided = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvided.ToString();
                    string CompsoundBarriersProvidedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvidedAvgPer10Min.ToString();
                    string CompsoundBarriersProvidedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvidedMostInGame.ToString();

                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpsoundBarriersProvided = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvided.ToString();
                    string QpsoundBarriersProvidedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvidedAvgPer10Min.ToString();
                    string QpsoundBarriersProvidedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvidedMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\n:Most Self Healing In Game **{QpselfHealingMostInGame}**\nSound Barriers Provided: **{QpsoundBarriersProvided}**\nAverage Sound Barriers Provided Per 10 minutes: **{QpsoundBarriersProvidedAvgPer10Min}**\nMost Sound barriers Provided In Game: **{QpsoundBarriersProvidedMostInGame}**";
                    string compHeroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\n:Most Self Healing In Game **{CompselfHealingMostInGame}**\nSound Barriers Provided: **{CompsoundBarriersProvided}**\nAverage Sound Barriers Provided Per 10 minutes: **{CompsoundBarriersProvidedAvgPer10Min}**\nMost Sound barriers Provided In Game: **{CompsoundBarriersProvidedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mccree")
                {
                    string QpdeadeyeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKills.ToString();
                    string QpdeadeyeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKillsAvgPer10Min.ToString();
                    string QpdeadeyeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKillsMostInGame.ToString();
                    string QpfanTheHammerKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKills.ToString();
                    string QpfanTheHammerKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKillsAvgPer10Min.ToString();
                    string QpfanTheHammerKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompdeadeyeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKills.ToString();
                    string CompdeadeyeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKillsAvgPer10Min.ToString();
                    string CompdeadeyeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKillsMostInGame.ToString();
                    string CompfanTheHammerKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKills.ToString();
                    string CompfanTheHammerKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKillsAvgPer10Min.ToString();
                    string CompfanTheHammerKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"Deadeye Kills: **{QpdeadeyeKills}**\nAverage Deadeye Kills Per 10 Minutes: **{QpdeadeyeKillsAvgPer10Min}**\nMost Deadeye Kills In Game: **{QpdeadeyeKillsMostInGame}**\nFan The Hammer Kills: **{QpfanTheHammerKills}**\nAverage Fan The Hammer Kills Per 10 Minutes: **{QpfanTheHammerKillsAvgPer10Min}**\nMost Fan The Hammer Kills In Game: **{QpfanTheHammerKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Deadeye Kills: **{CompdeadeyeKills}**\nAverage Deadeye Kills Per 10 Minutes: **{CompdeadeyeKillsAvgPer10Min}**\nMost Deadeye Kills In Game: **{CompdeadeyeKillsMostInGame}**\nFan The Hammer Kills: **{CompfanTheHammerKills}**\nAverage Fan The Hammer Kills Per 10 Minutes: **{CompfanTheHammerKillsAvgPer10Min}**\nMost Fan The Hammer Kills In Game: **{CompfanTheHammerKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mei")
                {
                    string QpblizzardKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKills.ToString();
                    string QpblizzardKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKillsAvgPer10Min.ToString();
                    string QpblizzardKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKillsMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpenemiesFrozen = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozen.ToString();
                    string QpenemiesFrozenAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozenAvgPer10Min.ToString();
                    string QpenemiesFrozenMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozenMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompblizzardKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKills.ToString();
                    string CompblizzardKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKillsAvgPer10Min.ToString();
                    string CompblizzardKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKillsMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompenemiesFrozen = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozen.ToString();
                    string CompenemiesFrozenAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozenAvgPer10Min.ToString();
                    string CompenemiesFrozenMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozenMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Blizzard Kills: **{QpblizzardKills}**\nAverage Blizzard Kills Per 10 Minutes: **{QpblizzardKillsAvgPer10Min}**\nMost Blizzard Kills In Game: **{QpblizzardKillsMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nEnemies Frozen: **{QpenemiesFrozen}**\nAverage Enemies Frozen: **{QpenemiesFrozenAvgPer10Min}**\nMost Enemies Frozen In Game: **{QpenemiesFrozenMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    string compHeroSpecific = $"Blizzard Kills: **{CompblizzardKills}**\nAverage Blizzard Kills Per 10 Minutes: **{CompblizzardKillsAvgPer10Min}**\nMost Blizzard Kills In Game: **{CompblizzardKillsMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nEnemies Frozen: **{CompenemiesFrozen}**\nAverage Enemies Frozen: **{CompenemiesFrozenAvgPer10Min}**\nMost Enemies Frozen In Game: **{CompenemiesFrozenMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mercy")
                {
                    string QpblasterKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKills.ToString();
                    string QpblasterKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKillsAvgPer10Min.ToString();
                    string QpblasterKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKillsMostInGame.ToString();
                    string QpdamageAmplified = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string QpdamageAmplifiedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string QpdamageAmplifiedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string QpplayersResurrected = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrected.ToString();
                    string QpplayersResurrectedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrectedAvgPer10Min.ToString();
                    string QpplayersResurrectedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrectedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompblasterKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKills.ToString();
                    string CompblasterKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKillsAvgPer10Min.ToString();
                    string CompblasterKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKillsMostInGame.ToString();
                    string CompdamageAmplified = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string CompdamageAmplifiedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string CompdamageAmplifiedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string CompplayersResurrected = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrected.ToString();
                    string CompplayersResurrectedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrectedAvgPer10Min.ToString();
                    string CompplayersResurrectedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrectedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Blaster Kills: **{QpblasterKills}**\nAverage Blaster Kills Per 10 Minutes: **{QpblasterKillsAvgPer10Min}**\nMost Blaster Kills In Game: **{QpblasterKillsMostInGame}**\nDamage Amplified: **{QpdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{QpdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{QpdamageAmplifiedMostInGame}**\nPlayers Resurrected: **{QpplayersResurrected}**\nAverage Players Resurrected Per 10 Minutes: **{QpplayersResurrectedAvgPer10Min}**\nMost Players Ressurected In Game: **{QpplayersResurrectedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    string compHeroSpecific = $"Blaster Kills: **{CompblasterKills}**\nAverage Blaster Kills Per 10 Minutes: **{CompblasterKillsAvgPer10Min}**\nMost Blaster Kills In Game: **{CompblasterKillsMostInGame}**\nDamage Amplified: **{CompdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{CompdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{CompdamageAmplifiedMostInGame}**\nPlayers Resurrected: **{CompplayersResurrected}**\nAverage Players Resurrected Per 10 Minutes: **{CompplayersResurrectedAvgPer10Min}**\nMost Players Ressurected In Game: **{CompplayersResurrectedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "moira")
                {
                    string QpcoalescenceHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealing.ToString();
                    string QpcoalescenceHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealingAvgPer10Min.ToString();
                    string QpcoalescenceHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealingMostInGame.ToString();
                    string QpcoalescenceKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKills.ToString();
                    string QpcoalescenceKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKillsAvgPer10Min.ToString();
                    string QpcoalescenceKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompcoalescenceHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealing.ToString();
                    string CompcoalescenceHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealingAvgPer10Min.ToString();
                    string CompcoalescenceHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealingMostInGame.ToString();
                    string CompcoalescenceKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKills.ToString();
                    string CompcoalescenceKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKillsAvgPer10Min.ToString();
                    string CompcoalescenceKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Coalescence Healing: **{QpcoalescenceHealing}**\nAverage Coalescence Healing Per 10 Minutes: **{QpcoalescenceHealingAvgPer10Min}**\nMost Coalescence Healing In Game: **{QpcoalescenceHealingMostInGame}**\nCoalescence Kills: **{QpcoalescenceKills}**\nAverage Coalescence Kills Per 10 Minutes: **{QpcoalescenceKillsAvgPer10Min}**\nMost Coalescence Kills In Game: **{QpcoalescenceKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    string compHeroSpecific = $"Coalescence Healing: **{CompcoalescenceHealing}**\nAverage Coalescence Healing Per 10 Minutes: **{CompcoalescenceHealingAvgPer10Min}**\nMost Coalescence Healing In Game: **{CompcoalescenceHealingMostInGame}**\nCoalescence Kills: **{CompcoalescenceKills}**\nAverage Coalescence Kills Per 10 Minutes: **{CompcoalescenceKillsAvgPer10Min}**\nMost Coalescence Kills In Game: **{CompcoalescenceKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "orisa")
                {
                    string QpdamageAmplified = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string QpdamageAmplifiedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string QpdamageAmplifiedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpsuperchargerAssists = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssists.ToString();
                    string QpsuperchargerAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssistsAvgPer10Min.ToString();
                    string QpsuperchargerAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssistsMostInGame.ToString();

                    string CompdamageAmplified = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string CompdamageAmplifiedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string CompdamageAmplifiedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompsuperchargerAssists = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssists.ToString();
                    string CompsuperchargerAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssistsAvgPer10Min.ToString();
                    string CompsuperchargerAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssistsMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Damage Amplified: **{QpdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{QpdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{QpdamageAmplifiedMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSupercharger Assists: **{QpsuperchargerAssists}**\nAverage Supercharger Assists Per 10 Minutes: **{QpsuperchargerAssistsAvgPer10Min}**\nMost Supercharger Assists In Game: **{QpsuperchargerAssistsMostInGame}**";
                    string compHeroSpecific = $"Damage Amplified: **{CompdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{CompdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{CompdamageAmplifiedMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSupercharger Assists: **{CompsuperchargerAssists}**\nAverage Supercharger Assists Per 10 Minutes: **{CompsuperchargerAssistsAvgPer10Min}**\nMost Supercharger Assists In Game: **{CompsuperchargerAssistsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "pharah")
                {
                    string QpbarrageKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKills.ToString();
                    string QpbarrageKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKillsAvgPer10Min.ToString();
                    string QpbarrageKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKillsMostInGame.ToString();
                    string QpdirectHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.directHitsAccuracy.ToString();
                    string QprocketDirectHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHits.ToString();
                    string QprocketDirectHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHitsAvgPer10Min.ToString();
                    string QprocketDirectHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompbarrageKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKills.ToString();
                    string CompbarrageKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKillsAvgPer10Min.ToString();
                    string CompbarrageKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKillsMostInGame.ToString();
                    string CompdirectHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.directHitsAccuracy.ToString();
                    string ComprocketDirectHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHits.ToString();
                    string ComprocketDirectHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHitsAvgPer10Min.ToString();
                    string ComprocketDirectHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"Barrage Kills: **{QpbarrageKills}**\nAverage Barrage Kills Per 10 Minutes: **{QpbarrageKillsAvgPer10Min}**\nMost Barrage Kills In Game: **{QpbarrageKillsMostInGame}**\nDirect Hits Accuracy: **{QpdirectHitsAccuracy}**\nRocket Dirrect Hits: **{QprocketDirectHits}**\nAverage Rocket Direct Hits Per 10 Minutes: **{QprocketDirectHitsAvgPer10Min}**\nMost Rocket Direct Hits In Game: **{QprocketDirectHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Barrage Kills: **{CompbarrageKills}**\nAverage Barrage Kills Per 10 Minutes: **{CompbarrageKillsAvgPer10Min}**\nMost Barrage Kills In Game: **{CompbarrageKillsMostInGame}**\nDirect Hits Accuracy: **{CompdirectHitsAccuracy}**\nRocket Dirrect Hits: **{ComprocketDirectHits}**\nAverage Rocket Direct Hits Per 10 Minutes: **{ComprocketDirectHitsAvgPer10Min}**\nMost Rocket Direct Hits In Game: **{ComprocketDirectHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reaper")
                {
                    string QpdeathsBlossomKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKills.ToString();
                    string QpdeathsBlossomKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKillsAvgPer10Min.ToString();
                    string QpdeathsBlossomKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompdeathsBlossomKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKills.ToString();
                    string CompdeathsBlossomKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKillsAvgPer10Min.ToString();
                    string CompdeathsBlossomKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string qpHeroSpecific = $"Death Blossom Kills: **{QpdeathsBlossomKills}**\nAverage Death Blossom Kills Per 10 Minutes: **{QpdeathsBlossomKillsAvgPer10Min}**\nMost Death Blossom Kills In Game: **{QpdeathsBlossomKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    string compHeroSpecific = $"Death Blossom Kills: **{CompdeathsBlossomKills}**\nAverage Death Blossom Kills Per 10 Minutes: **{CompdeathsBlossomKillsAvgPer10Min}**\nMost Death Blossom Kills In Game: **{CompdeathsBlossomKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reinhardt")
                {
                    string QpchargeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKills.ToString();
                    string QpchargeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKillsAvgPer10Min.ToString();
                    string QpchargeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKillsMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpearthshatterKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKills.ToString();
                    string QpearthshatterKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKillsAvgPer10Min.ToString();
                    string QpearthshatterKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKillsMostInGame.ToString();
                    string QpfireStrikeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKills.ToString();
                    string QpfireStrikeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKillsAvgPer10Min.ToString();
                    string QpfireStrikeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKillsMostInGame.ToString();
                    string QprocketHammerMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketHammerMeleeAccuracy.ToString();

                    string CompchargeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKills.ToString();
                    string CompchargeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKillsAvgPer10Min.ToString();
                    string CompchargeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKillsMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompearthshatterKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKills.ToString();
                    string CompearthshatterKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKillsAvgPer10Min.ToString();
                    string CompearthshatterKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKillsMostInGame.ToString();
                    string CompfireStrikeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKills.ToString();
                    string CompfireStrikeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKillsAvgPer10Min.ToString();
                    string CompfireStrikeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKillsMostInGame.ToString();
                    string ComprocketHammerMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketHammerMeleeAccuracy.ToString();

                    string qpHeroSpecific = $"Charge Kills: **{QpchargeKills}**\nAverage Charge Kills Per 10 Minutes: **{QpchargeKillsAvgPer10Min}**\nMost Charge Kills In Game: **{QpchargeKillsMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nEarthshatter Kills: **{QpearthshatterKills}**\nAverage Earthshatter Kills Per 10 Minutes: **{QpearthshatterKillsAvgPer10Min}**\nMost Earthshatter Kills In Game: **{QpearthshatterKillsMostInGame}**\nFire Strike Kills: **{QpfireStrikeKills}**\nFire Strike Kills: **{QpfireStrikeKills}**\nAverage Fire Strike Kills Per 10 Minutes: **{QpfireStrikeKillsAvgPer10Min}**\nMost Fire Strike Kills In Game: **{QpfireStrikeKillsMostInGame}**\nRocket Hammer Melee Accuracy: **{QprocketHammerMeleeAccuracy}**\n";
                    string compHeroSpecific = $"Charge Kills: **{CompchargeKills}**\nAverage Charge Kills Per 10 Minutes: **{CompchargeKillsAvgPer10Min}**\nMost Charge Kills In Game: **{CompchargeKillsMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nEarthshatter Kills: **{CompearthshatterKills}**\nAverage Earthshatter Kills Per 10 Minutes: **{CompearthshatterKillsAvgPer10Min}**\nMost Earthshatter Kills In Game: **{CompearthshatterKillsMostInGame}**\nFire Strike Kills: **{CompfireStrikeKills}**\nFire Strike Kills: **{CompfireStrikeKills}**\nAverage Fire Strike Kills Per 10 Minutes: **{CompfireStrikeKillsAvgPer10Min}**\nMost Fire Strike Kills In Game: **{CompfireStrikeKillsMostInGame}**\nRocket Hammer Melee Accuracy: **{ComprocketHammerMeleeAccuracy}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "roadhog")
                {
                    string QpenemiesHooked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHooked.ToString();
                    string QpenemiesHookedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHookedAvgPer10Min.ToString();
                    string QpenemiesHookedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHookedMostInGame.ToString();
                    string QphookAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hookAccuracy.ToString();
                    string QphookAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hookAccuracyBestInGame.ToString();
                    string QphooksAttempted = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hooksAttempted.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpwholeHogKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKills.ToString();
                    string QpwholeHogKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKillsAvgPer10Min.ToString();
                    string QpwholeHogKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKillsMostInGame.ToString();

                    string CompenemiesHooked = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHooked.ToString();
                    string CompenemiesHookedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHookedAvgPer10Min.ToString();
                    string CompenemiesHookedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHookedMostInGame.ToString();
                    string ComphookAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.hookAccuracy.ToString();
                    string ComphookAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.hookAccuracyBestInGame.ToString();
                    string ComphooksAttempted = dataObject.competitiveStats.careerStats[hero].heroSpecific.hooksAttempted.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompwholeHogKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKills.ToString();
                    string CompwholeHogKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKillsAvgPer10Min.ToString();
                    string CompwholeHogKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKillsMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Enemies Hooked: **{QpenemiesHooked}**\nAverage Enemies Hooked Per 10 Minutes: **{QpenemiesHookedAvgPer10Min}**\nMost Enemies Hooked In Game: **{QpenemiesHookedMostInGame}**\nHook Accuracy: **{QphookAccuracy}**\nBest Hook Accuracy In Game: **{QphookAccuracyBestInGame}**\nHooks Attempted: **{QphooksAttempted}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nWhole Hog Kills: **{QpwholeHogKills}**\nAverage Whole Hog Kills Per 10 Minutes: **{QpwholeHogKillsAvgPer10Min}**\nMost Whole Hog Kills In Game: **{QpwholeHogKillsMostInGame}**\n";
                    string compHeroSpecific = $"Enemies Hooked: **{CompenemiesHooked}**\nAverage Enemies Hooked Per 10 Minutes: **{CompenemiesHookedAvgPer10Min}**\nMost Enemies Hooked In Game: **{CompenemiesHookedMostInGame}**\nHook Accuracy: **{ComphookAccuracy}**\nBest Hook Accuracy In Game: **{ComphookAccuracyBestInGame}**\nHooks Attempted: **{ComphooksAttempted}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nWhole Hog Kills: **{CompwholeHogKills}**\nAverage Whole Hog Kills Per 10 Minutes: **{CompwholeHogKillsAvgPer10Min}**\nMost Whole Hog Kills In Game: **{CompwholeHogKillsMostInGame}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "soldier76")
                {
                    string QpbioticFieldHealingDone = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticFieldHealingDone.ToString();
                    string QpbioticFieldsDeployed = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticFieldsDeployed.ToString();
                    string QphelixRocketKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketKillsMostInGame.ToString();
                    string QphelixRocketsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketsKills.ToString();
                    string QphelixRocketsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketsKillsAvgPer10Min.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompbioticFieldHealingDone = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticFieldHealingDone.ToString();
                    string CompbioticFieldsDeployed = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticFieldsDeployed.ToString();
                    string ComphelixRocketKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketKillsMostInGame.ToString();
                    string ComphelixRocketsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketsKills.ToString();
                    string ComphelixRocketsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketsKillsAvgPer10Min.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QpselfHealing}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{CompselfHealing}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**";
                    string qpHeroSpecific = $"Biotic Field Healing Done: **{QpbioticFieldHealingDone}**\nBiotic Fields Deployed: **{QpbioticFieldsDeployed}**\nHelix Rocket Kills: **{QphelixRocketsKills}**\nAverage Helix Rocket Kills Per 10 Minutes: **{QphelixRocketsKillsAvgPer10Min}**\nMost Helix Rocket Kills In Game: **{QphelixRocketKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    string compHeroSpecific = $"Biotic Field Healing Done: **{CompbioticFieldHealingDone}**\nBiotic Fields Deployed: **{CompbioticFieldsDeployed}**\nHelix Rocket Kills: **{ComphelixRocketsKills}**\nAverage Helix Rocket Kills Per 10 Minutes: **{ComphelixRocketsKillsAvgPer10Min}**\nMost Helix Rocket Kills In Game: **{ComphelixRocketKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "sombra")
                {
                    string QpenemiesEmpd = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpd.ToString();
                    string QpenemiesEmpdAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpdAvgPer10Min.ToString();
                    string QpenemiesEmpdMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpdMostInGame.ToString();
                    string QpenemiesHacked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHacked.ToString();
                    string QpenemiesHackedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHackedAvgPer10Min.ToString();
                    string QpenemiesHackedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHackedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompenemiesEmpd = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpd.ToString();
                    string CompenemiesEmpdAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpdAvgPer10Min.ToString();
                    string CompenemiesEmpdMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpdMostInGame.ToString();
                    string CompenemiesHacked = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHacked.ToString();
                    string CompenemiesHackedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHackedAvgPer10Min.ToString();
                    string CompenemiesHackedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHackedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Enemies EMP'd: **{QpenemiesEmpd}**\nAverage EMP'd Per 10 Minutes: **{QpenemiesEmpdAvgPer10Min}**\nMost Enemies EMP'd In Game: **{QpenemiesEmpdMostInGame}**\nEnemies Hacked: **{QpenemiesHacked}**\nAverage Enemies Hacked Per 10 Minutes: **{QpenemiesHackedAvgPer10Min}**\nMost Enemies Hacked In Game: **{QpenemiesHackedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Enemies EMP'd: **{CompenemiesEmpd}**\nAverage EMP'd Per 10 Minutes: **{CompenemiesEmpdAvgPer10Min}**\nMost Enemies EMP'd In Game: **{CompenemiesEmpdMostInGame}**\nEnemies Hacked: **{CompenemiesHacked}**\nAverage Enemies Hacked Per 10 Minutes: **{CompenemiesHackedAvgPer10Min}**\nMost Enemies Hacked In Game: **{CompenemiesHackedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "symmetra")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpplayersTeleported = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleported.ToString();
                    string QpplayersTeleportedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleportedAvgPer10Min.ToString();
                    string QpplayersTeleportedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleportedMostInGame.ToString();
                    string QpprimaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string QpsecondaryDirectHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryDirectHitsAvgPer10Min.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpsentryTurretsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKills.ToString();
                    string QpsentryTurretsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKillsAvgPer10Min.ToString();
                    string QpsentryTurretsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKillsMostInGame.ToString();

                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompplayersTeleported = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleported.ToString();
                    string CompplayersTeleportedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleportedAvgPer10Min.ToString();
                    string CompplayersTeleportedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleportedMostInGame.ToString();
                    string CompprimaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string CompsecondaryDirectHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryDirectHitsAvgPer10Min.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompsentryTurretsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKills.ToString();
                    string CompsentryTurretsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKillsAvgPer10Min.ToString();
                    string CompsentryTurretsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKillsMostInGame.ToString();

                    string qpHeroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nPlayers Teleported: **{QpplayersTeleported}**\nAverage Players Teleported Per 10 Minutes: **{QpplayersTeleportedAvgPer10Min}**\nMost Players Teleported In Game: **{QpplayersTeleportedMostInGame}**\nPrimary Fire Accuracy: **{QpprimaryFireAccuracy}**\nSecondary Fire Direct Hits Per 10 Minutes: **{QpsecondaryDirectHitsAvgPer10Min}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSentry Turret Kills: **{QpsentryTurretsKills}**\nAverage Sentry Turret Kills Per 10 Minutes: **{QpsentryTurretsKillsAvgPer10Min}**\nMost Sentry Turret Kills In Game: **{QpsentryTurretsKillsMostInGame}**";
                    string compHeroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nPlayers Teleported: **{CompplayersTeleported}**\nAverage Players Teleported Per 10 Minutes: **{CompplayersTeleportedAvgPer10Min}**\nMost Players Teleported In Game: **{CompplayersTeleportedMostInGame}**\nPrimary Fire Accuracy: **{CompprimaryFireAccuracy}**\nSecondary Fire Direct Hits Per 10 Minutes: **{CompsecondaryDirectHitsAvgPer10Min}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSentry Turret Kills: **{CompsentryTurretsKills}**\nAverage Sentry Turret Kills Per 10 Minutes: **{CompsentryTurretsKillsAvgPer10Min}**\nMost Sentry Turret Kills In Game: **{CompsentryTurretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "torbjorn")
                {
                    string QpmoltenCoreKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKills.ToString();
                    string QpmoltenCoreKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKillsAvgPer10Min.ToString();
                    string QpmoltenCoreKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKillsMostInGame.ToString();
                    string QpoverloadKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.overloadKills.ToString();
                    string QpoverloadKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.overloadKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QptorbjornKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKills.ToString();
                    string QptorbjornKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKillsAvgPer10Min.ToString();
                    string QptorbjornKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKillsMostInGame.ToString();
                    string QpturretsDamageAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsDamageAvgPer10Min.ToString();
                    string QpturretsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKills.ToString();
                    string QpturretsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKillsAvgPer10Min.ToString();
                    string QpturretsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKillsMostInGame.ToString();

                    string CompmoltenCoreKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKills.ToString();
                    string CompmoltenCoreKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKillsAvgPer10Min.ToString();
                    string CompmoltenCoreKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKillsMostInGame.ToString();
                    string CompoverloadKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.overloadKills.ToString();
                    string CompoverloadKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.overloadKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string ComptorbjornKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKills.ToString();
                    string ComptorbjornKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKillsAvgPer10Min.ToString();
                    string ComptorbjornKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKillsMostInGame.ToString();
                    string CompturretsDamageAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsDamageAvgPer10Min.ToString();
                    string CompturretsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKills.ToString();
                    string CompturretsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKillsAvgPer10Min.ToString();
                    string CompturretsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKillsMostInGame.ToString();

                    string qpHeroSpecific = $"Molten Core Kills: **{QpmoltenCoreKills}**\nAverage Molten Core Kills Per 10 Minutes: **{QpmoltenCoreKillsAvgPer10Min}**\nMost Molten Core Kills In Game: **{QpmoltenCoreKillsMostInGame}**\nOverload Kills: **{QpoverloadKills}**\nMost Overload Kills In Game: **{QpoverloadKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nTorbjorn Kills: **{QptorbjornKills}**\nAverage Torbjorn Kills Per 10 Minutes: **{QptorbjornKillsAvgPer10Min}**\nMost Torbjorn Kills In Game: **{QptorbjornKillsMostInGame}**\nAverage Turret Damage Per 10 Minutes: **{QpturretsDamageAvgPer10Min}**\nTurret Kills: **{QpturretsKills}**\nAverage Turret Kills Per 10 Minutes: **{QpturretsKillsAvgPer10Min}**\nMost Turret Kills In Game: **{QpturretsKillsMostInGame}**";
                    string compHeroSpecific = $"Molten Core Kills: **{CompmoltenCoreKills}**\nAverage Molten Core Kills Per 10 Minutes: **{CompmoltenCoreKillsAvgPer10Min}**\nMost Molten Core Kills In Game: **{CompmoltenCoreKillsMostInGame}**\nOverload Kills: **{CompoverloadKills}**\nMost Overload Kills In Game: **{CompoverloadKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nTorbjorn Kills: **{ComptorbjornKills}**\nAverage Torbjorn Kills Per 10 Minutes: **{ComptorbjornKillsAvgPer10Min}**\nMost Torbjorn Kills In Game: **{ComptorbjornKillsMostInGame}**\nAverage Turret Damage Per 10 Minutes: **{CompturretsDamageAvgPer10Min}**\nTurret Kills: **{CompturretsKills}**\nAverage Turret Kills Per 10 Minutes: **{CompturretsKillsAvgPer10Min}**\nMost Turret Kills In Game: **{CompturretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "tracer")
                {
                    string QphealthRecovered = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecovered.ToString();
                    string QphealthRecoveredAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecoveredAvgPer10Min.ToString();
                    string QphealthRecoveredMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecoveredMostInGame.ToString();
                    string QppulseBombsAttached = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttached.ToString();
                    string QppulseBombsAttachedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttachedAvgPer10Min.ToString();
                    string QppulseBombsAttachedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttachedMostInGame.ToString();
                    string QppulseBombsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKills.ToString();
                    string QppulseBombsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKillsAvgPer10Min.ToString();
                    string QppulseBombsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string ComphealthRecovered = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecovered.ToString();
                    string ComphealthRecoveredAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecoveredAvgPer10Min.ToString();
                    string ComphealthRecoveredMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecoveredMostInGame.ToString();
                    string ComppulseBombsAttached = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttached.ToString();
                    string ComppulseBombsAttachedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttachedAvgPer10Min.ToString();
                    string ComppulseBombsAttachedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttachedMostInGame.ToString();
                    string ComppulseBombsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKills.ToString();
                    string ComppulseBombsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKillsAvgPer10Min.ToString();
                    string ComppulseBombsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"Health Recalled: **{QphealthRecovered}**\nAverage Health Recalled Per 10 Minutes: **{QphealthRecoveredAvgPer10Min}**\nMost Health Recalled In Game: **{QphealthRecoveredMostInGame}**\nPulse Bomb Attached: **{QppulseBombsAttached}**\nAverage Pulse Bombs Attached Per 10 Minutes: **{QppulseBombsAttachedAvgPer10Min}**\nMost Pulse Bombs Attached In Game: **{QppulseBombsAttachedMostInGame}**\nPulse Bomb Kills: **{QppulseBombsKills}**\nAverage Pulse Bomb Kills Per 10 Minutes: **{QppulseBombsKillsAvgPer10Min}**\nMost Pulse Bomb Kills In Game: **{QppulseBombsKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Health Recalled: **{ComphealthRecovered}**\nAverage Health Recalled Per 10 Minutes: **{ComphealthRecoveredAvgPer10Min}**\nMost Health Recalled In Game: **{ComphealthRecoveredMostInGame}**\nPulse Bomb Attached: **{ComppulseBombsAttached}**\nAverage Pulse Bombs Attached Per 10 Minutes: **{ComppulseBombsAttachedAvgPer10Min}**\nMost Pulse Bombs Attached In Game: **{ComppulseBombsAttachedMostInGame}**\nPulse Bomb Kills: **{ComppulseBombsKills}**\nAverage Pulse Bomb Kills Per 10 Minutes: **{ComppulseBombsKillsAvgPer10Min}**\nMost Pulse Bomb Kills In Game: **{ComppulseBombsKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "widowmaker")
                {
                    string QpscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpscopedAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpscopedCriticalHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string QpscopedCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string QpscopedCriticalHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string QpscopedCriticalHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpvenomMineKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKills.ToString();
                    string QpvenomMineKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKillsAvgPer10Min.ToString();
                    string QpvenomMineKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKillsMostInGame.ToString();

                    string CompscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompscopedAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompscopedCriticalHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string CompscopedCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string CompscopedCriticalHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string CompscopedCriticalHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompvenomMineKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKills.ToString();
                    string CompvenomMineKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKillsAvgPer10Min.ToString();
                    string CompvenomMineKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKillsMostInGame.ToString();

                    //recon assists
                    string CompreconAssists = dataObject.competitiveStats.careerStats[hero].assists.reconAssists.ToString();
                    string CompreconAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.reconAssistsAvgPer10Min.ToString();
                    string CompreconAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.reconAssistsMostInGame.ToString();

                    string QpreconAssists = dataObject.quickPlayStats.careerStats[hero].assists.reconAssists.ToString();
                    string QpreconAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.reconAssistsAvgPer10Min.ToString();
                    string QpreconAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.reconAssistsMostInGame.ToString();

                    string qpAssists = $"Recon Assists: **{QpreconAssists}**\nAverage Recon Assists Per 10 Minutes: **{QpreconAssistsAvgPer10Min}**\nMost Recon Assists In Game: **{QpreconAssistsMostInGame}**";
                    string compAssists = $"Recon Assists: **{CompreconAssists}**\nAverage Recon Assists Per 10 Minutes: **{CompreconAssistsAvgPer10Min}**\nMost Recon Assists In Game: **{CompreconAssistsMostInGame}**";
                    string qpHeroSpecific = $"Scoped Accuracy: **{QpscopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpscopedAccuracyBestInGame}**\nScoped Critical Hits Accuracy: **{QpscopedCriticalHitsAccuracy}**\nScoped Critical Hits: **{QpscopedCriticalHits}**\nAverage Scoped Critical Hits Per 10 Minutes: **{QpscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{QpscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nVenom Mine Kills: **{QpvenomMineKills}**\nAverage Venom Mine Kills Per 10 Minutes: **{QpvenomMineKillsAvgPer10Min}**\nMost Venom Mine Kills In Game: **{QpvenomMineKillsMostInGame}**";
                    string compHeroSpecific = $"Scoped Accuracy: **{CompscopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompscopedAccuracyBestInGame}**\nScoped Critical Hits Accuracy: **{CompscopedCriticalHitsAccuracy}**\nScoped Critical Hits: **{CompscopedCriticalHits}**\nAverage Scoped Critical Hits Per 10 Minutes: **{CompscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{CompscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nVenom Mine Kills: **{CompvenomMineKills}**\nAverage Venom Mine Kills Per 10 Minutes: **{CompvenomMineKillsAvgPer10Min}**\nMost Venom Mine Kills In Game: **{CompvenomMineKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "winston")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpjumpPackKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKills.ToString();
                    string QpjumpPackKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKillsAvgPer10Min.ToString();
                    string QpjumpPackKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKillsMostInGame.ToString();
                    string QpmeleeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKills.ToString();
                    string QpmeleeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKillsAvgPer10Min.ToString();
                    string QpmeleeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKillsMostInGame.ToString();
                    string QpplayersKnockedBack = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string QpplayersKnockedBackAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string QpplayersKnockedBackMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string QpprimalRageKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKills.ToString();
                    string QpprimalRageKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKillsAvgPer10Min.ToString();
                    string QpprimalRageKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKillsMostInGame.ToString();
                    string QpprimalRageMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpteslaCannonAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.teslaCannonAccuracy.ToString();
                    string QpweaponKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.weaponKills.ToString();

                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompjumpPackKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKills.ToString();
                    string CompjumpPackKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKillsAvgPer10Min.ToString();
                    string CompjumpPackKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKillsMostInGame.ToString();
                    string CompmeleeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKills.ToString();
                    string CompmeleeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKillsAvgPer10Min.ToString();
                    string CompmeleeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKillsMostInGame.ToString();
                    string CompplayersKnockedBack = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string CompplayersKnockedBackAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string CompplayersKnockedBackMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string CompprimalRageKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKills.ToString();
                    string CompprimalRageKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKillsAvgPer10Min.ToString();
                    string CompprimalRageKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKillsMostInGame.ToString();
                    string CompprimalRageMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompteslaCannonAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.teslaCannonAccuracy.ToString();
                    string CompweaponKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.weaponKills.ToString();

                    string qpHeroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nJump Pack Kills: **{QpjumpPackKills}**\nAverage Jump Pack Kills Per 10 Minutes: **{QpjumpPackKillsAvgPer10Min}**\nMost Jump Pack Kills In Game: **{QpjumpPackKillsMostInGame}**\nMelee Kills: **{QpmeleeKills}**\nAverage Melee Kills Per 10 Minutes: **{QpmeleeKillsAvgPer10Min}**\nMost Melee Kills In Game: **{QpmeleeKillsMostInGame}**\nPlayers Knocked Back: **{QpplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{QpplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{QpplayersKnockedBackMostInGame}**\nPrimal Rage Kills: **{QpprimalRageKills}**\nAverage Primal Rage Kills In 10 Minutes: **{QpprimalRageKillsAvgPer10Min}**\nMost Primal Rage Kills In Game: **{QpprimalRageKillsMostInGame}**\nPrimal Rage Melee Accuracy: **{QpprimalRageMeleeAccuracy}**\nTesla Cannon Accuracy: **{QpteslaCannonAccuracy}**\nWeapon Kils: **{QpweaponKills}**";
                    string compHeroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nJump Pack Kills: **{CompjumpPackKills}**\nAverage Jump Pack Kills Per 10 Minutes: **{CompjumpPackKillsAvgPer10Min}**\nMost Jump Pack Kills In Game: **{CompjumpPackKillsMostInGame}**\nMelee Kills: **{CompmeleeKills}**\nAverage Melee Kills Per 10 Minutes: **{CompmeleeKillsAvgPer10Min}**\nMost Melee Kills In Game: **{CompmeleeKillsMostInGame}**\nPlayers Knocked Back: **{CompplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{CompplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{CompplayersKnockedBackMostInGame}**\nPrimal Rage Kills: **{CompprimalRageKills}**\nAverage Primal Rage Kills In 10 Minutes: **{CompprimalRageKillsAvgPer10Min}**\nMost Primal Rage Kills In Game: **{CompprimalRageKillsMostInGame}**\nPrimal Rage Melee Accuracy: **{CompprimalRageMeleeAccuracy}**\nTesla Cannon Accuracy: **{CompteslaCannonAccuracy}**\nWeapon Kils: **{CompweaponKills}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "wreckingBall")
                {
                    string QpplayersKnockedBack = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string QpplayersKnockedBackAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string QpplayersKnockedBackMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompplayersKnockedBack = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string CompplayersKnockedBackAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string CompplayersKnockedBackMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"Players Knocked Back: **{QpplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{QpplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{QpplayersKnockedBackMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Players Knocked Back: **{CompplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{CompplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{CompplayersKnockedBackMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zarya")
                {
                    string QpaverageEnergy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.averageEnergy.ToString();
                    string QpaverageEnergyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.averageEnergyBestInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpgravitonSurgeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKills.ToString();
                    string QpgravitonSurgeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKillsAvgPer10Min.ToString();
                    string QpgravitonSurgeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKillsMostInGame.ToString();
                    string QphighEnergyKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKills.ToString();
                    string QphighEnergyKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKillsAvgPer10Min.ToString();
                    string QphighEnergyKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKillsMostInGame.ToString();
                    string QpprimaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string QpprojectedBarriersApplied = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersApplied.ToString();
                    string QpprojectedBarriersAppliedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersAppliedAvgPer10Min.ToString();
                    string QpprojectedBarriersAppliedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersAppliedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompaverageEnergy = dataObject.competitiveStats.careerStats[hero].heroSpecific.averageEnergy.ToString();
                    string CompaverageEnergyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.averageEnergyBestInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompgravitonSurgeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKills.ToString();
                    string CompgravitonSurgeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKillsAvgPer10Min.ToString();
                    string CompgravitonSurgeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKillsMostInGame.ToString();
                    string ComphighEnergyKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKills.ToString();
                    string ComphighEnergyKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKillsAvgPer10Min.ToString();
                    string ComphighEnergyKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKillsMostInGame.ToString();
                    string CompprimaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string CompprojectedBarriersApplied = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersApplied.ToString();
                    string CompprojectedBarriersAppliedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersAppliedAvgPer10Min.ToString();
                    string CompprojectedBarriersAppliedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersAppliedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive and defensive assists
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Average Energy: **{QpaverageEnergy}**\nBest Average Energy In Game: **{QpaverageEnergyBestInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nGraviton Surge Kills: **{QpgravitonSurgeKills}**\nAverage Graviton Surge Kills Per 10 Minutes: **{QpgravitonSurgeKillsAvgPer10Min}**\nMost Graviton Surge Kills In Game: **{QpgravitonSurgeKillsMostInGame}**\nHigh Energy Kills: **{QphighEnergyKills}**\nAverage High Energy Kills Per 10 Minutes: **{QphighEnergyKillsAvgPer10Min}**\nMost High Energy Kills In Game: **{QphighEnergyKillsMostInGame}**\nPrimary Fire Accuracy: **{QpprimaryFireAccuracy}**\nProjected Barriers Applied: **{QpprojectedBarriersApplied}**\nAverage Projected Barriers Provided Per 10 Minutes: **{QpprojectedBarriersAppliedAvgPer10Min}**\nMost Projected Barriers Provided In Game: **{QpprojectedBarriersAppliedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}*";
                    string compHeroSpecific = $"Average Energy: **{CompaverageEnergy}**\nBest Average Energy In Game: **{CompaverageEnergyBestInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nGraviton Surge Kills: **{CompgravitonSurgeKills}**\nAverage Graviton Surge Kills Per 10 Minutes: **{CompgravitonSurgeKillsAvgPer10Min}**\nMost Graviton Surge Kills In Game: **{CompgravitonSurgeKillsMostInGame}**\nHigh Energy Kills: **{ComphighEnergyKills}**\nAverage High Energy Kills Per 10 Minutes: **{ComphighEnergyKillsAvgPer10Min}**\nMost High Energy Kills In Game: **{ComphighEnergyKillsMostInGame}**\nPrimary Fire Accuracy: **{CompprimaryFireAccuracy}**\nProjected Barriers Applied: **{CompprojectedBarriersApplied}**\nAverage Projected Barriers Provided Per 10 Minutes: **{CompprojectedBarriersAppliedAvgPer10Min}**\nMost Projected Barriers Provided In Game: **{CompprojectedBarriersAppliedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}*";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zenyatta")
                {
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QptranscendenceHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.transcendenceHealing.ToString();
                    string QptranscendenceHealingBest = dataObject.quickPlayStats.careerStats[hero].heroSpecific.transcendenceHealingBest.ToString();

                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string ComptranscendenceHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.transcendenceHealing.ToString();
                    string ComptranscendenceHealingBest = dataObject.competitiveStats.careerStats[hero].heroSpecific.transcendenceHealingBest.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nTranscendence Healing: **{QptranscendenceHealing}**\nBest Transcendence Healing In Game: **{QptranscendenceHealingBest}**";
                    string compHeroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nTranscendence Healing: **{ComptranscendenceHealing}**\nBest Transcendence Healing In Game: **{ComptranscendenceHealingBest}**";

                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync("Make sure you have played Competitive and Quickplay with this hero, otherwise check your command.\n**w!owhs <hero> <Your Battle.net username and id> <platform (pc/xbl/psn)> <region> Ex: w!owhs dVa Phytal-1427 pc us**");
            }
        }

        [Command("owherostatsqp")]
        [Summary("Get a Overwatch user's statistics for a specific hero on Quickplay.")]
        [Alias("owhsqp")]
        [Remarks("w!owherostatsqp <hero> <Your Battle.net username and id> <platform (pc/xbl/psn)> <region (us/eu etc.)> Ex: w!owherostatsqp dVa Phytal-1427 pc us")]
        [Cooldown(10)]
        public async Task GetOwHeroStatsQP(string hero, string username, string platform, string region)
        {
            try
            {
                string originalhero = hero;
                var config = GlobalUserAccounts.GetUserAccount(Context.User);
                hero = hero.ToLower();
                hero = GetHero(hero);

                var json = await Global.SendWebRequest($"https://ow-api.com/v1/stats/{platform}/{region}/{username}/heroes/{hero}");

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string endorsementIcon = dataObject.endorsementIcon.ToString();
                string playerIcon = dataObject.icon.ToString();
                string srIcon = dataObject.ratingIcon.ToString();

                string QpAllDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.allDamageDoneAvgPer10Min.ToString();
                string QpBarrierDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.barrierDamageDoneAvgPer10Min.ToString();
                string QpCriticalsAvg = dataObject.quickPlayStats.careerStats[hero].average.criticalHitsAvgPer10Min.ToString();
                string QpDeathAvg = dataObject.quickPlayStats.careerStats[hero].average.deathsAvgPer10Min.ToString();
                string QpElimAvg = dataObject.quickPlayStats.careerStats[hero].average.eliminationsAvgPer10Min.ToString();
                string QpElimPerLife = dataObject.quickPlayStats.careerStats[hero].average.eliminationsPerLife.ToString();
                string QpFinalBlowAvg = dataObject.quickPlayStats.careerStats[hero].average.finalBlowsAvgPer10Min.ToString();
                string QpHeroDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.heroDamageDoneAvgPer10Min.ToString();
                string QpMeleeAvg = dataObject.quickPlayStats.careerStats[hero].average.meleeFinalBlowsAvgPer10Min.ToString();
                string QpObjKillsAvg = dataObject.quickPlayStats.careerStats[hero].average.objectiveKillsAvgPer10Min.ToString();
                string QpObjTimeAvg = dataObject.quickPlayStats.careerStats[hero].average.objectiveTimeAvgPer10Min.ToString();
                string QpSoloKillAvg = dataObject.quickPlayStats.careerStats[hero].average.soloKillsAvgPer10Min.ToString();
                string QpOnFireAvg = dataObject.quickPlayStats.careerStats[hero].average.timeSpentOnFireAvgPer10Min.ToString();
                //best
                string QpAllDamageInGame = dataObject.quickPlayStats.careerStats[hero].best.allDamageDoneMostInGame.ToString();
                string QpAllDamageInLife = dataObject.quickPlayStats.careerStats[hero].best.allDamageDoneMostInLife.ToString();
                string QpBarrierDamageInGame = dataObject.quickPlayStats.careerStats[hero].best.barrierDamageDoneMostInGame.ToString();
                string QpCritMostInGame = dataObject.quickPlayStats.careerStats[hero].best.criticalHitsMostInGame.ToString();
                string QpCritMostInLife = dataObject.quickPlayStats.careerStats[hero].best.criticalHitsMostInLife.ToString();
                string QpElimMostInLife = dataObject.quickPlayStats.careerStats[hero].best.eliminationsMostInLife.ToString();
                string QpElimMostInGame = dataObject.quickPlayStats.careerStats[hero].best.eliminationsMostInGame.ToString();
                string QpFinalBlowMostInGame = dataObject.quickPlayStats.careerStats[hero].best.finalBlowsMostInGame.ToString();
                string QpHeroDmgMostInGame = dataObject.quickPlayStats.careerStats[hero].best.heroDamageDoneMostInGame.ToString();
                string QpHeroDmgMostInLife = dataObject.quickPlayStats.careerStats[hero].best.heroDamageDoneMostInLife.ToString();
                string QpKillStreakBest = dataObject.quickPlayStats.careerStats[hero].best.killsStreakBest.ToString();
                string QpMeleeFinalBlowMostInGame = dataObject.quickPlayStats.careerStats[hero].best.meleeFinalBlowsMostInGame.ToString();
                string QpMultikillBest = dataObject.quickPlayStats.careerStats[hero].best.multikillsBest.ToString();
                string QpObjKillMostInGame = dataObject.quickPlayStats.careerStats[hero].best.objectiveKillsMostInGame.ToString();
                string QpObjTimeMostInGame = dataObject.quickPlayStats.careerStats[hero].best.objectiveTimeMostInGame.ToString();
                string QpSoloKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].best.soloKillsMostInGame.ToString();
                string QpOnFireMostInGame = dataObject.quickPlayStats.careerStats[hero].best.timeSpentOnFireMostInGame.ToString();
                string QpWeaponAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].best.weaponAccuracyBestInGame.ToString();
                //combat
                string QpBarrierDmgDone = dataObject.quickPlayStats.careerStats[hero].combat.barrierDamageDone.ToString();
                string QpCriticalHits = dataObject.quickPlayStats.careerStats[hero].combat.criticalHits.ToString();
                string QpCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.criticalHitsAccuracy.ToString();
                string QpDamageDone = dataObject.quickPlayStats.careerStats[hero].combat.damageDone.ToString();
                string QpDeaths = dataObject.quickPlayStats.careerStats[hero].combat.deaths.ToString();
                string QpElims = dataObject.quickPlayStats.careerStats[hero].combat.eliminations.ToString();

                string QpFinalBlows = dataObject.quickPlayStats.careerStats[hero].combat.finalBlows.ToString();
                string QpHeroDmg = dataObject.quickPlayStats.careerStats[hero].combat.heroDamageDone.ToString();
                string QpMeleeFinalBlows = dataObject.quickPlayStats.careerStats[hero].combat.meleeFinalBlows.ToString();
                string QpMultikills = dataObject.quickPlayStats.careerStats[hero].combat.multikills.ToString();
                string QpObjKills = dataObject.quickPlayStats.careerStats[hero].combat.objectiveKills.ToString();
                string QpObjTime = dataObject.quickPlayStats.careerStats[hero].combat.objectiveTime.ToString();
                string QpMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.quickMeleeAccuracy.ToString();
                string QpSoloKills = dataObject.quickPlayStats.careerStats[hero].combat.soloKills.ToString();
                string QpOnFire = dataObject.quickPlayStats.careerStats[hero].combat.timeSpentOnFire.ToString();
                string QpWeaponAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.weaponAccuracy.ToString();
                //misc stuff
                string QpGamesWon = dataObject.quickPlayStats.careerStats[hero].game.gamesWon.ToString();
                string QpTimePlayed = dataObject.quickPlayStats.careerStats[hero].game.timePlayed.ToString();
                string QpCards = dataObject.quickPlayStats.careerStats[hero].matchAwards.cards.ToString();
                string QpMedals = dataObject.quickPlayStats.careerStats[hero].matchAwards.medals.ToString();
                string QpMedalsBronze = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsBronze.ToString();
                string QpMedalsGold = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsGold.ToString();
                string QpMedalsSilver = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsSilver.ToString();
                string QpElimsPerLife = dataObject.quickPlayStats.topHeroes[hero].eliminationsPerLife.ToString();

                string qpAvg =  $"All Damage Done per 10 Minutes: **{QpAllDamageAvg}**\nBarrier Damage Done per 10 Minutes: **{QpBarrierDamageAvg}**\nHero Damage Done per 10 Minutes: **{QpHeroDamageAvg}**\nCritical Hits per 10 Minutes: **{QpCriticalsAvg}**\nDeaths per 10 Minutes: **{QpDeathAvg}**\nEliminations per 10 Minutes: **{QpElimAvg}**\nEliminations per Life: **{QpElimPerLife}**\nFinal Blows per 10 Minutes: **{QpFinalBlowAvg}**\nMelee Final Blows per 10 Minutes: **{QpMeleeAvg}**\nObjective Time per 10 Minutes: **{QpObjTimeAvg}**\nObjective Kills per 10 Minutes: **{QpObjKillsAvg}**\nSolo Kills per 10 Minutes: **{QpSoloKillAvg}**\nTime on Fire per 10 Minutes: **{QpOnFireAvg}**";
                string qpBest=  $"All Damage in Game: **{QpAllDamageInGame}**\nAll Damage in Life: **{QpAllDamageInLife}**\nBarrier Damage in Game: **{QpBarrierDamageInGame}**\nCriticals in Game: **{QpCritMostInGame}**\nCriticals in Life: **{QpCritMostInLife}**\nEliminations in Game: **{QpElimMostInGame}**\nEliminations in Life: **{QpElimMostInLife}**\nFinal Blows in Game: **{QpFinalBlowMostInGame}**\nHero Damage in Game: **{QpHeroDmgMostInGame}**\nHero Damage in Life: **{QpHeroDmgMostInLife}**\nKill Streak: **{QpKillStreakBest}**\nMelee Final Blows in Game: **{QpMeleeFinalBlowMostInGame}**\nMultikill: **{QpMultikillBest}**\nObjective Kills in Game: **{QpObjKillMostInGame}**\nObjective Time in Game: **{QpObjTimeMostInGame}**\nSolo Kills in Game: **{QpSoloKillsMostInGame}**\nOn Fire Time in Game: **{QpOnFireMostInGame}**\nWeapon Accuracy in Game: **{QpWeaponAccuracyBestInGame}**";
                string qpTotal = $"Barrier Damage Done: **{QpBarrierDmgDone}**\nCritical Hits: **{QpCriticalHits}**\nObjective Time in Game: **{QpObjTimeMostInGame}**\nCritical Hit Accuracy: **{QpCriticalHitsAccuracy}**\nDamage Done: **{QpDamageDone}**\nDeaths: **{QpDeaths}**\nEliminations: **{QpElims}**\nFinal Blows: **{QpFinalBlows}**\nHero Damage: **{QpHeroDmg}**\nMelee Final Blows: **{QpMeleeFinalBlows}**\nMultikills: **{QpMultikills}**\nObjective Kills: **{QpObjKills}**\nObjective Time: **{QpObjTime}**\nMelee Accuracy: **{QpMeleeAccuracy}**\nSolo Kills: **{QpSoloKills}**\nOn Fire Time: **{QpOnFire}**\nWeapon Accuracy: **{QpWeaponAccuracy}**";
                string qpMisc = $"Games Won: **{QpGamesWon}**\nTime Played: **{QpTimePlayed}**\nCards: **{QpCards}**\nTotal Medals: **{QpMedals}**\nGold Medals: **{QpMedalsGold}**\nSilver Medals: **{QpMedalsSilver}**\nBronze Medals: **{QpMedalsBronze}**\nEliminations per Life: **{QpElimsPerLife}**\n";

                if (hero == "ana")
                {
                    string QpBioticKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticGrenadeKills.ToString();
                    string QpEnemiesSlept = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSlept.ToString();
                    string QpEnemiesSleptPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSleptAvgPer10Min.ToString();
                    string QpEnemiesSleptMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSleptMostInGame.ToString();
                    string QpNanoAssists = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssists.ToString();
                    string QpNanoAssistsPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssistsAvgPer10Min.ToString();
                    string QpMostNanoAssistsIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssistsMostInGame.ToString();
                    string QpNanosApplied = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsApplied.ToString();
                    string QpNanosAppliedPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsAppliedAvgPer10Min.ToString();
                    string QpNanoAppliedMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsAppliedMostInGame.ToString();
                    string QpScopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpScopedAccuracyBestIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpSecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpSelfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpSelfHealingPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpSelfHealingMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpUnscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.unscopedAccuracy.ToString();
                    string QpUnscopedAccuracyBestIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.unscopedAccuracyBestInGame.ToString();

                    //healing stats for healers

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Biotic Grenade Kills: **{QpBioticKills}**\nEnemies Slept: **{QpEnemiesSlept}**\nAverage Enemies Slept per 10 Minutes: **{QpEnemiesSleptPer10Min}**\nMost Enemies Slept In Game: **{QpEnemiesSleptPer10Min}**\nNano Boost Assists: **{QpNanoAssists}**\nNano Boost Assists Per 10 Minutes: **{QpNanosAppliedPer10Min}**\nMost Nano Boost Assists In Game: **{QpMostNanoAssistsIG}**\nNano Boosts Applied: **{QpNanosApplied}**\nNano Boosts Applied Per 10 Minutes: **{QpNanosAppliedPer10Min}**\nNano Boosts Applied Most In Game: **{QpNanoAppliedMostIG}**\nScoped Accuracy: **{QpScopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpScopedAccuracyBestIG}**\nSecondary Fire Accuracy: **{QpSecondaryFireAccuracy}**\nSelf Healing: **{QpSelfHealing}**\nSelf Healing Per 10 Minutes: **{QpSelfHealingPer10Min}**\nMost Self Healing In Game: **{QpSelfHealingMostIG}**\nUnscoped Accuracy: **{QpUnscopedAccuracy}**\nBest Unscoped Accuracy In Game: **{QpScopedAccuracyBestIG}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific"} };
                    await PagedReplyAsync(pages);
                }
                if (hero == "ashe")
                {
                    string QpbobKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKills.ToString();
                    string QpbobKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKillsAvgPer10Min.ToString();
                    string QpbobKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKillsMostInGame.ToString();
                    string QpcoachGunKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKills.ToString();
                    string QpcoachGunKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKillsAvgPer10Min.ToString();
                    string QpcoachGunKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKillsMostInGame.ToString();
                    string QpdynamiteKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKills.ToString();
                    string QpdynamiteKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKillsAvgPer10Min.ToString();
                    string QpdynamiteKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKillsMostInGame.ToString();
                    string QpscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpscopedAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpscopedCriticalHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string QpscopedCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string QpscopedCriticalHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string QpscopedCriticalHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"BOB Kills: **{QpbobKills}**\nAverage BOB Kills Per 10 Minutes: **{QpbobKillsAvgPer10Min}**\nMost BOB Kills In Game: **{QpbobKillsMostInGame}**\nCoach Gun Kills: **{QpcoachGunKills}**\nAverage Coach Gun Kills Per 10 Minutes: **{QpcoachGunKillsAvgPer10Min}**\nMost Coach Gun Kills In Game: **{QpcoachGunKillsMostInGame}**\nDynamite Kills: **{QpdynamiteKills}**\nAverage Dynamite Kills Per 10 Minutes: **{QpdynamiteKillsAvgPer10Min}**\nMost Dynamite Kills In Game Kills: **{QpdynamiteKillsMostInGame}**\nScoped Accuracy: **{QpscopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpscopedAccuracyBestInGame}**\nScoped Creitical Hits: **{QpscopedCriticalHits}**\nScoped Critical Hits Accuracy: **{QpscopedCriticalHitsAccuracy}**\nAverage Scoped Critical Hits Per 10 Minutes: **{QpscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{QpscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";

                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "bastion")
                {
                    string QpreconKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKills.ToString();
                    string QpreconKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKillsAvgPer10Min.ToString();
                    string QpreconKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].selfHealingAvgPer10Min.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpsentryKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKills.ToString();
                    string QpsentryKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKillsAvgPer10Min.ToString();
                    string QpsentryKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKillsMostInGame.ToString();
                    string QptankKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKills.ToString();
                    string QptankKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKillsAvgPer10Min.ToString();
                    string QptankKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKillsMostInGame.ToString();

                    string heroSpecific = $"Recon Kills: **{QpreconKills}**\nAverage Recon Kills Per 10 Minutes: **{QpreconKillsAvgPer10Min}**\nMost Recon Kills In Game: **{QpreconKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nSentry Kills: **{QpsentryKills}**\nAverage Sentry Kills Per 10 Minutes: **{QpsentryKillsAvgPer10Min}**\nMost Sentry Kills In Game: **{QpsentryKillsMostInGame}**\nTank Kills: **{QptankKills}**\nAverage Tank Kills Per 10 Minutes: **{QpreconKills}**\nMost Tank Kills In Game: **{QptankKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "brigitte")
                {
                    string QparmorProvided = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvided.ToString();
                    string QparmorProvidedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvidedAvgPer10Min.ToString();
                    string QparmorProvidedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvidedMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpinspireUptimePercentage = dataObject.quickPlayStats.careerStats[hero].heroSpecific.inspireUptimePercentage.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();

                    //healing stats for healers
                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Armor Provided: **{QparmorProvided}**\nAverage Armor Provided Per 10 Minutes: **{QparmorProvidedAvgPer10Min}**\nMost Armor Provided In Game: **{QparmorProvidedMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nInspire Uptime Percentage: **{QpinspireUptimePercentage}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "dVa")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpmechDeaths = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechDeaths.ToString();
                    string QpmechsCalled = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalled.ToString();
                    string QpmechsCalledAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalledAvgPer10Min.ToString();
                    string QpmechsCalledMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalledMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfDestructKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKills.ToString();
                    string QpselfDestructKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKillsAvgPer10Min.ToString();
                    string QpselfDestructKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKillsMostInGame.ToString();

                    string heroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nMech Deaths: **{QpmechDeaths}**\nMechs Called: **{QpmechsCalled}**\nAverage Mechs Called Per 10 Minutes: **{QpmechsCalledAvgPer10Min}**\nMost Mechs Called In Game: **{QpmechsCalledMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Destruct Kills: **{QpselfDestructKills}**\nAverage Self Destruct Kills Per 10 Minutes: **{QpselfDestructKillsAvgPer10Min}**\nMost Self Destruct Kills In Game: **{QpselfDestructKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "doomfist")
                {
                    string QpabilityDamageDone = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.barrierDamageDone.ToString();
                    string QpabilityDamageDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.abilityDamageDoneAvgPer10Min.ToString();
                    string QpabilityDamageDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.abilityDamageDoneMostInGame.ToString();
                    string QpmeteorStrikeKills = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKills.ToString();
                    string QpmeteorStrikeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsAvgPer10Min.ToString();
                    string QpmeteorStrikeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.secondaryFireAccuracy.ToString();
                    string QpshieldsCreated = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreated.ToString();
                    string QpshieldsCreatedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreatedAvgPer10Min.ToString();
                    string QpshieldsCreatedMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreatedMostInGame.ToString();

                    string heroSpecific = $"Ability Damage Done: **{QpabilityDamageDone}**\nAverage Ability Damage Done Per 10 Minutes: **{QpabilityDamageDoneAvgPer10Min}**\nMost Ability Damage Done In Game: **{QpabilityDamageDoneMostInGame}**\nMeteor Strike Kills: **{QpmeteorStrikeKills}**\nAverage Meteor Strike Kills Per 10 Minutes: **{QpmeteorStrikeKillsAvgPer10Min}**\nMost Meteor Strike Kills In Game: **{QpmeteorStrikeKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nShields Created: **{QpshieldsCreated}**\nAverage Shields Created Per 10 Minutes: **{QpshieldsCreatedAvgPer10Min}**\nMost Shields Created In Game: **{QpshieldsCreatedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "genji")
                {
                    string QpdamageReflected = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflected.ToString();
                    string QpdamageReflectedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflectedAvgPer10Min.ToString();
                    string QpdamageReflectedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflectedMostInGame.ToString();
                    string QpdeflectionKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deflectionKills.ToString();
                    string QpdragonbladesKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKills.ToString();
                    string QpdragonbladesKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKillsAvgPer10Min.ToString();
                    string QpdragonbladesKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Damage Deflected: **{QpdamageReflected}**\nAverage Damage Deflected Per 10 Minutes: **{QpdamageReflectedMostInGame}**\nMost Damage Deflected In Game: **{QpdamageReflectedMostInGame}**\nDeflection Kills: **{QpdeflectionKills}**\nDragonblade Kills: **{QpdragonbladesKills}**\nAverage Dragonblade Kills Per 10 Minutes: **{QpdragonbladesKillsAvgPer10Min}**\nMost Dragonblade Kills In Game: **{QpdragonbladesKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "hanzo")
                {
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpstormArrowKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKills.ToString();
                    string QpstormArrowKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKillsAvgPer10Min.ToString();
                    string QpstormArrowKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKillsMostInGame.ToString();

                    string heroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nStorm Arrow Kills: **{QpstormArrowKills}**\nAverage Storm Arrow Kills Per 10 Minutes: **{QpstormArrowKillsAvgPer10Min}**\nMost Storm Arrow Kills In Game: **{QpstormArrowKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "junkrat")
                {
                    string QpconcussionMineKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKills.ToString();
                    string QpconcussionMineKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKillsAvgPer10Min.ToString();
                    string QpconcussionMineKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKillsMostInGame.ToString();
                    string QpenemiesTrapped = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrapped.ToString();
                    string QpenemiesTrappedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrappedAvgPer10Min.ToString();
                    string QpenemiesTrappedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrappedMostInGame.ToString();
                    string QpripTireKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKills.ToString();
                    string QpripTireKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKillsAvgPer10Min.ToString();
                    string QpripTireKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive assists

                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Concussion Mine Kills: **{QpconcussionMineKills}**\nAverage Concussion Mine Kills Per 10 Minutes: **{QpconcussionMineKillsAvgPer10Min}**\nMost Concussion Mine Kills in Game: **{QpconcussionMineKillsMostInGame}**\nEnemies Trapped: **{QpenemiesTrapped}**\nAverage Enemies Trapped Per 10 Minutes: **{QpenemiesTrappedAvgPer10Min}**\nMost Enemies Trapped In Game: **{QpenemiesTrappedMostInGame}**\nRip Tire Kills: **{QpripTireKills}**\nAverage Rip Tire Kills Per 10 Minutes: **{QpripTireKillsAvgPer10Min}**\nMost Rip Tire Kills In Game: **{QpripTireKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "lucio")
                {
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpsoundBarriersProvided = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvided.ToString();
                    string QpsoundBarriersProvidedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvidedAvgPer10Min.ToString();
                    string QpsoundBarriersProvidedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvidedMostInGame.ToString();

                    //healing stats for healers
                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\n:Most Self Healing In Game **{QpselfHealingMostInGame}**\nSound Barriers Provided: **{QpsoundBarriersProvided}**\nAverage Sound Barriers Provided Per 10 minutes: **{QpsoundBarriersProvidedAvgPer10Min}**\nMost Sound barriers Provided In Game: **{QpsoundBarriersProvidedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mccree")
                {
                    string QpdeadeyeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKills.ToString();
                    string QpdeadeyeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKillsAvgPer10Min.ToString();
                    string QpdeadeyeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKillsMostInGame.ToString();
                    string QpfanTheHammerKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKills.ToString();
                    string QpfanTheHammerKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKillsAvgPer10Min.ToString();
                    string QpfanTheHammerKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Deadeye Kills: **{QpdeadeyeKills}**\nAverage Deadeye Kills Per 10 Minutes: **{QpdeadeyeKillsAvgPer10Min}**\nMost Deadeye Kills In Game: **{QpdeadeyeKillsMostInGame}**\nFan The Hammer Kills: **{QpfanTheHammerKills}**\nAverage Fan The Hammer Kills Per 10 Minutes: **{QpfanTheHammerKillsAvgPer10Min}**\nMost Fan The Hammer Kills In Game: **{QpfanTheHammerKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mei")
                {
                    string QpblizzardKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKills.ToString();
                    string QpblizzardKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKillsAvgPer10Min.ToString();
                    string QpblizzardKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKillsMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpenemiesFrozen = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozen.ToString();
                    string QpenemiesFrozenAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozenAvgPer10Min.ToString();
                    string QpenemiesFrozenMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozenMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //offensive assists

                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Blizzard Kills: **{QpblizzardKills}**\nAverage Blizzard Kills Per 10 Minutes: **{QpblizzardKillsAvgPer10Min}**\nMost Blizzard Kills In Game: **{QpblizzardKillsMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nEnemies Frozen: **{QpenemiesFrozen}**\nAverage Enemies Frozen: **{QpenemiesFrozenAvgPer10Min}**\nMost Enemies Frozen In Game: **{QpenemiesFrozenMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mercy")
                {
                    string QpblasterKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKills.ToString();
                    string QpblasterKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKillsAvgPer10Min.ToString();
                    string QpblasterKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKillsMostInGame.ToString();
                    string QpdamageAmplified = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string QpdamageAmplifiedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string QpdamageAmplifiedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string QpplayersResurrected = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrected.ToString();
                    string QpplayersResurrectedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrectedAvgPer10Min.ToString();
                    string QpplayersResurrectedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrectedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Blaster Kills: **{QpblasterKills}**\nAverage Blaster Kills Per 10 Minutes: **{QpblasterKillsAvgPer10Min}**\nMost Blaster Kills In Game: **{QpblasterKillsMostInGame}**\nDamage Amplified: **{QpdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{QpdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{QpdamageAmplifiedMostInGame}**\nPlayers Resurrected: **{QpplayersResurrected}**\nAverage Players Resurrected Per 10 Minutes: **{QpplayersResurrectedAvgPer10Min}**\nMost Players Ressurected In Game: **{QpplayersResurrectedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "moira")
                {
                    string QpcoalescenceHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealing.ToString();
                    string QpcoalescenceHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealingAvgPer10Min.ToString();
                    string QpcoalescenceHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealingMostInGame.ToString();
                    string QpcoalescenceKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKills.ToString();
                    string QpcoalescenceKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKillsAvgPer10Min.ToString();
                    string QpcoalescenceKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Coalescence Healing: **{QpcoalescenceHealing}**\nAverage Coalescence Healing Per 10 Minutes: **{QpcoalescenceHealingAvgPer10Min}**\nMost Coalescence Healing In Game: **{QpcoalescenceHealingMostInGame}**\nCoalescence Kills: **{QpcoalescenceKills}**\nAverage Coalescence Kills Per 10 Minutes: **{QpcoalescenceKillsAvgPer10Min}**\nMost Coalescence Kills In Game: **{QpcoalescenceKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "orisa")
                {
                    string QpdamageAmplified = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string QpdamageAmplifiedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string QpdamageAmplifiedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpsuperchargerAssists = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssists.ToString();
                    string QpsuperchargerAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssistsAvgPer10Min.ToString();
                    string QpsuperchargerAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssistsMostInGame.ToString();

                    //offensive assists
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Damage Amplified: **{QpdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{QpdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{QpdamageAmplifiedMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSupercharger Assists: **{QpsuperchargerAssists}**\nAverage Supercharger Assists Per 10 Minutes: **{QpsuperchargerAssistsAvgPer10Min}**\nMost Supercharger Assists In Game: **{QpsuperchargerAssistsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "pharah")
                {
                    string QpbarrageKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKills.ToString();
                    string QpbarrageKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKillsAvgPer10Min.ToString();
                    string QpbarrageKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKillsMostInGame.ToString();
                    string QpdirectHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.directHitsAccuracy.ToString();
                    string QprocketDirectHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHits.ToString();
                    string QprocketDirectHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHitsAvgPer10Min.ToString();
                    string QprocketDirectHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Barrage Kills: **{QpbarrageKills}**\nAverage Barrage Kills Per 10 Minutes: **{QpbarrageKillsAvgPer10Min}**\nMost Barrage Kills In Game: **{QpbarrageKillsMostInGame}**\nDirect Hits Accuracy: **{QpdirectHitsAccuracy}**\nRocket Dirrect Hits: **{QprocketDirectHits}**\nAverage Rocket Direct Hits Per 10 Minutes: **{QprocketDirectHitsAvgPer10Min}**\nMost Rocket Direct Hits In Game: **{QprocketDirectHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reaper")
                {
                    string QpdeathsBlossomKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKills.ToString();
                    string QpdeathsBlossomKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKillsAvgPer10Min.ToString();
                    string QpdeathsBlossomKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string heroSpecific = $"Death Blossom Kills: **{QpdeathsBlossomKills}**\nAverage Death Blossom Kills Per 10 Minutes: **{QpdeathsBlossomKillsAvgPer10Min}**\nMost Death Blossom Kills In Game: **{QpdeathsBlossomKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reinhardt")
                {
                    string QpchargeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKills.ToString();
                    string QpchargeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKillsAvgPer10Min.ToString();
                    string QpchargeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKillsMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpearthshatterKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKills.ToString();
                    string QpearthshatterKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKillsAvgPer10Min.ToString();
                    string QpearthshatterKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKillsMostInGame.ToString();
                    string QpfireStrikeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKills.ToString();
                    string QpfireStrikeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKillsAvgPer10Min.ToString();
                    string QpfireStrikeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKillsMostInGame.ToString();
                    string QprocketHammerMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketHammerMeleeAccuracy.ToString();

                    string heroSpecific = $"Charge Kills: **{QpchargeKills}**\nAverage Charge Kills Per 10 Minutes: **{QpchargeKillsAvgPer10Min}**\nMost Charge Kills In Game: **{QpchargeKillsMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nEarthshatter Kills: **{QpearthshatterKills}**\nAverage Earthshatter Kills Per 10 Minutes: **{QpearthshatterKillsAvgPer10Min}**\nMost Earthshatter Kills In Game: **{QpearthshatterKillsMostInGame}**\nFire Strike Kills: **{QpfireStrikeKills}**\nFire Strike Kills: **{QpfireStrikeKills}**\nAverage Fire Strike Kills Per 10 Minutes: **{QpfireStrikeKillsAvgPer10Min}**\nMost Fire Strike Kills In Game: **{QpfireStrikeKillsMostInGame}**\nRocket Hammer Melee Accuracy: **{QprocketHammerMeleeAccuracy}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "roadhog")
                {
                    string QpenemiesHooked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHooked.ToString();
                    string QpenemiesHookedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHookedAvgPer10Min.ToString();
                    string QpenemiesHookedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHookedMostInGame.ToString();
                    string QphookAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hookAccuracy.ToString();
                    string QphookAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hookAccuracyBestInGame.ToString();
                    string QphooksAttempted = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hooksAttempted.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpwholeHogKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKills.ToString();
                    string QpwholeHogKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKillsAvgPer10Min.ToString();
                    string QpwholeHogKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKillsMostInGame.ToString();

                    //offensive assists
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Enemies Hooked: **{QpenemiesHooked}**\nAverage Enemies Hooked Per 10 Minutes: **{QpenemiesHookedAvgPer10Min}**\nMost Enemies Hooked In Game: **{QpenemiesHookedMostInGame}**\nHook Accuracy: **{QphookAccuracy}**\nBest Hook Accuracy In Game: **{QphookAccuracyBestInGame}**\nHooks Attempted: **{QphooksAttempted}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nWhole Hog Kills: **{QpwholeHogKills}**\nAverage Whole Hog Kills Per 10 Minutes: **{QpwholeHogKillsAvgPer10Min}**\nMost Whole Hog Kills In Game: **{QpwholeHogKillsMostInGame}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "soldier76")
                {
                    string QpbioticFieldHealingDone = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticFieldHealingDone.ToString();
                    string QpbioticFieldsDeployed = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticFieldsDeployed.ToString();
                    string QphelixRocketKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketKillsMostInGame.ToString();
                    string QphelixRocketsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketsKills.ToString();
                    string QphelixRocketsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketsKillsAvgPer10Min.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QpselfHealing}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**";
                    string heroSpecific = $"Biotic Field Healing Done: **{QpbioticFieldHealingDone}**\nBiotic Fields Deployed: **{QpbioticFieldsDeployed}**\nHelix Rocket Kills: **{QphelixRocketsKills}**\nAverage Helix Rocket Kills Per 10 Minutes: **{QphelixRocketsKillsAvgPer10Min}**\nMost Helix Rocket Kills In Game: **{QphelixRocketKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";

                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "sombra")
                {
                    string QpenemiesEmpd = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpd.ToString();
                    string QpenemiesEmpdAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpdAvgPer10Min.ToString();
                    string QpenemiesEmpdMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpdMostInGame.ToString();
                    string QpenemiesHacked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHacked.ToString();
                    string QpenemiesHackedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHackedAvgPer10Min.ToString();
                    string QpenemiesHackedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHackedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive assists
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Enemies EMP'd: **{QpenemiesEmpd}**\nAverage EMP'd Per 10 Minutes: **{QpenemiesEmpdAvgPer10Min}**\nMost Enemies EMP'd In Game: **{QpenemiesEmpdMostInGame}**\nEnemies Hacked: **{QpenemiesHacked}**\nAverage Enemies Hacked Per 10 Minutes: **{QpenemiesHackedAvgPer10Min}**\nMost Enemies Hacked In Game: **{QpenemiesHackedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "symmetra")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpplayersTeleported = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleported.ToString();
                    string QpplayersTeleportedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleportedAvgPer10Min.ToString();
                    string QpplayersTeleportedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleportedMostInGame.ToString();
                    string QpprimaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string QpsecondaryDirectHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryDirectHitsAvgPer10Min.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpsentryTurretsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKills.ToString();
                    string QpsentryTurretsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKillsAvgPer10Min.ToString();
                    string QpsentryTurretsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKillsMostInGame.ToString();

                    string heroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nPlayers Teleported: **{QpplayersTeleported}**\nAverage Players Teleported Per 10 Minutes: **{QpplayersTeleportedAvgPer10Min}**\nMost Players Teleported In Game: **{QpplayersTeleportedMostInGame}**\nPrimary Fire Accuracy: **{QpprimaryFireAccuracy}**\nSecondary Fire Direct Hits Per 10 Minutes: **{QpsecondaryDirectHitsAvgPer10Min}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSentry Turret Kills: **{QpsentryTurretsKills}**\nAverage Sentry Turret Kills Per 10 Minutes: **{QpsentryTurretsKillsAvgPer10Min}**\nMost Sentry Turret Kills In Game: **{QpsentryTurretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "torbjorn")
                {
                    string QpmoltenCoreKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKills.ToString();
                    string QpmoltenCoreKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKillsAvgPer10Min.ToString();
                    string QpmoltenCoreKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKillsMostInGame.ToString();
                    string QpoverloadKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.overloadKills.ToString();
                    string QpoverloadKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.overloadKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QptorbjornKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKills.ToString();
                    string QptorbjornKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKillsAvgPer10Min.ToString();
                    string QptorbjornKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKillsMostInGame.ToString();
                    string QpturretsDamageAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsDamageAvgPer10Min.ToString();
                    string QpturretsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKills.ToString();
                    string QpturretsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKillsAvgPer10Min.ToString();
                    string QpturretsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKillsMostInGame.ToString();

                    string heroSpecific = $"Molten Core Kills: **{QpmoltenCoreKills}**\nAverage Molten Core Kills Per 10 Minutes: **{QpmoltenCoreKillsAvgPer10Min}**\nMost Molten Core Kills In Game: **{QpmoltenCoreKillsMostInGame}**\nOverload Kills: **{QpoverloadKills}**\nMost Overload Kills In Game: **{QpoverloadKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nTorbjorn Kills: **{QptorbjornKills}**\nAverage Torbjorn Kills Per 10 Minutes: **{QptorbjornKillsAvgPer10Min}**\nMost Torbjorn Kills In Game: **{QptorbjornKillsMostInGame}**\nAverage Turret Damage Per 10 Minutes: **{QpturretsDamageAvgPer10Min}**\nTurret Kills: **{QpturretsKills}**\nAverage Turret Kills Per 10 Minutes: **{QpturretsKillsAvgPer10Min}**\nMost Turret Kills In Game: **{QpturretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "tracer")
                {
                    string QphealthRecovered = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecovered.ToString();
                    string QphealthRecoveredAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecoveredAvgPer10Min.ToString();
                    string QphealthRecoveredMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecoveredMostInGame.ToString();
                    string QppulseBombsAttached = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttached.ToString();
                    string QppulseBombsAttachedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttachedAvgPer10Min.ToString();
                    string QppulseBombsAttachedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttachedMostInGame.ToString();
                    string QppulseBombsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKills.ToString();
                    string QppulseBombsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKillsAvgPer10Min.ToString();
                    string QppulseBombsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Health Recalled: **{QphealthRecovered}**\nAverage Health Recalled Per 10 Minutes: **{QphealthRecoveredAvgPer10Min}**\nMost Health Recalled In Game: **{QphealthRecoveredMostInGame}**\nPulse Bomb Attached: **{QppulseBombsAttached}**\nAverage Pulse Bombs Attached Per 10 Minutes: **{QppulseBombsAttachedAvgPer10Min}**\nMost Pulse Bombs Attached In Game: **{QppulseBombsAttachedMostInGame}**\nPulse Bomb Kills: **{QppulseBombsKills}**\nAverage Pulse Bomb Kills Per 10 Minutes: **{QppulseBombsKillsAvgPer10Min}**\nMost Pulse Bomb Kills In Game: **{QppulseBombsKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "widowmaker")
                {
                    string QpscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpscopedAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpscopedCriticalHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string QpscopedCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string QpscopedCriticalHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string QpscopedCriticalHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpvenomMineKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKills.ToString();
                    string QpvenomMineKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKillsAvgPer10Min.ToString();
                    string QpvenomMineKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKillsMostInGame.ToString();

                    //recon assists

                    string QpreconAssists = dataObject.quickPlayStats.careerStats[hero].assists.reconAssists.ToString();
                    string QpreconAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.reconAssistsAvgPer10Min.ToString();
                    string QpreconAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.reconAssistsMostInGame.ToString();

                    string assists = $"Recon Assists: **{QpreconAssists}**\nAverage Recon Assists Per 10 Minutes: **{QpreconAssistsAvgPer10Min}**\nMost Recon Assists In Game: **{QpreconAssistsMostInGame}**";
                    string heroSpecific = $"Scoped Accuracy: **{QpscopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpscopedAccuracyBestInGame}**\nScoped Critical Hits Accuracy: **{QpscopedCriticalHitsAccuracy}**\nScoped Critical Hits: **{QpscopedCriticalHits}**\nAverage Scoped Critical Hits Per 10 Minutes: **{QpscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{QpscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nVenom Mine Kills: **{QpvenomMineKills}**\nAverage Venom Mine Kills Per 10 Minutes: **{QpvenomMineKillsAvgPer10Min}**\nMost Venom Mine Kills In Game: **{QpvenomMineKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "winston")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpjumpPackKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKills.ToString();
                    string QpjumpPackKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKillsAvgPer10Min.ToString();
                    string QpjumpPackKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKillsMostInGame.ToString();
                    string QpmeleeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKills.ToString();
                    string QpmeleeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKillsAvgPer10Min.ToString();
                    string QpmeleeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKillsMostInGame.ToString();
                    string QpplayersKnockedBack = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string QpplayersKnockedBackAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string QpplayersKnockedBackMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string QpprimalRageKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKills.ToString();
                    string QpprimalRageKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKillsAvgPer10Min.ToString();
                    string QpprimalRageKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKillsMostInGame.ToString();
                    string QpprimalRageMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpteslaCannonAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.teslaCannonAccuracy.ToString();
                    string QpweaponKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.weaponKills.ToString();

                    string heroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nJump Pack Kills: **{QpjumpPackKills}**\nAverage Jump Pack Kills Per 10 Minutes: **{QpjumpPackKillsAvgPer10Min}**\nMost Jump Pack Kills In Game: **{QpjumpPackKillsMostInGame}**\nMelee Kills: **{QpmeleeKills}**\nAverage Melee Kills Per 10 Minutes: **{QpmeleeKillsAvgPer10Min}**\nMost Melee Kills In Game: **{QpmeleeKillsMostInGame}**\nPlayers Knocked Back: **{QpplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{QpplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{QpplayersKnockedBackMostInGame}**\nPrimal Rage Kills: **{QpprimalRageKills}**\nAverage Primal Rage Kills In 10 Minutes: **{QpprimalRageKillsAvgPer10Min}**\nMost Primal Rage Kills In Game: **{QpprimalRageKillsMostInGame}**\nPrimal Rage Melee Accuracy: **{QpprimalRageMeleeAccuracy}**\nTesla Cannon Accuracy: **{QpteslaCannonAccuracy}**\nWeapon Kils: **{QpweaponKills}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "wreckingBall")
                {
                    string QpplayersKnockedBack = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string QpplayersKnockedBackAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string QpplayersKnockedBackMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Players Knocked Back: **{QpplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{QpplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{QpplayersKnockedBackMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zarya")
                {
                    string QpaverageEnergy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.averageEnergy.ToString();
                    string QpaverageEnergyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.averageEnergyBestInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpgravitonSurgeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKills.ToString();
                    string QpgravitonSurgeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKillsAvgPer10Min.ToString();
                    string QpgravitonSurgeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKillsMostInGame.ToString();
                    string QphighEnergyKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKills.ToString();
                    string QphighEnergyKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKillsAvgPer10Min.ToString();
                    string QphighEnergyKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKillsMostInGame.ToString();
                    string QpprimaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string QpprojectedBarriersApplied = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersApplied.ToString();
                    string QpprojectedBarriersAppliedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersAppliedAvgPer10Min.ToString();
                    string QpprojectedBarriersAppliedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersAppliedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive and defensive assists
                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Average Energy: **{QpaverageEnergy}**\nBest Average Energy In Game: **{QpaverageEnergyBestInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nGraviton Surge Kills: **{QpgravitonSurgeKills}**\nAverage Graviton Surge Kills Per 10 Minutes: **{QpgravitonSurgeKillsAvgPer10Min}**\nMost Graviton Surge Kills In Game: **{QpgravitonSurgeKillsMostInGame}**\nHigh Energy Kills: **{QphighEnergyKills}**\nAverage High Energy Kills Per 10 Minutes: **{QphighEnergyKillsAvgPer10Min}**\nMost High Energy Kills In Game: **{QphighEnergyKillsMostInGame}**\nPrimary Fire Accuracy: **{QpprimaryFireAccuracy}**\nProjected Barriers Applied: **{QpprojectedBarriersApplied}**\nAverage Projected Barriers Provided Per 10 Minutes: **{QpprojectedBarriersAppliedAvgPer10Min}**\nMost Projected Barriers Provided In Game: **{QpprojectedBarriersAppliedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}*";

                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zenyatta")
                {
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QptranscendenceHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.transcendenceHealing.ToString();
                    string QptranscendenceHealingBest = dataObject.quickPlayStats.careerStats[hero].heroSpecific.transcendenceHealingBest.ToString();

                    //healing stats for healers

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nTranscendence Healing: **{QptranscendenceHealing}**\nBest Transcendence Healing In Game: **{QptranscendenceHealingBest}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync("Make sure you have played Quickplay with this hero, otherwise check your command.\n**w!owhsqp <hero> <Your Battle.net username and id> <platform (pc/xbl/psn)> <region> Ex: w!owhsqp dVa Phytal-1427 pc us**");
            }
        }

        [Command("owherostatscomp")]
        [Summary("Get a Overwatch user's statistics for a specific hero on Competitive.")]
        [Alias("owhsc")]
        [Remarks("w!owherostatscomp <hero> <Your Battle.net username and id> <platform (pc/xbl/psn)> <region (us/eu etc.)> Ex: w!owherostatscomp dVa Phytal-1427 pc us")]
        [Cooldown(10)]
        public async Task GetOwHeroStatsComp(string hero, string username, string platform, string region)
        {
            try
            {
                string originalhero = hero;
                var config = GlobalUserAccounts.GetUserAccount(Context.User);
                hero = hero.ToLower();
                hero = GetHero(hero);

                var json = await Global.SendWebRequest($"https://ow-api.com/v1/stats/{platform}/{region}/{username}/heroes/{hero}");

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string endorsementIcon = dataObject.endorsementIcon.ToString();
                string playerIcon = dataObject.icon.ToString();
                string srIcon = dataObject.ratingIcon.ToString();
                //avg
                string CompAllDamageAvg = dataObject.competitiveStats.careerStats[hero].average.allDamageDoneAvgPer10Min.ToString();
                string CompBarrierDamageAvg = dataObject.competitiveStats.careerStats[hero].average.barrierDamageDoneAvgPer10Min.ToString();
                string CompCriticalsAvg = dataObject.competitiveStats.careerStats[hero].average.criticalHitsAvgPer10Min.ToString();
                string CompDeathAvg = dataObject.competitiveStats.careerStats[hero].average.deathsAvgPer10Min.ToString();
                string CompElimAvg = dataObject.competitiveStats.careerStats[hero].average.eliminationsAvgPer10Min.ToString();
                string CompElimPerLife = dataObject.competitiveStats.careerStats[hero].average.eliminationsPerLife.ToString();
                string CompFinalBlowAvg = dataObject.competitiveStats.careerStats[hero].average.finalBlowsAvgPer10Min.ToString();
                string CompHeroDamageAvg = dataObject.competitiveStats.careerStats[hero].average.heroDamageDoneAvgPer10Min.ToString();
                string CompMeleeAvg = dataObject.competitiveStats.careerStats[hero].average.meleeFinalBlowsAvgPer10Min.ToString();
                string CompObjKillsAvg = dataObject.competitiveStats.careerStats[hero].average.objectiveKillsAvgPer10Min.ToString();
                string CompObjTimeAvg = dataObject.competitiveStats.careerStats[hero].average.objectiveTimeAvgPer10Min.ToString();
                string CompSoloKillAvg = dataObject.competitiveStats.careerStats[hero].average.soloKillsAvgPer10Min.ToString();
                string CompOnFireAvg = dataObject.competitiveStats.careerStats[hero].average.timeSpentOnFireAvgPer10Min.ToString();
                //best
                string CompAllDamageInGame = dataObject.competitiveStats.careerStats[hero].best.allDamageDoneMostInGame.ToString();
                string CompAllDamageInLife = dataObject.competitiveStats.careerStats[hero].best.allDamageDoneMostInLife.ToString();
                string CompBarrierDamageInGame = dataObject.competitiveStats.careerStats[hero].best.barrierDamageDoneMostInGame.ToString();
                string CompCritMostInGame = dataObject.competitiveStats.careerStats[hero].best.criticalHitsMostInGame.ToString();
                string CompCritMostInLife = dataObject.competitiveStats.careerStats[hero].best.criticalHitsMostInLife.ToString();
                string CompElimMostInLife = dataObject.competitiveStats.careerStats[hero].best.eliminationsMostInLife.ToString();
                string CompElimMostInGame = dataObject.competitiveStats.careerStats[hero].best.eliminationsMostInGame.ToString();
                string CompFinalBlowMostInGame = dataObject.competitiveStats.careerStats[hero].best.finalBlowsMostInGame.ToString();
                string CompHeroDmgMostInGame = dataObject.competitiveStats.careerStats[hero].best.heroDamageDoneMostInGame.ToString();
                string CompHeroDmgMostInLife = dataObject.competitiveStats.careerStats[hero].best.heroDamageDoneMostInLife.ToString();
                string CompKillStreakBest = dataObject.competitiveStats.careerStats[hero].best.killsStreakBest.ToString();
                string CompMeleeFinalBlowMostInGame = dataObject.competitiveStats.careerStats[hero].best.meleeFinalBlowsMostInGame.ToString();
                string CompMultikillBest = dataObject.competitiveStats.careerStats[hero].best.multikillsBest.ToString();
                string CompObjKillMostInGame = dataObject.competitiveStats.careerStats[hero].best.objectiveKillsMostInGame.ToString();
                string CompObjTimeMostInGame = dataObject.competitiveStats.careerStats[hero].best.objectiveTimeMostInGame.ToString();
                string CompSoloKillsMostInGame = dataObject.competitiveStats.careerStats[hero].best.soloKillsMostInGame.ToString();
                string CompOnFireMostInGame = dataObject.competitiveStats.careerStats[hero].best.timeSpentOnFireMostInGame.ToString();
                string CompWeaponAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].best.weaponAccuracyBestInGame.ToString();
                //combat
                string CompBarrierDmgDone = dataObject.competitiveStats.careerStats[hero].combat.barrierDamageDone.ToString();
                string CompCriticalHits = dataObject.competitiveStats.careerStats[hero].combat.criticalHits.ToString();
                string CompCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].combat.criticalHitsAccuracy.ToString();
                string CompDamageDone = dataObject.competitiveStats.careerStats[hero].combat.damageDone.ToString();
                string CompDeaths = dataObject.competitiveStats.careerStats[hero].combat.deaths.ToString();
                string CompElims = dataObject.competitiveStats.careerStats[hero].combat.eliminations.ToString();
 
                string CompFinalBlows = dataObject.competitiveStats.careerStats[hero].combat.finalBlows.ToString();
                string CompHeroDmg = dataObject.competitiveStats.careerStats[hero].combat.heroDamageDone.ToString();
                string CompMeleeFinalBlows = dataObject.competitiveStats.careerStats[hero].combat.meleeFinalBlows.ToString();
                string CompMultikills = dataObject.competitiveStats.careerStats[hero].combat.multikills.ToString();
                string CompObjKills = dataObject.competitiveStats.careerStats[hero].combat.objectiveKills.ToString();
                string CompObjTime = dataObject.competitiveStats.careerStats[hero].combat.objectiveTime.ToString();
                string CompMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].combat.quickMeleeAccuracy.ToString();
                string CompSoloKills = dataObject.competitiveStats.careerStats[hero].combat.soloKills.ToString();
                string CompOnFire = dataObject.competitiveStats.careerStats[hero].combat.timeSpentOnFire.ToString();
                string CompWeaponAccuracy = dataObject.competitiveStats.careerStats[hero].combat.weaponAccuracy.ToString();
                //misc stuff
                string CompGamesPlayed = dataObject.competitiveStats.careerStats[hero].game.gamesPlayed.ToString();
                string CompGamesWon = dataObject.competitiveStats.careerStats[hero].game.gamesWon.ToString();
                string CompGamesTied = dataObject.competitiveStats.careerStats[hero].game.gamesTied.ToString();
                string CompGamesLost = dataObject.competitiveStats.careerStats[hero].game.gamesLost.ToString();
                string CompTimePlayed = dataObject.competitiveStats.careerStats[hero].game.timePlayed.ToString();
                string CompWinPercentage = dataObject.competitiveStats.careerStats[hero].game.winPercentage.ToString();
                string CompCards = dataObject.competitiveStats.careerStats[hero].matchAwards.cards.ToString();
                string CompMedals = dataObject.competitiveStats.careerStats[hero].matchAwards.medals.ToString();
                string CompMedalsBronze = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsBronze.ToString();
                string CompMedalsGold = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsGold.ToString();
                string CompMedalsSilver = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsSilver.ToString();
                string CompElimsPerLife = dataObject.competitiveStats.topHeroes[hero].eliminationsPerLife.ToString();

                string compAvg = $"All Damage Done per 10 Minutes: **{CompAllDamageAvg}**\nBarrier Damage Done per 10 Minutes: **{CompBarrierDamageAvg}**\nHero Damage Done per 10 Minutes: **{CompHeroDamageAvg}**\nCritical Hits per 10 Minutes: **{CompCriticalsAvg}**\nDeaths per 10 Minutes: **{CompDeathAvg}**\nEliminations per 10 Minutes: **{CompElimAvg}**\nEliminations per Life: **{CompElimPerLife}**\nFinal Blows per 10 Minutes: **{CompFinalBlowAvg}**\nMelee Final Blows per 10 Minutes: **{CompMeleeAvg}**\nObjective Time per 10 Minutes: **{CompObjTimeAvg}**\nObjective Kills per 10 Minutes: **{CompObjKillsAvg}**\nSolo Kills per 10 Minutes: **{CompSoloKillAvg}**\nTime on Fire per 10 Minutes: **{CompOnFireAvg}**";
                string compBest = $"All Damage in Game: **{CompAllDamageInGame}**\nAll Damage in Life: **{CompAllDamageInLife}**\nBarrier Damage in Game: **{CompBarrierDamageInGame}**\nCriticals in Game: **{CompCritMostInGame}**\nCriticals in Life: **{CompCritMostInLife}**\nEliminations in Game: **{CompElimMostInGame}**\nEliminations in Life: **{CompElimMostInLife}**\nFinal Blows in Game: **{CompFinalBlowMostInGame}**\nHero Damage in Game: **{CompHeroDmgMostInGame}**\nHero Damage in Life: **{CompHeroDmgMostInLife}**\nKill Streak: **{CompKillStreakBest}**\nMelee Final Blows in Game: **{CompMeleeFinalBlowMostInGame}**\nMultikill: **{CompMultikillBest}**\nObjective Kills in Game: **{CompObjKillMostInGame}**\nObjective Time in Game: **{CompObjTimeMostInGame}**\nSolo Kills in Game: **{CompSoloKillsMostInGame}**\nOn Fire Time in Game: **{CompOnFireMostInGame}**\nWeapon Accuracy in Game: **{CompWeaponAccuracyBestInGame}**";
                string compTotal = $"Barrier Damage Done: **{CompBarrierDmgDone}**\nCritical Hits: **{CompCriticalHits}**\nObjective Time in Game: **{CompObjTimeMostInGame}**\nCritical Hit Accuracy: **{CompCriticalHitsAccuracy}**\nDamage Done: **{CompDamageDone}**\nDeaths: **{CompDeaths}**\nEliminations: **{CompElims}**\nFinal Blows: **{CompFinalBlows}**\nHero Damage: **{CompHeroDmg}**\nMelee Final Blows: **{CompMeleeFinalBlows}**\nMultikills: **{CompMultikills}**\nObjective Kills: **{CompObjKills}**\nObjective Time: **{CompObjTime}**\nMelee Accuracy: **{CompMeleeAccuracy}**\nSolo Kills: **{CompSoloKills}**\nOn Fire Time: **{CompOnFire}**\nWeapon Accuracy: **{CompWeaponAccuracy}**";
                string compMisc = $"Games Played: **{CompGamesPlayed}**\nGames Won: **{CompGamesWon}**\nGames Tied: **{CompGamesTied}**\nGames Lost: **{CompGamesLost}**\nTime Played: **{CompTimePlayed}**\nWin Percentage: **{CompWinPercentage}**\nCards: **{CompCards}**\nTotal Medals: **{CompMedals}**\nGold Medals: **{CompMedalsGold}**\nSilver Medals: **{CompMedalsSilver}**\nBronze Medals: **{CompMedalsBronze}**\nEliminations per Life: **{CompElimsPerLife}**\n";

                if (hero == "ana")
                {
                    string CompBioticKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticGrenadeKills.ToString();
                    string CompEnemiesSlept = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSlept.ToString();
                    string CompEnemiesSleptPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSleptAvgPer10Min.ToString();
                    string CompEnemiesSleptMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSleptMostInGame.ToString();
                    string CompNanoAssists = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssists.ToString();
                    string CompNanoAssistsPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssistsAvgPer10Min.ToString();
                    string CompMostNanoAssistsIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssistsMostInGame.ToString();
                    string CompNanosApplied = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsApplied.ToString();
                    string CompNanosAppliedPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsAppliedAvgPer10Min.ToString();
                    string CompNanoAppliedMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsAppliedMostInGame.ToString();
                    string CompScopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompScopedAccuracyBestIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompSecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompSelfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompSelfHealingPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompSelfHealingMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompUnscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.unscopedAccuracy.ToString();
                    string CompUnscopedAccuracyBestIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.unscopedAccuracyBestInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Biotic Grenade Kills: **{CompBioticKills}**\nEnemies Slept: **{CompEnemiesSlept}**\nAverage Enemies Slept per 10 Minutes: **{CompEnemiesSleptPer10Min}**\nMost Enemies Slept In Game: **{CompEnemiesSleptPer10Min}**\nNano Boost Assists: **{CompNanoAssists}**\nNano Boost Assists Per 10 Minutes: **{CompNanosAppliedPer10Min}**\nMost Nano Boost Assists In Game: **{CompMostNanoAssistsIG}**\nNano Boosts Applied: **{CompNanosApplied}**\nNano Boosts Applied Per 10 Minutes: **{CompNanosAppliedPer10Min}**\nNano Boosts Applied Most In Game: **{CompNanoAppliedMostIG}**\nScoped Accuracy: **{CompScopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompScopedAccuracyBestIG}**\nSecondary Fire Accuracy: **{CompSecondaryFireAccuracy}**\nSelf Healing: **{CompSelfHealing}**\nSelf Healing Per 10 Minutes: **{CompSelfHealingPer10Min}**\nMost Self Healing In Game: **{CompSelfHealingMostIG}**\nUnscoped Accuracy: **{CompUnscopedAccuracy}**\nBest Unscoped Accuracy In Game: **{CompScopedAccuracyBestIG}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "ashe")
                {
                    string CompbobKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKills.ToString();
                    string CompbobKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKillsAvgPer10Min.ToString();
                    string CompbobKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKillsMostInGame.ToString();
                    string CompcoachGunKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKills.ToString();
                    string CompcoachGunKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKillsAvgPer10Min.ToString();
                    string CompcoachGunKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKillsMostInGame.ToString();
                    string CompdynamiteKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKills.ToString();
                    string CompdynamiteKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKillsAvgPer10Min.ToString();
                    string CompdynamiteKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKillsMostInGame.ToString();
                    string CompscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompscopedAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompscopedCriticalHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string CompscopedCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string CompscopedCriticalHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string CompscopedCriticalHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"BOB Kills: **{CompbobKills}**\nAverage BOB Kills Per 10 Minutes: **{CompbobKillsAvgPer10Min}**\nMost BOB Kills In Game: **{CompbobKillsMostInGame}**\nCoach Gun Kills: **{CompcoachGunKills}**\nAverage Coach Gun Kills Per 10 Minutes: **{CompcoachGunKillsAvgPer10Min}**\nMost Coach Gun Kills In Game: **{CompcoachGunKillsMostInGame}**\nDynamite Kills: **{CompdynamiteKills}**\nAverage Dynamite Kills Per 10 Minutes: **{CompdynamiteKillsAvgPer10Min}**\nMost Dynamite Kills In Game Kills: **{CompdynamiteKillsMostInGame}**\nScoped Accuracy: **{CompscopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompscopedAccuracyBestInGame}**\nScoped Creitical Hits: **{CompscopedCriticalHits}**\nScoped Critical Hits Accuracy: **{CompscopedCriticalHitsAccuracy}**\nAverage Scoped Critical Hits Per 10 Minutes: **{CompscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{CompscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "bastion")
                {
                    string CompreconKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKills.ToString();
                    string CompreconKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKillsAvgPer10Min.ToString();
                    string CompreconKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].selfHealingAvgPer10Min.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompsentryKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKills.ToString();
                    string CompsentryKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKillsAvgPer10Min.ToString();
                    string CompsentryKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKillsMostInGame.ToString();
                    string ComptankKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKills.ToString();
                    string ComptankKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKillsAvgPer10Min.ToString();
                    string ComptankKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKillsMostInGame.ToString();

                    string heroSpecific = $"Recon Kills: **{CompreconKills}**\nAverage Recon Kills Per 10 Minutes: **{CompreconKillsAvgPer10Min}**\nMost Recon Kills In Game: **{CompreconKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nSentry Kills: **{CompsentryKills}**\nAverage Sentry Kills Per 10 Minutes: **{CompsentryKillsAvgPer10Min}**\nMost Sentry Kills In Game: **{CompsentryKillsMostInGame}**\nTank Kills: **{ComptankKills}**\nAverage Tank Kills Per 10 Minutes: **{CompreconKills}**\nMost Tank Kills In Game: **{ComptankKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "brigitte")
                {
                    string ComparmorProvided = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvided.ToString();
                    string ComparmorProvidedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvidedAvgPer10Min.ToString();
                    string ComparmorProvidedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvidedMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompinspireUptimePercentage = dataObject.competitiveStats.careerStats[hero].heroSpecific.inspireUptimePercentage.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Armor Provided: **{ComparmorProvided}**\nAverage Armor Provided Per 10 Minutes: **{ComparmorProvidedAvgPer10Min}**\nMost Armor Provided In Game: **{ComparmorProvidedMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nInspire Uptime Percentage: **{CompinspireUptimePercentage}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "dVa")
                {
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompmechDeaths = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechDeaths.ToString();
                    string CompmechsCalled = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalled.ToString();
                    string CompmechsCalledAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalledAvgPer10Min.ToString();
                    string CompmechsCalledMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalledMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfDestructKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKills.ToString();
                    string CompselfDestructKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKillsAvgPer10Min.ToString();
                    string CompselfDestructKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKillsMostInGame.ToString();

                   string heroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nMech Deaths: **{CompmechDeaths}**\nMechs Called: **{CompmechsCalled}**\nAverage Mechs Called Per 10 Minutes: **{CompmechsCalledAvgPer10Min}**\nMost Mechs Called In Game: **{CompmechsCalledMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Destruct Kills: **{CompselfDestructKills}**\nAverage Self Destruct Kills Per 10 Minutes: **{CompselfDestructKillsAvgPer10Min}**\nMost Self Destruct Kills In Game: **{CompselfDestructKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "doomfist")
                {
                    string CompabilityDamageDone = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.barrierDamageDone.ToString();
                    string CompabilityDamageDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.abilityDamageDoneAvgPer10Min.ToString();
                    string CompabilityDamageDoneMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.abilityDamageDoneMostInGame.ToString();
                    string CompmeteorStrikeKills = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKills.ToString();
                    string CompmeteorStrikeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsAvgPer10Min.ToString();
                    string CompmeteorStrikeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.secondaryFireAccuracy.ToString();
                    string CompshieldsCreated = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreated.ToString();
                    string CompshieldsCreatedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreatedAvgPer10Min.ToString();
                    string CompshieldsCreatedMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreatedMostInGame.ToString();

                    string heroSpecific = $"Ability Damage Done: **{CompabilityDamageDone}**\nAverage Ability Damage Done Per 10 Minutes: **{CompabilityDamageDoneAvgPer10Min}**\nMost Ability Damage Done In Game: **{CompabilityDamageDoneMostInGame}**\nMeteor Strike Kills: **{CompmeteorStrikeKills}**\nAverage Meteor Strike Kills Per 10 Minutes: **{CompmeteorStrikeKillsAvgPer10Min}**\nMost Meteor Strike Kills In Game: **{CompmeteorStrikeKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nShields Created: **{CompshieldsCreated}**\nAverage Shields Created Per 10 Minutes: **{CompshieldsCreatedAvgPer10Min}**\nMost Shields Created In Game: **{CompshieldsCreatedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "genji")
                {
                    string CompdamageReflected = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflected.ToString();
                    string CompdamageReflectedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflectedAvgPer10Min.ToString();
                    string CompdamageReflectedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflectedMostInGame.ToString();
                    string CompdeflectionKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deflectionKills.ToString();
                    string CompdragonbladesKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKills.ToString();
                    string CompdragonbladesKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKillsAvgPer10Min.ToString();
                    string CompdragonbladesKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Damage Deflected: **{CompdamageReflected}**\nAverage Damage Deflected Per 10 Minutes: **{CompdamageReflectedMostInGame}**\nMost Damage Deflected In Game: **{CompdamageReflectedMostInGame}**\nDeflection Kills: **{CompdeflectionKills}**\nDragonblade Kills: **{CompdragonbladesKills}**\nAverage Dragonblade Kills Per 10 Minutes: **{CompdragonbladesKillsAvgPer10Min}**\nMost Dragonblade Kills In Game: **{CompdragonbladesKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "hanzo")
                {
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompstormArrowKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKills.ToString();
                    string CompstormArrowKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKillsAvgPer10Min.ToString();
                    string CompstormArrowKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKillsMostInGame.ToString();

                    string heroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nStorm Arrow Kills: **{CompstormArrowKills}**\nAverage Storm Arrow Kills Per 10 Minutes: **{CompstormArrowKillsAvgPer10Min}**\nMost Storm Arrow Kills In Game: **{CompstormArrowKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "junkrat")
                {
                    string CompconcussionMineKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKills.ToString();
                    string CompconcussionMineKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKillsAvgPer10Min.ToString();
                    string CompconcussionMineKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKillsMostInGame.ToString();
                    string CompenemiesTrapped = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrapped.ToString();
                    string CompenemiesTrappedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrappedAvgPer10Min.ToString();
                    string CompenemiesTrappedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrappedMostInGame.ToString();
                    string CompripTireKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKills.ToString();
                    string CompripTireKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKillsAvgPer10Min.ToString();
                    string CompripTireKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Concussion Mine Kills: **{CompconcussionMineKills}**\nAverage Concussion Mine Kills Per 10 Minutes: **{CompconcussionMineKillsAvgPer10Min}**\nMost Concussion Mine Kills in Game: **{CompconcussionMineKillsMostInGame}**\nEnemies Trapped: **{CompenemiesTrapped}**\nAverage Enemies Trapped Per 10 Minutes: **{CompenemiesTrappedAvgPer10Min}**\nMost Enemies Trapped In Game: **{CompenemiesTrappedMostInGame}**\nRip Tire Kills: **{CompripTireKills}**\nAverage Rip Tire Kills Per 10 Minutes: **{CompripTireKillsAvgPer10Min}**\nMost Rip Tire Kills In Game: **{CompripTireKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "lucio")
                {
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompsoundBarriersProvided = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvided.ToString();
                    string CompsoundBarriersProvidedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvidedAvgPer10Min.ToString();
                    string CompsoundBarriersProvidedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvidedMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\n:Most Self Healing In Game **{CompselfHealingMostInGame}**\nSound Barriers Provided: **{CompsoundBarriersProvided}**\nAverage Sound Barriers Provided Per 10 minutes: **{CompsoundBarriersProvidedAvgPer10Min}**\nMost Sound barriers Provided In Game: **{CompsoundBarriersProvidedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mccree")
                {
                    string CompdeadeyeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKills.ToString();
                    string CompdeadeyeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKillsAvgPer10Min.ToString();
                    string CompdeadeyeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKillsMostInGame.ToString();
                    string CompfanTheHammerKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKills.ToString();
                    string CompfanTheHammerKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKillsAvgPer10Min.ToString();
                    string CompfanTheHammerKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Deadeye Kills: **{CompdeadeyeKills}**\nAverage Deadeye Kills Per 10 Minutes: **{CompdeadeyeKillsAvgPer10Min}**\nMost Deadeye Kills In Game: **{CompdeadeyeKillsMostInGame}**\nFan The Hammer Kills: **{CompfanTheHammerKills}**\nAverage Fan The Hammer Kills Per 10 Minutes: **{CompfanTheHammerKillsAvgPer10Min}**\nMost Fan The Hammer Kills In Game: **{CompfanTheHammerKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mei")
                {

                    string CompblizzardKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKills.ToString();
                    string CompblizzardKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKillsAvgPer10Min.ToString();
                    string CompblizzardKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKillsMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompenemiesFrozen = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozen.ToString();
                    string CompenemiesFrozenAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozenAvgPer10Min.ToString();
                    string CompenemiesFrozenMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozenMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Blizzard Kills: **{CompblizzardKills}**\nAverage Blizzard Kills Per 10 Minutes: **{CompblizzardKillsAvgPer10Min}**\nMost Blizzard Kills In Game: **{CompblizzardKillsMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nEnemies Frozen: **{CompenemiesFrozen}**\nAverage Enemies Frozen: **{CompenemiesFrozenAvgPer10Min}**\nMost Enemies Frozen In Game: **{CompenemiesFrozenMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mercy")
                {
                    string CompblasterKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKills.ToString();
                    string CompblasterKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKillsAvgPer10Min.ToString();
                    string CompblasterKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKillsMostInGame.ToString();
                    string CompdamageAmplified = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string CompdamageAmplifiedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string CompdamageAmplifiedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string CompplayersResurrected = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrected.ToString();
                    string CompplayersResurrectedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrectedAvgPer10Min.ToString();
                    string CompplayersResurrectedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrectedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Blaster Kills: **{CompblasterKills}**\nAverage Blaster Kills Per 10 Minutes: **{CompblasterKillsAvgPer10Min}**\nMost Blaster Kills In Game: **{CompblasterKillsMostInGame}**\nDamage Amplified: **{CompdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{CompdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{CompdamageAmplifiedMostInGame}**\nPlayers Resurrected: **{CompplayersResurrected}**\nAverage Players Resurrected Per 10 Minutes: **{CompplayersResurrectedAvgPer10Min}**\nMost Players Ressurected In Game: **{CompplayersResurrectedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "moira")
                {
                    string CompcoalescenceHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealing.ToString();
                    string CompcoalescenceHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealingAvgPer10Min.ToString();
                    string CompcoalescenceHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealingMostInGame.ToString();
                    string CompcoalescenceKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKills.ToString();
                    string CompcoalescenceKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKillsAvgPer10Min.ToString();
                    string CompcoalescenceKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                     string heroSpecific = $"Coalescence Healing: **{CompcoalescenceHealing}**\nAverage Coalescence Healing Per 10 Minutes: **{CompcoalescenceHealingAvgPer10Min}**\nMost Coalescence Healing In Game: **{CompcoalescenceHealingMostInGame}**\nCoalescence Kills: **{CompcoalescenceKills}**\nAverage Coalescence Kills Per 10 Minutes: **{CompcoalescenceKillsAvgPer10Min}**\nMost Coalescence Kills In Game: **{CompcoalescenceKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "orisa")
                {
                    string CompdamageAmplified = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string CompdamageAmplifiedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string CompdamageAmplifiedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompsuperchargerAssists = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssists.ToString();
                    string CompsuperchargerAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssistsAvgPer10Min.ToString();
                    string CompsuperchargerAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssistsMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Damage Amplified: **{CompdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{CompdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{CompdamageAmplifiedMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSupercharger Assists: **{CompsuperchargerAssists}**\nAverage Supercharger Assists Per 10 Minutes: **{CompsuperchargerAssistsAvgPer10Min}**\nMost Supercharger Assists In Game: **{CompsuperchargerAssistsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "pharah")
                {
                    string CompbarrageKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKills.ToString();
                    string CompbarrageKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKillsAvgPer10Min.ToString();
                    string CompbarrageKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKillsMostInGame.ToString();
                    string CompdirectHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.directHitsAccuracy.ToString();
                    string ComprocketDirectHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHits.ToString();
                    string ComprocketDirectHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHitsAvgPer10Min.ToString();
                    string ComprocketDirectHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Barrage Kills: **{CompbarrageKills}**\nAverage Barrage Kills Per 10 Minutes: **{CompbarrageKillsAvgPer10Min}**\nMost Barrage Kills In Game: **{CompbarrageKillsMostInGame}**\nDirect Hits Accuracy: **{CompdirectHitsAccuracy}**\nRocket Dirrect Hits: **{ComprocketDirectHits}**\nAverage Rocket Direct Hits Per 10 Minutes: **{ComprocketDirectHitsAvgPer10Min}**\nMost Rocket Direct Hits In Game: **{ComprocketDirectHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reaper")
                {
                    string CompdeathsBlossomKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKills.ToString();
                    string CompdeathsBlossomKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKillsAvgPer10Min.ToString();
                    string CompdeathsBlossomKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string heroSpecific = $"Death Blossom Kills: **{CompdeathsBlossomKills}**\nAverage Death Blossom Kills Per 10 Minutes: **{CompdeathsBlossomKillsAvgPer10Min}**\nMost Death Blossom Kills In Game: **{CompdeathsBlossomKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reinhardt")
                {
                    string CompchargeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKills.ToString();
                    string CompchargeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKillsAvgPer10Min.ToString();
                    string CompchargeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKillsMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompearthshatterKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKills.ToString();
                    string CompearthshatterKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKillsAvgPer10Min.ToString();
                    string CompearthshatterKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKillsMostInGame.ToString();
                    string CompfireStrikeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKills.ToString();
                    string CompfireStrikeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKillsAvgPer10Min.ToString();
                    string CompfireStrikeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKillsMostInGame.ToString();
                    string ComprocketHammerMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketHammerMeleeAccuracy.ToString();

                    string heroSpecific = $"Charge Kills: **{CompchargeKills}**\nAverage Charge Kills Per 10 Minutes: **{CompchargeKillsAvgPer10Min}**\nMost Charge Kills In Game: **{CompchargeKillsMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nEarthshatter Kills: **{CompearthshatterKills}**\nAverage Earthshatter Kills Per 10 Minutes: **{CompearthshatterKillsAvgPer10Min}**\nMost Earthshatter Kills In Game: **{CompearthshatterKillsMostInGame}**\nFire Strike Kills: **{CompfireStrikeKills}**\nFire Strike Kills: **{CompfireStrikeKills}**\nAverage Fire Strike Kills Per 10 Minutes: **{CompfireStrikeKillsAvgPer10Min}**\nMost Fire Strike Kills In Game: **{CompfireStrikeKillsMostInGame}**\nRocket Hammer Melee Accuracy: **{ComprocketHammerMeleeAccuracy}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "roadhog")
                {
                    string CompenemiesHooked = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHooked.ToString();
                    string CompenemiesHookedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHookedAvgPer10Min.ToString();
                    string CompenemiesHookedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHookedMostInGame.ToString();
                    string ComphookAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.hookAccuracy.ToString();
                    string ComphookAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.hookAccuracyBestInGame.ToString();
                    string ComphooksAttempted = dataObject.competitiveStats.careerStats[hero].heroSpecific.hooksAttempted.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompwholeHogKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKills.ToString();
                    string CompwholeHogKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKillsAvgPer10Min.ToString();
                    string CompwholeHogKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKillsMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Enemies Hooked: **{CompenemiesHooked}**\nAverage Enemies Hooked Per 10 Minutes: **{CompenemiesHookedAvgPer10Min}**\nMost Enemies Hooked In Game: **{CompenemiesHookedMostInGame}**\nHook Accuracy: **{ComphookAccuracy}**\nBest Hook Accuracy In Game: **{ComphookAccuracyBestInGame}**\nHooks Attempted: **{ComphooksAttempted}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nWhole Hog Kills: **{CompwholeHogKills}**\nAverage Whole Hog Kills Per 10 Minutes: **{CompwholeHogKillsAvgPer10Min}**\nMost Whole Hog Kills In Game: **{CompwholeHogKillsMostInGame}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "soldier76")
                {
                    string CompbioticFieldHealingDone = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticFieldHealingDone.ToString();
                    string CompbioticFieldsDeployed = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticFieldsDeployed.ToString();
                    string ComphelixRocketKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketKillsMostInGame.ToString();
                    string ComphelixRocketsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketsKills.ToString();
                    string ComphelixRocketsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketsKillsAvgPer10Min.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{CompselfHealing}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**";
                    string heroSpecific = $"Biotic Field Healing Done: **{CompbioticFieldHealingDone}**\nBiotic Fields Deployed: **{CompbioticFieldsDeployed}**\nHelix Rocket Kills: **{ComphelixRocketsKills}**\nAverage Helix Rocket Kills Per 10 Minutes: **{ComphelixRocketsKillsAvgPer10Min}**\nMost Helix Rocket Kills In Game: **{ComphelixRocketKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "sombra")
                {
                    string CompenemiesEmpd = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpd.ToString();
                    string CompenemiesEmpdAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpdAvgPer10Min.ToString();
                    string CompenemiesEmpdMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpdMostInGame.ToString();
                    string CompenemiesHacked = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHacked.ToString();
                    string CompenemiesHackedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHackedAvgPer10Min.ToString();
                    string CompenemiesHackedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHackedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Enemies EMP'd: **{CompenemiesEmpd}**\nAverage EMP'd Per 10 Minutes: **{CompenemiesEmpdAvgPer10Min}**\nMost Enemies EMP'd In Game: **{CompenemiesEmpdMostInGame}**\nEnemies Hacked: **{CompenemiesHacked}**\nAverage Enemies Hacked Per 10 Minutes: **{CompenemiesHackedAvgPer10Min}**\nMost Enemies Hacked In Game: **{CompenemiesHackedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "symmetra")
                {
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompplayersTeleported = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleported.ToString();
                    string CompplayersTeleportedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleportedAvgPer10Min.ToString();
                    string CompplayersTeleportedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleportedMostInGame.ToString();
                    string CompprimaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string CompsecondaryDirectHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryDirectHitsAvgPer10Min.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompsentryTurretsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKills.ToString();
                    string CompsentryTurretsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKillsAvgPer10Min.ToString();
                    string CompsentryTurretsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKillsMostInGame.ToString();

                    string heroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nPlayers Teleported: **{CompplayersTeleported}**\nAverage Players Teleported Per 10 Minutes: **{CompplayersTeleportedAvgPer10Min}**\nMost Players Teleported In Game: **{CompplayersTeleportedMostInGame}**\nPrimary Fire Accuracy: **{CompprimaryFireAccuracy}**\nSecondary Fire Direct Hits Per 10 Minutes: **{CompsecondaryDirectHitsAvgPer10Min}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSentry Turret Kills: **{CompsentryTurretsKills}**\nAverage Sentry Turret Kills Per 10 Minutes: **{CompsentryTurretsKillsAvgPer10Min}**\nMost Sentry Turret Kills In Game: **{CompsentryTurretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "torbjorn")
                {
                    string CompmoltenCoreKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKills.ToString();
                    string CompmoltenCoreKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKillsAvgPer10Min.ToString();
                    string CompmoltenCoreKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKillsMostInGame.ToString();
                    string CompoverloadKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.overloadKills.ToString();
                    string CompoverloadKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.overloadKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string ComptorbjornKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKills.ToString();
                    string ComptorbjornKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKillsAvgPer10Min.ToString();
                    string ComptorbjornKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKillsMostInGame.ToString();
                    string CompturretsDamageAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsDamageAvgPer10Min.ToString();
                    string CompturretsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKills.ToString();
                    string CompturretsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKillsAvgPer10Min.ToString();
                    string CompturretsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKillsMostInGame.ToString();

                    string heroSpecific = $"Molten Core Kills: **{CompmoltenCoreKills}**\nAverage Molten Core Kills Per 10 Minutes: **{CompmoltenCoreKillsAvgPer10Min}**\nMost Molten Core Kills In Game: **{CompmoltenCoreKillsMostInGame}**\nOverload Kills: **{CompoverloadKills}**\nMost Overload Kills In Game: **{CompoverloadKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nTorbjorn Kills: **{ComptorbjornKills}**\nAverage Torbjorn Kills Per 10 Minutes: **{ComptorbjornKillsAvgPer10Min}**\nMost Torbjorn Kills In Game: **{ComptorbjornKillsMostInGame}**\nAverage Turret Damage Per 10 Minutes: **{CompturretsDamageAvgPer10Min}**\nTurret Kills: **{CompturretsKills}**\nAverage Turret Kills Per 10 Minutes: **{CompturretsKillsAvgPer10Min}**\nMost Turret Kills In Game: **{CompturretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "tracer")
                {
                    string ComphealthRecovered = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecovered.ToString();
                    string ComphealthRecoveredAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecoveredAvgPer10Min.ToString();
                    string ComphealthRecoveredMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecoveredMostInGame.ToString();
                    string ComppulseBombsAttached = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttached.ToString();
                    string ComppulseBombsAttachedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttachedAvgPer10Min.ToString();
                    string ComppulseBombsAttachedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttachedMostInGame.ToString();
                    string ComppulseBombsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKills.ToString();
                    string ComppulseBombsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKillsAvgPer10Min.ToString();
                    string ComppulseBombsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Health Recalled: **{ComphealthRecovered}**\nAverage Health Recalled Per 10 Minutes: **{ComphealthRecoveredAvgPer10Min}**\nMost Health Recalled In Game: **{ComphealthRecoveredMostInGame}**\nPulse Bomb Attached: **{ComppulseBombsAttached}**\nAverage Pulse Bombs Attached Per 10 Minutes: **{ComppulseBombsAttachedAvgPer10Min}**\nMost Pulse Bombs Attached In Game: **{ComppulseBombsAttachedMostInGame}**\nPulse Bomb Kills: **{ComppulseBombsKills}**\nAverage Pulse Bomb Kills Per 10 Minutes: **{ComppulseBombsKillsAvgPer10Min}**\nMost Pulse Bomb Kills In Game: **{ComppulseBombsKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "widowmaker")
                {
                    string CompscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompscopedAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompscopedCriticalHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string CompscopedCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string CompscopedCriticalHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string CompscopedCriticalHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompvenomMineKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKills.ToString();
                    string CompvenomMineKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKillsAvgPer10Min.ToString();
                    string CompvenomMineKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKillsMostInGame.ToString();

                    //recon assists
                    string CompreconAssists = dataObject.competitiveStats.careerStats[hero].assists.reconAssists.ToString();
                    string CompreconAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.reconAssistsAvgPer10Min.ToString();
                    string CompreconAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.reconAssistsMostInGame.ToString();

                    string assists = $"Recon Assists: **{CompreconAssists}**\nAverage Recon Assists Per 10 Minutes: **{CompreconAssistsAvgPer10Min}**\nMost Recon Assists In Game: **{CompreconAssistsMostInGame}**";
                    string heroSpecific = $"Scoped Accuracy: **{CompscopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompscopedAccuracyBestInGame}**\nScoped Critical Hits Accuracy: **{CompscopedCriticalHitsAccuracy}**\nScoped Critical Hits: **{CompscopedCriticalHits}**\nAverage Scoped Critical Hits Per 10 Minutes: **{CompscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{CompscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nVenom Mine Kills: **{CompvenomMineKills}**\nAverage Venom Mine Kills Per 10 Minutes: **{CompvenomMineKillsAvgPer10Min}**\nMost Venom Mine Kills In Game: **{CompvenomMineKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "winston")
                {
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompjumpPackKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKills.ToString();
                    string CompjumpPackKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKillsAvgPer10Min.ToString();
                    string CompjumpPackKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKillsMostInGame.ToString();
                    string CompmeleeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKills.ToString();
                    string CompmeleeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKillsAvgPer10Min.ToString();
                    string CompmeleeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKillsMostInGame.ToString();
                    string CompplayersKnockedBack = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string CompplayersKnockedBackAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string CompplayersKnockedBackMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string CompprimalRageKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKills.ToString();
                    string CompprimalRageKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKillsAvgPer10Min.ToString();
                    string CompprimalRageKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKillsMostInGame.ToString();
                    string CompprimalRageMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompteslaCannonAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.teslaCannonAccuracy.ToString();
                    string CompweaponKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.weaponKills.ToString();

                    string heroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nJump Pack Kills: **{CompjumpPackKills}**\nAverage Jump Pack Kills Per 10 Minutes: **{CompjumpPackKillsAvgPer10Min}**\nMost Jump Pack Kills In Game: **{CompjumpPackKillsMostInGame}**\nMelee Kills: **{CompmeleeKills}**\nAverage Melee Kills Per 10 Minutes: **{CompmeleeKillsAvgPer10Min}**\nMost Melee Kills In Game: **{CompmeleeKillsMostInGame}**\nPlayers Knocked Back: **{CompplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{CompplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{CompplayersKnockedBackMostInGame}**\nPrimal Rage Kills: **{CompprimalRageKills}**\nAverage Primal Rage Kills In 10 Minutes: **{CompprimalRageKillsAvgPer10Min}**\nMost Primal Rage Kills In Game: **{CompprimalRageKillsMostInGame}**\nPrimal Rage Melee Accuracy: **{CompprimalRageMeleeAccuracy}**\nTesla Cannon Accuracy: **{CompteslaCannonAccuracy}**\nWeapon Kils: **{CompweaponKills}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "wreckingBall")
                {
                    string CompplayersKnockedBack = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string CompplayersKnockedBackAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string CompplayersKnockedBackMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                   string heroSpecific = $"Players Knocked Back: **{CompplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{CompplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{CompplayersKnockedBackMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zarya")
                {
                    string CompaverageEnergy = dataObject.competitiveStats.careerStats[hero].heroSpecific.averageEnergy.ToString();
                    string CompaverageEnergyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.averageEnergyBestInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompgravitonSurgeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKills.ToString();
                    string CompgravitonSurgeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKillsAvgPer10Min.ToString();
                    string CompgravitonSurgeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKillsMostInGame.ToString();
                    string ComphighEnergyKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKills.ToString();
                    string ComphighEnergyKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKillsAvgPer10Min.ToString();
                    string ComphighEnergyKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKillsMostInGame.ToString();
                    string CompprimaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string CompprojectedBarriersApplied = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersApplied.ToString();
                    string CompprojectedBarriersAppliedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersAppliedAvgPer10Min.ToString();
                    string CompprojectedBarriersAppliedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersAppliedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive and defensive assists
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Average Energy: **{CompaverageEnergy}**\nBest Average Energy In Game: **{CompaverageEnergyBestInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nGraviton Surge Kills: **{CompgravitonSurgeKills}**\nAverage Graviton Surge Kills Per 10 Minutes: **{CompgravitonSurgeKillsAvgPer10Min}**\nMost Graviton Surge Kills In Game: **{CompgravitonSurgeKillsMostInGame}**\nHigh Energy Kills: **{ComphighEnergyKills}**\nAverage High Energy Kills Per 10 Minutes: **{ComphighEnergyKillsAvgPer10Min}**\nMost High Energy Kills In Game: **{ComphighEnergyKillsMostInGame}**\nPrimary Fire Accuracy: **{CompprimaryFireAccuracy}**\nProjected Barriers Applied: **{CompprojectedBarriersApplied}**\nAverage Projected Barriers Provided Per 10 Minutes: **{CompprojectedBarriersAppliedAvgPer10Min}**\nMost Projected Barriers Provided In Game: **{CompprojectedBarriersAppliedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}*";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zenyatta")
                {
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string ComptranscendenceHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.transcendenceHealing.ToString();
                    string ComptranscendenceHealingBest = dataObject.competitiveStats.careerStats[hero].heroSpecific.transcendenceHealingBest.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nTranscendence Healing: **{ComptranscendenceHealing}**\nBest Transcendence Healing In Game: **{ComptranscendenceHealingBest}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{username}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync("Make sure you have played Competitive with this hero, otherwise check your command.\n**w!owhscomp <hero> <Your Battle.net username and id> <platform (pc/xbl/psn)> <region> Ex: w!owhscomp dVa Phytal-1427 pc us**");
            }
        }

        [Command("myowherostats")]
        [Summary("Get your statistics for a specific hero.")]
        [Alias("myowhs")]
        [Remarks("w!owherostats <hero> Ex: w!myowherostats dVa")]
        [Cooldown(10)]
        public async Task GetMyOwHeroStats(string hero)
        {
            try
            {
                string originalhero = hero;
                var config = GlobalUserAccounts.GetUserAccount(Context.User);
                hero = hero.ToLower();
                hero = GetHero(hero);

                var json = await Global.SendWebRequest($"https://ow-api.com/v1/stats/{config.OverwatchPlatform}/{config.OverwatchRegion}/{config.OverwatchID}/heroes/{hero}");

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string endorsementIcon = dataObject.endorsementIcon.ToString();
                string playerIcon = dataObject.icon.ToString();
                string srIcon = dataObject.ratingIcon.ToString();
                //compstats
                //avg
                string CompAllDamageAvg = dataObject.competitiveStats.careerStats[hero].average.allDamageDoneAvgPer10Min.ToString();
                string CompBarrierDamageAvg = dataObject.competitiveStats.careerStats[hero].average.barrierDamageDoneAvgPer10Min.ToString();
                string CompCriticalsAvg = dataObject.competitiveStats.careerStats[hero].average.criticalHitsAvgPer10Min.ToString();
                string CompDeathAvg = dataObject.competitiveStats.careerStats[hero].average.deathsAvgPer10Min.ToString();
                string CompElimAvg = dataObject.competitiveStats.careerStats[hero].average.eliminationsAvgPer10Min.ToString();
                string CompElimPerLife = dataObject.competitiveStats.careerStats[hero].average.eliminationsPerLife.ToString();
                string CompFinalBlowAvg = dataObject.competitiveStats.careerStats[hero].average.finalBlowsAvgPer10Min.ToString();
                string CompHeroDamageAvg = dataObject.competitiveStats.careerStats[hero].average.heroDamageDoneAvgPer10Min.ToString();
                string CompMeleeAvg = dataObject.competitiveStats.careerStats[hero].average.meleeFinalBlowsAvgPer10Min.ToString();
                string CompObjKillsAvg = dataObject.competitiveStats.careerStats[hero].average.objectiveKillsAvgPer10Min.ToString();
                string CompObjTimeAvg = dataObject.competitiveStats.careerStats[hero].average.objectiveTimeAvgPer10Min.ToString();
                string CompSoloKillAvg = dataObject.competitiveStats.careerStats[hero].average.soloKillsAvgPer10Min.ToString();
                string CompOnFireAvg = dataObject.competitiveStats.careerStats[hero].average.timeSpentOnFireAvgPer10Min.ToString();
                //best
                string CompAllDamageInGame = dataObject.competitiveStats.careerStats[hero].best.allDamageDoneMostInGame.ToString();
                string CompAllDamageInLife = dataObject.competitiveStats.careerStats[hero].best.allDamageDoneMostInLife.ToString();
                string CompBarrierDamageInGame = dataObject.competitiveStats.careerStats[hero].best.barrierDamageDoneMostInGame.ToString();
                string CompCritMostInGame = dataObject.competitiveStats.careerStats[hero].best.criticalHitsMostInGame.ToString();
                string CompCritMostInLife = dataObject.competitiveStats.careerStats[hero].best.criticalHitsMostInLife.ToString();
                string CompElimMostInLife = dataObject.competitiveStats.careerStats[hero].best.eliminationsMostInLife.ToString();
                string CompElimMostInGame = dataObject.competitiveStats.careerStats[hero].best.eliminationsMostInGame.ToString();
                string CompFinalBlowMostInGame = dataObject.competitiveStats.careerStats[hero].best.finalBlowsMostInGame.ToString();
                string CompHeroDmgMostInGame = dataObject.competitiveStats.careerStats[hero].best.heroDamageDoneMostInGame.ToString();
                string CompHeroDmgMostInLife = dataObject.competitiveStats.careerStats[hero].best.heroDamageDoneMostInLife.ToString();
                string CompKillStreakBest = dataObject.competitiveStats.careerStats[hero].best.killsStreakBest.ToString();
                string CompMeleeFinalBlowMostInGame = dataObject.competitiveStats.careerStats[hero].best.meleeFinalBlowsMostInGame.ToString();
                string CompMultikillBest = dataObject.competitiveStats.careerStats[hero].best.multikillsBest.ToString();
                string CompObjKillMostInGame = dataObject.competitiveStats.careerStats[hero].best.objectiveKillsMostInGame.ToString();
                string CompObjTimeMostInGame = dataObject.competitiveStats.careerStats[hero].best.objectiveTimeMostInGame.ToString();
                string CompSoloKillsMostInGame = dataObject.competitiveStats.careerStats[hero].best.soloKillsMostInGame.ToString();
                string CompOnFireMostInGame = dataObject.competitiveStats.careerStats[hero].best.timeSpentOnFireMostInGame.ToString();
                string CompWeaponAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].best.weaponAccuracyBestInGame.ToString();
                //combat
                string CompBarrierDmgDone = dataObject.competitiveStats.careerStats[hero].combat.barrierDamageDone.ToString();
                string CompCriticalHits = dataObject.competitiveStats.careerStats[hero].combat.criticalHits.ToString();
                string CompCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].combat.criticalHitsAccuracy.ToString();
                string CompDamageDone = dataObject.competitiveStats.careerStats[hero].combat.damageDone.ToString();
                string CompDeaths = dataObject.competitiveStats.careerStats[hero].combat.deaths.ToString();
                string CompElims = dataObject.competitiveStats.careerStats[hero].combat.eliminations.ToString();
 
                string CompFinalBlows = dataObject.competitiveStats.careerStats[hero].combat.finalBlows.ToString();
                string CompHeroDmg = dataObject.competitiveStats.careerStats[hero].combat.heroDamageDone.ToString();
                string CompMeleeFinalBlows = dataObject.competitiveStats.careerStats[hero].combat.meleeFinalBlows.ToString();
                string CompMultikills = dataObject.competitiveStats.careerStats[hero].combat.multikills.ToString();
                string CompObjKills = dataObject.competitiveStats.careerStats[hero].combat.objectiveKills.ToString();
                string CompObjTime = dataObject.competitiveStats.careerStats[hero].combat.objectiveTime.ToString();
                string CompMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].combat.quickMeleeAccuracy.ToString();
                string CompSoloKills = dataObject.competitiveStats.careerStats[hero].combat.soloKills.ToString();
                string CompOnFire = dataObject.competitiveStats.careerStats[hero].combat.timeSpentOnFire.ToString();
                string CompWeaponAccuracy = dataObject.competitiveStats.careerStats[hero].combat.weaponAccuracy.ToString();
                //misc stuff
                string CompGamesPlayed = dataObject.competitiveStats.careerStats[hero].game.gamesPlayed.ToString();
                string CompGamesWon = dataObject.competitiveStats.careerStats[hero].game.gamesWon.ToString();
                string CompGamesTied = dataObject.competitiveStats.careerStats[hero].game.gamesTied.ToString();
                string CompGamesLost = dataObject.competitiveStats.careerStats[hero].game.gamesLost.ToString();
                string CompTimePlayed = dataObject.competitiveStats.careerStats[hero].game.timePlayed.ToString();
                string CompWinPercentage = dataObject.competitiveStats.careerStats[hero].game.winPercentage.ToString();
                string CompCards = dataObject.competitiveStats.careerStats[hero].matchAwards.cards.ToString();
                string CompMedals = dataObject.competitiveStats.careerStats[hero].matchAwards.medals.ToString();
                string CompMedalsBronze = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsBronze.ToString();
                string CompMedalsGold = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsGold.ToString();
                string CompMedalsSilver = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsSilver.ToString();
                string CompElimsPerLife = dataObject.competitiveStats.topHeroes[hero].eliminationsPerLife.ToString();

                //quickplay stats
                string QpAllDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.allDamageDoneAvgPer10Min.ToString();
                string QpBarrierDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.barrierDamageDoneAvgPer10Min.ToString();
                string QpCriticalsAvg = dataObject.quickPlayStats.careerStats[hero].average.criticalHitsAvgPer10Min.ToString();
                string QpDeathAvg = dataObject.quickPlayStats.careerStats[hero].average.deathsAvgPer10Min.ToString();
                string QpElimAvg = dataObject.quickPlayStats.careerStats[hero].average.eliminationsAvgPer10Min.ToString();
                string QpElimPerLife = dataObject.quickPlayStats.careerStats[hero].average.eliminationsPerLife.ToString();
                string QpFinalBlowAvg = dataObject.quickPlayStats.careerStats[hero].average.finalBlowsAvgPer10Min.ToString();
                string QpHeroDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.heroDamageDoneAvgPer10Min.ToString();
                string QpMeleeAvg = dataObject.quickPlayStats.careerStats[hero].average.meleeFinalBlowsAvgPer10Min.ToString();
                string QpObjKillsAvg = dataObject.quickPlayStats.careerStats[hero].average.objectiveKillsAvgPer10Min.ToString();
                string QpObjTimeAvg = dataObject.quickPlayStats.careerStats[hero].average.objectiveTimeAvgPer10Min.ToString();
                string QpSoloKillAvg = dataObject.quickPlayStats.careerStats[hero].average.soloKillsAvgPer10Min.ToString();
                string QpOnFireAvg = dataObject.quickPlayStats.careerStats[hero].average.timeSpentOnFireAvgPer10Min.ToString();
                //best
                string QpAllDamageInGame = dataObject.quickPlayStats.careerStats[hero].best.allDamageDoneMostInGame.ToString();
                string QpAllDamageInLife = dataObject.quickPlayStats.careerStats[hero].best.allDamageDoneMostInLife.ToString();
                string QpBarrierDamageInGame = dataObject.quickPlayStats.careerStats[hero].best.barrierDamageDoneMostInGame.ToString();
                string QpCritMostInGame = dataObject.quickPlayStats.careerStats[hero].best.criticalHitsMostInGame.ToString();
                string QpCritMostInLife = dataObject.quickPlayStats.careerStats[hero].best.criticalHitsMostInLife.ToString();
                string QpElimMostInLife = dataObject.quickPlayStats.careerStats[hero].best.eliminationsMostInLife.ToString();
                string QpElimMostInGame = dataObject.quickPlayStats.careerStats[hero].best.eliminationsMostInGame.ToString();
                string QpFinalBlowMostInGame = dataObject.quickPlayStats.careerStats[hero].best.finalBlowsMostInGame.ToString();
                string QpHeroDmgMostInGame = dataObject.quickPlayStats.careerStats[hero].best.heroDamageDoneMostInGame.ToString();
                string QpHeroDmgMostInLife = dataObject.quickPlayStats.careerStats[hero].best.heroDamageDoneMostInLife.ToString();
                string QpKillStreakBest = dataObject.quickPlayStats.careerStats[hero].best.killsStreakBest.ToString();
                string QpMeleeFinalBlowMostInGame = dataObject.quickPlayStats.careerStats[hero].best.meleeFinalBlowsMostInGame.ToString();
                string QpMultikillBest = dataObject.quickPlayStats.careerStats[hero].best.multikillsBest.ToString();
                string QpObjKillMostInGame = dataObject.quickPlayStats.careerStats[hero].best.objectiveKillsMostInGame.ToString();
                string QpObjTimeMostInGame = dataObject.quickPlayStats.careerStats[hero].best.objectiveTimeMostInGame.ToString();
                string QpSoloKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].best.soloKillsMostInGame.ToString();
                string QpOnFireMostInGame = dataObject.quickPlayStats.careerStats[hero].best.timeSpentOnFireMostInGame.ToString();
                string QpWeaponAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].best.weaponAccuracyBestInGame.ToString();
                //combat
                string QpBarrierDmgDone = dataObject.quickPlayStats.careerStats[hero].combat.barrierDamageDone.ToString();
                string QpCriticalHits = dataObject.quickPlayStats.careerStats[hero].combat.criticalHits.ToString();
                string QpCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.criticalHitsAccuracy.ToString();
                string QpDamageDone = dataObject.quickPlayStats.careerStats[hero].combat.damageDone.ToString();
                string QpDeaths = dataObject.quickPlayStats.careerStats[hero].combat.deaths.ToString();
                string QpElims = dataObject.quickPlayStats.careerStats[hero].combat.eliminations.ToString();

                string QpFinalBlows = dataObject.quickPlayStats.careerStats[hero].combat.finalBlows.ToString();
                string QpHeroDmg = dataObject.quickPlayStats.careerStats[hero].combat.heroDamageDone.ToString();
                string QpMeleeFinalBlows = dataObject.quickPlayStats.careerStats[hero].combat.meleeFinalBlows.ToString();
                string QpMultikills = dataObject.quickPlayStats.careerStats[hero].combat.multikills.ToString();
                string QpObjKills = dataObject.quickPlayStats.careerStats[hero].combat.objectiveKills.ToString();
                string QpObjTime = dataObject.quickPlayStats.careerStats[hero].combat.objectiveTime.ToString();
                string QpMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.quickMeleeAccuracy.ToString();
                string QpSoloKills = dataObject.quickPlayStats.careerStats[hero].combat.soloKills.ToString();
                string QpOnFire = dataObject.quickPlayStats.careerStats[hero].combat.timeSpentOnFire.ToString();
                string QpWeaponAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.weaponAccuracy.ToString();
                //misc stuff
                string QpGamesWon = dataObject.quickPlayStats.careerStats[hero].game.gamesWon.ToString();
                string QpTimePlayed = dataObject.quickPlayStats.careerStats[hero].game.timePlayed.ToString();
                string QpCards = dataObject.quickPlayStats.careerStats[hero].matchAwards.cards.ToString();
                string QpMedals = dataObject.quickPlayStats.careerStats[hero].matchAwards.medals.ToString();
                string QpMedalsBronze = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsBronze.ToString();
                string QpMedalsGold = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsGold.ToString();
                string QpMedalsSilver = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsSilver.ToString();
                string QpElimsPerLife = dataObject.quickPlayStats.topHeroes[hero].eliminationsPerLife.ToString();

                string compAvg = $"All Damage Done per 10 Minutes: **{CompAllDamageAvg}**\nBarrier Damage Done per 10 Minutes: **{CompBarrierDamageAvg}**\nHero Damage Done per 10 Minutes: **{CompHeroDamageAvg}**\nCritical Hits per 10 Minutes: **{CompCriticalsAvg}**\nDeaths per 10 Minutes: **{CompDeathAvg}**\nEliminations per 10 Minutes: **{CompElimAvg}**\nEliminations per Life: **{CompElimPerLife}**\nFinal Blows per 10 Minutes: **{CompFinalBlowAvg}**\nMelee Final Blows per 10 Minutes: **{CompMeleeAvg}**\nObjective Time per 10 Minutes: **{CompObjTimeAvg}**\nObjective Kills per 10 Minutes: **{CompObjKillsAvg}**\nSolo Kills per 10 Minutes: **{CompSoloKillAvg}**\nTime on Fire per 10 Minutes: **{CompOnFireAvg}**";
                string compBest = $"All Damage in Game: **{CompAllDamageInGame}**\nAll Damage in Life: **{CompAllDamageInLife}**\nBarrier Damage in Game: **{CompBarrierDamageInGame}**\nCriticals in Game: **{CompCritMostInGame}**\nCriticals in Life: **{CompCritMostInLife}**\nEliminations in Game: **{CompElimMostInGame}**\nEliminations in Life: **{CompElimMostInLife}**\nFinal Blows in Game: **{CompFinalBlowMostInGame}**\nHero Damage in Game: **{CompHeroDmgMostInGame}**\nHero Damage in Life: **{CompHeroDmgMostInLife}**\nKill Streak: **{CompKillStreakBest}**\nMelee Final Blows in Game: **{CompMeleeFinalBlowMostInGame}**\nMultikill: **{CompMultikillBest}**\nObjective Kills in Game: **{CompObjKillMostInGame}**\nObjective Time in Game: **{CompObjTimeMostInGame}**\nSolo Kills in Game: **{CompSoloKillsMostInGame}**\nOn Fire Time in Game: **{CompOnFireMostInGame}**\nWeapon Accuracy in Game: **{CompWeaponAccuracyBestInGame}**";
                string compTotal = $"Barrier Damage Done: **{CompBarrierDmgDone}**\nCritical Hits: **{CompCriticalHits}**\nObjective Time in Game: **{CompObjTimeMostInGame}**\nCritical Hit Accuracy: **{CompCriticalHitsAccuracy}**\nDamage Done: **{CompDamageDone}**\nDeaths: **{CompDeaths}**\nEliminations: **{CompElims}**\nFinal Blows: **{CompFinalBlows}**\nHero Damage: **{CompHeroDmg}**\nMelee Final Blows: **{CompMeleeFinalBlows}**\nMultikills: **{CompMultikills}**\nObjective Kills: **{CompObjKills}**\nObjective Time: **{CompObjTime}**\nMelee Accuracy: **{CompMeleeAccuracy}**\nSolo Kills: **{CompSoloKills}**\nOn Fire Time: **{CompOnFire}**\nWeapon Accuracy: **{CompWeaponAccuracy}**";
                string compMisc = $"Games Played: **{CompGamesPlayed}**\nGames Won: **{CompGamesWon}**\nGames Tied: **{CompGamesTied}**\nGames Lost: **{CompGamesLost}**\nTime Played: **{CompTimePlayed}**\nWin Percentage: **{CompWinPercentage}**\nCards: **{CompCards}**\nTotal Medals: **{CompMedals}**\nGold Medals: **{CompMedalsGold}**\nSilver Medals: **{CompMedalsSilver}**\nBronze Medals: **{CompMedalsBronze}**\nEliminations per Life: **{CompElimsPerLife}**\n";
                string qpAvg = $"All Damage Done per 10 Minutes: **{QpAllDamageAvg}**\nBarrier Damage Done per 10 Minutes: **{QpBarrierDamageAvg}**\nHero Damage Done per 10 Minutes: **{QpHeroDamageAvg}**\nCritical Hits per 10 Minutes: **{QpCriticalsAvg}**\nDeaths per 10 Minutes: **{QpDeathAvg}**\nEliminations per 10 Minutes: **{QpElimAvg}**\nEliminations per Life: **{QpElimPerLife}**\nFinal Blows per 10 Minutes: **{QpFinalBlowAvg}**\nMelee Final Blows per 10 Minutes: **{QpMeleeAvg}**\nObjective Time per 10 Minutes: **{QpObjTimeAvg}**\nObjective Kills per 10 Minutes: **{QpObjKillsAvg}**\nSolo Kills per 10 Minutes: **{QpSoloKillAvg}**\nTime on Fire per 10 Minutes: **{QpOnFireAvg}**";
                string qpBest = $"All Damage in Game: **{QpAllDamageInGame}**\nAll Damage in Life: **{QpAllDamageInLife}**\nBarrier Damage in Game: **{QpBarrierDamageInGame}**\nCriticals in Game: **{QpCritMostInGame}**\nCriticals in Life: **{QpCritMostInLife}**\nEliminations in Game: **{QpElimMostInGame}**\nEliminations in Life: **{QpElimMostInLife}**\nFinal Blows in Game: **{QpFinalBlowMostInGame}**\nHero Damage in Game: **{QpHeroDmgMostInGame}**\nHero Damage in Life: **{QpHeroDmgMostInLife}**\nKill Streak: **{QpKillStreakBest}**\nMelee Final Blows in Game: **{QpMeleeFinalBlowMostInGame}**\nMultikill: **{QpMultikillBest}**\nObjective Kills in Game: **{QpObjKillMostInGame}**\nObjective Time in Game: **{QpObjTimeMostInGame}**\nSolo Kills in Game: **{QpSoloKillsMostInGame}**\nOn Fire Time in Game: **{QpOnFireMostInGame}**\nWeapon Accuracy in Game: **{QpWeaponAccuracyBestInGame}**";
                string qpTotal = $"Barrier Damage Done: **{QpBarrierDmgDone}**\nCritical Hits: **{QpCriticalHits}**\nObjective Time in Game: **{QpObjTimeMostInGame}**\nCritical Hit Accuracy: **{QpCriticalHitsAccuracy}**\nDamage Done: **{QpDamageDone}**\nDeaths: **{QpDeaths}**\nEliminations: **{QpElims}**\nFinal Blows: **{QpFinalBlows}**\nHero Damage: **{QpHeroDmg}**\nMelee Final Blows: **{QpMeleeFinalBlows}**\nMultikills: **{QpMultikills}**\nObjective Kills: **{QpObjKills}**\nObjective Time: **{QpObjTime}**\nMelee Accuracy: **{QpMeleeAccuracy}**\nSolo Kills: **{QpSoloKills}**\nOn Fire Time: **{QpOnFire}**\nWeapon Accuracy: **{QpWeaponAccuracy}**";
                string qpMisc = $"Games Won: **{QpGamesWon}**\nTime Played: **{QpTimePlayed}**\nCards: **{QpCards}**\nTotal Medals: **{QpMedals}**\nGold Medals: **{QpMedalsGold}**\nSilver Medals: **{QpMedalsSilver}**\nBronze Medals: **{QpMedalsBronze}**\nEliminations per Life: **{QpElimsPerLife}**\n";

                if (hero == "ana")
                {
                    string QpBioticKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticGrenadeKills.ToString();
                    string QpEnemiesSlept = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSlept.ToString();
                    string QpEnemiesSleptPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSleptAvgPer10Min.ToString();
                    string QpEnemiesSleptMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSleptMostInGame.ToString();
                    string QpNanoAssists = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssists.ToString();
                    string QpNanoAssistsPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssistsAvgPer10Min.ToString();
                    string QpMostNanoAssistsIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssistsMostInGame.ToString();
                    string QpNanosApplied = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsApplied.ToString();
                    string QpNanosAppliedPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsAppliedAvgPer10Min.ToString();
                    string QpNanoAppliedMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsAppliedMostInGame.ToString();
                    string QpScopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpScopedAccuracyBestIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpSecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpSelfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpSelfHealingPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpSelfHealingMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpUnscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.unscopedAccuracy.ToString();
                    string QpUnscopedAccuracyBestIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.unscopedAccuracyBestInGame.ToString();

                    string CompBioticKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticGrenadeKills.ToString();
                    string CompEnemiesSlept = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSlept.ToString();
                    string CompEnemiesSleptPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSleptAvgPer10Min.ToString();
                    string CompEnemiesSleptMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSleptMostInGame.ToString();
                    string CompNanoAssists = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssists.ToString();
                    string CompNanoAssistsPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssistsAvgPer10Min.ToString();
                    string CompMostNanoAssistsIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssistsMostInGame.ToString();
                    string CompNanosApplied = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsApplied.ToString();
                    string CompNanosAppliedPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsAppliedAvgPer10Min.ToString();
                    string CompNanoAppliedMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsAppliedMostInGame.ToString();
                    string CompScopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompScopedAccuracyBestIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompSecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompSelfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompSelfHealingPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompSelfHealingMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompUnscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.unscopedAccuracy.ToString();
                    string CompUnscopedAccuracyBestIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.unscopedAccuracyBestInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Biotic Grenade Kills: **{QpBioticKills}**\nEnemies Slept: **{QpEnemiesSlept}**\nAverage Enemies Slept per 10 Minutes: **{QpEnemiesSleptPer10Min}**\nMost Enemies Slept In Game: **{QpEnemiesSleptPer10Min}**\nNano Boost Assists: **{QpNanoAssists}**\nNano Boost Assists Per 10 Minutes: **{QpNanosAppliedPer10Min}**\nMost Nano Boost Assists In Game: **{QpMostNanoAssistsIG}**\nNano Boosts Applied: **{QpNanosApplied}**\nNano Boosts Applied Per 10 Minutes: **{QpNanosAppliedPer10Min}**\nNano Boosts Applied Most In Game: **{QpNanoAppliedMostIG}**\nScoped Accuracy: **{QpScopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpScopedAccuracyBestIG}**\nSecondary Fire Accuracy: **{QpSecondaryFireAccuracy}**\nSelf Healing: **{QpSelfHealing}**\nSelf Healing Per 10 Minutes: **{QpSelfHealingPer10Min}**\nMost Self Healing In Game: **{QpSelfHealingMostIG}**\nUnscoped Accuracy: **{QpUnscopedAccuracy}**\nBest Unscoped Accuracy In Game: **{QpScopedAccuracyBestIG}**";
                    string compHeroSpecific = $"Biotic Grenade Kills: **{CompBioticKills}**\nEnemies Slept: **{CompEnemiesSlept}**\nAverage Enemies Slept per 10 Minutes: **{CompEnemiesSleptPer10Min}**\nMost Enemies Slept In Game: **{CompEnemiesSleptPer10Min}**\nNano Boost Assists: **{CompNanoAssists}**\nNano Boost Assists Per 10 Minutes: **{CompNanosAppliedPer10Min}**\nMost Nano Boost Assists In Game: **{CompMostNanoAssistsIG}**\nNano Boosts Applied: **{CompNanosApplied}**\nNano Boosts Applied Per 10 Minutes: **{CompNanosAppliedPer10Min}**\nNano Boosts Applied Most In Game: **{CompNanoAppliedMostIG}**\nScoped Accuracy: **{CompScopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompScopedAccuracyBestIG}**\nSecondary Fire Accuracy: **{CompSecondaryFireAccuracy}**\nSelf Healing: **{CompSelfHealing}**\nSelf Healing Per 10 Minutes: **{CompSelfHealingPer10Min}**\nMost Self Healing In Game: **{CompSelfHealingMostIG}**\nUnscoped Accuracy: **{CompUnscopedAccuracy}**\nBest Unscoped Accuracy In Game: **{CompScopedAccuracyBestIG}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "ashe")
                {
                    string CompbobKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKills.ToString();
                    string CompbobKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKillsAvgPer10Min.ToString();
                    string CompbobKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKillsMostInGame.ToString();
                    string CompcoachGunKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKills.ToString();
                    string CompcoachGunKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKillsAvgPer10Min.ToString();
                    string CompcoachGunKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKillsMostInGame.ToString();
                    string CompdynamiteKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKills.ToString();
                    string CompdynamiteKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKillsAvgPer10Min.ToString();
                    string CompdynamiteKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKillsMostInGame.ToString();
                    string CompscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompscopedAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompscopedCriticalHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string CompscopedCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string CompscopedCriticalHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string CompscopedCriticalHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string QpbobKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKills.ToString();
                    string QpbobKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKillsAvgPer10Min.ToString();
                    string QpbobKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKillsMostInGame.ToString();
                    string QpcoachGunKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKills.ToString();
                    string QpcoachGunKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKillsAvgPer10Min.ToString();
                    string QpcoachGunKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKillsMostInGame.ToString();
                    string QpdynamiteKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKills.ToString();
                    string QpdynamiteKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKillsAvgPer10Min.ToString();
                    string QpdynamiteKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKillsMostInGame.ToString();
                    string QpscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpscopedAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpscopedCriticalHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string QpscopedCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string QpscopedCriticalHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string QpscopedCriticalHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"BOB Kills: **{QpbobKills}**\nAverage BOB Kills Per 10 Minutes: **{QpbobKillsAvgPer10Min}**\nMost BOB Kills In Game: **{QpbobKillsMostInGame}**\nCoach Gun Kills: **{QpcoachGunKills}**\nAverage Coach Gun Kills Per 10 Minutes: **{QpcoachGunKillsAvgPer10Min}**\nMost Coach Gun Kills In Game: **{QpcoachGunKillsMostInGame}**\nDynamite Kills: **{QpdynamiteKills}**\nAverage Dynamite Kills Per 10 Minutes: **{QpdynamiteKillsAvgPer10Min}**\nMost Dynamite Kills In Game Kills: **{QpdynamiteKillsMostInGame}**\nScoped Accuracy: **{QpscopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpscopedAccuracyBestInGame}**\nScoped Creitical Hits: **{QpscopedCriticalHits}**\nScoped Critical Hits Accuracy: **{QpscopedCriticalHitsAccuracy}**\nAverage Scoped Critical Hits Per 10 Minutes: **{QpscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{QpscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"BOB Kills: **{CompbobKills}**\nAverage BOB Kills Per 10 Minutes: **{CompbobKillsAvgPer10Min}**\nMost BOB Kills In Game: **{CompbobKillsMostInGame}**\nCoach Gun Kills: **{CompcoachGunKills}**\nAverage Coach Gun Kills Per 10 Minutes: **{CompcoachGunKillsAvgPer10Min}**\nMost Coach Gun Kills In Game: **{CompcoachGunKillsMostInGame}**\nDynamite Kills: **{CompdynamiteKills}**\nAverage Dynamite Kills Per 10 Minutes: **{CompdynamiteKillsAvgPer10Min}**\nMost Dynamite Kills In Game Kills: **{CompdynamiteKillsMostInGame}**\nScoped Accuracy: **{CompscopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompscopedAccuracyBestInGame}**\nScoped Creitical Hits: **{CompscopedCriticalHits}**\nScoped Critical Hits Accuracy: **{CompscopedCriticalHitsAccuracy}**\nAverage Scoped Critical Hits Per 10 Minutes: **{CompscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{CompscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "bastion")
                {
                    string QpreconKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKills.ToString();
                    string QpreconKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKillsAvgPer10Min.ToString();
                    string QpreconKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].selfHealingAvgPer10Min.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpsentryKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKills.ToString();
                    string QpsentryKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKillsAvgPer10Min.ToString();
                    string QpsentryKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKillsMostInGame.ToString();
                    string QptankKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKills.ToString();
                    string QptankKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKillsAvgPer10Min.ToString();
                    string QptankKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKillsMostInGame.ToString();

                    string CompreconKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKills.ToString();
                    string CompreconKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKillsAvgPer10Min.ToString();
                    string CompreconKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].selfHealingAvgPer10Min.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompsentryKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKills.ToString();
                    string CompsentryKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKillsAvgPer10Min.ToString();
                    string CompsentryKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKillsMostInGame.ToString();
                    string ComptankKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKills.ToString();
                    string ComptankKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKillsAvgPer10Min.ToString();
                    string ComptankKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKillsMostInGame.ToString();

                    string qpHeroSpecific = $"Recon Kills: **{QpreconKills}**\nAverage Recon Kills Per 10 Minutes: **{QpreconKillsAvgPer10Min}**\nMost Recon Kills In Game: **{QpreconKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nSentry Kills: **{QpsentryKills}**\nAverage Sentry Kills Per 10 Minutes: **{QpsentryKillsAvgPer10Min}**\nMost Sentry Kills In Game: **{QpsentryKillsMostInGame}**\nTank Kills: **{QptankKills}**\nAverage Tank Kills Per 10 Minutes: **{QpreconKills}**\nMost Tank Kills In Game: **{QptankKillsMostInGame}**";
                    string compHeroSpecific = $"Recon Kills: **{CompreconKills}**\nAverage Recon Kills Per 10 Minutes: **{CompreconKillsAvgPer10Min}**\nMost Recon Kills In Game: **{CompreconKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nSentry Kills: **{CompsentryKills}**\nAverage Sentry Kills Per 10 Minutes: **{CompsentryKillsAvgPer10Min}**\nMost Sentry Kills In Game: **{CompsentryKillsMostInGame}**\nTank Kills: **{ComptankKills}**\nAverage Tank Kills Per 10 Minutes: **{CompreconKills}**\nMost Tank Kills In Game: **{ComptankKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "brigitte")
                {
                    string QparmorProvided = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvided.ToString();
                    string QparmorProvidedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvidedAvgPer10Min.ToString();
                    string QparmorProvidedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvidedMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpinspireUptimePercentage = dataObject.quickPlayStats.careerStats[hero].heroSpecific.inspireUptimePercentage.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();

                    string ComparmorProvided = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvided.ToString();
                    string ComparmorProvidedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvidedAvgPer10Min.ToString();
                    string ComparmorProvidedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvidedMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompinspireUptimePercentage = dataObject.competitiveStats.careerStats[hero].heroSpecific.inspireUptimePercentage.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Armor Provided: **{QparmorProvided}**\nAverage Armor Provided Per 10 Minutes: **{QparmorProvidedAvgPer10Min}**\nMost Armor Provided In Game: **{QparmorProvidedMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nInspire Uptime Percentage: **{QpinspireUptimePercentage}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\n";
                    string compHeroSpecific = $"Armor Provided: **{ComparmorProvided}**\nAverage Armor Provided Per 10 Minutes: **{ComparmorProvidedAvgPer10Min}**\nMost Armor Provided In Game: **{ComparmorProvidedMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nInspire Uptime Percentage: **{CompinspireUptimePercentage}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "dVa")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpmechDeaths = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechDeaths.ToString();
                    string QpmechsCalled = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalled.ToString();
                    string QpmechsCalledAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalledAvgPer10Min.ToString();
                    string QpmechsCalledMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalledMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfDestructKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKills.ToString();
                    string QpselfDestructKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKillsAvgPer10Min.ToString();
                    string QpselfDestructKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKillsMostInGame.ToString();

                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompmechDeaths = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechDeaths.ToString();
                    string CompmechsCalled = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalled.ToString();
                    string CompmechsCalledAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalledAvgPer10Min.ToString();
                    string CompmechsCalledMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalledMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfDestructKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKills.ToString();
                    string CompselfDestructKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKillsAvgPer10Min.ToString();
                    string CompselfDestructKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKillsMostInGame.ToString();

                    string qpHeroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nMech Deaths: **{QpmechDeaths}**\nMechs Called: **{QpmechsCalled}**\nAverage Mechs Called Per 10 Minutes: **{QpmechsCalledAvgPer10Min}**\nMost Mechs Called In Game: **{QpmechsCalledMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Destruct Kills: **{QpselfDestructKills}**\nAverage Self Destruct Kills Per 10 Minutes: **{QpselfDestructKillsAvgPer10Min}**\nMost Self Destruct Kills In Game: **{QpselfDestructKillsMostInGame}**";
                    string compHeroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nMech Deaths: **{CompmechDeaths}**\nMechs Called: **{CompmechsCalled}**\nAverage Mechs Called Per 10 Minutes: **{CompmechsCalledAvgPer10Min}**\nMost Mechs Called In Game: **{CompmechsCalledMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Destruct Kills: **{CompselfDestructKills}**\nAverage Self Destruct Kills Per 10 Minutes: **{CompselfDestructKillsAvgPer10Min}**\nMost Self Destruct Kills In Game: **{CompselfDestructKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "doomfist")
                {
                    string QpabilityDamageDone = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.barrierDamageDone.ToString();
                    string QpabilityDamageDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.abilityDamageDoneAvgPer10Min.ToString();
                    string QpabilityDamageDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.abilityDamageDoneMostInGame.ToString();
                    string QpmeteorStrikeKills = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKills.ToString();
                    string QpmeteorStrikeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsAvgPer10Min.ToString();
                    string QpmeteorStrikeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.secondaryFireAccuracy.ToString();
                    string QpshieldsCreated = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreated.ToString();
                    string QpshieldsCreatedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreatedAvgPer10Min.ToString();
                    string QpshieldsCreatedMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreatedMostInGame.ToString();

                    string CompabilityDamageDone = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.barrierDamageDone.ToString();
                    string CompabilityDamageDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.abilityDamageDoneAvgPer10Min.ToString();
                    string CompabilityDamageDoneMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.abilityDamageDoneMostInGame.ToString();
                    string CompmeteorStrikeKills = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKills.ToString();
                    string CompmeteorStrikeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsAvgPer10Min.ToString();
                    string CompmeteorStrikeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.secondaryFireAccuracy.ToString();
                    string CompshieldsCreated = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreated.ToString();
                    string CompshieldsCreatedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreatedAvgPer10Min.ToString();
                    string CompshieldsCreatedMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreatedMostInGame.ToString();

                    string qpHeroSpecific = $"Ability Damage Done: **{QpabilityDamageDone}**\nAverage Ability Damage Done Per 10 Minutes: **{QpabilityDamageDoneAvgPer10Min}**\nMost Ability Damage Done In Game: **{QpabilityDamageDoneMostInGame}**\nMeteor Strike Kills: **{QpmeteorStrikeKills}**\nAverage Meteor Strike Kills Per 10 Minutes: **{QpmeteorStrikeKillsAvgPer10Min}**\nMost Meteor Strike Kills In Game: **{QpmeteorStrikeKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nShields Created: **{QpshieldsCreated}**\nAverage Shields Created Per 10 Minutes: **{QpshieldsCreatedAvgPer10Min}**\nMost Shields Created In Game: **{QpshieldsCreatedMostInGame}**";
                    string compHeroSpecific = $"Ability Damage Done: **{CompabilityDamageDone}**\nAverage Ability Damage Done Per 10 Minutes: **{CompabilityDamageDoneAvgPer10Min}**\nMost Ability Damage Done In Game: **{CompabilityDamageDoneMostInGame}**\nMeteor Strike Kills: **{CompmeteorStrikeKills}**\nAverage Meteor Strike Kills Per 10 Minutes: **{CompmeteorStrikeKillsAvgPer10Min}**\nMost Meteor Strike Kills In Game: **{CompmeteorStrikeKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nShields Created: **{CompshieldsCreated}**\nAverage Shields Created Per 10 Minutes: **{CompshieldsCreatedAvgPer10Min}**\nMost Shields Created In Game: **{CompshieldsCreatedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "genji")
                {
                    string QpdamageReflected = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflected.ToString();
                    string QpdamageReflectedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflectedAvgPer10Min.ToString();
                    string QpdamageReflectedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflectedMostInGame.ToString();
                    string QpdeflectionKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deflectionKills.ToString();
                    string QpdragonbladesKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKills.ToString();
                    string QpdragonbladesKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKillsAvgPer10Min.ToString();
                    string QpdragonbladesKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompdamageReflected = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflected.ToString();
                    string CompdamageReflectedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflectedAvgPer10Min.ToString();
                    string CompdamageReflectedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflectedMostInGame.ToString();
                    string CompdeflectionKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deflectionKills.ToString();
                    string CompdragonbladesKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKills.ToString();
                    string CompdragonbladesKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKillsAvgPer10Min.ToString();
                    string CompdragonbladesKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"Damage Deflected: **{QpdamageReflected}**\nAverage Damage Deflected Per 10 Minutes: **{QpdamageReflectedMostInGame}**\nMost Damage Deflected In Game: **{QpdamageReflectedMostInGame}**\nDeflection Kills: **{QpdeflectionKills}**\nDragonblade Kills: **{QpdragonbladesKills}**\nAverage Dragonblade Kills Per 10 Minutes: **{QpdragonbladesKillsAvgPer10Min}**\nMost Dragonblade Kills In Game: **{QpdragonbladesKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Damage Deflected: **{CompdamageReflected}**\nAverage Damage Deflected Per 10 Minutes: **{CompdamageReflectedMostInGame}**\nMost Damage Deflected In Game: **{CompdamageReflectedMostInGame}**\nDeflection Kills: **{CompdeflectionKills}**\nDragonblade Kills: **{CompdragonbladesKills}**\nAverage Dragonblade Kills Per 10 Minutes: **{CompdragonbladesKillsAvgPer10Min}**\nMost Dragonblade Kills In Game: **{CompdragonbladesKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "hanzo")
                {
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompstormArrowKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKills.ToString();
                    string CompstormArrowKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKillsAvgPer10Min.ToString();
                    string CompstormArrowKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKillsMostInGame.ToString();

                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpstormArrowKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKills.ToString();
                    string QpstormArrowKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKillsAvgPer10Min.ToString();
                    string QpstormArrowKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKillsMostInGame.ToString();

                    string qpHeroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nStorm Arrow Kills: **{QpstormArrowKills}**\nAverage Storm Arrow Kills Per 10 Minutes: **{QpstormArrowKillsAvgPer10Min}**\nMost Storm Arrow Kills In Game: **{QpstormArrowKillsMostInGame}**";
                    string compHeroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nStorm Arrow Kills: **{CompstormArrowKills}**\nAverage Storm Arrow Kills Per 10 Minutes: **{CompstormArrowKillsAvgPer10Min}**\nMost Storm Arrow Kills In Game: **{CompstormArrowKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "junkrat")
                {
                    string CompconcussionMineKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKills.ToString();
                    string CompconcussionMineKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKillsAvgPer10Min.ToString();
                    string CompconcussionMineKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKillsMostInGame.ToString();
                    string CompenemiesTrapped = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrapped.ToString();
                    string CompenemiesTrappedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrappedAvgPer10Min.ToString();
                    string CompenemiesTrappedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrappedMostInGame.ToString();
                    string CompripTireKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKills.ToString();
                    string CompripTireKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKillsAvgPer10Min.ToString();
                    string CompripTireKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string QpconcussionMineKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKills.ToString();
                    string QpconcussionMineKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKillsAvgPer10Min.ToString();
                    string QpconcussionMineKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKillsMostInGame.ToString();
                    string QpenemiesTrapped = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrapped.ToString();
                    string QpenemiesTrappedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrappedAvgPer10Min.ToString();
                    string QpenemiesTrappedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrappedMostInGame.ToString();
                    string QpripTireKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKills.ToString();
                    string QpripTireKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKillsAvgPer10Min.ToString();
                    string QpripTireKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Concussion Mine Kills: **{QpconcussionMineKills}**\nAverage Concussion Mine Kills Per 10 Minutes: **{QpconcussionMineKillsAvgPer10Min}**\nMost Concussion Mine Kills in Game: **{QpconcussionMineKillsMostInGame}**\nEnemies Trapped: **{QpenemiesTrapped}**\nAverage Enemies Trapped Per 10 Minutes: **{QpenemiesTrappedAvgPer10Min}**\nMost Enemies Trapped In Game: **{QpenemiesTrappedMostInGame}**\nRip Tire Kills: **{QpripTireKills}**\nAverage Rip Tire Kills Per 10 Minutes: **{QpripTireKillsAvgPer10Min}**\nMost Rip Tire Kills In Game: **{QpripTireKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Concussion Mine Kills: **{CompconcussionMineKills}**\nAverage Concussion Mine Kills Per 10 Minutes: **{CompconcussionMineKillsAvgPer10Min}**\nMost Concussion Mine Kills in Game: **{CompconcussionMineKillsMostInGame}**\nEnemies Trapped: **{CompenemiesTrapped}**\nAverage Enemies Trapped Per 10 Minutes: **{CompenemiesTrappedAvgPer10Min}**\nMost Enemies Trapped In Game: **{CompenemiesTrappedMostInGame}**\nRip Tire Kills: **{CompripTireKills}**\nAverage Rip Tire Kills Per 10 Minutes: **{CompripTireKillsAvgPer10Min}**\nMost Rip Tire Kills In Game: **{CompripTireKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "lucio")
                {
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompsoundBarriersProvided = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvided.ToString();
                    string CompsoundBarriersProvidedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvidedAvgPer10Min.ToString();
                    string CompsoundBarriersProvidedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvidedMostInGame.ToString();

                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpsoundBarriersProvided = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvided.ToString();
                    string QpsoundBarriersProvidedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvidedAvgPer10Min.ToString();
                    string QpsoundBarriersProvidedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvidedMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\n:Most Self Healing In Game **{QpselfHealingMostInGame}**\nSound Barriers Provided: **{QpsoundBarriersProvided}**\nAverage Sound Barriers Provided Per 10 minutes: **{QpsoundBarriersProvidedAvgPer10Min}**\nMost Sound barriers Provided In Game: **{QpsoundBarriersProvidedMostInGame}**";
                    string compHeroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\n:Most Self Healing In Game **{CompselfHealingMostInGame}**\nSound Barriers Provided: **{CompsoundBarriersProvided}**\nAverage Sound Barriers Provided Per 10 minutes: **{CompsoundBarriersProvidedAvgPer10Min}**\nMost Sound barriers Provided In Game: **{CompsoundBarriersProvidedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mccree")
                {
                    string QpdeadeyeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKills.ToString();
                    string QpdeadeyeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKillsAvgPer10Min.ToString();
                    string QpdeadeyeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKillsMostInGame.ToString();
                    string QpfanTheHammerKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKills.ToString();
                    string QpfanTheHammerKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKillsAvgPer10Min.ToString();
                    string QpfanTheHammerKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompdeadeyeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKills.ToString();
                    string CompdeadeyeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKillsAvgPer10Min.ToString();
                    string CompdeadeyeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKillsMostInGame.ToString();
                    string CompfanTheHammerKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKills.ToString();
                    string CompfanTheHammerKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKillsAvgPer10Min.ToString();
                    string CompfanTheHammerKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"Deadeye Kills: **{QpdeadeyeKills}**\nAverage Deadeye Kills Per 10 Minutes: **{QpdeadeyeKillsAvgPer10Min}**\nMost Deadeye Kills In Game: **{QpdeadeyeKillsMostInGame}**\nFan The Hammer Kills: **{QpfanTheHammerKills}**\nAverage Fan The Hammer Kills Per 10 Minutes: **{QpfanTheHammerKillsAvgPer10Min}**\nMost Fan The Hammer Kills In Game: **{QpfanTheHammerKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Deadeye Kills: **{CompdeadeyeKills}**\nAverage Deadeye Kills Per 10 Minutes: **{CompdeadeyeKillsAvgPer10Min}**\nMost Deadeye Kills In Game: **{CompdeadeyeKillsMostInGame}**\nFan The Hammer Kills: **{CompfanTheHammerKills}**\nAverage Fan The Hammer Kills Per 10 Minutes: **{CompfanTheHammerKillsAvgPer10Min}**\nMost Fan The Hammer Kills In Game: **{CompfanTheHammerKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mei")
                {
                    string QpblizzardKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKills.ToString();
                    string QpblizzardKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKillsAvgPer10Min.ToString();
                    string QpblizzardKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKillsMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpenemiesFrozen = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozen.ToString();
                    string QpenemiesFrozenAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozenAvgPer10Min.ToString();
                    string QpenemiesFrozenMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozenMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompblizzardKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKills.ToString();
                    string CompblizzardKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKillsAvgPer10Min.ToString();
                    string CompblizzardKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKillsMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompenemiesFrozen = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozen.ToString();
                    string CompenemiesFrozenAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozenAvgPer10Min.ToString();
                    string CompenemiesFrozenMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozenMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Blizzard Kills: **{QpblizzardKills}**\nAverage Blizzard Kills Per 10 Minutes: **{QpblizzardKillsAvgPer10Min}**\nMost Blizzard Kills In Game: **{QpblizzardKillsMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nEnemies Frozen: **{QpenemiesFrozen}**\nAverage Enemies Frozen: **{QpenemiesFrozenAvgPer10Min}**\nMost Enemies Frozen In Game: **{QpenemiesFrozenMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    string compHeroSpecific = $"Blizzard Kills: **{CompblizzardKills}**\nAverage Blizzard Kills Per 10 Minutes: **{CompblizzardKillsAvgPer10Min}**\nMost Blizzard Kills In Game: **{CompblizzardKillsMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nEnemies Frozen: **{CompenemiesFrozen}**\nAverage Enemies Frozen: **{CompenemiesFrozenAvgPer10Min}**\nMost Enemies Frozen In Game: **{CompenemiesFrozenMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mercy")
                {
                    string QpblasterKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKills.ToString();
                    string QpblasterKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKillsAvgPer10Min.ToString();
                    string QpblasterKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKillsMostInGame.ToString();
                    string QpdamageAmplified = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string QpdamageAmplifiedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string QpdamageAmplifiedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string QpplayersResurrected = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrected.ToString();
                    string QpplayersResurrectedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrectedAvgPer10Min.ToString();
                    string QpplayersResurrectedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrectedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompblasterKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKills.ToString();
                    string CompblasterKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKillsAvgPer10Min.ToString();
                    string CompblasterKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKillsMostInGame.ToString();
                    string CompdamageAmplified = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string CompdamageAmplifiedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string CompdamageAmplifiedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string CompplayersResurrected = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrected.ToString();
                    string CompplayersResurrectedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrectedAvgPer10Min.ToString();
                    string CompplayersResurrectedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrectedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Blaster Kills: **{QpblasterKills}**\nAverage Blaster Kills Per 10 Minutes: **{QpblasterKillsAvgPer10Min}**\nMost Blaster Kills In Game: **{QpblasterKillsMostInGame}**\nDamage Amplified: **{QpdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{QpdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{QpdamageAmplifiedMostInGame}**\nPlayers Resurrected: **{QpplayersResurrected}**\nAverage Players Resurrected Per 10 Minutes: **{QpplayersResurrectedAvgPer10Min}**\nMost Players Ressurected In Game: **{QpplayersResurrectedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    string compHeroSpecific = $"Blaster Kills: **{CompblasterKills}**\nAverage Blaster Kills Per 10 Minutes: **{CompblasterKillsAvgPer10Min}**\nMost Blaster Kills In Game: **{CompblasterKillsMostInGame}**\nDamage Amplified: **{CompdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{CompdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{CompdamageAmplifiedMostInGame}**\nPlayers Resurrected: **{CompplayersResurrected}**\nAverage Players Resurrected Per 10 Minutes: **{CompplayersResurrectedAvgPer10Min}**\nMost Players Ressurected In Game: **{CompplayersResurrectedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "moira")
                {
                    string QpcoalescenceHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealing.ToString();
                    string QpcoalescenceHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealingAvgPer10Min.ToString();
                    string QpcoalescenceHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealingMostInGame.ToString();
                    string QpcoalescenceKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKills.ToString();
                    string QpcoalescenceKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKillsAvgPer10Min.ToString();
                    string QpcoalescenceKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompcoalescenceHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealing.ToString();
                    string CompcoalescenceHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealingAvgPer10Min.ToString();
                    string CompcoalescenceHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealingMostInGame.ToString();
                    string CompcoalescenceKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKills.ToString();
                    string CompcoalescenceKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKillsAvgPer10Min.ToString();
                    string CompcoalescenceKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Coalescence Healing: **{QpcoalescenceHealing}**\nAverage Coalescence Healing Per 10 Minutes: **{QpcoalescenceHealingAvgPer10Min}**\nMost Coalescence Healing In Game: **{QpcoalescenceHealingMostInGame}**\nCoalescence Kills: **{QpcoalescenceKills}**\nAverage Coalescence Kills Per 10 Minutes: **{QpcoalescenceKillsAvgPer10Min}**\nMost Coalescence Kills In Game: **{QpcoalescenceKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    string compHeroSpecific = $"Coalescence Healing: **{CompcoalescenceHealing}**\nAverage Coalescence Healing Per 10 Minutes: **{CompcoalescenceHealingAvgPer10Min}**\nMost Coalescence Healing In Game: **{CompcoalescenceHealingMostInGame}**\nCoalescence Kills: **{CompcoalescenceKills}**\nAverage Coalescence Kills Per 10 Minutes: **{CompcoalescenceKillsAvgPer10Min}**\nMost Coalescence Kills In Game: **{CompcoalescenceKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "orisa")
                {
                    string QpdamageAmplified = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string QpdamageAmplifiedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string QpdamageAmplifiedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpsuperchargerAssists = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssists.ToString();
                    string QpsuperchargerAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssistsAvgPer10Min.ToString();
                    string QpsuperchargerAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssistsMostInGame.ToString();

                    string CompdamageAmplified = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string CompdamageAmplifiedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string CompdamageAmplifiedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompsuperchargerAssists = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssists.ToString();
                    string CompsuperchargerAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssistsAvgPer10Min.ToString();
                    string CompsuperchargerAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssistsMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Damage Amplified: **{QpdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{QpdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{QpdamageAmplifiedMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSupercharger Assists: **{QpsuperchargerAssists}**\nAverage Supercharger Assists Per 10 Minutes: **{QpsuperchargerAssistsAvgPer10Min}**\nMost Supercharger Assists In Game: **{QpsuperchargerAssistsMostInGame}**";
                    string compHeroSpecific = $"Damage Amplified: **{CompdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{CompdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{CompdamageAmplifiedMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSupercharger Assists: **{CompsuperchargerAssists}**\nAverage Supercharger Assists Per 10 Minutes: **{CompsuperchargerAssistsAvgPer10Min}**\nMost Supercharger Assists In Game: **{CompsuperchargerAssistsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "pharah")
                {
                    string QpbarrageKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKills.ToString();
                    string QpbarrageKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKillsAvgPer10Min.ToString();
                    string QpbarrageKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKillsMostInGame.ToString();
                    string QpdirectHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.directHitsAccuracy.ToString();
                    string QprocketDirectHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHits.ToString();
                    string QprocketDirectHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHitsAvgPer10Min.ToString();
                    string QprocketDirectHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompbarrageKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKills.ToString();
                    string CompbarrageKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKillsAvgPer10Min.ToString();
                    string CompbarrageKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKillsMostInGame.ToString();
                    string CompdirectHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.directHitsAccuracy.ToString();
                    string ComprocketDirectHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHits.ToString();
                    string ComprocketDirectHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHitsAvgPer10Min.ToString();
                    string ComprocketDirectHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"Barrage Kills: **{QpbarrageKills}**\nAverage Barrage Kills Per 10 Minutes: **{QpbarrageKillsAvgPer10Min}**\nMost Barrage Kills In Game: **{QpbarrageKillsMostInGame}**\nDirect Hits Accuracy: **{QpdirectHitsAccuracy}**\nRocket Dirrect Hits: **{QprocketDirectHits}**\nAverage Rocket Direct Hits Per 10 Minutes: **{QprocketDirectHitsAvgPer10Min}**\nMost Rocket Direct Hits In Game: **{QprocketDirectHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Barrage Kills: **{CompbarrageKills}**\nAverage Barrage Kills Per 10 Minutes: **{CompbarrageKillsAvgPer10Min}**\nMost Barrage Kills In Game: **{CompbarrageKillsMostInGame}**\nDirect Hits Accuracy: **{CompdirectHitsAccuracy}**\nRocket Dirrect Hits: **{ComprocketDirectHits}**\nAverage Rocket Direct Hits Per 10 Minutes: **{ComprocketDirectHitsAvgPer10Min}**\nMost Rocket Direct Hits In Game: **{ComprocketDirectHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reaper")
                {
                    string QpdeathsBlossomKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKills.ToString();
                    string QpdeathsBlossomKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKillsAvgPer10Min.ToString();
                    string QpdeathsBlossomKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompdeathsBlossomKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKills.ToString();
                    string CompdeathsBlossomKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKillsAvgPer10Min.ToString();
                    string CompdeathsBlossomKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string qpHeroSpecific = $"Death Blossom Kills: **{QpdeathsBlossomKills}**\nAverage Death Blossom Kills Per 10 Minutes: **{QpdeathsBlossomKillsAvgPer10Min}**\nMost Death Blossom Kills In Game: **{QpdeathsBlossomKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    string compHeroSpecific = $"Death Blossom Kills: **{CompdeathsBlossomKills}**\nAverage Death Blossom Kills Per 10 Minutes: **{CompdeathsBlossomKillsAvgPer10Min}**\nMost Death Blossom Kills In Game: **{CompdeathsBlossomKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reinhardt")
                {
                    string QpchargeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKills.ToString();
                    string QpchargeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKillsAvgPer10Min.ToString();
                    string QpchargeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKillsMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpearthshatterKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKills.ToString();
                    string QpearthshatterKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKillsAvgPer10Min.ToString();
                    string QpearthshatterKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKillsMostInGame.ToString();
                    string QpfireStrikeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKills.ToString();
                    string QpfireStrikeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKillsAvgPer10Min.ToString();
                    string QpfireStrikeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKillsMostInGame.ToString();
                    string QprocketHammerMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketHammerMeleeAccuracy.ToString();

                    string CompchargeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKills.ToString();
                    string CompchargeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKillsAvgPer10Min.ToString();
                    string CompchargeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKillsMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompearthshatterKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKills.ToString();
                    string CompearthshatterKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKillsAvgPer10Min.ToString();
                    string CompearthshatterKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKillsMostInGame.ToString();
                    string CompfireStrikeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKills.ToString();
                    string CompfireStrikeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKillsAvgPer10Min.ToString();
                    string CompfireStrikeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKillsMostInGame.ToString();
                    string ComprocketHammerMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketHammerMeleeAccuracy.ToString();

                    string qpHeroSpecific = $"Charge Kills: **{QpchargeKills}**\nAverage Charge Kills Per 10 Minutes: **{QpchargeKillsAvgPer10Min}**\nMost Charge Kills In Game: **{QpchargeKillsMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nEarthshatter Kills: **{QpearthshatterKills}**\nAverage Earthshatter Kills Per 10 Minutes: **{QpearthshatterKillsAvgPer10Min}**\nMost Earthshatter Kills In Game: **{QpearthshatterKillsMostInGame}**\nFire Strike Kills: **{QpfireStrikeKills}**\nFire Strike Kills: **{QpfireStrikeKills}**\nAverage Fire Strike Kills Per 10 Minutes: **{QpfireStrikeKillsAvgPer10Min}**\nMost Fire Strike Kills In Game: **{QpfireStrikeKillsMostInGame}**\nRocket Hammer Melee Accuracy: **{QprocketHammerMeleeAccuracy}**\n";
                    string compHeroSpecific = $"Charge Kills: **{CompchargeKills}**\nAverage Charge Kills Per 10 Minutes: **{CompchargeKillsAvgPer10Min}**\nMost Charge Kills In Game: **{CompchargeKillsMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nEarthshatter Kills: **{CompearthshatterKills}**\nAverage Earthshatter Kills Per 10 Minutes: **{CompearthshatterKillsAvgPer10Min}**\nMost Earthshatter Kills In Game: **{CompearthshatterKillsMostInGame}**\nFire Strike Kills: **{CompfireStrikeKills}**\nFire Strike Kills: **{CompfireStrikeKills}**\nAverage Fire Strike Kills Per 10 Minutes: **{CompfireStrikeKillsAvgPer10Min}**\nMost Fire Strike Kills In Game: **{CompfireStrikeKillsMostInGame}**\nRocket Hammer Melee Accuracy: **{ComprocketHammerMeleeAccuracy}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "roadhog")
                {
                    string QpenemiesHooked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHooked.ToString();
                    string QpenemiesHookedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHookedAvgPer10Min.ToString();
                    string QpenemiesHookedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHookedMostInGame.ToString();
                    string QphookAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hookAccuracy.ToString();
                    string QphookAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hookAccuracyBestInGame.ToString();
                    string QphooksAttempted = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hooksAttempted.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpwholeHogKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKills.ToString();
                    string QpwholeHogKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKillsAvgPer10Min.ToString();
                    string QpwholeHogKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKillsMostInGame.ToString();

                    string CompenemiesHooked = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHooked.ToString();
                    string CompenemiesHookedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHookedAvgPer10Min.ToString();
                    string CompenemiesHookedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHookedMostInGame.ToString();
                    string ComphookAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.hookAccuracy.ToString();
                    string ComphookAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.hookAccuracyBestInGame.ToString();
                    string ComphooksAttempted = dataObject.competitiveStats.careerStats[hero].heroSpecific.hooksAttempted.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompwholeHogKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKills.ToString();
                    string CompwholeHogKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKillsAvgPer10Min.ToString();
                    string CompwholeHogKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKillsMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Enemies Hooked: **{QpenemiesHooked}**\nAverage Enemies Hooked Per 10 Minutes: **{QpenemiesHookedAvgPer10Min}**\nMost Enemies Hooked In Game: **{QpenemiesHookedMostInGame}**\nHook Accuracy: **{QphookAccuracy}**\nBest Hook Accuracy In Game: **{QphookAccuracyBestInGame}**\nHooks Attempted: **{QphooksAttempted}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nWhole Hog Kills: **{QpwholeHogKills}**\nAverage Whole Hog Kills Per 10 Minutes: **{QpwholeHogKillsAvgPer10Min}**\nMost Whole Hog Kills In Game: **{QpwholeHogKillsMostInGame}**\n";
                    string compHeroSpecific = $"Enemies Hooked: **{CompenemiesHooked}**\nAverage Enemies Hooked Per 10 Minutes: **{CompenemiesHookedAvgPer10Min}**\nMost Enemies Hooked In Game: **{CompenemiesHookedMostInGame}**\nHook Accuracy: **{ComphookAccuracy}**\nBest Hook Accuracy In Game: **{ComphookAccuracyBestInGame}**\nHooks Attempted: **{ComphooksAttempted}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nWhole Hog Kills: **{CompwholeHogKills}**\nAverage Whole Hog Kills Per 10 Minutes: **{CompwholeHogKillsAvgPer10Min}**\nMost Whole Hog Kills In Game: **{CompwholeHogKillsMostInGame}**\n";

                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "soldier76")
                {
                    string QpbioticFieldHealingDone = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticFieldHealingDone.ToString();
                    string QpbioticFieldsDeployed = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticFieldsDeployed.ToString();
                    string QphelixRocketKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketKillsMostInGame.ToString();
                    string QphelixRocketsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketsKills.ToString();
                    string QphelixRocketsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketsKillsAvgPer10Min.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompbioticFieldHealingDone = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticFieldHealingDone.ToString();
                    string CompbioticFieldsDeployed = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticFieldsDeployed.ToString();
                    string ComphelixRocketKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketKillsMostInGame.ToString();
                    string ComphelixRocketsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketsKills.ToString();
                    string ComphelixRocketsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketsKillsAvgPer10Min.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QpselfHealing}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{CompselfHealing}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**";
                    string qpHeroSpecific = $"Biotic Field Healing Done: **{QpbioticFieldHealingDone}**\nBiotic Fields Deployed: **{QpbioticFieldsDeployed}**\nHelix Rocket Kills: **{QphelixRocketsKills}**\nAverage Helix Rocket Kills Per 10 Minutes: **{QphelixRocketsKillsAvgPer10Min}**\nMost Helix Rocket Kills In Game: **{QphelixRocketKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    string compHeroSpecific = $"Biotic Field Healing Done: **{CompbioticFieldHealingDone}**\nBiotic Fields Deployed: **{CompbioticFieldsDeployed}**\nHelix Rocket Kills: **{ComphelixRocketsKills}**\nAverage Helix Rocket Kills Per 10 Minutes: **{ComphelixRocketsKillsAvgPer10Min}**\nMost Helix Rocket Kills In Game: **{ComphelixRocketKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "sombra")
                {
                    string QpenemiesEmpd = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpd.ToString();
                    string QpenemiesEmpdAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpdAvgPer10Min.ToString();
                    string QpenemiesEmpdMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpdMostInGame.ToString();
                    string QpenemiesHacked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHacked.ToString();
                    string QpenemiesHackedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHackedAvgPer10Min.ToString();
                    string QpenemiesHackedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHackedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompenemiesEmpd = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpd.ToString();
                    string CompenemiesEmpdAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpdAvgPer10Min.ToString();
                    string CompenemiesEmpdMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpdMostInGame.ToString();
                    string CompenemiesHacked = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHacked.ToString();
                    string CompenemiesHackedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHackedAvgPer10Min.ToString();
                    string CompenemiesHackedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHackedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Enemies EMP'd: **{QpenemiesEmpd}**\nAverage EMP'd Per 10 Minutes: **{QpenemiesEmpdAvgPer10Min}**\nMost Enemies EMP'd In Game: **{QpenemiesEmpdMostInGame}**\nEnemies Hacked: **{QpenemiesHacked}**\nAverage Enemies Hacked Per 10 Minutes: **{QpenemiesHackedAvgPer10Min}**\nMost Enemies Hacked In Game: **{QpenemiesHackedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Enemies EMP'd: **{CompenemiesEmpd}**\nAverage EMP'd Per 10 Minutes: **{CompenemiesEmpdAvgPer10Min}**\nMost Enemies EMP'd In Game: **{CompenemiesEmpdMostInGame}**\nEnemies Hacked: **{CompenemiesHacked}**\nAverage Enemies Hacked Per 10 Minutes: **{CompenemiesHackedAvgPer10Min}**\nMost Enemies Hacked In Game: **{CompenemiesHackedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "symmetra")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpplayersTeleported = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleported.ToString();
                    string QpplayersTeleportedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleportedAvgPer10Min.ToString();
                    string QpplayersTeleportedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleportedMostInGame.ToString();
                    string QpprimaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string QpsecondaryDirectHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryDirectHitsAvgPer10Min.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpsentryTurretsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKills.ToString();
                    string QpsentryTurretsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKillsAvgPer10Min.ToString();
                    string QpsentryTurretsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKillsMostInGame.ToString();

                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompplayersTeleported = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleported.ToString();
                    string CompplayersTeleportedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleportedAvgPer10Min.ToString();
                    string CompplayersTeleportedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleportedMostInGame.ToString();
                    string CompprimaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string CompsecondaryDirectHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryDirectHitsAvgPer10Min.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompsentryTurretsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKills.ToString();
                    string CompsentryTurretsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKillsAvgPer10Min.ToString();
                    string CompsentryTurretsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKillsMostInGame.ToString();

                    string qpHeroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nPlayers Teleported: **{QpplayersTeleported}**\nAverage Players Teleported Per 10 Minutes: **{QpplayersTeleportedAvgPer10Min}**\nMost Players Teleported In Game: **{QpplayersTeleportedMostInGame}**\nPrimary Fire Accuracy: **{QpprimaryFireAccuracy}**\nSecondary Fire Direct Hits Per 10 Minutes: **{QpsecondaryDirectHitsAvgPer10Min}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSentry Turret Kills: **{QpsentryTurretsKills}**\nAverage Sentry Turret Kills Per 10 Minutes: **{QpsentryTurretsKillsAvgPer10Min}**\nMost Sentry Turret Kills In Game: **{QpsentryTurretsKillsMostInGame}**";
                    string compHeroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nPlayers Teleported: **{CompplayersTeleported}**\nAverage Players Teleported Per 10 Minutes: **{CompplayersTeleportedAvgPer10Min}**\nMost Players Teleported In Game: **{CompplayersTeleportedMostInGame}**\nPrimary Fire Accuracy: **{CompprimaryFireAccuracy}**\nSecondary Fire Direct Hits Per 10 Minutes: **{CompsecondaryDirectHitsAvgPer10Min}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSentry Turret Kills: **{CompsentryTurretsKills}**\nAverage Sentry Turret Kills Per 10 Minutes: **{CompsentryTurretsKillsAvgPer10Min}**\nMost Sentry Turret Kills In Game: **{CompsentryTurretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "torbjorn")
                {
                    string QpmoltenCoreKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKills.ToString();
                    string QpmoltenCoreKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKillsAvgPer10Min.ToString();
                    string QpmoltenCoreKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKillsMostInGame.ToString();
                    string QpoverloadKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.overloadKills.ToString();
                    string QpoverloadKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.overloadKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QptorbjornKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKills.ToString();
                    string QptorbjornKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKillsAvgPer10Min.ToString();
                    string QptorbjornKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKillsMostInGame.ToString();
                    string QpturretsDamageAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsDamageAvgPer10Min.ToString();
                    string QpturretsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKills.ToString();
                    string QpturretsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKillsAvgPer10Min.ToString();
                    string QpturretsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKillsMostInGame.ToString();

                    string CompmoltenCoreKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKills.ToString();
                    string CompmoltenCoreKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKillsAvgPer10Min.ToString();
                    string CompmoltenCoreKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKillsMostInGame.ToString();
                    string CompoverloadKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.overloadKills.ToString();
                    string CompoverloadKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.overloadKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string ComptorbjornKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKills.ToString();
                    string ComptorbjornKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKillsAvgPer10Min.ToString();
                    string ComptorbjornKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKillsMostInGame.ToString();
                    string CompturretsDamageAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsDamageAvgPer10Min.ToString();
                    string CompturretsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKills.ToString();
                    string CompturretsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKillsAvgPer10Min.ToString();
                    string CompturretsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKillsMostInGame.ToString();

                    string qpHeroSpecific = $"Molten Core Kills: **{QpmoltenCoreKills}**\nAverage Molten Core Kills Per 10 Minutes: **{QpmoltenCoreKillsAvgPer10Min}**\nMost Molten Core Kills In Game: **{QpmoltenCoreKillsMostInGame}**\nOverload Kills: **{QpoverloadKills}**\nMost Overload Kills In Game: **{QpoverloadKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nTorbjorn Kills: **{QptorbjornKills}**\nAverage Torbjorn Kills Per 10 Minutes: **{QptorbjornKillsAvgPer10Min}**\nMost Torbjorn Kills In Game: **{QptorbjornKillsMostInGame}**\nAverage Turret Damage Per 10 Minutes: **{QpturretsDamageAvgPer10Min}**\nTurret Kills: **{QpturretsKills}**\nAverage Turret Kills Per 10 Minutes: **{QpturretsKillsAvgPer10Min}**\nMost Turret Kills In Game: **{QpturretsKillsMostInGame}**";
                    string compHeroSpecific = $"Molten Core Kills: **{CompmoltenCoreKills}**\nAverage Molten Core Kills Per 10 Minutes: **{CompmoltenCoreKillsAvgPer10Min}**\nMost Molten Core Kills In Game: **{CompmoltenCoreKillsMostInGame}**\nOverload Kills: **{CompoverloadKills}**\nMost Overload Kills In Game: **{CompoverloadKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nTorbjorn Kills: **{ComptorbjornKills}**\nAverage Torbjorn Kills Per 10 Minutes: **{ComptorbjornKillsAvgPer10Min}**\nMost Torbjorn Kills In Game: **{ComptorbjornKillsMostInGame}**\nAverage Turret Damage Per 10 Minutes: **{CompturretsDamageAvgPer10Min}**\nTurret Kills: **{CompturretsKills}**\nAverage Turret Kills Per 10 Minutes: **{CompturretsKillsAvgPer10Min}**\nMost Turret Kills In Game: **{CompturretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "tracer")
                {
                    string QphealthRecovered = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecovered.ToString();
                    string QphealthRecoveredAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecoveredAvgPer10Min.ToString();
                    string QphealthRecoveredMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecoveredMostInGame.ToString();
                    string QppulseBombsAttached = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttached.ToString();
                    string QppulseBombsAttachedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttachedAvgPer10Min.ToString();
                    string QppulseBombsAttachedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttachedMostInGame.ToString();
                    string QppulseBombsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKills.ToString();
                    string QppulseBombsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKillsAvgPer10Min.ToString();
                    string QppulseBombsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string ComphealthRecovered = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecovered.ToString();
                    string ComphealthRecoveredAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecoveredAvgPer10Min.ToString();
                    string ComphealthRecoveredMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecoveredMostInGame.ToString();
                    string ComppulseBombsAttached = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttached.ToString();
                    string ComppulseBombsAttachedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttachedAvgPer10Min.ToString();
                    string ComppulseBombsAttachedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttachedMostInGame.ToString();
                    string ComppulseBombsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKills.ToString();
                    string ComppulseBombsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKillsAvgPer10Min.ToString();
                    string ComppulseBombsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"Health Recalled: **{QphealthRecovered}**\nAverage Health Recalled Per 10 Minutes: **{QphealthRecoveredAvgPer10Min}**\nMost Health Recalled In Game: **{QphealthRecoveredMostInGame}**\nPulse Bomb Attached: **{QppulseBombsAttached}**\nAverage Pulse Bombs Attached Per 10 Minutes: **{QppulseBombsAttachedAvgPer10Min}**\nMost Pulse Bombs Attached In Game: **{QppulseBombsAttachedMostInGame}**\nPulse Bomb Kills: **{QppulseBombsKills}**\nAverage Pulse Bomb Kills Per 10 Minutes: **{QppulseBombsKillsAvgPer10Min}**\nMost Pulse Bomb Kills In Game: **{QppulseBombsKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Health Recalled: **{ComphealthRecovered}**\nAverage Health Recalled Per 10 Minutes: **{ComphealthRecoveredAvgPer10Min}**\nMost Health Recalled In Game: **{ComphealthRecoveredMostInGame}**\nPulse Bomb Attached: **{ComppulseBombsAttached}**\nAverage Pulse Bombs Attached Per 10 Minutes: **{ComppulseBombsAttachedAvgPer10Min}**\nMost Pulse Bombs Attached In Game: **{ComppulseBombsAttachedMostInGame}**\nPulse Bomb Kills: **{ComppulseBombsKills}**\nAverage Pulse Bomb Kills Per 10 Minutes: **{ComppulseBombsKillsAvgPer10Min}**\nMost Pulse Bomb Kills In Game: **{ComppulseBombsKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "widowmaker")
                {
                    string QpscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpscopedAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpscopedCriticalHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string QpscopedCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string QpscopedCriticalHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string QpscopedCriticalHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpvenomMineKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKills.ToString();
                    string QpvenomMineKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKillsAvgPer10Min.ToString();
                    string QpvenomMineKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKillsMostInGame.ToString();

                    string CompscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompscopedAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompscopedCriticalHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string CompscopedCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string CompscopedCriticalHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string CompscopedCriticalHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompvenomMineKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKills.ToString();
                    string CompvenomMineKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKillsAvgPer10Min.ToString();
                    string CompvenomMineKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKillsMostInGame.ToString();

                    //recon assists
                    string CompreconAssists = dataObject.competitiveStats.careerStats[hero].assists.reconAssists.ToString();
                    string CompreconAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.reconAssistsAvgPer10Min.ToString();
                    string CompreconAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.reconAssistsMostInGame.ToString();
                    string QpreconAssists = dataObject.quickPlayStats.careerStats[hero].assists.reconAssists.ToString();
                    string QpreconAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.reconAssistsAvgPer10Min.ToString();
                    string QpreconAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.reconAssistsMostInGame.ToString();

                    string qpAssists = $"Recon Assists: **{QpreconAssists}**\nAverage Recon Assists Per 10 Minutes: **{QpreconAssistsAvgPer10Min}**\nMost Recon Assists In Game: **{QpreconAssistsMostInGame}**";
                    string compAssists = $"Recon Assists: **{CompreconAssists}**\nAverage Recon Assists Per 10 Minutes: **{CompreconAssistsAvgPer10Min}**\nMost Recon Assists In Game: **{CompreconAssistsMostInGame}**";
                    string qpHeroSpecific = $"Scoped Accuracy: **{QpscopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpscopedAccuracyBestInGame}**\nScoped Critical Hits Accuracy: **{QpscopedCriticalHitsAccuracy}**\nScoped Critical Hits: **{QpscopedCriticalHits}**\nAverage Scoped Critical Hits Per 10 Minutes: **{QpscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{QpscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nVenom Mine Kills: **{QpvenomMineKills}**\nAverage Venom Mine Kills Per 10 Minutes: **{QpvenomMineKillsAvgPer10Min}**\nMost Venom Mine Kills In Game: **{QpvenomMineKillsMostInGame}**";
                    string compHeroSpecific = $"Scoped Accuracy: **{CompscopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompscopedAccuracyBestInGame}**\nScoped Critical Hits Accuracy: **{CompscopedCriticalHitsAccuracy}**\nScoped Critical Hits: **{CompscopedCriticalHits}**\nAverage Scoped Critical Hits Per 10 Minutes: **{CompscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{CompscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nVenom Mine Kills: **{CompvenomMineKills}**\nAverage Venom Mine Kills Per 10 Minutes: **{CompvenomMineKillsAvgPer10Min}**\nMost Venom Mine Kills In Game: **{CompvenomMineKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "winston")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpjumpPackKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKills.ToString();
                    string QpjumpPackKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKillsAvgPer10Min.ToString();
                    string QpjumpPackKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKillsMostInGame.ToString();
                    string QpmeleeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKills.ToString();
                    string QpmeleeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKillsAvgPer10Min.ToString();
                    string QpmeleeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKillsMostInGame.ToString();
                    string QpplayersKnockedBack = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string QpplayersKnockedBackAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string QpplayersKnockedBackMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string QpprimalRageKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKills.ToString();
                    string QpprimalRageKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKillsAvgPer10Min.ToString();
                    string QpprimalRageKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKillsMostInGame.ToString();
                    string QpprimalRageMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpteslaCannonAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.teslaCannonAccuracy.ToString();
                    string QpweaponKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.weaponKills.ToString();

                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompjumpPackKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKills.ToString();
                    string CompjumpPackKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKillsAvgPer10Min.ToString();
                    string CompjumpPackKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKillsMostInGame.ToString();
                    string CompmeleeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKills.ToString();
                    string CompmeleeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKillsAvgPer10Min.ToString();
                    string CompmeleeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKillsMostInGame.ToString();
                    string CompplayersKnockedBack = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string CompplayersKnockedBackAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string CompplayersKnockedBackMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string CompprimalRageKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKills.ToString();
                    string CompprimalRageKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKillsAvgPer10Min.ToString();
                    string CompprimalRageKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKillsMostInGame.ToString();
                    string CompprimalRageMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompteslaCannonAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.teslaCannonAccuracy.ToString();
                    string CompweaponKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.weaponKills.ToString();

                    string qpHeroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nJump Pack Kills: **{QpjumpPackKills}**\nAverage Jump Pack Kills Per 10 Minutes: **{QpjumpPackKillsAvgPer10Min}**\nMost Jump Pack Kills In Game: **{QpjumpPackKillsMostInGame}**\nMelee Kills: **{QpmeleeKills}**\nAverage Melee Kills Per 10 Minutes: **{QpmeleeKillsAvgPer10Min}**\nMost Melee Kills In Game: **{QpmeleeKillsMostInGame}**\nPlayers Knocked Back: **{QpplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{QpplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{QpplayersKnockedBackMostInGame}**\nPrimal Rage Kills: **{QpprimalRageKills}**\nAverage Primal Rage Kills In 10 Minutes: **{QpprimalRageKillsAvgPer10Min}**\nMost Primal Rage Kills In Game: **{QpprimalRageKillsMostInGame}**\nPrimal Rage Melee Accuracy: **{QpprimalRageMeleeAccuracy}**\nTesla Cannon Accuracy: **{QpteslaCannonAccuracy}**\nWeapon Kils: **{QpweaponKills}**";
                    string compHeroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nJump Pack Kills: **{CompjumpPackKills}**\nAverage Jump Pack Kills Per 10 Minutes: **{CompjumpPackKillsAvgPer10Min}**\nMost Jump Pack Kills In Game: **{CompjumpPackKillsMostInGame}**\nMelee Kills: **{CompmeleeKills}**\nAverage Melee Kills Per 10 Minutes: **{CompmeleeKillsAvgPer10Min}**\nMost Melee Kills In Game: **{CompmeleeKillsMostInGame}**\nPlayers Knocked Back: **{CompplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{CompplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{CompplayersKnockedBackMostInGame}**\nPrimal Rage Kills: **{CompprimalRageKills}**\nAverage Primal Rage Kills In 10 Minutes: **{CompprimalRageKillsAvgPer10Min}**\nMost Primal Rage Kills In Game: **{CompprimalRageKillsMostInGame}**\nPrimal Rage Melee Accuracy: **{CompprimalRageMeleeAccuracy}**\nTesla Cannon Accuracy: **{CompteslaCannonAccuracy}**\nWeapon Kils: **{CompweaponKills}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "wreckingBall")
                {
                    string QpplayersKnockedBack = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string QpplayersKnockedBackAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string QpplayersKnockedBackMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompplayersKnockedBack = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string CompplayersKnockedBackAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string CompplayersKnockedBackMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string qpHeroSpecific = $"Players Knocked Back: **{QpplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{QpplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{QpplayersKnockedBackMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    string compHeroSpecific = $"Players Knocked Back: **{CompplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{CompplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{CompplayersKnockedBackMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zarya")
                {
                    string QpaverageEnergy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.averageEnergy.ToString();
                    string QpaverageEnergyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.averageEnergyBestInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpgravitonSurgeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKills.ToString();
                    string QpgravitonSurgeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKillsAvgPer10Min.ToString();
                    string QpgravitonSurgeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKillsMostInGame.ToString();
                    string QphighEnergyKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKills.ToString();
                    string QphighEnergyKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKillsAvgPer10Min.ToString();
                    string QphighEnergyKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKillsMostInGame.ToString();
                    string QpprimaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string QpprojectedBarriersApplied = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersApplied.ToString();
                    string QpprojectedBarriersAppliedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersAppliedAvgPer10Min.ToString();
                    string QpprojectedBarriersAppliedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersAppliedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string CompaverageEnergy = dataObject.competitiveStats.careerStats[hero].heroSpecific.averageEnergy.ToString();
                    string CompaverageEnergyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.averageEnergyBestInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompgravitonSurgeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKills.ToString();
                    string CompgravitonSurgeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKillsAvgPer10Min.ToString();
                    string CompgravitonSurgeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKillsMostInGame.ToString();
                    string ComphighEnergyKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKills.ToString();
                    string ComphighEnergyKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKillsAvgPer10Min.ToString();
                    string ComphighEnergyKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKillsMostInGame.ToString();
                    string CompprimaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string CompprojectedBarriersApplied = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersApplied.ToString();
                    string CompprojectedBarriersAppliedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersAppliedAvgPer10Min.ToString();
                    string CompprojectedBarriersAppliedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersAppliedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive and defensive assists
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();
                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Average Energy: **{QpaverageEnergy}**\nBest Average Energy In Game: **{QpaverageEnergyBestInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nGraviton Surge Kills: **{QpgravitonSurgeKills}**\nAverage Graviton Surge Kills Per 10 Minutes: **{QpgravitonSurgeKillsAvgPer10Min}**\nMost Graviton Surge Kills In Game: **{QpgravitonSurgeKillsMostInGame}**\nHigh Energy Kills: **{QphighEnergyKills}**\nAverage High Energy Kills Per 10 Minutes: **{QphighEnergyKillsAvgPer10Min}**\nMost High Energy Kills In Game: **{QphighEnergyKillsMostInGame}**\nPrimary Fire Accuracy: **{QpprimaryFireAccuracy}**\nProjected Barriers Applied: **{QpprojectedBarriersApplied}**\nAverage Projected Barriers Provided Per 10 Minutes: **{QpprojectedBarriersAppliedAvgPer10Min}**\nMost Projected Barriers Provided In Game: **{QpprojectedBarriersAppliedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}*";
                    string compHeroSpecific = $"Average Energy: **{CompaverageEnergy}**\nBest Average Energy In Game: **{CompaverageEnergyBestInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nGraviton Surge Kills: **{CompgravitonSurgeKills}**\nAverage Graviton Surge Kills Per 10 Minutes: **{CompgravitonSurgeKillsAvgPer10Min}**\nMost Graviton Surge Kills In Game: **{CompgravitonSurgeKillsMostInGame}**\nHigh Energy Kills: **{ComphighEnergyKills}**\nAverage High Energy Kills Per 10 Minutes: **{ComphighEnergyKillsAvgPer10Min}**\nMost High Energy Kills In Game: **{ComphighEnergyKillsMostInGame}**\nPrimary Fire Accuracy: **{CompprimaryFireAccuracy}**\nProjected Barriers Applied: **{CompprojectedBarriersApplied}**\nAverage Projected Barriers Provided Per 10 Minutes: **{CompprojectedBarriersAppliedAvgPer10Min}**\nMost Projected Barriers Provided In Game: **{CompprojectedBarriersAppliedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}*";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zenyatta")
                {
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QptranscendenceHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.transcendenceHealing.ToString();
                    string QptranscendenceHealingBest = dataObject.quickPlayStats.careerStats[hero].heroSpecific.transcendenceHealingBest.ToString();

                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string ComptranscendenceHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.transcendenceHealing.ToString();
                    string ComptranscendenceHealingBest = dataObject.competitiveStats.careerStats[hero].heroSpecific.transcendenceHealingBest.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string qpAssists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string compAssists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string qpHeroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nTranscendence Healing: **{QptranscendenceHealing}**\nBest Transcendence Healing In Game: **{QptranscendenceHealingBest}**";
                    string compHeroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nTranscendence Healing: **{ComptranscendenceHealing}**\nBest Transcendence Healing In Game: **{ComptranscendenceHealingBest}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, qpAvg, qpBest, qpTotal, qpMisc, qpAssists, compAssists, qpHeroSpecific, compHeroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Competitive Averages", "Competitive Best", "Competitive Totals", "Competitive Miscellaneous", "Quickplay Averages", "Quickplay Best", "Quickplay Totals", "Quickplay Miscellaneous", "Quickplay Assists", "Competitive Assists", "Quickplay Hero Specific", "Competitive Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync("Make sure you have played Competitive and Quickplay with this hero, otherwise check your command.\n**w!myowhs <hero> Ex: w!myowhs dVa**");
            }
        }

        [Command("myowherostatsqp")]
        [Summary("Get your statistics for a specific hero on Quickplay.")]
        [Alias("myowhsqp")]
        [Remarks("w!myowherostatsqp <hero> Ex: w!myowherostatsqp dVa")]
        [Cooldown(10)]
        public async Task GetMyOwHeroStatsQP(string hero)
        {
            try
            {
                string originalhero = hero;
                var config = GlobalUserAccounts.GetUserAccount(Context.User);
                hero = hero.ToLower();
                hero = GetHero(hero);

                var json = await Global.SendWebRequest($"https://ow-api.com/v1/stats/{config.OverwatchPlatform}/{config.OverwatchRegion}/{config.OverwatchID}/heroes/{hero}");

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string endorsementIcon = dataObject.endorsementIcon.ToString();
                string playerIcon = dataObject.icon.ToString();
                string srIcon = dataObject.ratingIcon.ToString();

                string QpAllDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.allDamageDoneAvgPer10Min.ToString();
                string QpBarrierDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.barrierDamageDoneAvgPer10Min.ToString();
                string QpCriticalsAvg = dataObject.quickPlayStats.careerStats[hero].average.criticalHitsAvgPer10Min.ToString();
                string QpDeathAvg = dataObject.quickPlayStats.careerStats[hero].average.deathsAvgPer10Min.ToString();
                string QpElimAvg = dataObject.quickPlayStats.careerStats[hero].average.eliminationsAvgPer10Min.ToString();
                string QpElimPerLife = dataObject.quickPlayStats.careerStats[hero].average.eliminationsPerLife.ToString();
                string QpFinalBlowAvg = dataObject.quickPlayStats.careerStats[hero].average.finalBlowsAvgPer10Min.ToString();
                string QpHeroDamageAvg = dataObject.quickPlayStats.careerStats[hero].average.heroDamageDoneAvgPer10Min.ToString();
                string QpMeleeAvg = dataObject.quickPlayStats.careerStats[hero].average.meleeFinalBlowsAvgPer10Min.ToString();
                string QpObjKillsAvg = dataObject.quickPlayStats.careerStats[hero].average.objectiveKillsAvgPer10Min.ToString();
                string QpObjTimeAvg = dataObject.quickPlayStats.careerStats[hero].average.objectiveTimeAvgPer10Min.ToString();
                string QpSoloKillAvg = dataObject.quickPlayStats.careerStats[hero].average.soloKillsAvgPer10Min.ToString();
                string QpOnFireAvg = dataObject.quickPlayStats.careerStats[hero].average.timeSpentOnFireAvgPer10Min.ToString();
                //best
                string QpAllDamageInGame = dataObject.quickPlayStats.careerStats[hero].best.allDamageDoneMostInGame.ToString();
                string QpAllDamageInLife = dataObject.quickPlayStats.careerStats[hero].best.allDamageDoneMostInLife.ToString();
                string QpBarrierDamageInGame = dataObject.quickPlayStats.careerStats[hero].best.barrierDamageDoneMostInGame.ToString();
                string QpCritMostInGame = dataObject.quickPlayStats.careerStats[hero].best.criticalHitsMostInGame.ToString();
                string QpCritMostInLife = dataObject.quickPlayStats.careerStats[hero].best.criticalHitsMostInLife.ToString();
                string QpElimMostInLife = dataObject.quickPlayStats.careerStats[hero].best.eliminationsMostInLife.ToString();
                string QpElimMostInGame = dataObject.quickPlayStats.careerStats[hero].best.eliminationsMostInGame.ToString();
                string QpFinalBlowMostInGame = dataObject.quickPlayStats.careerStats[hero].best.finalBlowsMostInGame.ToString();
                string QpHeroDmgMostInGame = dataObject.quickPlayStats.careerStats[hero].best.heroDamageDoneMostInGame.ToString();
                string QpHeroDmgMostInLife = dataObject.quickPlayStats.careerStats[hero].best.heroDamageDoneMostInLife.ToString();
                string QpKillStreakBest = dataObject.quickPlayStats.careerStats[hero].best.killsStreakBest.ToString();
                string QpMeleeFinalBlowMostInGame = dataObject.quickPlayStats.careerStats[hero].best.meleeFinalBlowsMostInGame.ToString();
                string QpMultikillBest = dataObject.quickPlayStats.careerStats[hero].best.multikillsBest.ToString();
                string QpObjKillMostInGame = dataObject.quickPlayStats.careerStats[hero].best.objectiveKillsMostInGame.ToString();
                string QpObjTimeMostInGame = dataObject.quickPlayStats.careerStats[hero].best.objectiveTimeMostInGame.ToString();
                string QpSoloKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].best.soloKillsMostInGame.ToString();
                string QpOnFireMostInGame = dataObject.quickPlayStats.careerStats[hero].best.timeSpentOnFireMostInGame.ToString();
                string QpWeaponAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].best.weaponAccuracyBestInGame.ToString();
                //combat
                string QpBarrierDmgDone = dataObject.quickPlayStats.careerStats[hero].combat.barrierDamageDone.ToString();
                string QpCriticalHits = dataObject.quickPlayStats.careerStats[hero].combat.criticalHits.ToString();
                string QpCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.criticalHitsAccuracy.ToString();
                string QpDamageDone = dataObject.quickPlayStats.careerStats[hero].combat.damageDone.ToString();
                string QpDeaths = dataObject.quickPlayStats.careerStats[hero].combat.deaths.ToString();
                string QpElims = dataObject.quickPlayStats.careerStats[hero].combat.eliminations.ToString();
                string QpFinalBlows = dataObject.quickPlayStats.careerStats[hero].combat.finalBlows.ToString();
                string QpHeroDmg = dataObject.quickPlayStats.careerStats[hero].combat.heroDamageDone.ToString();
                string QpMeleeFinalBlows = dataObject.quickPlayStats.careerStats[hero].combat.meleeFinalBlows.ToString();
                string QpMultikills = dataObject.quickPlayStats.careerStats[hero].combat.multikills.ToString();
                string QpObjKills = dataObject.quickPlayStats.careerStats[hero].combat.objectiveKills.ToString();
                string QpObjTime = dataObject.quickPlayStats.careerStats[hero].combat.objectiveTime.ToString();
                string QpMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.quickMeleeAccuracy.ToString();
                string QpSoloKills = dataObject.quickPlayStats.careerStats[hero].combat.soloKills.ToString();
                string QpOnFire = dataObject.quickPlayStats.careerStats[hero].combat.timeSpentOnFire.ToString();
                string QpWeaponAccuracy = dataObject.quickPlayStats.careerStats[hero].combat.weaponAccuracy.ToString();
                //misc stuff
                string QpGamesWon = dataObject.quickPlayStats.careerStats[hero].game.gamesWon.ToString();
                string QpTimePlayed = dataObject.quickPlayStats.careerStats[hero].game.timePlayed.ToString();
                string QpCards = dataObject.quickPlayStats.careerStats[hero].matchAwards.cards.ToString();
                string QpMedals = dataObject.quickPlayStats.careerStats[hero].matchAwards.medals.ToString();
                string QpMedalsBronze = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsBronze.ToString();
                string QpMedalsGold = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsGold.ToString();
                string QpMedalsSilver = dataObject.quickPlayStats.careerStats[hero].matchAwards.medalsSilver.ToString();
                string QpElimsPerLife = dataObject.quickPlayStats.topHeroes[hero].eliminationsPerLife.ToString();

                string qpAvg = $"All Damage Done per 10 Minutes: **{QpAllDamageAvg}**\nBarrier Damage Done per 10 Minutes: **{QpBarrierDamageAvg}**\nHero Damage Done per 10 Minutes: **{QpHeroDamageAvg}**\nCritical Hits per 10 Minutes: **{QpCriticalsAvg}**\nDeaths per 10 Minutes: **{QpDeathAvg}**\nEliminations per 10 Minutes: **{QpElimAvg}**\nEliminations per Life: **{QpElimPerLife}**\nFinal Blows per 10 Minutes: **{QpFinalBlowAvg}**\nMelee Final Blows per 10 Minutes: **{QpMeleeAvg}**\nObjective Time per 10 Minutes: **{QpObjTimeAvg}**\nObjective Kills per 10 Minutes: **{QpObjKillsAvg}**\nSolo Kills per 10 Minutes: **{QpSoloKillAvg}**\nTime on Fire per 10 Minutes: **{QpOnFireAvg}**";
                string qpBest = $"All Damage in Game: **{QpAllDamageInGame}**\nAll Damage in Life: **{QpAllDamageInLife}**\nBarrier Damage in Game: **{QpBarrierDamageInGame}**\nCriticals in Game: **{QpCritMostInGame}**\nCriticals in Life: **{QpCritMostInLife}**\nEliminations in Game: **{QpElimMostInGame}**\nEliminations in Life: **{QpElimMostInLife}**\nFinal Blows in Game: **{QpFinalBlowMostInGame}**\nHero Damage in Game: **{QpHeroDmgMostInGame}**\nHero Damage in Life: **{QpHeroDmgMostInLife}**\nKill Streak: **{QpKillStreakBest}**\nMelee Final Blows in Game: **{QpMeleeFinalBlowMostInGame}**\nMultikill: **{QpMultikillBest}**\nObjective Kills in Game: **{QpObjKillMostInGame}**\nObjective Time in Game: **{QpObjTimeMostInGame}**\nSolo Kills in Game: **{QpSoloKillsMostInGame}**\nOn Fire Time in Game: **{QpOnFireMostInGame}**\nWeapon Accuracy in Game: **{QpWeaponAccuracyBestInGame}**";
                string qpTotal = $"Barrier Damage Done: **{QpBarrierDmgDone}**\nCritical Hits: **{QpCriticalHits}**\nObjective Time in Game: **{QpObjTimeMostInGame}**\nCritical Hit Accuracy: **{QpCriticalHitsAccuracy}**\nDamage Done: **{QpDamageDone}**\nDeaths: **{QpDeaths}**\nEliminations: **{QpElims}**\nFinal Blows: **{QpFinalBlows}**\nHero Damage: **{QpHeroDmg}**\nMelee Final Blows: **{QpMeleeFinalBlows}**\nMultikills: **{QpMultikills}**\nObjective Kills: **{QpObjKills}**\nObjective Time: **{QpObjTime}**\nMelee Accuracy: **{QpMeleeAccuracy}**\nSolo Kills: **{QpSoloKills}**\nOn Fire Time: **{QpOnFire}**\nWeapon Accuracy: **{QpWeaponAccuracy}**";
                string qpMisc = $"Games Won: **{QpGamesWon}**\nTime Played: **{QpTimePlayed}**\nCards: **{QpCards}**\nTotal Medals: **{QpMedals}**\nGold Medals: **{QpMedalsGold}**\nSilver Medals: **{QpMedalsSilver}**\nBronze Medals: **{QpMedalsBronze}**\nEliminations per Life: **{QpElimsPerLife}**\n";

                if (hero == "ana")
                {
                    string QpBioticKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticGrenadeKills.ToString();
                    string QpEnemiesSlept = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSlept.ToString();
                    string QpEnemiesSleptPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSleptAvgPer10Min.ToString();
                    string QpEnemiesSleptMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesSleptMostInGame.ToString();
                    string QpNanoAssists = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssists.ToString();
                    string QpNanoAssistsPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssistsAvgPer10Min.ToString();
                    string QpMostNanoAssistsIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostAssistsMostInGame.ToString();
                    string QpNanosApplied = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsApplied.ToString();
                    string QpNanosAppliedPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsAppliedAvgPer10Min.ToString();
                    string QpNanoAppliedMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.nanoBoostsAppliedMostInGame.ToString();
                    string QpScopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpScopedAccuracyBestIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpSecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpSelfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpSelfHealingPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpSelfHealingMostIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpUnscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.unscopedAccuracy.ToString();
                    string QpUnscopedAccuracyBestIG = dataObject.quickPlayStats.careerStats[hero].heroSpecific.unscopedAccuracyBestInGame.ToString();

                    //healing stats for healers

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Biotic Grenade Kills: **{QpBioticKills}**\nEnemies Slept: **{QpEnemiesSlept}**\nAverage Enemies Slept per 10 Minutes: **{QpEnemiesSleptPer10Min}**\nMost Enemies Slept In Game: **{QpEnemiesSleptPer10Min}**\nNano Boost Assists: **{QpNanoAssists}**\nNano Boost Assists Per 10 Minutes: **{QpNanosAppliedPer10Min}**\nMost Nano Boost Assists In Game: **{QpMostNanoAssistsIG}**\nNano Boosts Applied: **{QpNanosApplied}**\nNano Boosts Applied Per 10 Minutes: **{QpNanosAppliedPer10Min}**\nNano Boosts Applied Most In Game: **{QpNanoAppliedMostIG}**\nScoped Accuracy: **{QpScopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpScopedAccuracyBestIG}**\nSecondary Fire Accuracy: **{QpSecondaryFireAccuracy}**\nSelf Healing: **{QpSelfHealing}**\nSelf Healing Per 10 Minutes: **{QpSelfHealingPer10Min}**\nMost Self Healing In Game: **{QpSelfHealingMostIG}**\nUnscoped Accuracy: **{QpUnscopedAccuracy}**\nBest Unscoped Accuracy In Game: **{QpScopedAccuracyBestIG}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "ashe")
                {
                    string QpbobKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKills.ToString();
                    string QpbobKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKillsAvgPer10Min.ToString();
                    string QpbobKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bobKillsMostInGame.ToString();
                    string QpcoachGunKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKills.ToString();
                    string QpcoachGunKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKillsAvgPer10Min.ToString();
                    string QpcoachGunKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coachGunKillsMostInGame.ToString();
                    string QpdynamiteKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKills.ToString();
                    string QpdynamiteKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKillsAvgPer10Min.ToString();
                    string QpdynamiteKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dynamiteKillsMostInGame.ToString();
                    string QpscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpscopedAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpscopedCriticalHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string QpscopedCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string QpscopedCriticalHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string QpscopedCriticalHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"BOB Kills: **{QpbobKills}**\nAverage BOB Kills Per 10 Minutes: **{QpbobKillsAvgPer10Min}**\nMost BOB Kills In Game: **{QpbobKillsMostInGame}**\nCoach Gun Kills: **{QpcoachGunKills}**\nAverage Coach Gun Kills Per 10 Minutes: **{QpcoachGunKillsAvgPer10Min}**\nMost Coach Gun Kills In Game: **{QpcoachGunKillsMostInGame}**\nDynamite Kills: **{QpdynamiteKills}**\nAverage Dynamite Kills Per 10 Minutes: **{QpdynamiteKillsAvgPer10Min}**\nMost Dynamite Kills In Game Kills: **{QpdynamiteKillsMostInGame}**\nScoped Accuracy: **{QpscopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpscopedAccuracyBestInGame}**\nScoped Creitical Hits: **{QpscopedCriticalHits}**\nScoped Critical Hits Accuracy: **{QpscopedCriticalHitsAccuracy}**\nAverage Scoped Critical Hits Per 10 Minutes: **{QpscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{QpscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "bastion")
                {
                    string QpreconKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKills.ToString();
                    string QpreconKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKillsAvgPer10Min.ToString();
                    string QpreconKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.reconKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].selfHealingAvgPer10Min.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpsentryKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKills.ToString();
                    string QpsentryKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKillsAvgPer10Min.ToString();
                    string QpsentryKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryKillsMostInGame.ToString();
                    string QptankKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKills.ToString();
                    string QptankKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKillsAvgPer10Min.ToString();
                    string QptankKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.tankKillsMostInGame.ToString();

                    string heroSpecific = $"Recon Kills: **{QpreconKills}**\nAverage Recon Kills Per 10 Minutes: **{QpreconKillsAvgPer10Min}**\nMost Recon Kills In Game: **{QpreconKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nSentry Kills: **{QpsentryKills}**\nAverage Sentry Kills Per 10 Minutes: **{QpsentryKillsAvgPer10Min}**\nMost Sentry Kills In Game: **{QpsentryKillsMostInGame}**\nTank Kills: **{QptankKills}**\nAverage Tank Kills Per 10 Minutes: **{QpreconKills}**\nMost Tank Kills In Game: **{QptankKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "brigitte")
                {
                    string QparmorProvided = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvided.ToString();
                    string QparmorProvidedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvidedAvgPer10Min.ToString();
                    string QparmorProvidedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.armorProvidedMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpinspireUptimePercentage = dataObject.quickPlayStats.careerStats[hero].heroSpecific.inspireUptimePercentage.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();

                    //healing stats for healers
                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Armor Provided: **{QparmorProvided}**\nAverage Armor Provided Per 10 Minutes: **{QparmorProvidedAvgPer10Min}**\nMost Armor Provided In Game: **{QparmorProvidedMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nInspire Uptime Percentage: **{QpinspireUptimePercentage}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "dVa")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpmechDeaths = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechDeaths.ToString();
                    string QpmechsCalled = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalled.ToString();
                    string QpmechsCalledAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalledAvgPer10Min.ToString();
                    string QpmechsCalledMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.mechsCalledMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfDestructKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKills.ToString();
                    string QpselfDestructKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKillsAvgPer10Min.ToString();
                    string QpselfDestructKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfDestructKillsMostInGame.ToString();

                    string heroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nMech Deaths: **{QpmechDeaths}**\nMechs Called: **{QpmechsCalled}**\nAverage Mechs Called Per 10 Minutes: **{QpmechsCalledAvgPer10Min}**\nMost Mechs Called In Game: **{QpmechsCalledMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Destruct Kills: **{QpselfDestructKills}**\nAverage Self Destruct Kills Per 10 Minutes: **{QpselfDestructKillsAvgPer10Min}**\nMost Self Destruct Kills In Game: **{QpselfDestructKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "doomfist")
                {
                    string QpabilityDamageDone = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.barrierDamageDone.ToString();
                    string QpabilityDamageDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.abilityDamageDoneAvgPer10Min.ToString();
                    string QpabilityDamageDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.abilityDamageDoneMostInGame.ToString();
                    string QpmeteorStrikeKills = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKills.ToString();
                    string QpmeteorStrikeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsAvgPer10Min.ToString();
                    string QpmeteorStrikeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.secondaryFireAccuracy.ToString();
                    string QpshieldsCreated = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreated.ToString();
                    string QpshieldsCreatedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreatedAvgPer10Min.ToString();
                    string QpshieldsCreatedMostInGame = dataObject.quickPlayStats.careerStats[hero].abilityDamageDone.shieldsCreatedMostInGame.ToString();

                    string heroSpecific = $"Ability Damage Done: **{QpabilityDamageDone}**\nAverage Ability Damage Done Per 10 Minutes: **{QpabilityDamageDoneAvgPer10Min}**\nMost Ability Damage Done In Game: **{QpabilityDamageDoneMostInGame}**\nMeteor Strike Kills: **{QpmeteorStrikeKills}**\nAverage Meteor Strike Kills Per 10 Minutes: **{QpmeteorStrikeKillsAvgPer10Min}**\nMost Meteor Strike Kills In Game: **{QpmeteorStrikeKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nShields Created: **{QpshieldsCreated}**\nAverage Shields Created Per 10 Minutes: **{QpshieldsCreatedAvgPer10Min}**\nMost Shields Created In Game: **{QpshieldsCreatedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "genji")
                {
                    string QpdamageReflected = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflected.ToString();
                    string QpdamageReflectedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflectedAvgPer10Min.ToString();
                    string QpdamageReflectedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageReflectedMostInGame.ToString();
                    string QpdeflectionKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deflectionKills.ToString();
                    string QpdragonbladesKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKills.ToString();
                    string QpdragonbladesKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKillsAvgPer10Min.ToString();
                    string QpdragonbladesKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.dragonbladesKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Damage Deflected: **{QpdamageReflected}**\nAverage Damage Deflected Per 10 Minutes: **{QpdamageReflectedMostInGame}**\nMost Damage Deflected In Game: **{QpdamageReflectedMostInGame}**\nDeflection Kills: **{QpdeflectionKills}**\nDragonblade Kills: **{QpdragonbladesKills}**\nAverage Dragonblade Kills Per 10 Minutes: **{QpdragonbladesKillsAvgPer10Min}**\nMost Dragonblade Kills In Game: **{QpdragonbladesKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "hanzo")
                {
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpstormArrowKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKills.ToString();
                    string QpstormArrowKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKillsAvgPer10Min.ToString();
                    string QpstormArrowKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.stormArrowKillsMostInGame.ToString();

                    string heroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nStorm Arrow Kills: **{QpstormArrowKills}**\nAverage Storm Arrow Kills Per 10 Minutes: **{QpstormArrowKillsAvgPer10Min}**\nMost Storm Arrow Kills In Game: **{QpstormArrowKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "junkrat")
                {
                    string QpconcussionMineKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKills.ToString();
                    string QpconcussionMineKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKillsAvgPer10Min.ToString();
                    string QpconcussionMineKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.concussionMineKillsMostInGame.ToString();
                    string QpenemiesTrapped = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrapped.ToString();
                    string QpenemiesTrappedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrappedAvgPer10Min.ToString();
                    string QpenemiesTrappedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesTrappedMostInGame.ToString();
                    string QpripTireKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKills.ToString();
                    string QpripTireKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKillsAvgPer10Min.ToString();
                    string QpripTireKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.ripTireKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive assists

                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Concussion Mine Kills: **{QpconcussionMineKills}**\nAverage Concussion Mine Kills Per 10 Minutes: **{QpconcussionMineKillsAvgPer10Min}**\nMost Concussion Mine Kills in Game: **{QpconcussionMineKillsMostInGame}**\nEnemies Trapped: **{QpenemiesTrapped}**\nAverage Enemies Trapped Per 10 Minutes: **{QpenemiesTrappedAvgPer10Min}**\nMost Enemies Trapped In Game: **{QpenemiesTrappedMostInGame}**\nRip Tire Kills: **{QpripTireKills}**\nAverage Rip Tire Kills Per 10 Minutes: **{QpripTireKillsAvgPer10Min}**\nMost Rip Tire Kills In Game: **{QpripTireKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "lucio")
                {
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpsoundBarriersProvided = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvided.ToString();
                    string QpsoundBarriersProvidedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvidedAvgPer10Min.ToString();
                    string QpsoundBarriersProvidedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.soundBarriersProvidedMostInGame.ToString();

                    //healing stats for healers
                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\n:Most Self Healing In Game **{QpselfHealingMostInGame}**\nSound Barriers Provided: **{QpsoundBarriersProvided}**\nAverage Sound Barriers Provided Per 10 minutes: **{QpsoundBarriersProvidedAvgPer10Min}**\nMost Sound barriers Provided In Game: **{QpsoundBarriersProvidedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mccree")
                {
                    string QpdeadeyeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKills.ToString();
                    string QpdeadeyeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKillsAvgPer10Min.ToString();
                    string QpdeadeyeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deadeyeKillsMostInGame.ToString();
                    string QpfanTheHammerKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKills.ToString();
                    string QpfanTheHammerKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKillsAvgPer10Min.ToString();
                    string QpfanTheHammerKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fanTheHammerKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Deadeye Kills: **{QpdeadeyeKills}**\nAverage Deadeye Kills Per 10 Minutes: **{QpdeadeyeKillsAvgPer10Min}**\nMost Deadeye Kills In Game: **{QpdeadeyeKillsMostInGame}**\nFan The Hammer Kills: **{QpfanTheHammerKills}**\nAverage Fan The Hammer Kills Per 10 Minutes: **{QpfanTheHammerKillsAvgPer10Min}**\nMost Fan The Hammer Kills In Game: **{QpfanTheHammerKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mei")
                {
                    string QpblizzardKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKills.ToString();
                    string QpblizzardKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKillsAvgPer10Min.ToString();
                    string QpblizzardKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blizzardKillsMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpenemiesFrozen = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozen.ToString();
                    string QpenemiesFrozenAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozenAvgPer10Min.ToString();
                    string QpenemiesFrozenMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesFrozenMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //offensive assists

                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Blizzard Kills: **{QpblizzardKills}**\nAverage Blizzard Kills Per 10 Minutes: **{QpblizzardKillsAvgPer10Min}**\nMost Blizzard Kills In Game: **{QpblizzardKillsMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nEnemies Frozen: **{QpenemiesFrozen}**\nAverage Enemies Frozen: **{QpenemiesFrozenAvgPer10Min}**\nMost Enemies Frozen In Game: **{QpenemiesFrozenMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mercy")
                {
                    string QpblasterKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKills.ToString();
                    string QpblasterKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKillsAvgPer10Min.ToString();
                    string QpblasterKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.blasterKillsMostInGame.ToString();
                    string QpdamageAmplified = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string QpdamageAmplifiedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string QpdamageAmplifiedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string QpplayersResurrected = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrected.ToString();
                    string QpplayersResurrectedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrectedAvgPer10Min.ToString();
                    string QpplayersResurrectedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersResurrectedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Blaster Kills: **{QpblasterKills}**\nAverage Blaster Kills Per 10 Minutes: **{QpblasterKillsAvgPer10Min}**\nMost Blaster Kills In Game: **{QpblasterKillsMostInGame}**\nDamage Amplified: **{QpdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{QpdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{QpdamageAmplifiedMostInGame}**\nPlayers Resurrected: **{QpplayersResurrected}**\nAverage Players Resurrected Per 10 Minutes: **{QpplayersResurrectedAvgPer10Min}**\nMost Players Ressurected In Game: **{QpplayersResurrectedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "moira")
                {
                    string QpcoalescenceHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealing.ToString();
                    string QpcoalescenceHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealingAvgPer10Min.ToString();
                    string QpcoalescenceHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceHealingMostInGame.ToString();
                    string QpcoalescenceKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKills.ToString();
                    string QpcoalescenceKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKillsAvgPer10Min.ToString();
                    string QpcoalescenceKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.coalescenceKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Coalescence Healing: **{QpcoalescenceHealing}**\nAverage Coalescence Healing Per 10 Minutes: **{QpcoalescenceHealingAvgPer10Min}**\nMost Coalescence Healing In Game: **{QpcoalescenceHealingMostInGame}**\nCoalescence Kills: **{QpcoalescenceKills}**\nAverage Coalescence Kills Per 10 Minutes: **{QpcoalescenceKillsAvgPer10Min}**\nMost Coalescence Kills In Game: **{QpcoalescenceKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "orisa")
                {
                    string QpdamageAmplified = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string QpdamageAmplifiedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string QpdamageAmplifiedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpsuperchargerAssists = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssists.ToString();
                    string QpsuperchargerAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssistsAvgPer10Min.ToString();
                    string QpsuperchargerAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.superchargerAssistsMostInGame.ToString();

                    //offensive assists
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Damage Amplified: **{QpdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{QpdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{QpdamageAmplifiedMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSupercharger Assists: **{QpsuperchargerAssists}**\nAverage Supercharger Assists Per 10 Minutes: **{QpsuperchargerAssistsAvgPer10Min}**\nMost Supercharger Assists In Game: **{QpsuperchargerAssistsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "pharah")
                {
                    string QpbarrageKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKills.ToString();
                    string QpbarrageKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKillsAvgPer10Min.ToString();
                    string QpbarrageKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.barrageKillsMostInGame.ToString();
                    string QpdirectHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.directHitsAccuracy.ToString();
                    string QprocketDirectHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHits.ToString();
                    string QprocketDirectHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHitsAvgPer10Min.ToString();
                    string QprocketDirectHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketDirectHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Barrage Kills: **{QpbarrageKills}**\nAverage Barrage Kills Per 10 Minutes: **{QpbarrageKillsAvgPer10Min}**\nMost Barrage Kills In Game: **{QpbarrageKillsMostInGame}**\nDirect Hits Accuracy: **{QpdirectHitsAccuracy}**\nRocket Dirrect Hits: **{QprocketDirectHits}**\nAverage Rocket Direct Hits Per 10 Minutes: **{QprocketDirectHitsAvgPer10Min}**\nMost Rocket Direct Hits In Game: **{QprocketDirectHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reaper")
                {
                    string QpdeathsBlossomKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKills.ToString();
                    string QpdeathsBlossomKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKillsAvgPer10Min.ToString();
                    string QpdeathsBlossomKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.deathsBlossomKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string heroSpecific = $"Death Blossom Kills: **{QpdeathsBlossomKills}**\nAverage Death Blossom Kills Per 10 Minutes: **{QpdeathsBlossomKillsAvgPer10Min}**\nMost Death Blossom Kills In Game: **{QpdeathsBlossomKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reinhardt")
                {
                    string QpchargeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKills.ToString();
                    string QpchargeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKillsAvgPer10Min.ToString();
                    string QpchargeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.chargeKillsMostInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpearthshatterKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKills.ToString();
                    string QpearthshatterKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKillsAvgPer10Min.ToString();
                    string QpearthshatterKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.earthshatterKillsMostInGame.ToString();
                    string QpfireStrikeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKills.ToString();
                    string QpfireStrikeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKillsAvgPer10Min.ToString();
                    string QpfireStrikeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.fireStrikeKillsMostInGame.ToString();
                    string QprocketHammerMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.rocketHammerMeleeAccuracy.ToString();

                    string heroSpecific = $"Charge Kills: **{QpchargeKills}**\nAverage Charge Kills Per 10 Minutes: **{QpchargeKillsAvgPer10Min}**\nMost Charge Kills In Game: **{QpchargeKillsMostInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nEarthshatter Kills: **{QpearthshatterKills}**\nAverage Earthshatter Kills Per 10 Minutes: **{QpearthshatterKillsAvgPer10Min}**\nMost Earthshatter Kills In Game: **{QpearthshatterKillsMostInGame}**\nFire Strike Kills: **{QpfireStrikeKills}**\nFire Strike Kills: **{QpfireStrikeKills}**\nAverage Fire Strike Kills Per 10 Minutes: **{QpfireStrikeKillsAvgPer10Min}**\nMost Fire Strike Kills In Game: **{QpfireStrikeKillsMostInGame}**\nRocket Hammer Melee Accuracy: **{QprocketHammerMeleeAccuracy}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "roadhog")
                {
                    string QpenemiesHooked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHooked.ToString();
                    string QpenemiesHookedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHookedAvgPer10Min.ToString();
                    string QpenemiesHookedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHookedMostInGame.ToString();
                    string QphookAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hookAccuracy.ToString();
                    string QphookAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hookAccuracyBestInGame.ToString();
                    string QphooksAttempted = dataObject.quickPlayStats.careerStats[hero].heroSpecific.hooksAttempted.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QpwholeHogKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKills.ToString();
                    string QpwholeHogKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKillsAvgPer10Min.ToString();
                    string QpwholeHogKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.wholeHogKillsMostInGame.ToString();

                    //offensive assists
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Enemies Hooked: **{QpenemiesHooked}**\nAverage Enemies Hooked Per 10 Minutes: **{QpenemiesHookedAvgPer10Min}**\nMost Enemies Hooked In Game: **{QpenemiesHookedMostInGame}**\nHook Accuracy: **{QphookAccuracy}**\nBest Hook Accuracy In Game: **{QphookAccuracyBestInGame}**\nHooks Attempted: **{QphooksAttempted}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nWhole Hog Kills: **{QpwholeHogKills}**\nAverage Whole Hog Kills Per 10 Minutes: **{QpwholeHogKillsAvgPer10Min}**\nMost Whole Hog Kills In Game: **{QpwholeHogKillsMostInGame}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "soldier76")
                {
                    string QpbioticFieldHealingDone = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticFieldHealingDone.ToString();
                    string QpbioticFieldsDeployed = dataObject.quickPlayStats.careerStats[hero].heroSpecific.bioticFieldsDeployed.ToString();
                    string QphelixRocketKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketKillsMostInGame.ToString();
                    string QphelixRocketsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketsKills.ToString();
                    string QphelixRocketsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.helixRocketsKillsAvgPer10Min.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QpselfHealing}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**";
                    string heroSpecific = $"Biotic Field Healing Done: **{QpbioticFieldHealingDone}**\nBiotic Fields Deployed: **{QpbioticFieldsDeployed}**\nHelix Rocket Kills: **{QphelixRocketsKills}**\nAverage Helix Rocket Kills Per 10 Minutes: **{QphelixRocketsKillsAvgPer10Min}**\nMost Helix Rocket Kills In Game: **{QphelixRocketKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "sombra")
                {
                    string QpenemiesEmpd = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpd.ToString();
                    string QpenemiesEmpdAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpdAvgPer10Min.ToString();
                    string QpenemiesEmpdMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesEmpdMostInGame.ToString();
                    string QpenemiesHacked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHacked.ToString();
                    string QpenemiesHackedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHackedAvgPer10Min.ToString();
                    string QpenemiesHackedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.enemiesHackedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive assists
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Enemies EMP'd: **{QpenemiesEmpd}**\nAverage EMP'd Per 10 Minutes: **{QpenemiesEmpdAvgPer10Min}**\nMost Enemies EMP'd In Game: **{QpenemiesEmpdMostInGame}**\nEnemies Hacked: **{QpenemiesHacked}**\nAverage Enemies Hacked Per 10 Minutes: **{QpenemiesHackedAvgPer10Min}**\nMost Enemies Hacked In Game: **{QpenemiesHackedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "symmetra")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpplayersTeleported = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleported.ToString();
                    string QpplayersTeleportedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleportedAvgPer10Min.ToString();
                    string QpplayersTeleportedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersTeleportedMostInGame.ToString();
                    string QpprimaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string QpsecondaryDirectHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryDirectHitsAvgPer10Min.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpsentryTurretsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKills.ToString();
                    string QpsentryTurretsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKillsAvgPer10Min.ToString();
                    string QpsentryTurretsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.sentryTurretsKillsMostInGame.ToString();

                    string heroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nPlayers Teleported: **{QpplayersTeleported}**\nAverage Players Teleported Per 10 Minutes: **{QpplayersTeleportedAvgPer10Min}**\nMost Players Teleported In Game: **{QpplayersTeleportedMostInGame}**\nPrimary Fire Accuracy: **{QpprimaryFireAccuracy}**\nSecondary Fire Direct Hits Per 10 Minutes: **{QpsecondaryDirectHitsAvgPer10Min}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSentry Turret Kills: **{QpsentryTurretsKills}**\nAverage Sentry Turret Kills Per 10 Minutes: **{QpsentryTurretsKillsAvgPer10Min}**\nMost Sentry Turret Kills In Game: **{QpsentryTurretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "torbjorn")
                {
                    string QpmoltenCoreKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKills.ToString();
                    string QpmoltenCoreKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKillsAvgPer10Min.ToString();
                    string QpmoltenCoreKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.moltenCoreKillsMostInGame.ToString();
                    string QpoverloadKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.overloadKills.ToString();
                    string QpoverloadKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.overloadKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QptorbjornKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKills.ToString();
                    string QptorbjornKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKillsAvgPer10Min.ToString();
                    string QptorbjornKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.torbjornKillsMostInGame.ToString();
                    string QpturretsDamageAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsDamageAvgPer10Min.ToString();
                    string QpturretsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKills.ToString();
                    string QpturretsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKillsAvgPer10Min.ToString();
                    string QpturretsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.turretsKillsMostInGame.ToString();

                    string heroSpecific = $"Molten Core Kills: **{QpmoltenCoreKills}**\nAverage Molten Core Kills Per 10 Minutes: **{QpmoltenCoreKillsAvgPer10Min}**\nMost Molten Core Kills In Game: **{QpmoltenCoreKillsMostInGame}**\nOverload Kills: **{QpoverloadKills}**\nMost Overload Kills In Game: **{QpoverloadKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nTorbjorn Kills: **{QptorbjornKills}**\nAverage Torbjorn Kills Per 10 Minutes: **{QptorbjornKillsAvgPer10Min}**\nMost Torbjorn Kills In Game: **{QptorbjornKillsMostInGame}**\nAverage Turret Damage Per 10 Minutes: **{QpturretsDamageAvgPer10Min}**\nTurret Kills: **{QpturretsKills}**\nAverage Turret Kills Per 10 Minutes: **{QpturretsKillsAvgPer10Min}**\nMost Turret Kills In Game: **{QpturretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "tracer")
                {
                    string QphealthRecovered = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecovered.ToString();
                    string QphealthRecoveredAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecoveredAvgPer10Min.ToString();
                    string QphealthRecoveredMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.healthRecoveredMostInGame.ToString();
                    string QppulseBombsAttached = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttached.ToString();
                    string QppulseBombsAttachedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttachedAvgPer10Min.ToString();
                    string QppulseBombsAttachedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsAttachedMostInGame.ToString();
                    string QppulseBombsKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKills.ToString();
                    string QppulseBombsKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKillsAvgPer10Min.ToString();
                    string QppulseBombsKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.pulseBombsKillsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Health Recalled: **{QphealthRecovered}**\nAverage Health Recalled Per 10 Minutes: **{QphealthRecoveredAvgPer10Min}**\nMost Health Recalled In Game: **{QphealthRecoveredMostInGame}**\nPulse Bomb Attached: **{QppulseBombsAttached}**\nAverage Pulse Bombs Attached Per 10 Minutes: **{QppulseBombsAttachedAvgPer10Min}**\nMost Pulse Bombs Attached In Game: **{QppulseBombsAttachedMostInGame}**\nPulse Bomb Kills: **{QppulseBombsKills}**\nAverage Pulse Bomb Kills Per 10 Minutes: **{QppulseBombsKillsAvgPer10Min}**\nMost Pulse Bomb Kills In Game: **{QppulseBombsKillsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "widowmaker")
                {
                    string QpscopedAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string QpscopedAccuracyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string QpscopedCriticalHits = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string QpscopedCriticalHitsAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string QpscopedCriticalHitsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string QpscopedCriticalHitsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpvenomMineKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKills.ToString();
                    string QpvenomMineKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKillsAvgPer10Min.ToString();
                    string QpvenomMineKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.venomMineKillsMostInGame.ToString();

                    //recon assists

                    string QpreconAssists = dataObject.quickPlayStats.careerStats[hero].assists.reconAssists.ToString();
                    string QpreconAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.reconAssistsAvgPer10Min.ToString();
                    string QpreconAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.reconAssistsMostInGame.ToString();

                    string assists = $"Recon Assists: **{QpreconAssists}**\nAverage Recon Assists Per 10 Minutes: **{QpreconAssistsAvgPer10Min}**\nMost Recon Assists In Game: **{QpreconAssistsMostInGame}**";
                    string heroSpecific = $"Scoped Accuracy: **{QpscopedAccuracy}**\nBest Scoped Accuracy In Game: **{QpscopedAccuracyBestInGame}**\nScoped Critical Hits Accuracy: **{QpscopedCriticalHitsAccuracy}**\nScoped Critical Hits: **{QpscopedCriticalHits}**\nAverage Scoped Critical Hits Per 10 Minutes: **{QpscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{QpscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nVenom Mine Kills: **{QpvenomMineKills}**\nAverage Venom Mine Kills Per 10 Minutes: **{QpvenomMineKillsAvgPer10Min}**\nMost Venom Mine Kills In Game: **{QpvenomMineKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "winston")
                {
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpjumpPackKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKills.ToString();
                    string QpjumpPackKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKillsAvgPer10Min.ToString();
                    string QpjumpPackKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.jumpPackKillsMostInGame.ToString();
                    string QpmeleeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKills.ToString();
                    string QpmeleeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKillsAvgPer10Min.ToString();
                    string QpmeleeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.meleeKillsMostInGame.ToString();
                    string QpplayersKnockedBack = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string QpplayersKnockedBackAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string QpplayersKnockedBackMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string QpprimalRageKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKills.ToString();
                    string QpprimalRageKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKillsAvgPer10Min.ToString();
                    string QpprimalRageKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primalRageKillsMostInGame.ToString();
                    string QpprimalRageMeleeAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpteslaCannonAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.teslaCannonAccuracy.ToString();
                    string QpweaponKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.weaponKills.ToString();

                    string heroSpecific = $"Damage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nJump Pack Kills: **{QpjumpPackKills}**\nAverage Jump Pack Kills Per 10 Minutes: **{QpjumpPackKillsAvgPer10Min}**\nMost Jump Pack Kills In Game: **{QpjumpPackKillsMostInGame}**\nMelee Kills: **{QpmeleeKills}**\nAverage Melee Kills Per 10 Minutes: **{QpmeleeKillsAvgPer10Min}**\nMost Melee Kills In Game: **{QpmeleeKillsMostInGame}**\nPlayers Knocked Back: **{QpplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{QpplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{QpplayersKnockedBackMostInGame}**\nPrimal Rage Kills: **{QpprimalRageKills}**\nAverage Primal Rage Kills In 10 Minutes: **{QpprimalRageKillsAvgPer10Min}**\nMost Primal Rage Kills In Game: **{QpprimalRageKillsMostInGame}**\nPrimal Rage Melee Accuracy: **{QpprimalRageMeleeAccuracy}**\nTesla Cannon Accuracy: **{QpteslaCannonAccuracy}**\nWeapon Kils: **{QpweaponKills}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "wreckingBall")
                {
                    string QpplayersKnockedBack = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string QpplayersKnockedBackAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string QpplayersKnockedBackMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Players Knocked Back: **{QpplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{QpplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{QpplayersKnockedBackMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}**";

                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zarya")
                {
                    string QpaverageEnergy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.averageEnergy.ToString();
                    string QpaverageEnergyBestInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.averageEnergyBestInGame.ToString();
                    string QpdamageBlocked = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string QpdamageBlockedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string QpdamageBlockedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string QpgravitonSurgeKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKills.ToString();
                    string QpgravitonSurgeKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKillsAvgPer10Min.ToString();
                    string QpgravitonSurgeKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.gravitonSurgeKillsMostInGame.ToString();
                    string QphighEnergyKills = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKills.ToString();
                    string QphighEnergyKillsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKillsAvgPer10Min.ToString();
                    string QphighEnergyKillsMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.highEnergyKillsMostInGame.ToString();
                    string QpprimaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string QpprojectedBarriersApplied = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersApplied.ToString();
                    string QpprojectedBarriersAppliedAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersAppliedAvgPer10Min.ToString();
                    string QpprojectedBarriersAppliedMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.projectedBarriersAppliedMostInGame.ToString();
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive and defensive assists
                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Average Energy: **{QpaverageEnergy}**\nBest Average Energy In Game: **{QpaverageEnergyBestInGame}**\nDamage Blocked: **{QpdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{QpdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{QpdamageBlockedMostInGame}**\nGraviton Surge Kills: **{QpgravitonSurgeKills}**\nAverage Graviton Surge Kills Per 10 Minutes: **{QpgravitonSurgeKillsAvgPer10Min}**\nMost Graviton Surge Kills In Game: **{QpgravitonSurgeKillsMostInGame}**\nHigh Energy Kills: **{QphighEnergyKills}**\nAverage High Energy Kills Per 10 Minutes: **{QphighEnergyKillsAvgPer10Min}**\nMost High Energy Kills In Game: **{QphighEnergyKillsMostInGame}**\nPrimary Fire Accuracy: **{QpprimaryFireAccuracy}**\nProjected Barriers Applied: **{QpprojectedBarriersApplied}**\nAverage Projected Barriers Provided Per 10 Minutes: **{QpprojectedBarriersAppliedAvgPer10Min}**\nMost Projected Barriers Provided In Game: **{QpprojectedBarriersAppliedMostInGame}**\nSecondary Fire Accuracy: **{QpsecondaryFireAccuracy}*";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zenyatta")
                {
                    string QpsecondaryFireAccuracy = dataObject.quickPlayStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string QpselfHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string QpselfHealingAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string QpselfHealingMostInGame = dataObject.quickPlayStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string QptranscendenceHealing = dataObject.quickPlayStats.careerStats[hero].heroSpecific.transcendenceHealing.ToString();
                    string QptranscendenceHealingBest = dataObject.quickPlayStats.careerStats[hero].heroSpecific.transcendenceHealingBest.ToString();

                    //healing stats for healers

                    string QpdefensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string QpdefensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string QpdefensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string QphealingDone = dataObject.quickPlayStats.careerStats[hero].assists.healingDone.ToString();
                    string QphealingDoneAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string QphealingDoneMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string QpoffensiveAssists = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string QpoffensiveAssistsAvgPer10Min = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string QpoffensiveAssistsMostInGame = dataObject.quickPlayStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{QpdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{QpdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{QpdefensiveAssistsMostInGame}**\nHealing Done: **{QphealingDone}**\nAverage Healing Done Per 10 Minutes: **{QphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{QphealingDoneMostInGame}**\nOffensive Assists: **{QpoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{QpoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{QpoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Secondary Fire Accuracy: **{QpsecondaryFireAccuracy}**\nSelf Healing: **{QpselfHealing}**\nAverage Self Healing Per 10 Minutes: **{QpselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{QpselfHealingMostInGame}**\nTranscendence Healing: **{QptranscendenceHealing}**\nBest Transcendence Healing In Game: **{QptranscendenceHealingBest}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { qpAvg, qpBest, qpTotal, qpMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync("Have you already registered your Battle.Net account with `w!owaccount`?\nMake sure you have played Quickplay with this hero, otherwise check your command.\n**w!myowhsqp <hero>Ex: w!myowhsqp dVa Phytal-1427**");
            }
        }

        [Command("myowherostatscomp")]
        [Summary("Get your statistics for a specific hero on Competitive.")]
        [Alias("myowhsc")]
        [Remarks("w!myowherostatscomp <hero> Ex: w!myowherostatscomp dVa")]
        [Cooldown(10)]
        public async Task GetMyOwHeroStatsComp(string hero)
        {
            try
            {
                string originalhero = hero;
                var config = GlobalUserAccounts.GetUserAccount(Context.User);
                hero = hero.ToLower();
                hero = GetHero(hero);

                var json = await Global.SendWebRequest($"https://ow-api.com/v1/stats/{config.OverwatchPlatform}/{config.OverwatchRegion}/{config.OverwatchID}/heroes/{hero}");

                var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

                string endorsementIcon = dataObject.endorsementIcon.ToString();
                string playerIcon = dataObject.icon.ToString();
                string srIcon = dataObject.ratingIcon.ToString();
                //avg
                string CompAllDamageAvg = dataObject.competitiveStats.careerStats[hero].average.allDamageDoneAvgPer10Min.ToString();
                string CompBarrierDamageAvg = dataObject.competitiveStats.careerStats[hero].average.barrierDamageDoneAvgPer10Min.ToString();
                string CompCriticalsAvg = dataObject.competitiveStats.careerStats[hero].average.criticalHitsAvgPer10Min.ToString();
                string CompDeathAvg = dataObject.competitiveStats.careerStats[hero].average.deathsAvgPer10Min.ToString();
                string CompElimAvg = dataObject.competitiveStats.careerStats[hero].average.eliminationsAvgPer10Min.ToString();
                string CompElimPerLife = dataObject.competitiveStats.careerStats[hero].average.eliminationsPerLife.ToString();
                string CompFinalBlowAvg = dataObject.competitiveStats.careerStats[hero].average.finalBlowsAvgPer10Min.ToString();
                string CompHeroDamageAvg = dataObject.competitiveStats.careerStats[hero].average.heroDamageDoneAvgPer10Min.ToString();
                string CompMeleeAvg = dataObject.competitiveStats.careerStats[hero].average.meleeFinalBlowsAvgPer10Min.ToString();
                string CompObjKillsAvg = dataObject.competitiveStats.careerStats[hero].average.objectiveKillsAvgPer10Min.ToString();
                string CompObjTimeAvg = dataObject.competitiveStats.careerStats[hero].average.objectiveTimeAvgPer10Min.ToString();
                string CompSoloKillAvg = dataObject.competitiveStats.careerStats[hero].average.soloKillsAvgPer10Min.ToString();
                string CompOnFireAvg = dataObject.competitiveStats.careerStats[hero].average.timeSpentOnFireAvgPer10Min.ToString();
                //best
                string CompAllDamageInGame = dataObject.competitiveStats.careerStats[hero].best.allDamageDoneMostInGame.ToString();
                string CompAllDamageInLife = dataObject.competitiveStats.careerStats[hero].best.allDamageDoneMostInLife.ToString();
                string CompBarrierDamageInGame = dataObject.competitiveStats.careerStats[hero].best.barrierDamageDoneMostInGame.ToString();
                string CompCritMostInGame = dataObject.competitiveStats.careerStats[hero].best.criticalHitsMostInGame.ToString();
                string CompCritMostInLife = dataObject.competitiveStats.careerStats[hero].best.criticalHitsMostInLife.ToString();
                string CompElimMostInLife = dataObject.competitiveStats.careerStats[hero].best.eliminationsMostInLife.ToString();
                string CompElimMostInGame = dataObject.competitiveStats.careerStats[hero].best.eliminationsMostInGame.ToString();
                string CompFinalBlowMostInGame = dataObject.competitiveStats.careerStats[hero].best.finalBlowsMostInGame.ToString();
                string CompHeroDmgMostInGame = dataObject.competitiveStats.careerStats[hero].best.heroDamageDoneMostInGame.ToString();
                string CompHeroDmgMostInLife = dataObject.competitiveStats.careerStats[hero].best.heroDamageDoneMostInLife.ToString();
                string CompKillStreakBest = dataObject.competitiveStats.careerStats[hero].best.killsStreakBest.ToString();
                string CompMeleeFinalBlowMostInGame = dataObject.competitiveStats.careerStats[hero].best.meleeFinalBlowsMostInGame.ToString();
                string CompMultikillBest = dataObject.competitiveStats.careerStats[hero].best.multikillsBest.ToString();
                string CompObjKillMostInGame = dataObject.competitiveStats.careerStats[hero].best.objectiveKillsMostInGame.ToString();
                string CompObjTimeMostInGame = dataObject.competitiveStats.careerStats[hero].best.objectiveTimeMostInGame.ToString();
                string CompSoloKillsMostInGame = dataObject.competitiveStats.careerStats[hero].best.soloKillsMostInGame.ToString();
                string CompOnFireMostInGame = dataObject.competitiveStats.careerStats[hero].best.timeSpentOnFireMostInGame.ToString();
                string CompWeaponAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].best.weaponAccuracyBestInGame.ToString();
                //combat
                string CompBarrierDmgDone = dataObject.competitiveStats.careerStats[hero].combat.barrierDamageDone.ToString();
                string CompCriticalHits = dataObject.competitiveStats.careerStats[hero].combat.criticalHits.ToString();
                string CompCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].combat.criticalHitsAccuracy.ToString();
                string CompDamageDone = dataObject.competitiveStats.careerStats[hero].combat.damageDone.ToString();
                string CompDeaths = dataObject.competitiveStats.careerStats[hero].combat.deaths.ToString();
                string CompElims = dataObject.competitiveStats.careerStats[hero].combat.eliminations.ToString();
 
                string CompFinalBlows = dataObject.competitiveStats.careerStats[hero].combat.finalBlows.ToString();
                string CompHeroDmg = dataObject.competitiveStats.careerStats[hero].combat.heroDamageDone.ToString();
                string CompMeleeFinalBlows = dataObject.competitiveStats.careerStats[hero].combat.meleeFinalBlows.ToString();
                string CompMultikills = dataObject.competitiveStats.careerStats[hero].combat.multikills.ToString();
                string CompObjKills = dataObject.competitiveStats.careerStats[hero].combat.objectiveKills.ToString();
                string CompObjTime = dataObject.competitiveStats.careerStats[hero].combat.objectiveTime.ToString();
                string CompMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].combat.quickMeleeAccuracy.ToString();
                string CompSoloKills = dataObject.competitiveStats.careerStats[hero].combat.soloKills.ToString();
                string CompOnFire = dataObject.competitiveStats.careerStats[hero].combat.timeSpentOnFire.ToString();
                string CompWeaponAccuracy = dataObject.competitiveStats.careerStats[hero].combat.weaponAccuracy.ToString();
                //misc stuff
                string CompGamesPlayed = dataObject.competitiveStats.careerStats[hero].game.gamesPlayed.ToString();
                string CompGamesWon = dataObject.competitiveStats.careerStats[hero].game.gamesWon.ToString();
                string CompGamesTied = dataObject.competitiveStats.careerStats[hero].game.gamesTied.ToString();
                string CompGamesLost = dataObject.competitiveStats.careerStats[hero].game.gamesLost.ToString();
                string CompTimePlayed = dataObject.competitiveStats.careerStats[hero].game.timePlayed.ToString();
                string CompWinPercentage = dataObject.competitiveStats.careerStats[hero].game.winPercentage.ToString();
                string CompCards = dataObject.competitiveStats.careerStats[hero].matchAwards.cards.ToString();
                string CompMedals = dataObject.competitiveStats.careerStats[hero].matchAwards.medals.ToString();
                string CompMedalsBronze = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsBronze.ToString();
                string CompMedalsGold = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsGold.ToString();
                string CompMedalsSilver = dataObject.competitiveStats.careerStats[hero].matchAwards.medalsSilver.ToString();
                string CompElimsPerLife = dataObject.competitiveStats.topHeroes[hero].eliminationsPerLife.ToString();

                string compAvg = $"All Damage Done per 10 Minutes: **{CompAllDamageAvg}**\nBarrier Damage Done per 10 Minutes: **{CompBarrierDamageAvg}**\nHero Damage Done per 10 Minutes: **{CompHeroDamageAvg}**\nCritical Hits per 10 Minutes: **{CompCriticalsAvg}**\nDeaths per 10 Minutes: **{CompDeathAvg}**\nEliminations per 10 Minutes: **{CompElimAvg}**\nEliminations per Life: **{CompElimPerLife}**\nFinal Blows per 10 Minutes: **{CompFinalBlowAvg}**\nMelee Final Blows per 10 Minutes: **{CompMeleeAvg}**\nObjective Time per 10 Minutes: **{CompObjTimeAvg}**\nObjective Kills per 10 Minutes: **{CompObjKillsAvg}**\nSolo Kills per 10 Minutes: **{CompSoloKillAvg}**\nTime on Fire per 10 Minutes: **{CompOnFireAvg}**";
                string compBest = $"All Damage in Game: **{CompAllDamageInGame}**\nAll Damage in Life: **{CompAllDamageInLife}**\nBarrier Damage in Game: **{CompBarrierDamageInGame}**\nCriticals in Game: **{CompCritMostInGame}**\nCriticals in Life: **{CompCritMostInLife}**\nEliminations in Game: **{CompElimMostInGame}**\nEliminations in Life: **{CompElimMostInLife}**\nFinal Blows in Game: **{CompFinalBlowMostInGame}**\nHero Damage in Game: **{CompHeroDmgMostInGame}**\nHero Damage in Life: **{CompHeroDmgMostInLife}**\nKill Streak: **{CompKillStreakBest}**\nMelee Final Blows in Game: **{CompMeleeFinalBlowMostInGame}**\nMultikill: **{CompMultikillBest}**\nObjective Kills in Game: **{CompObjKillMostInGame}**\nObjective Time in Game: **{CompObjTimeMostInGame}**\nSolo Kills in Game: **{CompSoloKillsMostInGame}**\nOn Fire Time in Game: **{CompOnFireMostInGame}**\nWeapon Accuracy in Game: **{CompWeaponAccuracyBestInGame}**";
                string compTotal = $"Barrier Damage Done: **{CompBarrierDmgDone}**\nCritical Hits: **{CompCriticalHits}**\nObjective Time in Game: **{CompObjTimeMostInGame}**\nCritical Hit Accuracy: **{CompCriticalHitsAccuracy}**\nDamage Done: **{CompDamageDone}**\nDeaths: **{CompDeaths}**\nEliminations: **{CompElims}**\nFinal Blows: **{CompFinalBlows}**\nHero Damage: **{CompHeroDmg}**\nMelee Final Blows: **{CompMeleeFinalBlows}**\nMultikills: **{CompMultikills}**\nObjective Kills: **{CompObjKills}**\nObjective Time: **{CompObjTime}**\nMelee Accuracy: **{CompMeleeAccuracy}**\nSolo Kills: **{CompSoloKills}**\nOn Fire Time: **{CompOnFire}**\nWeapon Accuracy: **{CompWeaponAccuracy}**";
                string compMisc = $"Games Played: **{CompGamesPlayed}**\nGames Won: **{CompGamesWon}**\nGames Tied: **{CompGamesTied}**\nGames Lost: **{CompGamesLost}**\nTime Played: **{CompTimePlayed}**\nWin Percentage: **{CompWinPercentage}**\nCards: **{CompCards}**\nTotal Medals: **{CompMedals}**\nGold Medals: **{CompMedalsGold}**\nSilver Medals: **{CompMedalsSilver}**\nBronze Medals: **{CompMedalsBronze}**\nEliminations per Life: **{CompElimsPerLife}**\n";

                if (hero == "ana")
                {
                    string CompBioticKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticGrenadeKills.ToString();
                    string CompEnemiesSlept = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSlept.ToString();
                    string CompEnemiesSleptPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSleptAvgPer10Min.ToString();
                    string CompEnemiesSleptMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesSleptMostInGame.ToString();
                    string CompNanoAssists = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssists.ToString();
                    string CompNanoAssistsPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssistsAvgPer10Min.ToString();
                    string CompMostNanoAssistsIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostAssistsMostInGame.ToString();
                    string CompNanosApplied = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsApplied.ToString();
                    string CompNanosAppliedPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsAppliedAvgPer10Min.ToString();
                    string CompNanoAppliedMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.nanoBoostsAppliedMostInGame.ToString();
                    string CompScopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompScopedAccuracyBestIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompSecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompSelfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompSelfHealingPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompSelfHealingMostIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompUnscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.unscopedAccuracy.ToString();
                    string CompUnscopedAccuracyBestIG = dataObject.competitiveStats.careerStats[hero].heroSpecific.unscopedAccuracyBestInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Biotic Grenade Kills: **{CompBioticKills}**\nEnemies Slept: **{CompEnemiesSlept}**\nAverage Enemies Slept per 10 Minutes: **{CompEnemiesSleptPer10Min}**\nMost Enemies Slept In Game: **{CompEnemiesSleptPer10Min}**\nNano Boost Assists: **{CompNanoAssists}**\nNano Boost Assists Per 10 Minutes: **{CompNanosAppliedPer10Min}**\nMost Nano Boost Assists In Game: **{CompMostNanoAssistsIG}**\nNano Boosts Applied: **{CompNanosApplied}**\nNano Boosts Applied Per 10 Minutes: **{CompNanosAppliedPer10Min}**\nNano Boosts Applied Most In Game: **{CompNanoAppliedMostIG}**\nScoped Accuracy: **{CompScopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompScopedAccuracyBestIG}**\nSecondary Fire Accuracy: **{CompSecondaryFireAccuracy}**\nSelf Healing: **{CompSelfHealing}**\nSelf Healing Per 10 Minutes: **{CompSelfHealingPer10Min}**\nMost Self Healing In Game: **{CompSelfHealingMostIG}**\nUnscoped Accuracy: **{CompUnscopedAccuracy}**\nBest Unscoped Accuracy In Game: **{CompScopedAccuracyBestIG}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "ashe")
                {
                    string CompbobKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKills.ToString();
                    string CompbobKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKillsAvgPer10Min.ToString();
                    string CompbobKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.bobKillsMostInGame.ToString();
                    string CompcoachGunKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKills.ToString();
                    string CompcoachGunKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKillsAvgPer10Min.ToString();
                    string CompcoachGunKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coachGunKillsMostInGame.ToString();
                    string CompdynamiteKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKills.ToString();
                    string CompdynamiteKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKillsAvgPer10Min.ToString();
                    string CompdynamiteKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.dynamiteKillsMostInGame.ToString();
                    string CompscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompscopedAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompscopedCriticalHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string CompscopedCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string CompscopedCriticalHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string CompscopedCriticalHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"BOB Kills: **{CompbobKills}**\nAverage BOB Kills Per 10 Minutes: **{CompbobKillsAvgPer10Min}**\nMost BOB Kills In Game: **{CompbobKillsMostInGame}**\nCoach Gun Kills: **{CompcoachGunKills}**\nAverage Coach Gun Kills Per 10 Minutes: **{CompcoachGunKillsAvgPer10Min}**\nMost Coach Gun Kills In Game: **{CompcoachGunKillsMostInGame}**\nDynamite Kills: **{CompdynamiteKills}**\nAverage Dynamite Kills Per 10 Minutes: **{CompdynamiteKillsAvgPer10Min}**\nMost Dynamite Kills In Game Kills: **{CompdynamiteKillsMostInGame}**\nScoped Accuracy: **{CompscopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompscopedAccuracyBestInGame}**\nScoped Creitical Hits: **{CompscopedCriticalHits}**\nScoped Critical Hits Accuracy: **{CompscopedCriticalHitsAccuracy}**\nAverage Scoped Critical Hits Per 10 Minutes: **{CompscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{CompscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "bastion")
                {
                    string CompreconKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKills.ToString();
                    string CompreconKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKillsAvgPer10Min.ToString();
                    string CompreconKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.reconKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].selfHealingAvgPer10Min.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompsentryKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKills.ToString();
                    string CompsentryKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKillsAvgPer10Min.ToString();
                    string CompsentryKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryKillsMostInGame.ToString();
                    string ComptankKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKills.ToString();
                    string ComptankKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKillsAvgPer10Min.ToString();
                    string ComptankKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.tankKillsMostInGame.ToString();

                    string heroSpecific = $"Recon Kills: **{CompreconKills}**\nAverage Recon Kills Per 10 Minutes: **{CompreconKillsAvgPer10Min}**\nMost Recon Kills In Game: **{CompreconKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nSentry Kills: **{CompsentryKills}**\nAverage Sentry Kills Per 10 Minutes: **{CompsentryKillsAvgPer10Min}**\nMost Sentry Kills In Game: **{CompsentryKillsMostInGame}**\nTank Kills: **{ComptankKills}**\nAverage Tank Kills Per 10 Minutes: **{CompreconKills}**\nMost Tank Kills In Game: **{ComptankKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "brigitte")
                {
                    string ComparmorProvided = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvided.ToString();
                    string ComparmorProvidedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvidedAvgPer10Min.ToString();
                    string ComparmorProvidedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.armorProvidedMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompinspireUptimePercentage = dataObject.competitiveStats.careerStats[hero].heroSpecific.inspireUptimePercentage.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Armor Provided: **{ComparmorProvided}**\nAverage Armor Provided Per 10 Minutes: **{ComparmorProvidedAvgPer10Min}**\nMost Armor Provided In Game: **{ComparmorProvidedMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nInspire Uptime Percentage: **{CompinspireUptimePercentage}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "dVa")
                {
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompmechDeaths = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechDeaths.ToString();
                    string CompmechsCalled = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalled.ToString();
                    string CompmechsCalledAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalledAvgPer10Min.ToString();
                    string CompmechsCalledMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.mechsCalledMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfDestructKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKills.ToString();
                    string CompselfDestructKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKillsAvgPer10Min.ToString();
                    string CompselfDestructKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfDestructKillsMostInGame.ToString();

                    string heroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nMech Deaths: **{CompmechDeaths}**\nMechs Called: **{CompmechsCalled}**\nAverage Mechs Called Per 10 Minutes: **{CompmechsCalledAvgPer10Min}**\nMost Mechs Called In Game: **{CompmechsCalledMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Destruct Kills: **{CompselfDestructKills}**\nAverage Self Destruct Kills Per 10 Minutes: **{CompselfDestructKillsAvgPer10Min}**\nMost Self Destruct Kills In Game: **{CompselfDestructKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "doomfist")
                {
                    string CompabilityDamageDone = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.barrierDamageDone.ToString();
                    string CompabilityDamageDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.abilityDamageDoneAvgPer10Min.ToString();
                    string CompabilityDamageDoneMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.abilityDamageDoneMostInGame.ToString();
                    string CompmeteorStrikeKills = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKills.ToString();
                    string CompmeteorStrikeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsAvgPer10Min.ToString();
                    string CompmeteorStrikeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.meteorStrikeKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.secondaryFireAccuracy.ToString();
                    string CompshieldsCreated = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreated.ToString();
                    string CompshieldsCreatedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreatedAvgPer10Min.ToString();
                    string CompshieldsCreatedMostInGame = dataObject.competitiveStats.careerStats[hero].abilityDamageDone.shieldsCreatedMostInGame.ToString();

                    string heroSpecific = $"Ability Damage Done: **{CompabilityDamageDone}**\nAverage Ability Damage Done Per 10 Minutes: **{CompabilityDamageDoneAvgPer10Min}**\nMost Ability Damage Done In Game: **{CompabilityDamageDoneMostInGame}**\nMeteor Strike Kills: **{CompmeteorStrikeKills}**\nAverage Meteor Strike Kills Per 10 Minutes: **{CompmeteorStrikeKillsAvgPer10Min}**\nMost Meteor Strike Kills In Game: **{CompmeteorStrikeKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nShields Created: **{CompshieldsCreated}**\nAverage Shields Created Per 10 Minutes: **{CompshieldsCreatedAvgPer10Min}**\nMost Shields Created In Game: **{CompshieldsCreatedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "genji")
                {
                    string CompdamageReflected = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflected.ToString();
                    string CompdamageReflectedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflectedAvgPer10Min.ToString();
                    string CompdamageReflectedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageReflectedMostInGame.ToString();
                    string CompdeflectionKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deflectionKills.ToString();
                    string CompdragonbladesKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKills.ToString();
                    string CompdragonbladesKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKillsAvgPer10Min.ToString();
                    string CompdragonbladesKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.dragonbladesKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Damage Deflected: **{CompdamageReflected}**\nAverage Damage Deflected Per 10 Minutes: **{CompdamageReflectedMostInGame}**\nMost Damage Deflected In Game: **{CompdamageReflectedMostInGame}**\nDeflection Kills: **{CompdeflectionKills}**\nDragonblade Kills: **{CompdragonbladesKills}**\nAverage Dragonblade Kills Per 10 Minutes: **{CompdragonbladesKillsAvgPer10Min}**\nMost Dragonblade Kills In Game: **{CompdragonbladesKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "hanzo")
                {
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompstormArrowKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKills.ToString();
                    string CompstormArrowKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKillsAvgPer10Min.ToString();
                    string CompstormArrowKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.stormArrowKillsMostInGame.ToString();

                    string heroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nStorm Arrow Kills: **{CompstormArrowKills}**\nAverage Storm Arrow Kills Per 10 Minutes: **{CompstormArrowKillsAvgPer10Min}**\nMost Storm Arrow Kills In Game: **{CompstormArrowKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "junkrat")
                {
                    string CompconcussionMineKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKills.ToString();
                    string CompconcussionMineKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKillsAvgPer10Min.ToString();
                    string CompconcussionMineKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.concussionMineKillsMostInGame.ToString();
                    string CompenemiesTrapped = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrapped.ToString();
                    string CompenemiesTrappedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrappedAvgPer10Min.ToString();
                    string CompenemiesTrappedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesTrappedMostInGame.ToString();
                    string CompripTireKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKills.ToString();
                    string CompripTireKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKillsAvgPer10Min.ToString();
                    string CompripTireKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.ripTireKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Concussion Mine Kills: **{CompconcussionMineKills}**\nAverage Concussion Mine Kills Per 10 Minutes: **{CompconcussionMineKillsAvgPer10Min}**\nMost Concussion Mine Kills in Game: **{CompconcussionMineKillsMostInGame}**\nEnemies Trapped: **{CompenemiesTrapped}**\nAverage Enemies Trapped Per 10 Minutes: **{CompenemiesTrappedAvgPer10Min}**\nMost Enemies Trapped In Game: **{CompenemiesTrappedMostInGame}**\nRip Tire Kills: **{CompripTireKills}**\nAverage Rip Tire Kills Per 10 Minutes: **{CompripTireKillsAvgPer10Min}**\nMost Rip Tire Kills In Game: **{CompripTireKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "lucio")
                {
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompsoundBarriersProvided = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvided.ToString();
                    string CompsoundBarriersProvidedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvidedAvgPer10Min.ToString();
                    string CompsoundBarriersProvidedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.soundBarriersProvidedMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\n:Most Self Healing In Game **{CompselfHealingMostInGame}**\nSound Barriers Provided: **{CompsoundBarriersProvided}**\nAverage Sound Barriers Provided Per 10 minutes: **{CompsoundBarriersProvidedAvgPer10Min}**\nMost Sound barriers Provided In Game: **{CompsoundBarriersProvidedMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mccree")
                {
                    string CompdeadeyeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKills.ToString();
                    string CompdeadeyeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKillsAvgPer10Min.ToString();
                    string CompdeadeyeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.deadeyeKillsMostInGame.ToString();
                    string CompfanTheHammerKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKills.ToString();
                    string CompfanTheHammerKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKillsAvgPer10Min.ToString();
                    string CompfanTheHammerKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.fanTheHammerKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Deadeye Kills: **{CompdeadeyeKills}**\nAverage Deadeye Kills Per 10 Minutes: **{CompdeadeyeKillsAvgPer10Min}**\nMost Deadeye Kills In Game: **{CompdeadeyeKillsMostInGame}**\nFan The Hammer Kills: **{CompfanTheHammerKills}**\nAverage Fan The Hammer Kills Per 10 Minutes: **{CompfanTheHammerKillsAvgPer10Min}**\nMost Fan The Hammer Kills In Game: **{CompfanTheHammerKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "mei")
                {

                    string CompblizzardKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKills.ToString();
                    string CompblizzardKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKillsAvgPer10Min.ToString();
                    string CompblizzardKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.blizzardKillsMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompenemiesFrozen = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozen.ToString();
                    string CompenemiesFrozenAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozenAvgPer10Min.ToString();
                    string CompenemiesFrozenMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesFrozenMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Blizzard Kills: **{CompblizzardKills}**\nAverage Blizzard Kills Per 10 Minutes: **{CompblizzardKillsAvgPer10Min}**\nMost Blizzard Kills In Game: **{CompblizzardKillsMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nEnemies Frozen: **{CompenemiesFrozen}**\nAverage Enemies Frozen: **{CompenemiesFrozenAvgPer10Min}**\nMost Enemies Frozen In Game: **{CompenemiesFrozenMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";

                }
                if (hero == "mercy")
                {
                    string CompblasterKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKills.ToString();
                    string CompblasterKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKillsAvgPer10Min.ToString();
                    string CompblasterKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.blasterKillsMostInGame.ToString();
                    string CompdamageAmplified = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string CompdamageAmplifiedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string CompdamageAmplifiedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string CompplayersResurrected = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrected.ToString();
                    string CompplayersResurrectedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrectedAvgPer10Min.ToString();
                    string CompplayersResurrectedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersResurrectedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Blaster Kills: **{CompblasterKills}**\nAverage Blaster Kills Per 10 Minutes: **{CompblasterKillsAvgPer10Min}**\nMost Blaster Kills In Game: **{CompblasterKillsMostInGame}**\nDamage Amplified: **{CompdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{CompdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{CompdamageAmplifiedMostInGame}**\nPlayers Resurrected: **{CompplayersResurrected}**\nAverage Players Resurrected Per 10 Minutes: **{CompplayersResurrectedAvgPer10Min}**\nMost Players Ressurected In Game: **{CompplayersResurrectedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "moira")
                {
                    string CompcoalescenceHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealing.ToString();
                    string CompcoalescenceHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealingAvgPer10Min.ToString();
                    string CompcoalescenceHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceHealingMostInGame.ToString();
                    string CompcoalescenceKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKills.ToString();
                    string CompcoalescenceKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKillsAvgPer10Min.ToString();
                    string CompcoalescenceKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.coalescenceKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Coalescence Healing: **{CompcoalescenceHealing}**\nAverage Coalescence Healing Per 10 Minutes: **{CompcoalescenceHealingAvgPer10Min}**\nMost Coalescence Healing In Game: **{CompcoalescenceHealingMostInGame}**\nCoalescence Kills: **{CompcoalescenceKills}**\nAverage Coalescence Kills Per 10 Minutes: **{CompcoalescenceKillsAvgPer10Min}**\nMost Coalescence Kills In Game: **{CompcoalescenceKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "orisa")
                {
                    string CompdamageAmplified = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplified.ToString();
                    string CompdamageAmplifiedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedAvgPer10Min.ToString();
                    string CompdamageAmplifiedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageAmplifiedMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompsuperchargerAssists = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssists.ToString();
                    string CompsuperchargerAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssistsAvgPer10Min.ToString();
                    string CompsuperchargerAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.superchargerAssistsMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Damage Amplified: **{CompdamageAmplified}**\nAverage Damage Amplified Per 10 Minutes: **{CompdamageAmplifiedAvgPer10Min}**\nMost Damage Amplified In Game: **{CompdamageAmplifiedMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSupercharger Assists: **{CompsuperchargerAssists}**\nAverage Supercharger Assists Per 10 Minutes: **{CompsuperchargerAssistsAvgPer10Min}**\nMost Supercharger Assists In Game: **{CompsuperchargerAssistsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "pharah")
                {
                    string CompbarrageKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKills.ToString();
                    string CompbarrageKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKillsAvgPer10Min.ToString();
                    string CompbarrageKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.barrageKillsMostInGame.ToString();
                    string CompdirectHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.directHitsAccuracy.ToString();
                    string ComprocketDirectHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHits.ToString();
                    string ComprocketDirectHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHitsAvgPer10Min.ToString();
                    string ComprocketDirectHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketDirectHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Barrage Kills: **{CompbarrageKills}**\nAverage Barrage Kills Per 10 Minutes: **{CompbarrageKillsAvgPer10Min}**\nMost Barrage Kills In Game: **{CompbarrageKillsMostInGame}**\nDirect Hits Accuracy: **{CompdirectHitsAccuracy}**\nRocket Dirrect Hits: **{ComprocketDirectHits}**\nAverage Rocket Direct Hits Per 10 Minutes: **{ComprocketDirectHitsAvgPer10Min}**\nMost Rocket Direct Hits In Game: **{ComprocketDirectHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reaper")
                {
                    string CompdeathsBlossomKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKills.ToString();
                    string CompdeathsBlossomKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKillsAvgPer10Min.ToString();
                    string CompdeathsBlossomKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.deathsBlossomKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string heroSpecific = $"Death Blossom Kills: **{CompdeathsBlossomKills}**\nAverage Death Blossom Kills Per 10 Minutes: **{CompdeathsBlossomKillsAvgPer10Min}**\nMost Death Blossom Kills In Game: **{CompdeathsBlossomKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "reinhardt")
                {
                    string CompchargeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKills.ToString();
                    string CompchargeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKillsAvgPer10Min.ToString();
                    string CompchargeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.chargeKillsMostInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompearthshatterKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKills.ToString();
                    string CompearthshatterKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKillsAvgPer10Min.ToString();
                    string CompearthshatterKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.earthshatterKillsMostInGame.ToString();
                    string CompfireStrikeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKills.ToString();
                    string CompfireStrikeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKillsAvgPer10Min.ToString();
                    string CompfireStrikeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.fireStrikeKillsMostInGame.ToString();
                    string ComprocketHammerMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.rocketHammerMeleeAccuracy.ToString();

                    string heroSpecific = $"Charge Kills: **{CompchargeKills}**\nAverage Charge Kills Per 10 Minutes: **{CompchargeKillsAvgPer10Min}**\nMost Charge Kills In Game: **{CompchargeKillsMostInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nEarthshatter Kills: **{CompearthshatterKills}**\nAverage Earthshatter Kills Per 10 Minutes: **{CompearthshatterKillsAvgPer10Min}**\nMost Earthshatter Kills In Game: **{CompearthshatterKillsMostInGame}**\nFire Strike Kills: **{CompfireStrikeKills}**\nFire Strike Kills: **{CompfireStrikeKills}**\nAverage Fire Strike Kills Per 10 Minutes: **{CompfireStrikeKillsAvgPer10Min}**\nMost Fire Strike Kills In Game: **{CompfireStrikeKillsMostInGame}**\nRocket Hammer Melee Accuracy: **{ComprocketHammerMeleeAccuracy}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "roadhog")
                {
                    string CompenemiesHooked = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHooked.ToString();
                    string CompenemiesHookedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHookedAvgPer10Min.ToString();
                    string CompenemiesHookedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHookedMostInGame.ToString();
                    string ComphookAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.hookAccuracy.ToString();
                    string ComphookAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.hookAccuracyBestInGame.ToString();
                    string ComphooksAttempted = dataObject.competitiveStats.careerStats[hero].heroSpecific.hooksAttempted.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string CompwholeHogKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKills.ToString();
                    string CompwholeHogKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKillsAvgPer10Min.ToString();
                    string CompwholeHogKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.wholeHogKillsMostInGame.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Enemies Hooked: **{CompenemiesHooked}**\nAverage Enemies Hooked Per 10 Minutes: **{CompenemiesHookedAvgPer10Min}**\nMost Enemies Hooked In Game: **{CompenemiesHookedMostInGame}**\nHook Accuracy: **{ComphookAccuracy}**\nBest Hook Accuracy In Game: **{ComphookAccuracyBestInGame}**\nHooks Attempted: **{ComphooksAttempted}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nWhole Hog Kills: **{CompwholeHogKills}**\nAverage Whole Hog Kills Per 10 Minutes: **{CompwholeHogKillsAvgPer10Min}**\nMost Whole Hog Kills In Game: **{CompwholeHogKillsMostInGame}**\n";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "soldier76")
                {
                    string CompbioticFieldHealingDone = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticFieldHealingDone.ToString();
                    string CompbioticFieldsDeployed = dataObject.competitiveStats.careerStats[hero].heroSpecific.bioticFieldsDeployed.ToString();
                    string ComphelixRocketKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketKillsMostInGame.ToString();
                    string ComphelixRocketsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketsKills.ToString();
                    string ComphelixRocketsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.helixRocketsKillsAvgPer10Min.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();

                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{CompselfHealing}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**";
                    string heroSpecific = $"Biotic Field Healing Done: **{CompbioticFieldHealingDone}**\nBiotic Fields Deployed: **{CompbioticFieldsDeployed}**\nHelix Rocket Kills: **{ComphelixRocketsKills}**\nAverage Helix Rocket Kills Per 10 Minutes: **{ComphelixRocketsKillsAvgPer10Min}**\nMost Helix Rocket Kills In Game: **{ComphelixRocketKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "sombra")
                {
                    string CompenemiesEmpd = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpd.ToString();
                    string CompenemiesEmpdAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpdAvgPer10Min.ToString();
                    string CompenemiesEmpdMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesEmpdMostInGame.ToString();
                    string CompenemiesHacked = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHacked.ToString();
                    string CompenemiesHackedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHackedAvgPer10Min.ToString();
                    string CompenemiesHackedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.enemiesHackedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive assists
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Offensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Enemies EMP'd: **{CompenemiesEmpd}**\nAverage EMP'd Per 10 Minutes: **{CompenemiesEmpdAvgPer10Min}**\nMost Enemies EMP'd In Game: **{CompenemiesEmpdMostInGame}**\nEnemies Hacked: **{CompenemiesHacked}**\nAverage Enemies Hacked Per 10 Minutes: **{CompenemiesHackedAvgPer10Min}**\nMost Enemies Hacked In Game: **{CompenemiesHackedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "symmetra")
                {
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompplayersTeleported = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleported.ToString();
                    string CompplayersTeleportedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleportedAvgPer10Min.ToString();
                    string CompplayersTeleportedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersTeleportedMostInGame.ToString();
                    string CompprimaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string CompsecondaryDirectHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryDirectHitsAvgPer10Min.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompsentryTurretsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKills.ToString();
                    string CompsentryTurretsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKillsAvgPer10Min.ToString();
                    string CompsentryTurretsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.sentryTurretsKillsMostInGame.ToString();

                    string heroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nPlayers Teleported: **{CompplayersTeleported}**\nAverage Players Teleported Per 10 Minutes: **{CompplayersTeleportedAvgPer10Min}**\nMost Players Teleported In Game: **{CompplayersTeleportedMostInGame}**\nPrimary Fire Accuracy: **{CompprimaryFireAccuracy}**\nSecondary Fire Direct Hits Per 10 Minutes: **{CompsecondaryDirectHitsAvgPer10Min}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSentry Turret Kills: **{CompsentryTurretsKills}**\nAverage Sentry Turret Kills Per 10 Minutes: **{CompsentryTurretsKillsAvgPer10Min}**\nMost Sentry Turret Kills In Game: **{CompsentryTurretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "torbjorn")
                {
                    string CompmoltenCoreKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKills.ToString();
                    string CompmoltenCoreKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKillsAvgPer10Min.ToString();
                    string CompmoltenCoreKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.moltenCoreKillsMostInGame.ToString();
                    string CompoverloadKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.overloadKills.ToString();
                    string CompoverloadKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.overloadKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string ComptorbjornKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKills.ToString();
                    string ComptorbjornKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKillsAvgPer10Min.ToString();
                    string ComptorbjornKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.torbjornKillsMostInGame.ToString();
                    string CompturretsDamageAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsDamageAvgPer10Min.ToString();
                    string CompturretsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKills.ToString();
                    string CompturretsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKillsAvgPer10Min.ToString();
                    string CompturretsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.turretsKillsMostInGame.ToString();

                    string heroSpecific = $"Molten Core Kills: **{CompmoltenCoreKills}**\nAverage Molten Core Kills Per 10 Minutes: **{CompmoltenCoreKillsAvgPer10Min}**\nMost Molten Core Kills In Game: **{CompmoltenCoreKillsMostInGame}**\nOverload Kills: **{CompoverloadKills}**\nMost Overload Kills In Game: **{CompoverloadKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nTorbjorn Kills: **{ComptorbjornKills}**\nAverage Torbjorn Kills Per 10 Minutes: **{ComptorbjornKillsAvgPer10Min}**\nMost Torbjorn Kills In Game: **{ComptorbjornKillsMostInGame}**\nAverage Turret Damage Per 10 Minutes: **{CompturretsDamageAvgPer10Min}**\nTurret Kills: **{CompturretsKills}**\nAverage Turret Kills Per 10 Minutes: **{CompturretsKillsAvgPer10Min}**\nMost Turret Kills In Game: **{CompturretsKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "tracer")
                {
                    string ComphealthRecovered = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecovered.ToString();
                    string ComphealthRecoveredAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecoveredAvgPer10Min.ToString();
                    string ComphealthRecoveredMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.healthRecoveredMostInGame.ToString();
                    string ComppulseBombsAttached = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttached.ToString();
                    string ComppulseBombsAttachedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttachedAvgPer10Min.ToString();
                    string ComppulseBombsAttachedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsAttachedMostInGame.ToString();
                    string ComppulseBombsKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKills.ToString();
                    string ComppulseBombsKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKillsAvgPer10Min.ToString();
                    string ComppulseBombsKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.pulseBombsKillsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Health Recalled: **{ComphealthRecovered}**\nAverage Health Recalled Per 10 Minutes: **{ComphealthRecoveredAvgPer10Min}**\nMost Health Recalled In Game: **{ComphealthRecoveredMostInGame}**\nPulse Bomb Attached: **{ComppulseBombsAttached}**\nAverage Pulse Bombs Attached Per 10 Minutes: **{ComppulseBombsAttachedAvgPer10Min}**\nMost Pulse Bombs Attached In Game: **{ComppulseBombsAttachedMostInGame}**\nPulse Bomb Kills: **{ComppulseBombsKills}**\nAverage Pulse Bomb Kills Per 10 Minutes: **{ComppulseBombsKillsAvgPer10Min}**\nMost Pulse Bomb Kills In Game: **{ComppulseBombsKillsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "widowmaker")
                {
                    string CompscopedAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracy.ToString();
                    string CompscopedAccuracyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedAccuracyBestInGame.ToString();
                    string CompscopedCriticalHits = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHits.ToString();
                    string CompscopedCriticalHitsAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAccuracy.ToString();
                    string CompscopedCriticalHitsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsAvgPer10Min.ToString();
                    string CompscopedCriticalHitsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.scopedCriticalHitsMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompvenomMineKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKills.ToString();
                    string CompvenomMineKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKillsAvgPer10Min.ToString();
                    string CompvenomMineKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.venomMineKillsMostInGame.ToString();

                    //recon assists
                    string CompreconAssists = dataObject.competitiveStats.careerStats[hero].assists.reconAssists.ToString();
                    string CompreconAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.reconAssistsAvgPer10Min.ToString();
                    string CompreconAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.reconAssistsMostInGame.ToString();

                    string assists = $"Recon Assists: **{CompreconAssists}**\nAverage Recon Assists Per 10 Minutes: **{CompreconAssistsAvgPer10Min}**\nMost Recon Assists In Game: **{CompreconAssistsMostInGame}**";
                    string heroSpecific = $"Scoped Accuracy: **{CompscopedAccuracy}**\nBest Scoped Accuracy In Game: **{CompscopedAccuracyBestInGame}**\nScoped Critical Hits Accuracy: **{CompscopedCriticalHitsAccuracy}**\nScoped Critical Hits: **{CompscopedCriticalHits}**\nAverage Scoped Critical Hits Per 10 Minutes: **{CompscopedCriticalHitsAvgPer10Min}**\nMost Scoped Critical Hits In Game: **{CompscopedCriticalHitsMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nVenom Mine Kills: **{CompvenomMineKills}**\nAverage Venom Mine Kills Per 10 Minutes: **{CompvenomMineKillsAvgPer10Min}**\nMost Venom Mine Kills In Game: **{CompvenomMineKillsMostInGame}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "winston")
                {
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompjumpPackKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKills.ToString();
                    string CompjumpPackKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKillsAvgPer10Min.ToString();
                    string CompjumpPackKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.jumpPackKillsMostInGame.ToString();
                    string CompmeleeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKills.ToString();
                    string CompmeleeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKillsAvgPer10Min.ToString();
                    string CompmeleeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.meleeKillsMostInGame.ToString();
                    string CompplayersKnockedBack = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string CompplayersKnockedBackAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string CompplayersKnockedBackMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string CompprimalRageKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKills.ToString();
                    string CompprimalRageKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKillsAvgPer10Min.ToString();
                    string CompprimalRageKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.primalRageKillsMostInGame.ToString();
                    string CompprimalRageMeleeAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompteslaCannonAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.teslaCannonAccuracy.ToString();
                    string CompweaponKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.weaponKills.ToString();

                    string heroSpecific = $"Damage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nJump Pack Kills: **{CompjumpPackKills}**\nAverage Jump Pack Kills Per 10 Minutes: **{CompjumpPackKillsAvgPer10Min}**\nMost Jump Pack Kills In Game: **{CompjumpPackKillsMostInGame}**\nMelee Kills: **{CompmeleeKills}**\nAverage Melee Kills Per 10 Minutes: **{CompmeleeKillsAvgPer10Min}**\nMost Melee Kills In Game: **{CompmeleeKillsMostInGame}**\nPlayers Knocked Back: **{CompplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{CompplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{CompplayersKnockedBackMostInGame}**\nPrimal Rage Kills: **{CompprimalRageKills}**\nAverage Primal Rage Kills In 10 Minutes: **{CompprimalRageKillsAvgPer10Min}**\nMost Primal Rage Kills In Game: **{CompprimalRageKillsMostInGame}**\nPrimal Rage Melee Accuracy: **{CompprimalRageMeleeAccuracy}**\nTesla Cannon Accuracy: **{CompteslaCannonAccuracy}**\nWeapon Kils: **{CompweaponKills}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "wreckingBall")
                {
                    string CompplayersKnockedBack = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBack.ToString();
                    string CompplayersKnockedBackAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackAvgPer10Min.ToString();
                    string CompplayersKnockedBackMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.playersKnockedBackMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    string heroSpecific = $"Players Knocked Back: **{CompplayersKnockedBack}**\nAverage Players Knocked Back Per 10 Minutes: **{CompplayersKnockedBackAvgPer10Min}**\nMost Players Knocked Back In Game: **{CompplayersKnockedBackMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zarya")
                {
                    string CompaverageEnergy = dataObject.competitiveStats.careerStats[hero].heroSpecific.averageEnergy.ToString();
                    string CompaverageEnergyBestInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.averageEnergyBestInGame.ToString();
                    string CompdamageBlocked = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlocked.ToString();
                    string CompdamageBlockedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedAvgPer10Min.ToString();
                    string CompdamageBlockedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.damageBlockedMostInGame.ToString();
                    string CompgravitonSurgeKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKills.ToString();
                    string CompgravitonSurgeKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKillsAvgPer10Min.ToString();
                    string CompgravitonSurgeKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.gravitonSurgeKillsMostInGame.ToString();
                    string ComphighEnergyKills = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKills.ToString();
                    string ComphighEnergyKillsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKillsAvgPer10Min.ToString();
                    string ComphighEnergyKillsMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.highEnergyKillsMostInGame.ToString();
                    string CompprimaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.primaryFireAccuracy.ToString();
                    string CompprojectedBarriersApplied = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersApplied.ToString();
                    string CompprojectedBarriersAppliedAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersAppliedAvgPer10Min.ToString();
                    string CompprojectedBarriersAppliedMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.projectedBarriersAppliedMostInGame.ToString();
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();

                    //offensive and defensive assists
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Average Energy: **{CompaverageEnergy}**\nBest Average Energy In Game: **{CompaverageEnergyBestInGame}**\nDamage Blocked: **{CompdamageBlocked}**\nAverage Damage Blocked Per 10 Minutes: **{CompdamageBlockedAvgPer10Min}**\nMost Damage Blocked In Game: **{CompdamageBlockedMostInGame}**\nGraviton Surge Kills: **{CompgravitonSurgeKills}**\nAverage Graviton Surge Kills Per 10 Minutes: **{CompgravitonSurgeKillsAvgPer10Min}**\nMost Graviton Surge Kills In Game: **{CompgravitonSurgeKillsMostInGame}**\nHigh Energy Kills: **{ComphighEnergyKills}**\nAverage High Energy Kills Per 10 Minutes: **{ComphighEnergyKillsAvgPer10Min}**\nMost High Energy Kills In Game: **{ComphighEnergyKillsMostInGame}**\nPrimary Fire Accuracy: **{CompprimaryFireAccuracy}**\nProjected Barriers Applied: **{CompprojectedBarriersApplied}**\nAverage Projected Barriers Provided Per 10 Minutes: **{CompprojectedBarriersAppliedAvgPer10Min}**\nMost Projected Barriers Provided In Game: **{CompprojectedBarriersAppliedMostInGame}**\nSecondary Fire Accuracy: **{CompsecondaryFireAccuracy}*";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
                if (hero == "zenyatta")
                {
                    string CompsecondaryFireAccuracy = dataObject.competitiveStats.careerStats[hero].heroSpecific.secondaryFireAccuracy.ToString();
                    string CompselfHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealing.ToString();
                    string CompselfHealingAvgPer10Min = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingAvgPer10Min.ToString();
                    string CompselfHealingMostInGame = dataObject.competitiveStats.careerStats[hero].heroSpecific.selfHealingMostInGame.ToString();
                    string ComptranscendenceHealing = dataObject.competitiveStats.careerStats[hero].heroSpecific.transcendenceHealing.ToString();
                    string ComptranscendenceHealingBest = dataObject.competitiveStats.careerStats[hero].heroSpecific.transcendenceHealingBest.ToString();

                    //healing stats for healers
                    string CompdefensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssists.ToString();
                    string CompdefensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsAvgPer10Min.ToString();
                    string CompdefensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.defensiveAssistsMostInGame.ToString();
                    string ComphealingDone = dataObject.competitiveStats.careerStats[hero].assists.healingDone.ToString();
                    string ComphealingDoneAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.healingDoneAvgPer10Min.ToString();
                    string ComphealingDoneMostInGame = dataObject.competitiveStats.careerStats[hero].assists.healingDoneMostInGame.ToString();
                    string CompoffensiveAssists = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssists.ToString();
                    string CompoffensiveAssistsAvgPer10Min = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsAvgPer10Min.ToString();
                    string CompoffensiveAssistsMostInGame = dataObject.competitiveStats.careerStats[hero].assists.offensiveAssistsMostInGame.ToString();

                    string assists = $"Defensive Assists: **{CompdefensiveAssists}**\nAverage Defensive Assists Per 10 Minutes: **{CompdefensiveAssistsAvgPer10Min}**\nMost Defensive Assists In Game: **{CompdefensiveAssistsMostInGame}**\nHealing Done: **{ComphealingDone}**\nAverage Healing Done Per 10 Minutes: **{ComphealingDoneAvgPer10Min}**\nMost Healing Done In Game: **{ComphealingDoneMostInGame}**\nOffensive Assists: **{CompoffensiveAssists}**\nAverage Offensive Assists Per 10 Minutes: **{CompoffensiveAssistsAvgPer10Min}**\nMost Offensive Assists In Game: **{CompoffensiveAssistsMostInGame}**";
                    string heroSpecific = $"Secondary Fire Accuracy: **{CompsecondaryFireAccuracy}**\nSelf Healing: **{CompselfHealing}**\nAverage Self Healing Per 10 Minutes: **{CompselfHealingAvgPer10Min}**\nMost Self Healing In Game: **{CompselfHealingMostInGame}**\nTranscendence Healing: **{ComptranscendenceHealing}**\nBest Transcendence Healing In Game: **{ComptranscendenceHealingBest}**";
                    PaginatedMessage pages = new PaginatedMessage { Pages = new[] { compAvg, compBest, compTotal, compMisc, assists, heroSpecific }, Content = $"{config.OverwatchID}'s Hero Stats for {hero}", Color = Color.Blue, Title = new[] { "Averages", "Best", "Totals", "Miscellaneous", "Assists", "Hero Specific" } };
                    await PagedReplyAsync(pages);
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync("Have you already registered your Battle.Net account with `w!owaccount`?\nMake sure you have played Competitive with this hero, otherwise check your command.\n**w!myowhscomp <hero> Ex: w!myowhscomp dVa**");
            }
        }

        private string GetHero(string value)
        {
            if (value == "dva" || value == "d.va") return $"dVa";
            else if (value == "baguette") return $"brigitte";
            else if (value == "torb") return $"torbjorn";
            else if (value == "soldier") return $"soldier76";
            else if (value == "mcree") return $"mcree";
            else if (value == "widow") return $"widowmaker";
            else if (value == "sym") return $"symmetra";
            else if (value == "rein") return $"reinhardt";
            else if (value == "zen") return $"zenyatta";
            else if (value == "wreckingball" || value == "hammond") return $"wreckingBall";
            else return value;
        }
    }
}
