using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=1aCCS7jC5QOJf6GvjJTZVU0lRIZ2cZk94e4M6HM_f4A0i9zVkjCCRjCtceZ5MveI1yc8minsQwMZqYgFfVmS1ianS5Cc2rNHaCXl7u9pagDWeiBj8lKd1f5X6b7ZUCxBHs0f8h_NDf5YduCxZMB6PF.fGBZBPhj1mIEr1YMNRlH.7OLjNwYRAbrkkquCTbYGK6ny5GeeRWEVKH0S_39mf9i6McKtyh9Zk0b.MEXPMyoenalD7WdWebo8C0MySgie.67PxMqnep_52zl9rt_7BVBCx74cTTDXQNWm5YnDoSAsrU48AnvotGV5rNvc1N4pYX_ihaEmCOiWw7rJ68eTux2CHhEmW1Q1O8lJg8pCe3UtF8uhOEBP7OZ.2_nZ7rGh3LJxlY1zDw.yAFkmALvoSk7DqJCxIDrmkOL1i.HHhSFW1XfDrff09cOuD_1oW6raf6RKk1Bfcumxc.szPbO5j_1udHVHsdDoT_M1LBoV7y_V_g2n8tg2ACsysx33DHwmztcK2DAPD2.SXOTFc3sH5sbueiICPLphiZ8LVqQ.jVwzwjhiwS2ITIt58Bmdi8MgHbuO_RxvrIsUAFI39SPwa91OM8QVPMCWX4gOaNfmLy0F7XrOJztWrsjjtMUGMVXlqBmj8Qd0_YH_xy0OHVtO23xpu10w1zz09A1rnJiJQ.Dkme_swb6C7iE4WdA1czXfkJVDZKPqT_vOEZx.rhb.q3CSx54C2BR6E9DqjK9FvyGoPfUjGGKPXgC7mQZglfN2MDmWIGDBpLLt8wv6tQ--";
        public const string USER_ACCESS_TOKEN_SECRET = "2ec2b460da96261313e73552bcad1ea9239aa3ab";
        
        public const string DEFAULT_LEAGUE_KEY = "273.l.86177";
        public const string DEFAULT_TEAM_KEY = "273.l.86177.t.4"; // Wookie of the Year - 2012

        public static XNamespace YahooXMLNS = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng";

        public static string ConsumerKey
        {
            get { return Environment.GetEnvironmentVariable("YahooConsumerKey"); }
        }

        public static string ConsumerSecret
        {
            get { return Environment.GetEnvironmentVariable("YahooConsumerSecret"); }
        }
    }
}
