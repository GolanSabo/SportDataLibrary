using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SoccerDataLibrary.Models;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Utils;

namespace SoccerDataLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            ISoccerDataService s = SoccerDataFactory.GetSoccerDataService(WebServiceName.FootBallDataService);
            //Dictionary<String,int> leagueList = SecondaryLeaguesDictionaryCreator.GetLeagueList();
            //foreach (String key in leagueList.Keys)
            //    Console.WriteLine(key + "\t" + leagueList[key]);
            //Dictionary<String, int> leagues = s.GetSecondaryLeagues();
            //League e = s.GetLeague(leagues["Germany2"]);
            //Dictionary<String, Team> te = s.GetLeague(LeagueNameId.SPAIN).GetTeamByName("FC");
            //foreach(String key in te.Keys)
            //{
            //    Console.WriteLine(te[key].GetPlayerByName("Messi"));
            //}
            //League r = s.GetLeague(LeagueNameId.GERMANY);
            //Console.WriteLine(s.GetLeagueTable(r).ToString());
            League league=s.GetLeague(LeagueNameId.FRANCE);
            Dictionary<String,Team>paris= s.GetTeamByName(league, "Paris");
            Dictionary<String, int> secLeague = s.GetSecondaryLeagues();
            try
            {
                int x=secLeague["Germany2"];
                Console.WriteLine(x);
            }
            catch(KeyNotFoundException)
            {
                Console.WriteLine("Yaniv Hagever");
            }
        }
    }
}
