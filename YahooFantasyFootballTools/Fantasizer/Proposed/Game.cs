using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Proposed
{
    public class Game : Resource
    {
        internal override string ToRequest()
        {
            return "/game/" + this.Key;
        }
    }
}
