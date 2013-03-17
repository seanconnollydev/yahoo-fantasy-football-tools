using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=Hz7Ew5X84lwx7wllLodxYD_UfTgfzer89GnknRE_wehi4lJ3H03hRx1HjxEtaQtvTJviR1Ku_rQZL66B8qmh7JzIYsUHKTrqeLjrGfmwGGy1L7sapYOpjg1zm2quzQTSNa9Mmv3wJdqHQtM4WJ8CDvkd0K_JG3LnLeNaiwzalWKasQvCHGIb7FGbXeNhCYPUhKS0kI8vTTegFpakpZyBvBECVbzgSQ0pdI_RvkrFAybZsKA8G.QvT.werUbX4BkbUZynJQFtvqzg6n7Vs7eJQerA0t6cAPMAXs_oCnmFDOtl9ZqcC9HqWGLGq2_gzHbeGd5NBc5c_CYn9Nc1rhA9p.XDLBNHYj7tgdDn03AJmYUXhAFP3ExsBWDQZC3t9NXCaNjWiHsFXVjxDZq87GFD4Xd6U6F0rz_YNdIFvyb1zA_0YfXc55RrqAdSAcggBcLbL.u90AjTWil_efeEyC9WTdjc4r6egIbAj_XmZIOGxjrYgKh8MyR7TCTJqXZNh4NYO5nEkD77CfcRW7HFsWAZZB9VXQ.pqdgsNtbz3ztMLTTyqPSYSY1C0MSLiglaJ.otOYSHZbnJ8jK6uUFl5TD0tJ3m9Ct1Dr3PMKpIBROoqtATCoFMevbPSyLRvkLhMIBBTYMYE8gRUBZEjOaDFpNN6tcQ5nWV5ypndO65d_bbuhrWFuttFX5EOVfjuiyRNC4lVL4SmJf1FB_EUkmjs5PR6uUbg3mxiWG6JX.Px67pebR7EOCVp9GD.qPhd9lmRPYCxWBPu6c4XNFda2tcaw--";
        public const string USER_ACCESS_TOKEN_SECRET = "8f6bd2b9f5bdd80d45499ef10ecc841ab18e73a0";
        
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
