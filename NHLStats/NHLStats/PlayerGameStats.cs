using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class PlayerGameStats: Player
    {
        public string position { get; set; }  //Player position
        public string timeOnIce { get; set; }  // Player's total time on ice
        public string assists { get; set; } // Total assists
        public string goals { get; set; } // Total goals
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
        public string shotsFaced { get; set; } // Total shots faced
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


        public PlayerGameStats(int playerID, JToken json) : base(playerID)
        {
            position = json.SelectToken("position.code").ToString();
            JObject statsJson = json.SelectToken("stats").ToObject<JObject>();

            // Get the list of pure stats from the statsJson variable so that the ContainsKey method can be use
            // in the if statements
            
            if (statsJson.ContainsKey("skaterStats"))
            {
                // Get the list of pure stats from the statsJson variable so that the ContainsKey method can be use
                // in the if statements
                JObject pureStats = statsJson.SelectToken("skaterStats").ToObject<JObject>();

                if (pureStats.ContainsKey("timeOnIce"))
                {
                    timeOnIce = json.SelectToken("stats.skaterStats.timeOnIce").ToString();
                }

                if (pureStats.ContainsKey("assists"))
                {
                    assists = json.SelectToken("stats.skaterStats.assists").ToString();
                }
                if (pureStats.ContainsKey("goals"))
                {
                    goals = json.SelectToken("stats.skaterStats.goals").ToString();
                }
                if (pureStats.ContainsKey("shots"))
                {
                    shots = json.SelectToken("stats.skaterStats.shots").ToString();
                }
                if (pureStats.ContainsKey("hits"))
                {
                    hits = json.SelectToken("stats.skaterStats.hits").ToString();
                }
                if (pureStats.ContainsKey("powerPlayGoals"))
                {
                    powerPlayGoals = json.SelectToken("stats.skaterStats.powerPlayGoals").ToString();
                }
                if (pureStats.ContainsKey("powerPlayAssists"))
                {
                    powerPlayAssists = json.SelectToken("stats.skaterStats.powerPlayAssists").ToString();
                }
                if (pureStats.ContainsKey("penaltyMinutes"))
                {
                    penaltyMinutes = json.SelectToken("stats.skaterStats.penaltyMinutes").ToString();
                }
                if (pureStats.ContainsKey("faceOffPct"))
                {
                    faceoffWinPercentage = json.SelectToken("stats.skaterStats.faceOffPct").ToString();
                }
                if (pureStats.ContainsKey("faceOffWins"))
                {
                    faceoffWins = json.SelectToken("stats.skaterStats.faceOffWins").ToString();
                }
                if (pureStats.ContainsKey("faceoffTaken"))
                {
                    faceoffsTaken = json.SelectToken("stats.skaterStats.faceoffTaken").ToString();
                }
                if (pureStats.ContainsKey("takeaways"))
                {
                    takeaways = json.SelectToken("stats.skaterStats.takeaways").ToString();
                }
                if (pureStats.ContainsKey("giveaways"))
                {
                    giveaways = json.SelectToken("stats.skaterStats.giveaways").ToString();
                }
                if (pureStats.ContainsKey("shortHandedGoals"))
                {
                    shorthandedGoals = json.SelectToken("stats.skaterStats.shortHandedGoals").ToString();
                }
                if (pureStats.ContainsKey("shortHandedAssists"))
                {
                    shorthandedAssists = json.SelectToken("stats.skaterStats.shortHandedAssists").ToString();
                }
                if (pureStats.ContainsKey("blocked"))
                {
                    blocked = json.SelectToken("stats.skaterStats.blocked").ToString();
                }
                if (pureStats.ContainsKey("plusMinus"))
                {
                    plusMinus = json.SelectToken("stats.skaterStats.plusMinus").ToString();
                }
                if (pureStats.ContainsKey("evenTimeOnIce"))
                {
                    evenTimeOnIce = json.SelectToken("stats.skaterStats.evenTimeOnIce").ToString();
                }
                if (pureStats.ContainsKey("powerPlayTimeOnIce"))
                {
                    powerPlayTimeOnIce = json.SelectToken("stats.skaterStats.powerPlayTimeOnIce").ToString();
                }
                if (pureStats.ContainsKey("shortHandedTimeOnIce"))
                {
                    shorthandedTimeOnIce = json.SelectToken("stats.skaterStats.shortHandedTimeOnIce").ToString();
                }
            }


            if (statsJson.ContainsKey("goalieStats"))
            {
                // Get the list of pure stats from the statsJson variable so that the ContainsKey method can be use
                // in the if statements
                JObject pureStats = statsJson.SelectToken("goalieStats").ToObject<JObject>();

                if (pureStats.ContainsKey("timeOnIce"))
                {
                    timeOnIce = json.SelectToken("stats.goalieStats.timeOnIce").ToString();
                }
                if (pureStats.ContainsKey("assists"))
                {
                    assists = json.SelectToken("stats.goalieStats.assists").ToString();
                }
                if (pureStats.ContainsKey("goals"))
                {
                    goals = json.SelectToken("stats.goalieStats.goals").ToString();
                }
                if (pureStats.ContainsKey("pim"))
                {
                    penaltyMinutes = json.SelectToken("stats.goalieStats.pim").ToString();
                }
                if (pureStats.ContainsKey("shots"))
                {
                    shots = json.SelectToken("stats.goalieStats.shots").ToString();
                }
                if (pureStats.ContainsKey("saves"))
                {
                    shotsSaved = json.SelectToken("stats.goalieStats.saves").ToString();
                }
                if (pureStats.ContainsKey("powerPlaySaves"))
                {
                    powerPlayShotsSaved = json.SelectToken("stats.goalieStats.powerPlaySaves").ToString();
                }
                if (pureStats.ContainsKey("shortHandedSaves"))
                {
                    shorthandedShotsSaved = json.SelectToken("stats.goalieStats.shortHandedSaves").ToString();
                }
                if (pureStats.ContainsKey("evenSaves"))
                {
                    evenSaved = json.SelectToken("stats.goalieStats.evenSaves").ToString();
                }
                if (pureStats.ContainsKey("powerPlayShotsAgainst"))
                {
                    powerPlayShotsAgainst = json.SelectToken("stats.goalieStats.powerPlayShotsAgainst").ToString();
                }
                if (pureStats.ContainsKey("shortHandedShotsAgainst"))
                {
                    shorthandedShotsAgainst = json.SelectToken("stats.goalieStats.shortHandedShotsAgainst").ToString();
                }
                if (pureStats.ContainsKey("evenShotsAgainst"))
                {
                    evenShotsAgainst = json.SelectToken("stats.goalieStats.evenShotsAgainst").ToString();
                }
                if (pureStats.ContainsKey("decision"))
                {
                    decision = json.SelectToken("stats.goalieStats.decision").ToString();
                }
                if (pureStats.ContainsKey("savePercentage"))
                {
                    savePercentage = json.SelectToken("stats.goalieStats.savePercentage").ToString();
                }
                if (pureStats.ContainsKey("evenStrengthSavePercentage"))
                {
                    evenSavePercentage = json.SelectToken("stats.goalieStats.evenStrengthSavePercentage").ToString();
                }
                if (pureStats.ContainsKey("powerPlaySavePercentage"))
                {
                    powerPlaySavePercentage = json.SelectToken("stats.goalieStats.powerPlaySavePercentage").ToString();
                }

            }

        }
    }
}
