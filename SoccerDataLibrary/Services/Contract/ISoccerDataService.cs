using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Models;

namespace SoccerDataLibrary
{
    interface ISoccerDataService {
        /// <summary>
        /// Get a League type of the popular leagues by sending an enum of type LeagueNameId
        /// </summary>
        /// <param name="league"></param>
        /// <returns>League</returns>
        League GetLeague(LeagueNameId league);
        /// <summary>
        /// Get a League type by the league's code ID.
        /// You can get the ID code by using GetOtherLeagues function.
        /// </summary>
        /// <param name="league"></param>
        /// <returns>League</returns>
        League GetLeague(int league);
        /// <summary>
        /// Get a list of all leagues available
        /// into a Dictionary
        /// </summary>
        /// <returns></returns>
        Dictionary<String, int> GetSecondaryLeagues();
        /// <summary>
        /// Get a Dictionary holding all teams in a specific league
        /// </summary>
        /// <param name="league"></param>
        /// <returns></returns>
        Dictionary<String,Team> GetLeagueTeams(League league);
        /// <summary>
        /// Get a Dictionary holding all teams that thier name contain
        /// the string you sent.
        /// </summary>
        /// <param name="league"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Dictionary<String,Team> GetTeamByName(League league, String name);
        /// <summary>
        /// Get a player that his name contains the string you sent.
        /// </summary>
        /// <param name="team"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Player GetPlayerByName(Team team,String name);
        /// <summary>
        /// Get a player by his shirt number.
        /// </summary>
        /// <param name="team"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        Player GetPlayerByJerseyNumber(Team team,int number);
        /// <summary>
        /// Get a league table of a specific league.
        /// </summary>
        /// <param name="league"></param>
        /// <returns></returns>
        LeagueTable GetLeagueTable(League league);
        /// <summary>
        /// prints all the players of a club
        /// </summary>
        /// <param name="team"></param>
        void PrintPlayers(Team team);

    }
}
