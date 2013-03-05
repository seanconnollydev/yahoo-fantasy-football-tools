using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooFantasySportsClient.Domain
{
    public class DraftResult
    {
        public int Pick { get; set; }
        public int Round { get; set; }
        public string TeamKey { get; set; }
        public string PlayerKey { get; set; }
    }
}
