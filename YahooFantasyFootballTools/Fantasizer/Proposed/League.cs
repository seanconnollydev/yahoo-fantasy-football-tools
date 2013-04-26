using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Proposed
{
    public class League : IResource
    {
        #region IResource Members

        public string Key { get; set; }

        public string ToRequest()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
