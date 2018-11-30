using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHLStats
{
    public class Game
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
            gameType = json.SelectToken("gameData.game.type").ToString();
            season = json.SelectToken("gameData.game.season").ToString();
            gameDate = json.SelectToken("gameData.datetime.dateTime").ToString();
            abstractGameState = json.SelectToken("gameData.status.abstractGameState").ToString();
            codedGameState = json.SelectToken("gameData.status.codedGameState").ToString();
            detailedState = json.SelectToken("gameData.status.detailedState").ToString();
            statusCode = json.SelectToken("gameData.status.statusCode").ToString();
            homeTeam = new Team(json.SelectToken("teams.home.id").ToString());
            awayTeam = new Team(json.SelectToken("teams.away.id").ToString());

            //gameVenue 
            //gameContent

           
        }
    }
}
