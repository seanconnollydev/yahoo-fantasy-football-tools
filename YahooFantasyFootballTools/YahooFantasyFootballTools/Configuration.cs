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
            //get { return "dj0yJmk9OVJXSFBMcVZyRldJJmQ9WVdrOU9XaGhiblJ5TnpJbWNHbzlNVGd3TkRRd05qRTJNZy0tJnM9Y29uc3VtZXJzZWNyZXQmeD03MA--"; }
            get { return Get<string>("YahooConsumerKey"); }
        }

        public static string ConsumerSecret
        {
            get { return Get<string>("YahooConsumerSecret"); }
            //get { return "266f2c9d42e794b46aab16ce6c894986e008f3fa"; }
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