using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class Player
    {
        public int Id { get; private set; }
        public string Key { get; private set; }
        public string Name { get; private set; }

        internal Player() { }

        internal Player(XElement playerElement)
        {
            Load(playerElement);
        }

        protected internal virtual void Load(XElement playerElement)
        {
            this.Id = Convert.ToInt32(playerElement.Element(YahooXml.XMLNS + "player_id").Value);
            this.Key = playerElement.Element(YahooXml.XMLNS + "player_key").Value;
            this.Name = playerElement.Element(YahooXml.XMLNS + "name").Element(YahooXml.XMLNS + "full").Value;
        }
    }
}
