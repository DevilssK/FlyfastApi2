using FlyFast.API.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FlyFast.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        #region [Logger]
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger.Info("----------------------------------------------------------Lancement Application Web Star ------------------------------------------------");
            _logger.Info($"Lancement  {Process.GetCurrentProcess().ProcessName} in console mode");


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CACHE.LoadData();
        }
    }
}
