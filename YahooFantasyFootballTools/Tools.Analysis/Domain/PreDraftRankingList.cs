using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools.Analysis.Domain
{
    public class PreDraftRankingList : List<PreDraftRanking>
    {
        public PreDraftRanking GetPlayer(string playerName)
        {
            foreach (var ranking in this)
            {
                if (ranking.PlayerName.Contains(playerName))
                {
                    return ranking;
                }
            }

            return null;
        }
    }
}
