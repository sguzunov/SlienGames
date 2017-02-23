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
    public class SendMessageShould
    {
        [Test]
        public void CallContextConnectionIdPropertyOnce()
        {
            const string connectionId = "1";
            dynamic group = new ExpandoObject();
            
            group.acceptMessage = new Action<object, object, object>((x, y, z) =>
            {
            });

            var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            mockClients.Setup(m => m.Group(It.IsAny<string>(), It.IsAny<string[]>())).Returns((ExpandoObject)group);

            var mockHubCallerContext = new Mock<HubCallerContext>();
            mockHubCallerContext.Setup(x => x.ConnectionId).Returns(connectionId);
            var hub = new ChatHub
            {
                Clients = mockClients.Object,
                Context = mockHubCallerContext.Object
            };

            hub.SendMessage("gosho", "gosho", "gosho", "gosho");

            mockHubCallerContext.Verify(x => x.ConnectionId, Times.Once);
        }

        [Test]
        public void CallClientsАcceptMessageMethodOnce()
        {
            const string connectionId = "1";
            dynamic group = new ExpandoObject();

            var IsSendMessageCalled = false;

            group.acceptMessage = new Action<object, object, object>((x, y, z) =>
              {
                  IsSendMessageCalled = true;
              });

            var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            mockClients.Setup(m => m.Group(It.IsAny<string>(), It.IsAny<string[]>())).Returns((ExpandoObject)group);
            
            var mockHubCallerContext = new Mock<HubCallerContext>();
            mockHubCallerContext.Setup(x => x.ConnectionId).Returns(connectionId);
            var hub = new ChatHub
            {
                Clients = mockClients.Object,
                Context = mockHubCallerContext.Object
            };

            hub.SendMessage("gosho", "gosho", "gosho", "gosho");

            Assert.True(IsSendMessageCalled);
        }
    }
}
