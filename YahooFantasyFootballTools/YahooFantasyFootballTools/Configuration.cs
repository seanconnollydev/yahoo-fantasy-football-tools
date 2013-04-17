using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace YahooFantasyFootballTools
{
    public class Configuration : IApplicationConfiguration
    {
        public string ConsumerKey
        {
            get { return Get<string>("YahooConsumerKey"); }
        }

        public string ConsumerSecret
        {
            get { return Get<string>("YahooConsumerSecret"); }
        }

        public YahooCallbackUriType YahooCallbackUriType
        {
            get
            { 
                var configurationValue = Get<string>("YahooCallbackUriType");
                switch (configurationValue)
                {
                    case "Host":
                        return YahooCallbackUriType.Host;
                    case "Authority":
                        return YahooCallbackUriType.Authority;
                    default:
                        throw new Exception("Unrecognized YahooCallbackUriType specificed in Web.config.");
                }
            }
        }

        private static T Get<T>(string key)
        {
            string configValue = WebConfigurationManager.AppSettings[key];
            if (string.Equals(configValue, "{ENV}", StringComparison.OrdinalIgnoreCase))
            {
                return (T)Convert.ChangeType(Environment.GetEnvironmentVariable(key), typeof(T));
            }
            else
            {
                return (T)Convert.ChangeType(configValue, typeof(T));
            }
        }
    }
}