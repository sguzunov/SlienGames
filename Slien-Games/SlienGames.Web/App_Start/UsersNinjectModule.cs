using Ninject.Modules;
using SlienGames.Web.Presenters;

namespace SlienGames.Web.App_Start
{
    public class UsersNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<UserPresenter>().ToSelf();
            this.Bind<CurrentUserPresenter>().ToSelf();
        }
    }
}