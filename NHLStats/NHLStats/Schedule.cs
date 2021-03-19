using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace NHLStats
{
    public class Schedule
    {
        public string totalItems { get; set; }
        public string totalEvents { get; set; }
        public string totalGames { get; set; }
        public string totalMatches { get; set; }
        public string season { get; set; }
        public string scheduleDate { get; set; }
        public List<Game> games { get; set; }
        public JObject scheduleJson { get; set;  } //Storage of the raw JSON feed

        // Important URLs:  https://statsapi.web.nhl.com/api/v1/schedule?date=2018-11-21

        // Default constructor:  shows today's schedule
        public Schedule()
        {
            string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames;

            var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

            totalItems = json["totalItems"].ToString();
            totalEvents = json["totalEvents"].ToString();
            totalGames = json["totalGames"].ToString();
            totalMatches = json["totalMatches"].ToString();

            List<Game> scheduledGames = new List<Game>();

            var scheduleArray = JArray.Parse(json.SelectToken("dates").ToString());
            foreach (var game in scheduleArray[0]["games"])
            {
                Game aGame = new Game(game["gamePk"].ToString());
                scheduledGames.Add(aGame);

            }


            games = scheduledGames;
        }


        // NOTE:  Parameter format for date is YYYY-MM-DD
        public Schedule(string gameDate)
        {

            string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" +  gameDate;
            
            var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

            // Populate the raw JSON feed to the scheduleJson property.
            scheduleJson = json;
            if (json.ContainsKey("totalItems"))
                totalItems = json["totalItems"].ToString();
            else
                totalItems = "0";
            if (json.ContainsKey("totalEvents"))
                totalEvents = json["totalEvents"].ToString();
            else
                totalEvents = "0";
            if (json.ContainsKey("totalGames"))
                totalGames = json["totalGames"].ToString();
            else
                totalGames = "0";
            if (json.ContainsKey("totalMatches"))
                totalMatches = json["totalMatches"].ToString();
            else
                totalMatches = "0";
            scheduleDate = gameDate;

            List<Game> scheduledGames = new List<Game>();

            var scheduleArray = JArray.Parse(json.SelectToken("dates").ToString());

            // If the day has schedule games, add them to the object.
            if (scheduleArray.Count > 0)
            {
                foreach (var game in scheduleArray[0]["games"])
                {
                    Game aGame = new Game(game["gamePk"].ToString());
                    scheduledGames.Add(aGame);

                    if (season == "" || season == null)
                    {
                        season = aGame.season;
                    }

                }

                games = scheduledGames;
            }
            
        }

        // Constructor with featureFlag denotes that not all data on the schedule downward is being populated (think "Schedule Light")
        public Schedule (string gameDate, int featureFlag)
        {
            string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" + gameDate;

            var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

            totalItems = json["totalItems"].ToString();
            totalEvents = json["totalEvents"].ToString();
            totalGames = json["totalGames"].ToString();
            totalMatches = json["totalMatches"].ToString();

            List<Game> scheduledGames = new List<Game>();

            var scheduleArray = JArray.Parse(json.SelectToken("dates").ToString());
            foreach (var game in scheduleArray[0]["games"])
            {
                Game aGame = new Game(game["gamePk"].ToString(), featureFlag);
                scheduledGames.Add(aGame);

            }


            games = scheduledGames;
        }

        public static List<string> GetListOfGameIDs(string scheduleDate)
        {
            string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" + scheduleDate;

            var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

            List<string> listOfGameIDs = new List<string>();
            

            
            var scheduleArray = JArray.Parse(json.SelectToken("dates").ToString());
            if (scheduleArray.Count > 0)
            {
                foreach (var game in scheduleArray[0]["games"])
                {
                    listOfGameIDs.Add(game["gamePk"].ToString());
                }
            }


            return listOfGameIDs;
        }

        public static string[,] GetListOfGameIDsWithMetadata(string scheduleDate)
        {
            string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" + scheduleDate;
            //string[,] returnArray = new string[,]();

            var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

            List<string> listOfGameIDs = new List<string>();

            int count = 0;
            JObject gameJson = new JObject();
            string metadata;

            var scheduleArray = JArray.Parse(json.SelectToken("dates").ToString());
            string[,] returnArray = new string[Convert.ToInt16(scheduleArray[0]["totalGames"]), 2];

            if (scheduleArray.Count > 0)
            {

                foreach (var game in scheduleArray[0]["games"])
                {
                    // Get the URL for the API call to a specific Game
                    string theGame = NHLAPIServiceURLs.specificGame;

                    // Replace placeholder value ("###") in the placeholder URL with the requested GameID.
                    string gameLink = theGame.Replace("###", game["gamePk"].ToString());

                    // Execute the API call
                    gameJson = DataAccessLayer.ExecuteAPICall(gameLink);

                    returnArray[count, 0] = gameJson.SelectToken("gamePk").ToString();

                    metadata = "(" + gameJson.SelectToken("gameData.teams.away.name").ToString() + " at " + gameJson.SelectToken("gameData.teams.home.name").ToString() + ")";

                    returnArray[count, 1] = metadata;

                    count++;
                }
            }

            return returnArray;
        }

        public static JObject GetScheduleJson(string scheduleDate)
        {
            JObject scheduleJson = new JObject();

            string gameDateScheduleURL;

            if (scheduleDate is null)
            {
                gameDateScheduleURL = NHLAPIServiceURLs.todaysGames;
            }
            else
            {
                gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" + scheduleDate;
            }

            scheduleJson = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);

            return scheduleJson;

        }

        public static int GameCount(string scheduleDate)
        {
            string gameDateScheduleURL = NHLAPIServiceURLs.todaysGames + "?date=" + scheduleDate;

            int totalGames; 

            var json = DataAccessLayer.ExecuteAPICall(gameDateScheduleURL);
                        
            if (json.ContainsKey("totalGames"))
                totalGames = Convert.ToInt32(json["totalGames"].ToString());
            else
                totalGames = 0;

            return totalGames;
        }
    }
    
}
