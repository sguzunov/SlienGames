using TicTacToeGame.Contracts;

namespace TicTacToeGame.Factories
{
    public interface IPlayerFactory
    {
        IPlayer Create(string connectionId, string name);
    }
}
