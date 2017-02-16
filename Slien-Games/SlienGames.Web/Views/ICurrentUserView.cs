using SlienGames.Web.CustomEventArgs;
using SlienGames.Web.Models;
using System;
using WebFormsMvp;

namespace SlienGames.Web.Views
{
    public interface ICurrentUserView : IView<CurrentUserModel>
    {
        event EventHandler<IdEventArgs> MyInit;
    }
}
