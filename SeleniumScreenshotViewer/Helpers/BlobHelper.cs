using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SeleniumScreenshotDashboard.Helpers
{
    public class BlobHelper
    {
        private CloudStorageAccount CloudStorageAccount { get; set; }
        private List<IListBlobItem> _blobList = new List<IListBlobItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobHelper"/> class.
        /// </summary>
        /// <exception cref="Exception">There is in the appsettings no key found with name: StorageConnectionString</exception>
        public BlobHelper()
        {
            string connectionString = ConfigurationManager.AppSettings["StorageConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("There is in the appsettings no key found with name: StorageConnectionString");
            }

            CloudStorageAccount = CloudStorageAccount.Parse(connectionString);
        }

        /// <summary>
        /// Gets the menu items.
        /// </summary>
        /// <param name="folderName">Name of the folder.</param>
        /// <returns></returns>
        public IEnumerable<IListBlobItem> GetMenuItems(string folderName)
        {
            CloudBlobContainer blobContainer = CloudStorageAccount.CreateCloudBlobClient().GetContainerReference(folderName);
            return blobContainer.ListBlobs();
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <param name="folderName">Name of the folder.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public string GetContent(string folderName, string fileName)
        {
            CloudBlockBlob file = CloudStorageAccount.CreateCloudBlobClient().GetContainerReference(folderName).GetBlockBlobReference(fileName);
            return file.DownloadText();
        }

        /// <summary>
        /// Gets the sub menu items.
        /// </summary>
        /// <param name="folderName">Name of the folder.</param>
        /// <param name="subFolder">The sub folder.</param>
        /// <returns></returns>
        public IEnumerable<IListBlobItem> GetSubMenuItems(string folderName, string subFolder)
        {
            CloudBlobContainer blobContainer = CloudStorageAccount.CreateCloudBlobClient().GetContainerReference(folderName);
            return blobContainer.GetDirectoryReference(subFolder).ListBlobs();
        }

        /// <summary>
        /// Lists the blobs.
        /// </summary>
        /// <param name="folderName">Name of the folder.</param>
        /// <param name="subFolder">The sub folder.</param>
        /// <returns></returns>
        public List<IListBlobItem> ListBlobs(string folderName, string subFolder)
        {
            CloudBlobContainer blobContainer = CloudStorageAccount.CreateCloudBlobClient().GetContainerReference(folderName);
            IEnumerable<IListBlobItem> blobs = blobContainer.GetDirectoryReference(subFolder).ListBlobs();
            
            foreach (IListBlobItem blob in blobs)
            {
                if (!blob.Uri.AbsoluteUri.EndsWith(".html"))
                {
                    _blobList = ListBlobs(folderName, blob.Uri.AbsolutePath.Replace(string.Format("/{0}/", folderName), string.Empty));
                }
                else
                {
                    _blobList.Add(blob);
                }
            }

            return _blobList;
        }

        /// <summary>
        /// Deletes the blobs.
        /// </summary>
        /// <param name="blobs">The blobs.</param>
        /// <param name="folderName">Name of the folder.</param>
        public void DeleteBlobs(List<IListBlobItem> blobs, string folderName)
        {
            CloudBlobContainer blobContainer = CloudStorageAccount.CreateCloudBlobClient().GetContainerReference(folderName);

            foreach (IListBlobItem blob in blobs)
            {
                CloudBlockBlob cloudBlobBlock = blobContainer.GetBlockBlobReference(blob.Uri.AbsolutePath.Replace(string.Format("/{0}/", folderName), string.Empty));
                cloudBlobBlock.DeleteIfExistsAsync();
            }
            

        }
    }
}