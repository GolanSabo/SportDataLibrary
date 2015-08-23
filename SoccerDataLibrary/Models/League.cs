using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using SoccerDataLibrary.Models;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Exceptions;

namespace SoccerDataLibrary
{
    class League : Parseable
    {

        private String LeagueName;
        private Dictionary<String, int> teamsURL;
        private LeagueTable leagueTable;

        public int this[String index]
        {
            get
            {
                return teamsURL[index];
            }
            private set
            {
                teamsURL[index] = value;
            }
        }
        public League(LeagueNameId league)
        {
            String stringJson = DataExtractor.GetInstance().GetJsonStringFromUrl(DataType.LEAGUE,(int)league);
            JObject json = JObject.Parse(stringJson);
            Parse(json);
            leagueTable = new LeagueTable(json);
        }


        public Team GetTeamByName(String name)
        {
            int id = 0;
            foreach (String key in teamsURL.Keys)
            {
                if (key.Contains(name)) {
                    id = teamsURL[key];
                    break;
                }
            }
            if (id == 0)
                throw new TeamNotFoundException("The team you asked for isn't in the " + LeagueName + " league");

            Team team = new Team(id);
            return team;
        }


        public void Parse(JObject json){

            LeagueName = (string)json["leagueCaption"];
            teamsURL = new Dictionary<string, int>();
            var obj = from p in json["standing"]
                      select new {url = (String)p["_links"]["team"]["href"],
                                  name = (String)p["teamName"]};

            foreach (var item in obj)
            {
                int id = Int32.Parse(item.url.Replace("http://api.football-data.org/alpha/teams/", ""));
                teamsURL[item.name] = id;
            }
        }
    }
}
