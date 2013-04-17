using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooFantasyFootballTools
{
    public interface IApplicationConfiguration
    {
        string ConsumerKey { get; }
        string ConsumerSecret { get; }
        YahooCallbackUriType YahooCallbackUriType { get; }
    }
}
