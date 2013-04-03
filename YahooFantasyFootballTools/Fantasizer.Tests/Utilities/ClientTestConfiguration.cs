using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=v2g6D2SdkC30fXThTxtJ1gZdzbCrmwk1nCfyMiX41b1JTDUxsbFK8gveOvRdOrcDfRDrpEL2jg4LVnGvx4IjEQZzUqp0Y_sdByNI6cMAbIUttXpo_okp.dwI4A42SMrR0RKttL60lRo4sfFkpRAwEZx2cMfYFluzWylVpODc9kp_mnst61_bEZfbFOpX2MpQd0pwUxQ9xgJeDTdYfXwR4ztlhMUgKgCp84FymlKcZDLyTtNjvopZb779MOf_xdnSOPq5Jbgq3GttnG6cA7rSyiJaT6pOENs.rihDNcECjAUllbrQQEhq28hDuLNrPCdXGapLHCdcWGZ9iElKIhv2hiucpK1bh4GOai43BC32wyihlnYBS3pPBt63zDqJ3pgxWe0YbAAukuvZDEAnv3_WNhxGtP8AyscITNa3s96W8b4jZcbSB6w12mzQvx6esLzeYZ31D14wWHtA_jQpkmsXkdZ1PMCRwo2PtdtEbx4TS_DzewiQlqM9efwl.xjTDu8F.WpNkRMXYqN83SvmxqDiGxH1GVL6zDadhvRb7Y_Up62TxhOdNLAlv0KUqunKHbRzIiaVt9gKlLweEvXEk_wRqTo9yrWaS8uYMh6BdCT_aiqCWexZk8j8WPKL.QJaM9Nx8EKt1oVj0f2HMuCgYQqG510Hkx4MisjzbKJWauJuUd76Ktezhfaty5VpdwzY3ZnradDpvDW_toIls6hH1NCsSTCGGdr.6l1qQKjS5hWAwgQKXpRgVQH15rhTPsbfOE0a7bRVha9ieRNl1uiVng--";
        public const string USER_ACCESS_TOKEN_SECRET = "0d8cf51fff19e039b72e2bea6d27e2b977b987e1";
        
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
