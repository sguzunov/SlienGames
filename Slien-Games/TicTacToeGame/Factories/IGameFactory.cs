using TicTacToeGame.Contracts;

namespace TicTacToeGame.Factories
{
    public interface IGameFactory
    {
        IMultiplayerGame Create(IPlayer firstPlayer, IPlayer secondPlayer);
    }
}
