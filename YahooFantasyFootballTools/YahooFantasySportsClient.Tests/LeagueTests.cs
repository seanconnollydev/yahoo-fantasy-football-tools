using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahooFantasySportsClient.Domain;
using YahooFantasySportsClient.Tests.Utilities;

namespace YahooFantasySportsClient.Tests
{
    [TestClass]
    public class LeagueTests
    {
        [TestMethod]
        public void GetLeaguesForTheCurrentUser()
        {
            var client = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());
            var leagues = client.CurrentUser.GetLeagues();

            // This test isn't really deterministic since it may change when a new seasons starts.
            Assert.AreEqual(3, leagues.Count());
        }
    }
}
