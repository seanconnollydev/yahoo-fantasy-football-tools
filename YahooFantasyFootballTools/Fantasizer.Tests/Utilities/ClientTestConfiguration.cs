using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=fnBd2.advA5KyPqusZcvm5RhlBFHx4DbMMg5Ioum9NfKOBu88L636pH15Ghta5xM5JV8p4QclHLZdxVRghP45vp3jutEZIfoB2A.4GasNMAvNbm70VJf8qiUlvjnwtvhskZolT7crhnC6UG0W2F33NnJuLYYEt_wkUb13PpPX3hG7HHx9OZsou.PI53NFAXf.SlEcnE5h.U5VbGk_R48obUAIZGv4tx2U7REZ53c0XL7JaCzXa9.ziz3k0rg8kxfgZPB_TeBNtODBqTpYZGFFv.VaXXGg1r6tAq48.K5c4ZsCJZNGBZIwUNnwLPU.RY6TLydhyRRav24F2ZAYY6M3tCk4DhTNZMmUwBuy2NWGOpEBwj4t_TUWpllJWWhV6bNcAkxgkXIxYFzPrHOFHewztzVoR9Da8L9zvFqpY6O6ivaW1aor2FDCs1_13Vbbw5UN1_Hoc80460KkUCBxsI0XPeFb6WarRcLFKckTKT1lRnHAYOr2JA1Yg4oHcUk_IUX7BGPHwYllHK3nBx0Y9Db6V_o_MmrSHF4CUMYOVnZrYsNgjTv5i5a_dNxpFrqDUJdil4HLYKupBm5StaZQsCzh0sn0OcCXFAYmF5JmSM6BEvUd2jpLOCSDS_afZ3MvbzddH_VrTV9mQJ_g0zFwqUpWk49c7JYEJ4O..Y5C5FOy7sDmfnMd2jN0rqnWuKMUaHNIxnWILyH1oXTvokwyBQEVj6HR5P_2X9j6ChxsaZhzjddNYG8CzzAXNmYDWihQuviffsOYwLVJCDAmq_GpQ--";
        public const string USER_ACCESS_TOKEN_SECRET = "f0c20b5fbcf74b96fbc7ee959c487d1d8139acaf";
        
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
