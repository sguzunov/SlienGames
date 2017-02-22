using Microsoft.AspNet.Identity.Owin;
using SlienGames.Data.Services.Contracts;
using System;
using WebFormsMvp;

namespace SlienGames.MVP.Account.Login
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        private const string NullDependencyErrorMessage = "{0} is null!";

        private readonly IUsersService usersService;
        public LoginPresenter(ILoginView view, IUsersService usersService) : base(view)
        {
            if (usersService == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(usersService)));
            }
            this.usersService = usersService;
            this.View.LoginUser += View_LoginUser;
        }

        private void View_LoginUser(object sender, LoginEventArgs e)
        {
            if (this.usersService.CheckIfIsBlocked(e.Username))
            {
                this.View.Model.SignInStatus = SignInStatus.Failure;
                return;
            }
            var signInStatus = e.SignInManager.PasswordSignIn(e.Username, e.Password, e.IsPersistent, e.ShouldBeLockout);
            this.View.Model.SignInStatus = signInStatus;
        }
    }
}
