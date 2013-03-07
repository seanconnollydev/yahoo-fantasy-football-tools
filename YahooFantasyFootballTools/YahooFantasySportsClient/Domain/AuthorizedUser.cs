using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class AuthorizedUser
    {
        private readonly OAuthClient _oAuthClient;
        internal AuthorizedUser(OAuthClient oAuthClient)
        {
            _oAuthClient = oAuthClient;
        }

        public IEnumerable<League> GetLeagues()
        {
            var leagues = new List<League>();
            var request = _oAuthClient.PrepareAuthorizedRequest("http://fantasysports.yahooapis.com/fantasy/v2/users;use_login=1/games;game_keys=nfl/leagues");

            XDocument xmlDoc;
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    xmlDoc = XDocument.Load(responseStream);
                }
            }

            XNamespace ns = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng";

            foreach (var leagueElement in xmlDoc.Descendants(ns + "league"))
            {
                leagues.Add(new League(_oAuthClient)
                {
                    Id = Convert.ToInt32(leagueElement.Element(ns + "league_id").Value),
                    Name = leagueElement.Element(ns + "name").Value,
                    Key = leagueElement.Element(ns + "league_key").Value
                });
            }

            return leagues;
        }
    }
}
