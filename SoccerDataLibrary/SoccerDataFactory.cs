namespace SoccerDataLibrary
{
    public enum WebServiceName { FootBallDataService };
    static class SoccerDataFactory
    {
   

        public static ISoccerDataService GetSoccerDataService(WebServiceName site)
        {

            if (site.ToString() == "FootBallDataService")
                return FootBallDataService.GetInstance();
           return null;
        }

        
    }
}
