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
using System.Collections.Generic;
using Fantasizer.Domain;

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
                roster,
                depthAnalyzer.GetRosterDepth(roster.Week),
                leagueSettings.League.EndWeek);

            return View(rosterDepthModel);
        }

        [MvcSiteMapNode(Key = "WeeklyRosterDepth", Title = "Weekly Roster Depth", ParentKey = "Team")]
        public ActionResult ShowWeeklyRosterDepth(string teamKey)
        {
            var matchups = this.Fantasizer.GetMatchups(teamKey);
            LeagueSettings leagueSettings = null;

            var weeklyRosterDepthModels = new List<WeeklyRosterDepthModel>();
            foreach (var matchup in matchups)
            {
                var weeklyModel = new WeeklyRosterDepthModel();
                weeklyModel.Week = matchup.Week;
                
                var rosterSelf = this.Fantasizer.GetRosterPlayers(matchup.TeamKeySelf, matchup.Week);
                if (leagueSettings == null)
                {
                    leagueSettings = this.Fantasizer.GetLeagueSettings(rosterSelf.Team.LeagueKey);
                }
                var depthAnalyzerSelf = new RosterDepthAnalyzer(leagueSettings.RosterPositions, rosterSelf.Players);
                weeklyModel.TeamSelf = new WeeklyTeamRosterDepthModel();
                weeklyModel.TeamSelf.TeamName = rosterSelf.Team.Name;
                weeklyModel.TeamSelf.TeamKey = rosterSelf.Team.Key;
                var positionDepths = new List<PositionDepthModel>();
                foreach (var positionDepth in depthAnalyzerSelf.GetRosterDepth(matchup.Week))
                {
                    if ((int)positionDepth.Value < 3)
                    {
                        var pdModel = new PositionDepthModel();
                        pdModel.PositionName = positionDepth.Key.DisplayName;
                        pdModel.DepthName = positionDepth.Value.ToString();
                        pdModel.DepthValue = positionDepth.Value;
                        positionDepths.Add(pdModel);
                    }
                }
                weeklyModel.TeamSelf.PositionDepths = positionDepths;
                
                var rosterOpponent = this.Fantasizer.GetRosterPlayers(matchup.TeamKeyOpponent, matchup.Week);
                var depthAnalyzerOpponent = new RosterDepthAnalyzer(leagueSettings.RosterPositions, rosterOpponent.Players);

                weeklyModel.TeamOpponent = new WeeklyTeamRosterDepthModel();
                weeklyModel.TeamOpponent.TeamName = rosterOpponent.Team.Name;
                weeklyModel.TeamOpponent.TeamKey = rosterOpponent.Team.Key;
                var positionDepthsOpponent = new List<PositionDepthModel>();
                foreach (var positionDepth in depthAnalyzerOpponent.GetRosterDepth(matchup.Week))
                {
                    if ((int)positionDepth.Value < 3)
                    {
                        var pdModel = new PositionDepthModel();
                        pdModel.PositionName = positionDepth.Key.DisplayName;
                        pdModel.DepthName = positionDepth.Value.ToString();
                        pdModel.DepthValue = positionDepth.Value;
                        positionDepthsOpponent.Add(pdModel);
                    }
                }
                weeklyModel.TeamOpponent.PositionDepths = positionDepthsOpponent;
                weeklyRosterDepthModels.Add(weeklyModel);
            }

            return View(weeklyRosterDepthModels);
        }
    }
}
