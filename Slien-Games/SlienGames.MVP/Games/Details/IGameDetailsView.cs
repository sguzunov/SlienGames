using System;

using WebFormsMvp;

namespace SlienGames.MVP.Games.Details
{
    public interface IGameInfoView : IView<GameDetailsViewModel>
    {
        event EventHandler<GetDetailsEventArgs> GetGameDetails;

        event EventHandler<LikeGameEventArgs> LikeGame;

        event EventHandler<NewCommentEventArgs> AddComment;
    }
}