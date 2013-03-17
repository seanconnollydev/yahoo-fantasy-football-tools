using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer;
using Tools.Analysis.Domain;

namespace Tools.Analysis.Logic
{
    // TODO: There is some duplicate code in here that can be refactored.
    public class KeeperAnalyzer
    {
        // TODO: I don't like this dependency on the service at all, you can do better self.
        private readonly YahooFantasySportsService _service;
        public KeeperAnalyzer(YahooFantasySportsService service)
        {
            _service = service;
        }

        public List<EligibleKeeper> GetEligibleKeepersForLeague(string leagueKey)
        {
            var leagueTeamPlayers = _service.GetLeagueTeamPlayers(leagueKey);
            var draftResults = _service.GetDraftResults(leagueKey).DraftResults;

            var keepers = new List<EligibleKeeper>();

            foreach (var team in leagueTeamPlayers)
            {
                foreach (var player in team.Players)
                {
                    var keeper = new EligibleKeeper()
                    {
                        TeamName = team.Team.Name,
                        PlayerName = player.Name,
                        PlayerKey = player.Key,
                        IsEligible = true // eligible by default
                    };

                    if (EligibleKeeper.KeptByTeamInPriorSeason(team.Team.Key, player.Key))
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
            }

            return keepers;
        }

        public List<EligibleKeeper> GetEligibleKeepersForTeam(string teamKey)
        {
            var teamPlayers = _service.GetTeamPlayerStats(teamKey);
            var draftResults = _service.GetDraftResults(teamPlayers.Team.LeagueKey).DraftResults;

            var keepers = new List<EligibleKeeper>();

            foreach (var player in teamPlayers.Players)
            {
                var keeper = new EligibleKeeper()
                {
                    TeamName = teamPlayers.Team.Name,
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
