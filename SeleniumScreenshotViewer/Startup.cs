using System.IO;
using System.Web;
using log4net.Config;
using Microsoft.Owin;
using Owin;
using SeleniumScreenshotDashboard;

[assembly: OwinStartup(typeof(Startup))]

namespace SeleniumScreenshotDashboard
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var log4NetPath = HttpContext.Current.Server.MapPath("~/log4net.config");
            XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetPath));

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
