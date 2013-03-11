﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer.Domain
{
    //TODO: Consider renaming this to TeamRoster
    public class TeamRosterPlayerCollection
    {
        private TeamRosterPlayerCollection(Team team, PlayerCollection<Player> players)
        {
            if (team == null) { throw new ArgumentNullException("team"); }
            if (players == null) { throw new ArgumentNullException("players"); }

            this.Team = team;
            this.Players = players;
        }

        public Team Team { get; private set; }
        public PlayerCollection<Player> Players { get; private set; }

        internal static TeamRosterPlayerCollection CreateFromXml(XDocument xml)
        {
            var team = Team.CreateFromXml(xml.Root.Element(YahooXml.XMLNS + "team"));
            var players = new PlayerCollection<Player>(xml);

            return new TeamRosterPlayerCollection(team, players);
        }
    }
}

/*
<?xml version="1.0" encoding="UTF-8"?>
<fantasy_content xmlns:yahoo="http://www.yahooapis.com/v1/base.rng" xmlns="http://fantasysports.yahooapis.com/fantasy/v2/base.rng" xml:lang="en-US" yahoo:uri="http://fantasysports.yahooapis.com/fantasy/v2/team/253.l.102614.t.10/roster/players" time="110.02206802368ms" copyright="Data provided by Yahoo! and STATS, LLC">
  <team>
    <team_key>253.l.102614.t.10</team_key>
    <team_id>10</team_id>
    <name>Matt Dzaman</name>
    <url>http://baseball.fantasysports.yahoo.com/b1/102614/10</url>
    <team_logos>
      <team_logo>
        <size>medium</size>
        <url>http://l.yimg.com/a/i/us/sp/fn/mlb/gr/icon_12_2.gif</url>
      </team_logo>
    </team_logos>
    <managers>
      <manager>
        <manager_id>10</manager_id>
        <nickname>Sean Montgomery</nickname>
        <guid>VZVEVUCLSJAHSM73FMJ4BYFIKU</guid>
        <is_current_login>1</is_current_login>
      </manager>
    </managers>
    <roster>
      <coverage_type>date</coverage_type>
      <date>2011-07-22</date>
      <players count="22">
        <player>
          <player_key>253.p.7569</player_key>
          <player_id>7569</player_id>
          <name>
            <full>Brian McCann</full>
            <first>Brian</first>
            <last>McCann</last>
            <ascii_first>Brian</ascii_first>
            <ascii_last>McCann</ascii_last>
          </name>
          <editorial_player_key>mlb.p.7569</editorial_player_key>
          <editorial_team_key>mlb.t.15</editorial_team_key>
          <editorial_team_full_name>Atlanta Braves</editorial_team_full_name>
          <editorial_team_abbr>Atl</editorial_team_abbr>
          <uniform_number>16</uniform_number>
          <display_position>C</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/7569.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=eYxVIp_jg4DlEZmIgv6idg--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>C</position>
            <position>Util</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>C</position>
          </selected_position>
          <starting_status>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <is_starting>1</is_starting>
          </starting_status>
        </player>
        <player>
          <player_key>253.p.7054</player_key>
          <player_id>7054</player_id>
          <name>
            <full>Adrian Gonzalez</full>
            <first>Adrian</first>
            <last>Gonzalez</last>
            <ascii_first>Adrian</ascii_first>
            <ascii_last>Gonzalez</ascii_last>
          </name>
          <editorial_player_key>mlb.p.7054</editorial_player_key>
          <editorial_team_key>mlb.t.2</editorial_team_key>
          <editorial_team_full_name>Boston Red Sox</editorial_team_full_name>
          <editorial_team_abbr>Bos</editorial_team_abbr>
          <uniform_number>28</uniform_number>
          <display_position>1B</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/7054.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=54BODgSe4P3NxShTjtIt9g--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>1B</position>
            <position>Util</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>1B</position>
          </selected_position>
          <starting_status>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <is_starting>1</is_starting>
          </starting_status>
        </player>
        <player>
          <player_key>253.p.7746</player_key>
          <player_id>7746</player_id>
          <name>
            <full>Howie Kendrick</full>
            <first>Howie</first>
            <last>Kendrick</last>
            <ascii_first>Howie</ascii_first>
            <ascii_last>Kendrick</ascii_last>
          </name>
          <editorial_player_key>mlb.p.7746</editorial_player_key>
          <editorial_team_key>mlb.t.3</editorial_team_key>
          <editorial_team_full_name>Los Angeles Angels</editorial_team_full_name>
          <editorial_team_abbr>LAA</editorial_team_abbr>
          <uniform_number>47</uniform_number>
          <display_position>1B,2B,OF</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/7746.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=O01i1gfOs6RgisJQjmdipQ--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>1B</position>
            <position>2B</position>
            <position>OF</position>
            <position>Util</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <has_recent_player_notes>1</has_recent_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>2B</position>
          </selected_position>
          <starting_status>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <is_starting>0</is_starting>
          </starting_status>
        </player>
        <player>
          <player_key>253.p.7737</player_key>
          <player_id>7737</player_id>
          <name>
            <full>Martin Prado</full>
            <first>Martin</first>
            <last>Prado</last>
            <ascii_first>Martin</ascii_first>
            <ascii_last>Prado</ascii_last>
          </name>
          <editorial_player_key>mlb.p.7737</editorial_player_key>
          <editorial_team_key>mlb.t.15</editorial_team_key>
          <editorial_team_full_name>Atlanta Braves</editorial_team_full_name>
          <editorial_team_abbr>Atl</editorial_team_abbr>
          <uniform_number>14</uniform_number>
          <display_position>2B,3B,OF</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/7737.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=WPYI1xO62JwsL8QturlmJw--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>2B</position>
            <position>3B</position>
            <position>OF</position>
            <position>Util</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>3B</position>
          </selected_position>
          <starting_status>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <is_starting>1</is_starting>
          </starting_status>
        </player>
        <player>
          <player_key>253.p.7744</player_key>
          <player_id>7744</player_id>
          <name>
            <full>Erick Aybar</full>
            <first>Erick</first>
            <last>Aybar</last>
            <ascii_first>Erick</ascii_first>
            <ascii_last>Aybar</ascii_last>
          </name>
          <editorial_player_key>mlb.p.7744</editorial_player_key>
          <editorial_team_key>mlb.t.3</editorial_team_key>
          <editorial_team_full_name>Los Angeles Angels</editorial_team_full_name>
          <editorial_team_abbr>LAA</editorial_team_abbr>
          <uniform_number>2</uniform_number>
          <display_position>SS</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/7744.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=qHzsNyGFtGYxlpMxtysSPQ--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>SS</position>
            <position>Util</position>
          </eligible_positions>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>SS</position>
          </selected_position>
          <starting_status>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <is_starting>1</is_starting>
          </starting_status>
        </player>
        <player>
          <player_key>253.p.7977</player_key>
          <player_id>7977</player_id>
          <name>
            <full>Andrew McCutchen</full>
            <first>Andrew</first>
            <last>McCutchen</last>
            <ascii_first>Andrew</ascii_first>
            <ascii_last>McCutchen</ascii_last>
          </name>
          <editorial_player_key>mlb.p.7977</editorial_player_key>
          <editorial_team_key>mlb.t.23</editorial_team_key>
          <editorial_team_full_name>Pittsburgh Pirates</editorial_team_full_name>
          <editorial_team_abbr>Pit</editorial_team_abbr>
          <uniform_number>22</uniform_number>
          <display_position>OF</display_position>
          <image_url>http://l.yimg.com/a/p/sp/tools/med/2011/05/ipt/1304541420.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=61GeaeZwqXZWy2ITOX62Zg--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>OF</position>
            <position>Util</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>OF</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.7104</player_key>
          <player_id>7104</player_id>
          <name>
            <full>Shane Victorino</full>
            <first>Shane</first>
            <last>Victorino</last>
            <ascii_first>Shane</ascii_first>
            <ascii_last>Victorino</ascii_last>
          </name>
          <editorial_player_key>mlb.p.7104</editorial_player_key>
          <editorial_team_key>mlb.t.22</editorial_team_key>
          <editorial_team_full_name>Philadelphia Phillies</editorial_team_full_name>
          <editorial_team_abbr>Phi</editorial_team_abbr>
          <uniform_number>8</uniform_number>
          <display_position>OF</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/7104.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=QE9iNVRK5VCHq650WQii4g--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>OF</position>
            <position>Util</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>OF</position>
          </selected_position>
          <starting_status>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <is_starting>1</is_starting>
          </starting_status>
        </player>
        <player>
          <player_key>253.p.8239</player_key>
          <player_id>8239</player_id>
          <name>
            <full>Matt Joyce</full>
            <first>Matt</first>
            <last>Joyce</last>
            <ascii_first>Matt</ascii_first>
            <ascii_last>Joyce</ascii_last>
          </name>
          <editorial_player_key>mlb.p.8239</editorial_player_key>
          <editorial_team_key>mlb.t.30</editorial_team_key>
          <editorial_team_full_name>Tampa Bay Rays</editorial_team_full_name>
          <editorial_team_abbr>TB</editorial_team_abbr>
          <uniform_number>20</uniform_number>
          <display_position>OF</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/8239.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=ZIy1Z9IryxkYXVsSsodRfQ--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>OF</position>
            <position>Util</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>OF</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.8857</player_key>
          <player_id>8857</player_id>
          <name>
            <full>Eric Hosmer</full>
            <first>Eric</first>
            <last>Hosmer</last>
            <ascii_first>Eric</ascii_first>
            <ascii_last>Hosmer</ascii_last>
          </name>
          <editorial_player_key>mlb.p.8857</editorial_player_key>
          <editorial_team_key>mlb.t.7</editorial_team_key>
          <editorial_team_full_name>Kansas City Royals</editorial_team_full_name>
          <editorial_team_abbr>KC</editorial_team_abbr>
          <uniform_number>35</uniform_number>
          <display_position>1B</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110706/8857.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=h5CchQfLoumJ6xXRYqQNOw--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>1B</position>
            <position>Util</position>
          </eligible_positions>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>Util</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.8171</player_key>
          <player_id>8171</player_id>
          <name>
            <full>Jay Bruce</full>
            <first>Jay</first>
            <last>Bruce</last>
            <ascii_first>Jay</ascii_first>
            <ascii_last>Bruce</ascii_last>
          </name>
          <editorial_player_key>mlb.p.8171</editorial_player_key>
          <editorial_team_key>mlb.t.17</editorial_team_key>
          <editorial_team_full_name>Cincinnati Reds</editorial_team_full_name>
          <editorial_team_abbr>Cin</editorial_team_abbr>
          <uniform_number>32</uniform_number>
          <display_position>OF</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/8171.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=icy.cvuP8XXvyrQKm7m3HA--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>OF</position>
            <position>Util</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <has_recent_player_notes>1</has_recent_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>BN</position>
          </selected_position>
          <starting_status>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <is_starting>0</is_starting>
          </starting_status>
        </player>
        <player>
          <player_key>253.p.8401</player_key>
          <player_id>8401</player_id>
          <name>
            <full>Elvis Andrus</full>
            <first>Elvis</first>
            <last>Andrus</last>
            <ascii_first>Elvis</ascii_first>
            <ascii_last>Andrus</ascii_last>
          </name>
          <editorial_player_key>mlb.p.8401</editorial_player_key>
          <editorial_team_key>mlb.t.13</editorial_team_key>
          <editorial_team_full_name>Texas Rangers</editorial_team_full_name>
          <editorial_team_abbr>Tex</editorial_team_abbr>
          <uniform_number>1</uniform_number>
          <display_position>SS</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/8401.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=HIAp3xabHCwOw.hJpkbd1w--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>SS</position>
            <position>Util</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <has_recent_player_notes>1</has_recent_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>BN</position>
          </selected_position>
          <starting_status>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <is_starting>1</is_starting>
          </starting_status>
        </player>
        <player>
          <player_key>253.p.7926</player_key>
          <player_id>7926</player_id>
          <name>
            <full>Yovani Gallardo</full>
            <first>Yovani</first>
            <last>Gallardo</last>
            <ascii_first>Yovani</ascii_first>
            <ascii_last>Gallardo</ascii_last>
          </name>
          <editorial_player_key>mlb.p.7926</editorial_player_key>
          <editorial_team_key>mlb.t.8</editorial_team_key>
          <editorial_team_full_name>Milwaukee Brewers</editorial_team_full_name>
          <editorial_team_abbr>Mil</editorial_team_abbr>
          <uniform_number>49</uniform_number>
          <display_position>SP</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/7926.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=1lRXgDptEQng1WvYIB3vDQ--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>P</position_type>
          <eligible_positions>
            <position>SP</position>
            <position>P</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>SP</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.7172</player_key>
          <player_id>7172</player_id>
          <name>
            <full>Dan Haren</full>
            <first>Dan</first>
            <last>Haren</last>
            <ascii_first>Dan</ascii_first>
            <ascii_last>Haren</ascii_last>
          </name>
          <editorial_player_key>mlb.p.7172</editorial_player_key>
          <editorial_team_key>mlb.t.3</editorial_team_key>
          <editorial_team_full_name>Los Angeles Angels</editorial_team_full_name>
          <editorial_team_abbr>LAA</editorial_team_abbr>
          <uniform_number>24</uniform_number>
          <display_position>SP</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/7172.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=fnc4Dr.qGpHVMT8tW4phOQ--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>P</position_type>
          <eligible_positions>
            <position>SP</position>
            <position>P</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>SP</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.6210</player_key>
          <player_id>6210</player_id>
          <name>
            <full>Kyle Farnsworth</full>
            <first>Kyle</first>
            <last>Farnsworth</last>
            <ascii_first>Kyle</ascii_first>
            <ascii_last>Farnsworth</ascii_last>
          </name>
          <editorial_player_key>mlb.p.6210</editorial_player_key>
          <editorial_team_key>mlb.t.30</editorial_team_key>
          <editorial_team_full_name>Tampa Bay Rays</editorial_team_full_name>
          <editorial_team_abbr>TB</editorial_team_abbr>
          <uniform_number>43</uniform_number>
          <display_position>RP</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/6210.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=kJYLFUywffdzSTtTQ5MupQ--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>P</position_type>
          <eligible_positions>
            <position>RP</position>
            <position>P</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>RP</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.8929</player_key>
          <player_id>8929</player_id>
          <name>
            <full>Javy Guerra</full>
            <first>Javy</first>
            <last>Guerra</last>
            <ascii_first>Javy</ascii_first>
            <ascii_last>Guerra</ascii_last>
          </name>
          <editorial_player_key>mlb.p.8929</editorial_player_key>
          <editorial_team_key>mlb.t.19</editorial_team_key>
          <editorial_team_full_name>Los Angeles Dodgers</editorial_team_full_name>
          <editorial_team_abbr>LAD</editorial_team_abbr>
          <uniform_number>54</uniform_number>
          <display_position>RP</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/blank_player2.gif?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=8G0MjQyD1AdYbnv.fd2Wog--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>P</position_type>
          <eligible_positions>
            <position>RP</position>
            <position>P</position>
          </eligible_positions>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>RP</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.7279</player_key>
          <player_id>7279</player_id>
          <name>
            <full>Jesse Crain</full>
            <first>Jesse</first>
            <last>Crain</last>
            <ascii_first>Jesse</ascii_first>
            <ascii_last>Crain</ascii_last>
          </name>
          <editorial_player_key>mlb.p.7279</editorial_player_key>
          <editorial_team_key>mlb.t.4</editorial_team_key>
          <editorial_team_full_name>Chicago White Sox</editorial_team_full_name>
          <editorial_team_abbr>CWS</editorial_team_abbr>
          <uniform_number>26</uniform_number>
          <display_position>RP</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/7279.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=Xx9Emr_lBK3smmABr7fOcg--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>P</position_type>
          <eligible_positions>
            <position>RP</position>
            <position>P</position>
          </eligible_positions>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>P</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.8193</player_key>
          <player_id>8193</player_id>
          <name>
            <full>Max Scherzer</full>
            <first>Max</first>
            <last>Scherzer</last>
            <ascii_first>Max</ascii_first>
            <ascii_last>Scherzer</ascii_last>
          </name>
          <editorial_player_key>mlb.p.8193</editorial_player_key>
          <editorial_team_key>mlb.t.6</editorial_team_key>
          <editorial_team_full_name>Detroit Tigers</editorial_team_full_name>
          <editorial_team_abbr>Det</editorial_team_abbr>
          <uniform_number>37</uniform_number>
          <display_position>SP</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/8193.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=lcgNVFPn0gpchY5fCbb6nw--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>P</position_type>
          <eligible_positions>
            <position>SP</position>
            <position>P</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>P</position>
          </selected_position>
          <starting_status>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <is_starting>1</is_starting>
          </starting_status>
        </player>
        <player>
          <player_key>253.p.8099</player_key>
          <player_id>8099</player_id>
          <name>
            <full>Ian Kennedy</full>
            <first>Ian</first>
            <last>Kennedy</last>
            <ascii_first>Ian</ascii_first>
            <ascii_last>Kennedy</ascii_last>
          </name>
          <editorial_player_key>mlb.p.8099</editorial_player_key>
          <editorial_team_key>mlb.t.29</editorial_team_key>
          <editorial_team_full_name>Arizona Diamondbacks</editorial_team_full_name>
          <editorial_team_abbr>Ari</editorial_team_abbr>
          <uniform_number>31</uniform_number>
          <display_position>SP</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/8099.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=TjXYM8e9wtrcLfrhDnCMKQ--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>P</position_type>
          <eligible_positions>
            <position>SP</position>
            <position>P</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <has_recent_player_notes>1</has_recent_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>P</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.8179</player_key>
          <player_id>8179</player_id>
          <name>
            <full>Gio Gonzalez</full>
            <first>Gio</first>
            <last>Gonzalez</last>
            <ascii_first>Gio</ascii_first>
            <ascii_last>Gonzalez</ascii_last>
          </name>
          <editorial_player_key>mlb.p.8179</editorial_player_key>
          <editorial_team_key>mlb.t.11</editorial_team_key>
          <editorial_team_full_name>Oakland Athletics</editorial_team_full_name>
          <editorial_team_abbr>Oak</editorial_team_abbr>
          <uniform_number>47</uniform_number>
          <display_position>SP</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/8179.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=Wg7KqIjVG4zwo0znBbEViw--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>P</position_type>
          <eligible_positions>
            <position>SP</position>
            <position>P</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>BN</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.8759</player_key>
          <player_id>8759</player_id>
          <name>
            <full>Michael Pineda</full>
            <first>Michael</first>
            <last>Pineda</last>
            <ascii_first>Michael</ascii_first>
            <ascii_last>Pineda</ascii_last>
          </name>
          <editorial_player_key>mlb.p.8759</editorial_player_key>
          <editorial_team_key>mlb.t.12</editorial_team_key>
          <editorial_team_full_name>Seattle Mariners</editorial_team_full_name>
          <editorial_team_abbr>Sea</editorial_team_abbr>
          <uniform_number>36</uniform_number>
          <display_position>SP</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/8759.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=31SmIDWcet4v3AVAOGrY2g--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>P</position_type>
          <eligible_positions>
            <position>SP</position>
            <position>P</position>
          </eligible_positions>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>BN</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.6571</player_key>
          <player_id>6571</player_id>
          <name>
            <full>Ryan Vogelsong</full>
            <first>Ryan</first>
            <last>Vogelsong</last>
            <ascii_first>Ryan</ascii_first>
            <ascii_last>Vogelsong</ascii_last>
          </name>
          <editorial_player_key>mlb.p.6571</editorial_player_key>
          <editorial_team_key>mlb.t.26</editorial_team_key>
          <editorial_team_full_name>San Francisco Giants</editorial_team_full_name>
          <editorial_team_abbr>SF</editorial_team_abbr>
          <uniform_number>32</uniform_number>
          <display_position>SP,RP</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110706/6571.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=bdeeFeFntdasbz_0xzXCGA--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>P</position_type>
          <eligible_positions>
            <position>SP</position>
            <position>RP</position>
            <position>P</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>BN</position>
          </selected_position>
        </player>
        <player>
          <player_key>253.p.7382</player_key>
          <player_id>7382</player_id>
          <name>
            <full>David Wright</full>
            <first>David</first>
            <last>Wright</last>
            <ascii_first>David</ascii_first>
            <ascii_last>Wright</ascii_last>
          </name>
          <status>DL</status>
          <on_disabled_list>1</on_disabled_list>
          <editorial_player_key>mlb.p.7382</editorial_player_key>
          <editorial_team_key>mlb.t.21</editorial_team_key>
          <editorial_team_full_name>New York Mets</editorial_team_full_name>
          <editorial_team_abbr>NYM</editorial_team_abbr>
          <uniform_number>5</uniform_number>
          <display_position>3B</display_position>
          <image_url>http://l.yimg.com/a/i/us/sp/v/mlb/players_l/20110503x/7382.jpg?x=46&amp;y=60&amp;xc=1&amp;yc=1&amp;wc=164&amp;hc=215&amp;q=100&amp;sig=QNOFMSgR6NuPxUwDMUSM1w--</image_url>
          <is_undroppable>0</is_undroppable>
          <position_type>B</position_type>
          <eligible_positions>
            <position>3B</position>
            <position>Util</position>
            <position>DL</position>
          </eligible_positions>
          <has_player_notes>1</has_player_notes>
          <has_recent_player_notes>1</has_recent_player_notes>
          <selected_position>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <position>DL</position>
          </selected_position>
          <starting_status>
            <coverage_type>date</coverage_type>
            <date>2011-07-22</date>
            <is_starting>1</is_starting>
          </starting_status>
        </player>
      </players>
    </roster>
  </team>
</fantasy_content>
*/