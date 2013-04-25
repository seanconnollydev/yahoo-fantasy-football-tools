using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Fantasizer;
using MvcSiteMapProvider;
using Tools.Analysis.Logic;
using YahooFantasyFootballTools.Models;
using MvcSiteMapProvider.Filters;
using System;
using YahooFantasyFootballTools.Filters;
using NHibernate;
using Tools.Analysis.Data.Entities;

namespace YahooFantasyFootballTools.Controllers
{
    public class TeamController : BaseAuthenticatedController
    {
        private readonly ISessionFactory _sessionFactory;

        public TeamController(
            IUserTokenStore userTokenStore,
            IFantasizerService fantasizer,
            ISessionFactory sessionFactory) : base(userTokenStore, fantasizer)
        {
            _sessionFactory = sessionFactory;
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

            // TODO: This block is mostly duplicated with the LeagueController's DownloadEligibleKeepers action.
            LeagueDao leagueData;
            using (var session = _sessionFactory.OpenSession())
            {
                leagueData = session.Get<LeagueDao>(draftResults.League.Key);
                if (leagueData == null || !leagueData.AllowKeepersFromPriorSeason.HasValue)
                {
                    TempData["UserAlertMessage"] = "You must specify your league's keeper settings before proceeding.";
                    return RedirectToAction("ViewKeeperSettings", "League", new { leagueKey = draftResults.League.Key});
                }
            }

            var keeperAnalyzer = new KeeperAnalyzer(teamPlayers, draftResults, leagueData.AllowKeepersFromPriorSeason.Value);
            var keepers = keeperAnalyzer.GetEligibleKeepersForTeam(teamKey);
            var sortedKeepers = keepers.OrderBy(k => k.DraftRound);

            var model = new EligibleKeeperModel()
            {
                Team = teamPlayers.Team,
                EligibleKeepers = sortedKeepers
            };

            return View(model);
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
