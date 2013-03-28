using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=Jes11FrPjD0LPSt_BzM4SXE9reibZIzM3KQvkQNrKrJHHGw2JnltvKd2yg9dT9tKBaO64WMIcKSIU0kpj5VZKeoxS0Axq8ltj67nPyuVhCZxLHzI0A_EqN6mYeor4R6ryRKLqclFIzpVd.gFfuYjUVyxltjn2BEVT7gmC_uHDJJYOMGApSDpHK6JcXaWGiAazsNrCvTjSX5nv2cuYISHBxUL7tLjXk4IWA_CL2CyrSXNag_N.NGxMU6gbYjGMFHiRaiSywvCPPduLevJlq0eP.303go6xOqyuTaIM9Eh.jg1Rn1YSnPp3q3hHdSHSbNb0RMRIHB.8TtMrWzwNYHOmOURv6oQjf84n0ZZkkaJP44s5PNvGUC9O24_FIY49PYuDWK0iJ_.nY.Rnf9JCyOP3uP3sXZDxAs_KEQfhy_Dy.wmZ8_vhguW0ImxMgJzhe1DAL04HzW1jTIAYI90tjIJ3lVgOaYBi0cRqefrRNxgw2nKLNsL1gZI5JJuZ5RQi9IbLzVoXcNqT4Jih52kVSyPrSJ91OyGaD7UbXgyASdrdveqvRCL.EjBlreXDNHIadHRi2qUWB0UmQaodk9lX9rVAA0OcL_WmqLDFnPC2Lhpq6eSbSTAymT44hMVOtFBiA63DyToS4g5CNNmDjhjBFYhuK7xprxCydxHJSKAcmVCZmwe9J1WTnpT6wbkCxiEMWQZNcm5dtRrOekY9CKZzQQOakBbcPd0N5hPxeQY2oYUPKpzM1QnXZ1M6A6tfA9h3CDoUY5E3AnHOJnO3_6xpw--";
        public const string USER_ACCESS_TOKEN_SECRET = "4e604cbf826b08f5fe5ceda3d23a2fcd86830668";
        
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
