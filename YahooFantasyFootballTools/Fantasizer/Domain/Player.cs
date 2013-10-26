using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Fantasizer.Xml;

namespace Fantasizer.Domain
{
    public class Player : IEquatable<Player>
    {
        public int Id { get; private set; }
        public string Key { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }
        public ICollection<Position> EligiblePositions { get; private set; }
        public ICollection<int> ByeWeeks { get; private set; }

        public Player(int id, string key, string name, string status, ICollection<Position> eligiblePositions, ICollection<int> byeWeeks)
        {
            this.Id = id;
            this.Key = key;
            this.Name = name;
            this.Status = status;
            this.EligiblePositions = eligiblePositions;
            this.ByeWeeks = byeWeeks;
        }

        internal Player(Player player) : this(player.Id, player.Key, player.Name, player.Status, player.EligiblePositions, player.ByeWeeks)
        {
        }

        #region IEquatable<Player> Members

        public bool Equals(Player other)
        {
            return this.Id == other.Id;
        }

        #endregion
    }
}
