using SlienGames.Data.Models;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;
using SlienGames.MVP.Profiles.Profile;

namespace SlienGames.Web.Profiles
{
    [PresenterBinding(typeof(ProfilePresenter))]
    public partial class Profile : MvpPage<ProfileModel>, IProfileView
    {
        public User CurrentUser { get; private set; }

        public event EventHandler<ProfileEventArgs> GetCurrentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            var usersProfileId = Request.QueryString["id"];
            if (this.User.Identity.GetUserId() == usersProfileId)
            {
                Response.Redirect("/Account/Manage");
            }
            GetCurrentUser?.Invoke(sender, new ProfileEventArgs(usersProfileId));
            this.CurrentUser = this.Model.User;
        }
    }
}