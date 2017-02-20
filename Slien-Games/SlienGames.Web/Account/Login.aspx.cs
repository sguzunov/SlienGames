using System;
using System.Web;

using Microsoft.AspNet.Identity.Owin;

using SlienGames.Auth;
using SlienGames.MVP.Account.Login;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace SlienGames.Web.Account
{
    [PresenterBinding(typeof(LoginPresenter))]
    public partial class Login : MvpPage<LoginViewModel>, ILoginView
    {
        public event EventHandler<LoginEventArgs> LoginUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //   OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string username = this.TextBoxUsername.Text;
                string password = this.TextBoxPassword.Text;
                bool rememberUser = this.CheckBoxRememberMe.Checked;

                var signInManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                var loginArgs = new LoginEventArgs(username, password, isPersistent: rememberUser, shouldBeLockout: false, signInManager: signInManager);

                this.LoginUser(this, loginArgs);

                switch (this.Model.SignInStatus)
                {
                    case SignInStatus.Success:
                        {
                            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                            break;
                        }
                    case SignInStatus.LockedOut:
                        {
                            Response.Redirect("/Account/Lockout");
                            break;
                        }
                    case SignInStatus.RequiresVerification:
                        {
                            Response.Redirect(
                                    String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                    Request.QueryString["ReturnUrl"],
                                    rememberUser),
                                true);
                            break;
                        }

                    case SignInStatus.Failure:
                    default:
                        {
                            FailureText.Text = "Invalid login attempt";
                            ErrorMessage.Visible = true;
                            break;
                        }
                }
            }
        }
    }
}