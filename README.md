# nhlstats
A C# .NET Standard Library for interfacing with the open NHL Stats API

Current APIs that this library exposes as C# API endpoints include:

## Schedule

### Schedule Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
totalItems|string|The number of total items in the Schedule for a specific date.|2
totalEvents|string|The number of total events in the Schedule for a specific date.|0
totalGames|string|The number of total games in the Schedule for a specific date.|12
totalMatches|string|The number of total matches in the Schedule for a specific date.|1
season|string|The season that the Schedule gameDate resides in.|20192020
scheduleDate|string|The date for the data that theSchedule class is holding.|2019-05-31
games|List < Game >|A list of Game objects (see below for definition) that reside in the schedule for a given date.|(see definition for Game class)
scheduleJson|JObject|The JSON output returned by the NHL API for the API call.|(JSON Data)

### Schedule Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Schedule() | NONE | Creates a Schedule object for today's date
Schedule(string gameDate) | gameDate (string) -> FORMAT:  YYYY-MM-DD | Creates a schedule object for date specified in gameDate
static List< string > GetListOfGameIDs(string gameDate) | gameDate (string) -> FORMAT:  YYYY-MM-DD | Static method that brings back a list of Game IDs for date specified in gameDate 


## Game

### Game Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
gameID|string|The Game ID returned by the NHL API call.|2018021169
gameLink|string|URL of the writeup for the game.|https://statsapi.web.nhl.com/api/v1/game/201502093
gameType|string|Denotes the type of game (R=Regular; A=All Star; PR=Preseason; P=Playoff)|PR
season|string|The season that the Game resides in.|20192020
gameDate|string|The date of the game in the format YYYY-MM-DD|2019-03-25
abstractGameState|string|The state of the game.|Final
codedGameState|string|A number denoting the Game state.|7
detailedState|string|Unknown|???
statusCode|string|Status Code for the game.  May have the same value as codedGameState.|7
homeTeam|Team|The Team object holding data on the Home Team.|(see definition for Team class)
awayTeam|Team|The Team object holding data on the Away Team.|(see definition for Team class)
gameVenue|Venue|The Venue object holding data on the game Venue.|(see definition for Venue class)
gameContent|GameContent|The GameContent object holding data for the game content.|(see definition for GameContent class)
gameParticipants|List < Player >|The List of players that participated in the game.|(see definition for Player class)
gameEvents|List < GameEvents >|The List of game events that occurred during the game.|(see definition for GameEvents class)
periodData|List < Period >|The List of period data for the game.|(see definition for Period class)
gameBoxScore|BoxScore|The data that holds the box score statistics for the game.|(see definition for BoxScore class)
gameJson|JObject|The JSON output returned by the NHL API for the API call.|(JSON Data)

### Game Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Game() | NONE | Creates an empty Game object.
Game(string theGameID) | theGameID (string) | Populates a Game object with data corresponding to the input Game ID.
Game(string theGameID, int featureFlag) | theGameID (string) ; featureFlag (int) | DEPRECATED; NOT BEING MAINTAINED.

