using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class Team
    {
        public int NHLTeamID { get; set; }
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int OvertimeLosses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsAgainst { get; set; }
        public int Points { get; set; }
        public int DivisionRank { get; set; }
        public int ConferenceRank { get; set; }
        public int LeagueRank { get; set; }
        public int WildcardRank { get; set; }
        public int ROW { get; set; }
        public int GamesPlayed { get; set; }
        public string StreakType { get; set; }
        public int StreakNumber { get; set; }
        public string StreakCode { get; set; }
        public string LastUpdated { get; set; }

        public Team()
        {

        }
    }
}
