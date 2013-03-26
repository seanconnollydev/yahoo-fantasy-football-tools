using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=VD5GfPzYryqDrpOqOHHOzPIFBx9Jqpd5QoVjvSyKHJcXzLmZfFXPz1eHkPXy01F9GG7ZOJtv.yW_92ZmtJZxFFg8EWsAgWbO7VoCT065Ju3Ow7RVt4ZeWRv3pdQN8.PH5xi7gbMjGAL5TulI1ZD5RcINLkciVCoQDtlbyucmBX_pGJMysyjI93IxVdsCA2W99iLdF4TcXHykFOR7Cn0h6FbOvv3n9dQtsC8x6rSfikA5Vt.XlJzWBJVANlfb3g3wNSN8UhmNNz.6sd1sl4BHl4PV6b6nu3zIAlTcHcmrWgFRacJc3yprnHYbQiB1gXM.u3l3QmhnWG_BaeevN1.TJUDqptm8m7QNXpehX47UT7JgB5U9aTPAwD8fGx8j_fceh7.E0b3cXvzLJvc95Wf1_uFliVRB3hVcwOtYHaCVPSqIvJnYK21Nv_3wgR_sOYsJZZ3cwMBGtgFpcUTWNDrwfxTh7WTbGx18guwB0gdYqmlyMzHx2OHHRlE6_lX0XEEhMV9gA5J6YHJ7nB_NyDJOeIVDQLZGOHMVWJleiXfYbrhIX9alYvN3Hqauzn5tKZz0fiTxcOHiQoD5QV_Ri4NyGfYX_pZSujV7fRpMXHNYYOBR9r8nFQSfvOTBTtuqGvOk2_pTjPgv4UxTKk7_MWGP.1UnP0VNLHUIp0pCWPb6knqMXVJNjoqHx0mYl2Lq2sscndx1ax0k.1TBZQ2u3XSGVfCDgNzv83W1_uBY.zDbr3_BcpvcH.CyCq790CPzLU7VK6E9Hoz7805U6lyqWA--";
        public const string USER_ACCESS_TOKEN_SECRET = "ea71f2a487dcf1fefc314d58054b812aab982b5a";
        
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
