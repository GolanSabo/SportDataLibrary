using System;
using System.Collections.Generic;
using System.Net;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Exceptions;

namespace SoccerDataLibrary
{
    /// <summary>
    /// class for extracting data out of an url
    /// </summary>
    class DataExtractor
    {

        private static DataExtractor instance = null;
        Dictionary<DataType, String> extention = new Dictionary<DataType, String>(){
                {DataType.LEAGUENAMES, "soccerseasons"},
                {DataType.LEAGUE, "soccerseasons/{0}/leagueTable"},
                {DataType.TEAM, "teams/{0}"},
                {DataType.PLAYER, "teams/{0}/players"}
            };
        /// <summary>
        /// Base URL of the web service API
        /// </summary>
        const String baseUrl = "http://api.football-data.org/alpha/";
        /// <summary>
        /// Token header for using API
        /// </summary>
        const String header = "X-Auth-Token";
        /// <summary>
        /// Key for using API
        /// </summary>
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
        /// <summary>
        /// Extract json string out of a 
        /// </summary>
        /// <param name="dataType">indicate the type of data needed to be extracted</param>
        /// <param name="id">indicate a specific id of a team/league/player needed to be extracted</param>
        /// <returns></returns>
        public String GetJsonStringFromUrl(DataType dataType ,int id) {
            try {
                String url = dataType != DataType.LEAGUENAMES ? String.Format((baseUrl + extention[dataType]), id) : baseUrl + extention[dataType];
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add(header, token);
                    return client.DownloadString(url);
                }
            }
            catch (Exception)
            {
                throw new UnavailableConnectionException("Could not connect to web");
            }       
        }
    }
}