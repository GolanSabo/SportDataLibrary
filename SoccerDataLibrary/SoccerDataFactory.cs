using SoccerDataLibrary.Enums;

namespace SoccerDataLibrary
{
   
    static class SoccerDataFactory
    {
        /// <summary>
        /// Singelton.
        /// Chooses the web service.
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public static ISoccerDataService GetSoccerDataService(WebServiceName site)
        {

            if (site.ToString() == "FootBallDataService")
                return FootBallDataService.GetInstance();
           return null;
        }

        
    }
}
