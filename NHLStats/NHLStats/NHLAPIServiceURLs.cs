using static System.Net.WebRequestMethods;

namespace NHLStats
{
    public static class NHLAPIServiceURLs
    {
        //------------------------------------
        // LEAGUE-focused strings
        public static string leagueStandings = "https://statsapi.web.nhl.com/api/v1/standings/byLeague";
        public static string leagueStandings_season_extension = "?season=";
        public static string leagueStandings_date_extension = "?date=";  // (Date format is "YYYY-MM-DD"
                                                                         //------------------------------------




        //------------------------------------
        // GAME-focused string
        //public static string todaysGames = "https://statsapi.web.nhl.com/api/v1/schedule";
        public static string todaysGames = "https://api-web.nhle.com/v1/schedule/";  // NEW API:  Append the date of the schedule in YYYY-MM-DD format to the end of this string
        //public static string specificGame = "https://statsapi.web.nhl.com/api/v1/game/###/feed/live";  //Example for ###:  2018020323
        public static string specificGame = "https://api-web.nhle.com/v1/gamecenter/###/boxscore";  //NEW API:  Example for ###:  2018020323.  Gets BoxScore data
        //public static string specificGameContent = "https://statsapi.web.nhl.com/api/v1/game/###/content";
        public static string gameStory = "https://api-web.nhle.com/v1/wsc/game-story/###";  // Example for ###:  2018020323.  Get the team box score data for a game.  NEW API ENDPOINT
        public static string gameBoxScore = "https://api-web.nhle.com/v1/gamecenter/###/boxscore"; // Example for ###:  2023020204.  Get the player boxscore data for a game.  NEW API ENDPOINT.
        public static string shiftChart = "https://api.nhle.com/stats/rest/en/shiftcharts?cayenneExp=gameId=###";  // Example for ###:  2018020323.  Get the shift chart data for a game.  NEW API ENDPOINT
        public static string gameEvent = "https://api-web.nhle.com/v1/gamecenter/###/play-by-play";  // Example for ###:  2018020323.  Get the play-by-play game event data for a game.  NEW API ENDPOINT

        // Extensions for game-focused strings

        //------------------------------------



        //------------------------------------
        // TEAM-focused strings
        public static string teams = "https://statsapi.web.nhl.com/api/v1/teams/";

        // Extensions for team-focused strings
        public static string teams_roster_extension = "?expand=team.roster"; // Team Roster for a given team (extension).  Example:   https://statsapi.web.nhl.com/api/v1/teams/10?expand=team.roster
        public static string teams_nextgame_extension = "?expand=team.schedule.next"; // Team next game (extension).  Example:  https://statsapi.web.nhl.com/api/v1/teams/10?expand=team.schedule.next
        public static string teamsStandings = "https://statsapi.web.nhl.com/api/v1/standings/byLeague/"; // Get standings by league
        //------------------------------------



        //------------------------------------
        // MISCELLANEOUS-focused strings
        public static string venues = "http://statsapi.web.nhl.com/api/v1/venues/";
        public static string conferences = "https://statsapi.web.nhl.com/api/v1/conferences/";
        public static string divisions = "https://statsapi.web.nhl.com/api/v1/divisions/";
        //------------------------------------



        //------------------------------------
        // PEOPLE-focused strings
        // public static string specificplayer = "http://statsapi.web.nhl.com/api/v1/people/";  // OLD API
        public static string specificPlayer =  "https://api-web.nhle.com/v1/player/###/landing"; //Example for ###:  8479968  NEW API ENDPOINT for player information


        // Extensions for people-focused string
        public static string specificplayer_currentyearstats_extension = "stats?stats=gameLog"; //Player stats for current year (extension).  Example:  http://statsapi.web.nhl.com/api/v1/people/8475718/stats?stats=gameLog
        public static string specificplayer_specificseasonstats_extension = "stats?stats=gameLog&season="; // Player stats for a specific season (extension).  Example: http://statsapi.web.nhl.com/api/v1/people/8475718/stats?stats=gameLog&season=20172018 
        public static string specificplayer_yearbyyearstats_extension = "stats?expand=person.stats&stats=yearByYear";  // Player stats year by year (extension).  Example:  http://statsapi.web.nhl.com/api/v1/people/8475718/stats?expand=person.stats&stats=yearByYear

        // Player image URLs
        public static string playerImage = "https://nhl.bamcontent.com/images/headshots/current/168x168/###.jpg";  // Image URL for for player 8471675 (Sidney Crosby): https://nhl.bamcontent.com/images/headshots/current/168x168/8471675@2x.jpg
        public static string playerImage2x = "https://nhl.bamcontent.com/images/headshots/current/168x168/###@2x.jpg";  // Image URL for 2x size for player 8471675 (Sidney Crosby): https://nhl.bamcontent.com/images/headshots/current/168x168/8471675@2x.jpg
        public static string playerImage3x = "https://nhl.bamcontent.com/images/headshots/current/168x168/###@3x.jpg"; // Image URL for 3x size for player 8471675 (Sidney Crosby): https://nhl.bamcontent.com/images/headshots/current/168x168/8471675@2x.jpg

        //------------------------------------


        //------------------------------------
        // SCHEDULE-focused strings
        public static string schedule = "https://statsapi.web.nhl.com/api/v1/schedule";  // Shows current date's games

        // Extensions for schedule-focused strings
        public static string schedule_betweendates_extension = "?teamId=##&startDate=@@@@@@@@@@&endDate=^^^^^^^^^^"; // Get schedule for a team between two dates (extension).  ## is TeamID, @@@@@@@@@@ is start date, ^^^^^^^^^^ is end date.  Example:  https://statsapi.web.nhl.com/api/v1/schedule?teamId=30&startDate=2018-01-02&endDate=2018-01-02
        public static string schedule_tickets_extension = "?expand=schedule.ticket"; // Get ticket info for games (extension).  Example:  https://statsapi.web.nhl.com/api/v1/schedule?expand=schedule.ticket
        public static string schedule_season_team = "?season=########&teamId=@@"; // Get a specified team's schedule for a specified season.  Example:  https://statsapi.web.nhl.com/api/v1/schedule?season=20212022&teamId=12

        //------------------------------------


        public static string GetPlayerPictureURL(string playerID, int size)
        {
            string theURL;

            if (size == 2)
            {
                theURL = playerImage2x.Replace("###", playerID);
            }
            else if (size == 3)
            {
                theURL = playerImage3x.Replace("###", playerID);
            }
            else
            {
                theURL = playerImage.Replace("###", playerID);
            }

            return theURL;
        }


    }
}

