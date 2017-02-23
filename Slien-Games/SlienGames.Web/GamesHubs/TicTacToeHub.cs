using System.Linq;
using System.Threading.Tasks;

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
        private readonly object syncRootPlayer = new object();
        private readonly object syncRootGame = new object();

        public TicTacToeHub(ITicTacToeHubState state, IPlayerFactory playerFactory, IGameFactory gameFactory)
        {
            this.state = state;
            this.playerFactory = playerFactory;
            this.gameFactory = gameFactory;
        }

        public void RegisterPlayer(string playerName)
        {
            var connectionId = this.Context.ConnectionId;

            lock (syncRootPlayer)
            {
                var player = this.playerFactory.Create(connectionId, playerName);
                this.state.Clients.Add(player);
            }
        }

        public void FindOpponent()
        {
            string playerConnectionId = this.Context.ConnectionId;
            IPlayer player;
            lock (syncRootGame)
            {
                player = this.state.Clients.First(x => x.ConnectionId == playerConnectionId);
            }

            var opponent = this.state.Clients.FirstOrDefault(x => x.ConnectionId != playerConnectionId && !x.IsPlayingNow);
            if (opponent == null)
            {
                this.Clients.Client(playerConnectionId).noOpponentFound();
                return;
            }

            this.Clients.Client(playerConnectionId).playGame(opponent.Name);
            this.Clients.Client(opponent.ConnectionId).playGame(player.Name);
            this.InitGame(player, opponent);
        }

        public void PlayTurn(int markerPosition)
        {
            string playerConnectionId = this.Context.ConnectionId;
            IPlayer player;
            lock (syncRootPlayer)
            {
                player = this.state.Clients.First(x => x.ConnectionId == playerConnectionId);
            }

            if (!player.IsOnTurn)
            {
                this.Clients.Client(playerConnectionId).waitTurn();
                return;
            }

            var game = this.GetGameBy(playerConnectionId);
            bool isPlayed = game.PlayTurn(player, markerPosition);

            // Cannot set a this position.
            if (!isPlayed) return;

            var opponent = game.FirstPlayer == player ? game.SecondtPlayer : game.FirstPlayer;
            player.IsOnTurn = false;
            opponent.IsOnTurn = true;

            this.Clients.Client(playerConnectionId).addMarker(markerPosition, player.Name);
            this.Clients.Client(opponent.ConnectionId).addMarker(markerPosition, player.Name);

            if (game.IsOver)
            {
                this.FinishGame(game);
                if (game.IsDraw)
                {
                    this.Clients.Client(playerConnectionId).endGame("Draw!");
                    this.Clients.Client(opponent.ConnectionId).endGame("Draw!");
                }
                else // Player wins by this turn
                {
                    this.Clients.Client(playerConnectionId).endGame("You won!");
                    this.Clients.Client(opponent.ConnectionId).endGame("You lost!");
                }
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string playerConnectionId = this.Context.ConnectionId;
            var game = this.GetGameBy(playerConnectionId);
            var opponent = game.FirstPlayer.ConnectionId == playerConnectionId ? game.SecondtPlayer : game.FirstPlayer;

            this.FinishGame(game);
            this.Clients.Client(opponent.ConnectionId).endGame("You opponent left the game!");

            return base.OnDisconnected(stopCalled);
        }

        private void FinishGame(IMultiplayerGame game)
        {
            lock (syncRootGame)
            {
                this.state.Clients.Remove(game.FirstPlayer);
                this.state.Clients.Remove(game.SecondtPlayer);
                this.state.Games.Remove(game);
            }
        }

        private IMultiplayerGame GetGameBy(string playerConnectionId)
        {
            IMultiplayerGame game;
            lock (syncRootGame)
            {
                game = this.state.Games.First(x => x.FirstPlayer.ConnectionId == playerConnectionId || x.SecondtPlayer.ConnectionId == playerConnectionId);

            }
            return game;
        }

        private void InitGame(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            firstPlayer.IsOnTurn = true;
            firstPlayer.IsPlayingNow = true;
            secondPlayer.IsPlayingNow = true;

            firstPlayer.Opponent = secondPlayer;
            secondPlayer.Opponent = firstPlayer;

            lock (syncRootGame)
            {
                var game = this.gameFactory.Create(firstPlayer, secondPlayer);
                this.state.Games.Add(game);
            }
        }
    }
}