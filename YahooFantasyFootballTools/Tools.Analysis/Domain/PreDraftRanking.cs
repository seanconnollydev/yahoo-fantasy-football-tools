using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools.Analysis.Domain
{
    public class PreDraftRanking
    {
        public PreDraftRanking(string playerName, int rank, double auctionValue, int byeWeek)
        {
            this.PlayerName = playerName;
            this.Rank = rank;
            this.AuctionValue = auctionValue;
            this.ByeWeek = byeWeek;
        }

        public string PlayerName { get; private set; }

        public int Rank { get; private set; }
        public double AuctionValue { get; private set; }

        public int ByeWeek { get; private set; }
        
    }
}
