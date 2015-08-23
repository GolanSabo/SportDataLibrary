using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SoccerDataLibrary.Models
{
    
    class LeagueTable : Parseable
    {
        private Dictionary<String, TeamLeagueTable> leagueTable;

        public LeagueTable(JObject json) {
            Parse(json);
        }


        public void Parse(JObject json)
        {
            leagueTable = new Dictionary<String, TeamLeagueTable>();
            var obj = from p in json["standing"]
                      select new
                      {
                          name = (String)p["teamName"],
                          position = (int)p["position"],
                          playedGames = (int)p["playedGames"],
                          points = (int)p["points"],
                          goals = (int)p["goals"],
                          goalsAgainst = (int)p["goalsAgainst"],
                          goalDifference = (int)p["goalDifference"]
                      };

            foreach (var item in obj)
            {
                leagueTable[item.name]= new TeamLeagueTable(item.position, item.playedGames, item.points,
                item.goalDifference, item.goalsAgainst, item.goals);

            }
        }
        override public String ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach(String key in leagueTable.Keys)
            {
                str.Append(leagueTable[key].ToString() + "\n");
            }
            return str.ToString();
        }
        //public Dictionary<String, TeamLeagueTable> LeagueTabl { private set { leagueTable = value; } get { return leagueTable; } }
    }
}
