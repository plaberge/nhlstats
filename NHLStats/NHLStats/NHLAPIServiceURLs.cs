using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public static class NHLAPIServiceURLs
    {
        public static string leagueStandings = "https://statsapi.web.nhl.com/api/v1/standings/byLeague";
        public static string todaysGames = "https://statsapi.web.nhl.com/api/v1/schedule";
        public static string specificGame = "https://statsapi.web.nhl.com/api/v1/game/###/feed/live";
    }
}

