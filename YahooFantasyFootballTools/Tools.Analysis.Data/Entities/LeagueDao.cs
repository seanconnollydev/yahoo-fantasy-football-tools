using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools.Analysis.Data.Entities
{
    public class LeagueDao
    {
        public virtual string Key { get; set; }
        public virtual bool? AllowKeepersFromPriorSeason { get; set; }
    }
}
