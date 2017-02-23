using SlienGames.Auth;
using System;

namespace SlienGames.MVP.Account.Login
{
    public class LoginEventArgs
    {
        private const string NullDependencyErrorMessage = "{0} is null!";

        public LoginEventArgs(string username, string password, bool isPersistent, bool shouldBeLockout, ApplicationSignInManager signInManager)
        {
            if (username == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(username)));
            }

            if (password == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(password)));
            }

            if (signInManager == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(signInManager)));
            }

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
