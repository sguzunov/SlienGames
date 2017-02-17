using Ninject.Extensions.Factory;
using Ninject.Modules;

using SlienGames.Web.GamesHubs.States;
using TicTacToeGame;
using TicTacToeGame.Contracts;
using TicTacToeGame.Factories;

namespace SlienGames.Web.App_Start.NinjectModules
{
    public class GamesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMultiplayerGame>().To<TicTacToe>();
            this.Bind<IPlayer>().To<Player>();
            this.Bind<IPlayerFactory>().ToFactory().InSingletonScope();
            this.Bind<IGameFactory>().ToFactory().InSingletonScope();
            this.Bind<ITicTacToeHubState>().To<TicTacToeHubState>().InSingletonScope();
        }
    }
}