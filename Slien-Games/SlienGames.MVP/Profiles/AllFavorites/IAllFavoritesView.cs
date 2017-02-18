using System;
using WebFormsMvp;

namespace SlienGames.MVP.Profiles.AllFavorites
{
    public interface IAllFavoritesView : IView<AllFavoritesModel>
    {
        event EventHandler<AllFavoritesEventArgs> GetCurrentUser;
    }
}
