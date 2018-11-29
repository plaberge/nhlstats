using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    class Game
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
        public Game(string gameID)
        {

        }
    }
}
