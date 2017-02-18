using System;

using TicTacToeGame.Contracts;

namespace TicTacToeGame
{
    public class Player : IPlayer
    {
        private const string DefaultPlayerName = "Default(No name)";
        private readonly string connectionId;
        private readonly string name;

        public Player(string connectionId, string name)
        {
            if (connectionId == null)
            {
                throw new ArgumentNullException($"Players cannot be created with null value for {connectionId}!");
            }

            if (connectionId == string.Empty)
            {
                throw new ArgumentException($"Players cannot be created with empty string value for {connectionId}!");
            }

            this.connectionId = connectionId;
            this.name = name == null ? DefaultPlayerName : name;
        }

        public string ConnectionId => this.connectionId;

        public bool IsPlayingNow { get; set; }

        public string Name => this.name;

        public IPlayer Opponent { get; set; }

        public bool IsOnTurn { get; set; }
    }
}
