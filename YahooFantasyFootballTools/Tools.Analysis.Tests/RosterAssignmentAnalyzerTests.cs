using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fantasizer.Domain;
using Tools.Analysis.Tests.Utilities;
using Tools.Analysis.Logic;

namespace Tools.Analysis.Tests
{
    [TestClass]
    public class RosterAssignmentAnalyzerTests
    {
        private TestObjectFactory _testObjectFactory;

        [TestInitialize]
        public void Initialize()
        {
            _testObjectFactory = new TestObjectFactory();
        }

        [TestMethod]
        public void GetOptimalAssignment_SinglePlayer()
        {
            var rosterPositions = new Dictionary<PositionAbbreviation, RosterPosition>();
            rosterPositions.Add(PositionAbbreviation.W_R, new RosterPosition(Position.WideReceiverRunningBack, 1));

            var players = _testObjectFactory.CreatePlayers(Position.RunningBack);
            var rb = players.First();

            var analyzer = new RosterAssignmentAnalyzer(rosterPositions, players);
            var result = analyzer.GetOptimalAssignment();

            Assert.AreEqual(rb.Id, result[Position.WideReceiverRunningBack].Single().Id);
        }

        [TestMethod]
        public void GetOptimalAssignment_MultiFlex()
        {
            var rosterPositions = new Dictionary<PositionAbbreviation, RosterPosition>();
            rosterPositions.Add(PositionAbbreviation.W_R, new RosterPosition(Position.WideReceiverRunningBack, 1));
            rosterPositions.Add(PositionAbbreviation.W_T, new RosterPosition(Position.WideReceiverTightEnd, 1));
            
            var rb = _testObjectFactory.CreatePlayer(Position.RunningBack, byeWeek: 4);
            var wr = _testObjectFactory.CreatePlayer(Position.WideReceiver, byeWeek: 6);
            var players = new List<Player>() { rb, wr };

            var analyzer = new RosterAssignmentAnalyzer(rosterPositions, players);
            var result = analyzer.GetOptimalAssignment();

            Assert.AreEqual(rb.Id, result[Position.WideReceiverRunningBack].Single().Id);
            Assert.AreEqual(wr.Id, result[Position.WideReceiverTightEnd].Single().Id);
        }

        [TestMethod]
        public void GetOptimalAssignment_SingleFlex()
        {
            var rosterPositions = new Dictionary<PositionAbbreviation, RosterPosition>();
            rosterPositions.Add(PositionAbbreviation.RB, new RosterPosition(Position.RunningBack, 1));
            rosterPositions.Add(PositionAbbreviation.W_R, new RosterPosition(Position.WideReceiverRunningBack, 1));
            rosterPositions.Add(PositionAbbreviation.W_T, new RosterPosition(Position.WideReceiverTightEnd, 1));

            var players = _testObjectFactory.CreatePlayers(
                Position.RunningBack,
                Position.RunningBack,
                Position.WideReceiver);

            var analyzer = new RosterAssignmentAnalyzer(rosterPositions, players);
            var result = analyzer.GetOptimalAssignment();

            Assert.IsNotNull(result[Position.RunningBack]);
            Assert.IsNotNull(result[Position.WideReceiverRunningBack]);
            Assert.IsNotNull(result[Position.WideReceiverTightEnd]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetOptimalAssignment_MorePlayersThanAvailablePositions()
        {
            var rosterPositions = new Dictionary<PositionAbbreviation, RosterPosition>();
            rosterPositions.Add(PositionAbbreviation.RB, new RosterPosition(Position.RunningBack, 2));

            var players = _testObjectFactory.CreatePlayers(
                Position.RunningBack,
                Position.RunningBack,
                Position.RunningBack);

            var analyzer = new RosterAssignmentAnalyzer(rosterPositions, players);
            analyzer.GetOptimalAssignment();
        }

        [TestMethod]
        public void GetOptimalAssignment_UnfillablePosition()
        {
            var rosterPositions = new Dictionary<PositionAbbreviation, RosterPosition>();
            rosterPositions.Add(PositionAbbreviation.QB, new RosterPosition(Position.Quarterback, 1));
            rosterPositions.Add(PositionAbbreviation.BN, new RosterPosition(Position.Bench, 1));

            var rb = _testObjectFactory.CreatePlayer(Position.RunningBack, byeWeek: 4);
            var players = new List<Player>() { rb };

            var analyzer = new RosterAssignmentAnalyzer(rosterPositions, players);
            var result = analyzer.GetOptimalAssignment();

            Assert.AreEqual(0, result[Position.Quarterback].Count);
        }

        [TestMethod]
        public void GetOptimalAssignment_BenchPositionsFilled()
        {
            var rosterPositions = new Dictionary<PositionAbbreviation, RosterPosition>();
            rosterPositions.Add(PositionAbbreviation.QB, new RosterPosition(Position.Quarterback, 1));
            rosterPositions.Add(PositionAbbreviation.BN, new RosterPosition(Position.Bench, 1));

            var qb = _testObjectFactory.CreatePlayer(Position.Quarterback, byeWeek: 4);
            var rb = _testObjectFactory.CreatePlayer(Position.RunningBack, byeWeek: 7);
            var players = new List<Player>() { qb, rb };

            var analyzer = new RosterAssignmentAnalyzer(rosterPositions, players);
            var result = analyzer.GetOptimalAssignment();

            Assert.AreEqual(rb.Id, result[Position.Bench].Single().Id);

        }
    }
}
