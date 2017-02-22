using SlienGames.Data.Services.Contracts;
using System;
using WebFormsMvp;

namespace SlienGames.MVP.Profiles.Profile
{
    public class ProfilePresenter : Presenter<IProfileView>
    {
        private readonly IUsersService usersService;

        public ProfilePresenter(IProfileView view, IUsersService usersService)
            : base(view)
        {
            if (usersService == null)
            {
                throw new ArgumentNullException();
            }

            this.usersService = usersService;
            this.View.GetCurrentUser += View_MyInit;
        }

        private void View_MyInit(object sender, ProfileEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}