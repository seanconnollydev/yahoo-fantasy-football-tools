using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class PlayerCollection : ICollection<Player>
    {
        private readonly List<Player> _playerList;
        private PlayerCollection()
        {
            _playerList = new List<Player>();
        }

        #region ICollection<Player> Members

        public void Add(Player item)
        {
            _playerList.Add(item);
        }

        public void Clear()
        {
            _playerList.Clear();
        }

        public bool Contains(Player item)
        {
            return _playerList.Contains(item);
        }

        public void CopyTo(Player[] array, int arrayIndex)
        {
            _playerList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _playerList.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(Player item)
        {
            return _playerList.Remove(item);
        }

        #endregion

        #region IEnumerable<Player> Members

        public IEnumerator<Player> GetEnumerator()
        {
            return _playerList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _playerList.GetEnumerator();
        }

        #endregion

        internal static PlayerCollection CreateFromXml(XDocument xml)
        {
            var players = new PlayerCollection();

            foreach (var playerElement in xml.Descendants(YahooXml.XMLNS + "player"))
            {
                players.Add(Player.CreateFromXml(playerElement));
            }

            return players;
        }
    }
}
