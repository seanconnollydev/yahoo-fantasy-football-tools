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
        private YahooFantasySportsService _service;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            AppHarborUtil.CheckSecrets();
        }

        [TestInitialize]
        public void InitializeTest()
        {
            _service = new YahooFantasySportsService(ClientTestConfiguration.ConsumerKey, ClientTestConfiguration.ConsumerSecret, new TestUserTokenStore());
        }

        [TestMethod]
        public void GetTeams()
        {
            var teams = _service.GetTeams(ClientTestConfiguration.DEFAULT_LEAGUE_KEY);

            Assert.AreEqual(10, teams.Teams.Count);
        }

        [TestMethod]
        public void GetLeagues()
        {
            var leagues = _service.GetLeagues();

            Assert.AreEqual(3, leagues.Count);
        }

        [TestMethod]
        public void GetDraftResults()
        {
            var leagueDraftResults = _service.GetDraftResults(ClientTestConfiguration.DEFAULT_LEAGUE_KEY);

            Assert.AreEqual(150, leagueDraftResults.DraftResults.Count);
        }

        [TestMethod]
        public void GetRosterPlayers()
        {
            var rosterPlayerResults = _service.GetRosterPlayers(ClientTestConfiguration.DEFAULT_TEAM_KEY);

            Assert.AreEqual(15, rosterPlayerResults.Players.Count);
        }

        [TestMethod]
        public void GetTeamPlayerStats()
        {
            var teamPlayerStats = _service.GetTeamPlayerStats(ClientTestConfiguration.DEFAULT_TEAM_KEY);

            Assert.AreEqual(15, teamPlayerStats.Players.Count);
        }

        [TestMethod]
        public void GetLeaguePlayers()
        {
            var leagueTeamPlayers = _service.GetLeagueTeamPlayers(ClientTestConfiguration.DEFAULT_LEAGUE_KEY);

            Assert.AreEqual(10, leagueTeamPlayers.Count);
            Assert.AreEqual(150, leagueTeamPlayers.Sum(t => t.Players.Count));
        }

        [TestMethod]
        public void ExecuteRawRequest()
        {
            var xml = _service.ExecuteRawRequest("http://fantasysports.yahooapis.com/fantasy/v2/game/nfl");

            Assert.IsNotNull(xml);
            Assert.IsNotNull(xml.Root.Element(ClientTestConfiguration.YahooXMLNS + "game"));
        }

        [TestMethod]
        public void GetLeagueSettings()
        {
            var leagueSettings = _service.GetLeagueSettings(ClientTestConfiguration.DEFAULT_LEAGUE_KEY);
            Assert.IsNotNull(leagueSettings);

            // TODO: These lookups would be much easier if I used a dictionary and enums for positions
            Assert.AreEqual(1, leagueSettings.RosterPositions.Single(rp => rp.Position.Name.Equals("QB", StringComparison.OrdinalIgnoreCase)).Count);
            Assert.AreEqual(2, leagueSettings.RosterPositions.Single(rp => rp.Position.Name.Equals("RB", StringComparison.OrdinalIgnoreCase)).Count);
            Assert.AreEqual(2, leagueSettings.RosterPositions.Single(rp => rp.Position.Name.Equals("WR", StringComparison.OrdinalIgnoreCase)).Count);
            Assert.AreEqual(1, leagueSettings.RosterPositions.Single(rp => rp.Position.Name.Equals("W/R", StringComparison.OrdinalIgnoreCase)).Count);
            Assert.AreEqual(1, leagueSettings.RosterPositions.Single(rp => rp.Position.Name.Equals("TE", StringComparison.OrdinalIgnoreCase)).Count);
            Assert.AreEqual(1, leagueSettings.RosterPositions.Single(rp => rp.Position.Name.Equals("K", StringComparison.OrdinalIgnoreCase)).Count);
            Assert.AreEqual(1, leagueSettings.RosterPositions.Single(rp => rp.Position.Name.Equals("DEF", StringComparison.OrdinalIgnoreCase)).Count);
            Assert.AreEqual(6, leagueSettings.RosterPositions.Single(rp => rp.Position.Name.Equals("BN", StringComparison.OrdinalIgnoreCase)).Count);
        }
    }
}
