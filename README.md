# nhlstats
A C# .NET Standard Library for interfacing with the open NHL Stats API.

Current APIs that this library exposes as C# API endpoints include:

## BoxScore

### BoxScore Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
awayTeamId |string|The team ID of the away team in the game.|23
homeTeamId|string|The team ID of the home team in the game.|5
homeTeamStats|TeamGameStats|The object holding the team-related game stats for the home team.|(See definition for TeamGameStats class)
awayTeamStats|TeamGameStats|The object holding the team-related game stats for the away team.|(See definition for TeamGameStats class)
officials|List < Person >|A list of Person objects holding the details of the game officials.|(See definition for Person class)
boxScoreJson|JObject|JObject|The JSON output returned by the NHL API for the API call.|(JSON Data)

### BoxScore Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
BoxScore(string homeTeamId, string awayTeamId, JObject json) | homeTeamId (string); awayTeamId (string); json (JObject) -> holds the JSON sub-document from the Game JSON document holding box score info) | Creates a BoxScore object for the game within JSON document.
BoxScore(string homeTeamId, string awayTeamId, JObject json, int featureFlag) | homeTeamId (string); awayTeamId (string); json (JObject); featureFlag (int)|DEPRECATED; NOT BEING MAINTAINED.


## Conference

### Conference Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
conferenceId | int | The ID for a Conference. | 5
conferenceName | string | The name of the Conference. | Western
shortName | string | The short name of the Conference. | West
abbreviation | string | The abbreviation of the Conference. | W
active | string | Whether the Division is active or not. | True
conferenceJSON | JObject | The JSON output returned by the NHL API for the API call.|(JSON Data)

### Conference Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Conference() | NONE | Creates an empty Conference object.
Conference(int theConferenceId) | theConferenceId (int) | Returns a Conference object populated with data for the Conference with ID theConferenceId.
static List < Conference > GetAllConferences() | NONE | Returns a List < Conference > with all Conferences.


## DataAccessLayer

### DataAccessLayer Class Properties
(No properties for this class)

### DataAccessLayer Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
static ExecuteAPICall(string apiUrl) | apiUrl (string) | Executes the call to the NHL API using the API endpoint defined in apiUrl and returns the JSON document outputted by the API as a JObject.


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

## GameContent

### GameContent Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
gameID|string|The unique identifier for the Game. |2018020245
previewTitle|string|The preview summary title for the Game.|Toronto Maple Leafs Boston Bruins game preview
previewHeadline|string|The headline for the preview of the Game.|Maple Leafs at Bruins preview
previewSubHead|string|The sub-headline for the preview of the Game.|Toronto can tie its record for longest road win streak to begin season; Halak to start for Boston
previewSeoDescription|string|The search engine-optimized description for the Game.|Toronto can tie its record for longest road win streak to begin season; Halak to start for Boston
previewUrl|string|The URL for the preview article.|http://www.nhl.com/news/toronto-maple-leafs-boston-bruins-game-preview/c-301798978?game_pk=2018020245
previewMediaPhoto2568x1444|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/2568x1444/cut.jpg
previewMediaPhoto2208x1242|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/2208x1242/cut.jpg
previewMediaPhoto2048x1152|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/2048x1152/cut.jpg
previewMediaPhoto1536x864|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/1536x864/cut.jpg
previewMediaPhoto1284x722|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/1284x722/cut.jpg
previewMediaPhoto1136x640|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/1136x640/cut.jpg
previewMediaPhoto1024x576|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/1024x576/cut.jpg
previewMediaPhoto960x540|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/960x540/cut.jpg
previewMediaPhoto768x432|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/768x432/cut.jpg
previewMediaPhoto640x360|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/640x360/cut.jpg
previewMediaPhoto568x320|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/568x320/cut.jpg
previewMediaPhoto372x210|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/372x210/cut.jpg
previewMediaPhoto320x180|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/320x180/cut.jpg
previewMediaPhoto248x140|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/248x140/cut.jpg
previewMediaPhoto124x70|string|The URL for the preview photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301799740/124x70/cut.jpg
gameContentJson|JObject|The JSON output returned by the NHL API for the API call.|(JSON Data)
recapTitle|string|The title of the recap article for the game.|Toronto Maple Leafs Boston Bruins Game Recap
recapHeadline|string|The headline of the recap article for the game.|Pastrnak gets hat trick, Bruins send Maple Leafs to first road loss
recapSubHead|string|The sub-headline of the recap article for the game.|Forward has third four-point game of season; Halak makes 40 saves
recapSeoDescription|string|The search engine-optimized description of the article for the game.|BOSTON -- David Pastrnak scored his third NHL hat trick to help the Boston Bruins hand the Toronto Maple Leafs their first road loss of the season, 5-1 at TD Garden on Saturday.
recapUrl|string|The URL to the recap article for the game.|http://www.nhl.com/news/toronto-maple-leafs-boston-bruins-game-recap/c-301799398?game_pk=2018020245
recapMediaPhoto2568x1444|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/2568x1444/cut.jpg
recapMediaPhoto2208x1242|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/2208x1242/cut.jpg
recapMediaPhoto2048x1152|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/2048x1152/cut.jpg
recapMediaPhoto1704x960|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/1704x960/cut.jpg
recapMediaPhoto1536x864|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/1536x864/cut.jpg
recapMediaPhoto1284x722|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/1284x722/cut.jpg
recapMediaPhoto1136x640|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/1136x640/cut.jpg
recapMediaPhoto1024x576|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/1024x576/cut.jpg
recapMediaPhoto960x540|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/960x540/cut.jpg
recapMediaPhoto768x432|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/768x432/cut.jpg
recapMediaPhoto640x360|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/640x360/cut.jpg
recapMediaPhoto568x320|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/568x320/cut.jpg
recapMediaPhoto372x210|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/372x210/cut.jpg
recapMediaPhoto320x180|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/320x180/cut.jpg
recapMediaPhoto248x140|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/248x140/cut.jpg
recapMediaPhoto124x70|string|The URL for the recap photo of the resolution defined in the name of this property.|https://nhl.bamcontent.com/images/photos/301820386/124x70/cut.jpg
recapPlaybackFLASH_192K_320X180|string|The URL to the recap video of the resolution defined in the name of this property.  Currently not being populated.|N/A
recapPlaybackFLASH_450K_400X224|string|The URL to the recap video of the resolution defined in the name of this property.  Currently not being populated.|N/A
recapPlaybackFLASH_192K_320X180|string|The URL to the recap video of the resolution defined in the name of this property.  Currently not being populated.|N/A
recapPlaybackFLASH_1200K_640X360|string|The URL to the recap video of the resolution defined in the name of this property.  Currently not being populated.|N/A
recapPlaybackFLASH_1800K_960X540|string|The URL to the recap video of the resolution defined in the name of this property.  Currently not being populated.|N/A

### GameContent Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
GameContent() | NONE | Creates an empty GameContent object.
GameContent(string theGameID)|theGameID (string)|Populates a GameContent object for the Game denoted by ID theGameID.


## GameEvent

### GameEvent Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
correspondingGameID |string|The Game ID of the game that the GameEvent occurred.|2018020251
eventType|string|The type of the Event.|Giveaway
eventCode|string|The event code of the GameEvent.|CBJ15
eventTypeID|string|The ID of the event type for the GameEvent.|GIVEAWAY
eventDescription|string|The description of the GameEvent.|Giveaway by Vladislav Namestnikov
eventSecondaryType|string|The secondary type of the GameEvent.  Appears not to be used at present.|N/A
eventIDx|string|The eventIDx of the GameEvent.  I am not sure what this corresponds to.|21
eventID|string|The event ID for the GameEvent. Please note that this is not unique across all games.|15
period|string|The period number that the GameEvent occurred in.|1
periodType|string|The type of period the GameEvent occurred in.|REGULAR
ordinalPeriodNumber|string|The ordinal number of the period that the GameEvent occurred in.|1st
periodTime|string|The time in the period that the GameEvent occurred at.|3:15
periodTimeRemaining|string|The time remaining in the period that the GameEvent occurred at.|16:45
dateTimeStamp|string|The datetime stamp for the GameEvent when it occurred. I believe this time stamp is in the Greenwich Mean Time timezone.|2018-11-11 00:13:46.000
goalsAway|string|The number of goals for the away team at the time of the GameEvent.|0
goalsHome|string|The number of goals for the away team at the time of the GameEvent.|0
xCoordinate|string|The x-coordinate on the ice that the GameEvent occurred.  Range is between -100 and 100 (ends of the boards)|55.00
yCoordinate|string|The y-coordinate on the ice that the GameEvent occurred.  Range is between -100 and 100 (sides of the boards)|-40.00
team|Team|The Team object holding the data on which team initiated the GameEvent.|(see definition for Team class)
players|List < Player >|The list of Players involved in the GameEvent.|(see definition for Player class)
gameEventJson|JObject|The JSON output returned by the NHL API for the API call.|(JSON Data)

### GameEvent Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
GameEvent() | NONE | Creates an empty GameEvent object.
GameEvent(JToken jsonGameEvents)|jsonGameEvents (JToken)| Populates a GameEvent object with the data from the JSON JToken.  NOTE:  This JToken is taken from the JSON within the Game JSON document.


## Period

### Period Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
gameID |string|The Game ID of the game that the Period occurred.|2018020251
periodType | string | The type of the Period. | OVERTIME
periodTimeStart | string | The time (Greenwich Mean Time timezone) of the start of the Period. | 02:42:38.0000000
periodTimeEnd | string | The time (Greenwich Mean Time timezone) of the end of the Period. | 02:48:19.0000000
periodNum | string | The number of the Period. | 4
periodNumOrd | string | The ordinal number of the Period. | OT
homeTeamId | string | The ID of the home team. | 29
homeGoals | string | The number of goals scored in this Period by the home team. | 0
homeShotsOnGoal | string | The number of shots on goal in this Period by the home team. | 4
homeRinkSide | string | The side of the rink that the home team defended in this Period. | right
awayTeamId | string | The ID of the away team. | 3
awayGoals | string | The number of goals scored in this Period by the away team. | 0
awayShotsOnGoal | string | The number of shots on goal in this Period by the away team. | 1
awayRinkSide | string | The side of the rink that the away team defended in this Period. | left
periodJson|JObject|The JSON output returned by the NHL API for the API call.|(JSON Data)

### Period Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Period() | NONE | Creates an empty Period object.
Period(string gameID, JObject json, string homeTeamID, string awayTeamID) | gameID (string); json (JObject); homeTeamID (string); awayTeamID (string) -> note that the json parameter is a subset of the JSON created by the Game API.|A populated Period object.

## Person

### Person Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
personId |string|Unique identifier of the person.|325b6f65-abdc-470d-9f69-cdf84882ccc9
fullName|string|The first and last name of the person.|Derek Amell
role|string|The role of the person (e.g.:  Official, Head Coach, etc.)|Official
subRole|string|The sub-role of the person.|Linesman
personJson|JObject|The JSON output returned by the NHL API for the API call.|(JSON Data)

### Person Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Person(JObject json) | json (JObject) | Creates a Person object populated with data from the JSON document.



## Player

### Player Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
playerID | int | The ID for the Player. | 8478402
firstName | string | The Player's first name. | Connor
lastName | string | The Player's last name. | McDavid
primaryNumber | int | The Player's primary jersey number. | 97
birthDate | string | The Player's birth date. | 1997-01-13
currentAge | int | The Player's current age in years. | 22
birthCity | string | The city the Player was born in. | Richmond Hill
birthStateProvince | string | The state or province the Player was born in. | Ontario
birthCountry | string | The country the Player was born in. | Canada
nationality | string | The nationality of the Player. | CAN
height | int  | The height of the player in inches. | 73
weight | int | The weight of the player in pounds. | 193
active | string | Whether the player is currently active or not. | True
alternateCaptain | string | Whether the player is an Alternate Captain on the team or not. | False
captain | string | Whether the player is a Captain on the team or not. | True
rookie | string | Whether or not the player is a rookie. | False
shootsCatches | string | The side for which the Player shoots and catches. | L
rosterStatus | string | The roster status of the Player. | Y
currentTeamID | string | ID of the team that the Player currently plays for. | 22
primaryPositionCode | string | Code for the position that the Player primarily plays. | C
primaryPositionName | string | Name of the position that the Player primarily plays. | Center
primaryPositionType | string | Type of position that the Player primarily plays. | Forward
primaryPositionAbbr | string | Abbreviation of position that the Player primarily plays. | C
playerJson | JObject | The JSON output returned by the NHL API for the API call.|(JSON Data)

### Player Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Player() | NONE | Creates an empty Player object.
Player(int thePlayerID) | thePlayerID (int) | Populates a new Player object for the player with an ID of thePlayerID.


## PlayerGameStats

### PlayerGameStats Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
position|string|The position the player plays.|C
timeOnIce|string|The amount of time (in seconds) the player was on the ice for the game.|996
assists|string|The number of assists the player had in the game.|3
goals|string|The number of goals the player had in the game.|0
shots|string|The number of shots on net the player had in the game.|2
hits|string|The number of hits the player gave in the game.|1
powerPlayGoals|string|The number of power play goals the player scored in the game.|0
powerPlayAssists|string|The number of power play assists the player delivered in the game.|1
penaltyMinutes|string|The number of penalty minutes the player had in the game.|2
faceOffWins|string|The number of face offs won by the player in the game.|3
faceoffWinPercentage|string|The percentage of face offs won by the player in the game.|100.00
faceoffsTaken|string|The number of attempted face offs the player engaged in during the game.|3
takeaways|string|The number of takeaways the player completed in the game.|2
giveaways|string|The number of giveaways the player had in the game.|1
shorthandedGoals|string|The number of shorthanded goals the player had in the game.|0
shorthandedAssists|string|The number of shorthanded assists the player had in the game.|0
blocked|string|The number of shots the player blocked in the game.|1
plusMinus|string|The plus/minus rating for the player at the end of the game.|-2
evenTimeOnIce|string|The number of seconds the player spent on the ice at even strength|714
powerPlayTimeOnIce|string|The number of seconds the player spent on the ice during all power plays.|178
shorthandedTimeOnIce|string|The number of seconds the player spent on the ice shorthanded.|104
goalieTimeOnIce|string|The number of seconds the player played as a goalie on the ice in the game.|3896
shotsFaced|string|The number of shots the player face as a goalie.|21
shotsSaved|string|The number of saves by the player as a goalie.|19
powerPlayShotsSaved|string|The number of saves made by the player as a goalie while on a power play.|2
shorthandedShotsSaved|string|The number of saves made by the player as a goalie while shorthanded.|5
evenSaved|string|The number of saves made by the player as a goalie on even strength|12
shorthandedShotsAgainst|string|The number of shots faced by the player as a goalie while shorthanded.|5
evenShotsAgainst|string|The number of shots faced by the player as a goalie while at even strength.|14
powerPlayShotsAgainst|string|The number of shots faced by the player as a goalie while on the power play.|2
decision|string|Whether the player won, lost or drew as a goalie in the game.|W
savePercentage|string|The save percentage throughout the game for the player as a goalie.|0.9047
evenSavePercentage|string|The save percentage at even strength throughout the game for the player as a goalie.|0.8571
powerPlaySavePercentage|string|The save percentage on power plays throughout the game for the player as a goalie.|100.00
shorthandedSavePercentage|string|The save percentage while shorthanded throughout the game for the player as a goalie.|100.00
playerGameStatsJson|JObject|The JSON output returned by the NHL API for the API call.|(JSON Data)


### PlayerGameStats Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
PlayerGameStats(int playerID, JToken json) | playerID (int); json (JToken) -> JSON sub-document passed in by the TeamGameStats object. | Populates the PlayerGameStats object with the player's stats from a game.


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


## TeamGameStats

### TeamGameStats Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
totalGoals | string | The total number of goals for the team in this game. | 3
totalPIM | string | The total Penalties In Minutes for the team in this game. | 8
totalShots | string | The total number of shots on net for the team in this game. | 38
powerPlayPercentage | string | The success rate in percentage of the team's powerplay in this game.| 0.667
powerPlayGoals | string | The number of goals scored on the powerplay for the team. | 2
powerPlayOpportunities | string | The number of powerplay opportunities the team had in the game. | 3
faceOffWinPercentage | string | The percentage of face offs won by the team in the game. | 0.500
blockedShots | string | The number of shots the team blocked in the game. | 7
takeaways | string | The number of takeaways the team completed in the game. | 21
giveaways | string | The number of giveaways the team lost in the game. | 19
hits | string | The number of hits the team delivered in the game. | 53
coach | Person | An object holding the information on the team's head coach. | (See definition for Person class)
teamPlayers | PlayerGameStats | An object holding the information on the game stats for each player on the team in the game. | (See definition for PlayerGameStats class)
teamGameStatsJson | JObject | The JSON output returned by the NHL API for the API call.|(JSON Data)

### TeamGameStats Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
TeamGameStats(JObject json) | json (JObject) -> A sub-document of the JSON document used with the BoxScore JSON document. | Populates a BoxScore object with one team's team-based stats for the game.
TeamGameStats(JObject json, int featureFlag) | json (JObject) ; featureFlag (int) | DEPRECATED; NOT BEING MAINTAINED.



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

