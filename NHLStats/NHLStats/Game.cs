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
        public string awayTeamScore { get; set; }
        public string homeTeamScore { get; set; }
        public string awayTeamSOG { get; set; }
        public string homeTeamSOG { get; set; } 
        public string periodNumber { get; set; }
        public string periodType { get; set; }
        public string timeRemaining { get; set; }
        public string secondsRemaining { get; set; }
        public string gameIsRunning { get; set;}
        public string inIntermission { get; set; }
        public List<ShiftChart> shiftChartList { get; set; }
        public string gameSummaryURL { get; set; }
        public string eventSummaryURL { get; set; }
        public string playByPlayURL { get; set; }
        public string faceOffSummaryURL { get; set; }
        public string faceOffComparisonURL { get; set; }
        public string rostersURL { get; set; }
        public string shotSummaryURL { get; set; }
        public string shiftChartURL     { get; set; }
        public string toiAwayURL { get; set; }
        public string toiHomeURL { get; set; }
        //public Perioddescriptor periodDescriptor { get; set; }
        //public Gameoutcome gameOutcome { get; set; }
        //public Winninggoalie winningGoalie { get; set; }
        //public Winninggoalscorer winningGoalScorer { get; set; }
        public string threeMinRecap { get; set; }
        public string gameCenterLink { get; set; }
        public string threeMinRecapFr { get; set; }
        public string ticketsLink { get; set; }
        public BoxScore boxScore { get; set; }
        public List<GameEvent> gameEvents { get; set; } 
        public List<Person> officials { get; set; } // The list of officials for the game
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

            id = game["id"].ToString();
            // Get additional data from the boxscore API call
            string gameAPIURL = NHLAPIServiceURLs.specificGame.Replace("###", id);
            var boxScoreJson = DataAccessLayer.ExecuteAPICall(gameAPIURL);


            date = gameDate;
            //dayAbbrev = DateTime.Convert.ToDateTime(date)
            
            season = game["season"].ToString();
            gameType = game["gameType"].ToString();
            neutralSite = game["neutralSite"].ToString();
            startTimeUTC = game["startTimeUTC"].ToString();
            easternUTCOffset = game["easternUTCOffset"].ToString();
            venueTimezone = game["venueTimezone"].ToString();
            gameState = game["gameState"].ToString();
            gameScheduleState = game["gameScheduleState"].ToString();
            if (game["threeMinRecap"] != null)
                threeMinRecap = game["threeMinRecap"].ToString();
            gameCenterLink = game["gameCenterLink"].ToString();
            awayTeamScore = boxScoreJson.SelectToken("awayTeam.score").ToString();
            homeTeamScore = boxScoreJson.SelectToken("homeTeam.score").ToString();
            awayTeamSOG = boxScoreJson.SelectToken("awayTeam.sog").ToString();
            homeTeamSOG = boxScoreJson.SelectToken("homeTeam.sog").ToString();
            periodNumber = boxScoreJson.SelectToken("periodDescriptor.number").ToString();
            periodType = boxScoreJson.SelectToken("periodDescriptor.periodType").ToString();
            timeRemaining = boxScoreJson.SelectToken("clock.timeRemaining").ToString();
            secondsRemaining = boxScoreJson.SelectToken("clock.secondsRemaining").ToString();
            gameIsRunning = boxScoreJson.SelectToken("clock.running").ToString();
            inIntermission = boxScoreJson.SelectToken("clock.inIntermission").ToString();
            gameSummaryURL = boxScoreJson.SelectToken("summary.gameReports.gameSummary").ToString();
            eventSummaryURL = boxScoreJson.SelectToken("summary.gameReports.eventSummary").ToString();
            playByPlayURL = boxScoreJson.SelectToken("summary.gameReports.playByPlay").ToString();
            faceOffSummaryURL = boxScoreJson.SelectToken("summary.gameReports.faceoffSummary").ToString();
            faceOffComparisonURL = boxScoreJson.SelectToken("summary.gameReports.faceoffComparison").ToString();
            rostersURL = boxScoreJson.SelectToken("summary.gameReports.rosters").ToString();
            shotSummaryURL = boxScoreJson.SelectToken("summary.gameReports.shotSummary").ToString();
            this.shiftChartURL = boxScoreJson.SelectToken("summary.gameReports.shiftChart").ToString();
            toiAwayURL = boxScoreJson.SelectToken("summary.gameReports.toiAway").ToString();
            toiHomeURL = boxScoreJson.SelectToken("summary.gameReports.toiHome").ToString();
            
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

            // Populate the venue data for the game
            venue = new Venue(boxScoreJson.SelectToken("venue").ToObject<JObject>(), boxScoreJson.SelectToken("venueLocation").ToObject<JObject>());

            // Populate the team data for the game
            awayTeam = new Team(boxScoreJson.SelectToken("awayTeam"), this);
            homeTeam = new Team(boxScoreJson.SelectToken("homeTeam"), this);

            // Populate the list of officials for the game
            officials = new List<Person>();
            Person tempReferee;
            var refereeList = JArray.Parse(boxScoreJson.SelectToken("summary.gameInfo.referees").ToString());
            var linesmanList = JArray.Parse(boxScoreJson.SelectToken("summary.gameInfo.linesmen").ToString());

            foreach (var referee in refereeList)
            {
                tempReferee = new Person(referee.ToObject<JObject>(), "referee");
                officials.Add(tempReferee);

            }

            foreach (var linesman in linesmanList)
            {
                tempReferee = new Person(linesman.ToObject<JObject>(), "linesman");
                officials.Add(tempReferee);

            }

            // Populate the boxscore data for the game
            string gameStoryURL = NHLAPIServiceURLs.gameStory.Replace("###", id);
            var gameStoryJson = DataAccessLayer.ExecuteAPICall(gameStoryURL);
            boxScore = new BoxScore(homeTeam.id, awayTeam.id, gameStoryJson);

            // Get the Shift Chart data for the game
            shiftChartList = new List<ShiftChart>();
            ShiftChart shift = new ShiftChart();
            string shiftChartURL = NHLAPIServiceURLs.shiftChart.Replace("###", id);
            var shiftChartJson = DataAccessLayer.ExecuteAPICall(shiftChartURL);


            foreach (var shiftJson in shiftChartJson.SelectToken("data"))
            {
                shift = new ShiftChart(id, shiftJson);
                shiftChartList.Add(shift);
            }

            gameEvents = new List<GameEvent>();
            GameEvent gameEvent = new GameEvent();
            string gameEventsURL = NHLAPIServiceURLs.gameEvent.Replace("###", id);
            var gameEventsJson = DataAccessLayer.ExecuteAPICall(gameEventsURL);

            foreach (var gameEventJson in gameEventsJson.SelectToken("plays"))
            {
                gameEvent = new GameEvent(id, gameEventJson);
                gameEvents.Add(gameEvent);
            }
            



        }

    }
}
