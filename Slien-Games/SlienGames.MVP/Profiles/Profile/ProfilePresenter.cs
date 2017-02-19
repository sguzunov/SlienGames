using SlienGames.Data.Services.Contracts;
using WebFormsMvp;

namespace SlienGames.MVP.Profiles.Profile
{
    public class ProfilePresenter : Presenter<IProfileView>
    {
        private readonly IUsersService usersService;

        public ProfilePresenter(IProfileView view, IUsersService usersService)
            : base(view)
        {
            this.usersService = usersService;
            this.View.GetCurrentUser += View_MyInit;
        }

        private void View_MyInit(object sender, ProfileEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}