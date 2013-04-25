using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Fantasizer.Xml;

namespace Fantasizer.Domain
{
    public class PlayerCollection<TPlayerType> : ICollection<TPlayerType> where TPlayerType : Player
    {
        private readonly List<TPlayerType> _playerList;
        public PlayerCollection()
        {
            _playerList = new List<TPlayerType>();
        }

        #region ICollection<TPlayerType> Members

        public void Add(TPlayerType item)
        {
            _playerList.Add(item);
        }

        public void Clear()
        {
            _playerList.Clear();
        }

        public bool Contains(TPlayerType item)
        {
            return _playerList.Contains(item);
        }

        public void CopyTo(TPlayerType[] array, int arrayIndex)
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

        public bool Remove(TPlayerType item)
        {
            return _playerList.Remove(item);
        }

        #endregion

        #region IEnumerable<TPlayerType> Members

        public IEnumerator<TPlayerType> GetEnumerator()
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
    }
}
