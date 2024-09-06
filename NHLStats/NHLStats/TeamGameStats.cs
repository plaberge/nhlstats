using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class TeamGameStats
    {
        public string gameId { get; set; } // Game Id for the Team Game Stats
        public int nhlTeamId { get; set; }  // Team Id for the Team Game Stats
        public string totalGoals { get; set; }  // Number of goals scored by the team
        public string totalPIM { get; set; } // Number of penalties in minutes by the team
        public string totalShots { get; set; } // Number of shots by the team
        public string powerPlayPercentage { get; set; } // % of PP goals on total attempts
        public string powerPlayGoals { get; set; } // # of PP goals
        public string powerPlayOpportunities { get; set; } // # of PPs
        public string faceOffWinPercentage { get; set; } // % of faceoffs won
        public string blockedShots { get; set; } // # of blocked shots
        public string takeaways { get; set; } // # of takeaways
        public string giveaways { get; set; } // # of giveaways
        public string hits { get; set; } // # of hits
        public List<PlayerGameStats> teamPlayers { get; set; }  // Team roster stats
        public JArray teamGameStatsJson { get; set; } // Populate the raw JSON to a property

        public TeamGameStats(JObject json, int teamId)
        {
            nhlTeamId = teamId; // Populate the nhlTeamId property
            
            JToken teamGameStatsToken = json.SelectToken("summary.teamGameStats");
            gameId = json.SelectToken("id").ToString();
            
            teamGameStatsJson = (JArray)teamGameStatsToken;


            // Determine if the team defined by teamId parameter is the home team or away team and populate the TeamGameStats properties accordingly
            if (json.SelectToken("homeTeam.id").ToString() == teamId.ToString())
            {

                // -------------------------------------------------
                // Get the aggregate team stats
                totalGoals = json.SelectToken("homeTeam.score").ToString();

                foreach (var statsElement in teamGameStatsJson)
                {
                    if (statsElement.SelectToken("category").ToString() == "sog")
                        totalShots = statsElement.SelectToken("homeValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "faceoffWinningPctg")
                        faceOffWinPercentage = statsElement.SelectToken("homeValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "powerPlay")
                    {
                        string[] powerPlayRatio = Utilities.getRatioFromString(statsElement.SelectToken("homeValue").ToString());
                        powerPlayGoals = powerPlayRatio[0];
                        powerPlayOpportunities = powerPlayRatio[1];
                        if (powerPlayOpportunities == "0")
                            powerPlayPercentage = "N/A";
                        else
                            powerPlayPercentage = (Convert.ToDouble(powerPlayGoals) / Convert.ToDouble(powerPlayOpportunities)).ToString();
                    }
                    else if (statsElement.SelectToken("category").ToString() == "pim")
                        totalPIM = statsElement.SelectToken("homeValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "hits")
                        hits = statsElement.SelectToken("homeValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "blockedShots")
                        blockedShots = statsElement.SelectToken("homeValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "giveaways")
                        giveaways = statsElement.SelectToken("homeValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "takeaways")
                        takeaways = statsElement.SelectToken("homeValue").ToString();
                }

                // -------------------------------------------------
                // Get the individual player stats
                teamPlayers = new List<PlayerGameStats>();
                string playerGameStatsURL = NHLAPIServiceURLs.gameBoxScore.Replace("###", gameId);
                var playerGameStatsJson = DataAccessLayer.ExecuteAPICall(playerGameStatsURL);

                JToken specificPlayerStats = playerGameStatsJson.SelectToken("playerByGameStats.homeTeam");
                JArray forwards = (JArray)specificPlayerStats.SelectToken("forwards");
                JArray defense = (JArray)specificPlayerStats.SelectToken("defense");
                JArray goalies = (JArray)specificPlayerStats.SelectToken("goalies");

                // Merge the player arrays into a single array
                JArray allPlayers = new JArray();
                allPlayers.Merge(forwards);
                allPlayers.Merge(defense);  
                allPlayers.Merge(goalies);

                foreach (var player in allPlayers)
                {
                    PlayerGameStats aPlayer = new PlayerGameStats(player, nhlTeamId, gameId);
                    teamPlayers.Add(aPlayer);
                }   


            }

            else if (json.SelectToken("awayTeam.id").ToString() == teamId.ToString())
            {
                totalGoals = json.SelectToken("awayTeam.score").ToString();

                foreach (var statsElement in teamGameStatsJson)
                {
                    if (statsElement.SelectToken("category").ToString() == "sog")
                        totalShots = statsElement.SelectToken("awayValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "faceoffWinningPctg")
                        faceOffWinPercentage = statsElement.SelectToken("awayValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "powerPlay")
                    {
                        string[] powerPlayRatio = Utilities.getRatioFromString(statsElement.SelectToken("awayValue").ToString());
                        powerPlayGoals = powerPlayRatio[0];
                        powerPlayOpportunities = powerPlayRatio[1];
                        if (powerPlayOpportunities == "0")
                            powerPlayPercentage = "N/A";
                        else
                            powerPlayPercentage = (Convert.ToDouble(powerPlayGoals) / Convert.ToDouble(powerPlayOpportunities)).ToString();
                    }
                    else if (statsElement.SelectToken("category").ToString() == "pim")
                        totalPIM = statsElement.SelectToken("awayValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "hits")
                        hits = statsElement.SelectToken("awayValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "blockedShots")
                        blockedShots = statsElement.SelectToken("awayValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "giveaways")
                        giveaways = statsElement.SelectToken("awayValue").ToString();
                    else if (statsElement.SelectToken("category").ToString() == "takeaways")
                        takeaways = statsElement.SelectToken("awayValue").ToString();
                }

                // -------------------------------------------------
                // Get the individual player stats
                teamPlayers = new List<PlayerGameStats>();
                string playerGameStatsURL = NHLAPIServiceURLs.gameBoxScore.Replace("###", gameId);
                var playerGameStatsJson = DataAccessLayer.ExecuteAPICall(playerGameStatsURL);

                JToken specificPlayerStats = playerGameStatsJson.SelectToken("playerByGameStats.awayTeam");
                JArray forwards = (JArray)specificPlayerStats.SelectToken("forwards");
                JArray defense = (JArray)specificPlayerStats.SelectToken("defense");
                JArray goalies = (JArray)specificPlayerStats.SelectToken("goalies");

                // Merge the player arrays into a single array
                JArray allPlayers = new JArray();
                allPlayers.Merge(forwards);
                allPlayers.Merge(defense);
                allPlayers.Merge(goalies);

                foreach (var player in allPlayers)
                {
                    PlayerGameStats aPlayer = new PlayerGameStats(player, nhlTeamId, gameId);
                    teamPlayers.Add(aPlayer);
                }
            }


        }

    }
}

       
