using log4net.Config;
using NationwideNannies.Logging;
using NationwideNannies.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NationwideNannies
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));

            Utilities.CreateFolder(Constants.FolderUploadedResumes);
            Utilities.CreateFolder(Constants.FolderUploadedPhotos);

            Log4NetLogger.WriteLog(LogLevel.Info, "Application start!!");
           
        }
    }
}
