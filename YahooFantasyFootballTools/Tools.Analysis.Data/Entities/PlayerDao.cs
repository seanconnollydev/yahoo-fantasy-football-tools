using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools.Analysis.Data.Entities
{
    public class PlayerDao
    {
        public virtual string Key { get; set; }
        public virtual IList<SeasonDao> KeptInSeasons { get; protected set; }
    }
}
