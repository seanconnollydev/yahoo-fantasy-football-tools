using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Analysis.Domain;

namespace Tools.Analysis.External
{
    public interface IExternalDraftResultSource
    {
        PreDraftRankingList Get2012PprPreDraftRankings();
    }
}
