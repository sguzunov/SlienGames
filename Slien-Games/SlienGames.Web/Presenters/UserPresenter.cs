using SlienGames.Data.Services.Contracts;
using SlienGames.Web.Views;
using System;
using System.Linq;
using WebFormsMvp;

namespace SlienGames.Web.Presenters
{
    public class UserPresenter : Presenter<IUserView>
    {
        private readonly IUsersService usersService;
        
        public UserPresenter(IUserView view, IUsersService usersService) : base(view)
        {
            this.usersService = usersService;

            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            this.View.Model.Users = this.usersService.GetAll(null, x => x.Score).Take(5);
        }
    }
}