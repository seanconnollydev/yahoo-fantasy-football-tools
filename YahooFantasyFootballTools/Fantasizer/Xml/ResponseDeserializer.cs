using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
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
            double total = Convert.ToDouble(playerPointsElement.Element(YahooXml.XMLNS + "total").Value);
            return new PlayerPoints(season, total);
        }

        internal static LeagueSettings DeserializeLeagueSettings(XElement leagueElement)
        {
            var settingElement = leagueElement.Element(YahooXml.XMLNS + "settings");

            var rosterPositions = new Dictionary<PositionAbbreviation, RosterPosition>();
            foreach (var rosterPositionElement in settingElement.Descendants(YahooXml.XMLNS + "roster_position"))
            {
                var rosterPosition = ResponseDeserializer.DeserializeRosterPosition(rosterPositionElement);
                rosterPositions.Add(rosterPosition.Position.Abbreviation, rosterPosition);
            }

            var league = ResponseDeserializer.DeserializeLeague(leagueElement);

            return new LeagueSettings(rosterPositions, league);
        }

        internal static League DeserializeLeague(XElement leagueElement)
        {
            int id = Convert.ToInt32(leagueElement.Element(YahooXml.XMLNS + "league_id").Value);
            string name = leagueElement.Element(YahooXml.XMLNS + "name").Value;
            string key = leagueElement.Element(YahooXml.XMLNS + "league_key").Value;

            return new League(id, name, key);
        }

        internal static ICollection<Game> DeserializeGames(XElement gamesElement)
        {
            var games = new List<Game>();
            foreach (var gameElement in gamesElement.Descendants(YahooXml.XMLNS + "game"))
            {
                games.Add(ResponseDeserializer.DeserializeGame(gameElement));
            }

            return games;
        }

        internal static Game DeserializeGame(XElement gameElement)
        {
            string gameCodeStr = gameElement.Element(YahooXml.XMLNS + "code").Value;

            GameCode gameCode;
            if (!Enum.TryParse<GameCode>(gameCodeStr, out gameCode))
            {
                var ex = new Exception("Unrecognized game code");
                ex.Data.Add("code", gameCodeStr);
                throw ex;
            }

            int id = Convert.ToInt32(gameElement.Element(YahooXml.XMLNS + "game_id").Value);
            int season = Convert.ToInt32(gameElement.Element(YahooXml.XMLNS + "season").Value);

            return new Game(gameCode, id, season);
        }
    }
}
