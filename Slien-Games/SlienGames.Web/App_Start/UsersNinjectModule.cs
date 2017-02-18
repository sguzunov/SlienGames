using Ninject.Modules;
using SlienGames.MVP.Home;

namespace SlienGames.Web.App_Start
{
    public class UsersNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<HomePresenter>().ToSelf();
            //this.Bind<CurrentUserPresenter>().ToSelf();
        }
    }
}