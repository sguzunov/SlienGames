namespace TicTacToeGame.Contracts
{
    public interface IGame
    {
        bool PlayTurn(IPlayer player, int position);

        bool IsDraw { get; }

        bool IsOver { get; }
    }
}
