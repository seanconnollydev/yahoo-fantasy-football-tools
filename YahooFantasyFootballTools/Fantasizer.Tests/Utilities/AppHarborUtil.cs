using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fantasizer.Tests.Utilities
{
    public static class AppHarborUtil
    {
        public static void CheckSecrets()
        {
            if (string.IsNullOrEmpty(ClientTestConfiguration.ConsumerKey) ||
                string.IsNullOrEmpty(ClientTestConfiguration.ConsumerSecret))
            {
                Assert.Inconclusive("Consumer key or secret could not be found, probably because this test is running on AppHarbor.");
            } 
        }
    }
}
