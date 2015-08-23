using SoccerDataLibrary.Enums;

namespace SoccerDataLibrary
{
    class FootBallDataService : ISoccerDataService
    {
        private static FootBallDataService instance = null;
        private FootBallDataService() { }
        public static FootBallDataService GetInstance()
        {
            if (instance == null)
            {
                instance = new FootBallDataService();
            }
            return instance;
        }

        public League GetLeague(LeagueNameId league) {

            return new League(league);
        }
    }
}
