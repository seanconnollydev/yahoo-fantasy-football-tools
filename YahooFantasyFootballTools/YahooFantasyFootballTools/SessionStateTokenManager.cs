using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OAuth.ChannelElements;
using DotNetOpenAuth.OAuth.Messages;
using DotNetOpenAuth.OpenId.Extensions.OAuth;

namespace YahooFantasyFootballTools
{
    //TODO: This should probably be at application scope instead of session state scope (though a more persistent store is really appropriate)
    public class SessionStateTokenManager : IConsumerTokenManager, IOpenIdOAuthTokenManager
    {
        private HttpSessionStateBase _sessionState;
        private const string TOKENS_AND_SECRETS_DICTIONARY_KEY = "T_S_DICTIONARY";

        private Dictionary<string, string> TokensAndSecrets
        {
            get
            {
                return (Dictionary<string,string>)_sessionState[TOKENS_AND_SECRETS_DICTIONARY_KEY];
            }
            set
            {
                _sessionState[TOKENS_AND_SECRETS_DICTIONARY_KEY] = value;
            }
        }

        public SessionStateTokenManager(HttpSessionStateBase sessionState, string consumerKey, string consumerSecret)
        {
            // TODO: parameter checks
            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;

            _sessionState = sessionState;
            InitializeSessionStateIfNecessary();
        }

        public string ConsumerKey
        {
            get;
            private set;
        }

        public string ConsumerSecret
        {
            get;
            private set;
        }

        public void ExpireRequestTokenAndStoreNewAccessToken(string consumerKey, string requestToken, string accessToken, string accessTokenSecret)
        {
            TokensAndSecrets.Remove(requestToken);
            TokensAndSecrets[accessToken] = accessTokenSecret;
        }

        public string GetTokenSecret(string token)
        {
            return TokensAndSecrets[token];
        }

        public TokenType GetTokenType(string token)
        {
            throw new NotImplementedException();
        }

        public void StoreNewRequestToken(UnauthorizedTokenRequest request, ITokenSecretContainingMessage response)
        {
            TokensAndSecrets[response.Token] = response.TokenSecret;
        }

        public void StoreOpenIdAuthorizedRequestToken(string consumerKey, AuthorizationApprovedResponse authorization)
        {
            TokensAndSecrets[authorization.RequestToken] = String.Empty;
        }

        private void InitializeSessionStateIfNecessary()
        {
            if (TokensAndSecrets == null)
            {
                TokensAndSecrets = new Dictionary<string, string>();
            }
        }
    }
}