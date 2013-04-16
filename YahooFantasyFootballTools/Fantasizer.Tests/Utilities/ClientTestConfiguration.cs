using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=D1j6l1GZowLpxRlDNGt1Qk7ur2rKBed0awO39SCZwmamqnRTmea46guL9PbrHJyKU8NO4XVUZLNX_HMJ.M_hSwonkbtA9cz8KUmMjR.Vw8mzLV7k.QcN_CVhuYB70836ir6_saIDXBXFh4_Hf3YAsMdJHMonQJR5kGPMEV4vAeunhvbfU.lcUEyugm61_QsleLllrva7a4YGy04l5_LkR2cy4aCHxbzt754DT.kMdHxg73_3.3iBOqPblL1EENHh3FgHDAt_4px8qho40zBi947QjW2wrBkUzhpQToebCF68P0rWBQSCWrwcWaQcmm6L6iggSt8CAbp1lmfackvofiIbZkqqHXZo_aj0YHg2eVn_SSAMxzlDQUcCU.Q.hoFiaKVCFIRslTfcdCaS_2fRZkMP1CSmwF_BReDDodQ97AISME61ZnuJEsyZ2f_xtrlbPUkyW83Evdw9U9iMBRhIB6vh2XhFkbfMTJNEbBYCsICzdLBrOkHWepfI4JOxyxOXsBQMwysdY7HAhX3M_Sjahuf6DuDnPxszY.0p0UcAgh2vnpwkkQE5EqoL_UWe9MgLT4fZidnZaWArLWOTqD39g.cqDfo6ocuA9OQJLmWMP.9RRJ_vW8LCdJNL7RyIqNqYAMiH9VTt6vF9DmtYV9K2jSddNN2imnseoEub.C78xmnd8MEYHSpwA97WF11DxsV6IRylmF5drhIza_aWqhM3Lme1RaRg7UG1l6IKUqZ.wwGJ6HB8khM7N.MmemR574upS8OXUCpy.E_sIuUekA--";
        public const string USER_ACCESS_TOKEN_SECRET = "36dc74440dc06d3c8b2d35ce9b5f658a80bfba60";
        
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
