using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=ZoQXnbCb5BkLZJIqCrDmqqsXPycFwA8EA.0KjqmR8bJtyaQRU.oX7izGdAbDQyj.cW4NZl.9lr8lv9MM1oNinpEtXPtBvVt0yRDAaSM8bpI8utFWVeNO5VxGjZso8xpFF3mVy2gyC4V7E3fwbc6w.AwGtv_kc8Otk80R5bN0r7X1WIUSuKxJleQBfqbGzLeyBAzQ.yrtxtMAKGZ_5RNmcStnicR1UYCZJ.jzVE7rJjLaj9qMP4obVNYEVWl4AwD2y.5mp5OBQoFJrnjysWSGbPX646u3jG_AIm5Yfj4n4iD5SefUdEa7qJjsv9CSgZunVtksjndhSakgJpq8heNfbshByHfJI1j15mqFaZIqvjUYheWV_QZWdzEoVsrl.lwC3QoWY4H732FUF5AzRJi8weEFnQ.i1Imh14z5Yb.Sps.Kf7EdcXgyPmHxsrhdUclVF_..pQi3N4hEznBHueuuBTHsxEW_O0EdR.WxLBGxs11tcTz579GLtFBPKNanwmllvigpAomWJ5z8jZIT7vmjWWUI_8LB4vBTCpk3fbRZzjaiT91DGudF5FaKGN29HOtNpewo_S.xjInKzS_TDc1M6G253ACuqyAANWNm.3TUxQqXRB4Mow1ZD3rPRvWdDLfgb3u40sYK5dODtqrNRkJxFxRW0bqy.8SaLiKNp6Jgnv12ZLmAc9_EbR9KigKXhTPK5JLlDeVDyS4Y2GiWv7PB4KBBHKeRMszv9yzukd1ZsjasePV.UtKSGLRP.1Zbq0P0jiLgo.d5KJng1eHefQ--";
        public const string USER_ACCESS_TOKEN_SECRET = "d041d8fa4cb79899a2b37ddf0cb849d21b9d501c";
        
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
