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
        private readonly RosterDepthResult _rosterDepth;
        public RosterDepthModel(Team team, RosterDepthResult rosterDepth, int weeks, int selectedWeek)
        {
            this.Team = team;
            _rosterDepth = rosterDepth;
            this.Weeks = weeks;
            this.SelectedWeek = selectedWeek;
            Initialize();
        }

        private void Initialize()
        {
            var depthList = new List<PositionDepthModel>();

            foreach (var positionDepth in _rosterDepth.PositionDepthResults)
            {
                var positionDepthModel = new PositionDepthModel
                {
                    PositionName = positionDepth.Key.DisplayName,
                    DepthName = positionDepth.Value.Depth.ToString(),
                    DepthValue = positionDepth.Value.Depth
                };

                foreach (var playerAssignmentResult in positionDepth.Value.PlayerAssignmentResults)
                {
                    positionDepthModel.PlayerAssignments.Add(new PlayerAssignmentModel(playerAssignmentResult));
                }

                depthList.Add(positionDepthModel);
            }

            this.PositionDepths = depthList;
        }

        public Team Team { get; private set; }

        public IEnumerable<PositionDepthModel> PositionDepths { get; private set; }

        public int SelectedWeek { get; private set; }

        public int Weeks { get; private set; }

        public void SortPositionDepths()
        {
            this.PositionDepths = this.PositionDepths.OrderBy(d => d.DepthValue);
        }
    }

    public class PositionDepthModel
    {
        public PositionDepthModel()
        {
            this.PlayerAssignments = new List<PlayerAssignmentModel>();
        }

        public string PositionName { get; set; }
        public string DepthName { get; set; }
        public PositionDepth DepthValue { get; set; }
        public IList<PlayerAssignmentModel> PlayerAssignments { get; private set; }
    }

    public class PlayerAssignmentModel
    {
        public PlayerAssignmentModel(PlayerAssignmentResult playerAssignmentResult)
        {
            this.PlayerName = playerAssignmentResult.Player.Name;
            this.Reason = playerAssignmentResult.Reason.ToString();
        }

        public string PlayerName { get; private set; }
        public string Reason { get; private set; }
    }
}