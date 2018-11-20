using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace NHLStats
{
    public class League
    {
        //https://statsapi.web.nhl.com/api/v1/standings/byLeague
        public League()
        {

        }

        public List<Team> GetCurrentStandings()
        {
            // Initialize the list of teams to return
            List<Team> teamList = new List<Team>();

            var client = new System.Net.Http.HttpClient();

            // Get Current League Standings from NHL API
            var response = client.GetAsync(NHLAPIServiceURLs.leagueStandings).Result;
            var retResp = new HttpResponseMessage();
            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);
            Team newTeam = new Team();

            IList<JToken> results = json["records"][0]["teamRecords"].Children().ToList();

            foreach (JToken result in results)
            {


                // Put the values in the results list into a new Team object.
                newTeam.NHLTeamID = Convert.ToInt32(result["team"]["id"]);
                newTeam.TeamName = result["team"]["name"].ToString();
                newTeam.Wins = Convert.ToInt32(result["leagueRecord"]["wins"]);
                newTeam.Losses = Convert.ToInt32(result["leagueRecord"]["losses"]);
                newTeam.OvertimeLosses = Convert.ToInt32(result["leagueRecord"]["ot"]);
                newTeam.GoalsAgainst = Convert.ToInt32(result["goalsAgainst"]);
                newTeam.GoalsScored = Convert.ToInt32(result["goalsScored"]);
                newTeam.Points = Convert.ToInt32(result["points"]);
                newTeam.DivisionRank = Convert.ToInt32(result["divisionRank"]);
                newTeam.ConferenceRank = Convert.ToInt32(result["conferenceRank"]);
                newTeam.LeagueRank = Convert.ToInt32(result["leagueRank"]);
                newTeam.WildcardRank = Convert.ToInt32(result["wildcardRank"]);
                newTeam.ROW = Convert.ToInt32(result["row"]);
                newTeam.GamesPlayed = Convert.ToInt32(result["gamesPlayed"]);
                newTeam.StreakType = result["streak"]["streakType"].ToString();
                newTeam.StreakNumber = Convert.ToInt32(result["streak"]["streakNumber"]);
                newTeam.StreakCode = result["streak"]["streakCode"].ToString();
                newTeam.LastUpdated = result["lastUpdated"].ToString();

                // Add the newly-populated newTeam object to the Team List.
                teamList.Add(newTeam);

                newTeam = new Team();

            }

            return teamList;

        }

    }
}



