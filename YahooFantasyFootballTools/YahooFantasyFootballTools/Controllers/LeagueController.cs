using System.Web;
using System.Web.Mvc;
using Fantasizer;
using MvcSiteMapProvider;
using Tools.Analysis.Logic;
using MvcSiteMapProvider.Filters;
using YahooFantasyFootballTools.Filters;
using System;
using YahooFantasyFootballTools.Models;
using NHibernate;
using Tools.Analysis.Data.Entities;

namespace YahooFantasyFootballTools.Controllers
{
    public class LeagueController : BaseAuthenticatedController
    {
        private readonly ISessionFactory _sessionFactory;
        public LeagueController(IUserTokenStore userTokenStore, IFantasizerService fantasizer, ISessionFactory sessionFactory) : base(userTokenStore, fantasizer)
        {
            _sessionFactory = sessionFactory;
        }

        [MvcSiteMapNode(Key = "League", ParentKey = "User")]
        [SiteMapTitle("LeagueName")]
        [SiteMapPreserveParameters]
        public ActionResult ListTeams(string leagueKey)
        {
            var teams = this.Fantasizer.GetTeams(leagueKey);

            ViewData["LeagueName"] = teams.League.Name;

            return View(teams);
        }

        public ActionResult DownloadEligibleKeepers(string leagueKey)
        {
            var leagueTeamPlayers = this.Fantasizer.GetLeagueTeamPlayers(leagueKey);
            var draftResults = this.Fantasizer.GetDraftResults(leagueKey);

            // TODO: This block is mostly duplicated with the TeamController's ListEligibleKeepers action.
            LeagueDao leagueData;
            using (var session = _sessionFactory.OpenSession())
            {
                leagueData = session.Get<LeagueDao>(draftResults.League.Key);
                if (leagueData == null || !leagueData.AllowKeepersFromPriorSeason.HasValue)
                {
                    TempData["UserAlertMessage"] = "You must specify your league's keeper settings before proceeding.";
                    return RedirectToAction("ViewKeeperSettings", "League", new { leagueKey = draftResults.League.Key });
                }
            }

            var keepers = new KeeperAnalyzer(leagueTeamPlayers, draftResults, leagueData.AllowKeepersFromPriorSeason.Value);
            var writer = new EligibleKeeperWriter(keepers.GetEligibleKeepersForLeague(leagueKey));

            return File(writer.ToCsvArray(), "text/csv", "eligible-keepers.csv");
        }

        [MvcSiteMapNode(Key="KeeperSettings", ParentKey="League", Title="Keeper Settings")]
        public ActionResult ViewKeeperSettings(string leagueKey)
        {
            KeeperSettingsModel model;

            using (var session = _sessionFactory.OpenSession())
            {
                var leagueData = session.Get<LeagueDao>(leagueKey);

                if (leagueData != null)
                {
                    model = new KeeperSettingsModel(leagueData);
                }
                else
                {
                    model = new KeeperSettingsModel() { LeagueKey = leagueKey };
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateKeeperSettings(KeeperSettingsModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Invalid KeeperSettingsModel detected.");
            }

            using (var session = _sessionFactory.OpenSession())
            {
                var leagueData = session.Get<LeagueDao>(model.LeagueKey) ?? new LeagueDao() { Key = model.LeagueKey };

                using (var transaction = session.BeginTransaction())
                {
                    leagueData.AllowKeepersFromPriorSeason = model.AllowKeepersFromPriorSeason;
                    session.SaveOrUpdate(leagueData);
                    transaction.Commit();
                }
            }

            TempData["UserSuccessMessage"] = "Keeper settings successfully saved.";
            return RedirectToAction("ListTeams", new { leagueKey = model.LeagueKey });
        }
    }
}
