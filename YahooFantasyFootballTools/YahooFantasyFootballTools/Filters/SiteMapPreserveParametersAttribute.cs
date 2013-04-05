using System.Web;
using System.Web.Mvc;
using MvcSiteMapProvider;

namespace YahooFantasyFootballTools.Filters
{
    public class SiteMapPreserveParametersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var node = SiteMap.CurrentNode as MvcSiteMapNode;

            if (node != null)
            {
                foreach (var parameter in filterContext.ActionParameters)
                {
                    node.RouteValues[parameter.Key] = parameter.Value;
                }
            }   
        }
    }
}