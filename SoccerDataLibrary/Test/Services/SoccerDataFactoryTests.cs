using NUnit.Framework;
using SoccerDataLibrary;
using SoccerDataLibrary.Utils;
using SoccerDataLibrary.Enums;

namespace SportDataLibrary.Test
{
    [TestFixture]
    class SoccerDataServiceTests
    {
        [TestCase]
        public void GetSoccerDataServiceTests()
        {
            Assert.IsNotNull(SoccerDataFactory.GetSoccerDataService(WebServiceName.FootBallDataService));
        }
    }
}
