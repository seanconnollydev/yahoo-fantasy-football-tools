using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Analysis.Data.Entities;
using FluentNHibernate.Mapping;

namespace Tools.Analysis.Data.Mappings
{
    public class LeagueMap : ClassMap<LeagueDao>
    {
        public LeagueMap()
        {
            Table("League");
            Id(x => x.Key).GeneratedBy.Assigned().Column("[Key]");
            Map(x => x.AllowKeepersFromPriorSeason);
        }
    }
}
