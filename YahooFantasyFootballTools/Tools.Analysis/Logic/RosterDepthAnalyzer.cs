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
        private readonly IDictionary<string, RosterPosition> _rosterPositions;
        private readonly ICollection<Player> _availablePlayers;
        
        public RosterDepthAnalyzer(IDictionary<string, RosterPosition> rosterPositions, ICollection<Player> availablePlayers)
        {
            _rosterPositions = rosterPositions;
            _availablePlayers = availablePlayers;
        }

        /// <summary>
        /// Determine roster depth by position.
        /// </summary>
        /// <returns>A dictionary keyed off of position (e.g. QB, RB, etc.)</returns>
        public IDictionary<string, RosterDepth> GetRosterDepth()
        {
            var rosterDepthMap = new Dictionary<string, RosterDepth>();
            var remainingPlayers = _availablePlayers.ToList();
            var rosterPositionAvailabilityMap = new Dictionary<string, RosterPositionAvailability>();

            var trimmedRosterPositions = new Dictionary<string, RosterPosition>(_rosterPositions);
            trimmedRosterPositions.Remove("BN");
            var sortedRosterPositions = trimmedRosterPositions.OrderBy(i => i.Value.Position, new PositionComparer());

            // First fill all positions
            foreach (var rosterPosition in sortedRosterPositions)
            {
                var rosterPositionAvailability = new RosterPositionAvailability(rosterPosition.Value.Count);

                for (int i = remainingPlayers.Count - 1; i >= 0; i--)
                {
                    if (rosterPosition.Value.Position.CanBeFilledBy(remainingPlayers[i]))
                    {
                        remainingPlayers.Remove(remainingPlayers[i]);
                        rosterPositionAvailability.Available++;
                    }

                    if (rosterPositionAvailability.Available >= rosterPositionAvailability.Required)
                        break;
                }

                rosterPositionAvailabilityMap[rosterPosition.Key] = rosterPositionAvailability;
            }

            // Now determine what positions are left over
            foreach (var player in remainingPlayers)
            {
                foreach (var eligiblePosition in player.EligiblePositions)
                {
                    rosterPositionAvailabilityMap[eligiblePosition.Name].Available++;
                }
            }

            // Now determine depth
            foreach (var rosterPosition in trimmedRosterPositions)
            {
                var availability = rosterPositionAvailabilityMap[rosterPosition.Key];
                rosterDepthMap.Add(rosterPosition.Key, DetermineDepth(availability.Required, availability.Available));
            }

            return rosterDepthMap;
        }

        private static RosterDepth DetermineDepth(int required, int available)
        {
            int delta = required - available;

            if (delta >= 2)
                return RosterDepth.VeryShallow;
            else if (delta == 1)
                return RosterDepth.Shallow;
            else if (delta == 0)
                return RosterDepth.Adequate;
            else if (delta == -1)
                return RosterDepth.Deep;
            else if (delta <= 2)
                return RosterDepth.VeryDeep;
            else
            {
                var ex = new Exception("Could not determine depth based.");
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
                // TODO: At some point, update this to go from most specific (e.g. RB) to least (e.g. W/R/T)
                if (x.Name.Equals(y.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return 0;
                }
                else
                {
                    return x.IsFlex() ? 1 : -1;    
                }
            }
        }

        private class RosterPositionAvailability
        {
            public RosterPositionAvailability(int required)
            {
                this.Required = required;
            }

            public int Required { get; set; }
            public int Available { get; set; }
        }
    }
}
