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
        private readonly IGamesService gameProfileServices;

        public GameDetailsPresenter(IGameInfoView view, IGamesService gameProfileServices, ISlienGamesData uow) : base(view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(string.Format(DependencyIsNullErrorMessage, nameof(view), this.GetType().Name));
            }

            if (gameProfileServices == null)
            {
                throw new ArgumentNullException(string.Format(DependencyIsNullErrorMessage, nameof(gameProfileServices), this.GetType().Name));
            }

            this.view = view;
            this.gameProfileServices = gameProfileServices;

            this.view.GetGameDetails += View_GetGameDetails;
        }

        private void View_GetGameDetails(object sender, GetGameDetailsEventArgs e)
        {
            var gameDetails = this.gameProfileServices.GetDetailsByName(e.GameName);

            if (gameDetails == null)
            {
                throw new ArgumentNullException($"Game with name {e.GameName} is not found!");
            }

            this.view.Model.GameName = gameDetails.Name;
            this.view.Model.GameDescription = gameDetails.Description;
            this.view.Model.Comments = gameDetails.Comments;
        }
    }
}