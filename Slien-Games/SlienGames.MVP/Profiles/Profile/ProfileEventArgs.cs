using System;

namespace SlienGames.MVP.Profiles.Profile
{
    public class ProfileEventArgs : EventArgs
    {
        public ProfileEventArgs(object id)
        {
            this.Id = id;
        }
        public object Id { get; private set; }
    }
}