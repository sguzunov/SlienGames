using System;

using WebFormsMvp;

namespace SlienGames.MVP.Account.Login
{
    public interface ILoginView : IView<LoginViewModel>
    {
        event EventHandler<LoginEventArgs> LoginUser;
    }
}
