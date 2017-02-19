using SlienGames.Auth;

namespace SlienGames.MVP.Account.Login
{
    public class LoginEventArgs
    {
        public LoginEventArgs(string username, string password, bool isPersistent, bool shouldBeLockout, ApplicationSignInManager signInManager)
        {
            this.Username = username;
            this.Password = password;
            this.IsPersistent = isPersistent;
            this.ShouldBeLockout = shouldBeLockout;
            this.SignInManager = signInManager;
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public bool IsPersistent { get; private set; }

        public bool ShouldBeLockout { get; private set; }

        public ApplicationSignInManager SignInManager { get; set; }
    }
}
