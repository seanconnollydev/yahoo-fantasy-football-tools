using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YahooFantasyFootballTools.Controllers
{
    public class InternalController : Controller
    {
        public ActionResult ListKeys()
        {
            // TODO: Put this check someplace where it can be called on any "Internal" action.
            if (!Request.IsLocal)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.AccessToken = SessionStateUserTokenStore.Current.AccessToken;
            ViewBag.AccessTokenSecret = SessionStateUserTokenStore.Current.AccessTokenSecret;
            ViewBag.IsUserAuthenticated = SessionStateUserTokenStore.Current.IsAuthenticated();

            return View();
        }

    }
}
