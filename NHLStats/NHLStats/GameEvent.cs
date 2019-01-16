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
    }
}
