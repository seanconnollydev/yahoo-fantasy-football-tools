using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace YahooFantasyFootballTools
{
    public static class Configuration
    {
        public static string ConsumerKey
        {
            get { return Get<string>("YahooConsumerKey"); }
        }

        public static string ConsumerSecret
        {
            get { return Get<string>("YahooConsumerSecret"); }
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