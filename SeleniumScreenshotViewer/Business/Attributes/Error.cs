using System.Web.Mvc;
using log4net;

namespace SeleniumScreenshotDashboard.Business.Attributes
{
    public class Error : HandleErrorAttribute
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Error).FullName);
        public override void OnException(ExceptionContext filterContext)
        {
            log.Error("Unhandled error", filterContext.Exception);
        }
    }
}