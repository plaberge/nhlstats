using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class Team
    {
        public int NHLTeamID { get; set; }              // JSON
        public string TeamName { get; set; }              // JSON
        public string TeamCity { get; set; }
        public string TeamAbbreviation { get; set; }
        public Venue TeamVenue { get; set; }
        
        public string FirstYearOfPlay { get; set; }
        public Division teamDivision { get; set; }
        public Conference teamConference { get; set; }
        public string webSite { get; set; }    
        public int Wins { get; set; }              // JSON
        public int regulationWins { get; set; }
        public int Losses { get; set; }              // JSON
        public int OvertimeLosses { get; set; }              // JSON
        public int GoalsScored { get; set; }              // JSON
        public int GoalsAgainst { get; set; }              // JSON
        public int Points { get; set; }              // JSON
        public int DivisionRank { get; set; }              // JSON
        public int ConferenceRank { get; set; }              // JSON
        public int LeagueRank { get; set; }              // JSON
        public int WildcardRank { get; set; }              // JSON
        public int ROW { get; set; }              // JSON
        public int GamesPlayed { get; set; }              // JSON
        public string StreakType { get; set; }              // JSON
        public int StreakNumber { get; set; }              // JSON
        public string StreakCode { get; set; }              // JSON
        public string LastUpdated { get; set; }              // JSON
        public JObject teamJson { get; set; } // Populate the raw JSON to a property

        public Team()
        {

        }

        public Team(string teamID)
        {
            NHLTeamID = Convert.ToInt32(teamID);

            // Create API call URL by appending the team ID to the URL
            string teamLink = NHLAPIServiceURLs.teams + teamID;

            var json = DataAccessLayer.ExecuteAPICall(teamLink);
 
            var specificTeam = json.SelectToken("teams[0]").ToObject<JObject>();
            
            // Populate the raw JSON to a property
            teamJson = specificTeam;


            if (specificTeam.ContainsKey("teamName"))
            {
                TeamName = json.SelectToken("teams[0].teamName").ToString();
            }

            if (specificTeam.ContainsKey("abbreviation"))
            {
                TeamAbbreviation = json.SelectToken("teams[0].abbreviation").ToString();
            }

            if (specificTeam.ContainsKey("locationName"))
            {
                TeamCity = json.SelectToken("teams[0].locationName").ToString();
            }

            if (specificTeam.ContainsKey("firstYearOfPlay"))
            {
                FirstYearOfPlay = json.SelectToken("teams[0].firstYearOfPlay").ToString();
            }

            if (specificTeam.ContainsKey("conference"))
            {
                //Division - need to implement division class
                teamConference = new Conference(Convert.ToInt32(json.SelectToken("teams[0].conference.id")));
            }

            if (specificTeam.ContainsKey("division"))
            {
                teamDivision = new Division(Convert.ToInt32(json.SelectToken("teams[0].division.id")));
            }
            // Not all venues have an ID in the API (like Maple Leafs Scotiabank Arena), so need to check
            if (specificTeam.ContainsKey("venue"))
            {
                var venueJson = json.SelectToken("teams[0].venue").ToObject<JObject>();

                if (venueJson.ContainsKey("id"))
                {
                    TeamVenue = new Venue(json.SelectToken("teams[0].venue.id").ToString());
                }
            }


            if (specificTeam.ContainsKey("officialSiteUrl"))
            {
                webSite = json.SelectToken("teams[0].officialSiteUrl").ToString();
            }
            

        }

        // Constructor with featureFlag denotes that not all data on the team downward is being populated (think "Team Light")
        public Team(string teamID, int featureFlag)
        {
            NHLTeamID = Convert.ToInt32(teamID);

            // Create API call URL by appending the team ID to the URL
            string teamLink = NHLAPIServiceURLs.teams + teamID;

            var json = DataAccessLayer.ExecuteAPICall(teamLink);

            var specificTeam = json.SelectToken("teams[0]").ToObject<JObject>();

            // Populate the raw JSON to a property
            teamJson = specificTeam;

            if (specificTeam.ContainsKey("teamName"))
            {
                TeamName = json.SelectToken("teams[0].teamName").ToString();
            }

            if (specificTeam.ContainsKey("abbreviation"))
            {
                TeamAbbreviation = json.SelectToken("teams[0].abbreviation").ToString();
            }

            if (specificTeam.ContainsKey("locationName"))
            {
                TeamCity = json.SelectToken("teams[0].locationName").ToString();
            }

            if (specificTeam.ContainsKey("firstYearOfPlay"))
            {
                FirstYearOfPlay = json.SelectToken("teams[0].firstYearOfPlay").ToString();
            }

            if (specificTeam.ContainsKey("conference"))
            {
                //Division - need to implement division class
                teamConference = new Conference(Convert.ToInt32(json.SelectToken("teams[0].conference.id")));
            }

            if (specificTeam.ContainsKey("division"))
            {
                teamDivision = new Division(Convert.ToInt32(json.SelectToken("teams[0].division.id")));
            }
            // Not all venues have an ID in the API (like Maple Leafs Scotiabank Arena), so need to check
            var venueJson = json.SelectToken("teams[0].venue").ToObject<JObject>();
            if (venueJson.ContainsKey("id"))
            {
                TeamVenue = new Venue(json.SelectToken("teams[0].venue.id").ToString());
            }



            webSite = json.SelectToken("teams[0].officialSiteUrl").ToString();



        }

        public static List<Team> GetAllTeams()
        {
            var json = DataAccessLayer.ExecuteAPICall(NHLAPIServiceURLs.teams);
            var teamArray = JArray.Parse(json.SelectToken("teams").ToString());

            List<Team> listOfTeams = new List<Team>();
            Team tempTeam;

            foreach (var aTeam in teamArray)
            {
                tempTeam = new Team(aTeam.SelectToken("id").ToString());
                listOfTeams.Add(tempTeam);
            }
            return listOfTeams;
        }
    }
}
