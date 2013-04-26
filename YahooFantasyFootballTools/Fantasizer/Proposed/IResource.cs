using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Proposed
{
    public interface IResource
    {
        string Key { get; set; }
        string ToRequest();
    }
}
