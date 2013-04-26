using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Proposed
{
    public class Game : IResource
    {
        public Leagues Leagues
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #region IResource Members

        public string Key { get; set; }

        public string ToRequest()
        {
            return "/game/" + this.Key;
        }

        #endregion
    }
}
