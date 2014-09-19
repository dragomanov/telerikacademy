namespace GetAllFeedsAndMakeHtml
{
    using System;
    using System.Linq;
    using System.Net;

    public static class Downloader
    {
        public static void Download(string path = "http://forums.academy.telerik.com/feed/qa.rss", string fileName = "../../qa.xml")
        {
            var webClient = new WebClient();
            using (webClient)
            {
                webClient.DownloadFile(path, fileName);
            }
        }
    }
}
