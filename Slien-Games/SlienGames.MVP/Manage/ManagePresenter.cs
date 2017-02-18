using SlienGames.Data.Services.Contracts;
using WebFormsMvp;

namespace SlienGames.MVP.Manage
{
    public class ManagePresenter : Presenter<IManageView>
    {
        private IUsersService usersService;

        public ManagePresenter(IManageView view, IUsersService usersService)
            : base(view)
        {
            this.usersService = usersService;
            this.View.GetCurrentUser += View_MyInit;
        }

        private void View_MyInit(object sender, ManageEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}