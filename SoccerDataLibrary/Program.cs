using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Models;

namespace SoccerDataLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //First of all we need to create our web Service
            ISoccerDataService sds = SoccerDataFactory.GetSoccerDataService(WebServiceName.FootBallDataService);
            //now lets choose a league...
            //lets say spanish league!
            League league = sds.GetLeague(LeagueNameId.SPAIN);
            //now lets see the league table
            LeagueTable lt = league.LeagueTable;
            Console.WriteLine(lt.ToString());

        }
    }
}
