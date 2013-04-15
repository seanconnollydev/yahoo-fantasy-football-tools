using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=_bYOMaP94BDwNzI_vSPwcc4XQmRg8XXZagNW2xGmVrF5Tc2pXmZWp3trTJsDCsgdY3oaCmnksXt.paCnrZZWjePtNHQzUasKzTj2JZmK5ZknwHTMBOesDmBtpf7uVEwiEW2qaz0re30kJ3a64tpz87870NzxnPkC1.fY3w8VrEX3l9uykE8iZNt9OKPuri8sGT16mHe.TxSYq.9x0K5x7UG0.a2S.Csm0oxvgQabgx.5es0KhlLhF7y_c73wRzCbjfO1JnI82N_0YV24pwYMzifNi2JDw4Wg4gNhG.jMGjEg2wjbJ8nqqbmUlNy5EgonCYryVe1Kkq.Qzu5DSYY6fBxsVsxnMzHXgZmeiEVVtl6PJI2y3VjIryJj_tA.ZMSDTnI3sdLD1uWeo9m5DXjJBfNk_XzSZLaSnwhQ970.Hrg7TuNKvavV4QWvxbP0BVCWpzXnKowP1gLLQQpyxntufpF2Bh2OCCpSMdBISwXg7X_1MKKzTfeG6RaqFskDDBAifKyv76jcFCj2UWFongppd4n_iwvrosHu1.feQIVWFM8tf.UWb06k5cGxaPMiooNG6Fa5sWlT1_CqZx6UDJisvQcdR_v3rCTDnfAyw8ZsqdnuGUd2a_7PxMcuQkoOgd16CXba7urrimNdu4G..69XsvXU1qvnJM92RdDoQUbd2aGplTIDULUUTBmZ3DLzf0SWBAieFtJ.g7XNM5KYNcJI.uEzWCtrM0wIN9XStN5Zt9.9SuBuRHpPq8kMgfCzFBYk9Lx_OndTu2m0uj_bbw--";
        public const string USER_ACCESS_TOKEN_SECRET = "b23bf66d677dd19881bba771be5696785a5429b6";
        
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
