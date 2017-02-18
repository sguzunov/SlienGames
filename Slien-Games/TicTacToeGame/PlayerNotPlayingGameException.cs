using System;

namespace TicTacToeGame
{
    public class PlayerNotPlayingGameException : Exception
    {
        public PlayerNotPlayingGameException(string message) : base(message)
        {
        }
    }
}
