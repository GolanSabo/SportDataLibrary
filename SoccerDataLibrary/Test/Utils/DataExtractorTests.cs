using NUnit.Framework;
using SoccerDataLibrary;
using SoccerDataLibrary.Utils;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Models;

namespace SportDataLibrary.Test
{
    [TestFixture]
    class DataExtractorTests
    {
        [TestCase]
        public void GetPlayeGetJsonStringFromUrlTest()
        {
            Assert.IsNotNull(DataExtractor.GetInstance().GetJsonStringFromUrl(DataType.LEAGUE,398));
        }
    }
}
