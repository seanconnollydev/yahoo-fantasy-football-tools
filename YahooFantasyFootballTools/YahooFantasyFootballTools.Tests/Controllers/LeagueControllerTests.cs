using Fantasizer;
using Fantasizer.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using YahooFantasyFootballTools.Controllers;
using YahooFantasyFootballTools.Tests.Utilities;
using System.Web.Mvc;
using NHibernate;
using Tools.Analysis.Data.Entities;
using MvcContrib.TestHelper;
using YahooFantasyFootballTools.Models;
using System;

namespace YahooFantasyFootballTools.Tests.Controllers
{
    [TestClass]
    public class LeagueControllerTests
    {
        private IUserTokenStore _mockUserTokenStore;
        private IFantasizerService _mockFantasizer;
        private ISessionFactory _mockSessionFactory;
        private LeagueController _leagueController;
        private TestObjectFactory _testObjectFactory;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockUserTokenStore = MockRepository.GenerateMock<IUserTokenStore>();
            _mockFantasizer = MockRepository.GenerateMock<IFantasizerService>();
            _mockSessionFactory = MockRepository.GenerateMock<ISessionFactory>();
            _leagueController = new LeagueController(_mockUserTokenStore, _mockFantasizer, _mockSessionFactory);
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

        [TestMethod]
        public void DownloadEligibleKeepers_KeeperSettingNull_Redirects()
        {
            // league key format is {game_key}.l.{league_id}
            const string leagueKey = "1.l.2";
            const int leagueId = 2;

            _mockFantasizer
                .Expect(f => f.GetLeagueTeamPlayers(leagueKey))
                .Return(_testObjectFactory.CreateLeagueTeamPlayerCollection(leagueKey));

            _mockFantasizer
                .Expect(f => f.GetDraftResults(leagueKey))
                .Return(_testObjectFactory.CreateLeagueDraftResultCollection(leagueId, leagueKey));

            ISession mockSession = MockRepository.GenerateMock<ISession>();
            _mockSessionFactory.Expect(f => f.OpenSession()).Return(mockSession);
            mockSession
                .Expect(s => s.Get<LeagueDao>(leagueKey))
                .Return(new LeagueDao() { Key = leagueKey, AllowKeepersFromPriorSeason = null });

            RedirectToRouteResult result = _leagueController.DownloadEligibleKeepers(leagueKey) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Incorrect action result type returned.");
            result.AssertActionRedirect().ToAction<LeagueController>(c => c.ViewKeeperSettings(leagueKey));

            _mockFantasizer.VerifyAllExpectations();
            _mockSessionFactory.VerifyAllExpectations();
            mockSession.VerifyAllExpectations();
        }

        [TestMethod]
        public void DownloadEligibleKeepers_LeagueNull_Redirects()
        {
            // league key format is {game_key}.l.{league_id}
            const string leagueKey = "1.l.2";
            const int leagueId = 2;

            _mockFantasizer
                .Expect(f => f.GetLeagueTeamPlayers(leagueKey))
                .Return(_testObjectFactory.CreateLeagueTeamPlayerCollection(leagueKey));

            _mockFantasizer
                .Expect(f => f.GetDraftResults(leagueKey))
                .Return(_testObjectFactory.CreateLeagueDraftResultCollection(leagueId, leagueKey));

            ISession mockSession = MockRepository.GenerateMock<ISession>();
            _mockSessionFactory.Expect(f => f.OpenSession()).Return(mockSession);
            mockSession
                .Expect(s => s.Get<LeagueDao>(leagueKey))
                .Return(null);

            RedirectToRouteResult result = _leagueController.DownloadEligibleKeepers(leagueKey) as RedirectToRouteResult;

            Assert.IsNotNull(result, "Incorrect action result type returned.");
            result.AssertActionRedirect().ToAction<LeagueController>(c => c.ViewKeeperSettings(leagueKey));

            _mockFantasizer.VerifyAllExpectations();
            _mockSessionFactory.VerifyAllExpectations();
            mockSession.VerifyAllExpectations();
        }

        [TestMethod]
        public void ViewKeeperSettings_LeagueDataExists_ModelPrepopulated()
        {
            const string leagueKey = "1.l.2";

            ISession mockSession = MockRepository.GenerateMock<ISession>();
            _mockSessionFactory.Expect(f => f.OpenSession()).Return(mockSession);

            LeagueDao leagueData = new LeagueDao() { Key = leagueKey, AllowKeepersFromPriorSeason = true };
            mockSession.Expect(s => s.Get<LeagueDao>(leagueKey)).Return(leagueData);

            ViewResult result = _leagueController.ViewKeeperSettings(leagueKey) as ViewResult;
            Assert.IsNotNull(result, "Incorrect action result type returned.");

            KeeperSettingsModel model = result.Model as KeeperSettingsModel;
            Assert.IsNotNull(model, "Incorrect model type returned.");
            Assert.AreEqual(leagueKey, model.LeagueKey);
            Assert.IsTrue(model.AllowKeepersFromPriorSeason);

            _mockFantasizer.VerifyAllExpectations();
            _mockSessionFactory.VerifyAllExpectations();
            mockSession.VerifyAllExpectations();
        }

        [TestMethod]
        public void ViewKeeperSettings_LeagueDataDoesNotExist_ModelDefaultsToFalse()
        {
            const string leagueKey = "1.l.2";

            ISession mockSession = MockRepository.GenerateMock<ISession>();
            _mockSessionFactory.Expect(f => f.OpenSession()).Return(mockSession);
            
            mockSession.Expect(s => s.Get<LeagueDao>(leagueKey)).Return(null);

            ViewResult result = _leagueController.ViewKeeperSettings(leagueKey) as ViewResult;
            Assert.IsNotNull(result, "Incorrect action result type returned.");

            KeeperSettingsModel model = result.Model as KeeperSettingsModel;
            Assert.IsNotNull(model, "Incorrect model type returned.");
            Assert.AreEqual(leagueKey, model.LeagueKey);
            Assert.IsFalse(model.AllowKeepersFromPriorSeason);

            _mockFantasizer.VerifyAllExpectations();
            _mockSessionFactory.VerifyAllExpectations();
            mockSession.VerifyAllExpectations();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void UpdateKeeperSettings_LeagueKeyEmpty_Redirects()
        {
            var model = new KeeperSettingsModel();
            _leagueController.ModelState.AddModelError("Key", "Error Message");
            RedirectToRouteResult result = _leagueController.UpdateKeeperSettings(model) as RedirectToRouteResult;
        }

        [TestMethod]
        public void UpdateKeeperSettings_LeagueDataExists_Succeeds()
        {
            const string leagueKey = "1.l.2";

            var model = new KeeperSettingsModel() { LeagueKey = leagueKey, AllowKeepersFromPriorSeason = false };

            // Setup query expectations
            var leagueData = new LeagueDao() { Key = leagueKey, AllowKeepersFromPriorSeason = true };
            ISession mockSession = MockRepository.GenerateMock<ISession>();
            _mockSessionFactory.Expect(f => f.OpenSession()).Return(mockSession);
            mockSession.Expect(s => s.Get<LeagueDao>(leagueKey)).Return(leagueData);

            // Setup save expectation
            ITransaction mockTransaction = MockRepository.GenerateMock<ITransaction>();
            mockSession.Expect(s => s.BeginTransaction()).Return(mockTransaction);
            mockSession.Expect(s => s.SaveOrUpdate(Arg<LeagueDao>.Matches(l => l.AllowKeepersFromPriorSeason == false && l.Key == leagueKey)));
            mockTransaction.Expect(t => t.Commit());

            // Act
            RedirectToRouteResult result = _leagueController.UpdateKeeperSettings(model) as RedirectToRouteResult;

            // Verify
            Assert.IsNotNull(result, "Expected redirect result.");
            result.AssertActionRedirect().ToAction("ListTeams").WithParameter("leagueKey", leagueKey);
            _mockSessionFactory.VerifyAllExpectations();
            mockSession.VerifyAllExpectations();
        }

        [TestMethod]
        public void UpdateKeeperSettings_LeagueDataDoesNotExist_Succeeds()
        {
            const string leagueKey = "1.l.2";

            var model = new KeeperSettingsModel() { LeagueKey = leagueKey, AllowKeepersFromPriorSeason = false };

            // Setup query expectations
            ISession mockSession = MockRepository.GenerateMock<ISession>();
            _mockSessionFactory.Expect(f => f.OpenSession()).Return(mockSession);
            mockSession.Expect(s => s.Get<LeagueDao>(leagueKey)).Return(null);

            // Setup save expectation
            ITransaction mockTransaction = MockRepository.GenerateMock<ITransaction>();
            mockSession.Expect(s => s.BeginTransaction()).Return(mockTransaction);
            mockSession.Expect(s => s.SaveOrUpdate(Arg<LeagueDao>.Matches(l => l.AllowKeepersFromPriorSeason == false && l.Key == leagueKey)));
            mockTransaction.Expect(t => t.Commit());

            // Act
            RedirectToRouteResult result = _leagueController.UpdateKeeperSettings(model) as RedirectToRouteResult;

            // Verify
            Assert.IsNotNull(result, "Expected redirect result.");
            result.AssertActionRedirect().ToAction("ListTeams").WithParameter("leagueKey", leagueKey);
            _mockSessionFactory.VerifyAllExpectations();
            mockSession.VerifyAllExpectations();
        }
    }
}
