using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Fantasizer.Xml;

namespace Fantasizer.Domain
{
    public class LeagueCollection : ICollection<League>
    {
        private readonly List<League> _leagueList;

        public LeagueCollection()
        {
            _leagueList = new List<League>();
        }

        #region ICollection<League> Members

        public void Add(League item)
        {
            _leagueList.Add(item);
        }

        public void Clear()
        {
            _leagueList.Clear();
        }

        public bool Contains(League item)
        {
            return _leagueList.Contains(item);
        }

        public void CopyTo(League[] array, int arrayIndex)
        {
            _leagueList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _leagueList.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(League item)
        {
            return _leagueList.Remove(item);
        }

        #endregion

        #region IEnumerable<League> Members

        public IEnumerator<League> GetEnumerator()
        {
            return _leagueList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _leagueList.GetEnumerator();
        }

        #endregion

        internal static LeagueCollection CreateFromXml(XDocument xml)
        {
            var leagues = new LeagueCollection();
            foreach (var leagueElement in xml.Descendants(YahooXml.XMLNS + "league"))
            {
                leagues.Add(ResponseDeserializer.DeserializeLeague(leagueElement));
            }

            return leagues;
        }
    }
}
