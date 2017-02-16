using System.Collections.Generic;

using TicTacToeGame.Contracts;

namespace SlienGames.Web.GamesHubs.States
{
    public class TicTacToeHubState : ITicTacToeHubState
    {
        private readonly ICollection<IPlayer> clients;
        private readonly ICollection<IGame> games;

        public TicTacToeHubState()
        {
            this.clients = new List<IPlayer>();
            this.games = new List<IGame>();
        }

        public ICollection<IPlayer> Clients
        {
            get
            {
                return this.clients;
            }
        }

        public ICollection<IGame> Games
        {
            get
            {
                return this.games;
            }
        }
    }
}