using System;

using Microsoft.AspNet.Identity;

using WebFormsMvp;
using WebFormsMvp.Web;

using SlienGames.Data.Models;
using SlienGames.MVP.PlayedGame.CurrentGame;

namespace SlienGames.Web.PlayedGame
{
    [PresenterBinding(typeof(CurrentGamePresenter))]
    public partial class CurrentGame : MvpPage<CurrentGameModel>, ICurrentGameView
    {
        public User CurrentUser { get; set; }

        public GameDetails Game { get; set; }

        public event EventHandler<CurrentGameEventArgs> GetGame;

        public event EventHandler<CurrentGameEventArgs> GetUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            var gameId = Request.QueryString["id"];
            var userId = this.User.Identity.GetUserId();
            if (gameId == null)
            {
                Server.Transfer("/Errors/PageNotFound.aspx");

            }
            this.GetGame?.Invoke(sender, new CurrentGameEventArgs(int.Parse(gameId)));
            if (this.Model.EmbeddedGame == null)
            {
                Server.Transfer("/Errors/PageNotFound.aspx");
            }
            this.Game = this.Model.EmbeddedGame;

            this.GetUser?.Invoke(sender, new CurrentGameEventArgs(userId));
            this.CurrentUser = this.Model.User;

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            this.ChatController.Username = this.CurrentUser.UserName;
            this.ChatController.UserPictureUrl =
                this.CurrentUser.ProfileImage == null ? "/Content/Avatars/default.png" : this.CurrentUser.ProfileImage.FileSystemUrlPath
                              + this.CurrentUser.ProfileImage.FileName;
            this.ChatController.GroupId = Request.QueryString["id"];
        }
    }
}