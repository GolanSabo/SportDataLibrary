using NUnit.Framework;
using SoccerDataLibrary;
using SoccerDataLibrary.Utils;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Exceptions;

namespace SportDataLibrary.Test
{
    [TestFixture]
    class LeagueTests
    {
        [TestCase]
        public void GetLeagueListTest()
        {
            Assert.IsNotNull(SecondaryLeaguesDictionaryCreator.GetLeagueList());
        }

        [TestCase]
        public void GetLeagueTeamsTest()
        {
            League league = new League(LeagueNameId.ENGLAND);
            Assert.IsNotNull(league.GetLeagueTeams());
        }

        [TestCase]
        [ExpectedException(typeof(TeamNotFoundException))]
        public void GetLeagueTeamsWithExceptionTest()
        {
            League league = new League(398);
            Assert.IsNotNull(league.GetTeamByName("Barca"));
        }

        [TestCase]
        public void GetTeamByNameTest()
        {
            League league = new League(LeagueNameId.ENGLAND);
            Assert.IsNotNull(league.GetTeamByName("Manchester United FC"));
        }
    }
}
