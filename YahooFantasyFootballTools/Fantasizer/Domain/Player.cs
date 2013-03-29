using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Fantasizer.Xml;

namespace Fantasizer.Domain
{
    public class Player
    {
        public int Id { get; private set; }
        public string Key { get; private set; }
        public string Name { get; private set; }
        public ICollection<Position> EligiblePositions { get; private set; }

        internal Player(int id, string key, string name, ICollection<Position> eligiblePositions)
        {
            this.Id = id;
            this.Key = key;
            this.Name = name;
            this.EligiblePositions = eligiblePositions;
        }

        internal Player(Player player) : this(player.Id, player.Key, player.Name, player.EligiblePositions)
        {
        }
    }
}
