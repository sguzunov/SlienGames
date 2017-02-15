using System;

using TicTacToeGame.Contracts;

namespace TicTacToeGame
{
    public class TicTacToe : IGame, IMultiplayerGame
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

            this.board = new char[BoardSize, BoardSize];
            this.IsDraw = false;
            this.IsOver = false;
            this.HasWinner = false;
            this.markersLeft = BoardSize * BoardSize;
        }

        public IPlayer FirstPlayer => this.firstPlayer;

        public IPlayer SecondtPlayer => this.secondPlayer;

        public bool IsDraw { get; private set; }

        public bool IsOver { get; private set; }

        public bool HasWinner { get; private set; }

        public bool PlayTurn(IPlayer player, int positionX, int positionY)
        {
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

            // We cannot place at that position.
            if (!this.PlaceMarker(playerMarker, positionX, positionY))
            {
                return false;
            }

            if (CheckIfPlayerWins(playerMarker))
            {
                this.HasWinner = true;
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

        private bool PlaceMarker(char playerMarker, int positionX, int positionY)
        {
            if (positionX < 0 || BoardSize <= positionX)
            {
                throw new ArgumentException($"{positionX} is invalid position for x!");
            }

            if (positionY < 0 || BoardSize <= positionY)
            {
                throw new ArgumentException($"{positionY} is invalid position for y!");
            }

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
