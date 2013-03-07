using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.Messages;
using DotNetOpenAuth.OAuth.ChannelElements;
using System.Net;
using DotNetOpenAuth.Messaging;

namespace Fantasizer
{
    /// <summary>
    /// 
    /// </summary>
    public class OAuthClient
    {
        private readonly IUserTokenStore _userTokenStore;

        public WebConsumer Consumer { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }

        public OAuthClient(IUserTokenStore userTokenStore, string consumerKey, string consumerSecret)
        {
            _userTokenStore = userTokenStore;

            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;

            this.Consumer = new WebConsumer(YahooFantasySportsConfiguration.Description, new UserTokenManager(_userTokenStore, this.ConsumerKey, this.ConsumerSecret));
        }

        public void BeginAuth(Uri callback)
        {
            var request = this.Consumer.PrepareRequestUserAuthorization(callback, null, null);
            this.Consumer.Channel.Respond(request);
        }

        public void CompleteAuth()
        {
            this.Consumer.ProcessUserAuthorization();
        }

        public WebRequest PrepareAuthorizedRequest(string uri)
        {
            return this.Consumer.PrepareAuthorizedRequest(
                new MessageReceivingEndpoint(
                    uri,
                    HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
                _userTokenStore.AccessToken);
        }

        public IConsumerTokenManager TokenManager
        {
            get
            {
                return this.Consumer.TokenManager;
            }
        }
    }
}