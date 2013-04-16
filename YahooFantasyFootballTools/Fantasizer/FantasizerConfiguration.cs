using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth.ChannelElements;

namespace Fantasizer
{
    internal static class FantasizerConfiguration
    {
        internal static readonly ServiceProviderDescription Description = new ServiceProviderDescription()
        {
            RequestTokenEndpoint = new MessageReceivingEndpoint("https://api.login.yahoo.com/oauth/v2/get_request_token", HttpDeliveryMethods.PostRequest),
            UserAuthorizationEndpoint = new MessageReceivingEndpoint("https://api.login.yahoo.com/oauth/v2/request_auth", HttpDeliveryMethods.GetRequest),
            AccessTokenEndpoint = new MessageReceivingEndpoint("https://api.login.yahoo.com/oauth/v2/get_token", HttpDeliveryMethods.GetRequest),
            TamperProtectionElements = new ITamperProtectionChannelBindingElement[] {
                new HmacSha1SigningBindingElement()
            }
        };
    }
}