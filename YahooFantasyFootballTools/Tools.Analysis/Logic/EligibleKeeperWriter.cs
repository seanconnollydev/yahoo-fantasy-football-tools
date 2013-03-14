using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LibCSV;
using Tools.Analysis.Domain;
using LibCSV.Dialects;

namespace Tools.Analysis.Logic
{
    public class EligibleKeeperWriter
    {
        private readonly IEnumerable<EligibleKeeper> _keepers;

        public EligibleKeeperWriter(IEnumerable<EligibleKeeper> keepers)
        {
            _keepers = keepers;
        }

        public string ToCsv()
        {
            var dialect = new Dialect();
            string csvResult;

            using (var memoryStream = new MemoryStream())
            using (var textWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CSVWriter(dialect, textWriter))
            {
                csvWriter.WriteRow(new object[] {"Team", "Player", "Eligible?", "Draft Round", "Last Season Points"});

                foreach (var keeper in _keepers)
                {
                    csvWriter.WriteRow(new object[]
                        {
                            keeper.TeamName, keeper.PlayerName, keeper.IsEligible ? "Yes" : "No", keeper.DraftRound,
                            keeper.LastSeasonPoints
                        });
                }

                Encoding encoding = Encoding.ASCII;
                csvResult = encoding.GetString(memoryStream.ToArray());
            }

            return csvResult;
        }
    }
}
