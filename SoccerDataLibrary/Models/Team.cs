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
    /// <summary>
    /// class represnting a soccer team.
    /// </summary>
    class Team : Parseable
    {
        private int teamId;
        private String name;
        private String code;
        private String shortName;
        private String squadMarketValue;
        private Dictionary<int, Player> playersByJerseyNumber;
        private Dictionary<String, Player> playersByName;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="id"></param>
        public Team(int id)
        {
            teamId = id;
            String stringJson = DataExtractor.GetInstance().GetJsonStringFromUrl(DataType.TEAM, id);
            JObject json = JObject.Parse(stringJson);
            Parse(json);

        }

        /// <summary>
        /// Get a player by his shirt number.
        /// </summary>
        /// <exception cref="SoccerDataServiceException.PlayerNotFoundException">Thrown when player was not found</exception>
        /// <param name="index"></param>
        /// <returns></returns>
        public Player GetPlayerByJerseyNumber(int index)
        {
            if (playersByJerseyNumber.ContainsKey(index))
                return playersByJerseyNumber[index];
            else
               // Console.WriteLine("There is no player with a jersey number : " + index + " in " + name);
                throw new PlayerNotFoundException("There is no player with a jersey number : " + index + " in " + name);
        }


        /// <summary>
        /// Get a player by his name.
        /// </summary>
        /// <exception cref="SoccerDataServiceException.PlayerNotFoundException">Thrown when player was not found</exception>
        /// <param name="index"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Parse all players in the team
        /// </summary>
        /// <exception cref="SoccerDataServiceException.TeamPlayersNotFoundException">Thrown when the 
        /// api page of the team doesn't include its players</exception>
        /// <param name="id"></param>
        private void ParsePlayers(int id)
        {           
            String stringJson = DataExtractor.GetInstance().GetJsonStringFromUrl(DataType.PLAYER, id);
            JObject json = JObject.Parse(stringJson);
            playersByJerseyNumber = new Dictionary<int, Player>();
            playersByName = new Dictionary<String, Player>();
            var count = (int)json["count"];
            int itemId=0;
            int itemJerseyNumber = 0;
            try
            {
                if (count == 0)
                throw new TeamPlayersNotFoundException("The api doesn't have data about the players of " + Name);

                var objects = from p in json["players"]
                              select new
                              {
                                  id = (String)p["id"],
                                  name = (String)p["name"],
                                  position = (String)p["position"],
                                  jerseyNumber = (String)p["jerseyNumber"],
                                  dateOfBirth = (String)p["dateOfBirth"],
                                  nationality = (String)p["nationality"],
                                  contractUntil = (String)p["contractUntil"],
                                  marketValue = (String)p["marketValue"]
                              };

                foreach (var item in objects)
                {

                    if (item.jerseyNumber == null)
                        itemJerseyNumber = -1;
                    else itemJerseyNumber = Int32.Parse(item.jerseyNumber);
                    if (item.id == null)
                        itemId = -1;
                    else itemId= Int32.Parse(item.id);
                    Player player = new Player(itemId, item.name, item.position, itemJerseyNumber,
                        item.dateOfBirth, item.nationality, item.contractUntil, item.marketValue);

                    playersByJerseyNumber.Add(player.JerseyNumber, player);
                    playersByName.Add(player.Name, player);
                }
            }
            catch (Exception e) { Console.WriteLine("The api doesn't have data about the players of " + Name+"\n"); }
        }

        /// <summary>
        /// Parse json object into team
        /// </summary>
        /// <param name="json"></param>
        public void Parse(JObject json)
        {
            Code = (string)json["code"];
            Name = (string)json["name"];
            ShortName = (string)json["shortName"];
            SquadMarketValue = (string)json["squadMarketValue"];          
            ParsePlayers(teamId);

        }
        /// <summary>
        /// Property representing the code of the team in the api
        /// </summary>
        public String Code
        {
            private set
            {
                if (value == null)
                    code = "Unavailabe";
                else
                    code = value;
            }
            get
            {
                return code;
            }
        }
        /// <summary>
        /// Property representing the short name of the team.
        /// </summary>
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
        /// <summary>
        /// Property representing the total squad value of the team.
        /// </summary>
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
        /// <summary>
        /// Property representing the name of the team.
        /// </summary>
        public String Name { private set { name = value; } get { return name; } }


        /// <summary>Returns the details of a player ready for printing.</summary>
        /// <returns></returns>
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

        /// <summary>
        /// Property holds the list of the players by shirt number
        /// </summary>
        public Dictionary<int, Player> PlayersByJerseyNumber
        {
            get
            {
                return playersByJerseyNumber;
            }
        }
        /// <summary>
        /// Property holds the list of the players by name
        /// </summary>
        public Dictionary<String, Player> PlayersByName
        {
            get
            {
                return playersByName;
            }
        }
    }
}
