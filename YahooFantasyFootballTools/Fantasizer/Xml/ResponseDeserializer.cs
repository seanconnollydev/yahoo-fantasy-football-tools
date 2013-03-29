using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Fantasizer.Domain;

namespace Fantasizer.Xml
{
    internal static class ResponseDeserializer
    {
        internal static T Deserialize<T>(XElement rootElement)
        {
            Type type = typeof (T);

            if (type == typeof (Player))
            {
                return (T)(object)ResponseDeserializer.DeserializePlayer(rootElement);
            }
            else if (type == typeof (PlayerWithStats))
            {
                return (T)(object)ResponseDeserializer.DeserializePlayerWithStats(rootElement);
            }

            throw new Exception("Unable to deserialize type.");
        }

        internal static RosterPosition DeserializeRosterPosition(XElement rosterPositionElement)
        {
            var position = ResponseDeserializer.DeserializePosition(rosterPositionElement);
            int count = Convert.ToInt32(rosterPositionElement.Element(YahooXml.XMLNS + "count").Value);

            return new RosterPosition(position, count);
        }

        internal static Position DeserializePosition(XElement rosterPositionElement)
        {
            string name = rosterPositionElement.Element(YahooXml.XMLNS + "position").Value;
            return Position.GetPosition(name);
        }

        private static Player DeserializePlayer(XElement playerElement)
        {
            int id = Convert.ToInt32(playerElement.Element(YahooXml.XMLNS + "player_id").Value);
            string key = playerElement.Element(YahooXml.XMLNS + "player_key").Value;
            string name = playerElement.Element(YahooXml.XMLNS + "name").Element(YahooXml.XMLNS + "full").Value;

            var eligiblePositions = new List<Position>();
            foreach (var positionElement in playerElement.Elements(YahooXml.XMLNS + "eligible_positions"))
            {
                eligiblePositions.Add(ResponseDeserializer.DeserializePosition(positionElement));
            }

            return new Player(id, key, name, eligiblePositions);
        }

        private static PlayerWithStats DeserializePlayerWithStats(XElement playerElement)
        {
            var player = DeserializePlayer(playerElement);
            var points = DeserializePlayerPoints(playerElement.Element(YahooXml.XMLNS + "player_points"));

            return new PlayerWithStats(player, null, points);
        }

        internal static PlayerPoints DeserializePlayerPoints(XElement playerPointsElement)
        {
            int season = Convert.ToInt32(playerPointsElement.Element(YahooXml.XMLNS + "season").Value);
            int total = Convert.ToInt32(playerPointsElement.Element(YahooXml.XMLNS + "total").Value);
            return new PlayerPoints(season, total);
        }
    }
}
