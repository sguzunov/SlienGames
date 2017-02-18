using SlienGames.Data.Services.Contracts;
using System;
using System.Linq;
using WebFormsMvp;

namespace SlienGames.MVP.Home
{
    public class HomePresenter : Presenter<IHomeView>
    {
        private readonly IUsersService usersService;
        
        public HomePresenter(IHomeView view, IUsersService usersService) : base(view)
        {
            this.usersService = usersService;

            this.View.GetTopUsers += View_MyInit;
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            this.View.Model.Users = this.usersService.GetAll(null, x => x.Score).Take(5);
        }
    }
}