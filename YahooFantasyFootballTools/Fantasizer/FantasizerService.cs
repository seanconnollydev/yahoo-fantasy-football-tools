using System;
using System.Collections.Generic;
using Fantasizer.Domain;
using System.Xml.Linq;
using Fantasizer.Xml;

namespace Fantasizer
{
    internal class FantasizerService : IFantasizerService
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

        public FantasizerService(string consumerKey, string consumerSecret, IUserTokenStore userTokenStore)
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

        public XDocument ExecuteRawRequest(string requestUri)
        {
            return this.ApiClient.ExecuteRequest(requestUri);
        }

        public Team GetTeam(string teamKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/team/{0}", teamKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return ResponseDeserializer.DeserializeTeam(xml.Root.Element(YahooXml.XMLNS + "team"));
        }

        public LeagueTeamCollection GetTeams(string leagueKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/league/{0}/teams", leagueKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return LeagueTeamCollection.CreateFromXml(xml);
        }

        public LeagueTeamPlayerCollection<Player> GetLeagueTeamPlayers(string leagueKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/league/{0}/teams/players", leagueKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return ResponseDeserializer.DeserializeLeagueTeamPlayerCollection<Player>(xml.Root.Element(YahooXml.XMLNS + "league"));
        }

        public LeagueCollection GetLeagues(GameCode gameCode)
        {
            string gameKey = Enum.GetName(typeof(GameCode), gameCode);
            return GetLeagues(gameKey);
        }

        public LeagueCollection GetLeagues(int gameId)
        {
            string gameKey = Convert.ToString(gameId);
            return GetLeagues(gameKey);
        }

        private LeagueCollection GetLeagues(string gameKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/users;use_login=1/games;game_keys={0}/leagues", gameKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return LeagueCollection.CreateFromXml(xml);
        }

        public LeagueDraftResultCollection GetDraftResults(string leagueKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/league/{0}/draftresults", leagueKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return LeagueDraftResultCollection.CreateFromXml(xml);
        }

        public TeamRosterPlayerCollection GetRosterPlayers(string teamKey, int? week)
        {
            string requestUri;
            if (week.HasValue)
            {
                requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/team/{0}/roster;week={1}/players", teamKey, week.Value);
            }
            else
            {
                requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/team/{0}/roster/players", teamKey);
            }

            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return ResponseDeserializer.DeserializeTeamRosterPlayerCollection(xml.Root.Element(YahooXml.XMLNS + "team"));
        }

        public TeamPlayerCollection<PlayerWithStats> GetTeamPlayerStats(string teamKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/team/{0}/players/stats", teamKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return ResponseDeserializer.DeserializeTeamPlayerCollection<PlayerWithStats>(xml.Root.Element(YahooXml.XMLNS + "team"));
        }

        public LeagueSettings GetLeagueSettings(string leagueKey)
        {
            string requestUri = string.Format("http://fantasysports.yahooapis.com/fantasy/v2/league/{0}/settings", leagueKey);
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return ResponseDeserializer.DeserializeLeagueSettings(xml.Root.Element(YahooXml.XMLNS + "league"));
        }

        public ICollection<Game> GetGames()
        {
            string requestUri = "http://fantasysports.yahooapis.com/fantasy/v2/users;use_login=1/games";
            var xml = this.ApiClient.ExecuteRequest(requestUri);
            return ResponseDeserializer.DeserializeGames(xml.Root
                .Element(YahooXml.XMLNS + "users")
                .Element(YahooXml.XMLNS + "user")
                .Element(YahooXml.XMLNS + "games"));
        }
    }
}
