using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=rIMb1hrQhCF_gx1T1seNmkXDLSqDs6MMfK7.PJK7HksDZT6xsTf4nE6qUMU_xzOJK54I9AY2lN7StnlOVIKWGpjVfMNPW811ovhMei7LP35mO38KAAu5teEuBfet3Qu3z.agCefLi5hq_Rs0rCUhI4gZ8dd_rQQMuUXHkf9OqKxD1m3OPugWngiOF5IfPEnwrNhUP_qiQh1z5UJ8_EYeACox5AtlXCKfwC9FE4X5UXvVOKIoRBCCJ6iH5c6l.SrzpsjyX8s9ZCV_nCDYVMdxkjIYC4ueOTTzbClYirVOfclzBOalszH87VJWw97BFS1Q1plUDpXbCFsxUzWcbIT4J7eRDt8V7em_BOCTn4yZLLZ5O6vUEUxUcSfMx2NiCo4DnXlQ68CwSqflvDXSBMU3QvtvoFGV_cG4JgVwFIeJLK.MvXQJy59N0QpgIUkHIvWjZabZSZYKjB494rTm9.q9SHD05vpKeRHzB4VVLSfXYDeheTFqULQ4QAzOxBHK7l5focl0tldtJw2D74kzjJcp2kY7BdtUECb8vxasn9_U3WUs5ZGK_GpmFeMFbt5lhtac51AerHcwNiWwxsPUZPRosY_Qw1Rnwj10QZxs.pV88Hbgxek23ZNXdQlsoyqKnwh8KRwhhlNlLxMJvmuSi8nmvGpxluzwIFfQW76IUYcXuUq1dDZABj3YOSR0mUg2EysAt.31Pm.QGRCMAfVN7Vcn0RiQz7M6RaUaJIlOQuc.SUKQ4cof5YQK8zdskItaDKAJZw4dTHieJh3H5S0B7g--";
        public const string USER_ACCESS_TOKEN_SECRET = "516fa02c91815475d31cda58ed66304c79b1e02f";
        
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
