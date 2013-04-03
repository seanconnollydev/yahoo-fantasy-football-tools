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
        private TestObjectFactory _testObjectFactory;

        [TestInitialize]
        public void Initialize()
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
            Assert.AreEqual(PositionDepth.Adequate, results[Position.Quarterback]);
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
            Assert.AreEqual(PositionDepth.Adequate, results[Position.WideReceiverRunningBack]);
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
                Position.RunningBack,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.WideReceiver,
                Position.Kicker,
                Position.Kicker,
                Position.Defense,
                Position.Defense,
                Position.Defense);

            var analyzer = new RosterDepthAnalyzer(rosterPositions, players);
            var results = analyzer.GetRosterDepth();

            // In this case, the right thing to do is to fill the W/R spot with a RB so the WR can be used for W/T.
            Assert.AreEqual(PositionDepth.Deep, results[Position.Quarterback]);
            Assert.AreEqual(PositionDepth.Adequate, results[Position.RunningBack]);
            Assert.AreEqual(PositionDepth.Adequate, results[Position.WideReceiver]);
            Assert.AreEqual(PositionDepth.Adequate, results[Position.WideReceiverRunningBack]);
            Assert.AreEqual(PositionDepth.Adequate, results[Position.WideReceiverTightEnd]);
            Assert.AreEqual(PositionDepth.VeryDeep, results[Position.Defense]);
            Assert.AreEqual(PositionDepth.Deep, results[Position.Kicker]);
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

            Assert.AreEqual(PositionDepth.Deep, results[Position.Quarterback]);
            Assert.AreEqual(PositionDepth.Adequate, results[Position.RunningBack]);
            Assert.AreEqual(PositionDepth.Adequate, results[Position.WideReceiver]);
            Assert.AreEqual(PositionDepth.Adequate, results[Position.WideReceiverRunningBack]);
            Assert.AreEqual(PositionDepth.VeryDeep, results[Position.WideReceiverRunningBackTightEnd]);
            Assert.AreEqual(PositionDepth.Deep, results[Position.Defense]);
            Assert.AreEqual(PositionDepth.Adequate, results[Position.Kicker]);
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
            Assert.IsFalse(results.ContainsKey(Position.Bench));
        }
    }
}
