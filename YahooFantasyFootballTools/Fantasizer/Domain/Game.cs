using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Domain
{
    public class Game
    {
        internal Game(GameCode gamecode, int id, int season)
        {
            this.GameCode = gamecode;
            this.Id = id;
            this.Season = season;
        }

        public GameCode GameCode { get; private set; }

        public int Id { get; private set; }

        public int Season { get; private set; }
    }
}
