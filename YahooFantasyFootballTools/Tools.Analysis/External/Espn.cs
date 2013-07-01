using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Analysis.Domain;
using HtmlAgilityPack;

namespace Tools.Analysis.External
{
    public class Espn : IExternalDraftResultSource
    {
        public PreDraftRankingList Get2012PprPreDraftRankings()
        {
            var web = new HtmlWeb();
            var html = web.Load("http://sports.espn.go.com/fantasy/football/ffl/story?page=NFLDK2K12ranksPPR");
            var table = html.DocumentNode.SelectSingleNode("//table");

            var rows = table.SelectNodes("//tr");

            var preDraftRankings = new PreDraftRankingList();

            foreach (var row in rows)
            {
                var cells = row.SelectNodes("td");

                if (cells != null)
                {
                    string playerName = cells[1].InnerText.Trim('\t');
                    int rank = int.Parse(cells[0].InnerText.Trim('\t'));
                    int byeWeek = int.Parse(cells[2].InnerText.Trim('\t'));

                    double auctionValue;
                    if (!double.TryParse(cells[4].InnerText.Trim('\t', ' ', '$'), out auctionValue))
                    {
                        auctionValue = 0;
                    }

                    preDraftRankings.Add(new PreDraftRanking(playerName, rank, auctionValue, byeWeek));
                }
            }

            return preDraftRankings;
        }
    }
}
