# nhlstats
A C# .NET Standard Library for interfacing with the open NHL Stats API

Current APIs that this library exposes as C# API endpoints include:
* Schedule
METHOD NAME | Input Variable(s) | Output
------------|-------------------|-------
Schedule() | <NONE> | Creates a Schedule object for today's date
Schedule(string gameDate) | gameDate (string) -> FORMAT:  YYYY-MM-DD | Creates a schedule object for date specified in gameDate

* Game
  * Game(string gameID):  Get game associated with key "gameID" 
  * Game(string gameID, int featureFlag):  Get game associated with key "gameID", "featurFlag" tells library to not fetch all data downstream
  *
