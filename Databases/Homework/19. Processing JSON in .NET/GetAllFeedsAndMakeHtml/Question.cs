namespace GetAllFeedsAndMakeHtml
{
    using Newtonsoft.Json;

    public class Question
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        [JsonProperty(PropertyName = "pubDate")]
        public string Date { get; set; }
    }
}