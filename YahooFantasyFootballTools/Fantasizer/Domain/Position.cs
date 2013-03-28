using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class Position
    {
        internal Position(string name, string positionType)
        {
            this.Name = name;
            this.PositionType = positionType;
        }

        internal Position(string name) : this(name, null)
        {
        }

        public string Name { get; private set; }
        public string PositionType { get; private set; }
    }
}