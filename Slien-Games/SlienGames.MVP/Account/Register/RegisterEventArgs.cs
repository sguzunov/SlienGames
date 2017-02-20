using SlienGames.Auth;

namespace SlienGames.MVP.Account.Register
{
    public class RegisterEventArgs
    {
        public RegisterEventArgs(
            string username,
            string password,
            string email,
            ApplicationUserManager applicationUserManager,
            ApplicationSignInManager applicationSignInManager)
        {
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
