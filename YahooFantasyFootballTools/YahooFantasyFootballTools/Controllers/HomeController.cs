using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using YahooFantasyFootballTools.Models;
using System.Xml.Linq;
using System.Xml;
using Fantasizer;
using Fantasizer.Domain;

namespace YahooFantasyFootballTools.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            PopulateUserAuthViewData();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Login to view your eligible keepers";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult AuthenticateWithYahoo()
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);

            // TODO: Clean this up. It is a work around since AppHarbor does not support a callback redirect when a port is specified.
            string hostOrAuthority = Request.IsLocal ? Request.Url.Authority : Request.Url.Host;

            var callbackUri = new Uri(Request.Url.Scheme + "://" + hostOrAuthority + "/Home/YahooOAuthCallback");
            service.BeginAuthorization(callbackUri);

            // This will not get hit
            return null;
        }

        public ActionResult YahooOAuthCallback()
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            service.CompleteAuthorization();
            PopulateUserAuthViewData();
            
            return View("Index");
        }

        public ActionResult ListLeagues()
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            var leagues = service.GetLeagues();

            return View(leagues);
        }

        public ActionResult ListTeams(string leagueKey)
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            var teams = service.GetTeams(leagueKey);

            return View(teams.Teams);
        }

        public ActionResult ListEligibleKeepers(string teamKey)
        {
            List<EligibleKeeperModel> keepers = new List<EligibleKeeperModel>();
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            var teamPlayers = service.GetTeamPlayerStats(teamKey);
            var draftResults = service.GetDraftResults(teamPlayers.Team.LeagueKey).DraftResults;

            foreach (var player in teamPlayers.Players)
            {
                var keeper = new EligibleKeeperModel(){
                    PlayerName = player.Name,
                    PlayerKey = player.Key,
                    LastSeasonPoints = player.Points.Total,
                    IsEligible = true // eligible by default
                };

                if (EligibleKeeperModel.KeptByTeamInPriorSeason(teamPlayers.Team.Key, player.Key))
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

            var sortedKeepers = keepers.OrderBy(k => k.DraftRound);

            return View(sortedKeepers);
        }

        public ActionResult Logout()
        {
            SessionStateUserTokenStore.Current.AccessToken = default(string);
            SessionStateUserTokenStore.Current.AccessTokenSecret = default(string);
            PopulateUserAuthViewData();

            return View("Index");
        }

        private void PopulateUserAuthViewData()
        {
            ViewBag.IsUserAuthenticated = SessionStateUserTokenStore.Current.IsAuthenticated();
        }
    }
}
