using System;
using System.Web;

using Microsoft.AspNet.Identity.Owin;

using SlienGames.Auth;
using SlienGames.MVP.Account.Register;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace SlienGames.Web.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : MvpPage<RegiserViewModel>, RegisterView
    {
        public event EventHandler<RegisterEventArgs> CreateUser;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var username = this.TextBoxUsername.Text;
            var password = this.TextBoxPassword.Text;
            var email = this.TextBoxEmail.Text;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var registerArgs = new RegisterEventArgs(username, password, email, manager, signInManager);

            this.CreateUser(this, registerArgs);

            if (this.Model.IsRegistered)
            {
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                LiteralErrorMessage.Text = this.Model.ErrorMessage;
            }
        }
    }
}