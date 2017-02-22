using System;

using SlienGames.Data.Services.Contracts;

using WebFormsMvp;

namespace SlienGames.MVP.Games.Details
{
    public class GameDetailsPresenter : Presenter<IGameInfoView>
    {
        private readonly IGameInfoView view;
        private readonly IGamesService gameService;
        private readonly IUsersService userService;
        private readonly ICommentsService commentsService;

        public GameDetailsPresenter(
            IGameInfoView view,
            IGamesService gameProfileServices,
            IUsersService userService,
            ICommentsService commentsService) : base(view)
        {
            this.view = view;
            this.gameService = gameProfileServices;
            this.userService = userService;
            this.commentsService = commentsService;

            this.view.GetGameDetails += View_GetGameDetails;
            this.view.LikeGame += View_LikeGame;
            this.view.AddComment += View_AddComment;
        }

        private void View_AddComment(object sender, NewCommentEventArgs e)
        {
            this.commentsService.AddCommentToGame(e.GameId, e.AuthorUsername, e.CommentContent);
            this.view.Model.Comments = this.commentsService.GetGameComments(e.GameId);
        }

        private void View_LikeGame(object sender, LikeGameEventArgs e)
        {
            bool isLiked = this.gameService.LikeGame(e.GameId, e.Username);
            if (isLiked)
            {
                this.view.Model.IsFavourite = true;
            }
        }

        private void View_GetGameDetails(object sender, GetDetailsEventArgs e)
        {
            var gameDetails = this.gameService.GetDetailsWithComments(e.GameName);

            if (gameDetails == null)
            {
                throw new ArgumentNullException($"Game with name {e.GameName} is not found!");
            }

            if (e.Username != null) // has logged in user
            {
                bool userLikesTheGame = this.userService.CheckIfLikesAGame(e.Username, gameDetails.Id);

                // If the user has already liked the game.
                this.view.Model.IsFavourite = userLikesTheGame ? true : false;
            }

            this.view.Model.GameId = gameDetails.Id;
            this.view.Model.GameName = gameDetails.Name;
            this.view.Model.GameDescription = gameDetails.Description;
            this.view.Model.CoverImageFileSystemPath = gameDetails.CoverImage.FileSystemUrlPath;
            this.view.Model.Comments = gameDetails.Comments;
        }
    }
}