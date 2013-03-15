using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=g2N5kcPg4Sc1vpA05BhBs8j3WTrERF9uO7s6ipecJCZpainTnoNsbHUFC4ECIe99mkSfpdk9VwzWnEjYwdiBN4njXA3Nqt1XxfowiC0_3rq2FuCPp1s3aoJ853vWS9aTPRVDqOj7EsI0L2LmempjaLwBPAESLcd208q4c68iutGVpXN5I8PimKpVcsxPQOXKb4WA8oTRgdqRyfchGJH94BCyWyApgYbUmZRanBJdur5EicBOYWX9qh2eI4XA3kF5wlJ0ElAasdCrgAmPWTsq8MZpvwUxpI1.O0Sy.Ygn9kRXkGMIEyZjuA8KV0wKyONxFOz62VtLq6D5F2RgmM6p4FIf7rZlykPuNKzdpXric3G9AZAcK5mKoKMtDCxjyzvMfwIuSuyJEtDWI9IpLiMos6j9B.ywENp5B9nxSENLP6popP6JallRXCmI6oe5ZxSozRpOuadJExqXp0V3d9J9O2VmD5l92n2Gwhesy9qulRr1CVih2QAGhcBTO_SaH.g4.aRlF39ksrLCIavBPScSOy7_zIgxaWbQlCC14JASMWr7H6eP3QDuJR02x63uhzOrAkZ3q.jmdoB6wCrs347xm.VztZuUCjsWKIHHsn89LFS6cpCDaVhI6EYk3P7TEARFutyu43TJW2gz302wCwl8s0RVdAkKK0ne7aCb_RwI8BkaKLcB.us7jzHPG3dh1EUqYySdYiLV0ogPZdOHgenjlZ9cQjluCilAg2LHOudGXPPTkl6a2pbW5Dew9mZETIkP.93H.ec0q9We5j.d9A--";
        public const string USER_ACCESS_TOKEN_SECRET = "466bfdc44fd8130e4c76c40bd13ee20917544216";
        
        public const string DEFAULT_LEAGUE_KEY = "273.l.86177";
        public const string DEFAULT_TEAM_KEY = "273.l.86177.t.4"; // Wookie of the Year - 2012

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
