using System.Web;
using HtmlAgilityPack;
using SeleniumScreenshotDashboard.Business.Const;
using SeleniumScreenshotDashboard.Helpers;

namespace SeleniumScreenshotDashboard.ViewModels
{
    public class BlobContentViewModel : BlobBase
    {
        /// <summary>
        /// Gets or sets the HTML.
        /// </summary>
        /// <value>
        /// The HTML.
        /// </value>
        public string Html { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobContentViewModel"/> class.
        /// </summary>
        public BlobContentViewModel()
        {
            Html = GetHtml();
        }

        /// <summary>
        /// Gets the HTM template.
        /// </summary>
        /// <returns>The innerhtml of the template</returns>
        private string GetHtml()
        {
            string subFolder = HttpContext.Current.Request["folder"];
            BlobHelper blobHelper = new BlobHelper();
            string html = blobHelper.GetContent(Constant.BlobContainer, subFolder);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode bodyNode = doc.DocumentNode.SelectSingleNode("//body");

            return bodyNode.InnerHtml;
        }
    }
}