# nhlstats
A C# .NET Standard Library for interfacing with the open NHL Stats API.

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

## Team

### Team Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
NHLTeamID | int | The Team ID for a team. | 12
TeamName | string | The name of the team. | Hurricanes
TeamCity | string | The city/geographical area that the team resides in. | Carolina
TeamAbbreviation | string | The abbreviation code for the team. | CAR
TeamVenue | Venue | The Venue object that contains data for the team's home venue. | (see definition for Venue class)
FirstYearOfPlay | string | The inaugural year for the team entering the NHL. | 1979
teamDivision | Divsion | The Division object holding info on the division the team resides in. | (see definition for Division class)
teamConference | Conference | The Conference object holding info on the conference the team resides in. | (see definition for Conference class)
webSite | string | The website URL address for the team's homepage. | http://www.carolinahurricanes.com/
Wins | int | The team's number of wins in the current season. | 46
Losses | int | The team's number of losses in the current season. | 31
OvertimeLosses | int | The team's number of losses in overtime. | 5
GoalsScored | int | The team's current number of goals scored this season. | 132
GoalsAgainst | int | The team's current number of goals against this season. | 128
Points | int | The current number of points the team has this season. | 97
DivisionRank | int | The current rank of the team within its Division this season. | 2
ConferenceRank | int | The current rank of the team within its Conference this season. | 6
LeagueRank | int | The current rank of the team within the entire league this season. | 11
WildcardRank | int | The current Wildcard rank of the team within the conference this season.  | 2
ROW | int | The current number of wins of the team in regulation and overtime combined. | 42
GamesPlayed | int | The number of games the team has played so far in the current season. | 81
StreakType | string | The type of streak that the team is currently on. | L
StreakNumber | int | The number of games for the team's current streak. | 3
StreakCode | string | The coded streak description for the team's current streak. | L3
LastUpdated | string | The datetime that the team data was last updated on by the NHL API. | 2019-05-11 4:39:48AM
teamJson | JObject | The JSON output returned by the NHL API for the API call.|(JSON Data)

### Team Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Team() | NONE | Creates an empty Team object.
Team(string teamID) | teamID (string) | Creates a Team object populated with data for the team specified by teamID.
Team(string teamID, int featureFlag) | teamID (string) ; featureFlag (int) | DEPRECATED; NOT BEING MAINTAINED.
static List < Team > GetAllTeams() | NONE | Static method that returns a list of all teams within the league; output is of type List < Team >.

## Venue

### Venue Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
venueID | string | The Venue ID for a venue. | 5034
venueName | string | The name of the venue. | PPG Paints Arena
venueJSON | JObject | The JSON output returned by the NHL API for the API call.|(JSON Data)

### Venue Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Venue() | NONE | Creates an empty Venue object.
Venue(string theVenueID) | string theVenueID | A Venue object populated with the data for a venue with a Venue ID of theVenueID.

## Division

### Division Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
divisionId | int | The ID for a Division. | 15
divisionName | string | The name of the Division. | Pacific
shortName | string | The short name of the Division. | PAC
abbreviation | string | The abbreviation of the Division. | P
conference | Conference | An object holding the Conference data for the Division. | (see definition for Conference class)
active | string | Whether the Division is active or not. | True
divisionJSON | JObject | The JSON output returned by the NHL API for the API call.|(JSON Data)

### Division Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Division() | NONE | Creates an empty Division object.
Division(int theDivisionId) | theDivisionId (int) | Returns a Division object populated with data for the Division with ID theDivisionId.
static List < Division > GetAllDivisions() | NONE | Returns a List < Division > with all Divisions.
