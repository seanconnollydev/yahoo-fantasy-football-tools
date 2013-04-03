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
        public RosterDepthModel(IDictionary<Position, PositionDepth> rosterDepth)
        {
            _rosterDepth = rosterDepth;
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

        public IEnumerable<PositionDepthModel> PositionDepths { get; private set; }

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