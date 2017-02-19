using System;

using WebFormsMvp;

namespace SlienGames.MVP.Account.Register
{
    public interface RegisterView : IView<RegiserViewModel>
    {
        event EventHandler<RegisterEventArgs> CreateUser;
    }
}
