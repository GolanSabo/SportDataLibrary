using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Exceptions;

namespace SoccerDataLibrary.Models
{
    class Team : Parseable
    {
        private int teamId;
        private String name;
        private String code;
        private String shortName;
        private String squadMarketValue;
        private Dictionary<int, Player> playersByJerseyNumber;
        private Dictionary<String, Player> playersByName;


        public Team(int id)
        {

            teamId = id;
            String stringJson = DataExtractor.GetInstance().GetJsonStringFromUrl(DataType.TEAM, id);
            JObject json = JObject.Parse(stringJson);
            Parse(json);

        }


        public Player GetPlayerByJerseyNumber(int index)
        {
            if (playersByJerseyNumber.ContainsKey(index))
                return playersByJerseyNumber[index];
            else
               // Console.WriteLine("There is no player with a jersey number : " + index + " in " + name);
                throw new PlayerNotFoundException("There is no player with a jersey number : " + index + " in " + name);
        }
        
        public Player GetPlayerByName(String index)
        {
            if (playersByName.ContainsKey(index))
                return playersByName[index];
            else {
                Player player = null;
                foreach (String key in playersByName.Keys)
                {
                    if (key.Contains(index))
                    {
                        player = playersByName[key];
                        break;
                    }
                }
                if (player != null)
                    return player;
                else
                    //Console.WriteLine("There is no player which his name is : " + index + " in " + name);
                    throw new PlayerNotFoundException("There is no player which his name is : " + index + " in " + name);
            }
        }


        public void ParsePlayers(int id)
        {
            
            String stringJson = DataExtractor.GetInstance().GetJsonStringFromUrl(DataType.PLAYER, id);
            JObject json = JObject.Parse(stringJson);
            playersByJerseyNumber = new Dictionary<int, Player>();
            playersByName = new Dictionary<String, Player>();
            var count = (int)json["count"];
            if (count == 0)
                throw new TeamPlayersNotFoundException("The api doesn't have data about the players of " + Name);
            try
            {
                var objects = from p in json["players"]
                              select new
                              {
                                  id = (int)p["id"],
                                  name = (String)p["name"],
                                  position = (String)p["position"],
                                  jerseyNumber = (int)p["jerseyNumber"],
                                  dateOfBirth = (String)p["dateOfBirth"],
                                  nationality = (String)p["nationality"],
                                  contractUntil = (String)p["contractUntil"],
                                  marketValue = (String)p["marketValue"]
                              };

                foreach (var item in objects)
                {
                    Player player = new Player(item.id, item.name, item.position, item.jerseyNumber,
                        item.dateOfBirth, item.nationality, item.contractUntil, item.marketValue);

                    playersByJerseyNumber.Add(item.jerseyNumber, player);
                    playersByName.Add(item.name, player);
                }
            }
            catch (Exception e) { }
        }


        public void Parse(JObject json)
        {
            Code = (string)json["code"];
            Name = (string)json["name"];
            ShortName = (string)json["shortName"];
            SquadMarketValue = (string)json["squadMarketValue"];          
            try {
                ParsePlayers(teamId);
            }
            catch (TeamPlayersNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public String Code
        {
            private set
            {
                if (value == null)
                    code = "Unavailabe";
                code = value;
            }
            get
            {
                return code;
            }
        }
        public String ShortName
        {
            private set
            {
                if (value == null)
                    shortName = "Unavailabe";
                shortName = value;
            }
            get
            {
                return shortName;
            }
        }
        public String SquadMarketValue
        {
            private set
            {
                if (value == null)
                    squadMarketValue = "Unavailable";
                else
                {
                    squadMarketValue = value.Split(' ')[0];
                    if(squadMarketValue!="Unavailable")
                        squadMarketValue += "Euro";
                }
            }
            get
            {
                return squadMarketValue;
            }
        }
        public String Name { private set { name = value; } get { return name; } }



        public override String ToString()
        {
            return "Name: " + Name + "\nCode: " + Code + "\nShortName: " + ShortName + "\nSquadMarketValue: " + SquadMarketValue + " \n";
        }

        public void PrintPlayers()
        {
            Console.WriteLine("Players of: "+Name);
            foreach (int n in playersByJerseyNumber.Keys)
            {
                Console.WriteLine(playersByJerseyNumber[n].ToString());
            }
            Console.WriteLine("\n\n");
        }


        public Dictionary<int, Player> PlayersByJerseyNumber
        {
            get
            {
                return playersByJerseyNumber;
            }
        }

        public Dictionary<String, Player> PlayersByName
        {
            get
            {
                return playersByName;
            }
        }
    }
}
