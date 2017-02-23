using System;

namespace SlienGames.MVP.Profiles.Profile
{
    public class ProfileEventArgs : EventArgs
    {
        public ProfileEventArgs(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            this.Id = id;
        }
        public object Id { get; private set; }
    }
}