using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;
using TicTacToeGame.Contracts;

namespace TicTacToeGame.Tests.TicTacToeTests
{
    [TestFixture]
    public class PlayTurnShould
    {
        [Test]
        public void ThrowsPlayerNotPlayingGameException_WhenPassedPlayerIsNotPlayingThisGame()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var fakePlayingPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            Assert.Throws<PlayerNotPlayingGameException>(() => game.PlayTurn(fakePlayingPlayer.Object, 1));
        }

        [Test]
        public void NotThrowPlayerNotPlayingGameException_WhenPlayerWhoPlaysIsInTheGame()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            Assert.DoesNotThrow(() => game.PlayTurn(fakeFirstPlayer.Object, 1));
        }

        [Test]
        public void ThrowsArgumentOutOfRangeExceptionn_WhenPalyedPostionIsLessThanZero()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => game.PlayTurn(fakeFirstPlayer.Object, -1));
        }

        [Test]
        public void ThrowsArgumentOutOfRangeException_WhenPalyedPostionIsGreaterThanBoardSize()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => game.PlayTurn(fakeFirstPlayer.Object, 10));
        }

        [Test]
        public void ReturnTrue_WhenFirstTurnIsPlayed()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            Assert.IsTrue(game.PlayTurn(fakeFirstPlayer.Object, 1));
        }

        [Test]
        public void ReturnFalse_WhenAPostionIsAlreadyMarked()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            game.PlayTurn(fakeFirstPlayer.Object, 1);
            Assert.IsFalse(game.PlayTurn(fakeFirstPlayer.Object, 1));
        }

        [Test]
        public void NotChangeGameState_WhenFirstTurnIsPlayed()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            game.PlayTurn(fakeFirstPlayer.Object, 1);

            Assert.IsFalse(game.IsOver);
            Assert.IsFalse(game.IsDraw);
        }

        [Test]
        public void ChangeStateToGameOver_WhenAPlayerMarksAllCellsInFirstRow()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            game.PlayTurn(fakeFirstPlayer.Object, 0);
            game.PlayTurn(fakeFirstPlayer.Object, 1);
            game.PlayTurn(fakeFirstPlayer.Object, 2);

            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void ChangeStateToGameOver_WhenAPlayerMarksAllCellsInSecondRow()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            game.PlayTurn(fakeFirstPlayer.Object, 3);
            game.PlayTurn(fakeFirstPlayer.Object, 4);
            game.PlayTurn(fakeFirstPlayer.Object, 5);

            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void ChangeStateToGameOver_WhenAPlayerMarksAllCellsInThirdRow()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            game.PlayTurn(fakeFirstPlayer.Object, 6);
            game.PlayTurn(fakeFirstPlayer.Object, 7);
            game.PlayTurn(fakeFirstPlayer.Object, 8);

            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void ChangeStateToGameOver_WhenAPlayerMarksAllCellsInFirstColumn()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            game.PlayTurn(fakeFirstPlayer.Object, 0);
            game.PlayTurn(fakeFirstPlayer.Object, 3);
            game.PlayTurn(fakeFirstPlayer.Object, 6);

            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void ChangeStateToGameOver_WhenAPlayerMarksAllCellsInSecondColumn()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            game.PlayTurn(fakeFirstPlayer.Object, 1);
            game.PlayTurn(fakeFirstPlayer.Object, 4);
            game.PlayTurn(fakeFirstPlayer.Object, 7);

            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void ChangeStateToGameOver_WhenAPlayerMarksAllCellsInThirdColumn()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            game.PlayTurn(fakeFirstPlayer.Object, 2);
            game.PlayTurn(fakeFirstPlayer.Object, 5);
            game.PlayTurn(fakeFirstPlayer.Object, 8);

            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void ChangeStateToGameOver_WhenAPlayerMarksAllCellsInLeftDiagonal()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            // Mark left diagonal in matrix 3x3
            game.PlayTurn(fakeFirstPlayer.Object, 0);
            game.PlayTurn(fakeFirstPlayer.Object, 4);
            game.PlayTurn(fakeFirstPlayer.Object, 8);

            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void ChangeStateToGameOver_WhenAPlayerMarksAllCellsInRightDiagonal()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            // Mark right diagonal in matrix 3x3
            game.PlayTurn(fakeFirstPlayer.Object, 2);
            game.PlayTurn(fakeFirstPlayer.Object, 4);
            game.PlayTurn(fakeFirstPlayer.Object, 6);

            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void NotChangeStateToGameOver_WhenARowIsMarkedWithDifferentMarks()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            // Mark right diagonal in matrix 3x3
            game.PlayTurn(fakeFirstPlayer.Object, 0);
            game.PlayTurn(fakeSecondPlayer.Object, 1);
            game.PlayTurn(fakeFirstPlayer.Object, 2);

            Assert.IsFalse(game.IsOver);
        }

        [Test]
        public void NotChangeStateToGameOver_WhenAColumnIsMarkedWithDifferentMarks()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            // Mark right diagonal in matrix 3x3
            game.PlayTurn(fakeFirstPlayer.Object, 0);
            game.PlayTurn(fakeSecondPlayer.Object, 3);
            game.PlayTurn(fakeFirstPlayer.Object, 6);

            Assert.IsFalse(game.IsOver);
        }

        [Test]
        public void NotChangeStateToGameOver_WhenALeftDiagonalIsMarkedWithDifferentMarks()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            // Mark right diagonal in matrix 3x3
            game.PlayTurn(fakeFirstPlayer.Object, 0);
            game.PlayTurn(fakeSecondPlayer.Object, 4);
            game.PlayTurn(fakeFirstPlayer.Object, 8);

            Assert.IsFalse(game.IsOver);
        }

        [Test]
        public void NotChangeStateToGameOver_WhenARightDiagonalIsMarkedWithDifferentMarks()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();
            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            // Mark right diagonal in matrix 3x3
            game.PlayTurn(fakeFirstPlayer.Object, 2);
            game.PlayTurn(fakeSecondPlayer.Object, 4);
            game.PlayTurn(fakeFirstPlayer.Object, 6);

            Assert.IsFalse(game.IsOver);
        }
    }
}
