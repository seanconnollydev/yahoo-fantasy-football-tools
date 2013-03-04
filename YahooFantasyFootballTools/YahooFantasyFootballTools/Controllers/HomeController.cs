using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.OAuth;
using System.Net;
using System.IO;
using YahooFantasyFootballTools.Models;
using System.Xml.Linq;
using System.Xml;

namespace YahooFantasyFootballTools.Controllers
{
    public class HomeController : Controller
    {
        // TODO: Move these some where more configurey and secure
        private const string CONSUMER_KEY = "dj0yJmk9ZTAySXBKS1Z1SkJpJmQ9WVdrOU9YZGlPRmx4TXpJbWNHbzlPVEU1TnpReE9EWXkmcz1jb25zdW1lcnNlY3JldCZ4PTQx";
        private const string CONSUMER_SECRET = "85ab28cc61cd2c48a977ea19c0cf5ce352124091";
        private const string ACCESS_TOKEN_SESSION_KEY = "ACCESS_TOKEN";

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
            var wrapper = new OAuthWrapper(this.Session, CONSUMER_KEY, CONSUMER_SECRET);
            var callbackUri = new Uri(Request.Url.Scheme + "://" + Request.Url.Authority + "/Home/YahooOAuthCallback");
            wrapper.BeginAuth(callbackUri);

            // This will not get hit
            return null;
        }

        public ActionResult YahooOAuthCallback()
        {
            var wrapper = new OAuthWrapper(this.Session, CONSUMER_KEY, CONSUMER_SECRET);
            this.Session[ACCESS_TOKEN_SESSION_KEY] = wrapper.CompleteAuth();

            ViewBag.IsUserAuthenticated = true;
            
            return View("Index");
        }

        public ActionResult ListLeagues()
        {
            var leagues = new LeagueModelList();
            var wrapper = new OAuthWrapper(this.Session, CONSUMER_KEY, CONSUMER_SECRET);

            var request = wrapper.PrepareAuthorizedRequest(
                "http://fantasysports.yahooapis.com/fantasy/v2/users;use_login=1/games;game_keys=nfl/leagues",
                (string)this.Session[ACCESS_TOKEN_SESSION_KEY]);

            XDocument xmlDoc;
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    xmlDoc = XDocument.Load(responseStream);
                }
            }

            XNamespace ns = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng";

            foreach (var leagueElement in xmlDoc.Descendants(ns + "league"))
            {
                leagues.Add(new LeagueModel() {
                    Id = Convert.ToInt32(leagueElement.Element(ns + "league_id").Value),
                    Name = leagueElement.Element(ns + "name").Value
                });
            }

            return View(leagues);
        }
    }
}
