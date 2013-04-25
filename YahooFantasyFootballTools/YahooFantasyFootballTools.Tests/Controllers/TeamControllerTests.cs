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
using NHibernate;
using Tools.Analysis.Data.Entities;
using YahooFantasyFootballTools.Tests.Utilities;
using MvcContrib.TestHelper;

namespace YahooFantasyFootballTools.Tests.Controllers
{
    [TestClass]
    public class TeamControllerTests
    {
        private IUserTokenStore _mockUserTokenStore;
        private IFantasizerService _mockFantasizer;
        private ISessionFactory _mockSessionFactory;
        private TestObjectFactory _testObjectFactory;
        private TeamController _teamController;

        [TestInitialize]
        public void InitailizeTest()
        {
            _mockUserTokenStore = MockRepository.GenerateMock<IUserTokenStore>();
            _mockFantasizer = MockRepository.GenerateMock<IFantasizerService>();
            _mockSessionFactory = MockRepository.GenerateMock<ISessionFactory>();
            _testObjectFactory = new TestObjectFactory();
            _teamController = new TeamController(_mockUserTokenStore, _mockFantasizer, _mockSessionFactory);
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

        [TestMethod]
        public void ListEligibleKeepers_KeeperSettingNull_Redirects()
        {
            // team key format is {game_key}.l.{league_id}.t.{team_id}
            const string teamKey = "1.l.2.t.3";

            // league key format is {game_key}.l.{league_id}
            const string leagueKey = "1.l.2";
            const int leagueId = 2;

            _mockFantasizer
                .Expect(f => f.GetTeamPlayerStats(teamKey))
                .Return(_testObjectFactory.CreateTeamPlayerCollection(teamKey));

            _mockFantasizer
                .Expect(f => f.GetDraftResults(leagueKey))
                .Return(_testObjectFactory.CreateLeagueDraftResultCollection(leagueId, leagueKey));

            ISession mockSession = MockRepository.GenerateMock<ISession>();
            _mockSessionFactory.Expect(f => f.OpenSession()).Return(mockSession);
            mockSession
                .Expect(s => s.Get<LeagueDao>(leagueKey))
                .Return(new LeagueDao() { Key = leagueKey, AllowKeepersFromPriorSeason = null });

            RedirectToRouteResult result = _teamController.ListEligibleKeepers(teamKey) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Incorrect action result type returned.");
            result.AssertActionRedirect().ToAction<LeagueController>(c => c.ViewKeeperSettings(leagueKey));
            
            _mockFantasizer.VerifyAllExpectations();
            _mockSessionFactory.VerifyAllExpectations();
            mockSession.VerifyAllExpectations();
        }

        [TestMethod]
        public void ListEligibleKeepers_LeagueNull_Redirects()
        {
            // team key format is {game_key}.l.{league_id}.t.{team_id}
            const string teamKey = "1.l.2.t.3";

            // league key format is {game_key}.l.{league_id}
            const string leagueKey = "1.l.2";
            const int leagueId = 2;

            _mockFantasizer
                .Expect(f => f.GetTeamPlayerStats(teamKey))
                .Return(_testObjectFactory.CreateTeamPlayerCollection(teamKey));

            _mockFantasizer
                .Expect(f => f.GetDraftResults(leagueKey))
                .Return(_testObjectFactory.CreateLeagueDraftResultCollection(leagueId, leagueKey));

            ISession mockSession = MockRepository.GenerateMock<ISession>();
            _mockSessionFactory.Expect(f => f.OpenSession()).Return(mockSession);
            mockSession
                .Expect(s => s.Get<LeagueDao>(leagueKey))
                .Return(null);

            RedirectToRouteResult result = _teamController.ListEligibleKeepers(teamKey) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Incorrect action result type returned.");
            result.AssertActionRedirect().ToAction<LeagueController>(c => c.ViewKeeperSettings(leagueKey));
            
            _mockFantasizer.VerifyAllExpectations();
            _mockSessionFactory.VerifyAllExpectations();
            mockSession.VerifyAllExpectations();
        }
    }
}
