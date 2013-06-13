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

        public RosterDepthAnalyzer(IDictionary<PositionAbbreviation, RosterPosition> rosterPositions, ICollection<Player> availablePlayers)
        {
            _rosterPositions = rosterPositions;
            _availablePlayers = availablePlayers;
        }
       
        /// <summary>
        /// Determine roster depth by position.
        /// </summary>
        /// <returns>A dictionary keyed off of position (e.g. QB, RB, etc.)</returns>
        /// <param name="week">(Optional) A specific week to determine depth for (otherwise the team is evaluated overall).</param>
        public RosterDepthResult GetRosterDepth(int? week)
        {
            // Determine the optimal roster assignments
            var assignmentAnalyzer = new RosterAssignmentAnalyzer(_rosterPositions, _availablePlayers, week);
            var optimalAssignments = assignmentAnalyzer.GetOptimalAssignment();

            var rosterDepthResult = new RosterDepthResult();
            foreach (var rosterPosition in _rosterPositions)
            {
                // Short circuit the bench position, we don't need to evaluate depth for this position
                if (rosterPosition.Key == PositionAbbreviation.BN)
                    break;

                var positionAssignmentResult = optimalAssignments.PositionAssignmentResults[rosterPosition.Value.Position];
                int filled = positionAssignmentResult.Filled;
                int required = rosterPosition.Value.Count;
                int additionalAvailable = 0;

                if (filled == required)
                {
                    // There may still be additional players on the bench that could fill this position and should
                    // contribute to this position's depth.  Note that a bench player can contribute to the depth of
                    // more than one position.
                    foreach (var playerAssignment in optimalAssignments.PositionAssignmentResults[Position.Bench].PlayerAssignmentResults)
                    {
                        var position = rosterPosition.Value.Position;

                        if (position.CanBeFilledBy(playerAssignment.Player))
                        {
                            additionalAvailable++;
                        }
                    }
                }

                var positionDepthResult = new PositionDepthResult()
                {
                    Position = rosterPosition.Value.Position,
                    Depth = DetermineDepth(required, filled + additionalAvailable),
                    PlayerAssignmentResults = positionAssignmentResult.PlayerAssignmentResults
                };
                
                rosterDepthResult.PositionDepthResults[rosterPosition.Value.Position] = positionDepthResult;
            }
            
            return rosterDepthResult;
        }

        public RosterDepthResult GetRosterDepth()
        {
            return this.GetRosterDepth(null);
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
