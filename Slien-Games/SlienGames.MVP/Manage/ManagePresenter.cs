using SlienGames.Data.Services.Contracts;
using System;
using WebFormsMvp;

namespace SlienGames.MVP.Manage
{
    public class ManagePresenter : Presenter<IManageView>
    {
        private IUsersService usersService;

        public ManagePresenter(IManageView view, IUsersService usersService)
            : base(view)
        {
            if (usersService==null)
            {
                throw new ArgumentNullException(nameof(usersService));
            }
            this.usersService = usersService;
            this.View.GetCurrentUser += View_MyInit;
        }

        private void View_MyInit(object sender, ManageEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}