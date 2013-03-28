using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;

namespace Tools.Analysis.Tests.Utilities
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

        public IDictionary<string, RosterPosition> CreateDefaultRosterPositions()
        {
            var rosterPositionMap = new Dictionary<string, RosterPosition>();
            rosterPositionMap.Add("QB", new RosterPosition(new Position("QB"), 1));
            rosterPositionMap.Add("RB", new RosterPosition(new Position("RB"), 2));
            rosterPositionMap.Add("WR", new RosterPosition(new Position("WR"), 2));
            rosterPositionMap.Add("W/R", new RosterPosition(new Position("W/R"), 1));
            rosterPositionMap.Add("TE", new RosterPosition(new Position("TE"), 1));
            rosterPositionMap.Add("DST", new RosterPosition(new Position("DST"), 1));
            rosterPositionMap.Add("K", new RosterPosition(new Position("K"), 1));
            rosterPositionMap.Add("BN", new RosterPosition(new Position("BN"), 6));
            return rosterPositionMap;
        }

        public ICollection<Player> CreatePlayers(params string[] positionNames)
        {
            var players = new List<Player>();
            foreach (string positionName in positionNames)
            {
                players.Add(this.CreatePlayer(positionName));
            }

            return players;
        }
    }
}
