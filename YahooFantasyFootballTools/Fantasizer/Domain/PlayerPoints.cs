using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class PlayerPoints
    {
        public int Season { get; private set; }
        public int Total { get; private set; }

        internal PlayerPoints(XElement playerPointsElement)
        {
            this.Season = Convert.ToInt32(playerPointsElement.Element(YahooXml.XMLNS + "season").Value);
            this.Total = Convert.ToInt32(playerPointsElement.Element(YahooXml.XMLNS + "total").Value);
        }
    }
}
