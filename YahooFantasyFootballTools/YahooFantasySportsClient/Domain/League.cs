using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class League
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        internal static League CreateFromXml(XElement leagueElement)
        {
            return new League()
            {
                Id = Convert.ToInt32(leagueElement.Element(YahooXml.XMLNS + "league_id").Value),
                Name = leagueElement.Element(YahooXml.XMLNS + "name").Value,
                Key = leagueElement.Element(YahooXml.XMLNS + "league_key").Value
            };
        }
    }
}