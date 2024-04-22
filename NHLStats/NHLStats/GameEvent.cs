using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    // CLASS NAME:  GameEvent
    // Purpose:  Holds an event that had happened within a game.
    // Details:  For example, a hit, a goal, a penalty, a faceoff, a shot on net, etc.
    //           Includes x & y coordinates of the event on the ice.
    public class GameEvent
    {
        public string correspondingGameID { get; set; }
        public string eventType { get; set; }
        public string eventCode { get; set; }
        public string eventTypeID { get; set; }
        public string eventDescription { get; set; }
        public string eventSecondaryType { get; set; }
        public string eventIDx { get; set; }
        public string eventID { get; set; }
        public string period { get; set; }
        public string periodType { get; set; }
        public string ordinalPeriodNumber { get; set; }
        public string periodTime { get; set; }
        public string periodTimeRemaining { get; set; }
        public string dateTimeStamp { get; set; }
        public string goalsAway { get; set; }
        public string goalsHome { get; set; }
        public string xCoordinate { get; set; }
        public string yCoordinate { get; set; }
        public Team team { get; set; }
        public List<Player> players { get; set; }
        public JObject gameEventJson { get; set; } // Populate the raw JSON to a property

        public GameEvent()
        {

        }

        public GameEvent(JToken jsonGameEvents)
        {
            JObject gameEventObject = jsonGameEvents.ToObject<JObject>();

            // Populate the raw JSON to a property
            gameEventJson = gameEventObject;

            // If the game event contains a list of players, parse through the players and insert them
            if (gameEventObject.ContainsKey("players"))
            {
                Player aPlayer;
                List<Player> thePlayers = new List<Player>();
                foreach (var item in gameEventObject["players"])
                {
                    aPlayer = new Player(Convert.ToInt32(item.SelectToken("player.id")));
                    thePlayers.Add(aPlayer);
                }
                players = thePlayers;
            }

            
            eventType = gameEventObject.SelectToken("result.event").ToString();
            eventCode = gameEventObject.SelectToken("result.eventCode").ToString();
            eventTypeID = gameEventObject.SelectToken("result.eventTypeId").ToString();
            eventDescription = gameEventObject.SelectToken("result.description").ToString();
            if (gameEventObject.ContainsKey("eventSecondaryType"))
            {
                eventSecondaryType = gameEventObject.SelectToken("result.eventSecondaryType").ToString();
            }
            eventIDx = gameEventObject.SelectToken("about.eventIdx").ToString();
            eventID = gameEventObject.SelectToken("about.eventId").ToString();
            period = gameEventObject.SelectToken("about.period").ToString();
            periodType = gameEventObject.SelectToken("about.periodType").ToString();
            ordinalPeriodNumber = gameEventObject.SelectToken("about.ordinalNum").ToString();
            periodTime = gameEventObject.SelectToken("about.periodTime").ToString();
            periodTimeRemaining = gameEventObject.SelectToken("about.periodTimeRemaining").ToString();

            //if (periodTimeRemaining == "")
            //{
                if (periodTime != "")
                {
                    int periodTimeSeconds = Utilities.ConvertPeriodTimeToSeconds(periodTime);
                    int remainingPeriodTimeSeconds = 1200 - periodTimeSeconds;

                    periodTimeRemaining = Utilities.ConvertSecondsToPeriodTime(remainingPeriodTimeSeconds);
                }
                else
                {
                    periodTimeRemaining = "00:00";
                }
            //}

            dateTimeStamp = gameEventObject.SelectToken("about.dateTime").ToString();
            goalsAway = gameEventObject.SelectToken("about.goals.away").ToString();
            goalsHome = gameEventObject.SelectToken("about.goals.home").ToString();
            JObject coordinateEvent = gameEventObject["coordinates"].ToObject<JObject>();
            if (coordinateEvent.ContainsKey("x"))
            {
                xCoordinate = gameEventObject.SelectToken("coordinates.x").ToString();
            }

            if (coordinateEvent.ContainsKey("y"))
            {
                yCoordinate = gameEventObject.SelectToken("coordinates.y").ToString();
            }

            if (gameEventObject.ContainsKey("team"))
            {
                //Team theTeam = new Team(gameEventObject.SelectToken("team.id").ToString());
                //team = theTeam;
            }
            


        }
    }
}
