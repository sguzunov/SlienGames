using NUnit.Framework;

namespace TicTacToeGame.Tests.PlayerTests
{
    [TestFixture]
    public class WhenCreatedShould
    {
        [Test]
        public void NotPlayingNow()
        {
            string playerName = "John";
            string connectionId = "connectionId";
            var player = new Player(connectionId, playerName);

            bool isPlaying = player.IsPlayingNow;

            Assert.IsFalse(isPlaying);
        }

        [Test]
        public void NotBeOnTurn()
        {
            string playerName = "John";
            string connectionId = "connectionId";
            var player = new Player(connectionId, playerName);

            bool isOnTurn = player.IsPlayingNow;

            Assert.IsFalse(isOnTurn);
        }

        [Test]
        public void NotHaveOpponentYet()
        {
            string playerName = "John";
            string connectionId = "connectionId";
            var player = new Player(connectionId, playerName);

            Assert.IsNull(player.Opponent);
        }
    }
}
