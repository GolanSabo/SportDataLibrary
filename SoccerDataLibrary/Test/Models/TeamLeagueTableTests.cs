using NUnit.Framework;
using SoccerDataLibrary;
using SoccerDataLibrary.Utils;
using SoccerDataLibrary.Enums;

namespace SportDataLibrary.Test
{
    [TestFixture]
    class TeamLeagueTableTests
    {
        [TestCase]
        public void GetPlayerByJerseyNumberTest()
        {
            Assert.IsNotNull(new TeamLeagueTable(5,20,50,50,20,30));
        }
    }
}
