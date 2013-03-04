using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YahooFantasyFootballTools.Models
{
    public class LeagueModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static LeagueModel ConvertToModel(YahooFantasySportsClient.Domain.League league)
        {
            return new LeagueModel()
            {
                Id = league.Id,
                Name = league.Name
            };
        }
    }

    public class LeagueModelList : List<LeagueModel>
    {
        public static LeagueModelList ConvertToModel(IEnumerable<YahooFantasySportsClient.Domain.League> leagues)
        {
            var leaguesList = new LeagueModelList();

            foreach (var league in leagues)
            {
                leaguesList.Add(LeagueModel.ConvertToModel(league));
            }

            return leaguesList;
        }
    }
}