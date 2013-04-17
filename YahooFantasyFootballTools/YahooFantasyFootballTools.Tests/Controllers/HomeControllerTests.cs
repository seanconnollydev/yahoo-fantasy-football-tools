using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Fantasizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using YahooFantasyFootballTools.Controllers;
using YahooFantasyFootballTools.Tests.Utilities;

namespace YahooFantasyFootballTools.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private IFantasizerService _mockFantasizer;
        private IUserTokenStore _mockUserTokenStore;
        private IApplicationConfiguration _mockConfiguration;
        private HttpContextBase _mockHttpContext;
        private HomeController _homeController;
        private TestObjectFactory _testObjectFactory;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockFantasizer = MockRepository.GenerateMock<IFantasizerService>();
            _mockUserTokenStore = MockRepository.GenerateMock<IUserTokenStore>();
            _mockConfiguration = MockRepository.GenerateMock<IApplicationConfiguration>();
            _mockHttpContext = MockRepository.GenerateMock<HttpContextBase>();
            _homeController = new HomeController(_mockUserTokenStore, _mockFantasizer, _mockConfiguration);
            _testObjectFactory = new TestObjectFactory();
        }

        [TestMethod]
        public void Index_NoParameters_Succeeds()
        {
            var result = _homeController.Index();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AuthenticateWithYahoo_HostCallbackType_NoPortSpecified()
        {
            _mockConfiguration.Expect(c => c.YahooCallbackUriType).Return(YahooCallbackUriType.Host);
            _mockHttpContext.Expect(c => c.Request.Url).Return(new Uri("http://localhost:8080/"));
            _mockFantasizer.Expect(f => f.BeginAuthorization(new Uri("http://localhost/Home/YahooOAuthCallback"))); // Port should not be specified here.
            
            ApplyMockHttpContextBase(_mockHttpContext, _homeController);
            _homeController.AuthenticateWithYahoo();

            _mockFantasizer.VerifyAllExpectations();
            _mockHttpContext.VerifyAllExpectations();
        }

        [TestMethod]
        public void AuthenticateWithYahoo_AuthorityCallbackType_PortSpecified()
        {
            _mockConfiguration.Expect(c => c.YahooCallbackUriType).Return(YahooCallbackUriType.Authority);
            _mockHttpContext.Expect(c => c.Request.Url).Return(new Uri("http://localhost:8080/"));
            _mockFantasizer.Expect(f => f.BeginAuthorization(new Uri("http://localhost:8080/Home/YahooOAuthCallback"))); // Port should be specified here.

            ApplyMockHttpContextBase(_mockHttpContext, _homeController);
            _homeController.AuthenticateWithYahoo();

            _mockFantasizer.VerifyAllExpectations();
            _mockHttpContext.VerifyAllExpectations();
        }

        [TestMethod]
        public void YahooOAuthCallback()
        {
            var result = _homeController.YahooOAuthCallback() as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("ListLeagues", result.RouteValues["action"]);
            Assert.AreEqual("User", result.RouteValues["controller"]);
            _mockFantasizer.AssertWasCalled(f => f.CompleteAuthorization());
        }

        [TestMethod]
        public void Logout()
        {
            _mockUserTokenStore.Expect(s => s.AccessToken = null);
            _mockUserTokenStore.Expect(s => s.AccessTokenSecret = null);

            var result = _homeController.Logout() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(false, result.ViewBag.IsUserAuthenticated);
            Assert.AreEqual("Index", result.ViewName);
            _mockUserTokenStore.VerifyAllExpectations();
        }

        private static void ApplyMockHttpContextBase(HttpContextBase httpContext, Controller controller)
        {
            var requestContext = new RequestContext(httpContext, new RouteData());
            var controllerContext = new ControllerContext(requestContext, controller);
            controller.ControllerContext = controllerContext;
        }
    }
}
