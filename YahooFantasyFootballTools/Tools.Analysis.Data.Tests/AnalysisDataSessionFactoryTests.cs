using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tools.Analysis.Data.Tests.Utilities;

namespace Tools.Analysis.Data.Tests
{
    [TestClass]
    public class AnalysisDataSessionFactoryTests
    {
        [TestMethod]
        public void CreateMsSqlServer2008SessionFactory()
        {
            var sessionFactory = AnalysisDataSessionFactory.CreateMsSqlServer2008SessionFactory(DataTestConfiguration.LOCAL_CONNECTION_STRING);
            Assert.IsNotNull(sessionFactory);
        }
    }
}
