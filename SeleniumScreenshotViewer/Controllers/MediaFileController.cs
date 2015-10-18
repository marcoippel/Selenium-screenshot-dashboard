using System.Web.Mvc;
using SeleniumScreenshotDashboard.Business.Const;
using SeleniumScreenshotDashboard.Helpers;

namespace SeleniumScreenshotDashboard.Controllers
{
    public class MediaFileController : Controller
    {
        // GET: MediaFile
        public void Index()
        {

            string path = Request["path"];

            if (!string.IsNullOrEmpty(path))
            {
                BlobHelper blobHelper = new BlobHelper();

                var fileContents = blobHelper.GetVideo(Constant.VideoContainer, path);

                Response.Clear();
                Response.AddHeader("Content-Length", fileContents.Length.ToString());
                Response.ContentType = "video/x-ms-wmv";
                Response.AddHeader("Content-Disposition", "attachment; filename=ScreenCapture.wmv");
                Response.OutputStream.Write(fileContents, 0, fileContents.Length);
                Response.Flush();
                Response.End();
            }

            

           
        }
    }
}