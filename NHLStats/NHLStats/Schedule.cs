﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace NHLStats
{
    public class Schedule
    {
        public string nextStartDate { get; set; }
        public string previousStartDate { get; set; }
        public List<Game> games { get; set; }
        //public Oddspartner[] oddsPartners { get; set; }
        public string preSeasonStartDate { get; set; }
        public string regularSeasonStartDate { get; set; }
        public string regularSeasonEndDate { get; set; }
        public string playoffEndDate { get; set; }
        public int numberOfGames { get; set; }
        public string season { get; set; }
        public JObject scheduleJson {get; set;}


        // Default constructor:  shows today's schedule
        public Schedule(string scheduleDate)
        {
            string gameDateScheduleURL;
            if (scheduleDate == null)
                gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + Utilities.GetYesterdaysDate();
            else
                gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + scheduleDate;
            //gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "2024-02-04";

            var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);
            
            if (json["nextStartDate"] != null)
            {
                nextStartDate = json["nextStartDate"].ToString();
            }            
            else
            {
                nextStartDate = "null";
            }

            if (json["previousStartDate"] != null)
            {
                previousStartDate = json["previousStartDate"].ToString();

            }
            else
            {
                previousStartDate = "null";
            }

            if (json["preSeasonStartDate"] != null)
            {
                preSeasonStartDate = json["preSeasonStartDate"].ToString();
            }
            else
            {
                preSeasonStartDate = "null";
            }

            if (json["regularSeasonStartDate"] != null)
            {
                regularSeasonStartDate = json["regularSeasonStartDate"].ToString();
            }
            else
            {
                regularSeasonStartDate = "null";
            }


            if (json["regularSeasonEndDate"] != null)
            {
                regularSeasonEndDate = json["regularSeasonEndDate"].ToString();
            }
            else
            {
                regularSeasonEndDate = "null";
            }
            
            
            if (json["playoffEndDate"] != null)
            {
                playoffEndDate = json["playoffEndDate"].ToString();
            }
            else
            {
                playoffEndDate = "null";
            }

            if (json["numberOfGames"] != null)
            {
                numberOfGames = Convert.ToInt32(json["numberOfGames"]);
            }
            else
            {
                numberOfGames = -1;
            }

            season = Utilities.GetSeasonFromDate(Utilities.GetYesterdaysDate());
            scheduleJson = new JObject(json);

            // Get the JSON array of games
            if (JArray.Parse(json.SelectToken("gameWeek").ToString()) != null)
            {
                var scheduleArray = JArray.Parse(json.SelectToken("gameWeek").ToString());
                games = new List<Game>();

                // Get the ordinal day of the week so as to retrieve the right section of JSON from the schedule
                int ordinalDayOfWeek = Utilities.GetOrdinalDayOfWeek(Utilities.GetYesterdaysDate());
                ordinalDayOfWeek = Utilities.GetOrdinalDayOfWeek("2024-02-04");

                foreach (var game in scheduleArray[ordinalDayOfWeek]["games"])
                {
                    Game aGame = new Game(game, season, this);
                    games.Add(aGame);

                }
            }
            
        }





        //public string totalItems { get; set; }
        //public string totalEvents { get; set; }
        //public string totalGames { get; set; }
        //public string totalMatches { get; set; }
        //public string season { get; set; }
        //public string scheduleDate { get; set; }
        //public List<Game> games { get; set; }
        //public JObject scheduleJson { get; set;  } //Storage of the raw JSON feed

        //// Important URLs:  https://statsapi.web.nhl.com/api/v1/schedule?date=2018-11-21

        //// Default constructor:  shows today's schedule
        //public Schedule()
        //{
        //    string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames;

        //    var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

        //    totalItems = json["totalItems"].ToString();
        //    totalEvents = json["totalEvents"].ToString();
        //    totalGames = json["totalGames"].ToString();
        //    totalMatches = json["totalMatches"].ToString();

        //    List<Game> scheduledGames = new List<Game>();

        //    var scheduleArray = JArray.Parse(json.SelectToken("dates").ToString());
        //    foreach (var game in scheduleArray[0]["games"])
        //    {
        //        Game aGame = new Game(game["gamePk"].ToString());
        //        scheduledGames.Add(aGame);

        //    }


        //    games = scheduledGames;
        //}


        //// NOTE:  Parameter format for date is YYYY-MM-DD
        //public Schedule(string gameDate)
        //{

        //    string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" +  gameDate;

        //    var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

        //    // Populate the raw JSON feed to the scheduleJson property.
        //    scheduleJson = json;
        //    if (json.ContainsKey("totalItems"))
        //        totalItems = json["totalItems"].ToString();
        //    else
        //        totalItems = "0";
        //    if (json.ContainsKey("totalEvents"))
        //        totalEvents = json["totalEvents"].ToString();
        //    else
        //        totalEvents = "0";
        //    if (json.ContainsKey("totalGames"))
        //        totalGames = json["totalGames"].ToString();
        //    else
        //        totalGames = "0";
        //    if (json.ContainsKey("totalMatches"))
        //        totalMatches = json["totalMatches"].ToString();
        //    else
        //        totalMatches = "0";
        //    scheduleDate = gameDate;

        //    List<Game> scheduledGames = new List<Game>();

        //    var scheduleArray = JArray.Parse(json.SelectToken("dates").ToString());

        //    // If the day has schedule games, add them to the object.
        //    if (scheduleArray.Count > 0)
        //    {
        //        foreach (var game in scheduleArray[0]["games"])
        //        {
        //            Game aGame = new Game(game["gamePk"].ToString());
        //            scheduledGames.Add(aGame);

        //            if (season == "" || season == null)
        //            {
        //                season = aGame.season;
        //            }

        //        }

        //        games = scheduledGames;
        //    }

        //}

        //// Constructor with featureFlag denotes that not all data on the schedule downward is being populated (think "Schedule Light")
        //public Schedule (string gameDate, int featureFlag)
        //{
        //    string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" + gameDate;

        //    var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

        //    totalItems = json["totalItems"].ToString();
        //    totalEvents = json["totalEvents"].ToString();
        //    totalGames = json["totalGames"].ToString();
        //    totalMatches = json["totalMatches"].ToString();

        //    List<Game> scheduledGames = new List<Game>();

        //    var scheduleArray = JArray.Parse(json.SelectToken("dates").ToString());
        //    foreach (var game in scheduleArray[0]["games"])
        //    {
        //        Game aGame = new Game(game["gamePk"].ToString(), featureFlag);
        //        scheduledGames.Add(aGame);

        //    }


        //    games = scheduledGames;
        //}

        //public static List<string> GetListOfGameIDs(string scheduleDate)
        //{
        //    string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" + scheduleDate;

        //    var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

        //    List<string> listOfGameIDs = new List<string>();



        //    var scheduleArray = JArray.Parse(json.SelectToken("dates").ToString());
        //    if (scheduleArray.Count > 0)
        //    {
        //        foreach (var game in scheduleArray[0]["games"])
        //        {
        //            listOfGameIDs.Add(game["gamePk"].ToString());
        //        }
        //    }


        //    return listOfGameIDs;
        //}

        //public static string[,] GetListOfGameIDsWithMetadata(string scheduleDate)
        //{
        //    string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" + scheduleDate;
        //    //string[,] returnArray = new string[,]();

        //    var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

        //    List<string> listOfGameIDs = new List<string>();

        //    int count = 0;
        //    JObject gameJson = new JObject();
        //    string metadata;

        //    var scheduleArray = JArray.Parse(json.SelectToken("dates").ToString());
        //    string[,] returnArray = new string[Convert.ToInt16(scheduleArray[0]["totalGames"]), 2];

        //    if (scheduleArray.Count > 0)
        //    {

        //        foreach (var game in scheduleArray[0]["games"])
        //        {
        //            // Get the URL for the API call to a specific Game
        //            string theGame = NHLAPIServiceURLs.specificGame;

        //            // Replace placeholder value ("###") in the placeholder URL with the requested GameID.
        //            string gameLink = theGame.Replace("###", game["gamePk"].ToString());

        //            // Execute the API call
        //            gameJson = DataAccessLayer.ExecuteAPICall(gameLink);

        //            returnArray[count, 0] = gameJson.SelectToken("gamePk").ToString();

        //            metadata = "(" + gameJson.SelectToken("gameData.teams.away.name").ToString() + " at " + gameJson.SelectToken("gameData.teams.home.name").ToString() + ")";

        //            returnArray[count, 1] = metadata;

        //            count++;
        //        }
        //    }

        //    return returnArray;
        //}

        //public static JObject GetScheduleJson(string scheduleDate)
        //{
        //    JObject scheduleJson = new JObject();

        //    string gameDateScheduleURL;

        //    if (scheduleDate is null)
        //    {
        //        gameDateScheduleURL = NHLAPIServiceURLs.todaysGames;
        //    }
        //    else
        //    {
        //        gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" + scheduleDate;
        //    }

        //    scheduleJson = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

        //    return scheduleJson;

        //}

        //public static int GameCount(string scheduleDate)
        //{
        //    string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" + scheduleDate;

        //    int totalGames; 

        //    var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

        //    if (json.ContainsKey("totalGames"))
        //        totalGames = Convert.ToInt32(json["totalGames"].ToString());
        //    else
        //        totalGames = 0;

        //    return totalGames;
        //}

        //public static List<Game> TeamSchedule(string teamId, string season)
        //{
        //    List<Game> gameList = new List<Game>();

        //    // Create the URL call to get the schedule for the specified team in the specified season
        //    string teamScheduleExtension = NHLAPIServiceURLs.schedule_season_team.Replace("########", season);
        //    teamScheduleExtension = teamScheduleExtension.Replace("@@", teamId);
        //    string teamScheduleURL = NHLAPIServiceURLs.schedule + teamScheduleExtension;

        //    var json = DataAccessLayer.ExecuteAPICall(teamScheduleURL);

        //    var gameListJSON = JArray.Parse(json.SelectToken("dates").ToString());

        //    Game aGame = new Game();
        //    string gameId;

        //    // Check to see if there is a schedule list, if yes then parse through the games.
        //    if (gameListJSON.Count > 0)
        //    {
        //        foreach (var eachGame in gameListJSON)
        //        {
        //            var gameArray = eachGame.SelectToken("games");
        //            gameId = gameArray[0].SelectToken("gamePk").ToString();
        //            aGame = new Game();

        //            // Populate the Game Object
        //            aGame.gameID = gameId;
        //            aGame.season = season;
        //            aGame.gameType = gameArray[0].SelectToken("gameType").ToString();
        //            aGame.gameDate = gameArray[0].SelectToken("gameDate").ToString();
        //            aGame.abstractGameState = gameArray[0].SelectToken("status.abstractGameState").ToString();
        //            aGame.codedGameState = gameArray[0].SelectToken("status.codedGameState").ToString();
        //            aGame.detailedState = gameArray[0].SelectToken("status.detailedState").ToString();
        //            aGame.statusCode = gameArray[0].SelectToken("status.statusCode").ToString();
        //            aGame.homeTeam = new Team(gameArray[0].SelectToken("teams.home.team.id").ToString());
        //            aGame.awayTeam = new Team(gameArray[0].SelectToken("teams.away.team.id").ToString());
        //            if (gameArray[0].SelectToken("venue.id") != null)
        //                aGame.gameVenue = new Venue(gameArray[0].SelectToken("venue.id").ToString());

        //            gameList.Add(aGame);
        //        }
        //    }

        //    return gameList;

        //}
    }
    
}
