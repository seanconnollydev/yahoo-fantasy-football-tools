using System.Linq;
using Fantasizer.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fantasizer.Tests.Utilities;

namespace Fantasizer.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private IFantasizerService _service;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            AppHarborUtil.CheckSecrets();
        }

        [TestInitialize]
        public void InitializeTest()
        {
            _service = ServiceFactory.CreateFantasizerClient(ClientTestConfiguration.ConsumerKey,
                                                             ClientTestConfiguration.ConsumerSecret,
                                                             new TestUserTokenStore());
        }

        [TestMethod]
        public void GetTeams()
        {
            var teams = _service.GetTeams(ClientTestConfiguration.DEFAULT_LEAGUE_KEY);

            Assert.AreEqual(10, teams.Teams.Count);
        }

        [TestMethod]
        public void GetLeaguesByGameCode()
        {
            var leagues = _service.GetLeagues(GameCode.nfl);

            Assert.IsNotNull(leagues);
        }

        [TestMethod]
        public void GetLeaguesByGameId()
        {
            int nfl2011 = 257;
            var leagues = _service.GetLeagues(nfl2011);

            Assert.AreEqual(2, leagues.Count);
        }

        [TestMethod]
        public void GetDraftResults()
        {
            var leagueDraftResults = _service.GetDraftResults(ClientTestConfiguration.DEFAULT_LEAGUE_KEY);

            Assert.IsNotNull(leagueDraftResults);
            Assert.AreEqual(150, leagueDraftResults.DraftResults.Count);
        }

        [TestMethod]
        public void GetRosterPlayers()
        {
            var rosterPlayerResults = _service.GetRosterPlayers(ClientTestConfiguration.DEFAULT_TEAM_KEY, null);
            
            Assert.AreEqual(15, rosterPlayerResults.Players.Count);

            foreach (var player in rosterPlayerResults.Players)
            {
                Assert.IsTrue(player.EligiblePositions.Count > 0);
                Assert.IsTrue(player.ByeWeeks.Count > 0);
            }
        }

        [TestMethod]
        public void GetRosterPlayers_ByWeek()
        {
            var week1Roster = _service.GetRosterPlayers(ClientTestConfiguration.DEFAULT_TEAM_KEY, 1);
            var week2Roster = _service.GetRosterPlayers(ClientTestConfiguration.DEFAULT_TEAM_KEY, 16);

            Assert.IsFalse(week1Roster.Players.SequenceEqual(week2Roster.Players));
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
            Assert.IsNotNull(leagueSettings.League);
            Assert.AreEqual(1, leagueSettings.RosterPositions[PositionAbbreviation.QB].Count);
            Assert.AreEqual(2, leagueSettings.RosterPositions[PositionAbbreviation.RB].Count);
            Assert.AreEqual(2, leagueSettings.RosterPositions[PositionAbbreviation.WR].Count);
            Assert.AreEqual(1, leagueSettings.RosterPositions[PositionAbbreviation.W_R].Count);
            Assert.AreEqual(1, leagueSettings.RosterPositions[PositionAbbreviation.TE].Count);
            Assert.AreEqual(1, leagueSettings.RosterPositions[PositionAbbreviation.K].Count);
            Assert.AreEqual(1, leagueSettings.RosterPositions[PositionAbbreviation.DEF].Count);
            Assert.AreEqual(6, leagueSettings.RosterPositions[PositionAbbreviation.BN].Count);
            Assert.AreEqual(ClientTestConfiguration.DEFAULT_LEAGUE_KEY, leagueSettings.League.Key);
            Assert.AreEqual(1, leagueSettings.League.StartWeek);
            Assert.AreEqual(16, leagueSettings.League.EndWeek);
        }

        [TestMethod]
        public void GetGames()
        {
            var games = _service.GetGames();
            Assert.IsTrue(games.Count > 0);
        }
    }
}
