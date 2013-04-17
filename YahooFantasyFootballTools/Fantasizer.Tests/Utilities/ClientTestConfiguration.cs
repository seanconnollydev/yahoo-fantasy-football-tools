using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Tests.Utilities
{
    internal class ClientTestConfiguration
    {
        public const string USER_ACCESS_TOKEN = "A=AZQzjhbm4SUgInOnMhh2FwfdWl_vx3fA8RfO0OUhYdZCBsQATw7PyR0d4dRJeT_5g.C84IaMH.uhyKRN48op0yb.49ASlCb1daKxGCQKk9dQ8sjgYwA2uWUKmitdZKwAbKseB5MVlUpGhzeGIF84ucBN_Vv9QLu7WIdYOxT9NVmrmyas6aUgsYF0gpNgvLFch3T1pxSaKv7.OA82Guj6VBmnqyyebK6Qc.khtjivUodkXW8qnXyBo3DOo2TApyF2ZoQJvpgBBtIHKVwfo5szuvpY4QsgoSEfLvp5D497L8prFisnOPpCGiX0wod3Dem8OiOjGPite4qh3FfLad5L9vm.039TH_uRvCIB_4PoPBjnvMb5YB_hNTmMDZCRcFWHN.e8Sx8GzR4vaS2gjit9C3EcptGWp3DYLUXwN.LYgyn0y7MgE3BMsCdVJ1WBLwcys0L0fLJFqt_CQKWhGPZtWkxLuWca4lUcGh88_C.w7UAbYAw7ixoNvqvK_gF7rqlzXk0RTEMulgeucAkyU.y_eo1PzmBw3WxEt0H25RGeB7TnIZKUdTb_dX_uProUnzAA_fDMYt_lJ8mMcDH90bB6yAi4rHZr2fS9tf1OYlhIIcr7yNaXdC.erz7DrR6diN9ovSo.MSaDk3HPntHhawqzWtqz0odL7vhRw3fQ1zASeDZ_0tyCpQGuyqvCMT6UcVPBAI_VYnwjjShYAQnFRfbnaYrrFvHhf23yxO2OiwtxyyrKA1G1JAJ69Fjujg4NqU40vHMt34zjZGwwKZCcYQ--";
        public const string USER_ACCESS_TOKEN_SECRET = "97a9fd97982102192470fbc5ef7e079c05f4b693";
        
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
