using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=gHH2DFjulA6nSM7TMnLqqS7ALCrEV2096hvbzIyCUXOXE0EwKEM2GD7lQfer3OIGLpPV51Ms7XS7ZNGI3MBuNnMR6hP1Un188txH4Y.XVe2X119aapejs4KMK0NabmTPx3.G9YMJLpEL6.M99F.8Ww.0R7Ka2v583Z4UI9VlzgJqIRB7Bgf5M_FeM8Yy50FgoYvhA9GncHD9YGyNV9fPuOn0TBqrem5qfUDDkQFLXItYirsee8q63ib2ajOcQKS7pNXSl70jsXQ3TpSRL6Xq6_F.zimrg.z4x6pgvOe8WsczpYaBPtFzAy9UFdZVFS7yiAHNEIf1MN9pbEBI5g_N5xaiVOTQY03NMobWXY9iEAB.DfLn7T6WS7snjWUvS8dUP54AeBct4Gs2m15_W7QqTrTM.kfvMJH1SGFvsgj6PEjfK8XVpxp6lRbf2FicmaDe24ENfCfczTgsKHz._OVEPPjLCG9voSvgQAS17H2i7fgUPUjPw2hr85axK3vbuD5O_x_ynsaxACxx7ScNzNLEam4wuiIbTWnTsK_5NLbPA.IoNu6IZ_Mq6UYz7njAr7eDhMfdDtWsDcjVogGoBX.xRxBAvQiFNV4YXfLWTqKKBrjSLgpOR7eNER9Pd7QFavSeeJX9wKq46.MysgQZ2gl9.nn7yC4jto8xmb28g1PEBAiZoWmXI0vlfBZ_ABdw2nkLInN5GTW5Qb8pV0qbZrZMhxdyZnlj1tTcX.oOvvb5pJGgHbeZX5eJePK46J01FnQK_7z.WMkbEHRAcOs.pg--";
        public const string USER_ACCESS_TOKEN_SECRET = "aa73cbd8a3aee6d9da41b1f562f770655a9a5154";
        
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
