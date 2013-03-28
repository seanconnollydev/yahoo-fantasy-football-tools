using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Analysis.Domain;
using Tools.Analysis.Logic;
using Tools.Analysis.Tests.Utilities;

namespace Tools.Analysis.Tests
{
    [TestClass]
    public class RosterDepthAnalyzerTests
    {
        private static TestObjectFactory _testObjectFactory;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _testObjectFactory = new TestObjectFactory();
        }

        [TestMethod]
        public void GetRosterDepth_1QB()
        {
            var rosterPositions = _testObjectFactory.CreateDefaultRosterPositions();
            var players = _testObjectFactory.CreatePlayers("QB", "RB", "RB", "RB", "RB", "WR", "WR", "WR", "WR", "WR",
                                                           "TE", "TE", "TE", "K", "DST");

            var analyzer = new RosterDepthAnalyzer(rosterPositions, players);
            var results = analyzer.GetRosterDepth();

            // 1 QB spot required, 1 QB player. QB position should be adequate.
            Assert.AreEqual(RosterDepth.Adequate, results["QB"]);
        }

        [TestMethod]
        public void GetRosterDepth_Flex()
        {
            var rosterPositions = _testObjectFactory.CreateDefaultRosterPositions();

            var players = _testObjectFactory.CreatePlayers("QB", "RB", "RB", "WR", "WR", "WR", "QB", "QB", "QB", "TE",
                                                           "TE", "TE", "TE", "K", "DST");

            var analyzer = new RosterDepthAnalyzer(rosterPositions, players);
            var results = analyzer.GetRosterDepth();

            // W/R spot should be adequate, filled by 3rd WR.
            Assert.AreEqual(RosterDepth.Adequate, results["W/R"]);
        }

        [TestMethod]
        public void GetRosterDepth_NoBench()
        {
            var rosterPositions = _testObjectFactory.CreateDefaultRosterPositions();

            var players = _testObjectFactory.CreatePlayers("QB", "RB", "RB", "WR", "WR", "WR", "QB", "QB", "QB", "TE",
                                                           "TE", "TE", "TE", "K", "DST");

            var analyzer = new RosterDepthAnalyzer(rosterPositions, players);
            var results = analyzer.GetRosterDepth();

            // It doesn't make sense to analyze depth for BN spots
            Assert.IsFalse(results.ContainsKey("BN"));
        }
    }
}
