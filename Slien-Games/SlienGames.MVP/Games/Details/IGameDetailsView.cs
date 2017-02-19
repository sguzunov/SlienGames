using System;

using WebFormsMvp;

namespace SlienGames.MVP.Games.Details
{
    public interface IGameInfoView : IView<GameDetailsViewModel>
    {
        event EventHandler<GetGameDetailsEventArgs> GetGameDetails;
    }
}