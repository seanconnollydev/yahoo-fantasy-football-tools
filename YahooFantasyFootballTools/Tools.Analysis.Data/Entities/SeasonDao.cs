using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools.Analysis.Data.Entities
{
    public class SeasonDao
    {
        public virtual int Season { get; set; }
        public virtual IList<PlayerDao> PlayersKept { get; protected set; }
    }
}
