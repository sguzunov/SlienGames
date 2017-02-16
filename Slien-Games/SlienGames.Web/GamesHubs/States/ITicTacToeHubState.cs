using System.Collections.Generic;

using TicTacToeGame.Contracts;

namespace SlienGames.Web.GamesHubs.States
{
    public interface ITicTacToeHubState
    {
        ICollection<IPlayer> Clients { get; }

        ICollection<IGame> Games { get; }
    }
}