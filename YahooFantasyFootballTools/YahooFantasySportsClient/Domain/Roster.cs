using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace YahooFantasySportsClient.Domain
{
    public class Roster
    {
        private readonly OAuthClient _oAuthClient;
        private readonly Team _team;

        internal Roster(OAuthClient oAuthClient, Team team)
        {
            _oAuthClient = oAuthClient;
            _team = team;
        }

        public IEnumerable<Player> GetPlayers()
        {
            var players = new List<Player>();
            var request = _oAuthClient.PrepareAuthorizedRequest(
                string.Format("http://fantasysports.yahooapis.com/fantasy/v2/team/{0}/roster/players", _team.Key)
            );

            XDocument xmlDoc;
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    xmlDoc = XDocument.Load(responseStream);
                }
            }

            XNamespace ns = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng";

            foreach (var playerElement in xmlDoc.Descendants(ns + "player"))
            {
                players.Add(new Player()
                {
                    Id = Convert.ToInt32(playerElement.Element(ns + "player_id").Value),
                    Key = playerElement.Element(ns + "player_key").Value,
                    Name = playerElement.Element(ns + "name").Element(ns + "full").Value
                });
            }

            return players;
        }
    }
}
