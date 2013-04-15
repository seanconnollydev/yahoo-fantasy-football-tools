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
        [MvcSiteMapNode(Key="Team", ParentKey="League")]
        [SiteMapTitle("TeamName")]
        [SiteMapPreserveParameters]
        public ActionResult ShowTeam(string teamKey)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, this.UserTokenStore);
            var team = service.GetTeam(teamKey);

            ViewData["TeamName"] = team.Name;

            return View(team);
        }

        [MvcSiteMapNode(Key = "Keepers", Title="Keepers", ParentKey = "Team")]
        public ActionResult ListEligibleKeepers(string teamKey)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, this.UserTokenStore);
            var teamPlayers = service.GetTeamPlayerStats(teamKey);
            var draftResults = service.GetDraftResults(teamPlayers.Team.LeagueKey);

            var keeperAnalyzer = new KeeperAnalyzer(teamPlayers, draftResults);
            var keepers = keeperAnalyzer.GetEligibleKeepersForTeam(teamKey);
            var sortedKeepers = keepers.OrderBy(k => k.DraftRound);

            return View(sortedKeepers);
        }

        [MvcSiteMapNode(Key = "RosterDepth", Title = "Roster Depth", ParentKey = "Team")]
        public ActionResult ShowRosterDepth(string teamKey, int? week)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, this.UserTokenStore);
            var roster = service.GetRosterPlayers(teamKey, week);
            var leagueSettings = service.GetLeagueSettings(roster.Team.LeagueKey);

            var depthAnalyzer = new RosterDepthAnalyzer(leagueSettings.RosterPositions, roster.Players);

            var rosterDepthModel = new RosterDepthModel(
                roster.Team,
                depthAnalyzer.GetRosterDepth(week),
                leagueSettings.League.EndWeek);
            rosterDepthModel.CurrentWeek = week;

            return View(rosterDepthModel);
        }
    }
}
