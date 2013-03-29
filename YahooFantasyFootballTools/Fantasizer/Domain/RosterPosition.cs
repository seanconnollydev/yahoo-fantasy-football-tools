using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Fantasizer.Domain
{
    public class RosterPosition : IEqualityComparer<RosterPosition>
    {
        internal RosterPosition(Position position, int count)
        {
            this.Position = position;
            this.Count = count;
        }

        public Position Position { get; private set; }

        public int Count { get; set; }

        #region IEqualityComparer<RosterPosition> Members

        public bool Equals(RosterPosition x, RosterPosition y)
        {
            return x.Position.Equals(y.Position);
        }

        public int GetHashCode(RosterPosition obj)
        {
            return obj.Position.GetHashCode();
        }

        #endregion
    }
}
