using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlienGames.Web.ChatHubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string message, string groupName, string senderName, string senderPictureUrl)
        {
            Clients.Group(groupName, new string[] { this.Context.ConnectionId }).acceptMessage(message, senderName, senderPictureUrl);
        }

        public void JoinGroup(string room)
        {
            Groups.Add(Context.ConnectionId, room);
        }
    }
}