using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerDataLibrary.Enums;

namespace SoccerDataLibrary
{
    interface ISoccerDataService {
        League GetLeague(LeagueNameId league);
        //public PlayerData GetPlayerData(String name);
        //public LeagueData GetLeagueData(String name);
    }
}
