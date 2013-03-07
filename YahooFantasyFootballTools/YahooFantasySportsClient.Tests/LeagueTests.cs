using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fantasizer.Domain;
using Fantasizer.Tests.Utilities;

namespace Fantasizer.Tests
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

        [TestMethod]
        public void GetTeams()
        {
            var client = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());
            var league = client.CurrentUser.GetLeagues().First();
            Assert.IsTrue(league.GetTeams().Count() > 0);
        }

        [TestMethod]
        public void GetDraftResults()
        {
            var client = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());
            var league = client.CurrentUser.GetLeagues().First();
            var draftResults = league.GetDraftResults();
            Assert.AreEqual(150, draftResults.Count()); // 15 players per team, 10 teams
        }

        [TestMethod]
        public void GetLeagueFromKey()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());
            var league = service.GetLeague("273.l.86177");
            var teams = league.GetTeams();

            Assert.AreEqual(10, teams.Count());
        }
    }
}
