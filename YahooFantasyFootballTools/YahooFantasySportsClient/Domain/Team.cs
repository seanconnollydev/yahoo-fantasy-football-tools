using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooFantasySportsClient.Domain
{
    public class Team
    {
        private readonly OAuthClient _oAuthClient;

        public Team(OAuthClient oAuthClient)
        {
            _oAuthClient = oAuthClient;
        }

        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }

        public Roster GetRoster()
        {
            return new Roster(_oAuthClient, this);
        }
    }
}
