using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooFantasySportsClient
{
    public interface IUserTokenStore
    {
        string AccessToken { get; set; }
        string AccessTokenSecret { get; set; }
    }
}
