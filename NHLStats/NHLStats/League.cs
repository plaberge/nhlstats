using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NHLStats
{
    public class League
    {
        //public JObject leagueJson { get; set; } // Populate the raw JSON to a property

        public League()
        {

        }

        // METHOD:  GetCurrentStandings
        // Inputs:  None
        // Outputs:  A list of teams in the leage ranked by first to last
        // API URL:  https://statsapi.web.nhl.com/api/v1/standings/byLeague
        public static List<TeamRecord> GetCurrentStandings(string season)
        {
            JObject leagueJson;

            // Set up API call string (including season if the season parameter is not empty.
            string standingsAPICall;
            if (season != "")
                standingsAPICall = NHLAPIServiceURLs.leagueStandings + "now";
            else
                standingsAPICall = NHLAPIServiceURLs.leagueStandings;

            // Initialize the list of teams to return
            List<TeamRecord> teamList = new List<TeamRecord>();

            /*var client = new System.Net.Http.HttpClient();

            var response = client.GetAsync(standingsAPICall).Result;
            var retResp = new HttpResponseMessage();
            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);*/

            // Get Current League Standings from NHL API
            var json = DataAccessLayer.ExecuteAPICall(standingsAPICall);

            // Populate the raw JSON to a property
            leagueJson = json;


            TeamRecord newTeam = new TeamRecord();

            IList<JToken> results = json["records"][0]["teamRecords"].Children().ToList();
            JObject keyTest;
            string seasonYear;
            string seasonMonth;
            string seasonDay;
            DateTime dtString;

            foreach (JToken result in results)
            {
                keyTest = result.ToObject<JObject>();

                // Put the values in the results list into a new Team object.
                //newTeam.NHLTeamID = Convert.ToInt32(result["team"]["id"]);
                //newTeam.TeamName = result["team"]["name"].ToString();
                //newTeam.Wins = Convert.ToInt32(result["leagueRecord"]["wins"]);
                //newTeam.Losses = Convert.ToInt32(result["leagueRecord"]["losses"]);
                //newTeam.OvertimeLosses = Convert.ToInt32(result["leagueRecord"]["ot"]);
                //newTeam.regulationWins = Convert.ToInt32(result["regulationWins"]);
                //newTeam.GoalsAgainst = Convert.ToInt32(result["goalsAgainst"]);
                //newTeam.GoalsScored = Convert.ToInt32(result["goalsScored"]);
                //newTeam.Points = Convert.ToInt32(result["points"]);
                //newTeam.DivisionRank = Convert.ToInt32(result["divisionRank"]);
                //newTeam.DivisionL10Rank = Convert.ToInt32(result["divisionL10Rank"]);
                //newTeam.DivisionHomeRank = Convert.ToInt32(result["divisionHomeRank"]);
                //newTeam.DivisionRoadRank = Convert.ToInt32(result["divisionRoadRank"]);
                //newTeam.ConferenceRank = Convert.ToInt32(result["conferenceRank"]);
                //newTeam.ConferenceL10Rank = Convert.ToInt32(result["conferenceL10Rank"]);
                //newTeam.ConferenceHomeRank = Convert.ToInt32(result["conferenceHomeRank"]);
                //newTeam.ConferenceRoadRank = Convert.ToInt32(result["conferenceRoadRank"]);
                //newTeam.LeagueRank = Convert.ToInt32(result["leagueRank"]);
                //newTeam.WildcardRank = Convert.ToInt32(result["wildcardRank"]);
                //newTeam.ROW = Convert.ToInt32(result["row"]);
                //newTeam.GamesPlayed = Convert.ToInt32(result["gamesPlayed"]);
                //newTeam.StreakType = result["streak"]["streakType"].ToString();
                //newTeam.StreakNumber = Convert.ToInt32(result["streak"]["streakNumber"]);
                //newTeam.StreakCode = result["streak"]["streakCode"].ToString();
                //if (keyTest.ContainsKey("clinchIndicator"))
                //{
                //    newTeam.clinchIndicator = result["clinchIndicator"].ToString();
                //}
                //else
                //{
                //    newTeam.clinchIndicator = "N/A";
                //}

                //newTeam.LastUpdated = result["lastUpdated"].ToString();
                //dtString = Convert.ToDateTime(newTeam.LastUpdated);

                //if (season != "")
                //{
                //    newTeam.season = season;
                //}
                //else
                //{
                //    seasonYear = dtString.Year.ToString();
                //    if (dtString.Month < 10)
                //    {
                //        seasonMonth = "0" + dtString.Month.ToString();
                //    }
                //    else
                //    {
                //        seasonMonth = dtString.Month.ToString();
                //    }

                //    if (dtString.Day < 10)
                //    {
                //        seasonDay = "0" + dtString.Day.ToString();
                //    }
                //    else
                //    {
                //        seasonDay = dtString.Day.ToString();
                //    }

                //    newTeam.season = Utilities.GetSeasonFromDate(seasonYear + "-" + seasonMonth + "-" + seasonDay);
                //}



                //// Add the newly-populated newTeam object to the Team List.
                //teamList.Add(newTeam);

                //newTeam = new TeamRecord();

            }

            return teamList;

        }

        public static List<TeamRecord> GetStandingsAsOfDate(string gameDate)
        {
            JToken leagueJson;

            // Set up API call string.
            string standingsAPICall;

            standingsAPICall = NHLAPIServiceURLs.leagueStandings + gameDate;


            // Initialize the list of teams to return
            List<TeamRecord> teamList = new List<TeamRecord>();

            /*var client = new System.Net.Http.HttpClient();

            var response = client.GetAsync(standingsAPICall).Result;
            var retResp = new HttpResponseMessage();
            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);*/

            // Get Current League Standings from NHL APIee
            var json = DataAccessLayer.ExecuteAPICall(standingsAPICall);

            // Populate the raw JSON to a property
            leagueJson = JArray.Parse(json.SelectToken("standings").ToString());

            //var keyCheckJson = new JObject();

            TeamRecord newTeam = new TeamRecord();


            foreach (JToken teamRecord in leagueJson)
            {
                newTeam = new TeamRecord();

                newTeam.abbrev = teamRecord.SelectToken("teamAbbrev.default").ToString();

                newTeam.id = Team.GetTeamID(newTeam.abbrev);

                newTeam.asOfGameDate = teamRecord.SelectToken("date").ToString();

                JObject keyCheckJson = teamRecord.ToObject<JObject>();
                if (keyCheckJson.ContainsKey("clinchIndicator"))
                {
                    newTeam.clinchIndicator = teamRecord.SelectToken("clinchIndicator").ToString();
                }
                else newTeam.clinchIndicator = "N";

                newTeam.conferenceAbbrev = teamRecord.SelectToken("conferenceAbbrev").ToString();
                newTeam.conferenceHomeSequence = Convert.ToInt32(teamRecord.SelectToken("conferenceHomeSequence"));
                newTeam.conferenceL10Sequence = Convert.ToInt32(teamRecord.SelectToken("conferenceL10Sequence"));
                newTeam.conferenceName = teamRecord.SelectToken("conferenceName").ToString();
                newTeam.conferenceRoadSequence = Convert.ToInt32(teamRecord.SelectToken("conferenceRoadSequence"));
                newTeam.conferenceSequence = Convert.ToInt32(teamRecord.SelectToken("conferenceSequence"));
                newTeam.divisionAbbrev = teamRecord.SelectToken("divisionAbbrev").ToString();
                newTeam.divisionHomeSequence = Convert.ToInt32(teamRecord.SelectToken("divisionHomeSequence"));
                newTeam.divisionL10Sequence = Convert.ToInt32(teamRecord.SelectToken("divisionL10Sequence"));
                newTeam.divisionName = teamRecord.SelectToken("divisionName").ToString();
                newTeam.divisionRoadSequence = Convert.ToInt32(teamRecord.SelectToken("divisionRoadSequence"));
                newTeam.divisionSequence = Convert.ToInt32(teamRecord.SelectToken("divisionSequence"));
                newTeam.gameTypeId = Convert.ToInt32(teamRecord.SelectToken("gameTypeId"));
                newTeam.gamesPlayed = Convert.ToInt32(teamRecord.SelectToken("gamesPlayed"));
                newTeam.goalDifferential = Convert.ToInt32(teamRecord.SelectToken("goalDifferential"));
                newTeam.goalDifferentialPctg = Convert.ToDecimal(teamRecord.SelectToken("goalDifferentialPctg"));
                newTeam.goalsAgainst = Convert.ToInt32(teamRecord.SelectToken("goalsAgainst"));
                newTeam.goalsFor = Convert.ToInt32(teamRecord.SelectToken("goalsFor"));
                newTeam.goalsForPctg = Convert.ToDecimal(teamRecord.SelectToken("goalsForPctg"));
                newTeam.homeGamesPlayed = Convert.ToInt32(teamRecord.SelectToken("homeGamesPlayed"));
                newTeam.homeGoalDifferential = Convert.ToInt32(teamRecord.SelectToken("homeGoalDifferential"));
                newTeam.homeGoalsAgainst = Convert.ToInt32(teamRecord.SelectToken("homeGoalsAgainst"));
                newTeam.homeGoalsFor = Convert.ToInt32(teamRecord.SelectToken("homeGoalsFor"));
                newTeam.homeLosses = Convert.ToInt32(teamRecord.SelectToken("homeLosses"));
                newTeam.homeOtLosses = Convert.ToInt32(teamRecord.SelectToken("homeOtLosses"));
                newTeam.homePoints = Convert.ToInt32(teamRecord.SelectToken("homePoints"));
                newTeam.homeRegulationPlusOtWins = Convert.ToInt32(teamRecord.SelectToken("homeRegulationPlusOTWins"));
                newTeam.homeRegulationWins = Convert.ToInt32(teamRecord.SelectToken("homeRegulationWins"));
                newTeam.homeTies = Convert.ToInt32(teamRecord.SelectToken("homeTies"));
                newTeam.homeWins = Convert.ToInt32(teamRecord.SelectToken("homeWins"));
                newTeam.L10GamesPlayed = Convert.ToInt32(teamRecord.SelectToken("l10GamesPlayed"));
                newTeam.L10GoalDifferential = Convert.ToInt32(teamRecord.SelectToken("l10GoalDifferential"));
                newTeam.L10GoalsAgainst = Convert.ToInt32(teamRecord.SelectToken("l10GoalsAgainst"));
                newTeam.L10GoalsFor = Convert.ToInt32(teamRecord.SelectToken("l10GoalsFor"));
                newTeam.L10Losses = Convert.ToInt32(teamRecord.SelectToken("l10Losses"));
                newTeam.L10OtLosses = Convert.ToInt32(teamRecord.SelectToken("l10OtLosses"));
                newTeam.L10Points = Convert.ToInt32(teamRecord.SelectToken("l10Points"));
                newTeam.L10RegulationPlusOtWins = Convert.ToInt32(teamRecord.SelectToken("l10RegulationPlusOTWins"));
                newTeam.L10RegulationWins = Convert.ToInt32(teamRecord.SelectToken("l10RegulationWins"));
                newTeam.L10Ties = Convert.ToInt32(teamRecord.SelectToken("l10Ties"));
                newTeam.L10Wins = Convert.ToInt32(teamRecord.SelectToken("l10Wins"));
                newTeam.leagueHomeSequence = Convert.ToInt32(teamRecord.SelectToken("leagueHomeSequence"));
                newTeam.leagueL10Sequence = Convert.ToInt32(teamRecord.SelectToken("leagueL10Sequence"));
                newTeam.leagueRoadSequence = Convert.ToInt32(teamRecord.SelectToken("leagueRoadSequence"));
                newTeam.leagueSequence = Convert.ToInt32(teamRecord.SelectToken("leagueSequence"));
                newTeam.losses = Convert.ToInt32(teamRecord.SelectToken("losses"));
                newTeam.pointPctg = Convert.ToDecimal(teamRecord.SelectToken("pointPctg"));
                newTeam.points = Convert.ToInt32(teamRecord.SelectToken("points"));
                newTeam.regulationPlusdOtWinsPctg = Convert.ToInt32(teamRecord.SelectToken("regulationPlusOTWinsPctg"));
                newTeam.regulationPlusOtWins = Convert.ToInt32(teamRecord.SelectToken("regulationPlusOTWins"));
                newTeam.regulationWinPctg = Convert.ToDecimal(teamRecord.SelectToken("regulationWinPctg"));
                newTeam.regulationWins = Convert.ToInt32(teamRecord.SelectToken("regulationWins"));
                newTeam.roadGamesPlayed = Convert.ToInt32(teamRecord.SelectToken("roadGamesPlayed"));
                newTeam.roadGoalDifferential = Convert.ToInt32(teamRecord.SelectToken("roadGoalDifferential"));
                newTeam.roadGoalsAgainst = Convert.ToInt32(teamRecord.SelectToken("roadGoalsAgainst"));
                newTeam.roadGoalsFor = Convert.ToInt32(teamRecord.SelectToken("roadGoalsFor"));
                newTeam.roadLosses = Convert.ToInt32(teamRecord.SelectToken("roadLosses"));
                newTeam.roadOtLosses = Convert.ToInt32(teamRecord.SelectToken("roadOtLosses"));
                newTeam.roadPoints = Convert.ToInt32(teamRecord.SelectToken("roadPoints"));
                newTeam.roadRegulationPlusOtWins = Convert.ToInt32(teamRecord.SelectToken("roadRegulationPlusOTWins"));
                newTeam.roadRegulationWins = Convert.ToInt32(teamRecord.SelectToken("roadRegulationWins"));
                newTeam.roadTies = Convert.ToInt32(teamRecord.SelectToken("roadTies"));
                newTeam.roadWins = Convert.ToInt32(teamRecord.SelectToken("roadWins"));
                newTeam.season = teamRecord.SelectToken("seasonId").ToString();
                newTeam.shootoutLosses = Convert.ToInt32(teamRecord.SelectToken("shootoutLosses"));
                newTeam.shootoutWins = Convert.ToInt32(teamRecord.SelectToken("shootoutWins"));
                newTeam.streakCode = teamRecord.SelectToken("streakCode").ToString();
                newTeam.streakCount = Convert.ToInt32(teamRecord.SelectToken("streakCount"));
                newTeam.ties = Convert.ToInt32(teamRecord.SelectToken("ties"));
                newTeam.waiversSequence = Convert.ToInt32(teamRecord.SelectToken("waiversSequence"));
                newTeam.wildCardSequence = Convert.ToInt32(teamRecord.SelectToken("wildCardSequence"));
                newTeam.winPctg = Convert.ToDecimal(teamRecord.SelectToken("winPctg"));
                newTeam.wins = Convert.ToInt32(teamRecord.SelectToken("wins"));

                teamList.Add(newTeam);



            }

            return teamList;

        }
    }
}



