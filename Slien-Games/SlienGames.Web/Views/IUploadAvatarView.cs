using SlienGames.Web.CustomEventArgs;
using SlienGames.Web.Models;
using System;
using WebFormsMvp;

namespace SlienGames.Web.Views
{
    public interface IUploadAvatarView : IView<CurrentUserModel>
    {
        event EventHandler<CurrentUserEventArgs> GetCurrentUser;

        event EventHandler<UploadAvatarEventArgs> SetNewAvatar;

    }
}
