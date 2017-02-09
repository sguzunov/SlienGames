using Ninject.Modules;
using SlienGames.Web.Services;
using SlienGames.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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