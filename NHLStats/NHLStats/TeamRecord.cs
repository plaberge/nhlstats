using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class TeamRecord : Team
    {
        public string season { get; set; }
        public int DivisionL10Rank { get; set; }              // JSON
        public int DivisionHomeRank { get; set; }              // JSON
        public int DivisionRoadRank { get; set; }              // JSON
        public int ConferenceL10Rank { get; set; }              // JSON
        public int ConferenceHomeRank { get; set; }              // JSON
        public int ConferenceRoadRank { get; set; }              // JSON
        public int LeagueL10Rank { get; set; }              // JSON
        public int LeagueHomeRank { get; set; }              // JSON
        public int LeagueRoadRank { get; set; }              // JSON
        public string clinchIndicator { get; set; }

        public TeamRecord() : base()
        {
            
        }
    }
}
