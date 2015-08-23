using System;
using System.Collections.Generic;
using System.Net;
using SoccerDataLibrary.Enums;

namespace SoccerDataLibrary
{
    class DataExtractor
    {
        private static DataExtractor instance = null;
        Dictionary<DataType, String> extention = new Dictionary<DataType, String>(){
                {DataType.LEAGUENAMES, "soccerseasons"},
                {DataType.LEAGUE, "soccerseasons/{0}/leagueTable"},
                {DataType.TEAM, "teams/{0}"},
                {DataType.PLAYER, "teams/{0}/players"}
            };
        const String baseUrl = "http://api.football-data.org/alpha/";
        const String header = "X-Auth-Token";
        const String token = "9dac4da579014bf6b6a98f07feab86b2";

        private DataExtractor(){ }
        public static DataExtractor GetInstance()
        {
            if (instance == null)
            {
                instance = new DataExtractor();
            }
            return instance;
        }

        public String GetJsonStringFromUrl(DataType dataType ,int id) {

            String url = dataType != DataType.LEAGUENAMES ? String.Format((baseUrl + extention[dataType]), id) : baseUrl + extention[dataType];
            Console.WriteLine(url);
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(header, token);
                return client.DownloadString(url);
            }            
        }
    }
}