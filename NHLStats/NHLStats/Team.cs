using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class Team
    {
        public int NHLTeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamCity { get; set; }
        public string TeamAbbreviation { get; set; }
        public Venue TeamVenue { get; set; }

        public string FirstYearOfPlay { get; set; }
        //public Division teamDivision { get; set; }
        public Conference teamConference { get; set; }
        public string webSite { get; set; }    
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int OvertimeLosses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsAgainst { get; set; }
        public int Points { get; set; }
        public int DivisionRank { get; set; }
        public int ConferenceRank { get; set; }
        public int LeagueRank { get; set; }
        public int WildcardRank { get; set; }
        public int ROW { get; set; }
        public int GamesPlayed { get; set; }
        public string StreakType { get; set; }
        public int StreakNumber { get; set; }
        public string StreakCode { get; set; }
        public string LastUpdated { get; set; }

        public Team()
        {

        }

        public Team(string teamID)
        {
            NHLTeamID = Convert.ToInt32(teamID);

            // Create API call URL by appending the team ID to the URL
            string teamLink = NHLAPIServiceURLs.teams + teamID;

            var json = DataAccessLayer.ExecuteAPICall(teamLink);

            TeamName = json.SelectToken("teams[0].teamName").ToString();
            TeamAbbreviation = json.SelectToken("teams[0].abbreviation").ToString();
            TeamCity = json.SelectToken("teams[0].locationName").ToString();
            FirstYearOfPlay = json.SelectToken("teams[0].firstYearOfPlay").ToString();
            //Division - need to implement division class
            teamConference = new Conference(Convert.ToInt32(json.SelectToken("teams[0].conference.id")));

            // Not all venues have an ID in the API (like Maple Leafs Scotiabank Arena), so need to check
            var venueJson = json.SelectToken("teams[0].venue").ToObject<JObject>();
            if (venueJson.ContainsKey("id"))
            {
                TeamVenue = new Venue(json.SelectToken("teams[0].venue.id").ToString());
            }
                

            
           webSite = json.SelectToken("teams[0].officialSiteUrl").ToString();
            
            

        }
    }
}
