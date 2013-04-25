using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fantasizer.Domain;

namespace YahooFantasyFootballTools.Tests.Utilities
{
    internal class TestObjectFactory
    {
        public ICollection<Game> CreateGames()
        {
            var games = new List<Game>();

            int season = 2012;
            for (int i = 0; i < 10; i++)
            {
                games.Add(new Game(GameCode.nfl, i, season--));
            }

            return games;
        }

        public LeagueCollection CreateLeagueCollection()
        {
            var leagues = new LeagueCollection();
            
            for (int i = 0; i < 3; i++)
            {
                leagues.Add(new League(i, "League_" + i, "LeagueKey_" + i, 1, 16));
            }

            return leagues;
        }

        public LeagueTeamCollection CreateLeagueTeamCollection(string leagueName, string leagueKey)
        {
            var league = new League(1, leagueName, leagueKey, 1, 16);
            var teamCollection = new TeamCollection();
            teamCollection.Add(new Team(1, "team_key", "team_name"));
            return new LeagueTeamCollection(league, teamCollection);
        }

        public LeagueTeamPlayerCollection<Player> CreateLeagueTeamPlayerCollection(string leagueKey)
        {
            var leagueTeamPlayers = new LeagueTeamPlayerCollection<Player>();

            for (int i = 1; i <= 15; i++)
            {
                var team = new Team(i, "TeamKey_" + i, "Team " + i);
                var players = this.CreatePlayerCollection();
                leagueTeamPlayers.Add(new TeamPlayerCollection<Player>(team, players));
            }

            return leagueTeamPlayers;
        }

        public TeamPlayerCollection<PlayerWithStats> CreateTeamPlayerCollection(string teamKey)
        {
            var team = new Team(1, teamKey, "Team 1");
            var players = this.CreatePlayerWithStatsCollection();

            return new TeamPlayerCollection<PlayerWithStats>(team, players);
        }

        public PlayerCollection<Player> CreatePlayerCollection()
        {
            var players = new PlayerCollection<Player>();

            for (int i = 0; i < 15; i++)
            {
                players.Add(new Player(i, "PlayerKey_" + i, "Player " + i, null, null));
            }

            return players;
        }

        public PlayerCollection<PlayerWithStats> CreatePlayerWithStatsCollection()
        {
            var players = this.CreatePlayerCollection();
            var playersWithStats = new PlayerCollection<PlayerWithStats>();

            foreach (var player in players)
            {
                playersWithStats.Add(new PlayerWithStats(
                    player,
                    new PlayerStats(),
                    new PlayerPoints(2013, 200)));
            }

            return playersWithStats;
        }

        public LeagueDraftResultCollection CreateLeagueDraftResultCollection(int leagueId, string leagueKey)
        {
            var league = new League(leagueId, "League " + leagueId, leagueKey, 1, 16);
            var draftResults = CreateDraftResultCollection();
            return new LeagueDraftResultCollection(league, draftResults);
        }

        public DraftResultCollection CreateDraftResultCollection()
        {
            var draftResults = new DraftResultCollection();

            for (int i = 1; i <= 150; i++)
            {
                draftResults.Add(new DraftResult(i, (i % 15) + 1, "TeamKey_" + i, "PlayerKey_" + (i * 10)));
            }

            return draftResults;
        }
    }
}
