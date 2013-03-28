using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=LWkelrH4rA7XLwiOoW6.hQR86WE2N04zYwibADld_YjNE7.er1_TgW3gQGqpyvFanfR8ycQ53cMMw5PHHotNOLFcFPKoruQvQfrakfYAU072zdoP_kMWmShHU6bH_QCjC0RE4uxvYWqdJMyp82wPA93TEMFcBg.Nw_UAduMVKNTflWmIcy32aOvjCcUZXncKzDoBI7eq8QIhz7Te8DPxn5l1qwEL8Vg1VB7CPxcawWesUIzkTqVsnUbqysrIe6PmVj7.u0LP2Ps61D2xRitzX.61Qp4Ot5IOF8ZDZ.02BvzzhDvw075sizycKoFWnoynQwjY6.sRtFJALlMQh9vGgTiPezr_krQ3mofzufVRH0g4LRqKJkuyhxtn29Cb5.F.Wm_usmk3Ppd9IvxcEC6mrRBFCfByHBp23.kQaqwb4WSO294lp8SdCyVunAd6awed9LYgqylVkCfK96_B4Ui9PXj.UsiXU6Qpf7A6nH.dGGvm6ezIMzIp6NlbI0wltoqjNn9qWGMySe_t9yFu0kYMglzoyymueOHF9t4wskMjDM_UCT0ek4hyqhMueO3pMZzotnAmo_8ir6yzFE460hOOGpb4fh.qkXzB1JFh6r7lMf2IG6TGvVgb7F2hNHWJHiPcd7rpIoqzb76PzmsDHIK68PyGZKr64YvsmRMuD29eJrFfI_wodCVkoDi1Vz.eef1xTHfW.0KXce0QkTmN7GcTkKAUJ24l7GJ2Pzu2fNUwdCs9DcgiCuZd340Hi.YJj.bgFB2EFCUAuP47c1ZVUQ--";
        public const string USER_ACCESS_TOKEN_SECRET = "d5908fad61df4e6bc36007f74637f63f476665f8";
        
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
