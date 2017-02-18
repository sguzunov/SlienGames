using System;
using WebFormsMvp;

namespace SlienGames.MVP.PlayedGame.CurrentGame
{
    public interface ICurrentGameView : IView<CurrentGameModel>
    {
        event EventHandler<CurrentGameEventArgs> GetGame;

        event EventHandler<CurrentGameEventArgs> GetUser;
    }
}
