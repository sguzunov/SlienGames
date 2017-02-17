using SlienGames.Data.Services.Contracts;
using SlienGames.Web.CustomEventArgs;
using SlienGames.Web.Views;
using WebFormsMvp;

namespace SlienGames.Web.Presenters
{
    public class CurrentUserPresenter : Presenter<ICurrentUserView>
    {
        private IUsersService usersService;

        public CurrentUserPresenter(ICurrentUserView view, IUsersService usersService)
            : base(view)
        {
            this.usersService = usersService;
            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, IdEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}