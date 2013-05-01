using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=SZTY0zLYoif7d6DbdkOeyVuQ62B3KpjQx7fH5SRub2_FXT8m3cEs3vPyK6mlbvkofts4bPoK7k4qRB_wFrHggAFUGvhjLBdv3._lU5AY6px24I1I1tGd5g_c9Fow0H86KeK1nu5rlE1t0BRUPxcirXUeHY4zw1Pm0zNEZe5OZOYc8QwBwDRyvhpsgeOvGURfPu4plrPxX2C3Zh6X2MZn3rpxJQQ0JlFa5eL2dMFvprd3Nfadv_CXoa0M62WCr9ugwoChMgNRmaT5DGnPS476Abc6ytTEGu6BYPBmIEQOSjrYNwxfC2UCoiXZNSIlgk9p6cdwRw76h4WxY_9khWvEEXjiSjzXOT9SDnQumAPX8Ks3s9OQX8o6G4Ur9.YcNSG1CAiCK7UgrelPr5gpeJpvWiUlRi5O70727aWPTKf6GMJ.cEBJNwMe_sv.rPmRQ6pyqoZ5Ay4C94FBGLyYpJxhr4DFjQt2GwgafJZWTjHpgbxOPbu8VOppoodcqVinm5PheZ7X.hSOTvRdZQOGfkBgcEP1FtTSkpb4YcsR72fIujR3lbDvdk0mmsBIUkxbgBR1qa_580_JSX.NC17xO0JZZosE3Pt6EWrNxkkTtMYz2kDIp.6YQYc.C5BqXFlBUT_5tGvp2d_B4VwRbBNqqexItHopUR8fPVRRiTapr6KSjrC0yAqYkZ_FnzFoUkGcNmIlDbbi9vxEXnfKcXc2V77eN0.PnxsiIXwg7dFZLwrfH_qeokS2T.Kofu1U3p2FCCkKoAH.hRVHfk6GFQfLgQ--";
        public const string USER_ACCESS_TOKEN_SECRET = "a8dbb68315cfad58d9033a0e7c4f3541e1c828ea";
        
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
