using SlienGames.Data.Models;
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
using Microsoft.AspNet.Identity;

namespace SlienGames.Web.Profiles
{
    [PresenterBinding(typeof(CurrentUserPresenter))]
    public partial class Profile : MvpPage<CurrentUserModel>, ICurrentUserView
    {
        public User CurrentUser { get; private set; }

        public event EventHandler<IdEventArgs> MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            var usersProfileId = Request.QueryString["id"];
            if (this.User.Identity.GetUserId() == usersProfileId)
            {
                Response.Redirect("/Account/Manage");
            }
            MyInit?.Invoke(sender, new IdEventArgs(usersProfileId));
            this.CurrentUser = this.Model.User;
        }
    }
}