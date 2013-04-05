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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthenticateWithYahoo()
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, this.UserTokenStore);

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
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, this.UserTokenStore);
            service.CompleteAuthorization();
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
