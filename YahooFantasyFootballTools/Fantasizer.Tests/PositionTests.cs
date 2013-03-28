using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fantasizer.Domain;

namespace Fantasizer.Tests
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void InitializationTests()
        {
            var qb = Position.Quarterback;
            var w_r = Position.WideReceiverRunningBack;

            Assert.IsNotNull(qb);
            Assert.IsFalse(qb.IsFlex);
            Assert.IsNotNull(w_r);
            Assert.IsTrue(w_r.IsFlex);
            Assert.AreEqual(2, w_r.PossiblePositions.Count);
            Assert.IsTrue(qb.PossiblePositions.Contains(Position.Quarterback));
            Assert.IsTrue(w_r.PossiblePositions.Contains(Position.WideReceiver));
            Assert.IsTrue(w_r.PossiblePositions.Contains(Position.RunningBack));
        }
    }
}
