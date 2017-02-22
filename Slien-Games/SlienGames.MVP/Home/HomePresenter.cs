using SlienGames.Data.Services.Contracts;
using System;
using System.Linq;
using WebFormsMvp;

namespace SlienGames.MVP.Home
{
    public class HomePresenter : Presenter<IHomeView>
    {
        private const string NullDependencyErrorMessage = "{0} is null!";

        private readonly IUsersService usersService;
        
        public HomePresenter(IHomeView view, IUsersService usersService) : base(view)
        {
            if (usersService == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(usersService)));
            }

            this.usersService = usersService;

            this.View.GetTopUsers += View_MyInit;
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            this.View.Model.Users = this.usersService.GetAll(null, x => x.Score).Take(5);
        }
    }
}