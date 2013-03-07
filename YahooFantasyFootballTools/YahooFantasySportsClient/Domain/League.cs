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

        private readonly OAuthClient _oAuthClient;
        internal League(OAuthClient oAuthClient)
        {
            _oAuthClient = oAuthClient;
        }

        public IEnumerable<Team> GetTeams()
        {
            var teams = new List<Team>();
            var request = _oAuthClient.PrepareAuthorizedRequest(
                string.Format("http://fantasysports.yahooapis.com/fantasy/v2/league/{0}/teams", this.Key)
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

            foreach (var teamElement in xmlDoc.Descendants(ns + "team"))
            {
                teams.Add(new Team(_oAuthClient)
                {
                    Id = Convert.ToInt32(teamElement.Element(ns + "team_id").Value),
                    Key = teamElement.Element(ns + "team_key").Value,
                    Name = teamElement.Element(ns + "name").Value
                });
            }

            return teams;
        }

        public IEnumerable<DraftResult> GetDraftResults()
        {
            var draftResults = new List<DraftResult>();

            var request = _oAuthClient.PrepareAuthorizedRequest(
                string.Format("http://fantasysports.yahooapis.com/fantasy/v2/league/{0}/draftresults", this.Key)
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

            foreach (var draftResult in xmlDoc.Descendants(ns + "draft_result"))
            {
                draftResults.Add(new DraftResult()
                {
                    Pick = Convert.ToInt32(draftResult.Element(ns + "pick").Value),
                    Round = Convert.ToInt32(draftResult.Element(ns + "round").Value),
                    TeamKey = draftResult.Element(ns + "team_key").Value,
                    PlayerKey = draftResult.Element(ns + "player_key").Value
                });
            }

            return draftResults;
        }
    }
}
