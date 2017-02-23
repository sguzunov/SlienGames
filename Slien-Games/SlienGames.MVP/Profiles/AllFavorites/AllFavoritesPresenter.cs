using SlienGames.Data.Services.Contracts;
using System;
using WebFormsMvp;

namespace SlienGames.MVP.Profiles.AllFavorites
{
    public class AllFavoritesPresenter : Presenter<IAllFavoritesView>
    {
        private IUsersService usersService;

        public AllFavoritesPresenter(IAllFavoritesView view, IUsersService usersService)
            : base(view)
        {
            if (usersService == null)
            {
                throw new ArgumentNullException(nameof(usersService));
            }

            this.usersService = usersService;
            this.View.GetCurrentUser += View_MyInit;
        }

        private void View_MyInit(object sender, AllFavoritesEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}