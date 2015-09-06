using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Blob;
using SeleniumScreenshotDashboard.Business.Const;
using SeleniumScreenshotDashboard.Helpers;
using SeleniumScreenshotDashboard.Models.Blob;

namespace SeleniumScreenshotDashboard.ViewModels
{
    public class BlobBase
    {
        public List<BlobUrl> BlobMenuItems { get; set; }
        public List<BlobUrl> BlobBreadcrumbs { get; set; }

        protected BlobBase()
        {
            BlobMenuItems = GetMenuBlobItems();
            BlobBreadcrumbs = GetBreadCrumbs();
        }

        private List<BlobUrl> GetBreadCrumbs()
        {
            string url = HttpContext.Current.Request["folder"];
            List<BlobUrl> breadcrumbs = new List<BlobUrl>();
            if (!string.IsNullOrEmpty(url))
            {
                List<string> segments = UrlSegments(url);
                string parentUrl = string.Empty;
                foreach (string segment in segments)
                {
                    parentUrl = string.IsNullOrEmpty(parentUrl) ? string.Format("{0}", segment) : string.Format("{0}/{1}", parentUrl, segment);
                    breadcrumbs.Add(new BlobUrl
                    {
                        Url = "?folder=" + parentUrl,
                        Name = segment
                    });
                }
            }

            return breadcrumbs;
        }

        private List<BlobUrl> GetMenuBlobItems()
        {
            BlobHelper blobHelper = new BlobHelper();
            List<BlobUrl> blobMenuItems =new List<BlobUrl>();
            IEnumerable<IListBlobItem> blobItems = blobHelper.GetMenuItems(Constant.BlobContainer);
            foreach (IListBlobItem blobItem in blobItems)
            {
                blobMenuItems.Add(CreateBlobFolder(blobItem));
            }

            return blobMenuItems;
        }

        protected BlobUrl CreateBlobFolder(IListBlobItem blob)
        {
            var urlSegments = UrlSegments(blob.Uri.LocalPath);
            BlobUrl blobUrl = new BlobUrl
            {
                Name = urlSegments.Last(),
                Url = string.Join("/", urlSegments.Skip(1).Take(urlSegments.Count - 1))
            };

            return blobUrl;
        }

        private static List<string> UrlSegments(string uri)
        {
            List<string> urlSegments = uri.Split('/').ToList();
            urlSegments = urlSegments.Where(x => !string.IsNullOrEmpty(x)).ToList();
            return urlSegments;
        }
    }
}