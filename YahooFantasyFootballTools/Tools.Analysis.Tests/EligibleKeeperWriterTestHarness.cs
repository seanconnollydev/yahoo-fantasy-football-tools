using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Analysis.Domain;
using Tools.Analysis.Logic;

namespace Tools.Analysis.Tests
{
    [TestClass]
    public class EligibleKeeperWriterTestHarness
    {
        [TestMethod]
        public void GetEligibleKeepers()
        {
            var keepers = new List<EligibleKeeper>();
            var random = new Random();

            string teamName;
            for (int i = 1; i <= 10; i++)
            {
                teamName = "team_" + i;

                for (int j = 1; j <= 15; j++)
                {
                    keepers.Add(new EligibleKeeper
                        {
                            DraftRound = i,
                            IneligibilityReason = i == 1 ? "This player was kept last season" : null,
                            IsEligible = i != 1,
                            LastSeasonPoints = random.Next(100, 400),
                            PlayerName = "player_" + i,
                            TeamName = "team_" + i
                        });
                }
            }

            var writer = new EligibleKeeperWriter(keepers);
            var array = writer.ToCsvArray();
            Assert.IsNotNull(array);
            Assert.IsTrue(array.Length > 0);
        }
    }
}
