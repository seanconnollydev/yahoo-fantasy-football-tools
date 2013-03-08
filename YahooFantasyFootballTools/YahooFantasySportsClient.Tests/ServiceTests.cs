using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fantasizer.Tests.Utilities;

namespace Fantasizer.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void GetTeams()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());

            var teams = service.GetTeams(ClientTestConfiguration.DEFAULT_LEAGUE_KEY);

            Assert.AreEqual(10, teams.Teams.Count);
        }

        [TestMethod]
        public void GetLeagues()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());

            var leagues = service.GetLeagues();

            Assert.AreEqual(3, leagues.Count);
        }

        [TestMethod]
        public void GetDraftResults()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());

            var leagueDraftResults = service.GetDraftResults(ClientTestConfiguration.DEFAULT_LEAGUE_KEY);

            Assert.AreEqual(150, leagueDraftResults.DraftResults.Count);
        }

        [TestMethod]
        public void GetPlayers()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());

            var teamPlayerResults = service.GetPlayers(ClientTestConfiguration.DEFAULT_TEAM_KEY);

            Assert.AreEqual(15, teamPlayerResults.Players.Count);
        }
    }
}
