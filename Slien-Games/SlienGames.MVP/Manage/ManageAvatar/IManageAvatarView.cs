using System;
using WebFormsMvp;

namespace SlienGames.MVP.Manage.ManageAvatar
{
    public interface IManageAvatarView : IView<ManageAvatarModel>
    {
        event EventHandler<IdEventArgs> GetCurrentUser;

        event EventHandler<ManageAvatarEventArgs> SetNewAvatar;
    }
}
