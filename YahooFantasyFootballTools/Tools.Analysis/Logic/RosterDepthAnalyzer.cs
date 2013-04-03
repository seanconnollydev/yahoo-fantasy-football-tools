using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;
using Tools.Analysis.Domain;
using Tools.Analysis;

namespace Tools.Analysis.Logic
{
    public class RosterDepthAnalyzer
    {
        private readonly IDictionary<PositionAbbreviation, RosterPosition> _rosterPositions;
        private readonly ICollection<Player> _availablePlayers;
        private readonly RosterAssignmentAnalyzer _assignmentAnalyzer;

        public RosterDepthAnalyzer(IDictionary<PositionAbbreviation, RosterPosition> rosterPositions, ICollection<Player> availablePlayers)
        {
            _rosterPositions = rosterPositions;
            _availablePlayers = availablePlayers;
            _assignmentAnalyzer = new RosterAssignmentAnalyzer(_rosterPositions, _availablePlayers);
        }

        /// <summary>
        /// Determine roster depth by position.
        /// </summary>
        /// <returns>A dictionary keyed off of position (e.g. QB, RB, etc.)</returns>
        public IDictionary<Position, PositionDepth> GetRosterDepth()
        {
            // Determine the optimal roster assignments
            var optimalAssignments = _assignmentAnalyzer.GetOptimalAssignment();

            var rosterDepthMap = new Dictionary<Position, PositionDepth>();
            foreach (var rosterPosition in _rosterPositions)
            {
                // Short circuit the bench position, we don't need to evaluate depth for this position
                if (rosterPosition.Key == PositionAbbreviation.BN)
                    break;

                int filled = optimalAssignments[rosterPosition.Value.Position].Count;
                int required = rosterPosition.Value.Count;
                int additionalAvailable = 0;

                if (filled == required)
                {
                    // There may still be additional players on the bench that could fill this position and should
                    // contribute to this position's depth.  Note that a bench player can contribute to the depth of
                    // more than one position.
                    foreach (var player in optimalAssignments[Position.Bench])
                    {
                        var position = rosterPosition.Value.Position;

                        if (position.CanBeFilledBy(player))
                        {
                            additionalAvailable++;
                        }
                    }
                }

                rosterDepthMap[rosterPosition.Value.Position] = DetermineDepth(required, filled + additionalAvailable);
            }

            return rosterDepthMap;
        }

        private static PositionDepth DetermineDepth(int required, int available)
        {
            int delta = required - available;

            if (delta >= 2)
                return PositionDepth.VeryShallow;
            else if (delta == 1)
                return PositionDepth.Shallow;
            else if (delta == 0)
                return PositionDepth.Adequate;
            else if (delta == -1)
                return PositionDepth.Deep;
            else if (delta <= 2)
                return PositionDepth.VeryDeep;
            else
            {
                var ex = new Exception("Could not determine depth based on inputs.");
                ex.Data.Add("required", required);
                ex.Data.Add("available", available);
                throw ex;
            }
        }

        private class PositionComparer : IComparer<Position>
        {
            public int Compare(Position x, Position y)
            {
                // All I really want to do is push flex positions to the bottom
                return x.PossiblePositions.Count - y.PossiblePositions.Count;
            }
        }

        private class RosterPositionAvailability
        {
            public RosterPositionAvailability(int required)
            {
                this.Required = required;
            }

            public int Required { get; private set; }
            public int Available { get; set; }
        }
    }
}
