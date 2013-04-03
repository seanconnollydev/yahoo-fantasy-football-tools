using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Fantasizer.Xml;

namespace Fantasizer.Domain
{
    public class LeagueTeamCollection
    {
        private LeagueTeamCollection(League league, TeamCollection teams)
        {
            if (league == null) { throw new ArgumentNullException("league"); }
            if (teams == null) { throw new ArgumentNullException("teams"); }

            this.League = league;
            this.Teams = teams;
        }

        public League League { get; private set; }

        public TeamCollection Teams { get; private set; }

        internal static LeagueTeamCollection CreateFromXml(XDocument xml)
        {
            var leagueElement = xml.Root.Element(YahooXml.XMLNS + "league");

            var league = ResponseDeserializer.DeserializeLeague(leagueElement);
            var teams = TeamCollection.CreateFromXml(xml);

            return new LeagueTeamCollection(league, teams);
        }
    }
}

/*
<fantasy_content xml:lang="en-US" yahoo:uri="http://fantasysports.yahooapis.com/fantasy/v2/league/273.l.86177/teams" xmlns:yahoo="http://www.yahooapis.com/v1/base.rng" time="72.704792022705ms" copyright="Data provided by Yahoo! and STATS, LLC" refresh_rate="60" xmlns="http://fantasysports.yahooapis.com/fantasy/v2/base.rng">
  <league>
    <league_key>273.l.86177</league_key>
    <league_id>86177</league_id>
    <name>Let the Wookie Win</name>
    <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177</url>
    <draft_status>postdraft</draft_status>
    <num_teams>10</num_teams>
    <edit_key>17</edit_key>
    <weekly_deadline />
    <league_update_timestamp>1357340032</league_update_timestamp>
    <scoring_type>head</scoring_type>
    <league_type>private</league_type>
    <is_pro_league>0</is_pro_league>
    <current_week>16</current_week>
    <start_week>1</start_week>
    <start_date>2012-09-05</start_date>
    <end_week>16</end_week>
    <end_date>2012-12-24</end_date>
    <is_finished>1</is_finished>
    <teams count="10">
      <team>
        <team_key>273.l.86177.t.1</team_key>
        <team_id>1</team_id>
        <name>Jack Skywalker</name>
        <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/1</url>
        <team_logos>
          <team_logo>
            <size>medium</size>
            <url>http://l.yimg.com/a/i/identity2/profile_48e.png</url>
          </team_logo>
        </team_logos>
        <division_id>1</division_id>
        <waiver_priority>8</waiver_priority>
        <number_of_moves>35</number_of_moves>
        <number_of_trades>0</number_of_trades>
        <roster_adds>
          <coverage_type>week</coverage_type>
          <coverage_value>17</coverage_value>
          <value>0</value>
        </roster_adds>
        <clinched_playoffs>1</clinched_playoffs>
        <managers>
          <manager>
            <manager_id>1</manager_id>
            <nickname>John Connolly</nickname>
            <guid>ME664JYLOTFUFAAKM5YDYUOIPE</guid>
            <is_commissioner>1</is_commissioner>
          </manager>
        </managers>
      </team>
      <team>
        <team_key>273.l.86177.t.2</team_key>
        <team_id>2</team_id>
        <name>MJSkywkr-A New Hope</name>
        <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/2</url>
        <team_logos>
          <team_logo>
            <size>medium</size>
            <url>http://l.yimg.com/a/i/us/sp/fn/default/full/nfl/icon_05_48.gif</url>
          </team_logo>
        </team_logos>
        <division_id>1</division_id>
        <waiver_priority>1</waiver_priority>
        <number_of_moves>18</number_of_moves>
        <number_of_trades>1</number_of_trades>
        <roster_adds>
          <coverage_type>week</coverage_type>
          <coverage_value>17</coverage_value>
          <value>0</value>
        </roster_adds>
        <managers>
          <manager>
            <manager_id>2</manager_id>
            <nickname>kizzys</nickname>
            <guid>IWKB2MZG3DIEXYU7UPWS6OHYEA</guid>
          </manager>
        </managers>
      </team>
      <team>
        <team_key>273.l.86177.t.3</team_key>
        <team_id>3</team_id>
        <name>Jabba the Hut Hut!</name>
        <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/3</url>
        <team_logos>
          <team_logo>
            <size>medium</size>
            <url>http://l.yimg.com/a/i/identity2/profile_48d.png</url>
          </team_logo>
        </team_logos>
        <division_id>1</division_id>
        <waiver_priority>10</waiver_priority>
        <number_of_moves>26</number_of_moves>
        <number_of_trades>0</number_of_trades>
        <roster_adds>
          <coverage_type>week</coverage_type>
          <coverage_value>17</coverage_value>
          <value>0</value>
        </roster_adds>
        <clinched_playoffs>1</clinched_playoffs>
        <managers>
          <manager>
            <manager_id>3</manager_id>
            <nickname>Michelle</nickname>
            <guid>MYQMXD7WMSRBVZ3GIHKIWASW64</guid>
          </manager>
        </managers>
      </team>
      <team>
        <team_key>273.l.86177.t.4</team_key>
        <team_id>4</team_id>
        <name>Wookie of the Year</name>
        <is_owned_by_current_login>1</is_owned_by_current_login>
        <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/4</url>
        <team_logos>
          <team_logo>
            <size>medium</size>
            <url>http://l.yimg.com/a/i/identity2/profile_48e.png</url>
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
      <team>
        <team_key>273.l.86177.t.5</team_key>
        <team_id>5</team_id>
        <name>Admiral Akbar</name>
        <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/5</url>
        <team_logos>
          <team_logo>
            <size>medium</size>
            <url>http://l.yimg.com/a/i/identity2/profile_48a.png</url>
          </team_logo>
        </team_logos>
        <division_id>1</division_id>
        <waiver_priority>5</waiver_priority>
        <number_of_moves>15</number_of_moves>
        <number_of_trades>0</number_of_trades>
        <roster_adds>
          <coverage_type>week</coverage_type>
          <coverage_value>17</coverage_value>
          <value>0</value>
        </roster_adds>
        <clinched_playoffs>1</clinched_playoffs>
        <managers>
          <manager>
            <manager_id>5</manager_id>
            <nickname>Guido</nickname>
            <guid>4MY6XS5TNEFRC6SG3WDWRUSHGM</guid>
            <is_commissioner>1</is_commissioner>
          </manager>
        </managers>
      </team>
      <team>
        <team_key>273.l.86177.t.6</team_key>
        <team_id>6</team_id>
        <name>RG3PO</name>
        <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/6</url>
        <team_logos>
          <team_logo>
            <size>medium</size>
            <url>http://l.yimg.com/a/i/identity2/profile_48d.png</url>
          </team_logo>
        </team_logos>
        <division_id>1</division_id>
        <waiver_priority>7</waiver_priority>
        <number_of_moves>36</number_of_moves>
        <number_of_trades>0</number_of_trades>
        <roster_adds>
          <coverage_type>week</coverage_type>
          <coverage_value>17</coverage_value>
          <value>0</value>
        </roster_adds>
        <clinched_playoffs>1</clinched_playoffs>
        <managers>
          <manager>
            <manager_id>6</manager_id>
            <nickname>Barry</nickname>
            <guid>FR66YFDJRFNUDAJS6II4WJPY6U</guid>
          </manager>
        </managers>
      </team>
      <team>
        <team_key>273.l.86177.t.7</team_key>
        <team_id>7</team_id>
        <name>Millennium Falcons</name>
        <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/7</url>
        <team_logos>
          <team_logo>
            <size>medium</size>
            <url>http://l.yimg.com/a/i/us/sp/fn/default/full/nfl/icon_06_48.gif</url>
          </team_logo>
        </team_logos>
        <division_id>2</division_id>
        <waiver_priority>6</waiver_priority>
        <number_of_moves>21</number_of_moves>
        <number_of_trades>0</number_of_trades>
        <roster_adds>
          <coverage_type>week</coverage_type>
          <coverage_value>17</coverage_value>
          <value>0</value>
        </roster_adds>
        <clinched_playoffs>1</clinched_playoffs>
        <managers>
          <manager>
            <manager_id>7</manager_id>
            <nickname>Matthew</nickname>
            <guid>IVSXHQHRB4CJBS3UE37TFJQQOY</guid>
          </manager>
        </managers>
      </team>
      <team>
        <team_key>273.l.86177.t.8</team_key>
        <team_id>8</team_id>
        <name>Terrible Tauntauns</name>
        <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/8</url>
        <team_logos>
          <team_logo>
            <size>medium</size>
            <url>http://l.yimg.com/a/i/us/sp/fn/default/full/nfl/icon_01_48.gif</url>
          </team_logo>
        </team_logos>
        <division_id>2</division_id>
        <waiver_priority>9</waiver_priority>
        <number_of_moves>16</number_of_moves>
        <number_of_trades>0</number_of_trades>
        <roster_adds>
          <coverage_type>week</coverage_type>
          <coverage_value>17</coverage_value>
          <value>0</value>
        </roster_adds>
        <clinched_playoffs>1</clinched_playoffs>
        <managers>
          <manager>
            <manager_id>8</manager_id>
            <nickname>Pam</nickname>
            <guid>D7J7GW3MEMJ35TQAFTAL2HGQ7M</guid>
          </manager>
        </managers>
      </team>
      <team>
        <team_key>273.l.86177.t.9</team_key>
        <team_id>9</team_id>
        <name>Lando Calsleazian</name>
        <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/9</url>
        <team_logos>
          <team_logo>
            <size>medium</size>
            <url>http://l.yimg.com/a/i/identity2/profile_48d.png</url>
          </team_logo>
        </team_logos>
        <division_id>2</division_id>
        <waiver_priority>3</waiver_priority>
        <number_of_moves>18</number_of_moves>
        <number_of_trades>0</number_of_trades>
        <roster_adds>
          <coverage_type>week</coverage_type>
          <coverage_value>17</coverage_value>
          <value>0</value>
        </roster_adds>
        <clinched_playoffs>1</clinched_playoffs>
        <managers>
          <manager>
            <manager_id>9</manager_id>
            <nickname>Patrick Hansen</nickname>
            <guid>6VGORICEVQA4H7JFK2OD3TKNAA</guid>
          </manager>
        </managers>
      </team>
      <team>
        <team_key>273.l.86177.t.10</team_key>
        <team_id>10</team_id>
        <name>Emperor Le'monje'llo</name>
        <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/10</url>
        <team_logos>
          <team_logo>
            <size>medium</size>
            <url>http://l.yimg.com/a/i/identity2/profile_48a.png</url>
          </team_logo>
        </team_logos>
        <division_id>2</division_id>
        <waiver_priority>2</waiver_priority>
        <number_of_moves>23</number_of_moves>
        <number_of_trades>0</number_of_trades>
        <roster_adds>
          <coverage_type>week</coverage_type>
          <coverage_value>17</coverage_value>
          <value>0</value>
        </roster_adds>
        <managers>
          <manager>
            <manager_id>10</manager_id>
            <nickname>Nick Pithis</nickname>
            <guid>EW66YI4HCNOOY72D3TQIFN6AU4</guid>
          </manager>
        </managers>
      </team>
    </teams>
  </league>
</fantasy_content>
*/