using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Domain
{
    public class Matchup
    {
        public Matchup(int week, string teamKeySelf, string teamKeyOpponent)
        {
            this.Week = week;
            this.TeamKeySelf = teamKeySelf;
            this.TeamKeyOpponent = teamKeyOpponent;
        }

        public int Week { get; private set; }
        public string TeamKeySelf { get; private set; }
        public string TeamKeyOpponent { get; private set; }
    }
}
