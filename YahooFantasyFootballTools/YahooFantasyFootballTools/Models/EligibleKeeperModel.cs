using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools.Analysis.Domain;
using Fantasizer.Domain;

namespace YahooFantasyFootballTools.Models
{
    public class EligibleKeeperModel
    {
        public Team Team { get; set; }
        public IEnumerable<EligibleKeeper> EligibleKeepers { get; set; }
    }
}