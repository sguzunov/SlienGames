using SlienGames.Data.Services.Contracts;
using WebFormsMvp;

namespace SlienGames.MVP.PlayedGame.TicTacToe
{
    public class TicTacToePresenter : Presenter<ITicTacToeView>
    {
        private readonly IUsersService usersService;
        
        public TicTacToePresenter(ITicTacToeView view, IUsersService usersService) : base(view)
        {
            this.usersService = usersService;

            this.View.GetCurrentUser += View_MyInit;
        }

        private void View_MyInit(object sender, TicTacToeEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}