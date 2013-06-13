using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;
using Tools.Analysis.Domain;

namespace Tools.Analysis.Logic
{
    public class RosterAssignmentAnalyzer
    {
        private readonly IDictionary<PositionAbbreviation, RosterPosition> _rosterPositions;
        private readonly ICollection<Player> _availablePlayers;
        private readonly int? _week;
        private RosterAssignmentResult _result;

        public RosterAssignmentAnalyzer(
            IDictionary<PositionAbbreviation, RosterPosition> rosterPositions,
            ICollection<Player> availablePlayers,
            int? week)
        {
            if (availablePlayers.Count > rosterPositions.Sum(rp => rp.Value.Count))
            {
                throw new ArgumentException("There are more players than roster positions available.");
            }

            _rosterPositions = rosterPositions;
            _availablePlayers = availablePlayers;
            _week = week;
            _result = new RosterAssignmentResult();
        }

        public RosterAssignmentResult GetOptimalAssignment()
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
                        if (_week.HasValue && player.ByeWeeks.Contains(_week.Value))
                        {
                            var playerAssignmentResult = new PlayerAssignmentResult()
                            {
                                Player = player,
                                Reason = PlayerAssignmentResultReason.ByeWeek
                            };

                            // TODO: I need to change this logic so that this position result does not get overwritten later.
                            var positionAssignmentResult = new PositionAssignmentResult();
                            positionAssignmentResult.Position = rosterPosition.Value.Position;
                            positionAssignmentResult.PlayerAssignmentResults.Add(playerAssignmentResult);

                            _result.PositionAssignmentResults[rosterPosition.Value.Position] = positionAssignmentResult;
                                
                        }
                        else
                        {
                            possiblePlayers.Enqueue(player);
                        }
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

        private RosterAssignmentResult AssignPlayers(
            IOrderedEnumerable<KeyValuePair<RosterPosition, Queue<Player>>> orderedAssignments)
        {
            List<Player> availablePlayers = _availablePlayers.ToList();

            foreach (var assignment in orderedAssignments)
            {
                var positionAssignmentResult = new PositionAssignmentResult();

                var rosterPosition = assignment.Key;
                var playerQueue = assignment.Value;
                int required = rosterPosition.Count;

                while(required > 0 && playerQueue.Count > 0)
                {
                    var player = playerQueue.Dequeue();
                    if (availablePlayers.Contains(player))
                    {
                        positionAssignmentResult.PlayerAssignmentResults.Add(
                            new PlayerAssignmentResult()
                            {
                                Player = player,
                                Reason = PlayerAssignmentResultReason.Optimal
                            });

                        availablePlayers.Remove(player);
                        required--;
                    }
                }

                _result.PositionAssignmentResults[rosterPosition.Position] = positionAssignmentResult;
            }

            // Remaining players go on the bench
            foreach (var player in availablePlayers)
            {
                _result.PositionAssignmentResults[Position.Bench].PlayerAssignmentResults.Add(
                    new PlayerAssignmentResult()
                    {
                        Player = player,
                        Reason = PlayerAssignmentResultReason.Optimal
                    });
            }

            return _result;
        }
    }
}
