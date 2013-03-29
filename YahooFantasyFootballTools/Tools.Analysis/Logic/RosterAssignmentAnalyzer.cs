using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;

namespace Tools.Analysis.Logic
{
    public class RosterAssignmentAnalyzer
    {
        private readonly IDictionary<PositionAbbreviation, RosterPosition> _rosterPositions;
        private readonly ICollection<Player> _availablePlayers;

        public RosterAssignmentAnalyzer(IDictionary<PositionAbbreviation, RosterPosition> rosterPositions, ICollection<Player> availablePlayers)
        {
            if (availablePlayers.Count > rosterPositions.Sum(rp => rp.Value.Count))
            {
                throw new ArgumentException("There are more players than roster positions available.");
            }

            _rosterPositions = rosterPositions;
            _availablePlayers = availablePlayers;
        }

        public IDictionary<Position, ICollection<Player>> GetOptimalAssignment()
        {
            // Determine possible players for each position
            var assignments = DeterminePossiblePlayerAssignments();

            // Sort positions from most to least restrictive
            var orderedAssignments = Sort(assignments);

            // Start making assignments
            return AssignPlayers(orderedAssignments);
        }

        private IDictionary<RosterPosition, Queue<Player>> DeterminePossiblePlayerAssignments()
        {
            var assignments = new Dictionary<RosterPosition, Queue<Player>>();

            foreach (var rosterPosition in _rosterPositions)
            {
                var possiblePlayers = new Queue<Player>();
                foreach (var player in _availablePlayers)
                {
                    if (rosterPosition.Value.Position.CanBeFilledBy(player))
                    {
                        possiblePlayers.Enqueue(player);
                    }
                }

                assignments[rosterPosition.Value] = possiblePlayers;
            }

            return assignments;
        }

        private IOrderedEnumerable<KeyValuePair<RosterPosition, Queue<Player>>> Sort(
            IDictionary<RosterPosition, Queue<Player>> assignments)
        {
            return assignments.OrderBy(kv => kv.Value.Count - kv.Key.Count);
        }

        private IDictionary<Position, ICollection<Player>> AssignPlayers(
            IOrderedEnumerable<KeyValuePair<RosterPosition, Queue<Player>>> orderedAssignments)
        {
            var finalAssignments = new Dictionary<Position, ICollection<Player>>();
            List<Player> availablePlayers = _availablePlayers.ToList();

            foreach (var assignment in orderedAssignments)
            {
                var rosterPosition = assignment.Key;
                var playerQueue = assignment.Value;
                var assignedPlayers = new List<Player>();

                int required = rosterPosition.Count;

                while(required > 0 && playerQueue.Count > 0)
                {
                    var player = playerQueue.Dequeue();
                    if (availablePlayers.Contains(player))
                    {
                        assignedPlayers.Add(player);
                        availablePlayers.Remove(player);
                        required--;
                    }
                }

                finalAssignments[rosterPosition.Position] = assignedPlayers;
            }

            // Remaining players go on the bench
            foreach (var player in availablePlayers)
            {
                finalAssignments[Position.Bench].Add(player);
            }

            return finalAssignments;
        }
    }
}
