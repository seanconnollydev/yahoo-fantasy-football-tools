using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YahooFantasyFootballTools.Models;
using System.Web.Mvc.Html;

namespace YahooFantasyFootballTools.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Breadcrumb(this HtmlHelper helper, BreadcrumbItemModel item)
        {
            if (item.IsCurrent)
            {
                return MvcHtmlString.Create(item.LinkText);
            }
            else
            {
                return helper.ActionLink(item.LinkText, item.ActionName);    
            }
        }
    }
}