using System;
using WebFormsMvp.Web;
using SlienGames.Data.Models;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using SlienGames.MVP.Profiles.AllFavorites;

namespace SlienGames.Web.Profiles
{
    [PresenterBinding(typeof(AllFavoritesPresenter))]
    public partial class AllFavorites : MvpPage<AllFavoritesModel>, IAllFavoritesView
    {
        public User CurrentUser { get; private set; }

        public event EventHandler<AllFavoritesEventArgs> GetCurrentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetCurrentUser?.Invoke(sender, new AllFavoritesEventArgs(this.User.Identity.GetUserId()));
            this.CurrentUser = this.Model.User;

            if (this.CurrentUser.Favorites.Count > 0)
            {
                this.ListViewFavorites.DataSource = this.CurrentUser.Favorites;
                this.ListViewFavorites.DataBind();
            }
        }
    }
}