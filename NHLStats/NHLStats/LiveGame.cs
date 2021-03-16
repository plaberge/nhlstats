using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class LiveGame
    {
        public string timeStamp { get; set; }
        public string pk { get; set; }
        public string season { get; set; }
        public string abstractGameState { get; set; }
        public string codedGameState { get; set; }
        public string detailedGameState { get; set; }
        public string statusCode { get; set; }
        public Team awayTeam { get; set; }
        public Team homeTeam { get; set; }
        public List<Player> awayTeamRoster { get; set; }
        public List<Player> homeTeamRoster { get; set; }
        public Venue gameVenue { get; set; }

    }
}
