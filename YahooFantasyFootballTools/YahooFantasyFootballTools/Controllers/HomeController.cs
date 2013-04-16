using System;
using System.Web.Mvc;
using System.Net;
using DotNetOpenAuth.Messaging;
using Fantasizer;
using MvcSiteMapProvider;

namespace YahooFantasyFootballTools.Controllers
{
    public class HomeController : BaseAuthenticatedController
    {
        public HomeController(IUserTokenStore userTokenStore, IFantasizerService fantasizer) : base(userTokenStore, fantasizer)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthenticateWithYahoo()
        {
            // TODO: Clean this up. It is a work around since AppHarbor does not support a callback redirect when a port is specified.
            string hostOrAuthority = Request.IsLocal ? Request.Url.Authority : Request.Url.Host;

            var callbackUri = new Uri(Request.Url.Scheme + "://" + hostOrAuthority + "/Home/YahooOAuthCallback");

            try
            {
                this.Fantasizer.BeginAuthorization(callbackUri);
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
            this.Fantasizer.CompleteAuthorization();
            PopulateUserAuthViewData();

            return RedirectToAction("ListLeagues", "User");
        }

        public ActionResult Logout()
        {
            this.UserTokenStore.AccessToken = default(string);
            this.UserTokenStore.AccessTokenSecret = default(string);
            PopulateUserAuthViewData();

            return View("Index");
        }
    }
}
