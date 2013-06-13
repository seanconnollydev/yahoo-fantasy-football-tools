using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;

namespace Tools.Analysis.Domain
{
    public class RosterDepthResult
    {
        public RosterDepthResult()
        {
            this.PositionDepthResults = new Dictionary<Position, PositionDepthResult>();
        }

        public IDictionary<Position, PositionDepthResult> PositionDepthResults { get; private set; }
        
    }

    public class PositionDepthResult
    {
        public Position Position { get; internal set; }
        public PositionDepth Depth { get; internal set; }
        public IList<PlayerAssignmentResult> PlayerAssignmentResults { get; internal set; }
    }
}
