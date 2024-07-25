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
        public string gameId {  get; set; }
        public string eventId { get; set; }
        public string periodNumber { get; set; }
        public string periodType { get; set; }
        public string timeInPeriod { get; set; }
        public string timeRemaining { get; set; }
        public string situationCode { get; set; }
        public string homeTeamDefendingSide { get; set; }
        public string typeCode { get; set; }
        public string typeDescKey { get; set; }
        public string sortOrder { get; set; }
        public string xCoordinate { get; set; }
        public string yCoordinate { get; set; }
        public string zoneCode { get; set; }
        public string shotType { get; set; }
        public string shootingPlayerId { get; set; }
        public string goalieInNetId { get; set; }
        public string eventOwnerTeamId { get; set; }
        public string awaySOG { get; set; }
        public string homeSOG { get; set; }
        public string hittingPlayerId { get; set; }
        public string hitteePlayerId { get; set; }
        public string losingPlayerId { get; set; }
        public string winningPlayerId { get; set; }
        public string giveawayPlayerId { get; set; }
        public string scoringPlayerId { get; set; }
        public string scoringPlayerTotal { get; set; }
        public string assist1PlayerId { get; set; }
        public string assist1PlayerTotal { get; set; }
        public string assist2PlayerId { get; set; }
        public string assist2PlayerTotal { get; set; }
        public string awayScore { get; set; }
        public string homeScore { get; set; }
        public string reason { get; set; }
        public string blockingPlayerId { get; set; }
        public string detailTypeCode { get; set; }
        public string descKey { get; set; }
        public string duration { get; set; }
        public string drawnByPlayerId { get; set; }
        public string committedByPlayerId { get; set; }
        public string takeawayPlayerId { get; set; }
        public JObject gameEventJson { get; set; } // Populate the raw JSON to a property

        public GameEvent()
        {

        }

        public GameEvent(string gameId, JToken json)
        {
            // Event types
            // 502 - faceoff (unique details:  losingPlayerId, winningPlayerId)
            // 503 - hit (unique details: hittingPlayerId, hitteePlayerId)
            // 504 - giveaway (unique details: playerId)
            // 505 - goal (unique details: shotType, scoringPlayerId, scoringPlayerTotal, assist1PlayerId, assist1PlayerTotal, goalieInNetId, awayScore, homeScore)
            // 506 - shot-on-goal (unique details: shotType, shootingPlayerId, goalieInNetId, awaySOG, homeSOG)
            // 507 - missed-shot (unique details: reason, shotType, shootingPlayerId, goalieInNetId)
            // 508 - blocked-shot (unique details: blockingPlayerId, shootingPlayerId, reason)
            // 509 - penalty (unique details: typeCode, descKey, duration, committedByPlayerId, drawnByPlayerId)
            // 516 - stoppage (unique details: reason, secondaryReason)
            // 520 - period-start (no unique details)
            // 521 - period-end (no unique details)
            // 524 - game-end (no unique details)
            // 525 - takeaway (unique details: playerId)
            // 535 - delayed-penalty (no unique details)


            this.gameId = gameId;
            eventId = json.SelectToken("eventId").ToString();
            periodNumber = json.SelectToken("periodDescriptor.number").ToString();
            periodType = json.SelectToken("periodDescriptor.periodType").ToString();
            timeInPeriod = json.SelectToken("timeInPeriod").ToString();
            timeRemaining = json.SelectToken("timeRemaining").ToString();
            situationCode = json.SelectToken("situationCode").ToString();
            homeTeamDefendingSide = json.SelectToken("homeTeamDefendingSide").ToString();
            typeCode = json.SelectToken("typeCode").ToString();
            typeDescKey = json.SelectToken("typeDescKey").ToString();
            sortOrder = json.SelectToken("sortOrder").ToString();


            if (typeCode == "502") // Faceoff event
            {
                eventOwnerTeamId = json.SelectToken("details.eventOwnerTeamId").ToString();
                losingPlayerId = json.SelectToken("details.losingPlayerId").ToString();
                winningPlayerId = json.SelectToken("details.winningPlayerId").ToString();
                xCoordinate = json.SelectToken("details.xCoord").ToString();
                yCoordinate = json.SelectToken("details.yCoord").ToString();
                zoneCode = json.SelectToken("details.zoneCode").ToString();
            }
            else if (typeCode == "503")  // Hit event
            {
                eventOwnerTeamId = json.SelectToken("details.eventOwnerTeamId").ToString();
                xCoordinate = json.SelectToken("details.xCoord").ToString();
                yCoordinate = json.SelectToken("details.yCoord").ToString();
                zoneCode = json.SelectToken("details.zoneCode").ToString();
                hittingPlayerId = json.SelectToken("details.hittingPlayerId").ToString();
                hitteePlayerId = json.SelectToken("details.hitteePlayerId").ToString();
            }
            else if (typeCode == "504")  // Giveaway event
            {
                eventOwnerTeamId = json.SelectToken("details.eventOwnerTeamId").ToString();
                giveawayPlayerId = json.SelectToken("details.playerId").ToString();
                xCoordinate = json.SelectToken("details.xCoord").ToString();
                yCoordinate = json.SelectToken("details.yCoord").ToString();
                zoneCode = json.SelectToken("details.zoneCode").ToString();

            }
            else if (typeCode == "505")  // Goal event
            {
                eventOwnerTeamId = json.SelectToken("details.eventOwnerTeamId").ToString();
                if (json.SelectToken("details.shotType") != null)
                    shotType = json.SelectToken("details.shotType").ToString();
                scoringPlayerId = json.SelectToken("details.scoringPlayerId").ToString();
                scoringPlayerTotal = json.SelectToken("details.scoringPlayerTotal").ToString();
                if (json.SelectToken("details.assistPlayer1Id") != null)
                {
                    assist1PlayerId = json.SelectToken("details.assist1PlayerId").ToString();
                    assist1PlayerTotal = json.SelectToken("details.assist1PlayerTotal").ToString();

                    if (json.SelectToken("details.assistPlayer2Id") != null)
                    {
                        assist2PlayerId = json.SelectToken("details.assist1PlayerId").ToString();
                        assist2PlayerTotal = json.SelectToken("details.assist1PlayerTotal").ToString();
                    }
                }
                if(json.SelectToken("details.goalieInNetId") != null)
                    goalieInNetId = json.SelectToken("details.goalieInNetId").ToString();
                awayScore = json.SelectToken("details.awayScore").ToString();
                homeScore = json.SelectToken("details.homeScore").ToString();
                xCoordinate = json.SelectToken("details.xCoord").ToString();
                yCoordinate = json.SelectToken("details.yCoord").ToString();
                zoneCode = json.SelectToken("details.zoneCode").ToString();
            }
            else if (typeCode == "506")  // Shot-on-goal event
            {
                xCoordinate = json.SelectToken("details.xCoord").ToString();
                yCoordinate = json.SelectToken("details.yCoord").ToString();
                zoneCode = json.SelectToken("details.zoneCode").ToString();
                shotType = json.SelectToken("details.shotType").ToString();
                shootingPlayerId = json.SelectToken("details.shootingPlayerId").ToString();
                goalieInNetId = json.SelectToken("details.goalieInNetId").ToString();
                eventOwnerTeamId = json.SelectToken("details.eventOwnerTeamId").ToString();
                awaySOG = json.SelectToken("details.awaySOG").ToString();
                homeSOG = json.SelectToken("details.homeSOG").ToString();
            }
            else if (typeCode == "507")  // Missed-shot event
            {
                xCoordinate = json.SelectToken("details.xCoord").ToString();
                yCoordinate = json.SelectToken("details.yCoord").ToString();
                zoneCode = json.SelectToken("details.zoneCode").ToString();
                reason = json.SelectToken("details.reason").ToString();
                shotType = json.SelectToken("details.shotType").ToString();
                shootingPlayerId = json.SelectToken("details.shootingPlayerId").ToString();
                if (json.SelectToken("details.goalieInNetId") != null)
                    goalieInNetId = json.SelectToken("details.goalieInNetId").ToString();
                eventOwnerTeamId = json.SelectToken("details.eventOwnerTeamId").ToString();
            }
            else if (typeCode == "508")  // Blocked-shot event
            {
                xCoordinate = json.SelectToken("details.xCoord").ToString();
                yCoordinate = json.SelectToken("details.yCoord").ToString();
                zoneCode = json.SelectToken("details.zoneCode").ToString();
                blockingPlayerId = json.SelectToken("details.blockingPlayerId").ToString();
                shootingPlayerId = json.SelectToken("details.shootingPlayerId").ToString();
                reason = json.SelectToken("details.reason").ToString();
                eventOwnerTeamId = json.SelectToken("details.eventOwnerTeamId").ToString();
            }
            else if (typeCode == "509")  // Penalty event
            {
                xCoordinate = json.SelectToken("details.xCoord").ToString();
                yCoordinate = json.SelectToken("details.yCoord").ToString();
                zoneCode = json.SelectToken("details.zoneCode").ToString();
                detailTypeCode = json.SelectToken("details.typeCode").ToString();
                descKey = json.SelectToken("details.descKey").ToString();
                duration = json.SelectToken("details.duration").ToString();
                if(json.SelectToken("details.committedByPlayerId") != null)
                    committedByPlayerId = json.SelectToken("details.committedByPlayerId").ToString();
                if (json.SelectToken("details.drawnByPlayerId") != null)
                    drawnByPlayerId = json.SelectToken("details.drawnByPlayerId").ToString();
                eventOwnerTeamId = json.SelectToken("details.eventOwnerTeamId").ToString();
            }
            else if (typeCode == "516")  // Stoppage event
            {
                reason = json.SelectToken("details.reason").ToString();
            }
            else if (typeCode == "525")  // Takeaway event
            {
                xCoordinate = json.SelectToken("details.xCoord").ToString();
                yCoordinate = json.SelectToken("details.yCoord").ToString();
                zoneCode = json.SelectToken("details.zoneCode").ToString();
                takeawayPlayerId = json.SelectToken("details.playerId").ToString();
                eventOwnerTeamId = json.SelectToken("details.eventOwnerTeamId").ToString();
            }
            else if (typeCode == "535")  // Delayed-penalty event
            {
                eventOwnerTeamId = json.SelectToken("details.eventOwnerTeamId").ToString();
            }







        }

        //public GameEvent(JToken jsonGameEvents)
        //{
        //    JObject gameEventObject = jsonGameEvents.ToObject<JObject>();

        //    // Populate the raw JSON to a property
        //    gameEventJson = gameEventObject;

        //    // If the game event contains a list of players, parse through the players and insert them
        //    if (gameEventObject.ContainsKey("players"))
        //    {
        //        Player aPlayer;
        //        List<Player> thePlayers = new List<Player>();
        //        foreach (var item in gameEventObject["players"])
        //        {
        //            aPlayer = new Player(Convert.ToInt32(item.SelectToken("player.id")));
        //            thePlayers.Add(aPlayer);
        //        }
        //        players = thePlayers;
        //    }


        //    eventType = gameEventObject.SelectToken("result.event").ToString();
        //    eventCode = gameEventObject.SelectToken("result.eventCode").ToString();
        //    eventTypeID = gameEventObject.SelectToken("result.eventTypeId").ToString();
        //    eventDescription = gameEventObject.SelectToken("result.description").ToString();
        //    if (gameEventObject.ContainsKey("eventSecondaryType"))
        //    {
        //        eventSecondaryType = gameEventObject.SelectToken("result.eventSecondaryType").ToString();
        //    }
        //    eventIDx = gameEventObject.SelectToken("about.eventIdx").ToString();
        //    eventID = gameEventObject.SelectToken("about.eventId").ToString();
        //    period = gameEventObject.SelectToken("about.period").ToString();
        //    periodType = gameEventObject.SelectToken("about.periodType").ToString();
        //    ordinalPeriodNumber = gameEventObject.SelectToken("about.ordinalNum").ToString();
        //    periodTime = gameEventObject.SelectToken("about.periodTime").ToString();
        //    periodTimeRemaining = gameEventObject.SelectToken("about.periodTimeRemaining").ToString();

        //    //if (periodTimeRemaining == "")
        //    //{
        //        if (periodTime != "")
        //        {
        //            int periodTimeSeconds = Utilities.ConvertPeriodTimeToSeconds(periodTime);
        //            int remainingPeriodTimeSeconds = 1200 - periodTimeSeconds;

        //            periodTimeRemaining = Utilities.ConvertSecondsToPeriodTime(remainingPeriodTimeSeconds);
        //        }
        //        else
        //        {
        //            periodTimeRemaining = "00:00";
        //        }
        //    //}

        //    dateTimeStamp = gameEventObject.SelectToken("about.dateTime").ToString();
        //    goalsAway = gameEventObject.SelectToken("about.goals.away").ToString();
        //    goalsHome = gameEventObject.SelectToken("about.goals.home").ToString();
        //    JObject coordinateEvent = gameEventObject["coordinates"].ToObject<JObject>();
        //    if (coordinateEvent.ContainsKey("x"))
        //    {
        //        xCoordinate = gameEventObject.SelectToken("coordinates.x").ToString();
        //    }

        //    if (coordinateEvent.ContainsKey("y"))
        //    {
        //        yCoordinate = gameEventObject.SelectToken("coordinates.y").ToString();
        //    }

        //    if (gameEventObject.ContainsKey("team"))
        //    {
        //        //Team theTeam = new Team(gameEventObject.SelectToken("team.id").ToString());
        //        //team = theTeam;
        //    }



        //}
    }
}
