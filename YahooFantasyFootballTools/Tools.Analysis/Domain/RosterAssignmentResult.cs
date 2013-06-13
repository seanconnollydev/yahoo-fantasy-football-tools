using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;

namespace Tools.Analysis.Domain
{
    public class RosterAssignmentResult
    {
        public RosterAssignmentResult()
        {
            this.PositionAssignmentResults = new Dictionary<Position, PositionAssignmentResult>();
        }

        public IDictionary<Position, PositionAssignmentResult> PositionAssignmentResults { get; private set; }
    }

    public class PositionAssignmentResult
    {
        public PositionAssignmentResult()
        {
            this.PlayerAssignmentResults = new List<PlayerAssignmentResult>();
        }

        public Position Position { get; internal set; }
        public IList<PlayerAssignmentResult> PlayerAssignmentResults {get; private set;}
        public int Filled
        {
            get
            {
                return this.PlayerAssignmentResults.Count<PlayerAssignmentResult>(
                    r => r.Reason != PlayerAssignmentResultReason.ByeWeek);
            }
        }
    }

    public class PlayerAssignmentResult
    {
        public Player Player { get; internal set; }
        public PlayerAssignmentResultReason Reason { get; internal set; }
    }

    public enum PlayerAssignmentResultReason
    {
        Optimal,
        ByeWeek
    }
}
