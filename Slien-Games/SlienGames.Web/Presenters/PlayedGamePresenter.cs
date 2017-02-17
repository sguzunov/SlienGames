using SlienGames.Data.Services.Contracts;
using SlienGames.Web.CustomEventArgs;
using SlienGames.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SlienGames.Web.Presenters
{
    public class PlayedGamePresenter : Presenter<IPlayedGameView>
    {
        private readonly IGamesService gameService;
        private readonly IUsersService usersService;
        public PlayedGamePresenter(IPlayedGameView view, IGamesService gameService, IUsersService usersService) : base(view)
        {
            this.gameService = gameService;
            this.usersService = usersService;
            this.View.GetGame += View_GetGame;
            this.View.GetUser += View_GetUser;
        }

        private void View_GetGame(object sender, IdEventArgs e)
        {
            this.View.Model.EmbeddedGame = gameService.GetById(e.Id);
        }

        private void View_GetUser(object sender, IdEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
        
    }
}