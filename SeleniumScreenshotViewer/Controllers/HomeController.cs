using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;
using SeleniumScreenshotDashboard.Business.Attributes;
using SeleniumScreenshotDashboard.Business.Const;
using SeleniumScreenshotDashboard.Helpers;
using SeleniumScreenshotDashboard.ViewModels;

namespace SeleniumScreenshotDashboard.Controllers
{
    [Error]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.Url != null && Request.Url.AbsoluteUri.EndsWith(".html"))
            {
                BlobContentViewModel blobContentViewModel = new BlobContentViewModel();
                return View("Content", blobContentViewModel);
            }

            var blobFolderViewModel = new BlobFolderViewModel();
            return View(blobFolderViewModel);
        }

        public ActionResult Delete()
        {
            BlobHelper blobHelper = new BlobHelper();
            string subFolder = Request["folder"];
            
            if (subFolder == null)
            {
                return RedirectToAction("Index");
            }

            List<IListBlobItem> blobs = blobHelper.ListBlobs(Constant.BlobContainer, subFolder);
            blobHelper.DeleteBlobs(blobs, Constant.BlobContainer);

            return RedirectToAction("Index");
            
        }
    }
}