using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Tests.Utilities
{
    internal class TestUserTokenStore : IUserTokenStore
    {
        public string AccessToken
        {
            get
            {
                return ClientTestConfiguration.USER_ACCESS_TOKEN;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string AccessTokenSecret
        {
            get
            {
                return ClientTestConfiguration.USER_ACCESS_TOKEN_SECRET;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
