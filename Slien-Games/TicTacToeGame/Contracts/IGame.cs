namespace TicTacToeGame.Contracts
{
    public interface IGame : IMultiplayerGame
    {
        bool PlayTurn(IPlayer player, int positionX, int positionY);

        bool IsDraw { get; }

        bool IsOver { get; }
    }
}
