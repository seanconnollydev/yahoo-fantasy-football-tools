using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fantasizer;
using MvcSiteMapProvider;
using Tools.Analysis.Logic;
using YahooFantasyFootballTools.Models;
using MvcSiteMapProvider.Filters;
using System;
using YahooFantasyFootballTools.Filters;

namespace YahooFantasyFootballTools.Controllers
{
    public class TeamController : BaseAuthenticatedController
    {
        public TeamController(IUserTokenStore userTokenStore, IFantasizerService fantasizer) : base(userTokenStore, fantasizer)
        {
        }

        [MvcSiteMapNode(Key="Team", ParentKey="League")]
        [SiteMapTitle("TeamName")]
        [SiteMapPreserveParameters]
        public ActionResult ShowTeam(string teamKey)
        {
            var team = this.Fantasizer.GetTeam(teamKey);

            ViewData["TeamName"] = team.Name;

            return View(team);
        }

        [MvcSiteMapNode(Key = "Keepers", Title="Keepers", ParentKey = "Team")]
        public ActionResult ListEligibleKeepers(string teamKey)
        {
            var teamPlayers = this.Fantasizer.GetTeamPlayerStats(teamKey);
            var draftResults = this.Fantasizer.GetDraftResults(teamPlayers.Team.LeagueKey);

            var keeperAnalyzer = new KeeperAnalyzer(teamPlayers, draftResults);
            var keepers = keeperAnalyzer.GetEligibleKeepersForTeam(teamKey);
            var sortedKeepers = keepers.OrderBy(k => k.DraftRound);

            return View(sortedKeepers);
        }

        [MvcSiteMapNode(Key = "RosterDepth", Title = "Roster Depth", ParentKey = "Team")]
        public ActionResult ShowRosterDepth(string teamKey, int? week)
        {
            var roster = this.Fantasizer.GetRosterPlayers(teamKey, week);
            var leagueSettings = this.Fantasizer.GetLeagueSettings(roster.Team.LeagueKey);


            var depthAnalyzer = new RosterDepthAnalyzer(leagueSettings.RosterPositions, roster.Players);

            var rosterDepthModel = new RosterDepthModel(
                roster.Team,
                depthAnalyzer.GetRosterDepth(week),
                leagueSettings.League.EndWeek,
                roster.Week);

            return View(rosterDepthModel);
        }
    }
}
