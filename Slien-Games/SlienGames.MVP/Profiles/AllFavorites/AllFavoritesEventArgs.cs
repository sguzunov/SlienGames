using System;

namespace SlienGames.MVP.Profiles.AllFavorites
{
    public class AllFavoritesEventArgs : EventArgs
    {
        public AllFavoritesEventArgs(object id)
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