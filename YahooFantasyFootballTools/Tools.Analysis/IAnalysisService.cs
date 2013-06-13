using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Analysis.Domain;
using Fantasizer.Domain;

namespace Tools.Analysis
{
    /// <summary>
    /// Service interface for analysis functions.
    /// </summary>
    public interface IAnalysisService
    {
        /// <summary>
        /// Analyzes a team's depth by position.
        /// </summary>
        /// <param name="rosterPositions">The roster positions that are available.</param>
        /// <param name="availablePlayers">The players on the team that are available.</param>
        /// <param name="week">(Optional) The week to analyze for depth (in order to consider bye weeks).</param>
        /// <returns></returns>
        RosterDepthResult GetRosterDepth(
            IDictionary<PositionAbbreviation, RosterPosition> rosterPositions,
            ICollection<Player> availablePlayers,
            int? week);
    }
}
