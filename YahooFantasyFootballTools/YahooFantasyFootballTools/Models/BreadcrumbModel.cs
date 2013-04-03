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
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public bool IsCurrent { get; set; }
    }
}