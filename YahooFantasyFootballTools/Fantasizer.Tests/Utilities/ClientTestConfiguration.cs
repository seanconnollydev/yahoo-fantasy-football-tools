using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=_J8gA1zJnzzVrf7vBEX4qTqKfRQI4xP5V2fWZUkTJ_QLeQsuBQlBxiYXfGOmCfDMtfjcz7SCkVICX_bUpjQiB8gZekJNJ6s7RfPo_N0mXGpLq6EPGhPjP__y0eXD_bmbuFAdDP_x3GS.CNBI7fqfEYvlpLojUQmMqjF0HtnY6kQ61baxWIm3KS9ADzEW6BINccYIAtDCwBZt4hB6WJzZL7WZZQwMGtfBIsPdHDr5N5yd4gq0GC2qFe7Pt41oLg.PsOtv6nEZlDrQ_ot_dOMfQzSSbU6C7Am8LjdvQQZ_s83nf6u19mHKmwtFWqlFTqOWHzIndoZnlQkYhYO1rLCbIuUI0ccyZmvO2m9R4wD9q4v4o3NLFrmX3SKqBZKaZs85Bf1fIqxHtLFstErqrtRojJBoU55a.sYr39krOvNJfPi73QcoOipY10SCRrUH_2ajLpcnqBt0a7fmQmUCEQJiItXpfexB6qrBuEF9CyclhhUcN8UAU7gGzLEGcgXtOEegEkayCScKBcAQ1FxzM_fsJXlbAouuiDDK6r1sHYA_jJk8RcHySUlYEdMm4g7Sk82pC1qoF3BJ0XuxNJeS5WoChZ_Sgqs5TP6u.AAH73YAhKL0IYpP54HITyqicjf93VLA2TAE6bqI9MffV89TsN3TjmwsA.AJuMLswjDCGCZB91JFpT1dh3gSLQ929TR963RzttK.y0lnrko66Nwmsw7QwLSttwkyMSCMWhXwoEhiVVy556zN_2.JUKyWwq4IcsuWTagzJJQI_ZhfL.6P6g--";
        public const string USER_ACCESS_TOKEN_SECRET = "ad96d688574886dec54d9e6a8e53a08dbec5e400";
        
        public const string DEFAULT_LEAGUE_KEY = "273.l.86177";
        public const string DEFAULT_TEAM_KEY = "273.l.86177.t.4"; // Wookie of the Year - 2012

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
