using NUnit.Framework;
using SoccerDataLibrary;
using SoccerDataLibrary.Utils;
using SoccerDataLibrary.Enums;

namespace SportDataLibrary.Test
{
    [TestFixture]
    class LeagueTableTests
    {
        [TestCase]
        public void GetLeagueListTest()
        {
            Assert.IsNotNull(new LeagueTableTests());
        }
    }
}
