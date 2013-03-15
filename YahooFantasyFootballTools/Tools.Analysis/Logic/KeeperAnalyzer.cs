using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer;
using Tools.Analysis.Domain;

namespace Tools.Analysis.Logic
{
    public class KeeperAnalyzer
    {
        // TODO: I don't like this dependency on the service at all, you can do better self.
        private readonly YahooFantasySportsService _service;
        public KeeperAnalyzer(YahooFantasySportsService service)
        {
            _service = service;
        }

        //public List<EligibleKeeper> GetEligibleKeepersForLeague(string leagueKey)
        //{
        //    var teamPlayers = _service.Get
        //    var draftResults = _service.GetDraftResults(teamPlayers.Team.LeagueKey).DraftResults;

        //    var keepers = new List<EligibleKeeper>();

        //    foreach (var player in teamPlayers.Players)
        //    {
        //        var keeper = new EligibleKeeper()
        //        {
        //            PlayerName = player.Name,
        //            PlayerKey = player.Key,
        //            LastSeasonPoints = player.Points.Total,
        //            IsEligible = true // eligible by default
        //        };

        //        if (EligibleKeeper.KeptByTeamInPriorSeason(teamPlayers.Team.Key, player.Key))
        //        {
        //            keeper.IsEligible = false;
        //            keeper.IneligibilityReason = "This player was kept last season";
        //        }
        //        else
        //        {
        //            var playerDraftResult = draftResults.FirstOrDefault(d => d.PlayerKey == player.Key);
        //            keeper.DraftRound = playerDraftResult != null ? playerDraftResult.Round : 15;
        //        }

        //        keepers.Add(keeper);
        //    }

        //    return keepers;
        //}

        public List<EligibleKeeper> GetEligibleKeepersForTeam(string teamKey)
        {
            var teamPlayers = _service.GetTeamPlayerStats(teamKey);
            var draftResults = _service.GetDraftResults(teamPlayers.Team.LeagueKey).DraftResults;

            var keepers = new List<EligibleKeeper>();

            foreach (var player in teamPlayers.Players)
            {
                var keeper = new EligibleKeeper()
                {
                    PlayerName = player.Name,
                    PlayerKey = player.Key,
                    LastSeasonPoints = player.Points.Total,
                    IsEligible = true // eligible by default
                };

                if (EligibleKeeper.KeptByTeamInPriorSeason(teamPlayers.Team.Key, player.Key))
                {
                    keeper.IsEligible = false;
                    keeper.IneligibilityReason = "This player was kept last season";
                }
                else
                {
                    var playerDraftResult = draftResults.FirstOrDefault(d => d.PlayerKey == player.Key);
                    keeper.DraftRound = playerDraftResult != null ? playerDraftResult.Round : 15;
                }

                keepers.Add(keeper);
            }

            return keepers;
        }
    }
}
