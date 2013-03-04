using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using YahooFantasySportsClient;

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
        private SessionStateUserTokenStore(HttpSessionState sessionState)
        {
            _sessionState = sessionState;
        }

        private static SessionStateUserTokenStore _current;
        internal static SessionStateUserTokenStore Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SessionStateUserTokenStore(HttpContext.Current.Session);
                }

                return _current;
            }
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
    }
}