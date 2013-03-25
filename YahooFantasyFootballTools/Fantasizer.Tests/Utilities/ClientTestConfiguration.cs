using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=4FcL5ov4kzMysjfGAAauTJNoO__jzW6kM7SaKUJssNtK1eaajSXzkxxBbcT6WC1wOtwuRH34VQGTXOjGummgKtE1jLRb358Ut7FK0wJutjy5DkgD9Wwan.HiqwBSwfDa.TjOJz7FMUImOxSq1IpscvNEWCCj.a1F2Cnrh1RAB5uF.uKTbFYUByJEMHUkORoZEZm69K0qEkknWgMa_VKrfB98t3RQlxaA8YfBUP.oGvO4QmYSBR_UIqJoDAI6FQSUzdB4MqMyprmwsK11r7pKc9ryvMF1YbXBvsHIpgae06pJLEV8LPlWQu_Xla9bJgO2d6G.5Ss6EHhYYuyFOQ_ZpjY.81Qh5XTvFWsjMIiuEXXd8CTn0Cfd.BgLinzrGF7ZKW67AEDUHFUOcYiPSToiMDSRl5BDZ.z4n0AAaqzBQ3vDOdimL4kg9MEIwUXxAnq8N3RKs1goZpNTzfmtA8td9GA3PZ2wg7AYQqT19i_6zh1VmAD1NdSbZPug2UnkBoK0sZScUOKM_dt3WMU.5LYoi73RPUhk1uTCqxPkTADg4_3b9XwefNHsggo3tUlCNp0F84Csl48NwCeNt1nXl01.Gkpt1ooRiBZZtpZJS4fYzSYIwMZVbsQUtU2OyP6Y6gn2H2LxWxV5x.p5sSIASm7nso1QmkVOsyELnIMaNNqh6KIKTeK8DJ_ipj.IbFFB9_oJC5r1BwsAVZ89UF0mBDAzjcPQZ3OJnQuTjJU641h2N8j1LgjlnobHlmmcFJRkyq896cfyNrShd8xiBLZFGQ--";
        public const string USER_ACCESS_TOKEN_SECRET = "a1ee788b8d46c9120dca372e0ced7ababb27b677";
        
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
