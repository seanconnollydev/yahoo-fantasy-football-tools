using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Analysis.Data.Entities;
using FluentNHibernate.Mapping;

namespace Tools.Analysis.Data.Mappings
{
    public class SeasonMap : ClassMap<SeasonDao>
    {
        public SeasonMap()
        {
            Table("Season");
            Id(x => x.Season).GeneratedBy.Assigned();
            HasManyToMany(x => x.PlayersKept)
                .Table("SeasonKeptPlayer");
        }
    }
}
