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
        public static string teams = "https://statsapi.web.nhl.com/api/v1/teams/";
        public static string venues = "http://statsapi.web.nhl.com/api/v1/venues/";
        public static string specificplayer = "http://statsapi.web.nhl.com/api/v1/people/";
        public static string specificGameContent = "https://statsapi.web.nhl.com/api/v1/game/###/content";
        public static string conferences = "https://statsapi.web.nhl.com/api/v1/conferences/";
        public static string divisions = "https://statsapi.web.nhl.com/api/v1/divisions/";
    }
}

