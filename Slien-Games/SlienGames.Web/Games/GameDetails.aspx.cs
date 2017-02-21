using System;

using SlienGames.MVP.Games.Details;

using WebFormsMvp;
using WebFormsMvp.Web;
using AjaxControlToolkit;
using Microsoft.AspNet.Identity;

namespace SlienGames.Web.Games
{
    [PresenterBinding(typeof(GameDetailsPresenter))]
    public partial class GameDetails : MvpPage<GameDetailsViewModel>, IGameInfoView
    {
        public event EventHandler<RateGameEventArgs> ComentGame;
        public event EventHandler<GetDetailsEventArgs> GetGameDetails;
        public event EventHandler<RateGameEventArgs> RateGame;

        protected void Page_Load(object sender, EventArgs e)
        {
            var gameName = this.Request.QueryString["name"];
            var gameArgs = new GetDetailsEventArgs(gameName);

            this.GetGameDetails?.Invoke(this, gameArgs);
        }

        protected void Rating_Changed(object sender, RatingEventArgs e)
        {
            var rating = int.Parse(e.Value);
            var userId = Guid.Parse(this.User.Identity.GetUserId());
            var rateArgs = new RateGameEventArgs(this.Model.GameId, userId, rating);

            this.RateGame?.Invoke(this, rateArgs);
        }
    }
}