using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=OkkicGDg5CgHKXfdkW5R9iUYhkoh9K1XBvECw0SLvZerRXXVZWxTnYRyBb_7oNkCAk6juIZGkeEH57O5xytWCs6pgOhIByStDQKoIVA4N.UgYiLI5WZfpF4mBJezma.YUt_SuRsAzynxJcXyPkqGtNp5_mrkZtU9cCRT7wjcJGx_stwP3k1txm1KRbViNp2M41PBA5fJ95oWXGXV4h2JawDW_hGYV7pS7DV5q4z.7C7ETIjv8YAbAg9vZdyITFf0v50oH_OL36cFeOfOEBdyxJEE0xWNuibI1GMx7LknL4nBR0V0XU1GgWcwUO9Nn5T7E02Q4iZ8ISrk671QNnk1rKapokyCy9KtIGhoxo_0lvwQr_lXjsgaGZHb2CQKGyY.R8GNur6fvlPhMgCHgEKi9fmBt053.BTGdDwHtqBK7xCJP7qcu13AfVtKLqnfkqbmtL4uQ_4L2HOCvvAYcH09UG5.Rga0NO4ckIAqeo78AfcWY5k8FWpRFeXjhQtwJUglD4HdHFVRdec2xpmbwnw3mjKIjfYRhphplSVzB_448_FAuLxf3aic0UXpGJ7NHDklcF1vx3Y1MnNF5JqYL3hrI9CkSqaY6K6sexK4vZVaeCe3EPlo5RjRdqbgtZ_RjcPt955xX56r1GKUEeT7m25.o1LAeWx9bE0BDIW50xl4myP22upXu.HiSYvx9r2Jlst_0tmjyu7N1TFYTGHy2kbHiL7V_Pxr0fupcoINC2KEzyz.wc9g8KVRcxzpsQvYyl9YNygWV59CvGU0T9c8qg--";
        public const string USER_ACCESS_TOKEN_SECRET = "209cc819b9ff47712d05b58bcd61bd668baf6841";
        
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
