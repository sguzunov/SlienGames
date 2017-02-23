using System;

using WebFormsMvp;

using SlienGames.Data.Services.Contracts;

namespace SlienGames.MVP.Games
{
    public class AllGamesPresenter : Presenter<IAllGamesView>
    {
        private readonly IGamesService gameService;

        public AllGamesPresenter(IAllGamesView view, IGamesService gameService) : base(view)
        {
            if (gameService==null)
            {
                throw new ArgumentNullException(nameof(gameService));
            }

            this.gameService = gameService;
            this.View.GetGames += View_GetGames;
        }

        private void View_GetGames(object sender, EventArgs e)
        {
            this.View.Model.Games = this.gameService.GetAllGames();
        }
    }
}