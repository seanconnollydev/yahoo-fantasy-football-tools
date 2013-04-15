using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class LeagueTeamPlayerCollection<TPlayerType> : ICollection<TeamPlayerCollection<TPlayerType>> where TPlayerType : Player
    {
        private readonly List<TeamPlayerCollection<TPlayerType>> _teamPlayersList;

        internal LeagueTeamPlayerCollection()
        {
            _teamPlayersList = new List<TeamPlayerCollection<TPlayerType>>();
        }
    
        #region ICollection<TeamPlayerCollection<TPlayerType>> Members

        public void  Add(TeamPlayerCollection<TPlayerType> item)
        {
            _teamPlayersList.Add(item);
        }

        public void Clear()
        {
            _teamPlayersList.Clear();
        }

        public bool Contains(TeamPlayerCollection<TPlayerType> item)
        {
            return _teamPlayersList.Contains(item);
        }

        public void CopyTo(TeamPlayerCollection<TPlayerType>[] array, int arrayIndex)
        {
            _teamPlayersList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _teamPlayersList.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(TeamPlayerCollection<TPlayerType> item)
        {
            return _teamPlayersList.Remove(item);
        }

        #endregion

        #region IEnumerable<TeamPlayerCollection<TPlayerType>> Members

        public IEnumerator<TeamPlayerCollection<TPlayerType>> GetEnumerator()
        {
            return _teamPlayersList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _teamPlayersList.GetEnumerator();
        }

        #endregion
    }
}
