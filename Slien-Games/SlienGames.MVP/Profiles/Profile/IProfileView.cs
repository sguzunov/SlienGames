using System;
using WebFormsMvp;

namespace SlienGames.MVP.Profiles.Profile
{
    public interface IProfileView : IView<ProfileModel>
    {
        event EventHandler<ProfileEventArgs> GetCurrentUser;
    }
}
