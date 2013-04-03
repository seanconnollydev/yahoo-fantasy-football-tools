using System.Collections.Generic;

namespace Fantasizer.Domain
{
    public class LeagueSettings
    {
        internal LeagueSettings(IDictionary<PositionAbbreviation, RosterPosition> rosterPositions, League league)
        {
            this.RosterPositions = rosterPositions;
            this.League = league;
        }

        public IDictionary<PositionAbbreviation, RosterPosition> RosterPositions { get; private set; }

        public League League { get; private set; }
    }
}
