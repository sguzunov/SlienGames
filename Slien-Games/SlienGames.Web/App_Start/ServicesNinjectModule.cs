using Ninject.Modules;
using SlienGames.Data.Services;
using SlienGames.Data.Services.Contracts;
using SlienGames.Web.Services;
using SlienGames.Web.Services.Contracts;

namespace SlienGames.Web.App_Start
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFileSaver>().To<FileSaver>();
            this.Bind<IGameProfileServices>().To<GameProfileServices>();
        }
    }
}