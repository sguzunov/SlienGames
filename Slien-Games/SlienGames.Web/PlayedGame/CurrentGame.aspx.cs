using SlienGames.Web.Models;
using SlienGames.Web.Presenters;
using SlienGames.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using SlienGames.Web.CustomEventArgs;
using SlienGames.Data.Models;
using Microsoft.AspNet.Identity;

namespace SlienGames.Web.PlayedGame
{
    [PresenterBinding(typeof(PlayedGamePresenter))]
    public partial class CurrentGame : MvpPage<PlayedGameModel>, IPlayedGameView
    {
        public User CurrentUser { get; set; }

        public EmbeddedGame Game { get; set; }

        public event EventHandler<IdEventArgs> GetGame;

        public event EventHandler<IdEventArgs> GetUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            var gameId = Request.QueryString["id"];
            var userId = this.User.Identity.GetUserId();
            if (gameId == null)
            {
                Server.Transfer("/Errors/PageNotFound.aspx");

            }
            this.GetGame?.Invoke(sender, new IdEventArgs(int.Parse(gameId)));
            if (this.Model.EmbeddedGame==null)
            {
                Server.Transfer("/Errors/PageNotFound.aspx");
            }
            this.Game = this.Model.EmbeddedGame;

            this.GetUser?.Invoke(sender, new IdEventArgs(userId));
            this.CurrentUser = this.Model.User;
        }
    }
}