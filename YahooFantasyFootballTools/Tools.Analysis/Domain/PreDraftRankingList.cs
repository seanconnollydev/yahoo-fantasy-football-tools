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
            // TODO: Build a few hash tables that store supported formats of strings:
            // FirstName LastName
            // LastName, FirstName
            throw new NotImplementedException();
        }
    }
}
