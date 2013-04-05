using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Fantasizer;

namespace YahooFantasyFootballTools
{
    /// <summary>
    /// Stores OAuth token and secret storage for a single user across discrete web requests.
    /// </summary>
    public class SessionStateUserTokenStore : IUserTokenStore
    {
        private const string ACCESS_TOKEN_KEY = "ACCESS_TOKEN_KEY";
        private const string ACCESS_TOKEN_SECRET_KEY = "ACCESS_TOKEN_SECRET_KEY";

        private readonly HttpSessionState _sessionState;
        public SessionStateUserTokenStore(HttpSessionState sessionState)
        {
            _sessionState = sessionState;
        }

        public string AccessToken
        {
            get
            {
                return (string)_sessionState[ACCESS_TOKEN_KEY];
            }
            set
            {
                _sessionState[ACCESS_TOKEN_KEY] = value;
            }
        }

        public string AccessTokenSecret
        {
            get
            {
                return (string)_sessionState[ACCESS_TOKEN_SECRET_KEY];
            }
            set
            {
                _sessionState[ACCESS_TOKEN_SECRET_KEY] = value;
            }
        }

        public bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(this.AccessToken) && !string.IsNullOrEmpty(this.AccessTokenSecret);
        }
    }
}