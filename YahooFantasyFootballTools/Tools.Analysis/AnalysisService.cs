using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Analysis.Domain;
using Fantasizer.Domain;
using Tools.Analysis.Logic;

namespace Tools.Analysis
{
    public class AnalysisService : IAnalysisService
    {
        #region IAnalysisService Members

        public RosterDepthResult GetRosterDepth(IDictionary<PositionAbbreviation, RosterPosition> rosterPositions, ICollection<Player> availablePlayers, int? week)
        {
            var analyzer = new RosterDepthAnalyzer(rosterPositions, availablePlayers);
            return analyzer.GetRosterDepth(week);
        }

        #endregion
    }
}
