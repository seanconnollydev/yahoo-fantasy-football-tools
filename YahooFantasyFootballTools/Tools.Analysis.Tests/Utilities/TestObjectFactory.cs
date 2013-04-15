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
        public Player CreatePlayer(Position singlePosition, int byeWeek)
        {
            int id = _nextPlayerId++;
            
            string key = string.Format("{0}_key", id);
            string name = string.Format("{0}_name", id);

            var eligiblePositions = new List<Position>();
            eligiblePositions.Add(singlePosition);

            var byeWeeks = new List<int>() { byeWeek };

            var player = new Player(id, key, name, eligiblePositions, byeWeeks);
            return player;
        }

        public IDictionary<PositionAbbreviation, RosterPosition> CreateDefaultRosterPositions()
        {
            var rosterPositionMap = new Dictionary<PositionAbbreviation, RosterPosition>();
            rosterPositionMap.Add(PositionAbbreviation.QB, new RosterPosition(Position.Quarterback, 1));
            rosterPositionMap.Add(PositionAbbreviation.RB, new RosterPosition(Position.RunningBack, 2));
            rosterPositionMap.Add(PositionAbbreviation.WR, new RosterPosition(Position.WideReceiver, 2));
            rosterPositionMap.Add(PositionAbbreviation.W_R, new RosterPosition(Position.WideReceiverRunningBack, 1));
            rosterPositionMap.Add(PositionAbbreviation.TE, new RosterPosition(Position.TightEnd, 1));
            rosterPositionMap.Add(PositionAbbreviation.DEF, new RosterPosition(Position.Defense, 1));
            rosterPositionMap.Add(PositionAbbreviation.K, new RosterPosition(Position.Kicker, 1));
            rosterPositionMap.Add(PositionAbbreviation.BN, new RosterPosition(Position.Bench, 6));
            return rosterPositionMap;
        }

        public ICollection<Player> CreatePlayers(params Position[] positions)
        {
            Random random = new Random();
            var players = new List<Player>();
            foreach (var position in positions)
            {
                players.Add(this.CreatePlayer(position, random.Next(4, 11)));
            }

            return players;
        }
    }
}
