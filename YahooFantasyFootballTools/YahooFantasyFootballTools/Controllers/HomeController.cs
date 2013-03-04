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
using YahooFantasySportsClient;

namespace YahooFantasyFootballTools.Controllers
{
    public class HomeController : Controller
    {
        // TODO: Move these some where more configurey and secure
        private const string CONSUMER_KEY = "dj0yJmk9ZTAySXBKS1Z1SkJpJmQ9WVdrOU9YZGlPRmx4TXpJbWNHbzlPVEU1TnpReE9EWXkmcz1jb25zdW1lcnNlY3JldCZ4PTQx";
        private const string CONSUMER_SECRET = "85ab28cc61cd2c48a977ea19c0cf5ce352124091";

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            ViewBag.IsUserAuthenticated = false;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult AuthenticateWithYahoo()
        {
            var service = new YahooFantasySportsService(CONSUMER_KEY, CONSUMER_SECRET, SessionStateUserTokenStore.Current);
            var callbackUri = new Uri(Request.Url.Scheme + "://" + Request.Url.Authority + "/Home/YahooOAuthCallback");
            service.BeginAuthorization(callbackUri);

            // This will not get hit
            return null;
        }

        public ActionResult YahooOAuthCallback()
        {
            var service = new YahooFantasySportsService(CONSUMER_KEY, CONSUMER_SECRET, SessionStateUserTokenStore.Current);
            service.CompleteAuthorization();
            ViewBag.IsUserAuthenticated = true;
            
            return View("Index");
        }

        public ActionResult ListLeagues()
        {
            var service = new YahooFantasySportsService(CONSUMER_KEY, CONSUMER_SECRET, SessionStateUserTokenStore.Current);
            var leagues = LeagueModelList.ConvertToModel(service.CurrentUser.GetLeagues());

            return View(leagues);
        }
    }
}
