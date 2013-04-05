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
        [MvcSiteMapNode(Key = "Teams", ParentKey = "Leagues")]
        [SiteMapTitle("LeagueName")]
        [SiteMapPreserveParameters]
        public ActionResult ListTeams(string leagueKey)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, this.UserTokenStore);
            var teams = service.GetTeams(leagueKey);

            ViewData["LeagueName"] = teams.League.Name;

            return View(teams.Teams);
        }

        public FileResult DownloadEligibleKeepers(string leagueKey)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, this.UserTokenStore);
            var leagueTeamPlayers = service.GetTeamPlayerStats(leagueKey);
            var draftResults = service.GetDraftResults(leagueKey);

            var keepers = new KeeperAnalyzer(leagueTeamPlayers, draftResults);
            var writer = new EligibleKeeperWriter(keepers.GetEligibleKeepersForLeague(leagueKey));

            return File(writer.ToCsvArray(), "text/csv", "eligible-keepers.csv");
        }
    }
}
