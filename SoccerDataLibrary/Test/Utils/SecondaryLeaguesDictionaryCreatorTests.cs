using NUnit.Framework;
using SoccerDataLibrary;
using SoccerDataLibrary.Utils;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Models;

namespace SportDataLibrary.Test
{
    [TestFixture]
    class SecondaryLeaguesDictionaryCreatorTests
    {
        [TestCase]
        public void GetLeagueListTest()
        {
            Assert.IsNotNull(SecondaryLeaguesDictionaryCreator.GetLeagueList());
        }

        [TestCase]
        public void GetLeagueNamesTest()
        {
            Assert.IsNotNull(SecondaryLeaguesDictionaryCreator.GetLeagueNames());
        }

        [TestCase]
        public void GetLeagueIdsTest()
        {
            Assert.IsNotNull(SecondaryLeaguesDictionaryCreator.GetLeagueIds());
        }
    }
}
