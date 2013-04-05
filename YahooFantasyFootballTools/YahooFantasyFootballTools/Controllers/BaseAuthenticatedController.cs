using System.Web.Mvc;
using System.Web.SessionState;

namespace YahooFantasyFootballTools.Controllers
{
    /// <summary>
    /// Base controller when OAuth authentication is required
    /// </summary>
    public abstract class BaseAuthenticatedController : Controller
    {
        public BaseAuthenticatedController()
            : base()
        {
            PopulateUserAuthViewData();
        }

        private SessionStateUserTokenStore _userTokenStore;
        protected SessionStateUserTokenStore UserTokenStore
        {
            get
            {
                if (_userTokenStore == null)
                {
                    _userTokenStore = new SessionStateUserTokenStore(System.Web.HttpContext.Current.Session);
                }

                return _userTokenStore;
            }
        }

        protected void PopulateUserAuthViewData()
        {
            ViewBag.IsUserAuthenticated = this.UserTokenStore.IsAuthenticated();
        }
    }
}
