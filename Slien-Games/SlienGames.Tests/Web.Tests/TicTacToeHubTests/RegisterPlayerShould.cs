using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Hubs;

using Moq;
using NUnit.Framework;

using SlienGames.Web.GamesHubs;
using SlienGames.Web.GamesHubs.States;
using TicTacToeGame.Contracts;
using TicTacToeGame.Factories;

namespace SlienGames.Tests.Web.Tests.TicTacToeHubTests
{
    [TestFixture]
    public class RegisterPlayerShould
    {
        [Test]
        public void CallPlayerFactoryToCreateANewPlayer()
        {
            var fakeState = new Mock<ITicTacToeHubState>();
            var fakePlayerFactory = new Mock<IPlayerFactory>();
            var fakeGameFactory = new Mock<IGameFactory>();
            var hub = new TicTacToeHub(fakeState.Object, fakePlayerFactory.Object, fakeGameFactory.Object);
            var callerContext = new Mock<HubCallerContext>();
            hub.Context = callerContext.Object;

            callerContext.Setup(x => x.ConnectionId).Returns(It.IsAny<string>);
            fakePlayerFactory.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            fakeState.Setup(x => x.Clients).Returns(new List<IPlayer>());

            hub.RegisterPlayer(It.IsAny<string>());

            fakePlayerFactory.Verify(x => x.Create(It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce);
        }

        [Test]
        public void CallPlayerFactoryToCreateANewPlayerWithCorrectParams()
        {
            var fakeState = new Mock<ITicTacToeHubState>();
            var fakePlayerFactory = new Mock<IPlayerFactory>();
            var fakeGameFactory = new Mock<IGameFactory>();
            var hub = new TicTacToeHub(fakeState.Object, fakePlayerFactory.Object, fakeGameFactory.Object);
            var callerContext = new Mock<HubCallerContext>();
            hub.Context = callerContext.Object;
            string connectionId = "connectionId";
            string playerName = "John";

            callerContext.Setup(x => x.ConnectionId).Returns(connectionId);
            fakePlayerFactory.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            fakeState.Setup(x => x.Clients).Returns(new List<IPlayer>());

            hub.RegisterPlayer(playerName);

            fakePlayerFactory.Verify(x => x.Create(connectionId, playerName));
        }

        [Test]
        public void CallStateClientsToSaveTheNewPlayer()
        {
            var fakeState = new Mock<ITicTacToeHubState>();
            var fakePlayerFactory = new Mock<IPlayerFactory>();
            var fakeGameFactory = new Mock<IGameFactory>();
            var hub = new TicTacToeHub(fakeState.Object, fakePlayerFactory.Object, fakeGameFactory.Object);
            var callerContext = new Mock<HubCallerContext>();
            var fakeClients = new Mock<ICollection<IPlayer>>();
            hub.Context = callerContext.Object;

            callerContext.Setup(x => x.ConnectionId).Returns(It.IsAny<string>());
            fakePlayerFactory.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>()));
            fakeClients.Setup(x => x.Add(It.IsAny<IPlayer>())).Verifiable();
            fakeState.Setup(x => x.Clients).Returns(fakeClients.Object);

            hub.RegisterPlayer(It.IsAny<string>());

            fakeClients.Verify(x => x.Add(It.IsAny<IPlayer>()), Times.Once);
        }
    }
}
