using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SeleniumScreenshotDashboard.Models.Blob
{
    public class BlobModel
    {
        public IEnumerable<IListBlobItem> BlobMenuItems { get; set; }
        public IEnumerable<IListBlobItem> BlobMenuSubItems { get; set; }
    }
}