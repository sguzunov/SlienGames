using TicTacToeGame.Contracts;

namespace TicTacToeGame.Factories
{
    public interface IGameFactory
    {
        IGame Create(IPlayer firstPlayer, IPlayer secondPlayer);
    }
}
