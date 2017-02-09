using SlienGames.Web.Models;
using SlienGames.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using SlienGames.Web.CustomEventArgs;
using SlienGames.Data.Models;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using SlienGames.Web.Presenters;

namespace SlienGames.Web.Account
{
    [PresenterBinding(typeof(CurrentUserPresenter))]
    public partial class AllFavorites : MvpPage<CurrentUserModel>, ICurrentUserView
    {
        public User CurrentUser { get; private set; }

        public event EventHandler<CurrentUserEventArgs> MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, new CurrentUserEventArgs(this.User.Identity.GetUserId()));
            this.CurrentUser = this.Model.User;

            if (this.CurrentUser.Favorites.Count > 0)
            {
                this.ListViewFavorites.DataSource = this.CurrentUser.Favorites;
                this.ListViewFavorites.DataBind();
            }
        }
    }
}