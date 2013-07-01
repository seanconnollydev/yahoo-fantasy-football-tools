using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Analysis.External;

namespace Tools.Analysis.Tests
{
    [TestClass]
    public class EspnTests
    {
        [TestMethod]
        public void Get2012PprPreDraftRankings()
        {
            var espn = new Espn();
            var rankings = espn.Get2012PprPreDraftRankings();

            foreach (var ranking in rankings)
            {
                Assert.IsFalse(string.IsNullOrEmpty(ranking.PlayerName), "Player name is null or empty: " + ranking.PlayerName);
                Assert.IsTrue(ranking.Rank >= 1 && ranking.Rank <= 200, "Rank is not between 1 and 200: " + ranking.Rank);
                Assert.IsTrue(ranking.AuctionValue >= 0 && ranking.AuctionValue <= 200, "Auction value is not between $0 and $200." + ranking.AuctionValue);
                Assert.IsTrue(ranking.ByeWeek >= 1 && ranking.ByeWeek <= 16, "Bye week is not between 1 and 16: " + ranking.ByeWeek);
            }

            Assert.AreEqual(200, rankings.Count);
        }
    }
}
