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
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            AppHarborUtil.CheckSecrets();
        }

        [TestMethod]
        public void GetTeams()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.ConsumerKey, ClientTestConfiguration.ConsumerSecret, new TestUserTokenStore());

            var teams = service.GetTeams(ClientTestConfiguration.DEFAULT_LEAGUE_KEY);

            Assert.AreEqual(10, teams.Teams.Count);
        }

        [TestMethod]
        public void GetLeagues()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.ConsumerKey, ClientTestConfiguration.ConsumerSecret, new TestUserTokenStore());

            var leagues = service.GetLeagues();

            Assert.AreEqual(3, leagues.Count);
        }

        [TestMethod]
        public void GetDraftResults()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.ConsumerKey, ClientTestConfiguration.ConsumerSecret, new TestUserTokenStore());

            var leagueDraftResults = service.GetDraftResults(ClientTestConfiguration.DEFAULT_LEAGUE_KEY);

            Assert.AreEqual(150, leagueDraftResults.DraftResults.Count);
        }

        [TestMethod]
        public void GetRosterPlayers()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.ConsumerKey, ClientTestConfiguration.ConsumerSecret, new TestUserTokenStore());

            var rosterPlayerResults = service.GetRosterPlayers(ClientTestConfiguration.DEFAULT_TEAM_KEY);

            Assert.AreEqual(15, rosterPlayerResults.Players.Count);
        }

        [TestMethod]
        public void GetTeamPlayerStats()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.ConsumerKey, ClientTestConfiguration.ConsumerSecret, new TestUserTokenStore());

            var teamPlayerStats = service.GetTeamPlayerStats(ClientTestConfiguration.DEFAULT_TEAM_KEY);

            Assert.AreEqual(15, teamPlayerStats.Players.Count);
        }
    }
}
