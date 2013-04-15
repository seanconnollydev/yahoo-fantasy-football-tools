using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class Team
    {
        internal Team(int id, string key, string name)
        {
            this.Id = id;
            this.Key = key;
            this.Name = name;
        }

        public int Id { get; private set; }
        public string Key { get; private set; }
        public string Name { get; private set; }

        private string _leagueKey;
        public string LeagueKey
        {
            get
            {
                if (string.IsNullOrEmpty(_leagueKey))
                {
                    // team_key format is {game_key}.l.{league_id}.t.{team_id}
                    _leagueKey = this.Key.Substring(0, this.Key.IndexOf("t") - 1);
                }

                return _leagueKey;
            }
        }
    }
}

/*
<fantasy_content xml:lang="en-US" yahoo:uri="http://fantasysports.yahooapis.com/fantasy/v2/team/273.l.86177.t.4" xmlns:yahoo="http://www.yahooapis.com/v1/base.rng" time="50.369024276733ms" copyright="Data provided by Yahoo! and STATS, LLC" refresh_rate="60" xmlns="http://fantasysports.yahooapis.com/fantasy/v2/base.rng">
  <team>
    <team_key>273.l.86177.t.4</team_key>
    <team_id>4</team_id>
    <name>Wookie of the Year</name>
    <is_owned_by_current_login>1</is_owned_by_current_login>
    <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/4</url>
    <team_logos>
      <team_logo>
        <size>medium</size>
        <url>http://l.yimg.com/a/i/identity2/profile_48c.png</url>
      </team_logo>
    </team_logos>
    <division_id>2</division_id>
    <waiver_priority>4</waiver_priority>
    <number_of_moves>29</number_of_moves>
    <number_of_trades>1</number_of_trades>
    <roster_adds>
      <coverage_type>week</coverage_type>
      <coverage_value>17</coverage_value>
      <value>0</value>
    </roster_adds>
    <clinched_playoffs>1</clinched_playoffs>
    <managers>
      <manager>
        <manager_id>4</manager_id>
        <nickname>Sean</nickname>
        <guid>K5FUJQOYBEFUDKCE6ABRSYEB2I</guid>
        <is_current_login>1</is_current_login>
      </manager>
    </managers>
  </team>
</fantasy_content>
*/