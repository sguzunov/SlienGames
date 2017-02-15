using TicTacToeGame.Contracts;

namespace TicTacToeGame
{
    public interface IMultiplayerGame
    {
        IPlayer FirstPlayer { get; }

        IPlayer SecondtPlayer { get; }
    }
}
