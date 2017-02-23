using SlienGames.Data.Services.Contracts;
using WebFormsMvp;

namespace SlienGames.MVP.PlayedGame.CurrentGame
{
    public class CurrentGamePresenter : Presenter<ICurrentGameView>
    {
        private readonly IGamesService gameService;
        private readonly IUsersService usersService;
        public CurrentGamePresenter(ICurrentGameView view, IGamesService gameService, IUsersService usersService) : base(view)
        {
            this.gameService = gameService;
            this.usersService = usersService;
            this.View.GetGame += View_GetGame;
            this.View.GetUser += View_GetUser;
        }

        private void View_GetGame(object sender, CurrentGameEventArgs e)
        {
            this.View.Model.EmbeddedGame = gameService.GetAGameById(e.Id);
        }

        private void View_GetUser(object sender, CurrentGameEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
        
    }
}