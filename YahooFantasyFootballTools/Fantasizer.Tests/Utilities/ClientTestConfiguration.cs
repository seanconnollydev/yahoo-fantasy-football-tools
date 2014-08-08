using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=VLFnjkjJ5yOldTBcr_0qxo0_2WwRG9XRimkdpygLL_g3n5lyviBFQ2Z51epgtsHfBivBwH.yw.hAYepe.mHz_AiKSfdQB.VshIyabwyXV1NMtNXpWOHk8lGJtQ2C1fSAtNmcmlTt9iE5z18YWvb6wbtTO9L26EPWg9ccNl96fCKJYSBhqqg_T7R4VZobw4U7Vsq4cRLKLakyPaePkinFrUz5yCGQLJINpV7Z1PHJ8Ot_MuBl_nd_m8TlNuoVU8oAEBp..v4Hx6iQ4F4m4RlWRGttNjjSAL9g1FQj1lL__FygE0poUyGksCdZF8lPH8UN3mCTU5Q8FuUo9wKEr100r6tGbvWBdz17UhJgZ6nOu_gD32LZxIZ4A.Ig_N_0QxmMq0IJwS.nDzdaBpd9nTcdyFahbIc5IhZNauBRyMRZ9ChAzoFx7pUwv_mcyHvh0sH8LxCo6kLwEWHZ25ejU3JUMX4ngsLq4u5Pv5KXLLvJo9S_8prF1d3MaewD5LFXtzQFB9uBP_kSH56x0f7GcuU5Tx3U0aV_DV6Ok_4Jb9XVSvKshNhfJEYDjzXlGMRE2jk03hWggOeeTwxn.FQT2i_QPogIfkGe7NpuQv9bsIa2LqVVS1fpTgUVnRF3YOph8kqFphFboGyXErvFjIUaxrAmldLZuwGoDsowt2a2cKYe0BsyTFK..iqGcRpUpRoWFdKkUq4HsisRFhKSKJNqd2lQ9zin21zjelvG1QZpwyDXsv5sF_sTTkyoC0IwsB12PW.8f_Cuucbh.63nCwFIKGoUQTo5IwAa5B0S4..WG0sJ6atSEc0zVY9BS0x6y.RKzRw8ccj_PA--";
        public const string USER_ACCESS_TOKEN_SECRET = "b646efd88a4367b16bfd3ce1a589e2fad582cfa0";
        
        public const string DEFAULT_LEAGUE_KEY = "273.l.86177";
        public const string DEFAULT_TEAM_KEY = "273.l.86177.t.4"; // Wookie of the Year - 2012
        public const string LEAGUE_SCALLYWAGS_2013 = "314.l.137342";

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
