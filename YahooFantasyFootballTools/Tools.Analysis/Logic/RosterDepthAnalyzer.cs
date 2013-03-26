using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;
using Tools.Analysis.Domain;

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
            var availablePlayersMap = DetermineAvailablePlayers(_availablePlayers);
            
            foreach (var rosterPosition in _rosterPositions.Values)
            {
                int availablePlayers;
                if (!availablePlayersMap.TryGetValue(rosterPosition.Position.Name, out availablePlayers))
                {
                    availablePlayers = 0;
                }

                rosterDepthMap[rosterPosition.Position.Name] = DetermineDepth(rosterPosition.Count, availablePlayers);
            }

            return rosterDepthMap;
        }

        private static Dictionary<string, int> DetermineAvailablePlayers(ICollection<Player> availablePlayers)
        {
            // TODO: This needs to be updated to look at flex positions last (i.e. fill up RB, WR, and then RB/WR)
            var availablePlayerMap = new Dictionary<string, int>();

            foreach (var player in availablePlayers)
            {
                foreach (var position in player.EligiblePositions)
                {
                    if (!availablePlayerMap.ContainsKey(position.Name))
                    {
                        availablePlayerMap[position.Name] = 1;
                    }
                    else
                    {
                        availablePlayerMap[position.Name]++;
                    }
                }
            }

            return availablePlayerMap;
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
    }
}
