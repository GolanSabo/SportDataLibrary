using System;
using System.Collections.Generic;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Models;
using SoccerDataLibrary.Utils;

namespace SoccerDataLibrary
{
    class FootBallDataService : ISoccerDataService
    {
        private static FootBallDataService instance = null;
        private FootBallDataService() { }
        public static FootBallDataService GetInstance()
        {
            if (instance == null)
            {
                instance = new FootBallDataService();
            }
            return instance;
        }

        public League GetLeague(LeagueNameId league)
        {
            return new League(league);
        }

        public League GetLeague(int league)
        {
            return new League(league);
        }

        public Dictionary<String, Team> GetLeagueTeams(League league)
        {
            return league.GetLeagueTeams();
        }

        public Dictionary<string, int> GetSecondaryLeagues()
        {
            return SecondaryLeaguesDictionaryCreator.GetLeagueList();
        }

        public Player GetPlayerByJerseyNumber(Team team, int number)
        {
            return team.GetPlayerByJerseyNumber(number);
        }

        public Player GetPlayerByName(Team team, string name)
        {
            return team.GetPlayerByName(name);
        }

        public Dictionary<String, Team> GetTeamByName(League league,String name)
        {
            return league.GetTeamByName(name);
        }

        public LeagueTable GetLeagueTable(League league)
        {
            return league.LeagueTable;
        }
    }
}
