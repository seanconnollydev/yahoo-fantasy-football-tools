using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class TeamCollection : ICollection<Team>
    {
        private readonly List<Team> _teamList;

        internal TeamCollection()
        {
            _teamList = new List<Team>();
        }

        #region ICollection<Team> Members

        public void Add(Team item)
        {
            _teamList.Add(item);
        }

        public void Clear()
        {
            _teamList.Clear();
        }

        public bool Contains(Team item)
        {
            return _teamList.Contains(item);
        }

        public void CopyTo(Team[] array, int arrayIndex)
        {
            _teamList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _teamList.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(Team item)
        {
            return _teamList.Remove(item);
        }

        #endregion

        #region IEnumerable<Team> Members

        public IEnumerator<Team> GetEnumerator()
        {
            return _teamList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _teamList.GetEnumerator();
        }

        #endregion
    }
}
