using System;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class RosterPosition
    {
        internal RosterPosition(XElement rosterPositionElement)
        {
            this.Position = new Position(rosterPositionElement);
            this.Count = Convert.ToInt32(rosterPositionElement.Element(YahooXml.XMLNS + "count").Value);
        }

        public Position Position { get; private set; }

        public int Count { get; set; }
    }
}
