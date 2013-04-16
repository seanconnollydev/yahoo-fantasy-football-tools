using System.Web;
using System.Web.Mvc;
using Fantasizer;
using MvcSiteMapProvider;
using Tools.Analysis.Logic;
using MvcSiteMapProvider.Filters;
using YahooFantasyFootballTools.Filters;

namespace YahooFantasyFootballTools.Controllers
{
    public class LeagueController : BaseAuthenticatedController
    {
        public LeagueController(IUserTokenStore userTokenStore, IFantasizerService fantasizer) : base(userTokenStore, fantasizer)
        {
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

        public FileResult DownloadEligibleKeepers(string leagueKey)
        {
            var leagueTeamPlayers = this.Fantasizer.GetLeagueTeamPlayers(leagueKey);
            var draftResults = this.Fantasizer.GetDraftResults(leagueKey);

            var keepers = new KeeperAnalyzer(leagueTeamPlayers, draftResults);
            var writer = new EligibleKeeperWriter(keepers.GetEligibleKeepersForLeague(leagueKey));

            return File(writer.ToCsvArray(), "text/csv", "eligible-keepers.csv");
        }
    }
}
