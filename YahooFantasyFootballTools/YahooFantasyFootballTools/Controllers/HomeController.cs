using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using DotNetOpenAuth.Messaging;
using Tools.Analysis.Logic;
using YahooFantasyFootballTools.Models;
using System.Xml.Linq;
using System.Xml;
using Fantasizer;
using Fantasizer.Domain;

namespace YahooFantasyFootballTools.Controllers
{
    public class HomeController : BaseAuthenticatedController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthenticateWithYahoo()
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);

            // TODO: Clean this up. It is a work around since AppHarbor does not support a callback redirect when a port is specified.
            string hostOrAuthority = Request.IsLocal ? Request.Url.Authority : Request.Url.Host;

            var callbackUri = new Uri(Request.Url.Scheme + "://" + hostOrAuthority + "/Home/YahooOAuthCallback");

            try
            {
                service.BeginAuthorization(callbackUri);
            }
            catch (ProtocolException pe)
            {
                var webException = pe.InnerException as WebException;
                if (webException != null)
                {
                    HttpWebResponse response = webException.Response as HttpWebResponse;
                    if (response != null && response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        var appException =
                            new ApplicationException(
                                "Unable to authorize with Yahoo. Check YahooConsumerKey and YahooConsumerSecret environment variables.",
                                pe);

                        throw appException;
                    }
                }

                throw;
            }

            // This will not get hit
            return null;
        }

        public ActionResult YahooOAuthCallback()
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            service.CompleteAuthorization();
            PopulateUserAuthViewData();

            return RedirectToAction("ListLeagues");
        }

        public ActionResult ListLeagues()
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            var leagues = service.GetLeagues();

            var items = new List<BreadcrumbItemModel>();
            items.Add(new BreadcrumbItemModel() { LinkText = "Home", ActionName = "Index", IsCurrent = false });
            items.Add((new BreadcrumbItemModel() {LinkText = "Leagues", IsCurrent = true}));
            this.ViewBag.BreadcrumbModel = new BreadcrumbModel(items);

            return View(leagues);
        }

        public ActionResult ListTeams(string leagueKey)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            var teams = service.GetTeams(leagueKey);

            var items = new List<BreadcrumbItemModel>();
            items.Add(new BreadcrumbItemModel() { LinkText = "Home", ActionName = "Index", IsCurrent = false });
            items.Add(new BreadcrumbItemModel()
                {
                    LinkText = "Leagues",
                    ActionName = "ListLeagues",
                    IsCurrent = false
                });
            items.Add(new BreadcrumbItemModel() {LinkText = teams.League.Name, IsCurrent = true});
            this.ViewBag.BreadcrumbModel = new BreadcrumbModel(items);

            return View(teams.Teams);
        }

        public ActionResult ListEligibleKeepers(string teamKey)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            var teamPlayers = service.GetTeamPlayerStats(teamKey);
            var draftResults = service.GetDraftResults(teamPlayers.Team.LeagueKey);
            
            var keeperAnalyzer = new KeeperAnalyzer(teamPlayers, draftResults);
            var keepers = keeperAnalyzer.GetEligibleKeepersForTeam(teamKey);
            var sortedKeepers = keepers.OrderBy(k => k.DraftRound);

            var items = new List<BreadcrumbItemModel>();
            items.Add(new BreadcrumbItemModel() { LinkText = "Home", ActionName = "Index", IsCurrent = false });
            items.Add(new BreadcrumbItemModel()
            {
                LinkText = "Leagues",
                ActionName = "ListLeagues",
                IsCurrent = false
            });
            items.Add(new BreadcrumbItemModel()
                {
                    LinkText = draftResults.League.Name,
                    ActionName = "ListTeams",
                    RouteValues = new {leagueKey = draftResults.League.Key}
                });
            items.Add(new BreadcrumbItemModel() { LinkText = "Keepers", IsCurrent = true });
            this.ViewBag.BreadcrumbModel = new BreadcrumbModel(items);

            return View(sortedKeepers);
        }

        public ActionResult Logout()
        {
            SessionStateUserTokenStore.Current.AccessToken = default(string);
            SessionStateUserTokenStore.Current.AccessTokenSecret = default(string);
            PopulateUserAuthViewData();

            return View("Index");
        }

        public FileResult DownloadEligibleKeepers(string leagueKey)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            var leagueTeamPlayers = service.GetTeamPlayerStats(leagueKey);
            var draftResults = service.GetDraftResults(leagueKey);

            var keepers = new KeeperAnalyzer(leagueTeamPlayers, draftResults);
            var writer = new EligibleKeeperWriter(keepers.GetEligibleKeepersForLeague(leagueKey));

            return File(writer.ToCsvArray(), "text/csv", "eligible-keepers.csv");
        }

        public ActionResult ShowRosterDepth(string teamKey)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            var roster = service.GetRosterPlayers(teamKey);
            var leagueSettings = service.GetLeagueSettings(roster.Team.LeagueKey);

            var depthAnalyzer = new RosterDepthAnalyzer(leagueSettings.RosterPositions, roster.Players);

            var rosterDepthModel = new RosterDepthModel(depthAnalyzer.GetRosterDepth());
            rosterDepthModel.SortPositionDepths();

            var items = new List<BreadcrumbItemModel>();
            items.Add(new BreadcrumbItemModel() { LinkText = "Home", ActionName = "Index", IsCurrent = false });
            items.Add(new BreadcrumbItemModel()
            {
                LinkText = "Leagues",
                ActionName = "ListLeagues",
                IsCurrent = false
            });
            items.Add(new BreadcrumbItemModel()
                {
                    LinkText = leagueSettings.League.Name,
                    ActionName = "ListTeams",
                    IsCurrent = false,
                    RouteValues = new {leagueKey = leagueSettings.League.Key}
                });
            items.Add(new BreadcrumbItemModel() { LinkText = "Roster Depth", IsCurrent = true });
            this.ViewBag.BreadcrumbModel = new BreadcrumbModel(items);

            return View(rosterDepthModel);
        }
    }
}
