# nhlstats
A C# .NET Standard Library for interfacing with the open NHL Stats API

Current APIs that this library exposes as C# API endpoints include:

## Schedule

### Class Properties
VARIABLE NAME | VARIABLE TYPE | Description | Example 
--------------|---------------|-------------|--------
totalItems|string|The number of total items in the Schedule for a specific date.|2
totalEvents|string|The number of total events in the Schedule for a specific date.|0
totalGames|string|The number of total games in the Schedule for a specific date.|12
totalMatches|string|The number of total matches in the Schedule for a specific date.|1
season|string|The season that the Schedule gameDate resides in.|20192020
scheduleDate|string|The date for the data that theSchedule class is holding.|2019-06-10
games|List < Game >|A list of Game objects (see below for definition) that reside in the schedule for a given date.|(see definition for Game class)
scheduleJson|JObject|The JSON output returned by the NHL API for the API call.|(JSON Data)

### Class Methods
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Schedule() | NONE | Creates a Schedule object for today's date
Schedule(string gameDate) | gameDate (string) -> FORMAT:  YYYY-MM-DD | Creates a schedule object for date specified in gameDate
static List< string > GetListOfGameIDs(string gameDate) | gameDate (string) -> FORMAT:  YYYY-MM-DD | Static method that brings back a list of Game IDs for date specified in gameDate 





* Game
  * Game(string gameID):  Get game associated with key "gameID" 
  * Game(string gameID, int featureFlag):  Get game associated with key "gameID", "featurFlag" tells library to not fetch all data downstream
  *
