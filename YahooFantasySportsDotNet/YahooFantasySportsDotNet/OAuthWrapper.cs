using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OAuth.Messages;
using DotNetOpenAuth.OAuth.ChannelElements;

namespace YahooFantasySportsDotNet
{
    public class OAuthWrapper
    {
        private string _requestToken = "";

        public WebConsumer Consumer { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }

        public OAuthWrapper(HttpSessionStateBase sessionState, string consumerKey, string consumerSecret)
        {
            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;

            this.Consumer = new WebConsumer(YahooFantasySportsService.Description, new SessionStateTokenManager(sessionState, this.ConsumerKey, this.ConsumerSecret));
        }

        public void BeginAuth(Uri callback)
        {
            // TODO: This should probably redirect to a proper callback
            var request = this.Consumer.PrepareRequestUserAuthorization(callback, null, null);
            this.Consumer.Channel.Respond(request);
        }

        public string CompleteAuth()
        {
            var response = this.Consumer.ProcessUserAuthorization();
            return response.AccessToken;
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