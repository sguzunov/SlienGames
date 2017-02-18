using System;
using WebFormsMvp;

namespace SlienGames.MVP.Manage
{
    public interface IManageView : IView<ManageModel>
    {
        event EventHandler<ManageEventArgs> GetCurrentUser;
    }
}
