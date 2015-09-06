using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Blob;
using SeleniumScreenshotDashboard.Business.Const;
using SeleniumScreenshotDashboard.Extensions;
using SeleniumScreenshotDashboard.Helpers;
using SeleniumScreenshotDashboard.Models.Blob;

namespace SeleniumScreenshotDashboard.ViewModels
{
    public class BlobFolderViewModel : BlobBase
    {
        public List<BlobUrl> BlobSubMenuItems { get; set; }

        public BlobFolderViewModel()
        {
            BlobSubMenuItems = GetBlobSubMenuItems();
        }

        private List<BlobUrl> GetBlobSubMenuItems()
        {
            string subFolder = HttpContext.Current.Request["folder"];

            BlobHelper blobHelper = new BlobHelper();
            List<BlobUrl> blobMenuItems = new List<BlobUrl>();
            if (string.IsNullOrEmpty(subFolder))
            {
                return blobMenuItems;
            }

            IEnumerable<IListBlobItem> blobSubMenuItems = blobHelper.GetSubMenuItems(Constant.BlobContainer, subFolder);
            blobMenuItems.AddRange(blobSubMenuItems.Select(CreateBlobFolder).OrderBy(x => x.Name.ToInt()));
            return blobMenuItems;
        }
    }
}