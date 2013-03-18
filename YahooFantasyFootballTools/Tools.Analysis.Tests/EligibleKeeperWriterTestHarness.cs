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
        public void GetEligibleKeepersBytes()
        {
            int teams = 10;
            int playersPerTeam = 15;

            var keepers = BuildKeepers(teams, playersPerTeam);

            var writer = new EligibleKeeperWriter(keepers);
            var aResult = writer.ToCsvArray();
            Assert.IsNotNull(aResult);
            Assert.IsTrue(aResult.Length > 4096); // verify memory stream capacity is not exceeded.
        }

        [TestMethod]
        public void GetEligibleKeepersString()
        {
            int teams = 10;
            int playersPerTeam = 15;

            var keepers = BuildKeepers(teams, playersPerTeam);

            var writer = new EligibleKeeperWriter(keepers);
            var sResult = writer.ToCsvString();
            Assert.IsFalse(string.IsNullOrEmpty(sResult));
            Assert.IsTrue(sResult.Length > 0);
        }

        private List<EligibleKeeper> BuildKeepers(int teams, int playersPerTeam)
        {
            var keepers = new List<EligibleKeeper>();
            var random = new Random();
            string teamName;

            for (int i = 1; i <= teams; i++)
            {
                teamName = "team_" + i;

                for (int j = 1; j <= playersPerTeam; j++)
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

            return keepers;
        }
    }
}
