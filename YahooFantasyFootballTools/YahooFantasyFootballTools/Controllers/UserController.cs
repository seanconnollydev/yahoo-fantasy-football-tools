using System.   Collections.Generic;
using System.Web.Mvc;
using Fantasizer;
using MvcSiteMapProvider;
using Fantasizer.Domain;
using YahooFantasyFootballTools.Models;
using System.Linq;

namespace YahooFantasyFootballTools.Controllers
{
    public class UserController : BaseAuthenticatedController
    {
        private const GameCode DEFAULT_GAME_CODE = GameCode.nfl;
        public UserController(IUserTokenStore userTokenStore, IFantasizerService fantasizer) : base(userTokenStore, fantasizer)
        {
        }

        [MvcSiteMapNode(Key="User", Title="Leagues", ParentKey="Home")]
        public ActionResult ListLeagues(int? gameId)
        {
            LeagueCollection leagues;
            if (gameId.HasValue)
            {
                leagues = this.Fantasizer.GetLeagues(gameId.Value);
            }
            else
            {
                leagues = this.Fantasizer.GetLeagues(DEFAULT_GAME_CODE);
                if (leagues.Count == 0)
                {
                    return RedirectToAction(
                        "ListLeagues",
                        new { gameId = this.Fantasizer.GetGames().OrderByDescending(g => g.Season).Skip<Game>(1).First<Game>().Id });
                }
            }

            var games = this.Fantasizer.GetGames().OrderByDescending(g => g.Season);
            var gameList = new List<SelectListItem>();

            bool firstGameInList = true;
            foreach (var game in games)
            {
                var listItem = new SelectListItem();
                listItem.Text = string.Format("{0} - {1}", game.GameCode, game.Season);
                listItem.Value = game.Id.ToString();
                listItem.Selected = gameId.HasValue ? (game.Id == gameId.Value) : firstGameInList;
                
                gameList.Add(listItem);
                firstGameInList = false;
            }

            var model = new LeaguesViewModel()
            {
                Leagues = leagues,
                Games = gameList
            };

            return View(model);
        }
    }
}
