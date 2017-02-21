using System;

using SlienGames.Data.Contracts;
using SlienGames.Data.Services.Contracts;

using WebFormsMvp;

namespace SlienGames.MVP.Games.Details
{
    public class GameDetailsPresenter : Presenter<IGameInfoView>
    {
        private const string DependencyIsNullErrorMessage = "{0} is null in {1}!";

        private readonly IGameInfoView view;
        private readonly IGamesService gameService;

        public GameDetailsPresenter(IGameInfoView view, IGamesService gameProfileServices) : base(view)
        {
            if (gameProfileServices == null)
            {
                throw new ArgumentNullException(string.Format(DependencyIsNullErrorMessage, nameof(gameProfileServices), this.GetType().Name));
            }

            this.view = view;
            this.gameService = gameProfileServices;

            this.view.GetGameDetails += View_GetGameDetails;
            this.view.RateGame += View_RateGame;
        }

        private void View_RateGame(object sender, RateGameEventArgs e)
        {
            this.gameService.RateGame(e.GameId, e.UserId, e.Rating);
        }

        private void View_GetGameDetails(object sender, GetDetailsEventArgs e)
        {
            var gameDetails = this.gameService.GetDetailsWithComments(e.GameName);

            if (gameDetails == null)
            {
                throw new ArgumentNullException($"Game with name {e.GameName} is not found!");
            }

            this.view.Model.GameId = gameDetails.Id;
            this.view.Model.GameName = gameDetails.Name;
            this.view.Model.GameDescription = gameDetails.Description;
            this.view.Model.CoverImageFileSystemPath = gameDetails.CoverImage.FileSystemUrlPath;
            this.view.Model.Comments = gameDetails.Comments;
        }
    }
}