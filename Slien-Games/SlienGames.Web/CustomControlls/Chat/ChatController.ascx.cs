using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlienGames.Web.CustomControlls.Chat
{
    public partial class ChatController : System.Web.UI.UserControl
    {
        public string Username { get; set; }

        public string UserPictureUrl { get; set; }

        public string GroupId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}