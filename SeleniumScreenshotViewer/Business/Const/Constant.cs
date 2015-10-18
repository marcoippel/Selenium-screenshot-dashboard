using System.Configuration;

namespace SeleniumScreenshotDashboard.Business.Const
{
    public class Constant
    {
        public static string BlobContainer = ConfigurationManager.AppSettings["BlobContainer"];
        public static string VideoContainer = ConfigurationManager.AppSettings["VideoContainer"];
    }
}