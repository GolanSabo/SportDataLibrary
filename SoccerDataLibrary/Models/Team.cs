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

        public Player this[int index]
        {
            private set { playersByJerseyNumber[index] = value; }
            get { return playersByJerseyNumber[index]; }
        }


        public Player this[String index]
        {
            private set { playersByName[index] = value; }
            get { return playersByName[index]; }
        }


        public Team(int id)
        {
            teamId = id;
            String stringJson = DataExtractor.GetInstance().GetJsonStringFromUrl(DataType.TEAM, id);
            JObject json = JObject.Parse(stringJson);
            Parse(json);
        }


        public Player GetPlayerByJerseyNumber(int index)
        {
            if (PlayersByJerseyNumber.ContainsKey(index))
                return PlayersByJerseyNumber[index];
            else
                throw new PlayerNotFoundException("There is no player with a jersey number : " + index + " in " + name);
        }


        public Player GetPlayerByName(String index)
        {
            if (PlayersByName.ContainsKey(index))
                return PlayersByName[index];
            else {
                Player player = null;
                foreach (String key in PlayersByName.Keys)
                {
                    if (key.Contains(index))
                    {
                        player = PlayersByName[key];
                        break;
                    }
                }
                if (player != null)
                    return player;
                else
                    throw new PlayerNotFoundException("There is no player which his name is : " + index + " in " + name);
            }
        }


        public void ParsePlayers(int id)
        {
            String stringJson = DataExtractor.GetInstance().GetJsonStringFromUrl(DataType.PLAYER, id);
            JObject json = JObject.Parse(stringJson);
            playersByJerseyNumber = new Dictionary<int, Player>();
            playersByName = new Dictionary<String, Player>();

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

                PlayersByJerseyNumber.Add(item.jerseyNumber, player);
                PlayersByName.Add(item.name, player);
            }
        }


        public void Parse(JObject json)
        {
            Name = (string)json["name"];
            Code = (string)json["code"];
            ShortName = (string)json["shortName"];
            SquadMarketValue = (string)json["squadMarketValue"];
            ParsePlayers(teamId);
        }


        public String Name { private set { name = value; } get { return name; } }
        public String Code { private set { code = value; } get { return code; } }
        public String ShortName { private set { shortName = value; } get { return shortName; } }
        public String SquadMarketValue { private set { squadMarketValue = value; } get { return squadMarketValue; } }
        public Dictionary<int, Player> PlayersByJerseyNumber { private set { playersByJerseyNumber = value; } get { return playersByJerseyNumber; } }
        public Dictionary<String, Player> PlayersByName { private set { playersByName = value; } get { return playersByName; } }


        public override String ToString()
        {
            return "Name: " + Name + "\nCode: " + Code + "\nShortName: " + ShortName + "\nSquadMarketValue: " + SquadMarketValue + "\n";
        }
    }
}
