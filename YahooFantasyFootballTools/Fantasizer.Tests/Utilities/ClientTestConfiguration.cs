using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=Qk2PSPLSt1opceArZ6FqzdTYuajetdQfMfABioW36oC9zLFMDaO7UW3GWrv0.wfixLKcjvwOM3OShv7IRm6n4aqha3RRX9xtHDtuFHd7MmD1Laf90Th25PGYgOL38fBh.j3E2ePjloycmooI5kAagZoZOra7_15axwSdah09JasYSReAkEVhTJ6SK1i_YE7zp6GZT3xGChRZV.mkgy7k_a9j5ZwfQyuMeb5IqgZF2U66OtEmSz7K5ZITp5.YZtm25IS0VxeXo02yShHx_7ZKq1XgXZUhLCxsMFhOrFFh4_x6TsHu8AJlyebWqWNlSOImHzOo2iLV8E9iUMwfIotk.pSiwxIl.L_hS0XAozoZ1l2BoO7V88hw3NwX0pC4vaXlBlooh9Ud6E6NUI6joNekbAfCbuK_GOuwj_2mmLvL9iUoRYEF3zOcM2uP4zYHScj2Es0LfpcKTlXvLZKwUBbXcT0TyYPsgivfImBZk6HEDwGQhr112rlVDbqYlbNvz1xq3Dy5tXI0kEDg_A5Gwa6R.NH1XnZcNLF4PUYYqAAwRLPfoOmDwtlPydC48_7DH0PlDzef7IO5HIP.mH1SFwxHPA5lINXyuC78w1MKeAtQj8eFpG4wWy.6VMtOWxNd58rUAdKjPdQVp1ic9_BVah5QkowyLXoRVh6fssTDdSusZsVw0FLl2eVLRi577aJsjSCmm4KcH7.Du6kt2bjPcdaOfjsuL5oR5D1QUF1cn0Mtr3Dj.daWgalizujT58tyBBWEtkrOAgegxwpXs4KOEXDDuLYJjldL7U3A3wB0B1DnATUae6337ni4emj9XEqqFDgTE1lkJRYlX_8-";
        public const string USER_ACCESS_TOKEN_SECRET = "fd4e99c7d178f8af49877b876ed42ed6aa77c0e8";
        
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
