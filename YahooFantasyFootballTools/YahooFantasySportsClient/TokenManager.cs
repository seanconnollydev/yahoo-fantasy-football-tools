using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OAuth.ChannelElements;
using DotNetOpenAuth.OAuth.Messages;
using DotNetOpenAuth.OpenId.Extensions.OAuth;

namespace YahooFantasySportsClient
{
    /// <summary>
    /// OAuth token manager implementation that leaves storage of tokens and secrets to the client.
    /// </summary>
    public class TokenManager : IConsumerTokenManager, IOpenIdOAuthTokenManager
    {
        private readonly IDictionary<string, string> _tokensAndSecrets;

        public TokenManager(IDictionary<string, string> tokensAndSecrets, string consumerKey, string consumerSecret)
        {
            // TODO: parameter checks
            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;

            _tokensAndSecrets = tokensAndSecrets;
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
            _tokensAndSecrets.Remove(requestToken);
            _tokensAndSecrets[accessToken] = accessTokenSecret;
        }

        public string GetTokenSecret(string token)
        {
            return _tokensAndSecrets[token];
        }

        public TokenType GetTokenType(string token)
        {
            throw new NotImplementedException();
        }

        public void StoreNewRequestToken(UnauthorizedTokenRequest request, ITokenSecretContainingMessage response)
        {
            _tokensAndSecrets[response.Token] = response.TokenSecret;
        }

        public void StoreOpenIdAuthorizedRequestToken(string consumerKey, AuthorizationApprovedResponse authorization)
        {
            _tokensAndSecrets[authorization.RequestToken] = String.Empty;
        }
    }
}