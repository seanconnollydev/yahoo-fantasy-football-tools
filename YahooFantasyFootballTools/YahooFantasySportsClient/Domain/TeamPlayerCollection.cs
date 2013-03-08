using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    public class TeamPlayerCollection
    {
        private TeamPlayerCollection(Team team, PlayerCollection players)
        {
            if (team == null) { throw new ArgumentNullException("team"); }
            if (players == null) { throw new ArgumentNullException("players"); }

            this.Team = team;
            this.Players = players;
        }

        public Team Team { get; private set; }
        public PlayerCollection Players { get; private set; }

        internal static TeamPlayerCollection CreateFromXml(XDocument xml)
        {
            var team = Team.CreateFromXml(xml.Root.Element(YahooXml.XMLNS + "team"));
            var players = PlayerCollection.CreateFromXml(xml);

            return new TeamPlayerCollection(team, players);
        }
    }
}

/*
<fantasy_content xml:lang="en-US" yahoo:uri="http://fantasysports.yahooapis.com/fantasy/v2/team/273.l.86177.t.4/draftresults" xmlns:yahoo="http://www.yahooapis.com/v1/base.rng" time="52.631139755249ms" copyright="Data provided by Yahoo! and STATS, LLC" refresh_rate="60" xmlns="http://fantasysports.yahooapis.com/fantasy/v2/base.rng">
  <team>
    <team_key>273.l.86177.t.4</team_key>
    <team_id>4</team_id>
    <name>Wookie of the Year</name>
    <is_owned_by_current_login>1</is_owned_by_current_login>
    <url>http://football.fantasysports.yahoo.com/archive/nfl/2012/86177/4</url>
    <team_logos>
      <team_logo>
        <size>medium</size>
        <url>http://l.yimg.com/a/i/identity2/profile_48b.png</url>
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
    <draft_results count="15">
      <draft_result>
        <pick>2</pick>
        <round>1</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.9317</player_key>
      </draft_result>
      <draft_result>
        <pick>19</pick>
        <round>2</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.24791</player_key>
      </draft_result>
      <draft_result>
        <pick>22</pick>
        <round>3</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.6783</player_key>
      </draft_result>
      <draft_result>
        <pick>39</pick>
        <round>4</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.8001</player_key>
      </draft_result>
      <draft_result>
        <pick>42</pick>
        <round>5</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.8504</player_key>
      </draft_result>
      <draft_result>
        <pick>59</pick>
        <round>6</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.6624</player_key>
      </draft_result>
      <draft_result>
        <pick>62</pick>
        <round>7</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.24892</player_key>
      </draft_result>
      <draft_result>
        <pick>79</pick>
        <round>8</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.6405</player_key>
      </draft_result>
      <draft_result>
        <pick>82</pick>
        <round>9</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.25715</player_key>
      </draft_result>
      <draft_result>
        <pick>99</pick>
        <round>10</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.24860</player_key>
      </draft_result>
      <draft_result>
        <pick>102</pick>
        <round>11</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.24846</player_key>
      </draft_result>
      <draft_result>
        <pick>119</pick>
        <round>12</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.23996</player_key>
      </draft_result>
      <draft_result>
        <pick>122</pick>
        <round>13</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.100009</player_key>
      </draft_result>
      <draft_result>
        <pick>139</pick>
        <round>14</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.6243</player_key>
      </draft_result>
      <draft_result>
        <pick>142</pick>
        <round>15</round>
        <team_key>273.l.86177.t.4</team_key>
        <player_key>273.p.23997</player_key>
      </draft_result>
    </draft_results>
  </team>
</fantasy_content>
*/