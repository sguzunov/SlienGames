using SlienGames.Web.Models;
using System;
using WebFormsMvp;

namespace SlienGames.Web.Views
{
    public interface IUserView : IView<UserViewModel>
    {
        event EventHandler MyInit;
    }
}
