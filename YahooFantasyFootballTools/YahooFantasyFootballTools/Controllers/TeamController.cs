using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fantasizer;
using MvcSiteMapProvider;
using Tools.Analysis.Logic;
using YahooFantasyFootballTools.Models;
using MvcSiteMapProvider.Filters;

namespace YahooFantasyFootballTools.Controllers
{
    public class TeamController : BaseAuthenticatedController
    {
        [MvcSiteMapNode(Key = "Keepers", Title="Keepers", ParentKey = "Teams")]
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

        [MvcSiteMapNode(Key = "RosterDepth", Title = "Roster Depth", ParentKey = "Teams")]
        public ActionResult ShowRosterDepth(string teamKey)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, this.UserTokenStore);
            var roster = service.GetRosterPlayers(teamKey);
            var leagueSettings = service.GetLeagueSettings(roster.Team.LeagueKey);

            var depthAnalyzer = new RosterDepthAnalyzer(leagueSettings.RosterPositions, roster.Players);

            var rosterDepthModel = new RosterDepthModel(depthAnalyzer.GetRosterDepth());
            rosterDepthModel.SortPositionDepths();

            return View(rosterDepthModel);
        }
    }
}
