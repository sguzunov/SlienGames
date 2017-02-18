using System;
using WebFormsMvp;

namespace SlienGames.MVP.PlayedGame.TicTacToe
{
    public interface ITicTacToeView : IView<TicTacToeModel>
    {
        event EventHandler<TicTacToeEventArgs> GetCurrentUser;

    }
}
