using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahooFantasySportsClient.Tests.Utilities;
using YahooFantasySportsClient.Domain;

namespace YahooFantasySportsClient.Tests
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void TeamDraftResults()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());
            Team team = service.GetTeam("273.l.86177.t.4"); // Wookie of the Year - 2012
            var draftResults = team.GetDraftResults();

            Assert.AreEqual(15, draftResults.Count(d => d.TeamKey == "273.l.86177.t.4")); // All 15 results should be associated with the same team key
        }

        [TestMethod]
        public void GetLeagueKeyFromTeam()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());
            Team team = service.GetTeam("273.l.86177.t.4"); // Wookie of the Year - 2012

            Assert.AreEqual("273.l.86177", team.LeagueKey);
        }
    }
}
