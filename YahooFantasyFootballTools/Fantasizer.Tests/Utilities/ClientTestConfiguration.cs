using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=Ul9iAvvs4RAaRzdoiZryszVdV.rlqdcOadxOPCzcrUXZi5eN.y3hDB3LqedOimkf1H.A7UujmaJFabw45jUvWb.wHFms_ID_irrZq2gmjN1BRglC0IDak2OLUxiWR4oc8XCS50VmO0RCNU1xtbRvwOFNE2ivPkBJZa_LlNIblv4_rxC2Elr2G07lwa1C3YHvO9nyaJ2Sr5rMShLF507UuvZmpvv8jdtU5ywuYe10OcZhK0porvoJU40J11MX0z8gv.7aBhRbgmix5ngTnjJLx9NIdMlhDtYH0S5ekQqnFUq85q2xbltVQi7aLAeoZxV2hfT7nxc47rwJ8JQpuktcd1iyMiAg6bQtKKWiEwPUHvrsrdxG4syEKC2WG4CCGhGOAffKPDwDjgYNeP7cJB.DAZVr5X2qvMdg3uyVvzCFbO9dMh135MaXFf7Xv5XenBrj.Jvn4rPGS4Rb3AsSdMH6kVsJPsBVnPKvKWaaRLVH.Ip_QnhThE0w1X6Stnujm5v7ACq4nxnDEUG4VzKIvzIsmcCmyh.9taojxmu.tp_ACSwvgpTAG3t5kcGX6mLHodS_5omLHk7Ph_xVezQUyQNRpPzKVeL.L2zCRVvyu755f.G7duN4pUXk4J_yEj0TL5IC9HCEZUsmrJd1vhknBoTk3f4SeO1q8Gc3OkciygkPPEdtl4LhFoC3ZZ5FlnVcgOjaHfCphizManSHmO_km0q6dhcfbn_0ekRIuplqRWXNrmQge4pORofwXWrwSfqnOCStGWdS22gJqTYmjxCvgA--";
        public const string USER_ACCESS_TOKEN_SECRET = "25af981d8a3996abc748b07de7c52fc8108e2b67";
        
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
