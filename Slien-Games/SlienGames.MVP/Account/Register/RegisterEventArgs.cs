using SlienGames.Auth;
using System;

namespace SlienGames.MVP.Account.Register
{
    public class RegisterEventArgs
    {
        private const string NullDependencyErrorMessage = "{0} is null!";

        public RegisterEventArgs(
            string username,
            string password,
            string email,
            ApplicationUserManager applicationUserManager,
            ApplicationSignInManager applicationSignInManager)
        {
            if (username == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(username)));
            }
            if (password == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(password)));
            }
            if (email == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(email)));
            }
            if (applicationUserManager == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(applicationUserManager)));
            }
            if (applicationSignInManager == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(applicationSignInManager)));
            }
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.ApplicationUserManager = applicationUserManager;
            this.ApplicationSignInManager = applicationSignInManager;
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public string Email { get; private set; }

        public ApplicationUserManager ApplicationUserManager { get; private set; }

        public ApplicationSignInManager ApplicationSignInManager { get; set; }
    }
}
