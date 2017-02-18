using System;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using SlienGames.Data.Models;
using WebFormsMvp.Web;
using System.Linq;
using SlienGames.MVP.Manage;

namespace SlienGames.Web.Account
{
    [PresenterBinding(typeof(ManagePresenter))]
    public partial class Manage : MvpPage<ManageModel>, IManageView
    {
        public User CurrentUser { get; private set; }

        public event EventHandler<ManageEventArgs> GetCurrentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetCurrentUser?.Invoke(sender, new ManageEventArgs(this.User.Identity.GetUserId()));
            this.CurrentUser = this.Model.User;

            if (this.CurrentUser.Favorites.Count>0)
            {
                this.ListViewFavorites.DataSource = this.CurrentUser.Favorites.Take(4);
                this.ListViewFavorites.DataBind();
            }
        }


    }
}