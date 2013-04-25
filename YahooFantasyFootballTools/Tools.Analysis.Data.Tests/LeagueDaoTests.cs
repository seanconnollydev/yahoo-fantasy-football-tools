using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Analysis.Data.Entities;
using NHibernate;
using System.IO;
using Tools.Analysis.Data.Tests.Utilities;

namespace Tools.Analysis.Data.Tests
{
    [TestClass]
    public class LeagueDaoTests
    {
        private ISessionFactory _sessionFactory;

        [TestInitialize]
        public void InitializeTest()
        {
            try
            {
                _sessionFactory = AnalysisDataSessionFactory.CreateMsSqlServer2008SessionFactory(DataTestConfiguration.LOCAL_CONNECTION_STRING);
            }
            catch
            {
                Assert.Inconclusive("Skipping test, unable to configure database. This is expected to happen on AppHarbor.");
            }
        }

        [TestMethod]
        public void AllowKeepersFromPriorSeason_DefaultNull()
        {
            const string leagueKey = "League_Key_AllowKeepersFromPriorSeason_DefaultNull";

            using (var session = _sessionFactory.OpenSession())
            {
                var league = new LeagueDao() { Key = leagueKey };

                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(league);
                    transaction.Commit();
                }
            }

            using (var session = _sessionFactory.OpenSession())
            {
                var loadedLeague = session.Get<LeagueDao>(leagueKey);
                Assert.AreEqual(leagueKey, loadedLeague.Key);
                Assert.IsFalse(loadedLeague.AllowKeepersFromPriorSeason.HasValue);
            }
        }

        [TestMethod]
        public void AllowKeepersFromPriorSeason_SetFalse()
        {
            const string leagueKey = "League_Key_AllowKeepersFromPriorSeason_SetFalse";

            using (var session = _sessionFactory.OpenSession())
            {
                var league = new LeagueDao() { Key = leagueKey, AllowKeepersFromPriorSeason = false };

                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(league);
                    transaction.Commit();
                }
            }

            using (var session = _sessionFactory.OpenSession())
            {
                var loadedLeague = session.Get<LeagueDao>(leagueKey);
                Assert.AreEqual(leagueKey, loadedLeague.Key);
                Assert.IsNotNull(loadedLeague.AllowKeepersFromPriorSeason);
                Assert.IsFalse(loadedLeague.AllowKeepersFromPriorSeason.Value);
            }
        }
    }
}
