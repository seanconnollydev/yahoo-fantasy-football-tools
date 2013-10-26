using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fantasizer.Domain;
using Tools.Analysis.Domain;

namespace YahooFantasyFootballTools.Models
{
    public class RosterDepthModel
    {
        private readonly IDictionary<Position, PositionDepth> _rosterDepth;
        public RosterDepthModel(TeamRosterPlayerCollection roster, IDictionary<Position, PositionDepth> rosterDepth, int weeks)
        {
            this.Team = roster.Team;
            _rosterDepth = rosterDepth;
            this.Weeks = weeks;
            this.SelectedWeek = roster.Week;
            this.Players = roster.Players.OrderBy(p => p.EligiblePositions.First().Abbreviation);
            Initialize();
        }

        private void Initialize()
        {
            var depthList = new List<PositionDepthModel>();

            foreach (var positionDepth in _rosterDepth)
            {
                depthList.Add(new PositionDepthModel
                {
                    PositionName = positionDepth.Key.DisplayName,
                    DepthName = positionDepth.Value.ToString(),
                    DepthValue = positionDepth.Value});
            }

            this.PositionDepths = depthList;
        }

        public Team Team { get; private set; }

        public IEnumerable<PositionDepthModel> PositionDepths { get; private set; }

        public int SelectedWeek { get; private set; }

        public int Weeks { get; private set; }

        public IEnumerable<Player> Players { get; set; }

        public void SortPositionDepths()
        {
            this.PositionDepths = this.PositionDepths.OrderBy(d => d.DepthValue);
        }
    }

    public class PositionDepthModel
    {
        public string PositionName { get; set; }
        public string DepthName { get; set; }
        public PositionDepth DepthValue { get; set; }
    }
}