using System;

using TicTacToeGame.Contracts;

namespace TicTacToeGame
{
    public class Player : IPlayer
    {
        private readonly string connectionId;
        private readonly string name;

        public Player(string connectionId, string name)
        {
            if (connectionId == null)
            {
                throw new ArgumentNullException($"Players should be created with {connectionId}!");
            }

            this.connectionId = connectionId;
            this.name = name == null ? "Default(No name)" : name;
        }

        public string ConnectionId => this.name;

        public bool IsPlayingNow { get; set; }

        public bool LookingForOpponent { get; set; }

        public string Name => this.name;

        public IPlayer Opponent { get; set; }
    }
}
