using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;

namespace Fantasizer.Tests.Utilities
{
    public class TestObjectFactory
    {
        private static int _nextPlayerId = 1;
        public Player CreatePlayer(string singlePosition)
        {
            int id = _nextPlayerId++;
            
            string key = string.Format("{0}_key", id);
            string name = string.Format("{0}_name", id);

            var eligiblePositions = new List<Position>();
            eligiblePositions.Add(new Position(singlePosition));

            var player = new Player(id, key, name, eligiblePositions);
            return player;
        }
    }
}
