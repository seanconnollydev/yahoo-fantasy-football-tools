using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fantasizer.Tests.Utilities;
using Fantasizer.Domain;

namespace Fantasizer.Tests
{
    [TestClass]
    public class RosterTests
    {
        [TestMethod]
        public void GetRoster()
        {
            var service = new YahooFantasySportsService(ClientTestConfiguration.CONSUMER_KEY, ClientTestConfiguration.CONSUMER_SECRET, new TestUserTokenStore());
            
            string leagueKey = service.CurrentUser.GetLeagues().First().Key;
            League league = service.GetLeague(leagueKey);

            string teamKey = league.GetTeams().First().Key;
            Team team = service.GetTeam(teamKey);
            Roster roster = team.GetRoster();

            Assert.IsTrue(roster.GetPlayers().Count() > 0);
        }
    }
}
