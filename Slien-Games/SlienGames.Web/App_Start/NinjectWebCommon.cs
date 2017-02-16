[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SlienGames.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SlienGames.Web.App_Start.NinjectWebCommon), "Stop")]

namespace SlienGames.Web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Data;
    using Data.Contracts;
    using Microsoft.AspNet.SignalR;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using NinjectModules;
    using WebFormsMvp.Binder;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(Kernel);
                RegisterSignalr(Kernel);

                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        public static IKernel Kernel
        {
            get;
            private set;
        }

        private static void RegisterSignalr(IKernel kernel)
        {
            GlobalHost.DependencyResolver = new NinjectSignalRDependencyResolver(kernel);
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISlienGamesData>().To<SlienGamesData>();
            kernel.Bind<ISlienGamesDbContext>().To<SlienGamesDbContext>().InSingletonScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));

            kernel.Load(new MvpNinjectModule());
            kernel.Load(new UsersNinjectModule());
            kernel.Load(new ServicesNinjectModule());
            kernel.Load(new GamesNinjectModule());
            PresenterBinder.Factory = kernel.Get<IPresenterFactory>();
        }
    }

    internal class NinjectSignalRDependencyResolver : DefaultDependencyResolver
    {
        private readonly IKernel kernel;
        public NinjectSignalRDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public override object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType) ?? base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType).Concat(base.GetServices(serviceType));
        }
    }
}
