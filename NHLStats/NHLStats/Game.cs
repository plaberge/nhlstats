using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        public List<Player> gameParticipants { get; set; }
        public List<GameEvent> gameEvents { get; set; }

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
            homeTeam = new Team(json.SelectToken("gameData.teams.home.id").ToString());
            awayTeam = new Team(json.SelectToken("gameData.teams.away.id").ToString());
            gameVenue = new Venue(json.SelectToken("gameData.teams.home.venue.id").ToString());

            // Populating the players
            // Create a JSON 
            var playerJson = JObject.Parse(json.SelectToken("gameData.players").ToString());
            

            //IList<JToken> results = playerJson.Children().ToList();
            IList<JToken> results = JObject.Parse(json.SelectToken("gameData.players").ToString()).Children().ToList();

            // Create a placeholder List<Player> for populating the game roster
            List<Player> playerList = new List<Player>();

            // Add each player to the List<Player> placeholder
            foreach (JToken result in results.Children())
            {
           
                playerList.Add(new Player(Convert.ToInt32(result["id"])));
                
            }

            // Populate gameParticipants property with List<Player> placeholder.
            gameParticipants = playerList;

            var gameEventsJson = JArray.Parse(json.SelectToken("liveData.plays.allPlays").ToString());
            //GameEvent aGameEvent = new GameEvent(gameEventsJson[30]);
            GameEvent aGameEvent = new GameEvent();
            gameEvents = new List<GameEvent>();

            foreach (var item in gameEventsJson)
            {
                aGameEvent = new GameEvent(item);
                gameEvents.Add(aGameEvent);

            }


            //TODO:  Populate gameContent
            gameContent = new GameContent(theGameID);



        }
    }
}
