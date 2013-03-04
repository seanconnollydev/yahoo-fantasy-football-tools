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
    /// OAuth token manager implementation for a single user that leaves storage implementation to the client.
    /// </summary>
    public class UserTokenManager : IConsumerTokenManager, IOpenIdOAuthTokenManager
    {
        private readonly IUserTokenStore _userTokenStore;

        public UserTokenManager(IUserTokenStore userTokenStore, string consumerKey, string consumerSecret)
        {
            if (userTokenStore == null)
            {
                throw new ArgumentNullException("A userTokenStore implementation is required for OAuth authentication.");
            }

            if (string.IsNullOrEmpty(consumerKey))
            {
                throw new ArgumentNullException("A valid consumerKey is required for OAuth authentication.");
            }

            if (string.IsNullOrEmpty(consumerSecret))
            {
                throw new ArgumentNullException("A valid consumerSecret is required for OAuth authentication.");
            }

            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;
            _userTokenStore = userTokenStore;
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
            _userTokenStore.AccessToken = accessToken;
            _userTokenStore.AccessTokenSecret = accessTokenSecret;
        }

        public string GetTokenSecret(string token)
        {
            return _userTokenStore.AccessTokenSecret;
        }

        public TokenType GetTokenType(string token)
        {
            throw new NotImplementedException();
        }

        public void StoreNewRequestToken(UnauthorizedTokenRequest request, ITokenSecretContainingMessage response)
        {
            _userTokenStore.AccessToken = response.Token;
            _userTokenStore.AccessTokenSecret = response.TokenSecret;
        }

        public void StoreOpenIdAuthorizedRequestToken(string consumerKey, AuthorizationApprovedResponse authorization)
        {
            throw new NotImplementedException();
        }
    }
}