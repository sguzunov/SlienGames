using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using SlienGames.Web.App_Start;
using WebFormsMvp;
using SlienGames.Web.Presenters;
using SlienGames.Data.Models;
using WebFormsMvp.Web;
using SlienGames.Web.Models;
using SlienGames.Web.Views;
using SlienGames.Web.CustomEventArgs;

namespace SlienGames.Web.Account
{
    [PresenterBinding(typeof(CurrentUserPresenter))]
    public partial class Manage : MvpPage<CurrentUserModel>, ICurrentUserView
    {
        public User CurrentUser { get; private set; }

        public event EventHandler<CurrentUserEventArgs> MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, new CurrentUserEventArgs(this.User.Identity.GetUserId()));
            this.CurrentUser = this.Model.User;
        }


    }
}