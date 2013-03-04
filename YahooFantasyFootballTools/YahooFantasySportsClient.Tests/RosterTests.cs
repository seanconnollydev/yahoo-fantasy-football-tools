﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahooFantasySportsClient.Tests.Utilities;
using YahooFantasySportsClient.Domain;

namespace YahooFantasySportsClient.Tests
{
    [TestClass]
    public class RosterTests
    {
        [TestMethod]
        public void GetRoster()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());
            Roster roster = service.CurrentUser.GetLeagues().First().GetTeams().First().GetRoster();

            Assert.IsTrue(roster.GetPlayers().Count() > 0);
        }
    }
}