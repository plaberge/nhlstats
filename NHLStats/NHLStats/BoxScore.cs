using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace NHLStats
{
    public class BoxScore
    {
        public string awayTeamId { get; set; } // ID of the Away Team
        public string homeTeamId { get; set; } // ID of the Home Team
        public TeamGameStats homeTeamStats { get; set; } // Stats from the home team
        public TeamGameStats awayTeamStats { get; set; } // Stats from the away team
        

        public JObject boxScoreJson { get; set; } // The raw JSON for the box score data.
        
        public BoxScore(string homeTeamID, string awayTeamID, JObject json)
        {
            awayTeamId = awayTeamID;
            homeTeamId = homeTeamID;

            //Populate the raw JSON data to the boxScoreJson property
            boxScoreJson = json;

            homeTeamStats = new TeamGameStats(boxScoreJson, Convert.ToInt32(homeTeamId));
            awayTeamStats = new TeamGameStats(boxScoreJson, Convert.ToInt32(awayTeamId));

            

        }

        
    }
}
