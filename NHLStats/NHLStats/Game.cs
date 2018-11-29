using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHLStats
{
    class Game
    {
        public string gameID { get; set; }
        public string gameLink { get; set; }
        public string gameType { get; set; }
        public string season { get; set; }
        public string gameDate { get; set; }
        public string abstractGameState { get; set; }
        public string codedGameState { get; set; }
        public string detailedState { get; set; }
        public string statusCode { get; set; }
        public Team homeTeam { get; set; }
        public Team awayTeam { get; set; }
        public Venue gameVenue { get; set; }
        public GameContent gameContent { get; set; }

        // Important URLs:  Live Feed:  https://statsapi.web.nhl.com/api/v1/game/2018020323/feed/live



        // Default void constructor
        public Game()
        {

        }

        // Constructor for Game class from a specific Game ID
        public Game(string theGameID)
        {
            // Populate the gameID property
            gameID = theGameID;

            // Get the URL for the API call to a specific Game
            string theGame = NHLAPIServiceURLs.specificGame;

            // Replace placeholder value ("###") in the placeholder URL with the requested GameID.
            gameLink = theGame.Replace("###", theGameID);

            // Execute the API call
            var json = DataAccessLayer.ExecuteAPICall(gameLink);

            // Populate the rest of the Game class properties
            gameType = 
            season 
            gameDate 
            abstractGameState 
            codedGameState 
            detailedState 
            statusCode 
            homeTeam 
            awayTeam 
            gameVenue 
            gameContent

            //IList<JToken> results = json["gameData"][0]["game"][0].Children().ToList();


        //newTeam.NHLTeamID = Convert.ToInt32(result["team"]["id"]);
        //newTeam.TeamName = result["team"]["name"].ToString();
        //newTeam.Wins = Convert.ToInt32(result["leagueRecord"]["wins"]);
        //newTeam.Losses = Convert.ToInt32(result["leagueRecord"]["losses"]);
        //newTeam.OvertimeLosses = Convert.ToInt32(result["leagueRecord"]["ot"]);
        //newTeam.GoalsAgainst = Convert.ToInt32(result["goalsAgainst"]);
        //newTeam.GoalsScored = Convert.ToInt32(result["goalsScored"]);
        //newTeam.Points = Convert.ToInt32(result["points"]);
        //newTeam.DivisionRank = Convert.ToInt32(result["divisionRank"]);
        //newTeam.ConferenceRank = Convert.ToInt32(result["conferenceRank"]);
        //newTeam.LeagueRank = Convert.ToInt32(result["leagueRank"]);
        //newTeam.WildcardRank = Convert.ToInt32(result["wildcardRank"]);
        //newTeam.ROW = Convert.ToInt32(result["row"]);







    }
    }
}
