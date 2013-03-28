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
            var players = _testObjectFactory.CreatePlayers(
                Position.Quarterback,
                Position.RunningBack,
                Position.RunningBack,
                Position.RunningBack,
                Position.RunningBack,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.TightEnd,
                Position.TightEnd,
                Position.TightEnd,
                Position.Kicker,
                Position.Defense);

            var analyzer = new RosterDepthAnalyzer(rosterPositions, players);
            var results = analyzer.GetRosterDepth();

            // 1 QB spot required, 1 QB player. QB position should be adequate.
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.QB]);
        }

        [TestMethod]
        public void GetRosterDepth_Flex()
        {
            var rosterPositions = _testObjectFactory.CreateDefaultRosterPositions();

            var players = _testObjectFactory.CreatePlayers(
                Position.Quarterback,
                Position.RunningBack,
                Position.RunningBack,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.Quarterback,
                Position.Quarterback,
                Position.Quarterback,
                Position.TightEnd,
                Position.TightEnd,
                Position.TightEnd,
                Position.TightEnd,
                Position.Kicker,
                Position.Defense);

            var analyzer = new RosterDepthAnalyzer(rosterPositions, players);
            var results = analyzer.GetRosterDepth();

            // W/R spot should be adequate, filled by 3rd WR.
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.W_R]);
        }

        [TestMethod]
        public void GetRosterDepth_MultiFlex()
        {
            var rosterPositions = new Dictionary<PositionAbbreviation, RosterPosition>();
            rosterPositions.Add(PositionAbbreviation.QB, new RosterPosition(Position.Quarterback, 1));
            rosterPositions.Add(PositionAbbreviation.RB, new RosterPosition(Position.RunningBack, 2));
            rosterPositions.Add(PositionAbbreviation.WR, new RosterPosition(Position.WideReceiver, 2));
            rosterPositions.Add(PositionAbbreviation.W_R, new RosterPosition(Position.WideReceiverRunningBack, 1));
            rosterPositions.Add(PositionAbbreviation.W_T, new RosterPosition(Position.WideReceiverTightEnd, 1));
            rosterPositions.Add(PositionAbbreviation.DEF, new RosterPosition(Position.Defense, 1));
            rosterPositions.Add(PositionAbbreviation.K, new RosterPosition(Position.Kicker, 1));
            rosterPositions.Add(PositionAbbreviation.BN, new RosterPosition(Position.Bench, 4));

            var players = _testObjectFactory.CreatePlayers(
                Position.Quarterback,
                Position.Quarterback,
                Position.RunningBack,
                Position.RunningBack,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.TightEnd,
                Position.Kicker,
                Position.Kicker,
                Position.Defense,
                Position.Defense,
                Position.Defense);

            var analyzer = new RosterDepthAnalyzer(rosterPositions, players);
            var results = analyzer.GetRosterDepth();

            Assert.AreEqual(RosterDepth.Deep, results[PositionAbbreviation.QB]);
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.RB]);
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.WR]);
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.W_R]);
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.W_T]);
            Assert.AreEqual(RosterDepth.VeryDeep, results[PositionAbbreviation.DEF]);
            Assert.AreEqual(RosterDepth.Deep, results[PositionAbbreviation.K]);
        }

        [TestMethod]
        public void GetRosterDepth_MultiFlex_VaryingConstraint()
        {
            // Verify more constrained flex positions are considered first
            var rosterPositions = new Dictionary<PositionAbbreviation, RosterPosition>();
            rosterPositions.Add(PositionAbbreviation.QB, new RosterPosition(Position.Quarterback, 1));
            rosterPositions.Add(PositionAbbreviation.RB, new RosterPosition(Position.RunningBack, 2));
            rosterPositions.Add(PositionAbbreviation.WR, new RosterPosition(Position.WideReceiver, 2));
            rosterPositions.Add(PositionAbbreviation.W_R_T, new RosterPosition(Position.WideReceiverRunningBackTightEnd, 1));
            rosterPositions.Add(PositionAbbreviation.W_R, new RosterPosition(Position.WideReceiverRunningBack, 1));
            rosterPositions.Add(PositionAbbreviation.DEF, new RosterPosition(Position.Defense, 1));
            rosterPositions.Add(PositionAbbreviation.K, new RosterPosition(Position.Kicker, 1));
            rosterPositions.Add(PositionAbbreviation.BN, new RosterPosition(Position.Bench, 4));

            var players = _testObjectFactory.CreatePlayers(
                Position.Quarterback,
                Position.Quarterback,
                Position.RunningBack,
                Position.RunningBack,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.TightEnd,
                Position.TightEnd,
                Position.TightEnd,
                Position.Kicker,
                Position.Defense,
                Position.Defense);

            var analyzer = new RosterDepthAnalyzer(rosterPositions, players);
            var results = analyzer.GetRosterDepth();

            Assert.AreEqual(RosterDepth.Deep, results[PositionAbbreviation.QB]);
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.RB]);
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.WR]);
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.W_R]);
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.W_R_T]);
            Assert.AreEqual(RosterDepth.Deep, results[PositionAbbreviation.DEF]);
            Assert.AreEqual(RosterDepth.Adequate, results[PositionAbbreviation.K]);
        }

        [TestMethod]
        public void GetRosterDepth_NoBench()
        {
            var rosterPositions = _testObjectFactory.CreateDefaultRosterPositions();

            var players = _testObjectFactory.CreatePlayers(
                Position.Quarterback,
                Position.RunningBack,
                Position.RunningBack,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.Quarterback,
                Position.Quarterback,
                Position.Quarterback,
                Position.TightEnd,
                Position.TightEnd,
                Position.TightEnd,
                Position.TightEnd,
                Position.Kicker,
                Position.Defense);

            var analyzer = new RosterDepthAnalyzer(rosterPositions, players);
            var results = analyzer.GetRosterDepth();

            // It doesn't make sense to analyze depth for BN spots
            Assert.IsFalse(results.ContainsKey(PositionAbbreviation.BN));
        }
    }
}
