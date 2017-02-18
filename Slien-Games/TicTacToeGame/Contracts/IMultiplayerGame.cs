namespace TicTacToeGame.Contracts
{
    public interface IMultiplayerGame : IGame
    {
        IPlayer FirstPlayer { get; }

        IPlayer SecondtPlayer { get; }
    }
}
