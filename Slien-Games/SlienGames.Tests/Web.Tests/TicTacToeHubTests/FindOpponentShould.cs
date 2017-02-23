using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;
using SlienGames.Web.GamesHubs.States;
using TicTacToeGame.Factories;
using Microsoft.AspNet.SignalR.Hubs;
using SlienGames.Web.GamesHubs;
using TicTacToeGame.Contracts;

namespace SlienGames.Tests.Web.Tests.TicTacToeHubTests
{

    /*
         var fakeState = new Mock<ITicTacToeHubState>();
            var fakePlayerFactory = new Mock<IPlayerFactory>();
            var fakeGameFactory = new Mock<IGameFactory>();
            var hub = new TicTacToeHub(fakeState.Object, fakePlayerFactory.Object, fakeGameFactory.Object);
            var callerContext = new Mock<HubCallerContext>();
            hub.Context = callerContext.Object;

            callerContext.Setup(x => x.ConnectionId).Returns(It.IsAny<string>);
            fakePlayerFactory.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            fakeState.Setup(x => x.Clients).Returns(new List<IPlayer>());              
    */
    internal interface IClientContract
    {
        void noOpponentFound();
    }

    [TestFixture]
    public class FindOpponentShould
    {
        [Test]
        public void CallClientNoOpponentFound()
        {
            //var fakeState = new Mock<ITicTacToeHubState>();
            //var fakePlayerFactory = new Mock<IPlayerFactory>();
            //var fakeGameFactory = new Mock<IGameFactory>();
            //var fakeClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            //var hub = new TicTacToeHub(fakeState.Object, fakePlayerFactory.Object, fakeGameFactory.Object);
            //var all = new Mock<IClientContract>();
            //var callerContext = new Mock<HubCallerContext>();
            //hub.Context = callerContext.Object;
            //hub.Clients = fakeClients.Object;
            //string connectionId = "ConnectionId";
            //var fakeRegisteredClient = new Mock<IPlayer>();

            //fakeRegisteredClient.Setup(x => x.ConnectionId).Returns(connectionId);
            //all.Setup(x => x.noOpponentFound()).Verifiable();
            //callerContext.Setup(x => x.ConnectionId).Returns(connectionId);
            //fakeState.Setup(x => x.Clients).Returns(new List<IPlayer>() { fakeRegisteredClient.Object });
            //fakeClients.Setup(x => x.Client(connectionId)).Returns(fakeRegisteredClient.Object);

            //hub.FindOpponent();

            //all.Verify();
        }
    }
}
