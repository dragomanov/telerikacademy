namespace GetAllFeedsAndMakeHtml
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Channel
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        [JsonProperty(PropertyName = "item")]
        public List<Question> Questions { get; set; }
    }
}