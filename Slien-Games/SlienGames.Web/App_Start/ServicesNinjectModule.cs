using Ninject.Modules;

using SlienGames.Data.Services;
using SlienGames.Data.Services.Contracts;

namespace SlienGames.Web.App_Start
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFileSaver>().To<FileSaver>();
            this.Bind<IUsersService>().To<UserService>();
            this.Bind<IGamesService>().To<GamesService>();
            this.Bind<IReviewsService>().To<ReviewsService>();
        }
    }
}