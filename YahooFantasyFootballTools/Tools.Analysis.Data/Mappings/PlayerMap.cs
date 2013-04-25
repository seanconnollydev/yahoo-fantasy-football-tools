using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Tools.Analysis.Data.Entities;

namespace Tools.Analysis.Data.Mappings
{
    public class PlayerMap : ClassMap<PlayerDao>
    {
        public PlayerMap()
        {
            Table("Player");
            Id(x => x.Key).GeneratedBy.Assigned();
            HasManyToMany(x => x.KeptInSeasons)
                .Table("SeasonKeptPlayer");
        }
    }
}
