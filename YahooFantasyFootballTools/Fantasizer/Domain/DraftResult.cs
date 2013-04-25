using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class DraftResult
    {
        public DraftResult(int pick, int round, string teamKey, string playerKey)
        {
            this.Pick = pick;
            this.Round = round;
            this.TeamKey = teamKey;
            this.PlayerKey = playerKey;
        }

        public int Pick { get; private set; }
        public int Round { get; private set; }
        public string TeamKey { get; private set; }
        public string PlayerKey { get; private set; }
    }
}
