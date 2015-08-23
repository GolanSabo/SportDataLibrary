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
            //ISoccerDataService s = SoccerDataFactory.GetSoccerDataService(WebServiceName.FootBallDataService);
            //Console.WriteLine(s.GetLeague(LeagueNameId.ENGLAND).GetTeamByName("Manchester United FC"));
            //Console.WriteLine(s.GetLeague(LeagueNameId.ENGLAND).GetTeamByName("Manchester U").GetPlayerByName("Rooney"));
            //Console.WriteLine(s.GetLeague(LeagueNameId.ENGLAND).GetTeamByName("Manchester United FC").GetPlayerByJerseyNumber(7));

            LeaguesEnumDictionaryCreator led = new LeaguesEnumDictionaryCreator();
            Dictionary<String,int> leagueList = led.GetLeagueList();
            foreach(String key in leagueList.Keys)
                Console.WriteLine(key + "\t" + leagueList[key]);
        }
    }
}
