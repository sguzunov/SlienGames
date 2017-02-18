using System;

using NUnit.Framework;

namespace TicTacToeGame.Tests.PlayerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenConnectionIdIsNull()
        {
            string connectionId = null;
            string playerName = "John";

            Assert.Throws<ArgumentNullException>(() => new Player(connectionId, playerName));
        }

        [Test]
        public void ThrowArgumentException_WhenConnectionIdIsEmptyString()
        {
            string connectionId = "";
            string playerName = "John";

            Assert.Throws<ArgumentException>(() => new Player(connectionId, playerName));
        }

        [Test]
        public void NotThrow_WhenNameIsNull()
        {
            string connectionId = "connectionId";
            string playerName = null;

            Assert.DoesNotThrow(() => new Player(connectionId, playerName));
        }

        [Test]
        public void SetNameAsDefault_WhenNameIsNull()
        {
            string connectionId = "connectionId";
            string playerName = null;

            var player = new Player(connectionId, playerName);

            StringAssert.Contains("Default", player.Name);
        }

        [TestCase("John")]
        [TestCase("John123")]
        [TestCase("123")]
        public void SetNameCorrectly_WhenAValidStringIsPassed(string playerName)
        {
            string connectionId = "connectionId";

            var player = new Player(connectionId, playerName);
            string actualName = player.Name;

            Assert.AreEqual(actualName, playerName);
        }

        [TestCase("connectionId")]
        [TestCase("connectionId123")]
        [TestCase("123")]
        public void SetConnectionIdCorrectly_WhenAValidStringIsPassed(string connectionId)
        {
            string playerName = "John";

            var player = new Player(connectionId, playerName);
            string actualConnectionId = player.ConnectionId;

            Assert.AreEqual(actualConnectionId, connectionId);
        }
    }
}
