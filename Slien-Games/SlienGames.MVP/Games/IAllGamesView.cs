using System;
using WebFormsMvp;

namespace SlienGames.MVP.Games
{
    public interface IAllGamesView : IView<AllGamesModel>
    {
        event EventHandler GetGames;
    }
}
