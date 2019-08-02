using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    class TeamRecord : Team
    {
        public string season { get; set; }
        public int DivisionRank { get; set; }
        public int DivisionL10Rank { get; set; }
        public int DivisionHomeRank { get; set; }
        public int DivisionRoadRank { get; set; }
        public int ConferenceRank { get; set; }
        public int ConferenceL10Rank { get; set; }
        public int ConferenceHomeRank { get; set; }
        public int ConferenceRoadRank { get; set; }
        public int LeagueRank { get; set; }
        public int LeagueL10Rank { get; set; }
        public int LeagueHomeRank { get; set; }
        public int LeagueRoadRank { get; set; }
        public string clinchIndicator { get; set; }

        public TeamRecord() : base()
        {
            
        }
    }
}
