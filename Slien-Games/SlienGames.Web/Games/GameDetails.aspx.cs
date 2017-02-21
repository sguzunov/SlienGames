using System;

using SlienGames.MVP.Games.Details;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace SlienGames.Web.Games
{
    [PresenterBinding(typeof(GameDetailsPresenter))]
    public partial class GameDetails : MvpPage<GameDetailsViewModel>, IGameInfoView
    {
        public event EventHandler<GetGameDetailsEventArgs> GetGameDetails;

        protected void Page_Load(object sender, EventArgs e)
        {
            var gameName = this.Request.QueryString["name"];

            var gameArgs = new GetGameDetailsEventArgs(gameName);

            this.GetGameDetails(this, gameArgs);
        }
    }
}