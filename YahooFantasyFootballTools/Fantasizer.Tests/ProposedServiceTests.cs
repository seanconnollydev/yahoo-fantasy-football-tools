using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fantasizer.Proposed;
using Fantasizer.Tests.Utilities;

namespace Fantasizer.Tests
{
    // TODO: Rename this to ServiceTests if/when this replaced current service
    [TestClass]
    public class ProposedServiceTests
    {
        private IFantasizerService _service;

        [TestInitialize]
        public void InitializeTest()
        {
            _service = ServiceFactory.CreateFantasizerClient(
                ClientTestConfiguration.ConsumerKey,
                ClientTestConfiguration.ConsumerSecret,
                new TestUserTokenStore());
        }

        [TestMethod]
        public void GetGame()
        {
            //var response = _service.Get(Resource.Game("nfl"));
            var response = _service.Get(Resource<Game>.WithKey("nfl"));
            Assert.IsTrue(response.Id > 0);
        }

        [TestMethod]
        public void GetGameLeagues()
        {
            var response = _service.Get(Resource<Game>.WithKey("nfl").Leagues);
        }
    }
}
