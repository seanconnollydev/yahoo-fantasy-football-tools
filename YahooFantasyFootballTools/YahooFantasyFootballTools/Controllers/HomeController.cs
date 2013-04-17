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
        private readonly IApplicationConfiguration _configuration;
        public HomeController(IUserTokenStore userTokenStore, IFantasizerService fantasizer, IApplicationConfiguration configuration) : base(userTokenStore, fantasizer)
        {
            _configuration = configuration;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthenticateWithYahoo()
        {
            string host;
            if (_configuration.YahooCallbackUriType == YahooCallbackUriType.Host)
            {
                host = Request.Url.Host;
            }
            else if (_configuration.YahooCallbackUriType == YahooCallbackUriType.Authority)
            {
                host = Request.Url.Authority;
            }
            else
            {
                throw new Exception("Unrecognized YahooCallbackUriType.");
            }

            var callbackUri = new Uri(Request.Url.Scheme + "://" + host + "/Home/YahooOAuthCallback");

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
