using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fantasizer;
using Fantasizer.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using YahooFantasyFootballTools.Controllers;
using YahooFantasyFootballTools.Models;
using YahooFantasyFootballTools.Tests.Utilities;

namespace YahooFantasyFootballTools.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        private IFantasizerService _mockFantasizer;
        private IUserTokenStore _mockUserTokenStore;
        private UserController _userController;
        private TestObjectFactory _testObjectFactory;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockFantasizer = MockRepository.GenerateMock<IFantasizerService>();
            _mockUserTokenStore = MockRepository.GenerateMock<IUserTokenStore>();
            _userController = new UserController(_mockUserTokenStore, _mockFantasizer);
            _testObjectFactory = new TestObjectFactory();
        }

        [TestMethod]
        public void ListLeagues_NullGameId_Succeeds()
        {
            _mockFantasizer.Expect(f => f.GetLeagues(Arg<GameCode>.Is.Anything)).Return(_testObjectFactory.CreateLeagueCollection());
            _mockFantasizer.Expect(f => f.GetGames()).Return(_testObjectFactory.CreateGames());
            
            ViewResult result = _userController.ListLeagues(null) as ViewResult;
            Assert.IsNotNull(result);

            LeaguesViewModel model = result.Model as LeaguesViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Games.Count(g => g.Selected), "Only 1 game should be selected.");

            _mockFantasizer.VerifyAllExpectations();
        }

        [TestMethod]
        public void ListLeagues_ValidGameID_Succeeds()
        {
            const int gameId = 1;
            _mockFantasizer.Expect(f => f.GetLeagues(gameId)).Return(_testObjectFactory.CreateLeagueCollection());
            _mockFantasizer.Expect(f => f.GetGames()).Return(_testObjectFactory.CreateGames());

            ViewResult result = _userController.ListLeagues(gameId) as ViewResult;
            Assert.IsNotNull(result);

            LeaguesViewModel model = result.Model as LeaguesViewModel;
            Assert.IsNotNull(model);

            var selectedGame = model.Games.Single(g => g.Selected);
            Assert.IsNotNull(selectedGame);
            Assert.AreEqual(gameId.ToString(), selectedGame.Value);
            
            _mockFantasizer.VerifyAllExpectations();
        }

        [TestMethod]
        public void ListLeagues_Empty_Redirects()
        {
            _mockFantasizer.Expect(f => f.GetLeagues(Arg<GameCode>.Is.Anything)).Return(new LeagueCollection());
            _mockFantasizer.Expect(f => f.GetGames()).Return(_testObjectFactory.CreateGames());
            RedirectToRouteResult result = _userController.ListLeagues(null) as RedirectToRouteResult;
            Assert.IsNotNull(result, "Expected a redirect result.");
        }
    }
}
