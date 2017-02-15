using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlienGames.Web.PlayedGame
{
    public partial class TicTacToe : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string username = this.User.Identity.Name;
                this.InputUsername.Value = username;
            }
        }
    }
}