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

        private String leagueName;
        private Dictionary<String, int> teamsId;
        private LeagueTable leagueTable;


        public League(LeagueNameId league):this((int)league)
        {
        }

        public League(int league)
        {
            String stringJson = DataExtractor.GetInstance().GetJsonStringFromUrl(DataType.LEAGUE,league);
            JObject json = JObject.Parse(stringJson);
            Parse(json);
            leagueTable = new LeagueTable(json);
        }


        public Dictionary<String,Team> GetLeagueTeams()
        {
            Dictionary<String, Team> teams = new Dictionary<string, Team>();
            foreach(String key in teamsId.Keys)
            {
                teams[key]=(new Team(teamsId[key]));
            }
            return teams;
        }

        public Dictionary<String, Team> GetTeamByName(String name)
        {

            List<int> id = new List<int>();
            foreach (String key in teamsId.Keys)
            {
                if (key.Contains(name))
                {
                    id.Add(teamsId[key]);
                }
            }
            if (id.Count == 0)
                throw new TeamNotFoundException("The team you asked for isn't in the " + LeagueName + " league");

            Dictionary<String,Team> teams = new Dictionary<string, Team>();
            foreach (int t in id)
                teams[name]=new Team(t);

            return teams;
        }

        public void Parse(JObject json){

            LeagueName = (string)json["leagueCaption"];
            teamsId = new Dictionary<string, int>();
            var obj = from p in json["standing"]
                      select new {url = (String)p["_links"]["team"]["href"],
                                  name = (String)p["teamName"]};

            foreach (var item in obj)
            {
                int id = Int32.Parse(item.url.Replace("http://api.football-data.org/alpha/teams/", ""));
                teamsId[item.name] = id;
            }
        }
        public String LeagueName {
            get
            {
                return leagueName;
            }
            private set
            {
                leagueName = value;
            }
        }

        public LeagueTable LeagueTable {
            get
            {
                return leagueTable;
            }
            private set
            {
                leagueTable = value;
            }
        }
    }
}
