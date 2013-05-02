using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Proposed
{
    // TODO: Consider renaming this to a ResourceRequest.
    public abstract class Resource
    {
        internal string Key { get; set; }

        public virtual T Includes<T>()
        {
            throw new NotImplementedException();
        }

        public virtual T Includes<T>(params string[] keys)
        {
            throw new NotImplementedException();
        }

        internal abstract string ToRequest();
    }
}
