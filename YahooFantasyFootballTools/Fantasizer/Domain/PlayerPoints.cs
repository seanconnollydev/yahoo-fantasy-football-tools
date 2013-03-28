using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class PlayerPoints
    {
        public int Season { get; private set; }
        public int Total { get; private set; }

        internal PlayerPoints(int season, int total)
        {
            this.Season = season;
            this.Total = total;
        }
    }
}
