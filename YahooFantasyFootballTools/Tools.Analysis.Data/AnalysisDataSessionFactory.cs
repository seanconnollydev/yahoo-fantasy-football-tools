using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;

namespace Tools.Analysis.Data
{
    public class AnalysisDataSessionFactory
    {
        public static ISessionFactory CreateMsSqlServer2008SessionFactory(string connectionString)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AnalysisDataSessionFactory>())
                .ExposeConfiguration(UpdateSchema)
                .BuildSessionFactory();
        }

        private static void UpdateSchema(Configuration config)
        {
            new SchemaUpdate(config).Execute(false, true);
        }
    }
}
