﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class PlayerGameStats: Player
    {
        public string gameId { get; set; }
        public int playerTeamId { get; set; }
        public string position { get; set; }  //Player position
        public string timeOnIce { get; set; }  // Player's total time on ice
        public string assists { get; set; } // Total assists
        public string goals { get; set; } // Total goals
        public string points { get; set; }
        public string shots { get; set; } // Total shots on net
        public string hits { get; set; } // Total hits
        public string powerPlayGoals { get; set; } // Total powerplay goals
        public string powerPlayAssists { get; set; } // Total powerplay assists
        public string penaltyMinutes { get; set; } // Total penalties in minutes
        public string faceoffWins { get; set; } // Total won faceoffs
        public string faceoffWinPercentage { get; set; } // % won faceoffs
        public string faceoffsTaken { get; set; } // Total faceoffs taken
        public string takeaways { get; set; } // Total takeaways
        public string giveaways { get; set; }  //Total giveaways
        public string shorthandedGoals { get; set; } // Total shorthanded goals scored
        public string shorthandedAssists { get; set; } //Total shorthanded assists
        public string blocked { get; set; } // Total blocked shots
        public string plusMinus { get; set; } // +/- rating
        public string evenTimeOnIce { get; set; } // Total even strength time on ice
        public string powerPlayTimeOnIce { get; set; } // Total powerplay time on ice
        public string shorthandedTimeOnIce { get; set; } // Total Penalty Kill time on ice

        // Goalie specific stats
        public string goalieTimeOnIce { get; set; } // If goalie
        public string shotsAgainst { get; set; } // Total shots faced
        public string shotsSaved { get; set; } // Total saves
        public string powerPlayShotsSaved { get; set; } // Total PP shots saved
        public string shorthandedShotsSaved { get; set; } // Total penalty kill shots saved
        public string evenSaved { get; set; } // Total even strength shots saved
        public string shorthandedShotsAgainst { get; set; } // Total Penalty Kill shots faced

        public string evenShotsAgainst { get; set; } // Total even strength shots faced
        public string powerPlayShotsAgainst { get; set; } // Total PP shots faced
        public string decision { get; set; } // Win or loss
        public string savePercentage { get; set; } // Save %
        public string evenSavePercentage { get; set; } // Even strength save %
        public string powerPlaySavePercentage { get; set; } //PP save %
        public string shorthandedSavePercentage { get; set; }  // Shorthanded save %
        public JObject playerGameStatsJson { get; set; } // Populate the raw JSON to a property


        public PlayerGameStats(JToken player, int nhlTeamId, string theGameId)
        {
            gameId = theGameId;
            playerTeamId = nhlTeamId;
            playerID = Convert.ToInt32(player.SelectToken("playerId"));
            
            // Non-goalie specific stats
            if (player.SelectToken("position").ToString() != "G")
            {
                // Get Player stats info from the player JToken
                hits = player.SelectToken("hits").ToString();
                goals = player.SelectToken("goals").ToString();
                assists = player.SelectToken("assists").ToString();
                points = player.SelectToken("points").ToString();
                powerPlayGoals = player.SelectToken("powerPlayGoals").ToString();
                powerPlayAssists = " ";
                penaltyMinutes = player.SelectToken("pim").ToString();
                faceoffWins = " ";
                faceoffWinPercentage = player.SelectToken("faceoffWinningPctg").ToString();
                shots = player.SelectToken("shots").ToString();
                faceoffsTaken = " ";
                takeaways = " ";
                giveaways = " ";
                shorthandedGoals = " ";
                shorthandedAssists = " ";
                blocked = " ";
                plusMinus = player.SelectToken("plusMinus").ToString();
                timeOnIce = player.SelectToken("toi").ToString();
                evenTimeOnIce = " ";
                powerPlayTimeOnIce = " ";
                shorthandedTimeOnIce = " ";
            }

            // Goalie specific stats
            if (player.SelectToken("position").ToString() == "G")
            {
                goalieTimeOnIce = player.SelectToken("toi").ToString();
                string[] shotsFacedRatio = Utilities.getRatioFromString(player.SelectToken("saveShotsAgainst").ToString());
                shotsAgainst = shotsFacedRatio[1];
                shotsSaved = shotsFacedRatio[0];
                string[] powerPlayShotsFacedRatio = Utilities.getRatioFromString(player.SelectToken("powerPlayShotsAgainst").ToString());
                powerPlayShotsSaved = powerPlayShotsFacedRatio[0];
                powerPlayShotsAgainst = powerPlayShotsFacedRatio[1];
                string[] shorthandedShotsFacedRatio = Utilities.getRatioFromString(player.SelectToken("shorthandedShotsAgainst").ToString());
                shorthandedShotsSaved = shorthandedShotsFacedRatio[0];
                shorthandedShotsAgainst = shorthandedShotsFacedRatio[1];
                string[] evenShotsFacedRatio = Utilities.getRatioFromString(player.SelectToken("evenStrengthShotsAgainst").ToString());
                evenSaved = evenShotsFacedRatio[0];
                evenShotsAgainst = evenShotsFacedRatio[1];

                JToken doesKeyExist = player.SelectToken("decision");
                if (doesKeyExist != null)
                {
                    decision = player.SelectToken("decision").ToString();
                }
                else
                {
                    decision = " ";
                }

                if (shotsAgainst == "0")
                    savePercentage = "0";   
                else
                    savePercentage = (Convert.ToInt16(shotsSaved) / Convert.ToInt16(shotsAgainst)).ToString();
                
                if (evenShotsAgainst == "0")
                    evenSavePercentage = "0";
                else
                    evenSavePercentage = (Convert.ToInt16(evenSaved) / Convert.ToInt16(evenShotsAgainst)).ToString();
                
                if (powerPlayShotsAgainst == "0")
                    powerPlaySavePercentage = "0";
                else
                    powerPlaySavePercentage = (Convert.ToInt16(powerPlayShotsSaved) / Convert.ToInt16(powerPlayShotsAgainst)).ToString();
                
                if (shorthandedShotsAgainst == "0")
                    shorthandedSavePercentage = "0";
                else
                    shorthandedSavePercentage = (Convert.ToInt16(shorthandedShotsSaved) / Convert.ToInt16(shorthandedShotsAgainst)).ToString();
            }
            


            string playerInfoURL = NHLAPIServiceURLs.specificPlayer.Replace("###", playerID.ToString());
            var playerInfoJson = DataAccessLayer.ExecuteAPICall(playerInfoURL);

            firstName = playerInfoJson.SelectToken("firstName.default").ToString();
            lastName = playerInfoJson.SelectToken("lastName.default").ToString();
            primaryNumber = Convert.ToInt32(playerInfoJson.SelectToken("sweaterNumber"));
            birthDate = playerInfoJson.SelectToken("birthDate").ToString();
            currentAge = Utilities.GetCurrentAge(birthDate);
            birthCity = playerInfoJson.SelectToken("birthCity.default").ToString();
            if (playerInfoJson.ContainsKey("birthStateProvince"))
                birthStateProvince = playerInfoJson.SelectToken("birthStateProvince.default").ToString();
            birthCountry = playerInfoJson.SelectToken("birthCountry").ToString();
            nationality = " ";
            height = Convert.ToInt16(playerInfoJson.SelectToken("heightInInches"));
            weight = Convert.ToInt16(playerInfoJson.SelectToken("weightInPounds"));
            active = playerInfoJson.SelectToken("isActive").ToString();
            alternateCaptain = " ";
            captain = " ";
            rookie = " ";
            shootsCatches = " ";
            rosterStatus = active;
            currentTeamID = nhlTeamId;
            primaryPositionCode = playerInfoJson.SelectToken("position").ToString();
            if (primaryPositionCode == "C")
            { 
                primaryPositionName = "Center";
                primaryPositionType = "Forward";
                primaryPositionAbbr = "C";
            }
            else if (primaryPositionCode == "L")
            {
                primaryPositionName = "Left Wing";
                primaryPositionType = "Forward";
                primaryPositionAbbr = "LW";
            }
            else if (primaryPositionCode == "R")
            {
                primaryPositionName = "Right Wing";
                primaryPositionType = "Forward";
                primaryPositionAbbr = "RW";
            }
            else if (primaryPositionCode == "D")
            {
                primaryPositionName = "Defense";
                primaryPositionType = "Defense";
                primaryPositionAbbr = "D";
            }
            else if (primaryPositionCode == "G")
            {
                primaryPositionName = "Goalie";
                primaryPositionType = "Goalie";
                primaryPositionAbbr = "G";
            }
            else
            {
                primaryPositionName = "Unknown";
                primaryPositionType = "Unknown";
                primaryPositionAbbr = "Unknown";
            }
                
            playerJson = playerInfoJson;

        }

        //public PlayerGameStats(int playerID, JToken json) : base(playerID)
        //{
        //    position = json.SelectToken("position.code").ToString();
        //    JObject statsJson = json.SelectToken("stats").ToObject<JObject>();

        //    // Populate the raw JSON to a property
        //    playerGameStatsJson = statsJson;

        //    // Get the list of pure stats from the statsJson variable so that the ContainsKey method can be use
        //    // in the if statements

        //    // If the player was not on the ice during the game, blank the stats out.
        //    if (!statsJson.ContainsKey("skaterStats") && !statsJson.ContainsKey("goalieStats"))
        //    {
        //        timeOnIce = "0:00";
        //        assists = "0";
        //        goals = "0";
        //        shots = "0";
        //        hits = "0";
        //        powerPlayGoals = "0";
        //        powerPlayAssists = "0";
        //        penaltyMinutes = "0";
        //        faceoffWins = "0";
        //        faceoffWinPercentage = "0";
        //        faceoffsTaken = "0";
        //        takeaways = "0";
        //        giveaways = "0";
        //        shorthandedGoals = "0";
        //        shorthandedAssists = "0";
        //        blocked = "0";
        //        plusMinus = "0";
        //        evenTimeOnIce = "0:00";
        //        powerPlayTimeOnIce = "0:00";
        //        shorthandedTimeOnIce = "0:00";

        //        goalieTimeOnIce = "0:00";
        //        shotsFaced = "0";
        //        shotsSaved = "0";
        //        powerPlayShotsSaved = "0";
        //        shorthandedShotsSaved = "0";
        //        evenSaved = "0";
        //        shorthandedShotsAgainst = "0";
        //        evenShotsAgainst = "0";
        //        powerPlayShotsAgainst = "0";
        //        decision = "N/A";
        //        savePercentage = "0";
        //        evenSavePercentage = "0";
        //        powerPlaySavePercentage = "0";
        //        shorthandedSavePercentage = "0";


        //    }

        //    // If the player was a forward or defenceman during the game, populate the stats
        //    if (statsJson.ContainsKey("skaterStats"))
        //    {
        //        // Get the list of pure stats from the statsJson variable so that the ContainsKey method can be use
        //        // in the if statements
        //        JObject pureStats = statsJson.SelectToken("skaterStats").ToObject<JObject>();

        //        if (pureStats.ContainsKey("timeOnIce"))
        //        {
        //            timeOnIce = json.SelectToken("stats.skaterStats.timeOnIce").ToString();
        //            goalieTimeOnIce = "0:00";
        //        }
        //        else
        //        {
        //            timeOnIce = "0:00";
        //        }

        //        if (pureStats.ContainsKey("assists"))
        //        {
        //            assists = json.SelectToken("stats.skaterStats.assists").ToString();
        //        }
        //        else
        //        {
        //            assists = "0";
        //        }

        //        if (pureStats.ContainsKey("goals"))
        //        {
        //            goals = json.SelectToken("stats.skaterStats.goals").ToString();
        //        }
        //        else
        //        {
        //            goals = "0";
        //        }

        //        if (pureStats.ContainsKey("shots"))
        //        {
        //            shots = json.SelectToken("stats.skaterStats.shots").ToString();
        //        }
        //        else
        //        {
        //            shots = "0";
        //        }

        //        if (pureStats.ContainsKey("hits"))
        //        {
        //            hits = json.SelectToken("stats.skaterStats.hits").ToString();
        //        }
        //        else
        //        {
        //            hits = "0";
        //        }

        //        if (pureStats.ContainsKey("powerPlayGoals"))
        //        {
        //            powerPlayGoals = json.SelectToken("stats.skaterStats.powerPlayGoals").ToString();
        //        }
        //        else
        //        {
        //            powerPlayGoals = "0";
        //        }

        //        if (pureStats.ContainsKey("powerPlayAssists"))
        //        {
        //            powerPlayAssists = json.SelectToken("stats.skaterStats.powerPlayAssists").ToString();
        //        }
        //        else
        //        {
        //            powerPlayAssists = "0";
        //        }

        //        if (pureStats.ContainsKey("penaltyMinutes"))
        //        {
        //            penaltyMinutes = json.SelectToken("stats.skaterStats.penaltyMinutes").ToString();
        //        }
        //        else
        //        {
        //            penaltyMinutes = "0";
        //        }

        //        if (pureStats.ContainsKey("faceOffPct"))
        //        {
        //            faceoffWinPercentage = json.SelectToken("stats.skaterStats.faceOffPct").ToString();
        //        }
        //        else
        //        {
        //            faceoffWinPercentage = "0";
        //        }

        //        if (pureStats.ContainsKey("faceOffWins"))
        //        {
        //            faceoffWins = json.SelectToken("stats.skaterStats.faceOffWins").ToString();
        //        }
        //        else
        //        {
        //            faceoffWins = "0";
        //        }

        //        if (pureStats.ContainsKey("faceoffTaken"))
        //        {
        //            faceoffsTaken = json.SelectToken("stats.skaterStats.faceoffTaken").ToString();
        //        }
        //        else
        //        {
        //            faceoffsTaken = "0";
        //        }

        //        if (pureStats.ContainsKey("takeaways"))
        //        {
        //            takeaways = json.SelectToken("stats.skaterStats.takeaways").ToString();
        //        }
        //        else
        //        {
        //            takeaways = "0";
        //        }

        //        if (pureStats.ContainsKey("giveaways"))
        //        {
        //            giveaways = json.SelectToken("stats.skaterStats.giveaways").ToString();
        //        }
        //        else
        //        {
        //            giveaways = "0";
        //        }

        //        if (pureStats.ContainsKey("shortHandedGoals"))
        //        {
        //            shorthandedGoals = json.SelectToken("stats.skaterStats.shortHandedGoals").ToString();
        //        }
        //        else
        //        {
        //            shorthandedGoals = "0";
        //        }

        //        if (pureStats.ContainsKey("shortHandedAssists"))
        //        {
        //            shorthandedAssists = json.SelectToken("stats.skaterStats.shortHandedAssists").ToString();
        //        }
        //        else
        //        {
        //            shorthandedAssists = "0";
        //        }

        //        if (pureStats.ContainsKey("blocked"))
        //        {
        //            blocked = json.SelectToken("stats.skaterStats.blocked").ToString();
        //        }
        //        else
        //        {
        //            blocked = "0";
        //        }

        //        if (pureStats.ContainsKey("plusMinus"))
        //        {
        //            plusMinus = json.SelectToken("stats.skaterStats.plusMinus").ToString();
        //        }
        //        else
        //        {
        //            plusMinus = "0";
        //        }

        //        if (pureStats.ContainsKey("evenTimeOnIce"))
        //        {
        //            evenTimeOnIce = json.SelectToken("stats.skaterStats.evenTimeOnIce").ToString();
        //        }
        //        else
        //        {
        //            evenTimeOnIce = "0:00";
        //        }
        //        if (pureStats.ContainsKey("powerPlayTimeOnIce"))
        //        {
        //            powerPlayTimeOnIce = json.SelectToken("stats.skaterStats.powerPlayTimeOnIce").ToString();
        //        }
        //        else
        //        {
        //            powerPlayTimeOnIce = "0:00";
        //        }

        //        if (pureStats.ContainsKey("shortHandedTimeOnIce"))
        //        {
        //            shorthandedTimeOnIce = json.SelectToken("stats.skaterStats.shortHandedTimeOnIce").ToString();
        //        }
        //        else
        //        {
        //            shorthandedTimeOnIce = "0:00";
        //        }

        //        // Blank out the goalie-related stats
        //        goalieTimeOnIce = "0:00";
        //        shotsFaced = "0";
        //        shotsSaved = "0";
        //        powerPlayShotsSaved = "0";
        //        shorthandedShotsSaved = "0";
        //        evenSaved = "0";
        //        shorthandedShotsAgainst = "0";
        //        evenShotsAgainst = "0";
        //        powerPlayShotsAgainst = "0";
        //        decision = "N/A";
        //        savePercentage = "0";
        //        evenSavePercentage = "0";
        //        powerPlaySavePercentage = "0";
        //        shorthandedSavePercentage = "0";
        //    }

        //    // If the player was a goalie during the game, populate the stats
        //    if (statsJson.ContainsKey("goalieStats"))
        //    {
        //        // Get the list of pure stats from the statsJson variable so that the ContainsKey method can be use
        //        // in the if statements
        //        JObject pureStats = statsJson.SelectToken("goalieStats").ToObject<JObject>();

        //        if (pureStats.ContainsKey("timeOnIce"))
        //        {
        //            timeOnIce = json.SelectToken("stats.goalieStats.timeOnIce").ToString();
        //            goalieTimeOnIce = json.SelectToken("stats.goalieStats.timeOnIce").ToString();
        //        }
        //        else
        //        {
        //            timeOnIce = "0:00";
        //        }

        //        if (pureStats.ContainsKey("assists"))
        //        {
        //            assists = json.SelectToken("stats.goalieStats.assists").ToString();
        //        }
        //        else
        //        {
        //            assists = "0";
        //        }

        //        if (pureStats.ContainsKey("goals"))
        //        {
        //            goals = json.SelectToken("stats.goalieStats.goals").ToString();
        //        }
        //        else
        //        {
        //            goals = "0";
        //        }

        //        if (pureStats.ContainsKey("pim"))
        //        {
        //            penaltyMinutes = json.SelectToken("stats.goalieStats.pim").ToString();
        //        }
        //        else
        //        {
        //            penaltyMinutes = "0";
        //        }

        //        if (pureStats.ContainsKey("shots"))
        //        {
        //            shots = json.SelectToken("stats.goalieStats.shots").ToString();
        //        }
        //        else
        //        {
        //            shots = "0";
        //        }

        //        if (pureStats.ContainsKey("saves"))
        //        {
        //            shotsSaved = json.SelectToken("stats.goalieStats.saves").ToString();
        //        }
        //        else
        //        {
        //            shotsSaved = "0";
        //        }
        //        if (pureStats.ContainsKey("powerPlaySaves"))
        //        {
        //            powerPlayShotsSaved = json.SelectToken("stats.goalieStats.powerPlaySaves").ToString();
        //        }
        //        else
        //        {
        //            powerPlayShotsSaved = "0";
        //        }

        //        if (pureStats.ContainsKey("shortHandedSaves"))
        //        {
        //            shorthandedShotsSaved = json.SelectToken("stats.goalieStats.shortHandedSaves").ToString();
        //        }
        //        else
        //        {
        //            shorthandedShotsSaved = "0";
        //        }

        //        if (pureStats.ContainsKey("evenSaves"))
        //        {
        //            evenSaved = json.SelectToken("stats.goalieStats.evenSaves").ToString();
        //        }
        //        else
        //        {
        //            evenSaved = "0";
        //        }

        //        if (pureStats.ContainsKey("powerPlayShotsAgainst"))
        //        {
        //            powerPlayShotsAgainst = json.SelectToken("stats.goalieStats.powerPlayShotsAgainst").ToString();
        //        }
        //        else
        //        {
        //            powerPlayShotsAgainst = "0";
        //        }

        //        if (pureStats.ContainsKey("shortHandedShotsAgainst"))
        //        {
        //            shorthandedShotsAgainst = json.SelectToken("stats.goalieStats.shortHandedShotsAgainst").ToString();
        //        }
        //        else
        //        {
        //            shorthandedShotsAgainst = "0";
        //        }

        //        if (pureStats.ContainsKey("evenShotsAgainst"))
        //        {
        //            evenShotsAgainst = json.SelectToken("stats.goalieStats.evenShotsAgainst").ToString();
        //        }
        //        else
        //        {
        //            evenShotsAgainst = "0";
        //        }

        //        if (pureStats.ContainsKey("decision"))
        //        {
        //            decision = json.SelectToken("stats.goalieStats.decision").ToString();
        //        }
        //        else
        //        {
        //            decision = "N/A";
        //        }

        //        if (pureStats.ContainsKey("savePercentage"))
        //        {
        //            savePercentage = json.SelectToken("stats.goalieStats.savePercentage").ToString();
        //        }
        //        else
        //        {
        //            savePercentage = "0";
        //        }

        //        if (pureStats.ContainsKey("evenStrengthSavePercentage"))
        //        {
        //            evenSavePercentage = json.SelectToken("stats.goalieStats.evenStrengthSavePercentage").ToString();
        //        }
        //        else
        //        {
        //            evenSavePercentage = "0";
        //        }

        //        if (pureStats.ContainsKey("powerPlaySavePercentage"))
        //        {
        //            powerPlaySavePercentage = json.SelectToken("stats.goalieStats.powerPlaySavePercentage").ToString();
        //        }
        //        else
        //        {
        //            powerPlaySavePercentage = "0";
        //        }

        //        // Blank out the non-goalie related stats
        //        powerPlayGoals = "0";
        //        powerPlayAssists = "0";
        //        penaltyMinutes = "0";
        //        faceoffWins = "0";
        //        faceoffWinPercentage = "0";
        //        faceoffsTaken = "0";
        //        takeaways = "0";
        //        giveaways = "0";
        //        shorthandedGoals = "0";
        //        shorthandedAssists = "0";
        //        blocked = "0";
        //        plusMinus = "0";
        //        evenTimeOnIce = "0:00";
        //        powerPlayTimeOnIce = "0:00";
        //        shorthandedTimeOnIce = "0:00";
        //    }

        //}

        //public PlayerGameStats(int playerID, int playerGameTeamId, JToken json) : base(playerID)
        //{
        //    position = json.SelectToken("position.code").ToString();
        //    JObject statsJson = json.SelectToken("stats").ToObject<JObject>();

        //    // Populate the raw JSON to a property
        //    playerGameStatsJson = statsJson;

        //    // Get the list of pure stats from the statsJson variable so that the ContainsKey method can be use
        //    // in the if statements

        //    // If the player was not on the ice during the game, blank the stats out.
        //    if (!statsJson.ContainsKey("skaterStats") && !statsJson.ContainsKey("goalieStats"))
        //    {
        //        playerTeamId = playerGameTeamId;
        //        timeOnIce = "0:00";
        //        assists = "0";
        //        goals = "0";
        //        shots = "0";
        //        hits = "0";
        //        powerPlayGoals = "0";
        //        powerPlayAssists = "0";
        //        penaltyMinutes = "0";
        //        faceoffWins = "0";
        //        faceoffWinPercentage = "0";
        //        faceoffsTaken = "0";
        //        takeaways = "0";
        //        giveaways = "0";
        //        shorthandedGoals = "0";
        //        shorthandedAssists = "0";
        //        blocked = "0";
        //        plusMinus = "0";
        //        evenTimeOnIce = "0:00";
        //        powerPlayTimeOnIce = "0:00";
        //        shorthandedTimeOnIce = "0:00";

        //        goalieTimeOnIce = "0:00";
        //        shotsFaced = "0";
        //        shotsSaved = "0";
        //        powerPlayShotsSaved = "0";
        //        shorthandedShotsSaved = "0";
        //        evenSaved = "0";
        //        shorthandedShotsAgainst = "0";
        //        evenShotsAgainst = "0";
        //        powerPlayShotsAgainst = "0";
        //        decision = "N/A";
        //        savePercentage = "0";
        //        evenSavePercentage = "0";
        //        powerPlaySavePercentage = "0";
        //        shorthandedSavePercentage = "0";


        //    }

        //    // If the player was a forward or defenceman during the game, populate the stats
        //    if (statsJson.ContainsKey("skaterStats"))
        //    {
        //        playerTeamId = playerGameTeamId;
        //        // Get the list of pure stats from the statsJson variable so that the ContainsKey method can be use
        //        // in the if statements
        //        JObject pureStats = statsJson.SelectToken("skaterStats").ToObject<JObject>();

        //        if (pureStats.ContainsKey("timeOnIce"))
        //        {
        //            timeOnIce = json.SelectToken("stats.skaterStats.timeOnIce").ToString();
        //            goalieTimeOnIce = "0:00";
        //        }
        //        else
        //        {
        //            timeOnIce = "0:00";
        //        }

        //        if (pureStats.ContainsKey("assists"))
        //        {
        //            assists = json.SelectToken("stats.skaterStats.assists").ToString();
        //        }
        //        else
        //        {
        //            assists = "0";
        //        }

        //        if (pureStats.ContainsKey("goals"))
        //        {
        //            goals = json.SelectToken("stats.skaterStats.goals").ToString();
        //        }
        //        else
        //        {
        //            goals = "0";
        //        }

        //        if (pureStats.ContainsKey("shots"))
        //        {
        //            shots = json.SelectToken("stats.skaterStats.shots").ToString();
        //        }
        //        else
        //        {
        //            shots = "0";
        //        }

        //        if (pureStats.ContainsKey("hits"))
        //        {
        //            hits = json.SelectToken("stats.skaterStats.hits").ToString();
        //        }
        //        else
        //        {
        //            hits = "0";
        //        }

        //        if (pureStats.ContainsKey("powerPlayGoals"))
        //        {
        //            powerPlayGoals = json.SelectToken("stats.skaterStats.powerPlayGoals").ToString();
        //        }
        //        else
        //        {
        //            powerPlayGoals = "0";
        //        }

        //        if (pureStats.ContainsKey("powerPlayAssists"))
        //        {
        //            powerPlayAssists = json.SelectToken("stats.skaterStats.powerPlayAssists").ToString();
        //        }
        //        else
        //        {
        //            powerPlayAssists = "0";
        //        }

        //        if (pureStats.ContainsKey("penaltyMinutes"))
        //        {
        //            penaltyMinutes = json.SelectToken("stats.skaterStats.penaltyMinutes").ToString();
        //        }
        //        else
        //        {
        //            penaltyMinutes = "0";
        //        }

        //        if (pureStats.ContainsKey("faceOffPct"))
        //        {
        //            faceoffWinPercentage = json.SelectToken("stats.skaterStats.faceOffPct").ToString();
        //        }
        //        else
        //        {
        //            faceoffWinPercentage = "0";
        //        }

        //        if (pureStats.ContainsKey("faceOffWins"))
        //        {
        //            faceoffWins = json.SelectToken("stats.skaterStats.faceOffWins").ToString();
        //        }
        //        else
        //        {
        //            faceoffWins = "0";
        //        }

        //        if (pureStats.ContainsKey("faceoffTaken"))
        //        {
        //            faceoffsTaken = json.SelectToken("stats.skaterStats.faceoffTaken").ToString();
        //        }
        //        else
        //        {
        //            faceoffsTaken = "0";
        //        }

        //        if (pureStats.ContainsKey("takeaways"))
        //        {
        //            takeaways = json.SelectToken("stats.skaterStats.takeaways").ToString();
        //        }
        //        else
        //        {
        //            takeaways = "0";
        //        }

        //        if (pureStats.ContainsKey("giveaways"))
        //        {
        //            giveaways = json.SelectToken("stats.skaterStats.giveaways").ToString();
        //        }
        //        else
        //        {
        //            giveaways = "0";
        //        }

        //        if (pureStats.ContainsKey("shortHandedGoals"))
        //        {
        //            shorthandedGoals = json.SelectToken("stats.skaterStats.shortHandedGoals").ToString();
        //        }
        //        else
        //        {
        //            shorthandedGoals = "0";
        //        }

        //        if (pureStats.ContainsKey("shortHandedAssists"))
        //        {
        //            shorthandedAssists = json.SelectToken("stats.skaterStats.shortHandedAssists").ToString();
        //        }
        //        else
        //        {
        //            shorthandedAssists = "0";
        //        }

        //        if (pureStats.ContainsKey("blocked"))
        //        {
        //            blocked = json.SelectToken("stats.skaterStats.blocked").ToString();
        //        }
        //        else
        //        {
        //            blocked = "0";
        //        }

        //        if (pureStats.ContainsKey("plusMinus"))
        //        {
        //            plusMinus = json.SelectToken("stats.skaterStats.plusMinus").ToString();
        //        }
        //        else
        //        {
        //            plusMinus = "0";
        //        }

        //        if (pureStats.ContainsKey("evenTimeOnIce"))
        //        {
        //            evenTimeOnIce = json.SelectToken("stats.skaterStats.evenTimeOnIce").ToString();
        //        }
        //        else
        //        {
        //            evenTimeOnIce = "0:00";
        //        }
        //        if (pureStats.ContainsKey("powerPlayTimeOnIce"))
        //        {
        //            powerPlayTimeOnIce = json.SelectToken("stats.skaterStats.powerPlayTimeOnIce").ToString();
        //        }
        //        else
        //        {
        //            powerPlayTimeOnIce = "0:00";
        //        }

        //        if (pureStats.ContainsKey("shortHandedTimeOnIce"))
        //        {
        //            shorthandedTimeOnIce = json.SelectToken("stats.skaterStats.shortHandedTimeOnIce").ToString();
        //        }
        //        else
        //        {
        //            shorthandedTimeOnIce = "0:00";
        //        }

        //        // Blank out the goalie-related stats
        //        goalieTimeOnIce = "0:00";
        //        shotsFaced = "0";
        //        shotsSaved = "0";
        //        powerPlayShotsSaved = "0";
        //        shorthandedShotsSaved = "0";
        //        evenSaved = "0";
        //        shorthandedShotsAgainst = "0";
        //        evenShotsAgainst = "0";
        //        powerPlayShotsAgainst = "0";
        //        decision = "N/A";
        //        savePercentage = "0";
        //        evenSavePercentage = "0";
        //        powerPlaySavePercentage = "0";
        //        shorthandedSavePercentage = "0";
        //    }

        //    // If the player was a goalie during the game, populate the stats
        //    if (statsJson.ContainsKey("goalieStats"))
        //    {
        //        // Get the list of pure stats from the statsJson variable so that the ContainsKey method can be use
        //        // in the if statements
        //        JObject pureStats = statsJson.SelectToken("goalieStats").ToObject<JObject>();

        //        if (pureStats.ContainsKey("timeOnIce"))
        //        {
        //            timeOnIce = json.SelectToken("stats.goalieStats.timeOnIce").ToString();
        //            goalieTimeOnIce = json.SelectToken("stats.goalieStats.timeOnIce").ToString();
        //        }
        //        else
        //        {
        //            timeOnIce = "0:00";
        //        }

        //        if (pureStats.ContainsKey("assists"))
        //        {
        //            assists = json.SelectToken("stats.goalieStats.assists").ToString();
        //        }
        //        else
        //        {
        //            assists = "0";
        //        }

        //        if (pureStats.ContainsKey("goals"))
        //        {
        //            goals = json.SelectToken("stats.goalieStats.goals").ToString();
        //        }
        //        else
        //        {
        //            goals = "0";
        //        }

        //        if (pureStats.ContainsKey("pim"))
        //        {
        //            penaltyMinutes = json.SelectToken("stats.goalieStats.pim").ToString();
        //        }
        //        else
        //        {
        //            penaltyMinutes = "0";
        //        }

        //        if (pureStats.ContainsKey("shots"))
        //        {
        //            shots = json.SelectToken("stats.goalieStats.shots").ToString();
        //        }
        //        else
        //        {
        //            shots = "0";
        //        }

        //        if (pureStats.ContainsKey("saves"))
        //        {
        //            shotsSaved = json.SelectToken("stats.goalieStats.saves").ToString();
        //        }
        //        else
        //        {
        //            shotsSaved = "0";
        //        }
        //        if (pureStats.ContainsKey("powerPlaySaves"))
        //        {
        //            powerPlayShotsSaved = json.SelectToken("stats.goalieStats.powerPlaySaves").ToString();
        //        }
        //        else
        //        {
        //            powerPlayShotsSaved = "0";
        //        }

        //        if (pureStats.ContainsKey("shortHandedSaves"))
        //        {
        //            shorthandedShotsSaved = json.SelectToken("stats.goalieStats.shortHandedSaves").ToString();
        //        }
        //        else
        //        {
        //            shorthandedShotsSaved = "0";
        //        }

        //        if (pureStats.ContainsKey("evenSaves"))
        //        {
        //            evenSaved = json.SelectToken("stats.goalieStats.evenSaves").ToString();
        //        }
        //        else
        //        {
        //            evenSaved = "0";
        //        }

        //        if (pureStats.ContainsKey("powerPlayShotsAgainst"))
        //        {
        //            powerPlayShotsAgainst = json.SelectToken("stats.goalieStats.powerPlayShotsAgainst").ToString();
        //        }
        //        else
        //        {
        //            powerPlayShotsAgainst = "0";
        //        }

        //        if (pureStats.ContainsKey("shortHandedShotsAgainst"))
        //        {
        //            shorthandedShotsAgainst = json.SelectToken("stats.goalieStats.shortHandedShotsAgainst").ToString();
        //        }
        //        else
        //        {
        //            shorthandedShotsAgainst = "0";
        //        }

        //        if (pureStats.ContainsKey("evenShotsAgainst"))
        //        {
        //            evenShotsAgainst = json.SelectToken("stats.goalieStats.evenShotsAgainst").ToString();
        //        }
        //        else
        //        {
        //            evenShotsAgainst = "0";
        //        }

        //        if (pureStats.ContainsKey("decision"))
        //        {
        //            decision = json.SelectToken("stats.goalieStats.decision").ToString();
        //        }
        //        else
        //        {
        //            decision = "N/A";
        //        }

        //        if (pureStats.ContainsKey("savePercentage"))
        //        {
        //            savePercentage = json.SelectToken("stats.goalieStats.savePercentage").ToString();
        //        }
        //        else
        //        {
        //            savePercentage = "0";
        //        }

        //        if (pureStats.ContainsKey("evenStrengthSavePercentage"))
        //        {
        //            evenSavePercentage = json.SelectToken("stats.goalieStats.evenStrengthSavePercentage").ToString();
        //        }
        //        else
        //        {
        //            evenSavePercentage = "0";
        //        }

        //        if (pureStats.ContainsKey("powerPlaySavePercentage"))
        //        {
        //            powerPlaySavePercentage = json.SelectToken("stats.goalieStats.powerPlaySavePercentage").ToString();
        //        }
        //        else
        //        {
        //            powerPlaySavePercentage = "0";
        //        }

        //        // Blank out the non-goalie related stats
        //        powerPlayGoals = "0";
        //        powerPlayAssists = "0";
        //        penaltyMinutes = "0";
        //        faceoffWins = "0";
        //        faceoffWinPercentage = "0";
        //        faceoffsTaken = "0";
        //        takeaways = "0";
        //        giveaways = "0";
        //        shorthandedGoals = "0";
        //        shorthandedAssists = "0";
        //        blocked = "0";
        //        plusMinus = "0";
        //        evenTimeOnIce = "0:00";
        //        powerPlayTimeOnIce = "0:00";
        //        shorthandedTimeOnIce = "0:00";
        //    }

        //}
    }
}
