using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer
{
    public class ServiceFactory
    {
        public static IFantasizerService CreateFantasizerClient(string consumerKey, string consumerSecret, IUserTokenStore userTokenStore)
        {
            return new FantasizerService(consumerKey, consumerSecret, userTokenStore);
        }
    }
}
