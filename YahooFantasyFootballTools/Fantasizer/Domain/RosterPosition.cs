using System;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class RosterPosition
    {
        internal RosterPosition(Position position, int count)
        {
            this.Position = position;
            this.Count = count;
        }

        public Position Position { get; private set; }

        public int Count { get; set; }
    }
}
