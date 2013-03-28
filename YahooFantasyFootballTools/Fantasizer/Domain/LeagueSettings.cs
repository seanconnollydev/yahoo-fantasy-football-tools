using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Linq;
using Fantasizer.Xml;

namespace Fantasizer.Domain
{
    public class LeagueSettings
    {
        
        internal LeagueSettings(XElement settingElement)
        {
            _rosterPositions = new Dictionary<string, RosterPosition>();

            foreach (var rosterPositionElement in settingElement.Descendants(YahooXml.XMLNS + "roster_position"))
            {
                var rosterPosition = ResponseDeserializer.DeserializeRosterPosition(rosterPositionElement);
                _rosterPositions.Add(rosterPosition.Position.Name, rosterPosition);
            }
        }

        private readonly Dictionary<string, RosterPosition> _rosterPositions;
        public IDictionary<string, RosterPosition> RosterPositions
        {
            get { return _rosterPositions; }
        }
    }
}
