using System.Linq;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using SlienGames.Data.Models;

using WebFormsMvp;

namespace SlienGames.MVP.Account.Register
{
    public class RegisterPresenter : Presenter<RegisterView>
    {
        public RegisterPresenter(RegisterView view) : base(view)
        {
            this.View.CreateUser += View_CreateUser;
        }

        private void View_CreateUser(object sender, RegisterEventArgs e)
        {
            var user = new User { UserName = e.Username, Email = e.Email };

            IdentityResult result = e.ApplicationUserManager.Create(user, e.Password);
            if (result.Succeeded)
            {
                e.ApplicationSignInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                this.View.Model.IsRegistered = true;
            }
            else
            {
                this.View.Model.IsRegistered = false;
                this.View.Model.ErrorMessage = result.Errors.FirstOrDefault();
            }
        }
    }
}
