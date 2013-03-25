using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class LeagueSettings
    {
        
        internal LeagueSettings(XElement settingElement)
        {
            _rosterPositions = new List<RosterPosition>();

            foreach (var rosterPositionElement in settingElement.Descendants(YahooXml.XMLNS + "roster_position"))
            {
                _rosterPositions.Add(new RosterPosition(rosterPositionElement));
            }
        }

        private readonly List<RosterPosition> _rosterPositions;
        public ICollection<RosterPosition> RosterPositions
        {
            get { return _rosterPositions; }
        }
    }
}
