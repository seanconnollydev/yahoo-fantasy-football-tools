using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YahooFantasyFootballTools.Models
{
    public class EligibleKeeperModel
    {
        public string PlayerName { get; set; }

        public string PlayerKey { get; set; }

        public int DraftRound { get; set; }

        public bool IsEligible { get; set; }

        public string IneligibilityReason { get; set; }


        private static Dictionary<string, string> _previousKeepers;

        static EligibleKeeperModel()
        {
            _previousKeepers = new Dictionary<string, string>();

            _previousKeepers.Add("273.l.86177.t.1", "273.p.24788"); // Jack Skywalker / Cam Newton
            _previousKeepers.Add("273.l.86177.t.2", "273.p.5228"); // MJSkywkr-A New Hope / Tom Brady
            _previousKeepers.Add("273.l.86177.t.3", "273.p.24017"); // Rob Gronkowski
            _previousKeepers.Add("273.l.86177.t.4", "273.p.23997"); // Wookie of the Year / Demaryius Thomas
            _previousKeepers.Add("273.l.86177.t.5", "273.p.8256"); // Admiral Akbar / Calvin Johnson
            _previousKeepers.Add("273.l.86177.t.6", "273.p.24062"); // RG3PO / Eric Decker
            _previousKeepers.Add("273.l.86177.t.7", "273.p.9265"); // Millenium Falcons / Matthew Stafford
            _previousKeepers.Add("273.l.86177.t.8", "273.p.24070"); // Terrible Tauntauns / Jimmy Graham
            _previousKeepers.Add("273.l.86177.t.9", "273.p.9527"); // Lando Calsleazian / Arian Foster
            _previousKeepers.Add("273.l.86177.t.10", "273.p.24553"); // Emperor Le'monje'llo / Victor Cruz
        }

        public static bool KeptByTeamInPriorSeason(string teamKey, string playerKey)
        {
            return _previousKeepers[teamKey].Equals(playerKey, StringComparison.OrdinalIgnoreCase);
        }
    }

    


}