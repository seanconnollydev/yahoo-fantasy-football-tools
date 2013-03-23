using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fantasizer;

namespace YahooFantasyFootballTools.Controllers
{
    public class InternalController : BaseAuthenticatedController
    {
        public ActionResult ListKeys()
        {
            // TODO: Put this check someplace where it can be called on any "Internal" action that I want to restrict.
            if (!Request.IsLocal)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.AccessToken = SessionStateUserTokenStore.Current.AccessToken;
            ViewBag.AccessTokenSecret = SessionStateUserTokenStore.Current.AccessTokenSecret;
            ViewBag.IsUserAuthenticated = SessionStateUserTokenStore.Current.IsAuthenticated();

            return View();
        }

        /// <summary>
        /// Action for executing raw requests to Yahoo and viewing response.  Technically this does not need to be restricted
        /// because it does not display sensitive information.
        /// </summary>
        /// <param name="sUri"></param>
        /// <returns></returns>
        public ActionResult ShowResponse(string sUri)
        {
            if (!string.IsNullOrEmpty(sUri))
            {
                var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, SessionStateUserTokenStore.Current);
                ViewBag.XmlResponse = service.ExecuteRawRequest(sUri).ToString();
            }
            return View();
        }
    }
}
