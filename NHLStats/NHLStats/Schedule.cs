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
        //public string wait { get; set; }
        public List<Game> games { get; set; }

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
    }
}
