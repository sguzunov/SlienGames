using Microsoft.AspNet.SignalR;
namespace SlienGames.Web.ChatHubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string message, string groupName, string senderName, string senderPictureUrl)
        {
            Clients.Group(groupName, new string[] { this.Context.ConnectionId }).acceptMessage(System.Security.SecurityElement.Escape(message), senderName, senderPictureUrl);
        }

        public void JoinGroup(string room)
        {
            Groups.Add(Context.ConnectionId, room);
        }
    }
}