using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace YahooFantasyFootballTools.Models
{
    public class BreadcrumbModel
    {
        public BreadcrumbModel(IList<BreadcrumbItemModel> items)
        {
            this.Items = items;
        }

        public IList<BreadcrumbItemModel> Items { get; private set; }
    }

    public class BreadcrumbItemModel
    {
        public BreadcrumbItemModel(string text, MvcHtmlString actionLink, bool isCurrent)
        {
            this.Text = text;
            this.ActionLink = actionLink;
            this.IsCurrent = isCurrent;
        }

        public string Text { get; private set; }
        public MvcHtmlString ActionLink { get; private set; }
        public bool IsCurrent { get; private set; }
    }
}