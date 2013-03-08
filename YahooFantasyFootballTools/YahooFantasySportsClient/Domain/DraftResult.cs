using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class DraftResult
    {
        public int Pick { get; set; }
        public int Round { get; set; }
        public string TeamKey { get; set; }
        public string PlayerKey { get; set; }

        internal static DraftResult CreateFromXml(XElement draftResultElement)
        {
            return new DraftResult()
            {
                Pick = Convert.ToInt32(draftResultElement.Element(YahooXml.XMLNS + "pick").Value),
                Round = Convert.ToInt32(draftResultElement.Element(YahooXml.XMLNS + "round").Value),
                TeamKey = draftResultElement.Element(YahooXml.XMLNS + "team_key").Value,
                PlayerKey = draftResultElement.Element(YahooXml.XMLNS + "player_key").Value
            };
        }
    }
}
