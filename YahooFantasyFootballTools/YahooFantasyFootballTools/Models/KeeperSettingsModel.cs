using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools.Analysis.Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YahooFantasyFootballTools.Models
{
    public class KeeperSettingsModel
    {
        public KeeperSettingsModel()
        {
            
        }

        public KeeperSettingsModel(LeagueDao leagueData)
        {
            this.AllowKeepersFromPriorSeason = leagueData.AllowKeepersFromPriorSeason.GetValueOrDefault(false);
            this.LeagueKey = leagueData.Key;
        }

        [Required]
        public bool AllowKeepersFromPriorSeason { get; set; }

        [Required(AllowEmptyStrings=false)]
        public string LeagueKey { get; set; }
    }
}