using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YahooFantasyFootballTools.Models
{
    public class EligibleKeeperModel
    {
        public string PlayerName { get; set; }

        public int DraftRound { get; set; }

        public bool IsEligible { get; set; }

        public string IneligibilityReason { get; set; }
    }
}