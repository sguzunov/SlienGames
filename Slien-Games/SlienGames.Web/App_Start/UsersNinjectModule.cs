using Ninject.Modules;
using SlienGames.Web.Presenters;
using SlienGames.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlienGames.Web.App_Start
{
    public class UsersNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDataProvider>().To<DataProvider>();

            this.Bind<UserPresenter>().ToSelf();
            this.Bind<CurrentUserPresenter>().ToSelf();
        }
    }
}