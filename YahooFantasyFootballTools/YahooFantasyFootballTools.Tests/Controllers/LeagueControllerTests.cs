using Fantasizer;
using Fantasizer.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using YahooFantasyFootballTools.Controllers;
using YahooFantasyFootballTools.Tests.Utilities;
using System.Web.Mvc;

namespace YahooFantasyFootballTools.Tests.Controllers
{
    [TestClass]
    public class LeagueControllerTests
    {
        private IUserTokenStore _mockUserTokenStore;
        private IFantasizerService _mockFantasizer;
        private LeagueController _leagueController;
        private TestObjectFactory _testObjectFactory;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockUserTokenStore = MockRepository.GenerateMock<IUserTokenStore>();
            _mockFantasizer = MockRepository.GenerateMock<IFantasizerService>();
            _leagueController = new LeagueController(_mockUserTokenStore, _mockFantasizer);
            _testObjectFactory = new TestObjectFactory();
        }


        [TestMethod]
        public void ListTeams()
        {
            const string leagueKey = "league_key";
            const string leagueName = "league_name";
            var leagueTeamCollection = _testObjectFactory.CreateLeagueTeamCollection(leagueName, leagueKey);
            _mockFantasizer.Expect(f => f.GetTeams(leagueKey)).Return(leagueTeamCollection);

            ViewResult result = _leagueController.ListTeams(leagueKey) as ViewResult;
            Assert.IsNotNull(result);

            Assert.AreEqual(leagueName, result.ViewData["LeagueName"]);
        }
    }
}
