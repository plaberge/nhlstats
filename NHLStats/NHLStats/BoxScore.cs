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
        public List<Person> officials { get; set; } // The list of officials for the game

        public JObject boxScoreJson { get; set; } // The raw JSON for the box score data.
        
        public BoxScore(string homeTeamID, string awayTeamID, JObject json)
        {
            awayTeamId = awayTeamID;
            homeTeamId = homeTeamID;

            //Populate the raw JSON data to the boxScoreJson property
            boxScoreJson = json;

            awayTeamStats = new TeamGameStats(json.SelectToken("teams.away").ToObject<JObject>());
            homeTeamStats = new TeamGameStats(json.SelectToken("teams.home").ToObject<JObject>());

            officials = new List<Person>();
            Person tempReferee;
            foreach (var referee in JArray.Parse(json.SelectToken("officials").ToString()))
            {
                tempReferee = new Person(referee.ToObject<JObject>());
                officials.Add(tempReferee);

            }

        }

        // Constructor with featureFlag denotes that not all data on the BoxScore downward is being populated (think "BoxScore Light")
        public BoxScore(string homeTeamID, string awayTeamID, JObject json, int featureFlag)
        {
            awayTeamId = awayTeamID;
            homeTeamId = homeTeamID;

            awayTeamStats = new TeamGameStats(json.SelectToken("teams.away").ToObject<JObject>(), featureFlag);
            homeTeamStats = new TeamGameStats(json.SelectToken("teams.home").ToObject<JObject>(), featureFlag);

        }
    }
}
