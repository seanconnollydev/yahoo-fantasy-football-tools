using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fantasizer.Domain;
using System.Web.Mvc;

namespace YahooFantasyFootballTools.Models
{
    public class LeaguesViewModel
    {
        public LeagueCollection Leagues { get; set; }

        public IEnumerable<SelectListItem> Games { get; set; }
    }
}