using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class PlayerWithStats : Player
    {
        public PlayerStats Stats { get; private set; }
        public PlayerPoints Points { get; private set; }

        public PlayerWithStats(Player player, PlayerStats stats, PlayerPoints points)
            : base(player)
        {
            this.Stats = stats;
            this.Points = points;
        }
    }
}
