namespace GetAllFeedsAndMakeHtml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Using JSON.NET and the Telerik Academy Forums RSS feed implement the following:
    /// 1. The RSS feed is at http://forums.academy.telerik.com/feed/qa.rss 
    /// 2. Download the content of the feed programmatically
    /// You can use WebClient.DownloadFile()
    /// 3. Parse the XML from the feed to JSON
    /// 4. Using LINQ-to-JSON select all the question titles and print them to the console
    /// 5. Parse the JSON string to POCO
    /// 6. Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question's page
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Downloader.Download();

            var rssFeedXml = XElement.Load("../../qa.xml");

            var rssFeedJson = JsonConvert.SerializeXNode(rssFeedXml);

            PrintAllQuestionTitles(rssFeedJson);

            var pocoFromJson = JsonConvert.DeserializeObject<RssFeed>(rssFeedJson);

            CreateHtml(pocoFromJson);
        }

        private static void CreateHtml(RssFeed feed)
        {
            // this is not optimal but I just dont have time to do it with T4 templates.

            var resultHtml = new StringBuilder(500);

            resultHtml.Append(@"<!DOCTYPE html><html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml""><head><meta charset=""utf-8"" /><title>Telerik JSON Homework</title></head><body><h1>Telerik RSS Feed</h1><ul>");

            foreach (var question in feed.Rss.Channel.Questions)
            {
                string formatString = @"<li>Title: {0}</li><li>Category: {1}</li><li>Link: {2}</li>";
                resultHtml.Append(string.Format(formatString, question.Title, question.Category, question.Link));
            }

            resultHtml.Append(@"</ul></body></html>");
            File.WriteAllText("../../forum-feed.html", resultHtml.ToString());
        }

        private static void PrintAllQuestionTitles(string rssFeedJson)
        {
            var jObjectRssFeed = JObject.Parse(rssFeedJson);

            var titles = jObjectRssFeed["rss"]["channel"]["item"].Select(it => it["title"]);
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
