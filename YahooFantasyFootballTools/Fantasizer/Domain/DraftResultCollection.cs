using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class DraftResultCollection : ICollection<DraftResult>
    {
        private readonly List<DraftResult> _draftResultList;
        private DraftResultCollection()
        {
            _draftResultList = new List<DraftResult>();
        }

        #region ICollection<DraftResult> Members

        public void Add(DraftResult item)
        {
            _draftResultList.Add(item);
        }

        public void Clear()
        {
            _draftResultList.Clear();
        }

        public bool Contains(DraftResult item)
        {
            return _draftResultList.Contains(item);
        }

        public void CopyTo(DraftResult[] array, int arrayIndex)
        {
            _draftResultList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _draftResultList.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(DraftResult item)
        {
            return _draftResultList.Remove(item);
        }

        #endregion

        #region IEnumerable<DraftResult> Members

        public IEnumerator<DraftResult> GetEnumerator()
        {
            return _draftResultList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _draftResultList.GetEnumerator();
        }

        #endregion

        internal static DraftResultCollection CreateFromXml(XDocument xml)
        {
            var draftResults = new DraftResultCollection();

            foreach (var draftResultElement in xml.Descendants(YahooXml.XMLNS + "draft_result"))
            {
                draftResults.Add(DraftResult.CreateFromXml(draftResultElement));
            }

            return draftResults;
        }
    }
}
