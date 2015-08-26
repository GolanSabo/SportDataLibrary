using NUnit.Framework;
using SoccerDataLibrary;
using SoccerDataLibrary.Utils;
using SoccerDataLibrary.Enums;
using SoccerDataLibrary.Models;

namespace SportDataLibrary.Test
{
    [TestFixture]
    class PlayerTest
    {
        [TestCase]
        public void GetPlayerTest()
        {
            Assert.IsNotNull(new Player(1000,"Sagi Scholes", "Center-Midfield", 18, "01-01-1991", "Yaman", "01-01-2020", "20000000"));
        }
    }
}
