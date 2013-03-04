using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooFantasySportsClient.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }

        public Roster GetRoster()
        {
            throw new NotImplementedException();
        }
    }
}
