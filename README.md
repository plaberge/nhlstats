# nhlstats
A C# .NET Standard Library for interfacing with the open NHL Stats API

Current APIs that this library exposes as C# API endpoints include:
* Schedule
  * Schedule():  Get a list of today's games
  * Schedule(string gameDate):  Get a list of games from gameDate (format:  "YYYY-MM-DD")
  * Schedule(string gameDate, int featureFlag):  Get a list of games from gameDate (format:  "YYYY-MM-DD"), "featurFlag" tells library to not fetch all data downstream
* Game
  * Game(string gameID):  Get game associated with key "gameID" 
  * Game(string gameID, int featureFlag):  Get game associated with key "gameID", "featurFlag" tells library to not fetch all data downstream
  *
