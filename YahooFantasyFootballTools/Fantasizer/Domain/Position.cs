using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class Position
    {
        internal Position(XElement rosterPositionElement)
        {
            this.Name = rosterPositionElement.Element(YahooXml.XMLNS + "position").Value;

            var positionTypeElement = rosterPositionElement.Element(YahooXml.XMLNS + "position_type");
            if (positionTypeElement != null)
            {
                this.PositionType = positionTypeElement.Value;
            }
        }

        public string Name { get; private set; }
        public string PositionType { get; private set; }
    }
}