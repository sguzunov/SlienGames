using Microsoft.AspNet.Identity.Owin;

using WebFormsMvp;

namespace SlienGames.MVP.Account.Login
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view) : base(view)
        {
            this.View.LoginUser += View_LoginUser;
        }

        private void View_LoginUser(object sender, LoginEventArgs e)
        {
            var signInStatus = e.SignInManager.PasswordSignIn(e.Username, e.Password, e.IsPersistent, e.ShouldBeLockout);
            this.View.Model.SignInStatus = signInStatus;
        }
    }
}
