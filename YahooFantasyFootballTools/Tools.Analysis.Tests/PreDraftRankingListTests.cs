using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Analysis.Domain;

namespace Tools.Analysis.Tests
{
    [TestClass]
    public class PreDraftRankingListTests
    {
        [TestMethod]
        public void GetPlayer()
        {
            var rankings = new PreDraftRankingList();

            rankings.Add(new PreDraftRanking("Arian Foster, HOU", 1, 60, 8));
            rankings.Add(new PreDraftRanking("Ray Rice, BAL", 2, 59, 8));
            rankings.Add(new PreDraftRanking("Calvin Johnson, DET", 3, 59, 5));
            rankings.Add(new PreDraftRanking("Wes Welker", 4, 55, 9));
            rankings.Add(new PreDraftRanking("LeSean McCoy, PHO", 5, 53, 7));

            var arianFoster = rankings.GetPlayer("Arian Foster");
            Assert.IsNotNull(arianFoster);

            var fosterArian = rankings.GetPlayer("Foster, Arian");
            Assert.IsNotNull(fosterArian);
        }
    }
}
