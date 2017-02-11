using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

using SlienGames.Web.App_Start;

namespace SlienGames.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbConfig.InitDatabase();
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var serverError = Server.GetLastError() as HttpException;

            if (null != serverError)
            {
                int errorCode = serverError.GetHttpCode();

                if (404 == errorCode)
                {
                    Server.ClearError();
                    Server.Transfer("/Errors/PageNotFound.aspx");
                }
                else
                {
                    Server.ClearError();
                    Server.Transfer("/Errors/ErrorPage.aspx");
                }
            }
        }

    }
}