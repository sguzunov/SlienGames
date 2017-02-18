using Microsoft.AspNet.Identity;
using SlienGames.Data.Models;
using SlienGames.MVP.PlayedGame.TicTacToe;
using System;
using System.Web.UI;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SlienGames.Web.PlayedGame
{
    [PresenterBinding(typeof(TicTacToePresenter))]
    public partial class TicTacToe : MvpPage<TicTacToeModel>, ITicTacToeView
    {
        public event EventHandler<TicTacToeEventArgs> GetCurrentUser;
        public User CurrentUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string username = this.User.Identity.Name;
                this.InputUsername.Value = username;
            }

            this.GetCurrentUser?.Invoke(sender, new TicTacToeEventArgs(this.User.Identity.GetUserId()));
            this.CurrentUser = this.Model.User;

            this.ChatController.Username = this.CurrentUser.UserName;
            this.ChatController.UserPictureUrl =
                this.CurrentUser.ProfileImage == null ? "/Content/Avatars/default.png" : this.CurrentUser.ProfileImage.FileSystemUrlPath
                              + this.CurrentUser.ProfileImage.FileName;
            this.ChatController.GroupId = "tictactoe";
        }
    }
}