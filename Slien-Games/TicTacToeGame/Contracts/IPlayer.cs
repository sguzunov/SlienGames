namespace TicTacToeGame.Contracts
{
    public interface IPlayer
    {
        string ConnectionId { get; }

        string Name { get; }

        IPlayer Opponent { get; set; }

        bool LookingForOpponent { get; set; }

        bool IsPlayingNow { get; set; }

        bool IsOnTurn { get; set; }
    }
}
