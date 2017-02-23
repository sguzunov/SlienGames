using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using Microsoft.AspNet.Identity;

using SlienGames.MVP.Games.Details;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SlienGames.Web.Games
{
    [PresenterBinding(typeof(GameDetailsPresenter))]
    public partial class GameDetails : MvpPage<GameDetailsViewModel>, IGameInfoView
    {
        public event EventHandler<GetDetailsEventArgs> GetGameDetails;
        public event EventHandler<LikeGameEventArgs> LikeGame;
        public event EventHandler<NewCommentEventArgs> AddComment;

        protected void Page_Load(object sender, EventArgs e)
        {
            var gameName = this.Request.QueryString["name"];

            string username = null;
            if (this.User.Identity.IsAuthenticated)
            {
                username = this.User.Identity.GetUserName();
            }

            var gameArgs = new GetDetailsEventArgs(gameName, username);
            this.GetGameDetails?.Invoke(this, gameArgs);

            if (this.User.Identity.IsAuthenticated)
            {
                this.SetFavouriteBtnImage();
            }
        }

        protected void ButtonLikeUnlike_Click(object sender, EventArgs e)
        {
            var username = this.User.Identity.GetUserName();
            var likeArgs = new LikeGameEventArgs(this.Model.GameId, username);

            this.LikeGame?.Invoke(this, likeArgs);
            this.SetFavouriteBtnImage();
        }

        private void SetFavouriteBtnImage()
        {
            var buttonLikeUnlike = (Image)this.LoginViewLike.FindControl("ButtonLikeUnlike");
            buttonLikeUnlike.ImageUrl = "/Content/Images/" + (this.Model.IsFavourite ? "liked-game.png" : "not-liked-game.png");
            buttonLikeUnlike.DataBind();
        }

        protected void ButtonAddComment_ServerClick(object sender, EventArgs e)
        {
            var commentContent = ((HtmlTextArea)this.LoginViewAddComment.FindControl("CommentContent")).InnerText;
            if (string.IsNullOrEmpty(commentContent))
            {
                ((Label)this.LoginViewAddComment.FindControl("CommentContentErrorMessage")).Text = "Add some content to your comment, please.";
                this.DataBind();
                return;
            }

            var commentArgs = new NewCommentEventArgs(this.Model.GameId, this.User.Identity.GetUserName(), commentContent);
            this.AddComment?.Invoke(this, commentArgs);
            this.UpdatePanelComments.Update();
        }
    }
}