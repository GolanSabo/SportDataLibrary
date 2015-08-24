using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using SoccerDataLibrary.Models;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Exceptions;

namespace SoccerDataLibrary
{
    /// <summary>
    /// Class representing a europian soccer league
    /// </summary>
    class League : Parseable
    {

        private String leagueName;
        private Dictionary<String, int> teamsId;
        private LeagueTable leagueTable;

        /// <summary>
        /// C'tor that gets the LeagueNameId enum and make a League instance of the
        /// asked country
        /// </summary>
        /// <param name="league"></param>
        public League(LeagueNameId league):this((int)league)
        {
        }
        /// <summary>
        /// C'tor that gets the id (int) and make a League instance of the
        /// asked country
        /// </summary>
        /// <param name="league"></param>
        public League(int league)
        {
            String stringJson = DataExtractor.GetInstance().GetJsonStringFromUrl(DataType.LEAGUE,league);
            JObject json = JObject.Parse(stringJson);
            Parse(json);
            leagueTable = new LeagueTable(json);
        }

        /// <summary>
        /// Get a Dictionary holding all teams in a specific league
        /// </summary>
        /// <returns></returns>
        public Dictionary<String,Team> GetLeagueTeams()
        {
            Dictionary<String, Team> teams = new Dictionary<string, Team>();
            foreach(String key in teamsId.Keys)
            {
                teams[key]=(new Team(teamsId[key]));
            }
            return teams;
        }
        /// <summary>
        /// Get a Dictionary holding all teams that thier name contain
        /// the string you sent.
        /// </summary>
        /// <exception cref="SoccerDataServiceExceptions.TeamNotFoundException">Thrown when team can't be found int the API</exception>
        /// <param name="name"></param>
        /// <returns></returns>
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
                throw new TeamNotFoundException("The team you asked for isn't in the " + LeagueName + " league\n");

            Dictionary<String,Team> teams = new Dictionary<string, Team>();
            foreach (int t in id)
            {
                Team tmp= new Team(t);
                teams[tmp.Name] = tmp;
            }
            return teams;
        }
        /// <summary>
        /// parse json object.
        /// </summary>
        /// <param name="json"></param>
        public void Parse(JObject json){

            LeagueName = (string)json["caption"];
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
        /// <summary>Property that indicates the league name </summary>
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
        /// <summary>Property that league table</summary>
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
