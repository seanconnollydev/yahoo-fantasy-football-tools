using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=gZjW_lD4vgfN_AzTB1t_3G3m9zP7IYlvlRaDo9WlEjME0qe_zCGhceWzxJZv3yzYPnj1WW7vbPwHIHgDik2is4AH8_hltIXN9VuHHKnWOIF7bOr_MgwZ_duMXnZH3vmuTgn14XS9wd_jFRFpFukUyWTKUOmhiFNBpAPNo4SXthPc.EBtGKV5vxk2XM9eQddpgRwnpdMteoRuo2VEoNeiGiRCvZBu4MXtvF9.OhTCaFulUrLfl5y3q5xRU_1C04YrekYRT1zzXpti2Ly1FF3bpVzbW3fhjwB71ufT9uWgd3PFQI.mTLt1cMwbfOuopmk714AxuseRJSCKCGVS4gkjU7eRM2wBryq4i2ByopfOAwWlcBwrXZCvEpGNTGhtflg_uc7fI1lEgRRMO7KhGMSA99etpH92asLKIrLZQcLQd_87pJYf.pGYPACdGWdlir6pg_2NYsB9eO0xVN0LLXYP0_cIRjgA07pY_5RLyoWP9LI21SP9yglvDnO013.y3vlGEYtmO3LxH3TXxUJJBD1DYl4aerFTEMvNwIq3hG5GQt5oTt4BOJoha1qQObrexWMGmXTMtmAlATd5zUsBEa9wlhV3nzpmlgXKn3RLTgITweWuFuzDfJdUn4YU_vMwF09ZSDUEGGRu5HUJGtRAfq12_iME5H3y3.v6gz02uiSFEwRoTdlwRiI_iVTINLgbxvqH7eq88vvPEp3blTjz2c.CwXxLx9jYkDbyGZHqp65efytzIcGNp_H8JJ_S46Dt8ngjl8ZyAlaj_S1WhU8WfQ--";
        public const string USER_ACCESS_TOKEN_SECRET = "8f97acb6108826f066c169f75c86d20b06672eae";
        
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
