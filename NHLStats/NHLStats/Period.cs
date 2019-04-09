using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace NHLStats
{
    public class Period
    {
        public string gameId { get; set; } // Which game does the period belong to?
        public string periodType { get; set; } // Regulation or Overtime
        public string periodTimeStart { get; set; } // Time the period started
        public string periodTimeEnd { get; set; }  // Time the period ended
        public string periodNum { get; set; } // Which period
        public string periodNumOrd { get; set; } // Period ordinal value (1st, 2nd, 3rd, etc.)
        public string homeTeamId { get; set; }  // ID of the home team
        public string homeGoals { get; set; }  // Number of goals for the home team in the period.
        public string homeShotsOnGoal { get; set; }  // Home shots on goal in the period.
        public string homeRinkSide { get; set; } // Side of the rink for the home team.

        public string awayTeamId { get; set; }  // ID of the away team
        public string awayGoals { get; set; }  // Number of goals for the away team in the period.
        public string awayShotsOnGoal { get; set; }  // Away shots on goal in the period.
        public string awayRinkSide { get; set; } // Side of the rink for the away team.
        public JObject periodJson { get; set; } // Populate the raw JSON to a property

        public Period()
        {

        }

        // Constructor by the gameId and pass in a JSON string with the data
        public Period(string gameID, JObject json, string homeTeamID, string awayTeamID)
        {
            periodJson = json; // Populate the raw JSON to a property
            gameId = gameID;  // Populate the gameId property
            if (periodJson.ContainsKey("periodType") == true)
            {
                periodType = json.SelectToken("periodType").ToString();
            }

            if (periodJson.ContainsKey("startTime") == true)
            {
                periodTimeStart = json.SelectToken("startTime").ToString();
            }

            if (periodJson.ContainsKey("endTime") == true)
            {
                periodTimeEnd = json.SelectToken("endTime").ToString();
            }

            if (periodJson.ContainsKey("num") == true)
            {
                periodNum = json.SelectToken("num").ToString();
            }

            if (periodJson.ContainsKey("ordinalNum") == true)
            {
                periodNumOrd = json.SelectToken("ordinalNum").ToString();
            }

            homeTeamId = homeTeamID;
            awayTeamId = awayTeamID;

            JObject teamJson = json.SelectToken("home").ToObject<JObject>();
            if (teamJson.ContainsKey("goals") == true)
            {
                homeGoals = json.SelectToken("home.goals").ToString();
            }

            if (teamJson.ContainsKey("shotsOnGoal") == true)
            {
                homeShotsOnGoal = json.SelectToken("home.shotsOnGoal").ToString();
            }

            if (teamJson.ContainsKey("rinkSide") == true)
            {
                homeRinkSide = json.SelectToken("home.rinkSide").ToString();
            }

            teamJson = json.SelectToken("away").ToObject<JObject>();

            if (teamJson.ContainsKey("goals") == true)
            {
                homeGoals = json.SelectToken("away.goals").ToString();
            }

            if (teamJson.ContainsKey("shotsOnGoal") == true)
            {
                homeShotsOnGoal = json.SelectToken("away.shotsOnGoal").ToString();
            }

            if (teamJson.ContainsKey("rinkSide") == true)
            {
                homeRinkSide = json.SelectToken("away.rinkSide").ToString();
            }
            //awayGoals = json.SelectToken("away.goals").ToString();
            //awayShotsOnGoal = json.SelectToken("away.shotsOnGoal").ToString();
            //awayRinkSide = json.SelectToken("away.rinkSide").ToString();

        }
    }
}
