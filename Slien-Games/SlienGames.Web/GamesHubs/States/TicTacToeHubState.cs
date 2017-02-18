using System.Collections.Generic;

using TicTacToeGame.Contracts;

namespace SlienGames.Web.GamesHubs.States
{
    public class TicTacToeHubState : ITicTacToeHubState
    {
        private readonly ICollection<IPlayer> clients;
        private readonly ICollection<IMultiplayerGame> games;

        public TicTacToeHubState()
        {
            this.clients = new List<IPlayer>();
            this.games = new List<IMultiplayerGame>();
        }

        public ICollection<IPlayer> Clients => this.clients;

        public ICollection<IMultiplayerGame> Games => this.games;
    }
}