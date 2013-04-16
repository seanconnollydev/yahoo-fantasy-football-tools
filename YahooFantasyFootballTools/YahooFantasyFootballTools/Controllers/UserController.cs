using System.   Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Fantasizer;
using MvcSiteMapProvider;
using Fantasizer.Domain;
using YahooFantasyFootballTools.Models;
using System;

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
            }

            var games = this.Fantasizer.GetGames();
            var gameList = new List<SelectListItem>();

            foreach (var game in games)
            {
                var listItem = new SelectListItem();
                listItem.Text = string.Format("{0} - {1}", game.GameCode, game.Season);
                listItem.Value = game.Id.ToString();
                listItem.Selected = gameId.HasValue ? (game.Id == gameId.Value) : (game.GameCode == DEFAULT_GAME_CODE);
                gameList.Add(listItem);
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
