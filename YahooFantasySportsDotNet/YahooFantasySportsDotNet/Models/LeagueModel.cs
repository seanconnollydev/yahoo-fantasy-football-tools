using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YahooFantasySportsDotNet.Models
{
    public class LeagueModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class LeagueModelList : List<LeagueModel>
    {

    }
}