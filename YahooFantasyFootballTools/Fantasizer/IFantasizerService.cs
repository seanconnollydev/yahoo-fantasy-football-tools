using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Fantasizer.Domain;

namespace Fantasizer
{
    // TODO: Document
    public interface IFantasizerService
    {
        void BeginAuthorization(Uri callback);

        void CompleteAuthorization();

        XDocument ExecuteRawRequest(string requestUri);

        Team GetTeam(string teamKey);

        LeagueTeamCollection GetTeams(string leagueKey);

        LeagueTeamPlayerCollection<Player> GetLeagueTeamPlayers(string leagueKey);

        LeagueCollection GetLeagues(int gameId);

        LeagueCollection GetLeagues(GameCode gameCode);

        LeagueDraftResultCollection GetDraftResults(string leagueKey);

        TeamRosterPlayerCollection GetRosterPlayers(string teamKey, int? week);

        TeamPlayerCollection<PlayerWithStats> GetTeamPlayerStats(string teamKey);

        LeagueSettings GetLeagueSettings(string leagueKey);

        ICollection<Game> GetGames();

        ICollection<Matchup> GetMatchups(string teamKey);
    }
}
