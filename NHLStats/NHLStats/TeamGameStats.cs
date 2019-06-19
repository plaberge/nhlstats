using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class TeamGameStats
    {
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
        public Person coach { get; set; }
        public List<PlayerGameStats> teamPlayers { get; set; }  // Team roster stats
        public JObject teamGameStatsJson { get; set; } // Populate the raw JSON to a property

        public TeamGameStats(JObject json)
        {
            // Populate the raw JSON to a property
            teamGameStatsJson = json;

            totalGoals = json.SelectToken("teamStats.teamSkaterStats.goals").ToString();
            totalPIM = json.SelectToken("teamStats.teamSkaterStats.pim").ToString();
            totalShots = json.SelectToken("teamStats.teamSkaterStats.shots").ToString();
            powerPlayPercentage = json.SelectToken("teamStats.teamSkaterStats.powerPlayPercentage").ToString();
            powerPlayGoals = json.SelectToken("teamStats.teamSkaterStats.powerPlayGoals").ToString();
            powerPlayOpportunities = json.SelectToken("teamStats.teamSkaterStats.powerPlayOpportunities").ToString();
            faceOffWinPercentage = json.SelectToken("teamStats.teamSkaterStats.faceOffWinPercentage").ToString();
            blockedShots = json.SelectToken("teamStats.teamSkaterStats.blocked").ToString();
            takeaways = json.SelectToken("teamStats.teamSkaterStats.takeaways").ToString();
            giveaways = json.SelectToken("teamStats.teamSkaterStats.giveaways").ToString();
            hits = json.SelectToken("teamStats.teamSkaterStats.hits").ToString();

            JArray coachJsonArray = new JArray();
            coachJsonArray = json.SelectToken("coaches").ToObject<JArray>();
            if (coachJsonArray.Count > 0)
            {
                coach = new Person(json.SelectToken("coaches")[0].ToObject<JObject>());
                //coach = json.SelectToken("coaches")[0].SelectToken("person.fullName").ToString();
            }
            

            PlayerGameStats currentPlayerProcessed;
            teamPlayers = new List<PlayerGameStats>();
            foreach (var player in json.SelectToken("players"))
            {
                JToken currentPlayer = player.First; // Root Token ID is dynamically generated so need to ignore it.

                currentPlayerProcessed = new PlayerGameStats(Convert.ToInt32(currentPlayer.SelectToken("person.id")), currentPlayer);
                teamPlayers.Add(currentPlayerProcessed);
            }
        }

        // Constructor with featureFlag denotes that not all data on the TeamGameStats downward is being populated (think "TeamGameStats Light")
        public TeamGameStats(JObject json, int featureFlag)
        {
            // Populate the raw JSON to a property
            teamGameStatsJson = json;

            totalGoals = json.SelectToken("teamStats.teamSkaterStats.goals").ToString();
            totalPIM = json.SelectToken("teamStats.teamSkaterStats.pim").ToString();
            totalShots = json.SelectToken("teamStats.teamSkaterStats.shots").ToString();
            powerPlayPercentage = json.SelectToken("teamStats.teamSkaterStats.powerPlayPercentage").ToString();
            powerPlayGoals = json.SelectToken("teamStats.teamSkaterStats.powerPlayGoals").ToString();
            powerPlayOpportunities = json.SelectToken("teamStats.teamSkaterStats.powerPlayOpportunities").ToString();
            faceOffWinPercentage = json.SelectToken("teamStats.teamSkaterStats.faceOffWinPercentage").ToString();
            blockedShots = json.SelectToken("teamStats.teamSkaterStats.blocked").ToString();
            takeaways = json.SelectToken("teamStats.teamSkaterStats.takeaways").ToString();
            giveaways = json.SelectToken("teamStats.teamSkaterStats.giveaways").ToString();
            hits = json.SelectToken("teamStats.teamSkaterStats.hits").ToString();
            

            
        }
    }
}
