using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=jdjqbV.frgURFoLAilHzwaciqdBBq4T0MQnx73bHK4dMF0TryBtNv77aq3k3Cqcqz40kNBhFRM6bjTpKnwIVP.WLw0BtYjxgK93kmhClBATFC8w1pIQm0i9VnQrMa9.WskMSk6Yl1LWsHsGOHwhM3icsD99uW889bRRC7yShQIpS2wHAN1L8Yi0srAtRnhq_8aSQkbfOoYfPneFKN0nlAb27QFYG4XZbIG58889DpANak3kVF2ovyV0SC6z3PQ5py3IfbrO88aopdIEbt26vXquCgASYGTGb.tJ0rV.Q1Tl_ETWcQS38..TKkJNdBh79VsyTFc9Fp5EI6..IWlj7veKEFGNqZhjCQ.6h0ODt.izP1YNDriYhjvUpygLpLMDxb9trtCJwjgwW2RgsLGhNisnttPorAviLW75ugMtRWch1ZVgA6ElQSaFZ8irAsw8CI9O1Va.x2dNjwtSp7b5LQvpS4LFlQaxb_T4MG0k_gAmqpxTQN1aINaECKwkb5valYcr7vbczvXDV842FcRVSOjYsDIEhY4A35juTSaCG5Tfcmrni8uhKBPgxdXu4vz0i6FhySIKt7qoyIkSxTi6PD1bliUL6JxFbPG4BsJ68sULPh.CnpFTNTMSOCu6bZ0hYXNsYuiT8XNri1EdaCnj4VUK0mFLNsrpeOKSxBA2ZWQxwwT3VM6VubY37S8zUVVL.D.a3l9Z._6MH5ecffc1Sc6A_lypgcIYUHvf5zspU7ZtZu8.N_Ai59G.2GhwP7fSho1vk7Ae7mQT.EUI19A--";
        public const string USER_ACCESS_TOKEN_SECRET = "cd57c123127be79be78fc807597233e05f6c4288";
        
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
