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
    public class ConstructorShould
    {
        [Test]
        public void SetFirstPlayer()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();

            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            Assert.AreEqual(game.FirstPlayer, fakeFirstPlayer.Object);
        }

        [Test]
        public void SetSecondPlayer()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();

            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            Assert.AreEqual(game.SecondtPlayer, fakeSecondPlayer.Object);
        }

        [Test]
        public void CreateGameWhichIsNotDraw()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();

            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            Assert.IsFalse(game.IsDraw);
        }

        [Test]
        public void CreateGameWhichIsNotOver()
        {
            var fakeFirstPlayer = new Mock<IPlayer>();
            var fakeSecondPlayer = new Mock<IPlayer>();

            var game = new TicTacToe(fakeFirstPlayer.Object, fakeSecondPlayer.Object);

            Assert.IsFalse(game.IsOver);
        }
    }
}
