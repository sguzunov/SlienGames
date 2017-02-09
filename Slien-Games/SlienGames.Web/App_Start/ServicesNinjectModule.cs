using Ninject.Modules;
using SlienGames.Web.Services;
using SlienGames.Web.Services.Contracts;

namespace SlienGames.Web.App_Start
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFileSaver>().To<FileSaver>();
        }
    }
}