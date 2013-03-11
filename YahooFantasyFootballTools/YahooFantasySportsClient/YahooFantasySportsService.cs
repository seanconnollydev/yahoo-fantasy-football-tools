using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;
using System.Xml.Linq;

namespace Fantasizer
{
    public class YahooFantasySportsService
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private OAuthClient _oAuthClient;

        private ApiClient _apiClient;
        private ApiClient ApiClient
        {
            get
            {
                if (_apiClient == null)
                {
                    _apiClient = new ApiClient(_oAuthClient);
                }

                return _apiClient;
            }
        }

        public YahooFantasySportsService(string consumerKey, string consumerSecret, IUserTokenStore userTokenStore)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _oAuthClient = new OAuthClient(userTokenStore, consumerKey, consumerSecret);
        }

        public void BeginAuthorization(Uri callback)
        {
            _oAuthClient.BeginAuth(callback);
        }

        public void CompleteAuthorization()
        {
            _oAuthClient.CompleteAuth();
        }

        public Team GetTeam(string teamKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/team/{0}", teamKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return Team.CreateFromXml(xml.Root.Element(YahooXml.XMLNS + "team"));
        }

        public LeagueTeamCollection GetTeams(string leagueKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/league/{0}/teams", leagueKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return LeagueTeamCollection.CreateFromXml(xml);
        }

        public LeagueCollection GetLeagues()
        {
            // TODO: Make game_keys a parameter
            string requestUri = "http://fantasysports.yahooapis.com/fantasy/v2/users;use_login=1/games;game_keys=nfl/leagues";
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return LeagueCollection.CreateFromXml(xml);
        }

        public LeagueDraftResultCollection GetDraftResults(string leagueKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/league/{0}/draftresults", leagueKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return LeagueDraftResultCollection.CreateFromXml(xml);
        }

        public TeamRosterPlayerCollection GetRosterPlayers(string teamKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/team/{0}/roster/players", teamKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return TeamRosterPlayerCollection.CreateFromXml(xml);
        }

        public TeamPlayerCollection<PlayerWithStats> GetTeamPlayerStats(string teamKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/team/{0}/players/stats", teamKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return new TeamPlayerCollection<PlayerWithStats>(xml);
        }
    }
}
