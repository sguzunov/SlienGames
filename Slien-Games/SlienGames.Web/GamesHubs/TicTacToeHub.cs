using System.Linq;
using Microsoft.AspNet.SignalR;

using SlienGames.Web.GamesHubs.States;
using TicTacToeGame.Contracts;
using TicTacToeGame.Factories;

namespace SlienGames.Web.GamesHubs
{
    public class TicTacToeHub : Hub
    {
        private readonly IPlayerFactory playerFactory;
        private readonly IGameFactory gameFactory;
        private readonly ITicTacToeHubState state;
        private readonly object syncRoot = new object();

        public TicTacToeHub(ITicTacToeHubState state, IPlayerFactory playerFactory, IGameFactory gameFactory)
        {
            this.state = state;
            this.playerFactory = playerFactory;
            this.gameFactory = gameFactory;
        }

        public void RegisterPlayer(string playerName)
        {
            var connectionId = this.Context.ConnectionId;

            lock (syncRoot)
            {
                var player = this.playerFactory.Create(connectionId, playerName);
                this.state.Clients.Add(player);
            }
        }

        public void FindOpponent()
        {
            string playerConnectionId = this.Context.ConnectionId;
            var player = this.state.Clients.First(x => x.ConnectionId == playerConnectionId);

            var opponent = this.state.Clients.FirstOrDefault(x => x.ConnectionId != playerConnectionId && !x.IsPlayingNow);
            if (opponent == null)
            {
                this.Clients.Client(playerConnectionId).noOpponentFound();
                return;
            }

            this.InitGame(player, opponent);

            this.Clients.Client(playerConnectionId).playGame(opponent.Name);
            this.Clients.Client(opponent.ConnectionId).playGame(player.Name);
        }

        private void InitGame(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            firstPlayer.IsPlayingNow = true;
            secondPlayer.IsPlayingNow = true;

            firstPlayer.Opponent = secondPlayer;
            secondPlayer.Opponent = firstPlayer;

            var game = this.gameFactory.Create(firstPlayer, secondPlayer);
            this.state.Games.Add(game);
        }
    }
}