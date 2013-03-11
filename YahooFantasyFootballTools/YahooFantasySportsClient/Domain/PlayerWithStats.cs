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

        internal PlayerWithStats() { }

        internal PlayerWithStats(XElement playerElement)
            : base(playerElement)
        {
            Load(playerElement);   
        }

        protected internal override void Load(XElement playerElement)
        {
            base.Load(playerElement);
            this.Points = new PlayerPoints(playerElement.Element(YahooXml.XMLNS + "player_points"));
        }
    }
}
