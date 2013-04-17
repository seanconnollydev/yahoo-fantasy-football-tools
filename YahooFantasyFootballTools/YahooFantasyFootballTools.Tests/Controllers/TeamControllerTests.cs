using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahooFantasyFootballTools.Controllers;
using Fantasizer;
using Rhino.Mocks;
using Fantasizer.Domain;
using System.Web.Mvc;

namespace YahooFantasyFootballTools.Tests.Controllers
{
    [TestClass]
    public class TeamControllerTests
    {
        private IUserTokenStore _mockUserTokenStore;
        private IFantasizerService _mockFantasizer;
        private TeamController _teamController;

        [TestInitialize]
        public void InitailizeTest()
        {
            _mockUserTokenStore = MockRepository.GenerateMock<IUserTokenStore>();
            _mockFantasizer = MockRepository.GenerateMock<IFantasizerService>();
            _teamController = new TeamController(_mockUserTokenStore, _mockFantasizer);
        }

        [TestMethod]
        public void ShowTeam()
        {
            const string teamKey = "team_key";
            const string teamName = "Team 1";
            var team = new Team(1, teamKey, teamName);

            _mockFantasizer.Expect(f => f.GetTeam(teamKey)).Return(team);

            ViewResult result = _teamController.ShowTeam(teamKey) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(teamName, result.ViewData["TeamName"]);
            _mockFantasizer.VerifyAllExpectations();
        }
    }
}
