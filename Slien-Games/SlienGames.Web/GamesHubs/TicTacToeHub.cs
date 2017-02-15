using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using TicTacToeGame;
using TicTacToeGame.Contracts;

namespace SlienGames.Web.GamesHubs
{
    public class TicTacToeHub : Hub
    {
        private readonly static ICollection<IPlayer> clients = new List<IPlayer>();

        private object syncRoot = new object();

        public void RegisterPlayer(string playerName)
        {
            var connectionId = this.Context.ConnectionId;

            lock (syncRoot)
            {
                var player = new Player(connectionId, playerName);
                clients.Add(player);
            }
        }

        public void FindOpponent()
        {
            string playerConnectionId = this.Context.ConnectionId;
            var player = clients.First(x => x.ConnectionId == playerConnectionId);

            var opponent = clients.FirstOrDefault(x => x.ConnectionId != playerConnectionId && !x.IsPlayingNow);

            if (opponent == null)
            {
                this.Clients.Client(playerConnectionId).noOpponentFound();
                return;
            }

            player.IsPlayingNow = true;
            opponent.IsPlayingNow = true;

            this.Clients.Client(playerConnectionId).playGame(opponent.Name);
            this.Clients.Client(opponent.ConnectionId).playGame(player.Name);
        }

        private void CreateGame
    }
}