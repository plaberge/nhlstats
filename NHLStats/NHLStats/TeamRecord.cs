using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NHLStats
{
    public class TeamRecord : Team
    {
        public string season { get; set; }
        public string asOfGameDate { get; set; }
        public string clinchIndicator { get; set; }
        public string conferenceAbbrev { get; set; }
        public int conferenceHomeSequence { get; set; }
        public int conferenceL10Sequence { get; set; }
        public string conferenceName { get; set; }
        public int conferenceRoadSequence { get; set; }
        public int conferenceSequence { get; set; }
        public string divisionAbbrev { get; set; }
        public int divisionHomeSequence { get; set; }
        public int divisionL10Sequence { get; set; }
        public string divisionName { get; set; }
        public int divisionRoadSequence { get; set; }
        public int divisionSequence { get; set; }
        public int gameTypeId { get; set; }
        public int gamesPlayed { get; set; }
        public int goalDifferential { get; set; }
        public decimal goalDifferentialPctg { get; set; }
        public int goalsAgainst { get; set; }
        public int goalsFor { get; set; }
        public decimal goalsForPctg { get; set; }
        public int homeGamesPlayed { get; set; }
        public int homeGoalDifferential { get; set; }
        public int homeGoalsAgainst { get; set; }
        public int homeGoalsFor { get; set; }
        public int homeLosses { get; set; }
        public int homeOtLosses { get; set; }
        public int homePoints { get; set; }
        public int homeRegulationPlusOtWins { get; set; }
        public int homeRegulationWins { get; set; }
        public int homeTies { get; set; }
        public int homeWins { get; set; }
        public int L10GamesPlayed { get; set; }
        public int L10GoalDifferential { get; set; }
        public int L10GoalsAgainst { get; set; }
        public int L10GoalsFor { get; set; }
        public int L10Losses { get; set; }
        public int L10OtLosses { get; set; }
        public int L10Points { get; set; }
        public int L10RegulationPlusOtWins { get; set; }
        public int L10RegulationWins { get; set; }
        public int L10Ties { get; set; }
        public int L10Wins { get; set; }
        public int leagueHomeSequence { get; set; }
        public int leagueL10Sequence { get; set; }
        public int leagueRoadSequence { get; set; }
        public int leagueSequence { get; set; }
        public int losses { get; set; }
        public int otLosses { get;set; }
        public decimal pointPctg { get; set; }
        public int points { get; set; }
        public int regulationPlusdOtWinsPctg { get; set; }
        public int regulationPlusOtWins { get; set; }
        public decimal regulationWinPctg { get; set; }
        public int regulationWins { get; set; }
        public int roadGamesPlayed { get; set; }
        public int roadGoalDifferential { get; set; }
        public int roadGoalsAgainst { get; set; }
        public int roadGoalsFor { get; set; }
        public int roadLosses { get; set; }
        public int roadOtLosses { get; set; }
        public int roadPoints { get; set; }
        public int roadRegulationPlusOtWins { get; set; }
        public int roadRegulationWins { get; set; }
        public int roadTies { get; set; }
        public int roadWins { get; set; }
        public int shootoutLosses { get; set; }
        public int shootoutWins { get; set; }
        public string streakCode { get; set; }
        public int streakCount { get; set; }
        public int ties { get; set; }
        public int waiversSequence { get; set; }
        public int wildCardSequence { get; set; }
        public decimal winPctg { get; set; }
        public int wins { get; set; }


        public TeamRecord() : base()
        {


        }
    }
}
