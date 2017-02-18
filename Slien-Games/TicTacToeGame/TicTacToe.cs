using System;

using TicTacToeGame.Contracts;

namespace TicTacToeGame
{
    public class TicTacToe : IMultiplayerGame, IGame
    {
        private const int BoardSize = 3;
        private const char FirstPlayerMarker = 'x';
        private const char SecondPlayerMarker = 'o';

        private readonly IPlayer firstPlayer;
        private readonly IPlayer secondPlayer;
        private readonly char[,] board;

        private int markersLeft;

        public TicTacToe(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;

            // Setting games's initial state.
            this.board = new char[BoardSize, BoardSize];
            this.IsDraw = false;
            this.IsOver = false;
            this.markersLeft = BoardSize * BoardSize;
        }

        public IPlayer FirstPlayer => this.firstPlayer;

        public IPlayer SecondtPlayer => this.secondPlayer;

        public bool IsDraw { get; private set; }

        public bool IsOver { get; private set; }

        public bool PlayTurn(IPlayer player, int position)
        {
            if (!(player == this.FirstPlayer || player == this.SecondtPlayer))
            {
                throw new PlayerNotPlayingGameException("Cannot play with player not in the game!");
            }

            if (this.IsOver) return false;

            char playerMarker;
            if (player == this.FirstPlayer)
            {
                playerMarker = FirstPlayerMarker;
            }
            else
            {
                playerMarker = SecondPlayerMarker;
            }

            // We cannot place at this position.
            if (!this.PlaceMarker(playerMarker, position))
            {
                return false;
            }

            if (CheckIfPlayerWins(playerMarker))
            {
                this.IsOver = true;
            }
            else
            {
                if (this.markersLeft == 0)
                {
                    this.IsOver = true;
                    this.IsDraw = true;
                }
            }

            return true;
        }

        private bool CheckIfPlayerWins(char playerMarker)
        {
            for (int i = 0; i < 3; i++)
            {
                bool winsByRow = playerMarker == this.board[i, 0] && playerMarker == this.board[i, 1] && playerMarker == this.board[i, 2];
                bool winsByCol = playerMarker == this.board[0, i] && playerMarker == this.board[1, i] && playerMarker == this.board[2, i];
                if (winsByRow || winsByCol)
                {
                    return true;
                }
            }

            bool winsByLeftDiagonal = playerMarker == this.board[0, 0] && playerMarker == this.board[1, 1] && playerMarker == this.board[2, 2];
            bool winsByRightDiagonal = playerMarker == this.board[0, 2] && playerMarker == this.board[1, 1] && playerMarker == this.board[2, 0];

            return winsByLeftDiagonal || winsByRightDiagonal;
        }

        private bool PlaceMarker(char playerMarker, int position)
        {
            if (position < 0 || BoardSize * BoardSize <= position)
            {
                throw new ArgumentOutOfRangeException($"{position} is out of the board!");
            }

            int positionX = position / BoardSize;
            int positionY = position % BoardSize;

            // If already used position is choosen.
            if (this.board[positionX, positionY] != '\0')
            {
                return false;
            }

            this.board[positionX, positionY] = playerMarker;
            return true;
        }
    }
}
