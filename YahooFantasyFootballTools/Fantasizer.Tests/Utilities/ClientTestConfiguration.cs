using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=AqMcIGj7hTFqDqzAID6l5klAZSrMuMW1KQNa_U8JxHyW_1Xj8PgTBSv3omc.jKLbPfBpReEY.HuLKEjHsXsUK6SxVqUoXjAbHL4yATq8KQvFZ5sP0.qDYCBmgS79UF8gx1EQXRPrFo_AwjL8Ar4eEmsHxPdbIUoVEHuAZjkwj5NbMHgG3wpuM51K79J5CjlgASMrZ4.rQZR3Vn6VwfL18HhzYVhSs4NSMYZiBWXFN88R0Rz62qElPDvdN4m9htg0rX98qnigvIghvDep9.iZw7EdGsMtelG1O9DvcfpGSS8qPxT.teYcVmSzQjpX2xdkIMC9IcNiyvE58x6JNBFBjj75FbqViHdh61RLGUDHHInTdMv0.pffcQcaKsE6JxCJE9zzpXQ_gXyatwOqtGnY_um.plmx6tE8XyfGd6OY6tchBFgY.0KDngaWDVoly_tC3bKdaq_sTd8IYEhgfNjYee3AsmuJiO9k3fILXgfRMUGiiyoFbsJva3f9JSGIF2QkbgPifg2nk.ePqbCeGalhHo1faM322qeHBptZoWb4XGMjH6BpN4fqmOYHAYplXb.Mw2DAm8P0OQ_SD84VUvle8CiG6AhbT_BxWwOF0tjqDT_8jXnDb.5NCNeM.IbVGmMn14XsbcuVA0vZ8uAw70TC3HO9Vwvd5XUnpWe8GjgNlfapeuX3goA6RMl.GAhS2cKCZXHHqBRz2a1pSVTZscxLrQSPgDCP7JPjTrHQ9Easf7H5NQ0mlJPktxwKsoCUybo3PmozhgVWVjtSHxfIAQ--";
        public const string USER_ACCESS_TOKEN_SECRET = "b1cd46c3624cf32e047c732339d06332c64ce000";
        
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
