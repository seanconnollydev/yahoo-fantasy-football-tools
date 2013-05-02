using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Proposed
{
    public class Leagues<TParent> : IResource
    {
        public TParent Parent { get; set; }

        #region IResource Members

        public string Key
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ToRequest()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
