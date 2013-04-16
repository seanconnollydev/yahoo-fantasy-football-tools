using System;
using System.Web.Mvc;
using System.Web.SessionState;
using Fantasizer;

namespace YahooFantasyFootballTools.Controllers
{
    /// <summary>
    /// Base controller when OAuth authentication is required
    /// </summary>
    public abstract class BaseAuthenticatedController : Controller
    {
        public BaseAuthenticatedController(IUserTokenStore userTokenStore, IFantasizerService fantasizer)
            : base()
        {
            _userTokenStore = userTokenStore;
            _fantasizer = fantasizer;
            PopulateUserAuthViewData();
        }

        private readonly IUserTokenStore _userTokenStore;
        protected IUserTokenStore UserTokenStore
        {
            get { return _userTokenStore; }
        }

        private readonly IFantasizerService _fantasizer;
        protected IFantasizerService Fantasizer
        {
            get { return _fantasizer; }
        }

        protected bool IsUserAuthenticated
        {
            get
            {
                return !string.IsNullOrEmpty(_userTokenStore.AccessToken) && !string.IsNullOrEmpty(_userTokenStore.AccessTokenSecret);
            }
        }

        protected void PopulateUserAuthViewData()
        {
            ViewBag.IsUserAuthenticated = this.IsUserAuthenticated;
        }
    }
}
