using SlienGames.Data.Services.Contracts;
using System;
using WebFormsMvp;

namespace SlienGames.MVP.Games
{
    public class AllGamesPresenter : Presenter<IAllGamesView>
    {
        private IGamesService gameService;
        public AllGamesPresenter(IAllGamesView view, IGamesService gameService) : base(view)
        {
            this.gameService = gameService;
            this.View.GetGames += View_GetGames;
        }

        private void View_GetGames(object sender, EventArgs e)
        {
            this.View.Model.EmbeddedGames = this.gameService.GetAll();
        }
    }
}