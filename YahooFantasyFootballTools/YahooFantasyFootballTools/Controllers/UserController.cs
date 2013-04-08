using System.Web.Mvc;
using Fantasizer;
using MvcSiteMapProvider;

namespace YahooFantasyFootballTools.Controllers
{
    public class UserController : BaseAuthenticatedController
    {
        [MvcSiteMapNode(Key="User", Title="Leagues", ParentKey="Home")]
        public ActionResult ListLeagues()
        {
            var service = new YahooFantasySportsService(Configuration.ConsumerKey, Configuration.ConsumerSecret, this.UserTokenStore);
            var leagues = service.GetLeagues();

            return View(leagues);
        }
    }
}
