using SlienGames.Data.Services.Contracts;
using System;
using WebFormsMvp;

namespace SlienGames.MVP.PlayedGame.TicTacToe
{
    public class TicTacToePresenter : Presenter<ITicTacToeView>
    {
        private readonly IUsersService usersService;

        public TicTacToePresenter(ITicTacToeView view, IUsersService usersService) : base(view)
        {
            if (usersService == null)
            {
                throw new ArgumentNullException(nameof(usersService));
            }

            this.usersService = usersService;

            this.View.GetCurrentUser += View_MyInit;
        }

        private void View_MyInit(object sender, TicTacToeEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}