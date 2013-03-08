using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class Player
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }

        internal static Player CreateFromXml(XElement playerElement)
        {
            return new Player()
            {
                Id = Convert.ToInt32(playerElement.Element(YahooXml.XMLNS + "player_id").Value),
                Key = playerElement.Element(YahooXml.XMLNS + "player_key").Value,
                Name = playerElement.Element(YahooXml.XMLNS + "name").Element(YahooXml.XMLNS + "full").Value
            };
        }
    }
}
