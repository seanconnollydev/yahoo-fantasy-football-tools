using System.Web.Mvc;
using Fantasizer;
using MvcSiteMapProvider;

namespace YahooFantasyFootballTools.Controllers
{
    public class InternalController : BaseAuthenticatedController
    {
        public InternalController(IUserTokenStore userTokenStore, IFantasizerService fantasizer) : base(userTokenStore, fantasizer)
        {
        }

        [MvcSiteMapNode(ParentKey="Home", Title="List Keys")]
        public ActionResult ListKeys()
        {
            // TODO: Put this check someplace where it can be called on any "Internal" action that I want to restrict.
            if (!Request.IsLocal)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.AccessToken = this.UserTokenStore.AccessToken;
            ViewBag.AccessTokenSecret = this.UserTokenStore.AccessTokenSecret;
            ViewBag.IsUserAuthenticated = this.IsUserAuthenticated;

            return View();
        }

        /// <summary>
        /// Action for executing raw requests to Yahoo and viewing response.  Technically this does not need to be restricted
        /// because it does not display sensitive information.
        /// </summary>
        /// <param name="prependedAppendedInputButton"></param>
        /// <returns></returns>
        [MvcSiteMapNode(ParentKey="Home", Title="Show Response")]
        public ActionResult ShowResponse(string appendedInputButton)
        {
            if (!string.IsNullOrEmpty(appendedInputButton))
            {
                ViewBag.XmlResponse = this.Fantasizer.ExecuteRawRequest(appendedInputButton).ToString();
            }
            return View();
        }
    }
}
