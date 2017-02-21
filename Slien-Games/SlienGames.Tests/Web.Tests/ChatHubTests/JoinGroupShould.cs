using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Moq;
using NUnit.Framework;
using SlienGames.Web.ChatHubs;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.Web.Tests.ChatHubTests
{
    [TestFixture]
    public class JoinGroupShould
    {
        [Test]
        public void CallConnectionIdOnce()
        {
            const string connectionId = "1";

            var mockGroupManager = new Mock<IGroupManager>();
            mockGroupManager.Setup(x => x.Add(It.IsAny<string>(), It.IsAny<string>()));

            var mockHubCallerContext = new Mock<HubCallerContext>();
            mockHubCallerContext.Setup(x => x.ConnectionId).Returns(connectionId);
            var hub = new ChatHub
            {
                Context = mockHubCallerContext.Object,
                Groups = mockGroupManager.Object
            };

            hub.JoinGroup("gosho");

            mockHubCallerContext.Verify(x => x.ConnectionId, Times.Once);
        }

        [Test]
        public void CallAddMethodOnce()
        {
            const string connectionId = "1";
            
            var mockGroupManager = new Mock<IGroupManager>();
            mockGroupManager.Setup(x => x.Add(It.IsAny<string>(), It.IsAny<string>()));

            var mockHubCallerContext = new Mock<HubCallerContext>();
            mockHubCallerContext.Setup(x => x.ConnectionId).Returns(connectionId);
            var hub = new ChatHub
            {
                Context = mockHubCallerContext.Object,
                Groups = mockGroupManager.Object
            };

            hub.JoinGroup("gosho");

            mockGroupManager.Verify(x => x.Add(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
