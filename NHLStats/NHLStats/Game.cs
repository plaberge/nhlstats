﻿using Newtonsoft.Json;
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

        public string date { get; set; }
        public string dayAbbrev { get; set; }
        public string id { get; set; }
        public string season { get; set; }
        public string gameType { get; set; }
        public Venue venue { get; set; }
        public string neutralSite { get; set; }
        public string startTimeUTC { get; set; }
        public string easternUTCOffset { get; set; }
        public string venueUTCOffset { get; set; }
        public string venueTimezone { get; set; }
        public string gameState { get; set; }
        public string gameScheduleState { get; set; }
        public List<TVBroadcast> tvBroadcasts { get; set; }
        public Team awayTeam { get; set; }
        public Team homeTeam { get; set; }
        //public Perioddescriptor periodDescriptor { get; set; }
        //public Gameoutcome gameOutcome { get; set; }
        //public Winninggoalie winningGoalie { get; set; }
        //public Winninggoalscorer winningGoalScorer { get; set; }
        public string threeMinRecap { get; set; }
        public string gameCenterLink { get; set; }
        public string threeMinRecapFr { get; set; }
        public string ticketsLink { get; set; }
        public Schedule parentSchedule { get; set; }
        public JToken json { get; set; }


        // Default void constructor
        public Game()
        {

        }

        public Game(string gameId)
        {

        }

        public Game(JToken game, string gameDate, Schedule parent)
        {
            // Populate the parentSchedule property to allow traversing the object hierarchy
            parentSchedule = parent;

            date = gameDate;
            //dayAbbrev = DateTime.Convert.ToDateTime(date)
            id = game["id"].ToString();
            season = game["season"].ToString();
            gameType = game["gameType"].ToString();
            neutralSite = game["neutralSite"].ToString();
            startTimeUTC = game["startTimeUTC"].ToString();
            easternUTCOffset = game["easternUTCOffset"].ToString();
            venueTimezone = game["venueTimezone"].ToString();
            gameState = game["gameState"].ToString();
            gameScheduleState = game["gameScheduleState"].ToString();
            threeMinRecap = game["threeMinRecap"].ToString();
            gameCenterLink = game["gameCenterLink"].ToString();
            json = game;


            // Get the list of TV Broadcasts for the game
            // Get the JSON array of TV Broadcasts
            var tvbArray = JArray.Parse(game.SelectToken("tvBroadcasts").ToString());
            tvBroadcasts = new List<TVBroadcast>();

            foreach (var tvb in tvbArray)
            {
                TVBroadcast aTVBroadcast = new TVBroadcast(tvb);
                tvBroadcasts.Add(aTVBroadcast);
                //Game aGame = new Game(game["gamePk"].ToString());
                //scheduledGames.Add(aGame);

            }

            venue = new Venue(game.SelectToken("venue").ToObject<JObject>());

            awayTeam = new Team(game.SelectToken("awayTeam"), this);
            homeTeam = new Team(game.SelectToken("homeTeam"), this);


        }

        //public string gameID { get; set; }
        //public string timeStamp { get; set; }
        //public string gameLink { get; set; }
        //public string gameType { get; set; }
        //public string season { get; set; }
        //public string gameDate { get; set; }
        //public string abstractGameState { get; set; }
        //public string codedGameState { get; set; }
        //public string detailedState { get; set; }
        //public string statusCode { get; set; }
        //public Team homeTeam { get; set; }
        //public Team awayTeam { get; set; }
        //public Venue gameVenue { get; set; }
        //public GameContent gameContent { get; set; }
        //public List<Player> gameParticipants { get; set; }
        //public List<GameEvent> gameEvents { get; set; }
        //public List<Period> periodData { get; set; }
        //public BoxScore gameBoxScore { get; set; } // Game stats
        //public JObject gameJson { get; set; } // storing the raw JSON data for the game

        //// Important URLs:  Live Feed:  https://statsapi.web.nhl.com/api/v1/game/2018020323/feed/live



        //// Default void constructor
        //public Game()
        //{

        //}

        //// Constructor for Game class from a specific Game ID
        //public Game(string theGameID)
        //{
        //    // Populate the gameID property
        //    gameID = theGameID;

        //    // Get the URL for the API call to a specific Game
        //    string theGame = NHLAPIServiceURLs.specificGame;

        //    // Replace placeholder value ("###") in the placeholder URL with the requested GameID.
        //    gameLink = theGame.Replace("###", theGameID);

        //    // Execute the API call
        //    var json = DataAccessLayer.ExecuteAPICall(gameLink);

        //    // Populate the raw JSON into the gameJson property
        //    gameJson = json;

        //    // Populate the rest of the Game class properties
        //    gameType = json.SelectToken("gameData.game.type").ToString();
        //    season = json.SelectToken("gameData.game.season").ToString();
        //    gameDate = json.SelectToken("gameData.datetime.dateTime").ToString();
        //    abstractGameState = json.SelectToken("gameData.status.abstractGameState").ToString();
        //    codedGameState = json.SelectToken("gameData.status.codedGameState").ToString();
        //    detailedState = json.SelectToken("gameData.status.detailedState").ToString();
        //    statusCode = json.SelectToken("gameData.status.statusCode").ToString();
        //    homeTeam = new Team(json.SelectToken("gameData.teams.home.id").ToString());
        //    awayTeam = new Team(json.SelectToken("gameData.teams.away.id").ToString());
        //    JObject venueJson = JObject.Parse(json.SelectToken("gameData.teams.home").ToString());
        //    if (venueJson.ContainsKey("venue"))
        //    {
        //        JObject venueObject = JObject.Parse(json.SelectToken("gameData.teams.home.venue").ToString());
        //        if (venueObject.ContainsKey("id"))
        //        {
        //            gameVenue = new Venue(json.SelectToken("gameData.teams.home.venue.id").ToString());
        //        }
        //    }

        //    // If the Abstract Game State is "Live" or "Final", populate the in-game data.
        //    if (abstractGameState != "Preview")
        //    {
        //        var periodInfo = JArray.Parse(json.SelectToken("liveData.linescore.periods").ToString());
        //        Period tempPeriod;
        //        periodData = new List<Period>();

        //        // If there is period data, populate the list of periods.
        //        if (periodInfo.Count > 0)
        //        {
        //            foreach (var period in periodInfo)
        //            {
        //                tempPeriod = new Period(gameID, (JObject)period, homeTeam.NHLTeamID.ToString(), awayTeam.NHLTeamID.ToString());
        //                periodData.Add(tempPeriod);
        //            }
        //        }


        //        //Populate the Box Score if it exists
        //        if (!(json.SelectToken("liveData.boxscore") is null))
        //        {
        //            gameBoxScore = new BoxScore(json.SelectToken("gameData.teams.home.id").ToString(), json.SelectToken("gameData.teams.away.id").ToString(), json.SelectToken("liveData.boxscore").ToObject<JObject>());
        //        }


        //        // Populating the players
        //        // Create a JSON 
        //        //var playerJson = JObject.Parse(json.SelectToken("gameData.players").ToString());


        //        //IList<JToken> results = playerJson.Children().ToList();
        //        IList<JToken> results = JObject.Parse(json.SelectToken("gameData.players").ToString()).Children().ToList();

        //        // Create a placeholder List<Player> for populating the game roster
        //        List<Player> playerList = new List<Player>();

        //        // Add each player to the List<Player> placeholder
        //        if (results.Children().Count() > 0)
        //        {
        //            foreach (JToken result in results.Children())
        //            {

        //                playerList.Add(new Player(Convert.ToInt32(result["id"])));

        //            }
        //        }


        //        // Populate gameParticipants property with List<Player> placeholder.
        //        if (playerList.Count > 0)
        //            gameParticipants = playerList;

        //        var gameEventsJson = JArray.Parse(json.SelectToken("liveData.plays.allPlays").ToString());

        //        GameEvent aGameEvent = new GameEvent();
        //        gameEvents = new List<GameEvent>();

        //        if (gameEventsJson.Count > 0)
        //        {
        //            foreach (var item in gameEventsJson)
        //            {
        //                aGameEvent = new GameEvent(item);
        //                gameEvents.Add(aGameEvent);

        //            }
        //        }
        //    }

        //    gameContent = new GameContent(theGameID);


        //}

        //// Constructor with featureFlag denotes that not all data on the game downward is being populated (think "Game Light")
        //public Game(string theGameID, int featureFlag)
        //{
        //    // Populate the gameID property
        //    gameID = theGameID;

        //    // Get the URL for the API call to a specific Game
        //    string theGame = NHLAPIServiceURLs.specificGame;

        //    // Replace placeholder value ("###") in the placeholder URL with the requested GameID.
        //    gameLink = theGame.Replace("###", theGameID);

        //    // Execute the API call
        //    var json = DataAccessLayer.ExecuteAPICall(gameLink);

        //    // Populate the raw JSON into the gameJson property
        //    gameJson = json;


        //    // Populate the rest of the Game class properties
        //    gameType = json.SelectToken("gameData.game.type").ToString();
        //    season = json.SelectToken("gameData.game.season").ToString();
        //    gameDate = json.SelectToken("gameData.datetime.dateTime").ToString();
        //    abstractGameState = json.SelectToken("gameData.status.abstractGameState").ToString();
        //    codedGameState = json.SelectToken("gameData.status.codedGameState").ToString();
        //    detailedState = json.SelectToken("gameData.status.detailedState").ToString();
        //    statusCode = json.SelectToken("gameData.status.statusCode").ToString();
        //    homeTeam = new Team(json.SelectToken("gameData.teams.home.id").ToString(), featureFlag);
        //    awayTeam = new Team(json.SelectToken("gameData.teams.away.id").ToString(), featureFlag);
        //    JObject venueObject = JObject.Parse(json.SelectToken("gameData.teams.home.venue").ToString());
        //    if (venueObject.ContainsKey("id"))
        //    {
        //        gameVenue = new Venue(json.SelectToken("gameData.teams.home.venue.id").ToString());
        //    }

        //    //Populate the Box Score
        //    if (json.ContainsKey("liveData.boxscore"))
        //    {
        //        gameBoxScore = new BoxScore(json.SelectToken("gameData.teams.home.id").ToString(), json.SelectToken("gameData.teams.away.id").ToString(), json.SelectToken("liveData.boxscore").ToObject<JObject>(), featureFlag);
        //    }
        //}

        //// Constructor below is largely used for live game statistics
        //public Game(string theGameID, string theTimeStamp)
        //{
        //    // Populate the gameID property
        //    gameID = theGameID;

        //    // Get the URL for the API call to a specific Game
        //    string theGame = NHLAPIServiceURLs.specificGame;

        //    // Replace placeholder value ("###") in the placeholder URL with the requested GameID.
        //    gameLink = theGame.Replace("###", theGameID);

        //    // Execute the API call
        //    var json = DataAccessLayer.ExecuteAPICall(gameLink);

        //    // Populate the raw JSON into the gameJson property
        //    gameJson = json;

        //    timeStamp = json.SelectToken("metaData.timeStamp").ToString();

        //    if (timeStamp != theTimeStamp)
        //    {
        //        // Populate the rest of the Game class properties
        //        gameType = json.SelectToken("gameData.game.type").ToString();
        //        season = json.SelectToken("gameData.game.season").ToString();
        //        gameDate = json.SelectToken("gameData.datetime.dateTime").ToString();
        //        abstractGameState = json.SelectToken("gameData.status.abstractGameState").ToString();
        //        codedGameState = json.SelectToken("gameData.status.codedGameState").ToString();
        //        detailedState = json.SelectToken("gameData.status.detailedState").ToString();
        //        statusCode = json.SelectToken("gameData.status.statusCode").ToString();
        //        homeTeam = new Team(json.SelectToken("gameData.teams.home.id").ToString());
        //        awayTeam = new Team(json.SelectToken("gameData.teams.away.id").ToString());
        //        JObject venueJson = JObject.Parse(json.SelectToken("gameData.teams.home").ToString());
        //        if (venueJson.ContainsKey("venue"))
        //        {
        //            JObject venueObject = JObject.Parse(json.SelectToken("gameData.teams.home.venue").ToString());
        //            if (venueObject.ContainsKey("id"))
        //            {
        //                gameVenue = new Venue(json.SelectToken("gameData.teams.home.venue.id").ToString());
        //            }
        //        }

        //        // If the Abstract Game State is "Live" or "Final", populate the in-game data.
        //        if (abstractGameState != "Preview")
        //        {
        //            var periodInfo = JArray.Parse(json.SelectToken("liveData.linescore.periods").ToString());
        //            Period tempPeriod;
        //            periodData = new List<Period>();

        //            // If there is period data, populate the list of periods.
        //            if (periodInfo.Count > 0)
        //            {
        //                foreach (var period in periodInfo)
        //                {
        //                    tempPeriod = new Period(gameID, (JObject)period, homeTeam.NHLTeamID.ToString(), awayTeam.NHLTeamID.ToString());
        //                    periodData.Add(tempPeriod);
        //                }
        //            }


        //            //Populate the Box Score if it exists
        //            if (!(json.SelectToken("liveData.boxscore") is null))
        //            {
        //                gameBoxScore = new BoxScore(json.SelectToken("gameData.teams.home.id").ToString(), json.SelectToken("gameData.teams.away.id").ToString(), json.SelectToken("liveData.boxscore").ToObject<JObject>());
        //            }


        //            // Populating the players
        //            // Create a JSON 
        //            //var playerJson = JObject.Parse(json.SelectToken("gameData.players").ToString());


        //            //IList<JToken> results = playerJson.Children().ToList();
        //            IList<JToken> results = JObject.Parse(json.SelectToken("gameData.players").ToString()).Children().ToList();

        //            // Create a placeholder List<Player> for populating the game roster
        //            List<Player> playerList = new List<Player>();

        //            // Add each player to the List<Player> placeholder
        //            if (results.Children().Count() > 0)
        //            {
        //                foreach (JToken result in results.Children())
        //                {

        //                    playerList.Add(new Player(Convert.ToInt32(result["id"])));

        //                }
        //            }


        //            // Populate gameParticipants property with List<Player> placeholder.
        //            if (playerList.Count > 0)
        //                gameParticipants = playerList;

        //            var gameEventsJson = JArray.Parse(json.SelectToken("liveData.plays.allPlays").ToString());

        //            GameEvent aGameEvent = new GameEvent();
        //            gameEvents = new List<GameEvent>();
        //            JToken latestGameEvent;

        //            if (gameEventsJson.Count > 0)
        //            {
        //                latestGameEvent = gameEventsJson[gameEventsJson.Count - 1];
        //                aGameEvent = new GameEvent(latestGameEvent);
        //                gameEvents.Add(aGameEvent);

        //                //foreach (var item in gameEventsJson)
        //                //{
        //                //    aGameEvent = new GameEvent(item);
        //                //    gameEvents.Add(aGameEvent);

        //                //}
        //            }
        //        }

        //        gameContent = new GameContent(theGameID);
        //    }

        //}

        //public static JObject GetGameJson(string gameId)
        //{
        //    JObject gameJson = new JObject();

        //    // Get the URL for the API call to a specific Game
        //    string theGame = NHLAPIServiceURLs.specificGame;

        //    // Replace placeholder value ("###") in the placeholder URL with the requested GameID.
        //    string gameLink = theGame.Replace("###", gameId);

        //    // Execute the API call
        //    gameJson = DataAccessLayer.ExecuteAPICall(gameLink);

        //    return gameJson;

        //}
    }
}
