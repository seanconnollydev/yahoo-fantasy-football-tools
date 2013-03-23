using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        protected void PopulateUserAuthViewData()
        {
            ViewBag.IsUserAuthenticated = SessionStateUserTokenStore.Current.IsAuthenticated();
        }
    }
}
