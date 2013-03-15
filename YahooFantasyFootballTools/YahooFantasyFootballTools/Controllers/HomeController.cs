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
    public class HomeController : Controller
    {
        //protected readonly YahooFantasySportsService _yahooService;

        public HomeController()
        {
            //_yahooService = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
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
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            var keeperAnalyzer = new KeeperAnalyzer(service);
            var keepers = keeperAnalyzer.GetEligibleKeepersForTeam(teamKey);
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

        public FileResult DownloadEligibleKeepers(string leagueKey)
        {
            throw new NotImplementedException();
            //var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
            //var keepers = new KeeperAnalyzer(service);
            //var writer = new EligibleKeeperWriter(keepers.GetEligibleKeepers();
        }

        private void PopulateUserAuthViewData()
        {
            ViewBag.IsUserAuthenticated = SessionStateUserTokenStore.Current.IsAuthenticated();
        }
    }
}
